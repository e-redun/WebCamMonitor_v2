using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Views;

namespace WebCamMonitor
{
    public partial class FormEditMonitorPage : Form
    {
        // см. папку MVP

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("FormMain_KeyDown");
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("FormMain_KeyPress");
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("FormMain_KeyUp");
        }
    }
}
