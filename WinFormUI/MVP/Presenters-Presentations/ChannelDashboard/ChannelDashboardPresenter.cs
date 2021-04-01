using MyLib;
using MyLib.Controls;
using MyLib.Controls.ChannelDashboard;
using MyLib.Controls.VideoPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCamMonitor.Presenters
{
    internal class ChannelDashboardPresenter
    {
        /// <summary>
        /// Запускает все каналы в открытых пакетах / СomboToggler
        /// </summary>
        internal void StartAllChannels(ChannelDashboard channelsDashBoard)
        {
            // выборка плееров каналов в открытых пакетах (ComboTogglers)
            var players = from comboToggler in channelsDashBoard.ComboTogglers
                          from player in comboToggler.ChannelPlayers
                          where comboToggler.State == ExpColState.Expanded
                          select player;
            // запуск
            foreach (var player in players)
            {
                if (player.PlayerState == State.Off)
                {
                    ((ChannelVideoPlayer)player).buttonStartStop_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Останавливает все каналы пакетах / СomboToggler
        /// </summary>
        internal void StopAllChannels(ChannelDashboard channelsDashBoard)
        {

            // выборка всех невыключенных плееров каналов во всех пакетах (ComboTogglers)
            var players = from comboToggler in channelsDashBoard.ComboTogglers
                          from player in comboToggler.ChannelPlayers
                          where player.PlayerState != State.Off
                          //where comboToggler.State == ExpColState.Expanded // оставлено на всякий
                          select player;
            // запуск
            foreach (var player in players)
            {
                if (player.PlayerState != State.Off)
                {
                    ((ChannelVideoPlayer)player).buttonStartStop_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Удаляет все каналы пакетах / СomboToggler
        /// </summary>
        internal void DeleteAllChannels(ChannelDashboard channelsDashBoard)
        {
            // перебор ComboTogglers / пакетов
            for (int j = channelsDashBoard.ComboTogglers.Count - 1; j >= 0; j--)
            {
                var comboToggler = channelsDashBoard.ComboTogglers[j];
                
                // перебор плееров/каналов
                for (int i = comboToggler.ChannelPlayers.Count - 1; i >= 0; i--)
                {
                    // обощенный вариант
                    comboToggler.ChannelPlayers[i].buttonDelete_Click(null, null);
                }
            }
        }
    }
}
