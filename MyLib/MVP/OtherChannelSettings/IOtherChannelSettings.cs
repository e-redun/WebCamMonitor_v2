namespace MyLib.Views
{
    /// <summary>
    /// Представляет View Настроек Прочих каналов
    /// </summary>
    public interface IOtherChannelSettings
    {
        string XmlFilePath { get; set; }
        string SnapshotRootFolder { get; set; }
    }
}
