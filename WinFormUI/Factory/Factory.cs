using MyLib.Models;
using MyLib.Controls.VideoPlayers;
using MyLib.Views;

namespace WebCamMonitor
{
    public static class Factory
    {
        /// <summary>
        /// Создает и возвращает экземпляр ChannelsPackage
        /// </summary>
        /// <returns></returns>
        public static IChannelPackage CreateChannelPackage(string name, string description)
        {
            return new ChannelsPackageModel
            {
                Name = name,
                Description = description,
            };
        }

        internal static OtherSettingsModel CreateOtherSettings(IOtherSettings otherSettingsView)
        {
            return new OtherSettingsModel
            {
                channelSnapshotFolder = otherSettingsView.channelSnapshotFolder,
                playerSnapshotFolder  = otherSettingsView.playerSnapshotFolder,
            };
        }


        /// <summary>
        /// Возвращает новый экземпляр MainChannelSettingsModel
        /// </summary>
        /// <returns>MainChannelSettingsModel</returns>
        public static MainChannelSettingsModel CreateMainChannelSettings(IMainChannelSettings view)
        {
            return new MainChannelSettingsModel
            {
                XmlFilePath    = view.XmlFilePath,
                DataTableName  = view.DataTableName,
                BaseLink       = view.BaseLink,
                Login          = view.Login,
                ResolutionX    = view.ResolutionX,
                ResolutionY    = view.ResolutionY,
                Fps            = view.Fps,
                SnapshotRootFolder = view.SnapshotRootFolder,
            };
        }
        /// <summary>
        /// Возвращает новый экземпляр OtherChannelSettingsModel
        /// </summary>
        /// <returns>OtherChannelSettingsModel</returns>
        public static OtherChannelSettingsModel CreateOtherChannelSettings(IOtherChannelSettings view)
        {
            return new OtherChannelSettingsModel
            {
                XmlFilePath    = view.XmlFilePath,
                SnapshotRootFolder = view.SnapshotRootFolder,
            };
        }
    }
}