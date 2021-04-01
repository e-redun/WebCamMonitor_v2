using MyLib.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Views
{
    public interface ITogglerHandler
    {
        BindingList<ComboToggler> ComboTogglers { get; set; }
        List<IChannelPackage> ChannelPackages { get; set; }
        Panel PanelTogglers { get; set; }
        bool AllowMultiplePanelsOpen { get; set; }
    }
}