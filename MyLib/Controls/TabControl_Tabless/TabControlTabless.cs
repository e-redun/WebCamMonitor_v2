using System;
using System.Windows.Forms;

namespace MyLib.Controls.TabControls
{
    public partial class TabControlTabLess : System.Windows.Forms.TabControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }
    }
}
