using System;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MyLib.Services;

namespace MyLib.Processors
{
    public partial class MJPEGProcessor3 : IMJPEGProcessor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        public Image Snapshot { get; set; }
        public WebHeaderCollection WebHeaders { get; set; }
        public int FrameLengthStartPos { get; set; }
        public int JpegFrameStartPos { get; set; }

        private readonly byte[] JpegHeader = new byte[] { 0xff, 0xd8 };

        private const int ChunkSize = 1024;

        public State State = State.Off;

        //private SynchronizationContext context;
        public SynchronizationContext Context { get; set; }

        public event EventHandler<FrameReadyEventArgs> FrameReady;
        
        public Bitmap Bitmap { get; set; }
        public State ProcessorState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MJPEGProcessor3()
        {
            //context = SynchronizationContext.Current;
        }

        //async 
        public void StartStreaming()
        {
            if (State == State.Off)
            {
                MessageBox.Show("if (State == State.Off)");
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
                    WebResponse response;
                    using (response = request.GetResponse())
                    { 
                        byte[] imageBuffer = new byte[ChunkSize * ChunkSize];

                        using (Stream stream = response.GetResponseStream())
                        {
                            using (BinaryReader binaryReader = new BinaryReader(stream))
                            {
                                byte[] buff = binaryReader.ReadBytes(ChunkSize);
                                // поиск boundaryString
                                string boundaryString = System.Text.Encoding.UTF8.GetString(buff, 0, 30);
                                boundaryString = boundaryString.Remove(boundaryString.IndexOf("\r\n"));

                                byte[] boundaryBytes = Encoding.UTF8.GetBytes(boundaryString);

                                // переключение режима
                                State = State.On;

                                while (State == State.On)
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
                                                //обработка JPEG фрейма
                                                ProcessFrame(frame);

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
                            } //  using (BinaryReader binaryReader = new BinaryReader(stream))
                        } // using (Stream stream = response.GetResponseStream())
                    } // using (WebResponse response = request.GetResponse())
                    response.Close();
                } // try
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message + "." + Environment.NewLine + Environment.NewLine +
                                    Messenger.WebExceptionStatuses(ex.Status.ToString()));
                    return;
                }
            }
        }

        public void StopStreaming()
        {
            //   MessageBox.Show("StopStreaming() call");
            State = State.Off;
        }

        private void ProcessFrame(byte[] frame)
        {
            //MessageBox.Show("private void ProcessFrame call");
            Context.Post(delegate
            {
                Bitmap = new Bitmap(new MemoryStream(frame));
                FrameReady?.Invoke(this, new FrameReadyEventArgs { Bitmap = Bitmap });
            },
                                null);

            //Bitmap = new Bitmap(new MemoryStream(frame));
            //FrameReady?.Invoke(this, new FrameReadyEventArgs { Bitmap = Bitmap });
        }

        public void StartStreaming(Action action)
        {
            throw new NotImplementedException();
        }
    }
}