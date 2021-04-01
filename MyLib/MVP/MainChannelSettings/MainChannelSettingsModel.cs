using MyLib.Models;
using MyLib.Views;
using System.Windows.Forms;

namespace MyLib.Models
{
    /// <summary>
    /// Представляет модель настроек главных каналов
    /// </summary>
    public class MainChannelSettingsModel : IMainChannelSettings//IMainChannelSettings
    {
        public string XmlFilePath { get; set; }
        public string DataTableName { get; set; }
        public string BaseLink { get; set; }
        public string Login { get; set; }
        public string ResolutionX { get; set; }
        public string ResolutionY { get; set; }
        public string Fps { get; set; }
        public string SnapshotRootFolder { get; set; }
    }
}
