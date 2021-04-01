using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Controls.VideoPlayers;
using MyLib.Processors;
using System.Reflection;
using System.ComponentModel;

namespace MyLib.Controls.TabPages
{
    public class MonitorTabPage : TabPage
    {
        MonitorTabPageLayout _pageLayout;

        public MonitorTabPageLayout PageLayout
        {
            get
            {
                return _pageLayout;
            }
            set
            {
                _pageLayout = value;

                if (value != null)
                {
                    ResetLayout(value);
                    ResetVideoPlayers();
                }
            }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<VideoPlayer> VideoPlayers { get; set; }
        /// <summary>
        /// Количество плееров на странице
        /// </summary>
        public int VideoPlayersCount { get; private set; }

        /// <summary>
        /// Конструктор 
        /// </summary>
        public MonitorTabPage()
        {
            VideoPlayers = new List<VideoPlayer>();

            PageLayout = LibFactory.CreateDefaultMonitorTabPageLayout();
        }


        /// <summary>
        /// Переустанавливает шаблон
        /// </summary>
        /// <param name="newLayout"></param>
        private void ResetLayout(MonitorTabPageLayout newLayout)
        {
            try
            {
                if (newLayout != null)
                {
                    // получение старого шаблона
                    MonitorTabPageLayout oldLayout = (MonitorTabPageLayout)Controls.Find("myLayout", true).FirstOrDefault();

                    if (newLayout.Equals(oldLayout))
                    {
                        return;
                    }
                    else
                    {
                        if (oldLayout != null)
                        {
                            // удаление старого шаблона
                            oldLayout.Controls.Clear();
                            Controls.Remove(oldLayout);
                            oldLayout.Dispose();
                            oldLayout = null;
                        }

                        // настройка нового шаблона
                        newLayout.Name = "myLayout";
                        newLayout.BorderStyle = BorderStyle.None;
                        newLayout.AllCellBodersStyle = TableLayoutPanelCellBorderStyle.None;
                        newLayout.Dock = DockStyle.Fill;

                        // постановка нового шаблона
                        Controls.Add(newLayout);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
                Application.Exit();
            }
        }

        /// <summary>
        /// Переустанавливает видеоплееры в шаблоне страницы
        /// </summary>
        private void ResetVideoPlayers()
        {
            try
            {
                // получение списка TableLayoutPanel
                List<Control> tableLayoutPanels = GetAllTableLayoutPanels();

                // счетчик ячеек (плееров)
                int playerIndex = 0;

                if (tableLayoutPanels.Count > 0)
                {
                    // перебор tableLayoutPanels
                    for (int k = 0; k < tableLayoutPanels.Count; k++)
                    {
                        TableLayoutPanel panel = (TableLayoutPanel)tableLayoutPanels[k];
                        int colums = panel.ColumnCount;
                        int rows = panel.RowCount;

                        // перебор строк
                        for (int i = 0; i < rows; i++)
                        {
                            // перебор колонок
                            for (int j = 0; j < colums; j++)
                            {
                                VideoPlayer videoPlayer;

                                if (playerIndex < VideoPlayersCount)
                                {
                                    // извлечение плеера из списока страницы
                                    videoPlayer = VideoPlayers[playerIndex];
                                }
                                else
                                {   
                                    // создание нового
                                    videoPlayer = LibFactory.CreateMonitorVideoPlayer();
                                    VideoPlayers.Add(videoPlayer);
                                }
;
                                videoPlayer.Dock = DockStyle.Fill;

                                panel.Controls.Add(videoPlayer, j, i);
                                playerIndex++;
                            }
                        }
                    }
                }

                // удаление лишних плееров при смене шаблона на более "короткий"
                if (playerIndex < VideoPlayersCount)
                {
                    VideoPlayers.RemoveRange(playerIndex, VideoPlayersCount - playerIndex);
                }

                VideoPlayersCount = VideoPlayers.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        /// <summary>
        /// Возвращает список всех TableLayoutPanels в шаблоне
        /// </summary>
        /// <returns></returns>
        private List<Control> GetAllTableLayoutPanels()
        {
            List<Control> output = ControlProcessor.GetAllControls(PageLayout, typeof(TableLayoutPanel)).ToList();
            return output;
        }
    }
}