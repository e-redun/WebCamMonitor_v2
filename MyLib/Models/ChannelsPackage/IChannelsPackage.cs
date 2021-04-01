using System.Collections.Generic;
using System.ComponentModel;

namespace MyLib.Models
{
    public interface IChannelPackage
    {
        string Name { get; set; }
        string Description { get; set; }
        BindingList<ChannelModel> Channels { get; set; }
        void AddChannel(ChannelModel channel);
        void Clear();
    }
}