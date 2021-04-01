using MyLib.Controls.ChannelDashboard;
using MyLib.Models;
using MyLib.Processors;
using MyLib.Processors.MJPEG;
using MyLib.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MyLib.Processors
{
    /// <summary>
    /// Класс обработки DGV-таблиц
    /// </summary>
    public static class DataGridViewProcessor
    {
        /// <summary>
        /// Формирует DataTable настроек
        /// </summary>
        /// <param name="channelDataTable">Имя таблицы данных файла настроек</param>
        static public void FormatSettingsDataTable( DataTable channelDataTable // таблица данных
                                                    , IMainChannelSettings settings // базовые настройки Главных каналов
                                                    )
        {
            channelDataTable.Columns.Add("ChannelLink", typeof(string));
            channelDataTable.Columns.Add("Snapshot", typeof(Image));

            // заполнение колонки снимков Snapshot
            for (int i = 0; i < channelDataTable.Rows.Count; i++)
            {
                string channelName = channelDataTable.Rows[i]["Name"].ToString();

                string filePath = $@"{settings.SnapshotRootFolder}\MainChannels\{channelName}.jpg";

                if (File.Exists(filePath))
                {
                    channelDataTable.Rows[i]["Snapshot"] = DataIOProcessor.ReadImageFile(filePath);
                }
                else
                {
                    channelDataTable.Rows[i]["Snapshot"] = Properties.Resources.NoSnapshot;
                }
            }

            // заполнение колонки ChannelLink / ссылка
            for (int i = 0; i < channelDataTable.Rows.Count; i++)
            {
                string channelLink = "";
                channelLink += settings.BaseLink;
                channelLink += "?login=" + settings.Login;
                channelLink += "&channelid=" + channelDataTable.Rows[i]["Id"];
                channelLink += "&resolutionX=" + settings.ResolutionX;
                channelLink += "&resolutionY=" + settings.ResolutionY;
                channelLink += "&fps=" + settings.Fps;

                channelDataTable.Rows[i]["ChannelLink"] = channelLink;
            }
        }

        /// <summary>
        /// Перегрузка
        /// Формирует DataTable настроек
        /// </summary>
        /// <param name="channelDataTable">Имя таблицы данных файла настроек</param>
        static public void FormatSettingsDataTable ( DataTable channelDataTable // таблица данных
                                                   , IOtherChannelSettings settings // базовые настройки Главных каналов
                                                   )
        {

            channelDataTable.Columns.Add("Snapshot", typeof(Image));
            
            // заполнение колонки снимков Snapshot
            for (int i = 0; i < channelDataTable.Rows.Count; i++)
            {
                string channelName = channelDataTable.Rows[i]["Name"].ToString();

                string filePath = $@"{settings.SnapshotRootFolder}\OtherChannels\{channelName}.jpg";

                if (File.Exists(filePath))
                {
                    channelDataTable.Rows[i]["Snapshot"] = DataIOProcessor.ReadImageFile(filePath);
                }
                else
                {
                    channelDataTable.Rows[i]["Snapshot"] = Properties.Resources.NoSnapshot;
                }
            }
        }

        /// <summary>
        /// Инициализирует DataGridView данных каналов
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void Initialize(DataGridView dataGridView)
        {
            // добавление текстовых колонок
            dataGridView.Columns.Add("ChannelLink", "Ссылка на канал");
            dataGridView.Columns.Add("Name", "Имя");
            dataGridView.Columns.Add("Description", "Описание");

            // добавление колонки Снимок
            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();

            dataGridViewImageColumn.Name = "Snapshot";
            dataGridViewImageColumn.HeaderText = "Снимок";
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            //dataGridViewImageColumn.Image = Properties.Resources.cameraIconYellow;
            dataGridView.Columns.Add(dataGridViewImageColumn);

            // ширина dataGridView
            int dGVWidth = dataGridView.Width;
            // ширина колонок
            dataGridView.Columns["ChannelLink"].Width = 55 * dGVWidth / 100;
            dataGridView.Columns["Name"].Width = 15 * dGVWidth / 100;
            dataGridView.Columns["Description"].Width = 15 * dGVWidth / 100;
            dataGridView.Columns["Snapshot"].Width = 15 * dGVWidth / 100;

            // режим автоизменения размера колонок
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Columns["ChannelLink"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["Snapshot"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // режим ручного изменения размера колонок
            dataGridView.Columns["ChannelLink"].Frozen = false;
            dataGridView.Columns["Name"].Frozen = false;
            dataGridView.Columns["Description"].Frozen = false;
            dataGridView.Columns["Snapshot"].Frozen = false;

            // установка названия источника данных - Name столбца подключаемой таблицы
            dataGridView.Columns["ChannelLink"].DataPropertyName = "ChannelLink";
            dataGridView.Columns["Name"].DataPropertyName = "Name";
            dataGridView.Columns["Description"].DataPropertyName = "Description";
            dataGridView.Columns["Snapshot"].DataPropertyName = "Snapshot";

            // многострочность
            dataGridView.Columns["ChannelLink"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // редактируемость
            //dataGridView.Columns["Name"].ReadOnly = true;
            dataGridView.Columns["Snapshot"].ReadOnly = true;

            // запрет сортировки
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// Подключает DataTable данных каналов к DataGridView
        /// </summary>
        /// <param name="channelDataTable"></param>
        public static void FillDataGridChannelTable(DataGridView dataGridView, DataTable channelDataTable)
        {
            // запрет автогенереции колонок
            dataGridView.AutoGenerateColumns = false;

            dataGridView.DataSource = channelDataTable;
        }

        /// <summary>
        /// Возвращает true, если DataGridView пуста
        /// </summary>
        /// <param name="dataGridView">DataGridView каналов</param>
        /// <returns></returns>
        private static bool IsDataGridViewEmpty(DataGridView dataGridView)
        {
            bool output=true;
            
            // перебор строк таблицы
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                object cellValue = dataGridView.Rows[i].Cells[0].Value;
                if (cellValue != null)
                {
                    output = false;
                    return output;
                }
            }

            return output;
        }


        // Новая версия
        /// <summary>
        /// Перезагружает каналы в пакет
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="channelPackage"></param>
        /// <param name="mainChannelBaseSettings"></param>
        public static void ReloadChannelsToPackage(DataGridView dataGridView         // DataGridView-таблица данных
                                                   , IChannelPackage channelPackage    // пакет каналов
                                                   , ChannelDashboard сhannelDashboard // панель управления каналами
                                                   , IMainChannelSettings mainChannelBaseSettings // базовые настройки Главных каналов
                                                   )
        {
            try
            {
                if (IsDataGridViewEmpty(dataGridView))
                {
                    MessageBox.Show(MessageProcessor.DataGridView.IsEmpty);
                    return;
                }
                else
                {
                    // добавление в channelsDashBoard пакета каналов
                    сhannelDashboard.AddChannelPackage(channelPackage);
                }

                // добавление каналов
                // перебор строк таблицы
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    string channelLink = "";
                    string channelName = "";

                    try
                    {
                        channelLink = dataGridView.Rows[i].Cells["ChannelLink"].Value.ToString();
                        channelName = dataGridView.Rows[i].Cells["Name"].Value.ToString();
                    }
                    catch (Exception ex)
                    { }

                    if (string.IsNullOrWhiteSpace(channelLink))
                    { }
                    else
                    {
                        // поиск канала в пакете 
                        // преобразование BindingList в List для поиска канала в пакете
                        var varChannel = new List<ChannelModel>(channelPackage.Channels).Find(c => c.Name == channelName);

                        if (varChannel == null)
                        {
                            ChannelModel channel;

                            if (mainChannelBaseSettings == null)
                            {
                                // создание Прочего канала
                                channel = LibFactory.CreateChannel(dataGridView, i, channelPackage);
                            }
                            else
                            {
                                // создание Главного канала
                                channel = LibFactory.CreateChannel(dataGridView, i, channelPackage, mainChannelBaseSettings);
                            }

                            // добавление канала в пакет
                            channelPackage.AddChannel(channel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }



        /// <summary>
        /// При добавляении строки в DGV заполняет колонку Snapshot кантинкой NoSnapshot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DefaultValuesNeededHandler(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ChannelLink"].Value = "Ссылка";
            e.Row.Cells["Name"].Value = "Channel" + (e.Row.Index + 1);
            e.Row.Cells["Description"].Value = "Канал" + (e.Row.Index + 1);
            e.Row.Cells["Snapshot"].Value = Properties.Resources.NoSnapshot;
        }   
    }
}