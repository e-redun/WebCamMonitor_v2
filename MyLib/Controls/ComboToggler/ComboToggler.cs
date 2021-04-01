using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyLib.Processors;
using MyLib.Models;
using MyLib.Controls.VideoPlayers;
using System.Reflection;
using System.ComponentModel;

namespace MyLib.Controls
{
    public partial class ComboToggler : UserControl, IComboToggler
    {
        // Текст контрола
        string _text;
        // состояние контрола
        ExpColState _state;

        // Каналы // выделены из пакета отдельно для отслеживания события добавления канала
        BindingList<ChannelModel> Channels;

        // Пакет каналов = Каналы + Имя + Описание ....
        IChannelPackage _channelPackage;

        /// <summary>
        /// Текст контрола
        /// </summary>
        public override string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                buttonToggler.Text = _text;
            }
        }

        /// <summary>
        /// Возвращает/задает направление указателя раскрытия
        /// </summary>
        ExpandDirection _expandDirection;

        /// <summary>
        /// Возвращает/устанавливает список плееров
        /// </summary>
        public BindingList<VideoPlayer> ChannelPlayers { get; set; }
        
        /// <summary>
        /// Возвращает/устанавливает пакет каналов
        /// </summary>
        public IChannelPackage ChannelPackage
        {
            get
            {
                return _channelPackage;
            }
            set
            {
                _channelPackage = value;
                // назначение каналов для отслеживания событий списка Channels
                Channels =_channelPackage.Channels;
            }
        }

        /// <summary>
        /// Состояние включено/выключено
        /// </summary>
        public ExpColState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                StateChangeHandler();
            }
        }

        /// <summary>
        /// Направление раскрытия
        /// </summary>
        public ExpandDirection ExpandDirection
        {
            get
            {
                return _expandDirection;
            }
            set
            {
                _expandDirection = value;
                SetIcon();
            }
        }

        /// <summary>
        /// Иконка на кнопке переключателя
        /// </summary>
        public Image Icon
        {
            get
            {
                return buttonToggler.Image;
            }
            set
            {
                buttonToggler.Image = value;
            }
        }

        /// <summary>
        /// Событие раскрытия ComboToggler-а
        /// </summary>
        public event EventHandler<EventArgs> ComboTogglerExpantion;

        /// <summary>
        /// Запрос на Dispose
        /// </summary>
        public event EventHandler<EventArgs> DisposeRequest;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="channelPackage"></param>
        public ComboToggler(IChannelPackage channelPackage)
        {
            InitializeComponent();

            // назначение пакета каналов
            ChannelPackage = channelPackage;

            // список плееров
            ChannelPlayers = new BindingList<VideoPlayer>();

            // подписка на обработку измений в списке ChannelPlayers
            ChannelPlayers.ListChanged += ChannelPlayers_ListChanged;

            // подписка на изменения в списке Channels
            Channels.ListChanged += Channels_ListChanged;

            // первоначальное состояние
            State = ExpColState.Collapsed;

        }
        /// <summary>
        /// Обработчик события изменения в Channels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Channels_ListChanged(object sender, ListChangedEventArgs e)
        {
            // добавление
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                // создание нового канала
                CreateAndAddChannelPlayer(Channels[e.NewIndex]);
            }
        }

        /// <summary>
        /// Обработчик изменения списка ChannelPlayers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelPlayers_ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<VideoPlayer> channelPlayers = (BindingList<VideoPlayer>)sender;

            // самоликвидация
            if (channelPlayers.Count < 1)
            {
                //TODO переделка ComboToggler InVisible/ Dispose
                //запрос в ChannelDashboard на удаление
                DisposeRequest?.Invoke(this, new EventArgs());

                ////// сделать ComboToggler невидимым и свернуть
                //this.Visible = false;
                //this.State = ExpColState.Collapsed;
            }
            else
            {
                this.Visible = true;
            }
        }

        /// <summary>
        /// Установка иконки в зависимости от направления разворота и состояния
        /// </summary>

        private void SetIcon()
        {  
            if (State == ExpColState.Collapsed) // если выключено = свернуто
            {
                switch (ExpandDirection)
                {
                    case ExpandDirection.Left:
                        Icon = global::MyLib.Properties.Resources.arrowLeftIcon;
                        break;
                    case ExpandDirection.Up:
                        Icon = global::MyLib.Properties.Resources.arrowUpIcon;
                        break;
                    case ExpandDirection.Right:
                        Icon = global::MyLib.Properties.Resources.arrowRightIcon;
                        break;
                    case ExpandDirection.Down:
                        Icon = global::MyLib.Properties.Resources.arrowDownIcon;
                        break;
                }
            }
            else
            {
                switch (ExpandDirection)
                {
                    case ExpandDirection.Left:
                        Icon = global::MyLib.Properties.Resources.arrowRightIcon;
                        break;
                    case ExpandDirection.Up:
                        Icon = global::MyLib.Properties.Resources.arrowDownIcon;
                        break;
                    case ExpandDirection.Right:
                        Icon = global::MyLib.Properties.Resources.arrowLeftIcon;
                        break;
                    case ExpandDirection.Down:
                        Icon = global::MyLib.Properties.Resources.arrowUpIcon;
                        break;
                }
            }
            buttonToggler.Refresh();
        }
        private void buttonToggler_Click(object sender, EventArgs e)
        {
            // переключение состояния Переключателя (ComboToggler)
            if (State == ExpColState.Expanded)
            {
                State = ExpColState.Collapsed;
            }
            else
            {
                State = ExpColState.Expanded;
            }
        }

        /// <summary>
        /// Обработчик изменения состояния ComboToggler
        /// </summary>
        private void StateChangeHandler()
        {            
            if (State == ExpColState.Expanded)
            {
                // установка панели плееров видимой
                panelPlayers.Visible = true;

                // вызов события раскрытия ComboToggler
                ComboTogglerExpantion?.Invoke(this, new EventArgs());
            }
            else
            {
                // установка панели плееров невидимой
                panelPlayers.Visible = false;
            }

            // установка иконки
            SetIcon();
        }
 

        /// <summary>
        /// Создает плеер и добавляет в список плееров ChannelPlayers
        /// </summary>
        /// <param name="channel"></param>
        internal void CreateAndAddChannelPlayer(ChannelModel channel)
        {
            // новый плеер
            VideoPlayer channelPlayer = LibFactory.CreateChannelVideoPlayer();
            
            // подписка на самоликвидацию плеера
            channelPlayer.Disposed += ChannelPlayer_Disposed;
            
            // присвоение плееру ссылки на канал
            channelPlayer.Channel = channel;

            // занесение в список
            ChannelPlayers.Add(channelPlayer);

            channelPlayer.Dock = DockStyle.Bottom;

            // добавление на панель
            panelPlayers.Controls.Add(channelPlayer);
        
            panelPlayers.Refresh();
        }

        /// <summary>
        /// Обработчик события самоликвидации канального плеера ChannelVideoPlayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelPlayer_Disposed(object sender, EventArgs e)
        {
            VideoPlayer videoPlayer = (VideoPlayer)sender;
            // самоудаление из списка
            ChannelPlayers.Remove(videoPlayer);
        }
    }
}
