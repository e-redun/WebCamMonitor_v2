using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.Processors
{
    public struct MessageProcessor
    {
        string text;

        public struct MonitorPlayersTips
        {
            static public string StartStopPlayer = "Запустить/остановить плеер";
            static public string StopPlayer = "Остановить плеер";
            static public string TakeSnapshot = "Сделать снимок с плеера";
            static public string DisconnectChannel = "Отключить канал";
        }
        public struct ChannelPlayersTips
        {
            static public string StartStopChannel = "Запустить/остановить трансляцию канала";
            static public string StopChannel = "Остановить канал";
            static public string TakeSnapshot = "Сделать снимок канала";
            static public string DeleteChannel = "Удалить канал из списка";
        }
        public struct ChannelPackagesTips
        {
            static public string ReloadChannelsPackages = "Перезагрузить пакеты каналов из файлов";
            static public string LoadChannelsPackages = "Перезагрузить пакеты каналов из таблиц";
            static public string StartAllChannels = "Запустить все каналы (в открытых пакетах)";
            static public string StopAllChannels = "Остановить все каналы";
            static public string DeleteAllChannels = "Удалить все каналы из списка";
        }
        public struct ChannelSettings
        {
            static public string ChannelDataIsNotLoaded = "Не загружены данные каналов";
            static public string ChannelDataTableIsEmpty = "Таблица данных каналов пуста";
        }
        public struct DataGridView
        {
            static public string IsEmpty = "Таблица каналов пуста";
        }

        public struct File
        {
            static public string DoesntExist = "Файл с таким именем не существует";
            static public string NotChoosen = "Не выбран файл настроек";
            static public string NotChoosenOrDoesntExist = "Файл настроек не выбран или не существует. Создать и выбрать?";
        }
        public static string WebExceptionStatuses(string key)
        {
            Dictionary<string, string> webExceptionStatuses = new Dictionary<string, string>
            {
                { "ConnectFailure", "Невозможно подключиться к ресурсу." },
                { "ConnectionClosed", "Подключение было преждевременно закрыто." },
                { "KeepAliveFailure", "Сервер закрыл подключение, для которого был установлен заголовок Keep-Alive." },
                { "MessageLengthLimitExceeded", "Запрос превышает допустимый размер." },
                { "NameResolutionFailure", "Служба DNS не может сопоставить имя хоста с ip-адресом." },
                { "ProtocolError", "Запрос был завершен, но возникла ошибка на уровне протокола, например, запрошенный ресурс не был найден." },
                { "ReceiveFailure", "От удаленного сервера не был получен полный ответ." },
                { "RequestCanceled", "Запрос был отменен." },
                { "SecureChannelFailure", "При установлении подключения с использованием SSL произошла ошибка." },
                { "SendFailure", "Полный запрос не был передан на удаленный сервер." },
                { "ServerProtocolViolation", "Ответ сервера не являлся допустимым ответом HTTP." },
                { "Timeout", "Ответ не был получен в течение определенного времени." },
                { "TrustFailure", "Сертификат сервера не может быть проверен." },
                { "UnknownError", "Ввозникло исключение неизвестного типа." },
            };
            return webExceptionStatuses[key];
        }

        /// <summary>
        /// Выводит имя метода, в котором было вызвано исключение и описание последнего
        /// </summary>
        /// <param name="methodName">Имя метода, в котором было вызвано исключение</param>
        /// <param name="ex">Исключение</param>
        /// <returns></returns>
        public static string ExceptionDescriptor(string methodName, Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Метод:\n");
            stringBuilder.Append(methodName + "\n\n");
            stringBuilder.Append(ex.Message);
            
            return stringBuilder.ToString();
        }
    }
}