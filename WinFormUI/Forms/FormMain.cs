using System;
using System.Windows.Forms;
using MyLib.Models;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Controls.TabPages;
using MyLib;

namespace WebCamMonitor
{
    public partial class FormMain : Form
    {

        // пакет Главных каналов вещания
        IChannelPackage mainChannelPackage;

        // пакет Прочих каналов вещания
        IChannelPackage otherChannelPackage;

        public FormMain()
        {
            InitializeComponent();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // загрузка общих установок
            FormMain_Load_General();

            // загрузка Прочих установок
            FormMain_Load_OtherSettings();

            // загрузка установок для MainChannelsLoadingPresentation
            FormMain_Load_MainChannelLoadingPresentation();

            // загрузка установок для OtherChannelsLoadingPresentation
            FormMain_Load_OtherChannelLoadingPresentation();

            // загрузка установок для ChannelTogglerPresentation
            FormMain_Load_ChannelTogglerPresentation();

            // загрузка установок для ChannelsDashboardPresentation
            FormMain_Load_ChannelDashboardPresentation();

            // автозагрузка каналов
            AutoLoadAllChannels();
        }


        private void FormMain_Load_General()
        {
            // распахнуть форму на весь экран
            this.WindowState = FormWindowState.Maximized;

            // пакет Главных каналов
            mainChannelPackage = Factory.CreateChannelPackage("MainChannels", "Главные");

            // пакет Прочих каналов
            otherChannelPackage = Factory.CreateChannelPackage("OtherChannels", "Прочие");

            // подписка на вызов формы редактирования настроек страниц Мониторов
            tabControlMonitors.SettingsSelectionDelegate += EditMonitorPageHandler;

            // Инициализация ListBoxSettingsPages (меню настроек)
            listBoxSettingsPages.TabControlTabLess = tabControlSettings;
            listBoxSettingsPages.Initialize();

            // открытие программы на последнем меcте перед закрытием
            // последняя открытая страничка tabControlMonitors
            SettingsSaveLoadProcessor.LoadValue(tabControlMonitors);

            // последний открытый пункт меню в настройках
            SettingsSaveLoadProcessor.LoadValue(listBoxSettingsPages);
            // подписка на событие здесь, чтобы не получилось автосохраннения в 0-индекс при загрузке листа
            this.listBoxSettingsPages.SelectedIndexChanged += new System.EventHandler(this.listBoxSettingsPages_SelectedIndexChanged);

            // загрузка шаблонов на MonitorPage
            LoadLayoutsOnMonitorPages();
        }
        
        /// <summary>
        /// Автозагрузка каналов в систему
        /// </summary>
        private void AutoLoadAllChannels()
        {
            if (checkBoxLoadChannels.Checked)
            {
                // загрузка всех каналов
                ReloadAllChannels();
            }
        }

        /// <summary>
        /// Загрузка каналов из фалов данных в систему
        /// </summary>
        private void ReloadAllChannels()
        {
            // TODO из-за особенности работы Dock обратный порядок добавления
            // подумать на будущее как это решить
            
            // загрузка Прочих каналов
            ReloadAllOtherChannels();
            // загрузка Главных каналов
            ReloadAllMainChannels();
        }

        /// <summary>
        /// Загрузка каналов из фалов данных в систему
        /// </summary>
        private void LoadAllChannels()
        {
            // TODO из-за особенности работы Dock обратный порядок добавления
            // подумать на будущее как это решить

            // загрузка Прочих каналов
            LoadAllOtherChannels();
            // загрузка Главных каналов
            LoadAllMainChannels();
        }

        /// <summary>
        /// Устанавливает MonitorTabPageLayout на первые две стартовые страницы
        /// </summary>
        private void LoadLayoutsOnMonitorPages()
        {
            tabPageMonitor2x2.PageLayout = new MonitorTabPageLayout_2x2();
            tabPageMonitor1x4.PageLayout = new MonitorTabPageLayout_1_4V();
        }

        /// <summary>
        /// Вызывает форму редактирования MonitorTabPage
        /// </summary>
        /// <param name="tabPage"></param>
        private void EditMonitorPageHandler(MonitorTabPage tabPage)
        {
            FormEditMonitorPage formEditMonitorPage = new FormEditMonitorPage(tabPage);
            formEditMonitorPage.ShowDialog();
        }


        #region Автосохранение текущего местоположения в интерфейсе программы
        /// <summary>
        /// Сохраняет индекс последней открытой страницы TabControl_Dynamic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsSaveLoadProcessor.SaveValue((Control)sender);
        }
        /// <summary>
        /// Сохраняет индекс последней открытой мониторной страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxSettingsPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsSaveLoadProcessor.SaveValue((Control)sender);
        }
        #endregion


        #region Тестовая кнопка

        private void buttonTest_Click(object sender, EventArgs e)
        {
            channelsDashBoard.panelTogglers.PerformLayout();
        }
        /// <summary>
        /// Подсказка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTest_MouseEnter(object sender, EventArgs e)
        {
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(buttonTest, "Выполняет PerformLayout панели плееров каналов");
        }


        #endregion
    }
}
