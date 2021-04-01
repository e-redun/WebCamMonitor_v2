using MyLib.Models;
using MyLib.Views;
using System.Windows.Forms;

namespace MyLib.Models
{
    /// <summary>
    /// Представляет модель настроек Прочих каналов
    /// </summary>
    public class OtherChannelSettingsModel : IOtherChannelSettings
    {
        public string XmlFilePath { get; set; }
        public string DataTableName { get; set; }
        public string SnapshotRootFolder { get; set; }
    }
}
