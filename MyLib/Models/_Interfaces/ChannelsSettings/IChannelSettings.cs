namespace MyLib.Models
{
    /// <summary>
    /// Интерфейс странички Настройки главных каналов
    /// </summary>
    public interface IChannelSettings
    {
        string XmlFilePath { get; set; }
        string SnapshotRootFolder { get; set; }
    }
}