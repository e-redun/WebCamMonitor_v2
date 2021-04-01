using System.ComponentModel;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Views
{
    public interface IContextMenu
    {
        BindingList<ComboToggler> ComboTogglers { get; set; }
        bool AllowMultiplePanelsOpen { get; set; }
        ContextMenuStrip contextMenuStrip { get; set; }
    }
}
