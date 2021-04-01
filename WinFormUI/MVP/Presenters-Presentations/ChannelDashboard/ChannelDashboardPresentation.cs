using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;
using WebCamMonitor.Presenters;

namespace WebCamMonitor
{
    public partial class FormMain : Form
    {
        private void FormMain_Load_ChannelDashboardPresentation()
        {
            // подписка на события панели (группового) управления каналами ChannelDashboard
            channelsDashBoard.PackageOperationsDelegate += PackageOperations;
        }

        /// <summary>
        /// Производит групповые операции с каналами
        /// </summary>
        /// <param name="operation">Тип операции</param>
        private void PackageOperations(Operations operation)
        {
            ChannelDashboardPresenter channelDashboardPresenter = new ChannelDashboardPresenter();

            switch (operation)
            {
                case Operations.Reload: // загружает все каналы из файлов
                    ReloadAllChannels();
                    break;

                case Operations.Load: // загружает все каналы из таблиц
                    LoadAllChannels(); 
                    break;

                case Operations.Start: // стартует все каналы в открытых пакетах
                    channelDashboardPresenter.StartAllChannels(channelsDashBoard);
                    break;

                case Operations.Stop: // останавливает все каналы
                    channelDashboardPresenter.StopAllChannels(channelsDashBoard);
                    break;

                case Operations.Delete: // удаляет все каналы
                    channelDashboardPresenter.DeleteAllChannels(channelsDashBoard);
                    break;
            }
        }
    }
}
