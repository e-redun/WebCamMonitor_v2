
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLib.Processors
{
    public static class Validator
    {
        /// <summary>
        /// Проверяет существует ли путь к файлу
        /// </summary>
        /// <param name="filePath">Полный путь файла</param>
        /// <returns></returns>
        public static bool IsFilePathEmpty(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет существует ли файл
        /// </summary>
        /// <param name="filePath">Полный путь файла</param>
        /// <returns></returns>
        public static bool IsFilePathValid (string filePath)
        {
            if (File.Exists(filePath))
            { }
            else
            { 
                return false;
            }

            return true;
        }

        public static void ValidateAndCreateFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            { }
            else
            {
                Directory.CreateDirectory(folderPath);
            }
       }
    }
}
