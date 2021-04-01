using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLib.Processors
{
    public static class Photographer
    {
        /// <summary>
        /// Делает фотографию с плеера и сохряняет на диске
        /// </summary>
        /// <param name="channel"></param>
        public static void TakeMonitorPlayerSnapshot(ChannelModel channel, Image image, UserControl player)
        {
            try
            {
                // получение текущего времени
                DateTime dateTime = DateTime.Now;

                // получение полного пути файла
                // корневая папка
                TextBox textBox = ((TextBox)(player.ParentForm.Controls.Find("textBoxPlayerSnapshotFolder", true)[0]));

                string rootPath = textBox.Text;

                // путь к папке
                string folderPath = Path.Combine(rootPath, channel.Name);

                // валидация папки
                Validator.ValidateAndCreateFolder(folderPath);

                // имя файла
                string fileName = dateTime.ToString("yyyyMMddHHmmss");
                fileName += $"_{channel.Name}.jpg";

                // полный путь к файлу
                string fullPath = Path.Combine(folderPath, fileName);

                // сохранение
                image.Save(fullPath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        /// <summary>
        /// Делает фотографию канала (с плеера) и сохряняет на диске
        /// </summary>
        /// <param name="channel"></param>
        public static void TakeChannelSnapshot(ChannelModel channel, Image image, UserControl player)
        {
            // присвоение снимка каналу
            AssignChannelSnapshot(channel, image);

            // сохранение снимка на диск
            SaveSnapshotOnDisk(channel, image, player);
        }

        /// <summary>
        /// Сохраняет снимок на диск
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="image"></param>
        private static void SaveSnapshotOnDisk(ChannelModel channel, Image image, UserControl player)
        {
            try
            {
                // получение полного пути файла
                // корневая папка
                TextBox textBox = ((TextBox)(player.ParentForm.Controls.Find("textBoxChannelSnapshotFolder", true)[0]));

                string rootPath = textBox.Text;

                // путь к папке
                string folderPath = Path.Combine(rootPath, channel.ChannelPackage.Name);

                // валидация папки
                Validator.ValidateAndCreateFolder(folderPath);

                string fileName = channel.Name + ".jpg";

                // полный путь к файлу
                string fullPath = Path.Combine(folderPath, fileName);

                // сохранение
                image.Save(fullPath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }

        private static void AssignChannelSnapshot(ChannelModel channel, Image image)
        {
            // присвоение снимка каналу
            channel.Picture = image;
        }
    }
}