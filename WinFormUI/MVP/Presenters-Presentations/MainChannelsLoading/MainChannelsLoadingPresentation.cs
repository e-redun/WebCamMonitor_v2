using System;
using MyLib.Views;
using WebCamMonitor.Presenters;
using System.Windows.Forms;
using MyLib.Processors;
using System.Reflection;
using MyLib.Models;

namespace WebCamMonitor
{
    public partial class FormMain : IMainChannelSettings
    {
        private void FormMain_Load_MainChannelLoadingPresentation()
        {

            // Загрузка автосохранненых значений в поля страницы Настройки основных каналов
            LoadMainCannelsSettingsPageFields();
            // TODO сделать однообразно ???
            //SettingsSaveLoadProcessor.LoadAllValuesOnControl(tabPageMainChannelsSettings);            

            // Инициализация таблицы dgvMainChannels
            DataGridViewProcessor.Initialize(dgvMainChannels);
        }

        /// <summary>
        /// Загружает базовые настройки в поля формы Главных каналов из файла сохраненных настроек
        /// </summary>
        private void LoadMainCannelsSettingsPageFields()
        {

            // поле пути к файлу настроек
            // SettingsSaveLoadProcessor.LoadFilePathTextBoxValueAndLookForDefault(tabPageOtherSettings, textBoxMainChannelSettingsFile);
            SettingsSaveLoadProcessor.LoadValue(textBoxMainChannelSettingsFile);

            // поле базовой ссылки на каналы Main
            SettingsSaveLoadProcessor.LoadValue(textBoxChannelBaseLink);

            // поле таблицы файла данных Main
            SettingsSaveLoadProcessor.LoadValue(textBoxSettingsDataTable);
        }

        /// <summary>
        /// Загружает каналы из файла в систему
        /// </summary>
        private void ReloadAllMainChannels()
        {
            try
            {
                // загрузка данных из файла в таблицу
                buttonGetMainChannelsSettings_Click(null, null);

                // загрузка данных из таблицы в систему
                LoadAllMainChannels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        /// <summary>
        /// Загружает каналы из таблицы в систему
        /// </summary>
        private void LoadAllMainChannels()
        {
            try
            {
                // загрузка данных из таблицы в систему
                buttonLoadMainChannelsToSystem_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }


        #region GetSaveLoadChannelSettingsMain

        /// <summary>
        /// Открыват диалоговое окно для выбора файла настроек каналов
        /// </summary>
        private void buttonSelectMainSettingsFile_Click(object sender, EventArgs e)
        {
            MainChannelLoadingPresenter mainChannelsLoadingPresenter = new MainChannelLoadingPresenter(this);
            mainChannelsLoadingPresenter.OpenSettingsFileDialog();
        }

        /// <summary>
        /// Загружает данные из файла в таблицу
        /// </summary>
        private void buttonGetMainChannelsSettings_Click(object sender, EventArgs e)
        {
            MainChannelLoadingPresenter mainChannelsLoadingPresenter = new MainChannelLoadingPresenter(this);
            mainChannelsLoadingPresenter.GetSettingsToDataGridChannelTable(dgvMainChannels);
        }

        /// <summary>
        /// Сохраняет данные в файле
        /// </summary>
        private void buttonSaveMainChannelSettings_Click(object sender, EventArgs e)
        {
            MainChannelLoadingPresenter mainChannelsLoadingPresenter = new MainChannelLoadingPresenter(this);
            mainChannelsLoadingPresenter.SaveDataToXmlFile(dgvMainChannels);
        }

        /// <summary>
        /// Загружает данные каналов из таблицы в систему
        /// </summary>
        private void buttonLoadMainChannelsToSystem_Click(object sender, EventArgs e)
        {
            //// добавление в channelsDashBoard пакета Главных каналов
            //channelsDashBoard.AddChannelPackage(mainChannelPackage);

            MainChannelLoadingPresenter mainChannelsLoadingPresenter = new MainChannelLoadingPresenter(this);
            mainChannelsLoadingPresenter.ReloadChannelsToPackage(dgvMainChannels, mainChannelPackage, channelsDashBoard);
        }
        #endregion
        
        #region Интерфейс
        string IMainChannelSettings.XmlFilePath
        {
            get
            {
                return textBoxMainChannelSettingsFile.Text;
            }
            set
            {
                textBoxMainChannelSettingsFile.Text = value;
                // Автосохранение полей Базовых настроек главных каналов
                SettingsSaveLoadProcessor.SaveValue(textBoxMainChannelSettingsFile);
            }
        }
        string IMainChannelSettings.SnapshotRootFolder
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
        string IMained.DataTableName
        {
            get
            {
                return textBoxSettingsDataTable.Text;
            }
            set
            {
                textBoxSettingsDataTable.Text = value;
                // Автосохранение полей Базовых настроек главных каналов
                SettingsSaveLoadProcessor.SaveValue(textBoxSettingsDataTable);

            }
        }

        string IMained.BaseLink
        {
            get
            {
                return textBoxChannelBaseLink.Text;
            }
            set
            {
                textBoxChannelBaseLink.Text = value;
                // Автосохранение полей Базовых настроек главных каналов
                SettingsSaveLoadProcessor.SaveValue(textBoxChannelBaseLink);

            }
        }
        string IMained.Login
        {
            get
            {
                return textBoxLogin.Text;
            }
            set
            {
                textBoxLogin.Text = value;
            }
        }
        string IMained.ResolutionX
        {
            get
            {
                return textBoxResolutionX.Text;
            }
            set
            {
                textBoxResolutionX.Text = value;
            }
        }
        string IMained.ResolutionY
        {
            get
            {
                return textBoxResolutionY.Text;
            }
            set
            {
                textBoxResolutionY.Text = value;
            }
        }
        string IMained.Fps
        {
            get
            {
                return textBoxFps.Text;
            }
            set
            {
                textBoxFps.Text = value;
            }
        }
        #endregion
        
    }
}