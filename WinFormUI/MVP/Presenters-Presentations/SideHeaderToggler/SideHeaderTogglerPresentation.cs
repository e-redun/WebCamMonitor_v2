using System;
using System.Windows.Forms;
using MyLib.Views;
using WebCamMonitor.Presenters;

namespace WebCamMonitor
{
    public partial class FormMain : IChannelToggler
    {
        private void FormMain_Load_ChannelTogglerPresentation()
        {
            // инициализация ToggleChannel
            InitializeToggleChannel();
        }

        #region ToggleChannel
        private void InitializeToggleChannel()
        {

            // инициализация текста кнопки
            // стрелка вправо
            buttonToggleChannel.Text = '\x7D'.ToString();
        }

        private void buttonToggleChannel_Click(object sender, EventArgs e)
        {
            // скрытие/открытие панели каналов

            ChannelTogglerPresenter presenterChannel = new ChannelTogglerPresenter(this);
            presenterChannel.ToggleSplitContainerPanel();
            presenterChannel.ToggleButtonSign();

        }
        public SplitContainer splitContainer
        {
            get
            {
                return splitContainerFormMain;
            }
        }
        public Button toggleButton
        {
            get
            {
                return buttonToggleChannel;
            }
        }
        #endregion

    }
}
