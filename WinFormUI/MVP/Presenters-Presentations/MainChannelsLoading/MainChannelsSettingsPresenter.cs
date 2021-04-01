using System.Data;
using System.Windows.Forms;
using MyLib.Models;
using MyLib.Views;
using MyLib.Processors;
using MyLib.Processors.DialogProcessor;
using System;
using System.Reflection;
using MyLib.Controls.ChannelDashboard;

namespace WebCamMonitor.Presenters
{
    /// <summary>
    /// Класс управления базовыми настройками главных каналов и их загрузкой в систему
    /// </summary>
    class MainChannelLoadingPresenter
    {
        IMainChannelSettings MainChannelSettingsView;
        MainChannelSettingsModel MainChannelSettings;
        
        // папка хранения снимков каналов
        //string SnapshotFolder = @"Resources\Snapshots\MainChannels";

        public MainChannelLoadingPresenter(IMainChannelSettings view)
        {
            // представление
            MainChannelSettingsView = view;

            // получение базовых настроек главных каналов из формы
            MainChannelSettings = Factory.CreateMainChannelSettings(MainChannelSettingsView);
        }

        /// <summary>
        /// Открывает диалоговое окно для загрузки файла настроек каналов
        /// </summary>
        public void OpenSettingsFileDialog()
        {
            // Открывает диалоговое окно для загрузки файла настроек каналов
            DialogProcessor.OpenSettingsFileDialog(MainChannelSettingsView);
        }


        /// <summary>
        /// Загружает в таблицу данные из файла настроек
        /// </summary>
        public void GetSettingsToDataGridChannelTable(DataGridView dataGridView)
        {
            // если путь непустой
            if (Validator.IsFilePathEmpty(MainChannelSettings.XmlFilePath))

                // если путь корректный
                if (Validator.IsFilePathValid(MainChannelSettings.XmlFilePath))
                {
                    try
                    {
                        // получение DataTable данных каналов из файла
                        DataTable channelDataTable = DataIOProcessor.GetDataTable(MainChannelSettings.XmlFilePath // путь к файлу настроек
                                                                                 , MainChannelSettings.DataTableName // имя DataTable данных каналов
                                                                                 );

                        if (channelDataTable == null)
                        {
                            MessageBox.Show(MessageProcessor.ChannelSettings.ChannelDataTableIsEmpty);
                        }
                        else
                        {
                            // форматирование DataTable данных каналов
                            DataGridViewProcessor.FormatSettingsDataTable(channelDataTable, // таблица данных
                                                                            MainChannelSettings // базовые настройки Главных каналов
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
        /// Сохраняет изменения в файле настроек
        /// </summary>
        public void SaveDataToXmlFile(DataGridView dataGridView)
        {
            // Сохраняет изменения в файле настроек
            DataIOProcessor.MainChannels.SaveDataToXmlFile(dataGridView, MainChannelSettings.XmlFilePath);
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
            DataGridViewProcessor.ReloadChannelsToPackage(dataGridView, channelsPackage, сhannelDashboard, MainChannelSettings);
        }
    }
}