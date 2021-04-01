using System;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MyLib.Processors;
using System.Reflection;

namespace MyLib.Processors.MJPEG
{
    public abstract class MJPEGProcessorModel
    {
        // состояние процессора
        State _processorState;

        public event Action<State> ProcessorStateEvent;

        public string Uri { get; set; }

        private readonly byte[] JpegHeader = new byte[] { 0xff, 0xd8 };

        private const int ChunkSize = 1024;

        public State ProcessorState
        {
            get
            {
                return _processorState;
            }
            set
            {
                _processorState = value;
                // вызов события изменения состояния
                if (_processorState == State.On || _processorState == State.Off)
                ProcessorStateEvent?.Invoke(_processorState);
            }
        }

        
        public SynchronizationContext Context { get; set; }

        public event EventHandler<FrameReadyEventArgs> FrameReady;
        public Bitmap Bitmap { get; set; }

        public MJPEGProcessorModel()
        {
            // контекст синхронизации
            Context = SynchronizationContext.Current;
        }

        /// <summary>
        /// Запускает процесс запроса на видеопоток и его обработки
        /// </summary>
        public void StartStreaming()
        {
            try
            {
                if (ProcessorState != State.On)
                {
                    // перевод процессора в состояние Стартую
                    ProcessorState = State.Starting;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);

                    request.BeginGetResponse(new AsyncCallback(OnGetResponse), request);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
                ProcessorState = State.Off;
                return;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        private void OnGetResponse(IAsyncResult asyncResult)
        {
            byte[] imageBuffer = new byte[ChunkSize * ChunkSize];

            // получение ответа
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);

                using (Stream stream = response.GetResponseStream())
                {

                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        byte[] buff = binaryReader.ReadBytes(ChunkSize);
                        // поиск boundaryString
                        string boundaryString = System.Text.Encoding.UTF8.GetString(buff, 0, 30);
                        boundaryString = boundaryString.Remove(boundaryString.IndexOf("\r\n"));

                        byte[] boundaryBytes = Encoding.UTF8.GetBytes(boundaryString);

                        while (ProcessorState == State.Starting || ProcessorState == State.On)
                        {
                            // нахождение начальной границы JPEG фрейма
                            int imageStart = buff.Find(JpegHeader);

                            if (imageStart != -1)
                            {
                                // копирование начала кадра JPEG в буфер imageBuffer
                                int size = buff.Length - imageStart;
                                Array.Copy(buff, imageStart, imageBuffer, 0, size);

                                while (true)
                                {
                                    buff = binaryReader.ReadBytes(ChunkSize);

                                    // нахождение конечной границы JPEG фрейма
                                    int imageEnd = buff.Find(boundaryBytes);
                                    if (imageEnd != -1)
                                    {
                                        // copy the remainder of the JPEG to the imageBuffer
                                        Array.Copy(buff, 0, imageBuffer, size, imageEnd);
                                        size += imageEnd;

                                        //получение JPEG фрейма
                                        byte[] frame = new byte[size];
                                        Array.Copy(imageBuffer, 0, frame, 0, size);

                                        // переключение процессора в состоянии On
                                        if (ProcessorState == State.Starting)
                                        {
                                            // переключение процессора в состоянии On
                                            ProcessorState = State.On;
                                        }
                                        //отправка JPEG фрейма
                                        PostFrame(frame);

                                        // копирование оставшихся данных в начало
                                        Array.Copy(buff, imageEnd, buff, 0, buff.Length - imageEnd);

                                        // заполнение оставшейся части буфера новыми данными
                                        byte[] temp = binaryReader.ReadBytes(imageEnd);

                                        Array.Copy(temp, 0, buff, buff.Length - imageEnd, temp.Length);
                                        break;
                                    }

                                    Array.Copy(buff, 0, imageBuffer, size, buff.Length);
                                    size += buff.Length;
                                }
                            }
                        }
                    }
                }
                response.Close();
            }

            catch (WebException ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex) + "\n\n" +
                                MessageProcessor.WebExceptionStatuses(ex.Status.ToString()));

                ProcessorState = State.Off;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));

                ProcessorState = State.Off;
                return;
            }
        }

        /// <summary>
        /// Останавливает MJPEGProcessor
        /// </summary>
        public void StopStreaming()
        {
            // останов процессора
            ProcessorState = State.Off;
        }

        /// <summary>
        ///  Отправляет асинхронное сообщение о готовности кадра в UI-контекст (каналу)
        /// </summary>
        /// <param name="frame">JPEG-кадр</param>
        private void PostFrame(byte[] frame)
        {
            Context.Post(delegate{
                                    Bitmap = new Bitmap(new MemoryStream(frame));
                                    FrameReady?.Invoke(this, new FrameReadyEventArgs { Bitmap = Bitmap });},
                                null);
        }
    }
}