using System.ComponentModel;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Views
{
    public class ContextMenuModel : IContextMenu
    {
        public BindingList<ComboToggler> ComboTogglers { get; set; }
        public bool AllowMultiplePanelsOpen { get; set; }
        public ContextMenuStrip contextMenuStrip { get; set; }
    }
}
