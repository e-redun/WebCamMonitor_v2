using System;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MyLib.Processors
{
    public partial class MJPEGProcessor : IMJPEGProcessor
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

        public bool streamActive;

        private SynchronizationContext context;

        public event EventHandler<FrameReadyEventArgs> FrameReady;

        public event EventHandler<ErrorEventArgs> Error;

        public Bitmap Bitmap { get; set; }



        public MJPEGProcessor()
        {
            context = SynchronizationContext.Current;
        }

        public void StartStreaming()
        {
            StartStreaming(null, null);
        }
        public void StartStreaming(string Username)
        {
            StartStreaming(Username, null);
        }
        //async 
            public void StartStreaming(string Username, string password)
        {
           // MessageBox.Show("GetStream " + Name);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            if (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Password))
                request.Credentials = new NetworkCredential(Username, password);

            //await 
                //Task.Run(() => { request.BeginGetResponse(OnGetResponse, request); });
            request.BeginGetResponse(OnGetResponse, request);
        }

        private void OnGetResponse(IAsyncResult asyncResult)
        {

            byte[] imageBuffer = new byte[1024 * 1024];

            // получение ответа
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);

                Stream stream = response.GetResponseStream();

                BinaryReader binaryReader = new BinaryReader(stream);

                byte[] buff = binaryReader.ReadBytes(ChunkSize);

                // поиск boundaryString
                string boundaryString = System.Text.Encoding.UTF8.GetString( buff, 0, 30);
                boundaryString = boundaryString.Remove(boundaryString.IndexOf("\r\n"));

                byte[] boundaryBytes = Encoding.UTF8.GetBytes(boundaryString);

                streamActive = true;
                

                while (streamActive)
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

                response.Close();
           
            }
            catch (Exception ex)
            {
                if (Error != null)
                    context.Post(delegate { Error(this, new ErrorEventArgs() { Message = ex.Message }); }, null);
                return;
            }
        }

        public void StopStreaming()
        {
         //   MessageBox.Show("StopStreaming() call");
            streamActive = false;
        }

        private void ProcessFrame(byte[] frame)
        {
            context.Post(delegate
            {
                Bitmap = new Bitmap(new MemoryStream(frame));
                FrameReady?.Invoke(this, new FrameReadyEventArgs { Bitmap = Bitmap });
            }, null);
        }
    }
}