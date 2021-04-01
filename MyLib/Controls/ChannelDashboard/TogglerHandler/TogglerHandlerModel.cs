using MyLib.Controls.ChannelDashboard.Views;
using MyLib.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Models
{
    public class TogglerHandlerModel : ITogglerHandler
    {
        public BindingList<ComboToggler> ComboTogglers { get; set; }
        public Panel PanelTogglers { get; set; }
        public List<IChannelPackage> ChannelPackages { get; set; }
        public bool AllowMultiplePanelsOpen { get; set; }
    }
}
