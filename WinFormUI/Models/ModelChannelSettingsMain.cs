using MyLib.Interfaces;
using System.Windows.Forms;

namespace WebCamMonitor.Models
{
    class ModelChannelSettingsMain : IChannelSettingsMain
    {
        public string XmlFilePath { get; set; }
        public string DataTableName { get; set; }
        public string BaseLink { get; set; }
        public string Login { get; set; }
        public string ResolutionX { get; set; }
        public string ResolutionY { get; set; }
        public string Fps { get; set; }
    }
}
