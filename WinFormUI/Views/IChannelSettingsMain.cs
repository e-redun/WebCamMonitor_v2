using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamMonitor.Views
{
    public interface IChannelSettingsMain
    {
        string XmlFilePath { get; set; }
        string DataTableName { get; set; }
        string BaseLink { get; set; }
        string Login { get; set; }
        string ResolutionX { get; set; }
        string ResolutionY { get; set; }
        string Fps { get; set; }
//        DataGridView dgvChannels { get; }
    }
}
