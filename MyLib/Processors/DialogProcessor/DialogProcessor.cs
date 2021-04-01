using MyLib.Models;
using MyLib.Views;
using System.IO;
using System.Windows.Forms;

namespace MyLib.Processors.DialogProcessor
{
    public static class DialogProcessor
    {
        /// <summary>
        /// Открывает диалоговое окно для загрузки файла настроек Прочих каналов
        /// </summary>
        public static void OpenSettingsFileDialog(IOtherChannelSettings channelSettings)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            if (string.IsNullOrWhiteSpace(channelSettings.XmlFilePath))
            {
                // начальный путь к папке по-умолчанию
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, @"Resources\XMLs");
            }
            else
            {   // начальный путь к папке из сохраненного в поле

                if (Directory.Exists(Path.GetDirectoryName(channelSettings.XmlFilePath)))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(channelSettings.XmlFilePath);
                }
            }

            openFileDialog.Filter = "Файлы(*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                channelSettings.XmlFilePath = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Открывает диалоговое окно для загрузки файла настроек Главных каналов
        /// </summary>
        public static void OpenSettingsFileDialog(IMainChannelSettings channelSettings)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            if (string.IsNullOrWhiteSpace(channelSettings.XmlFilePath))
            {
                // начальный путь к папке по-умолчанию
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, @"Resources\XMLs");
            }
            else
            {   // начальный путь к папке из сохраненного в поле

                if (Directory.Exists(Path.GetDirectoryName(channelSettings.XmlFilePath)))
                {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(channelSettings.XmlFilePath);
                }
            }

            openFileDialog.Filter = "Файлы(*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                channelSettings.XmlFilePath = openFileDialog.FileName;
            }
        }
        /// <summary>
        /// Открывает диалоговое окно для выбора папки. Возвращает путь.
        /// </summary>
        /// <param name="path">Путь к папке - место открытия окна</param>
        public static string SelectFolder(string path)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = path;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                return folderBrowserDialog.SelectedPath;
            }

            return path;
        }
    }
}