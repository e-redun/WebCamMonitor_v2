using MyLib.Models;
using MyLib.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MyLib.Controls.VideoPlayers
{
    [Serializable]
    public partial class VideoPlayer : UserControl
    {
        // делегат фотографирования
        public delegate void TakeSnapshot(ChannelModel channel, Image image, UserControl thisPlayer);
        public TakeSnapshot TakeSnapshotDelegate;

        // состояние плеера
        State _playerState;

        // сопоставленный канал
        ChannelModel _channel;

        /// <summary>
        /// Задает/возвращает сопоставленный плееру канал 
        /// </summary>
        public ChannelModel Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                _channel = value;

                // обработка после назначения канала
                ProcessChannelAssignment(_channel);
            }
        }

        /// <summary>
        /// Описание канала
        /// </summary>
        public string ChannelDescription { get; set; }

        /// <summary>
        /// Отображаемая картинка (экран) плеера
        /// </summary>
        public Image Picture
        {
            get
            {
                return pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
            }
        }

        /// <summary>
        /// Состояние плеера
        /// </summary>
        public State PlayerState
        {
            get
            {
                return _playerState;
            }
            set
            {
                _playerState = value;

                // Переключение кнопок Старт/Стоп
                ToggleStartStopButtonImage();
                ToggleOnOffLabel();
            }
        }

        /// <summary>
        /// Выполняет действия после назначения нового канала
        /// </summary>
        /// <param name="channel"></param>
        internal virtual void ProcessChannelAssignment(ChannelModel channel)
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

                // пописка на состояние канала
                Channel.ChannelStateEvent += ChannelStateEventHandler;

                // установка контролов видимыми
                SetControlsVisible();
            }
        }

        private void ChannelStateEventHandler(State channelState)
        {
            PlayerState = channelState;
        }

        internal virtual void SetPlayerToInitialState()
        {
        }

        /// <summary>
        /// Делает все контролы кроме PictureBox видимыми
        /// </summary>
        internal void SetControlsVisible()
        {
            // получение списка всех контролов расположенных в SplitCotainer без SplitterPanel
            List<Control> controls = ControlProcessor.GetAllControlsExceptType(splitContainer, typeof(SplitterPanel));

            // исключение pictureBox
            if (controls.Contains(pictureBox))
            {
                controls.Remove(pictureBox);
            }

            foreach (var control in controls)
            {
                control.Visible = true;
                control.Parent = pictureBox;
            }
        }

        /// <summary>
        /// Делает все контролы кроме PictureBox видимыми
        /// </summary>
        internal void SetControlsInvisible()
        {
            // получение списка всех контролов расположенных в SplitCotainer без SplitterPanel
            List<Control> controls = ControlProcessor.GetAllControlsExceptType(splitContainer, typeof(SplitterPanel));

            // исключение pictureBox
            if (controls.Contains(pictureBox))
            {
                controls.Remove(pictureBox);
            }

            foreach (var control in controls)
            {
                control.Visible = false;
                //control.Parent = pictureBox;
            }
        }
        /// <summary>
        /// Переключает картинку на кнопке buttonStartStop
        /// </summary>
        public virtual void ToggleStartStopButtonImage()
        {
            if (PlayerState == State.Off)
            {
                buttonStartStop.Image = global::MyLib.Properties.Resources.playIconRed;
            }
            else
            {
                buttonStartStop.Image = global::MyLib.Properties.Resources.stopIconGreen;
            }
        }

        /// <summary>
        /// Переключает метку labelState
        /// </summary>
        public void ToggleOnOffLabel()
        {
            labelState.Text = PlayerState.ToString();

            switch (PlayerState)
            {
                case State.Off:
                    labelState.ForeColor = Color.YellowGreen;
                    break;
                case State.On:
                    labelState.ForeColor = Color.Red;
                    break;
                case State.Starting:
                    labelState.ForeColor = Color.Orange;
                    break;
            }
        }

        #region Drag & Drop
        public void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                if (Channel != null)
                {
                    DoDragDrop(Channel, DragDropEffects.Link);
                }
            }
        }
        #endregion

        /// <summary>
        /// Обработчик получения нового кадра из канала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ChannelPictureRefreshHandler(object sender, EventArgs e)
        {
            if (PlayerState == State.On)
            {
                Picture = Channel.Picture;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public VideoPlayer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Делает снимок канала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeSnapshot_Click(object sender, EventArgs e)
        {
            if (Channel != null)// && Channel.ChannelState == State.On)
            {
                TakeSnapshotDelegate?.Invoke(Channel, Picture, this);
            }
        }

        /// <summary>
        /// Переключает состояние плеера Start/Stop
        /// </summary>
        public virtual void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (PlayerState == State.Off)
            {
                // состояние плеера Стартую
                PlayerState = State.Starting;
                labelState.Refresh();

                // команда на старт канала
                Channel.StartChannel();
            }
            else
            {
                // команда на останов канала
                Channel.StopChannel();
            }
        }

        public virtual void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // самовыпиливание из пакета каналов
                Channel.ChannelPackage.Channels.Remove(Channel);

                // диспозинг канала
                Channel.Dispose();

                // диспозинг плеера
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        #region Подсказки
        internal virtual void buttonStartStop_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPlayersTips.StartStopChannel);
        }

        internal virtual void buttonTakeSnapshot_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPlayersTips.TakeSnapshot);

        }
        internal virtual void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPlayersTips.DeleteChannel);
        }
        #endregion
    }
}