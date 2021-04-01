using MyLib.Models;

namespace MyLib.Views
{
    /// <summary>
    /// Представляет View Настроек главных каналов
    /// </summary>
    public interface IMainChannelSettings : IMained
    {
        string XmlFilePath { get; set; }
        string SnapshotRootFolder { get; set; }
    }
}
