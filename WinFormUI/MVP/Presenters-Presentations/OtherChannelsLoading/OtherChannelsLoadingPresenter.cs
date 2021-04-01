using System;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using MyLib.Processors;
using MyLib.Processors.DialogProcessor;
using MyLib.Models;
using MyLib.Views;
using System.Configuration;
using MyLib.Controls.ChannelDashboard;

namespace WebCamMonitor.Presenters
{
    /// <summary>
    /// Класс загрузки Прочих каналов в систему
    /// </summary>
    class OtherChannelLoadingPresenter
    {
        IOtherChannelSettings OtherChannelSettingsView;
        OtherChannelSettingsModel OtherChannelSettings;

        public OtherChannelLoadingPresenter(IOtherChannelSettings view)
        {
            // представление
            OtherChannelSettingsView = view;

            // получение базовых настроек главных каналов из формы
            OtherChannelSettings = Factory.CreateOtherChannelSettings(OtherChannelSettingsView);
        }

        /// <summary>
        /// Открывает диалоговое окно для загрузки файла настроек каналов
        /// </summary>
        public void OpenSettingsFileDialog()
        {
            // Открывает диалоговое окно для загрузки файла настроек каналов
            DialogProcessor.OpenSettingsFileDialog(OtherChannelSettingsView);
        }

        /// <summary>
        /// Загружает в таблицу данные из файла настроек
        /// </summary>
        public void GetSettingsToDataGridChannelTable(DataGridView dataGridView)
        {
            // если путь непустой
            if (Validator.IsFilePathEmpty(OtherChannelSettings.XmlFilePath))
                
                // если путь корректный
                if (Validator.IsFilePathValid(OtherChannelSettings.XmlFilePath))
                {
                    try
                    {
                        // получение имени таблицы данных их файла App.config
                        string DataTableName = ConfigurationManager.AppSettings["ChannelInfoTable"];

                        // получение DataTable данных каналов из файла
                        DataTable channelDataTable = DataIOProcessor.GetDataTable(OtherChannelSettings.XmlFilePath, DataTableName);

                        if (channelDataTable == null)
                        {
                            MessageBox.Show(MessageProcessor.ChannelSettings.ChannelDataTableIsEmpty);
                        }
                        else
                        {
                            // форматирование DataTable данных каналов
                            DataGridViewProcessor.FormatSettingsDataTable( channelDataTable // DataTable данных каналов
                                                                         , OtherChannelSettingsView // Прочих каналов
                                                                         );

                            // заполнение таблицы каналов
                            DataGridViewProcessor.FillDataGridChannelTable(dataGridView, channelDataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
                    }
                }
                else // if (Validator.IsFilePathValid
                {
                    MessageBox.Show(MessageProcessor.File.DoesntExist   // сообщение
                                    , "Загрузка файла настроек"         // заголовок
                                    , MessageBoxButtons.OK              // кнопки
                                    , MessageBoxIcon.Stop               // иконка
                                    );
                }
            else // Validator.IsFilePathEmpty
            {
                MessageBox.Show(MessageProcessor.File.NotChoosen);
            }
        }


        /// <summary>
        /// Вызывает диалоговое окно "Создать файл настроек или нет?"
        /// </summary>
        private void ShowCreateFileDialog(TextBox textBoxSettingsFile)
        {
            var answer = MessageBox.Show(MessageProcessor.File.NotChoosenOrDoesntExist, // сообщение
                                         "Создание файла настроек", // Заголовок
                                         MessageBoxButtons.YesNo, // кнопки
                                         MessageBoxIcon.Question // иконка
                                         );

            if (answer == DialogResult.Yes)
            {
                textBoxSettingsFile.Text = CreateXmlDataFile();
            }
        }

        /// <summary>
        /// Создает файл настроек
        /// </summary>
        public string CreateXmlDataFile()
        {
            string fullPath = Application.StartupPath;
            fullPath += @"\Resources\XMLs\otherChannelSettings.xml";
            
            // создаение файла настроек
            DataIOProcessor.OtherChannels.CreateXmlDataFile(fullPath);

            // возвращает полный путь 
            return fullPath;
        }

        /// <summary>
        /// Сохраняет изменения в файле настроек
        /// </summary>
        public void SaveDataToXmlFile(DataGridView dataGridView, TextBox textBoxSettingsFile)
        {
            // если путь не пустой и корректный
            if (Validator.IsFilePathValid(OtherChannelSettings.XmlFilePath))
            {
                // Сохраняет изменения в файле настроек
                DataIOProcessor.OtherChannels.SaveDataToXmlFile(dataGridView, OtherChannelSettingsView.XmlFilePath);
            }
            else
            {
                ShowCreateFileDialog(textBoxSettingsFile);
            }
        }

        /// <summary>
        /// Загружает каналы в пакет каналов
        /// </summary>
        /// <param name="dataGridView">Таблица каналов</param>
        /// <param name="channelsPackage">Пакет каналов</param>
        public void ReloadChannelsToPackage( DataGridView dataGridView       // DataGridView каналов
                                           , IChannelPackage channelsPackage // пакет каналов
                                           , ChannelDashboard сhannelDashboard // панель управления каналами
                                           )
        {
            DataGridViewProcessor.ReloadChannelsToPackage(dataGridView, channelsPackage, сhannelDashboard, null);
        }
    }
}
