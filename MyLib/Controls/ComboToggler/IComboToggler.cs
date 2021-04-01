using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MyLib.Controls.VideoPlayers;
using MyLib.Models;

namespace MyLib.Controls
{
    public interface IComboToggler
    {
        IChannelPackage ChannelPackage { get; set; }
        ExpandDirection ExpandDirection { get; set; }

        Image Icon { get; set; }
        ExpColState State { get; set; }
        string Text { get; set; }
        BindingList<VideoPlayer> ChannelPlayers { get; set; }
    }
}