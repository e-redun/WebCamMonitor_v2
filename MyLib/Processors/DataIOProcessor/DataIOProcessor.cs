using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MyLib.Processors
{
    /// <summary>
    /// Вспомогательный класс ввода/вывода данных
    /// </summary>
    public static class DataIOProcessor
    {
        /// <summary>
        /// Возвращает DataTable
        /// </summary>
        /// <param name="filePath">Путь к XML-файлу</param>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string filePath, string tableName)
        {
            DataSet myDataSet = new DataSet();
            
            if (File.Exists(filePath))
            {
                myDataSet.ReadXml(filePath);
  
                if (myDataSet.Tables[tableName] != null)
                {
                    return myDataSet.Tables[tableName];
                }
            }
            return null;
        }

        public static Image ReadImageFile(string filePath)
        {
            Image output=null;
            try
            {
                Image image = Image.FromFile(filePath);
                output = new Bitmap(image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }

            return output;
        }
        /// <summary>
        /// Обслуживает Главные каналы
        /// </summary>
        public static class MainChannels
        {
            /// <summary>
            /// Сохраняет изменения в файле настроек
            /// </summary>
            public static void SaveDataToXmlFile(DataGridView dataGridView, string xmlFilePath)
            {
                if (dataGridView.Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(xmlFilePath))
                        if (File.Exists(xmlFilePath))
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(xmlFilePath);
                            var xmlNodes = xmlDocument.GetElementsByTagName("ChannelInfo");

                            for (int i = 0; i < xmlNodes.Count; i++)
                            {
                                string description = dataGridView.Rows[i].Cells["Description"].Value.ToString();
                                xmlNodes[i].Attributes["Description"].Value = description;
                            }

                            xmlDocument.Save(xmlFilePath);
                        }
                        else
                        {
                            // файл не существует
                            MessageBox.Show(MessageProcessor.File.DoesntExist);
                        }
                    else
                    {
                        // не выбран файл настроек
                        MessageBox.Show(MessageProcessor.File.NotChoosen);
                    }
                }
                else
                {
                    // поле Таблица настроек пусто
                    MessageBox.Show(MessageProcessor.ChannelSettings.ChannelDataTableIsEmpty);
                }
            }
        }
        /// <summary>
        /// Обслуживает Прочие каналы
        /// </summary>
        public static class OtherChannels
        {
            /// <summary>
            /// Создает xml-файл данных
            /// </summary>
            public static void CreateXmlDataFile(string xmlFilePath)
            {
                try
                {
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(xmlFilePath, System.Text.Encoding.UTF8);
                    xmlTextWriter.WriteStartDocument(true);
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.Indentation = 2;

                    xmlTextWriter.WriteStartElement("ChannelInfo");

                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndDocument();
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
                }
            }

            /// <summary>
            /// Создает xml-файл данных
            /// </summary>
            public static void SaveDataToXmlFile(DataGridView dataGridView, string xmlFilePath)
            {
                if (dataGridView.Rows.Count > 0)
                {
                    try
                    {
                        XmlTextWriter xmlTextWriter = new XmlTextWriter(xmlFilePath, System.Text.Encoding.UTF8);
                        xmlTextWriter.WriteStartDocument(true);
                        xmlTextWriter.Formatting = Formatting.Indented;
                        xmlTextWriter.Indentation = 2;

                        // открытие элемента ChannelInfo
                        xmlTextWriter.WriteStartElement("ChannelInfo");

                        for (int i = 0; i < dataGridView.RowCount - 1; i++)
                        {

                            string channelLink = dataGridView.Rows[i].Cells["ChannelLink"].Value.ToString();
                            string name = dataGridView.Rows[i].Cells["Name"].Value.ToString();
                            string description = dataGridView.Rows[i].Cells["Description"].Value.ToString();

                            CreateNode(channelLink, name, description, xmlTextWriter);
                        }
                        // закрытие элемента ChannelInfo
                        xmlTextWriter.WriteEndElement();

                        // закрытие документа
                        xmlTextWriter.WriteEndDocument();
                        xmlTextWriter.Flush();
                        xmlTextWriter.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
                    }
                }
            }

            private static void CreateNode(string channelLink, string name, string description, XmlTextWriter xmlTextWriter)
            {
                // добавление элемента ChannelInfo
                xmlTextWriter.WriteStartElement("ChannelInfo");

                // добавление атрибута Ссылка
                xmlTextWriter.WriteStartAttribute("ChannelLink");
                xmlTextWriter.WriteValue(channelLink);

                // добавление атрибута Имя канала
                xmlTextWriter.WriteStartAttribute("Name");
                xmlTextWriter.WriteValue(name);

                // добавление атрибута Описание канала
                xmlTextWriter.WriteStartAttribute("Description");
                xmlTextWriter.WriteValue(description);
                
                // закрытие элемента
                xmlTextWriter.WriteEndElement();
            }

        }
    }
}