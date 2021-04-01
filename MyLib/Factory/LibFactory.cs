using System.Windows.Forms;
using System.Drawing;
using MyLib.Models;
using MyLib.Controls.VideoPlayers;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Processors.MJPEG;
using MyLib.Processors;
using MyLib.Controls;
using MyLib.Views;

namespace MyLib
{
    public static class LibFactory
    {
        /// <summary>
        /// Создает ComboToggler - распахивающийся список плееров каналов
        /// </summary>
        /// <returns></returns>
        internal static ComboToggler CreateComboToggler(IChannelPackage сhannelPackage)
        {
            ComboToggler output = new ComboToggler(сhannelPackage)
            {
                ExpandDirection = ExpandDirection.Down,
                AutoSize = true,
                Dock = DockStyle.Top,
                Visible = false,
            };
            return output;
        }

        /// <summary>
        /// Создает Прочий канал OtherChannelModel из таблицы
        /// </summary>
        /// <param name="dataGridView">Таблица каналов</param>
        /// <param name="rowIndex">Индекс строки</param>
        /// <returns></returns>
        public static ChannelModel CreateChannel( DataGridView dataGridView     // таблица с данными каналов
                                                , int rowIndex                  // индекс строки
                                                , IChannelPackage channelPackage// пакет каналов (ссылка на пектет нужна для фотографирования)
                                                )
        {
            // ChannelModel output = new OtherChannelModel(); почему-то при перетаскивании Drag&Drop возникает ошибка
            ChannelModel output = new MainChannelModel();

            output.Name = dataGridView.Rows[rowIndex].Cells["Name"].Value.ToString();
            output.Description = dataGridView.Rows[rowIndex].Cells["Description"].Value.ToString();
            output.ChannelLink = dataGridView.Rows[rowIndex].Cells["ChannelLink"].Value.ToString();
            output.Picture = (Image)dataGridView.Rows[rowIndex].Cells["Snapshot"].Value;
            output.ChannelPackage = channelPackage;

            return output;
        }


        /// <summary>
        /// Перегрузка. Создает и возвращает экземпляр Главный канал MainChannelModel
        /// </summary>
        /// <returns></returns>
        public static ChannelModel CreateChannel( DataGridView dataGridView         // таблица с данными каналов
                                                , int rowIndex                      // индекс строки
                                                , IChannelPackage channelPackage    // пакет каналов (ссылка на пектет нужна для фотографирования)
                                                , IMainChannelSettings mainChannelBaseSettings // базовые настройки Главных каналов
                                                )
        {
            ChannelModel output = new MainChannelModel();

            output.Name = dataGridView.Rows[rowIndex].Cells["Name"].Value.ToString();
            output.Description = dataGridView.Rows[rowIndex].Cells["Description"].Value.ToString();
            output.ChannelLink = dataGridView.Rows[rowIndex].Cells["ChannelLink"].Value.ToString();
            output.Picture = (Image)dataGridView.Rows[rowIndex].Cells["Snapshot"].Value;
            output.ChannelPackage = channelPackage;

            //
            // на будущее
            // TODO передача базовых настроек каналу пока отложена
            //

            return output;
        }
        public static VideoPlayer CreateChannelVideoPlayer()
        {
            ChannelVideoPlayer output = new ChannelVideoPlayer();
            output.PlayerState = State.Off;

            // установка зазора между плеерами 5px
            // студия почему-то сбрасывает SplitterDistance к 25px ???
            ((SplitContainer)output.Controls["splitContainer"]).SplitterDistance = output.Height - 5;

            // подписка на делегат фотографирования
            output.TakeSnapshotDelegate += Photographer.TakeChannelSnapshot;

            return output;
        }

        /// <summary>
        /// Возвращает новый экземпляр MonitorVideoPlayer
        /// </summary>
        /// <returns>MonitorVideoPlayer</returns>
        public static VideoPlayer CreateMonitorVideoPlayer()
        {
            MonitorVideoPlayer output = new MonitorVideoPlayer();
            output.PlayerState = State.Off;

            // отключение Panel2
            // разделительный пробел между плеерами не нужен см. CreateChannelVideoPlayer
            ((SplitContainer)output.Controls["splitContainer"]).Panel2Collapsed = true;

            // подписка на делегат фотографирования
            output.TakeSnapshotDelegate += Photographer.TakeMonitorPlayerSnapshot;

            return output;
        }

        /// <summary>
        /// Возвращает новый экземпляр дефолтного шаблона
        /// </summary>
        /// <returns>MonitorTabPageLayout_1_Default</returns>
        internal static MonitorTabPageLayout CreateDefaultMonitorTabPageLayout()
        {
            return new MonitorTabPageLayout_1_Default();
        }

        /// <summary>
        /// Возвращает новый MJPEGProcessor
        /// </summary>
        /// <returns>MJPEGProcessor</returns>
        public static MJPEGProcessorModel CreateMJPEGProcessor()
        {
            return new MJPEGProcessor();
        }


        public static ToolTip CreatNewTooltip()
        {
            return new ToolTip();
        }

        /// <summary>
        /// Возвращает новый экземпляр ToolStripMenuItem
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="description">Описание</param>
        /// <param name="checkable">с чекбоксами</param>
        /// <returns></returns>
        public static ToolStripMenuItem CreateMenuItem(string name, string description, bool checkable)
        {
            ToolStripMenuItem output = new ToolStripMenuItem
            {
                AutoSize = true,
                CheckOnClick = checkable,
                Checked = checkable,
                DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text,
                Name = name,
                Text = description,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            return output;
        }
    }
}
