using MyLib.Models;
using MyLib.Processors;
using MyLib.Processors.DialogProcessor;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WebCamMonitor.Presenters
{
    public class OtherSettingsPresenter
    {
        IOtherSettings OtherSettingsView;
        OtherSettingsModel OtherSettings;

        public OtherSettingsPresenter(IOtherSettings view)
        {
            OtherSettingsView = view;

            OtherSettings = Factory.CreateOtherSettings(OtherSettingsView);
        }

        /// <summary>
        /// Открывает в Проводнике папку указанную в поле channelSnapshotFolder
        /// </summary>
        public void OpenChannelSnapshotFolder()
        {
            OpenFolderInExplorer(OtherSettings.channelSnapshotFolder);
        }

        /// <summary>
        /// Открывает в Проводнике папку указанную в поле channelSnapshotFolder
        /// </summary>
        public void OpenPlayerSnapshotFolder()
        {
            OpenFolderInExplorer(OtherSettings.playerSnapshotFolder);
        }

        /// <summary>
        /// Открывает папку в проводнике
        /// </summary>
        /// <param name="path">Путь к папке</param>
        private void OpenFolderInExplorer(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /n, " + path));
            }
        }

        /// <summary>
        /// Загружает Настройки страницы tabPageOtherSettings из файла параметров/ресурсов
        /// </summary>
        /// <param name="tabPageOtherSettings"></param>
        internal void LoadValuesOnControl(Control tabPageOtherSettings)
        {
            try
            {
                // чек-бокс автоматической загрузки каналов
                CheckBox checkBox = (CheckBox)tabPageOtherSettings.Controls["checkBoxLoadChannels"];
                SettingsSaveLoadProcessor.LoadValue(checkBox);

                // путь сохранения снимков каналов
                SettingsSaveLoadProcessor.LoadFolderPathTextBoxValueAndCheckForDefault(tabPageOtherSettings, "textBoxChannelSnapshotFolder");

                // путь сохранения снимков плееров
                SettingsSaveLoadProcessor.LoadFolderPathTextBoxValueAndCheckForDefault(tabPageOtherSettings, "textBoxPlayerSnapshotFolder");
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }


        /// <summary>
        /// Открывает диалоговое окно для выбора папки снимков каналов (канальных плееров). Возвращает путь.
        /// </summary>
        internal string SelectChannelSnapshotFolder()
        {
            return DialogProcessor.SelectFolder(OtherSettings.channelSnapshotFolder);
        }

        /// <summary>
        /// Открывает диалоговое окно для выбора папки снимков плееров (мониторных плееров). Возвращает путь.
        /// </summary>
        internal string SelectPlayerSnapshotFolder()
        {
            return DialogProcessor.SelectFolder(OtherSettings.playerSnapshotFolder);
        }
    }
}
