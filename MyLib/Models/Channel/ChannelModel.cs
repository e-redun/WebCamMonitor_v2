using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MyLib.Processors.MJPEG;

namespace MyLib.Models
{
    /// <summary>
    /// Описывает простой (Прочий) канал
    /// </summary>
    public abstract class ChannelModel : IDisposable
    {
        // состояние канала
        State _channelState;

        // ссылка на поток
        string _channelLink;

        // MJPEGProcessor (обработчик) потока
        MJPEGProcessorModel MJPEGProcessor;

        /// <summary>
        /// Событие обновления картинки
        /// </summary>
        public event EventHandler<EventArgs> PictureRefresh;

        /// <summary>
        /// Событие перевода плеера в первоначальное состояние
        /// </summary>
        public event Action SetPlayerToInitialState;

        /// <summary>
        /// Собщение подписчикам о своем состоянии
        /// </summary>
        public event Action<State> ChannelStateEvent;

        /// <summary>
        /// Пакет каналов
        /// </summary>
        public IChannelPackage ChannelPackage { get; set; }
        
        /// <summary>
        /// Имя канала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание канала
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на поток
        /// </summary>
        public string ChannelLink
        {
            get
            {
                return _channelLink;
            }
            set
            {
                _channelLink = value;
                MJPEGProcessor.Uri = _channelLink;
            }
        }
        
        /// <summary>
        /// Картинка канала
        /// </summary>
        public Image Picture { get; set; }



        public ChannelModel()
        {
            MJPEGProcessor = LibFactory.CreateMJPEGProcessor();
            
            // подписка на изменение состояния MJPEGProcessor-а
            MJPEGProcessor.ProcessorStateEvent += ProcessorStateEventHandler;
            
            // подписка на новый готовый кадр MJPEGProcessor-а
            MJPEGProcessor.FrameReady += MJPEGProcessorFrameReadyHandler;
        }

        /// <summary>
        /// Обработчик состояния процессора
        /// </summary>
        /// <param name="processorState"></param>
        private void ProcessorStateEventHandler(State processorState)
        {
            ChannelState = processorState;
        }

        /// <summary>
        /// Обработчик события получения готового фрейма для передечи каналу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MJPEGProcessorFrameReadyHandler(object sender, FrameReadyEventArgs e)
        {
            if (ChannelState == State.On)
            {
                // картинке канала присваиватся фрейм/картинка MJPEGProcessor-а
                Picture = e.Bitmap;
                // вызов события обновления картинки канала
                PictureRefresh?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Состояние канала
        /// </summary>
        public State ChannelState
        {
            get
            {
                return _channelState;
            }
            set
            {
                _channelState = value;
                // вызов события Изменение состояния канала
                ChannelStateEvent?.Invoke(ChannelState);
            }
        }

        /// <summary>
        /// Старт канала
        /// </summary>
        /// <param name="action">Обратный вызов состояния канала</param>
        public void StartChannel()
        {
            // старт процессинга стрима
            MJPEGProcessor.StartStreaming();
        }

        /// <summary>
        /// Останов канала
        /// </summary>
        /// <param name="action">Обратный вызов состояния канала</param>
        public void StopChannel()
        {
            // Останов обработки потока
            MJPEGProcessor.StopStreaming();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

       // public bool Disposing { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            //Disposing = disposing;

            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).

                    // обнуление события обновления картинки канала
                    this.PictureRefresh = null;

                    // остановка MJPEGProcessor-a
                    MJPEGProcessor.StopStreaming();

                    // вызов установки плеера в первоначальное состояние
                    SetPlayerToInitialState?.Invoke();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~ChannelModel() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion



    }
}