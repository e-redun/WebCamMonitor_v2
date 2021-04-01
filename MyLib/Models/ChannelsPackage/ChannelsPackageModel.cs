using System.Collections.Generic;
using System.ComponentModel;
using MyLib.Models;

namespace MyLib.Models
{
    public class ChannelsPackageModel : IChannelPackage
    {
        /// <summary>
        /// Имя пакета каналов
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание пакета каналов
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Пакет (список/List) каналов
        /// </summary>
        public BindingList<ChannelModel> Channels { get; set; }

        public ChannelsPackageModel()
        {
            Channels = new BindingList<ChannelModel>();
        }

        /// <summary>
        /// Добавляет канал в список каналов
        /// </summary>
        /// <param name="channel"></param>
        public void AddChannel(ChannelModel channel)
        {
           Channels.Add(channel);
        }

        /// <summary>
        /// Очищает список каналов
        /// </summary>
        public void Clear()
        {
            Channels.Clear();
        }

    }
}
