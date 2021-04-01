using System;
using System.Windows.Forms;
using MyLib.Models;
using MyLib.Processors;
using System.Reflection;

namespace MyLib.Controls.VideoPlayers
{
    public partial class MonitorVideoPlayer : VideoPlayer
    {
        PictureBoxSizeMode _playerSizeMode;
        
        /// <summary>
        /// Режим плеера
        /// </summary>
        public PictureBoxSizeMode PlayerSizeMode
        {
            get
            {
                return _playerSizeMode;
            }
            set
            {
                _playerSizeMode = value;
                pictureBox.SizeMode = _playerSizeMode;
            }
        }

        /// <summary>
        /// Последний выбранный пункт меню
        /// </summary>
        private int lastSelectedMenuItem { get; set; }

        public MonitorVideoPlayer()
        {
            InitializeComponent();

            // разрешение Drag & Drop
            pictureBox.AllowDrop = true;

            // сокрытие Panel2 splitContainerS
            splitContainer.Panel2Collapsed = true;

            // инициализация контекстного меню
            InitializeMenu();

            // контекстное меню
            pictureBox.ContextMenuStrip = contextMenuStrip;
        }

        /// <summary>
        /// Инициализирует контекстное меню
        /// </summary>
        private void InitializeMenu()
        {
            // создание пунктов меню
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("Normal", "Normal", false));
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("StretchImage", "Stretch", false));
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("CenterImage", "Center", false));
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("Zoom", "Zoom", false));

            //contextMenuStrip.Click += Test;

            // подписка
            foreach (ToolStripMenuItem menuItem in contextMenuStrip.Items)
            {
                menuItem.Click += SizeModeItemClickHandler;
            }
        }

        private void Test(object sender, EventArgs e)
        {
            contextMenuStrip.Items[lastSelectedMenuItem].Select();
        }

        private void SizeModeItemClickHandler(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            switch (menuItem.Name)
            {
                case "Normal":
                    PlayerSizeMode = PictureBoxSizeMode.Normal;
                    break;
                case "StretchImage":
                    PlayerSizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case "CenterImage":
                    PlayerSizeMode = PictureBoxSizeMode.CenterImage;
                    break;
                case "Zoom":
                    PlayerSizeMode = PictureBoxSizeMode.Zoom;
                    break;
                default:
                    break;
            }
        }

        public override void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (PlayerState == State.Off)
            {
                PlayerState = State.On;
            }
            else
            {
                PlayerState = State.Off;
            }
        }

        public override void ToggleStartStopButtonImage()
        {
            if (PlayerState == State.Off)
            {
                buttonStartStop.Image = global::MyLib.Properties.Resources.playIconRed;
            }
            else
            {
                buttonStartStop.Image = global::MyLib.Properties.Resources.pauseIconOrange;
            }
        }

        #region Drag & Drop
        public void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MainChannelModel)) || e.Data.GetDataPresent(typeof(OtherChannelModel)))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        public void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // главные каналы // TODO при прочих каналах OtherChannelModel возникает ошибка ... непонятно почему
                if (e.Data.GetData(typeof(MainChannelModel)).GetType() == typeof(MainChannelModel))
                {
                    if (Channel != null)
                    {
                        // отписка от события получения нового кадра (отмена старой подписки)
                        Channel.PictureRefresh -= ChannelPictureRefreshHandler;
                    }

                    Channel = (ChannelModel)e.Data.GetData(typeof(MainChannelModel));
                }
                else // Прочие 
                {
                    if (Channel != null)
                    {
                        // отписка от события получения нового кадра (отмена старой подписки)
                        Channel.PictureRefresh -= ChannelPictureRefreshHandler;
                    }

                    Channel = (ChannelModel)e.Data.GetData(typeof(OtherChannelModel));
                }
                // TODO переделать на передачу плеера а// передача плееру состояния канала
                PlayerState = Channel.ChannelState;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }
        #endregion

        /// <summary>
        /// Перевод плеера в первоначальное состояние (отклчение канала)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void buttonDelete_Click(object sender, EventArgs e)
        {
            SetPlayerToInitialState();
        }

        #region Обработка наведения курсора (Подсказки)
        internal override void buttonStartStop_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.MonitorPlayersTips.StartStopPlayer);
        }

        internal override void buttonTakeSnapshot_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.MonitorPlayersTips.TakeSnapshot);
        }

        internal override void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.MonitorPlayersTips.DisconnectChannel);

        }
        #endregion

        /// <summary>
        /// Выполняет действия после назначения нового канала
        /// </summary>
        /// <param name="channel"></param>
        internal override void ProcessChannelAssignment(ChannelModel channel)
        {
            if (channel == null)
            {
            }
            else
            {
                // описание канала
                ChannelDescription = Channel.Description;

                // метка описания канала
                labelChannelDescription.Text = ChannelDescription;

                // текущая картинка канала
                Picture = Channel.Picture;

                // подписка на обновление картинки канала
                Channel.PictureRefresh += ChannelPictureRefreshHandler;

                // подписка на установку плеера в первоначальное состояние
                // после Dispose канала
                Channel.SetPlayerToInitialState += SetPlayerToInitialState;

                // установка контролов видимыми
                SetControlsVisible();
            }
        }


        /// <summary>
        /// Переводит плеер в первоначальное состояние
        /// </summary>
        internal override void SetPlayerToInitialState()
        {
            // состояние плеера 
            PlayerState = State.Off;

            // описание канала
            ChannelDescription = "";

            // метка описания канала
            labelChannelDescription.Text = ChannelDescription;

            // отписка от обновления картинки канала
            //Channel.PictureRefresh -= ChannelPictureRefreshHandler;

            // установка элементов невидимыми
            SetControlsInvisible();

            // установка первоначальной картинки
            Picture = pictureBox.InitialImage;

            // удаление ссылки на канал
            Channel = null; // TODO Channel = null; 
        }
    }
}
