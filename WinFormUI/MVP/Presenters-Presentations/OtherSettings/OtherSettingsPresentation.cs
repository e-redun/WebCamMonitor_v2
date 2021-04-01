using MyLib.Models;
using MyLib.Processors;
using System;
using System.Windows.Forms;
using WebCamMonitor.Presenters;

namespace WebCamMonitor
{
    public partial class FormMain : IOtherSettings
    {
        private void FormMain_Load_OtherSettings()
        {
            // загрузка Настроек из файла параметров/ресурсов
            LoadAllValuesOnControl(tabPageOtherSettings);

            // подписка на автоматическое заполнение колонки Snapshot - cнимок канала 
            this.dgvOtherChannels.DefaultValuesNeeded += DataGridViewProcessor.DefaultValuesNeededHandler;
        }

        /// <summary>
        /// Загружает Настройки страницы tabPageOtherSettings из файла параметров/ресурсов
        /// </summary>
        /// <param name="tabPageOtherSettings">Страница Прочих настроек</param>
        private void LoadAllValuesOnControl(TabPage tabPageOtherSettings)
        {
            OtherSettingsPresenter otherSettingsPresenter = new OtherSettingsPresenter(this);
            otherSettingsPresenter.LoadValuesOnControl(tabPageOtherSettings);
        }

        /// <summary>
        /// Сохраняет состояние CheckBox автозагрузки каналов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxLoadChannels_CheckedChanged(object sender, EventArgs e)
        {
            SettingsSaveLoadProcessor.SaveValue((Control)sender);
        }

        /// <summary>
        /// Открывает в Проводнике папку указанную в поле channelSnapshotFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkChannelSnapshotFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OtherSettingsPresenter otherSettingsPresenter = new OtherSettingsPresenter(this);
            otherSettingsPresenter.OpenChannelSnapshotFolder();
        }

        /// <summary>
        /// Открывает в Проводнике папку указанную в поле playerSnapshotFolder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkPlayerSnapshotFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OtherSettingsPresenter otherSettingsPresenter = new OtherSettingsPresenter(this);
            otherSettingsPresenter.OpenPlayerSnapshotFolder();
        }

        /// <summary>
        /// Открывает диалоговое окно для выбора папки хранения снимков каналов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectChannelSnapshotFolder_Click(object sender, EventArgs e)
        {
            OtherSettingsPresenter otherSettingsPresenter = new OtherSettingsPresenter(this);
            channelSnapshotFolder = otherSettingsPresenter.SelectChannelSnapshotFolder();
        }

        /// <summary>
        /// Открывает диалоговое окно для выбора папки хранения снимков плееров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectPlayerSnapshotFolder_Click(object sender, EventArgs e)
        {
            OtherSettingsPresenter otherSettingsPresenter = new OtherSettingsPresenter(this);
            playerSnapshotFolder = otherSettingsPresenter.SelectPlayerSnapshotFolder();
        }

        #region Интерфейс
        public string channelSnapshotFolder
        {
            get
            {
                return textBoxChannelSnapshotFolder.Text;
            }
            set
            {
                textBoxChannelSnapshotFolder.Text = value;

                // сохранение в настройках программы
                SettingsSaveLoadProcessor.SaveValue(textBoxChannelSnapshotFolder);
            }
        }
        public string playerSnapshotFolder
        {
            get
            {
                return textBoxPlayerSnapshotFolder.Text;
            }
            set
            {
                textBoxPlayerSnapshotFolder.Text = value;
                // сохранение в настройках программы
                SettingsSaveLoadProcessor.SaveValue(textBoxPlayerSnapshotFolder);
            }
        }
        #endregion
    }
}
