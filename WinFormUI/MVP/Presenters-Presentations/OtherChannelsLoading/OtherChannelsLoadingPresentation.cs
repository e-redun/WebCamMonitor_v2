using MyLib.Models;
using MyLib.Processors;
using System.Reflection;
using System.Windows.Forms;
using System;
using WebCamMonitor.Presenters;
using System.Configuration;
using MyLib.Views;

namespace WebCamMonitor
{
    public partial class FormMain : IOtherChannelSettings
    {
        private void FormMain_Load_OtherChannelLoadingPresentation()
        {
            // Инициализация таблицы dgvMainChannels
            DataGridViewProcessor.Initialize(dgvOtherChannels);

            // Загрузка автосохранненого пути к файлу настроек
            SettingsSaveLoadProcessor.LoadValue(textBoxOtherChannelSettingsFile);
        }

        /// <summary>
        /// Загружает каналы из файла в систему
        /// </summary>
        private void ReloadAllOtherChannels()
        {
            try
            {
                // загрузка данных из файла в таблицу
                buttonGetOtherChannelsSettings_Click(null, null);

                // загрузка данных из таблицы в систему
                LoadAllOtherChannels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        /// <summary>
        /// Загружает каналы из таблицы в систему
        /// </summary>
        private void LoadAllOtherChannels()
        {
            try
            {
                // загрузка данных из таблицы в систему
                buttonLoadOtherChannelsToSystem_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        private void buttonSelectOtherChannelSettingsFile_Click(object sender, EventArgs e)
        {
            OtherChannelLoadingPresenter otherChannelsLoadingPresenter = new OtherChannelLoadingPresenter(this);
            otherChannelsLoadingPresenter.OpenSettingsFileDialog();
        }

        private void buttonGetOtherChannelsSettings_Click(object sender, EventArgs e)
        {
            OtherChannelLoadingPresenter otherChannelsLoadingPresenter = new OtherChannelLoadingPresenter(this);
            otherChannelsLoadingPresenter.GetSettingsToDataGridChannelTable(dgvOtherChannels);
        }

        private void buttonSaveOtherChannelSettings_Click(object sender, EventArgs e)
        {
            OtherChannelLoadingPresenter otherChannelsLoadingPresenter = new OtherChannelLoadingPresenter(this);
            otherChannelsLoadingPresenter.SaveDataToXmlFile(dgvOtherChannels, textBoxOtherChannelSettingsFile);
        }

        private void buttonLoadOtherChannelsToSystem_Click(object sender, EventArgs e)
        {

            // добавление в channelsDashBoard пакета Прочих каналов
            //channelsDashBoard.AddChannelPackage(otherChannelPackage);

            OtherChannelLoadingPresenter otherChannelsLoadingPresenter = new OtherChannelLoadingPresenter(this);
            otherChannelsLoadingPresenter.ReloadChannelsToPackage(dgvOtherChannels, otherChannelPackage, channelsDashBoard);
        }

        #region Автосохранение полей настроек каналов
        private void textBoxOtherChannelSettigsFilePath_TextChanged(object sender, EventArgs e)
        {
            SettingsSaveLoadProcessor.SaveValue((Control)sender);
        }
        #endregion

        #region Интерфейс
        string IOtherChannelSettings.XmlFilePath
        {
            get
            {
                return textBoxOtherChannelSettingsFile.Text;
            }
            set
            {
                textBoxOtherChannelSettingsFile.Text = value;
            }
        }

        string IOtherChannelSettings.SnapshotRootFolder
        {
            get
            {
                return textBoxChannelSnapshotFolder.Text;
            }
            set
            {
                textBoxChannelSnapshotFolder.Text = value;
            }
        }

        #endregion
    }
}