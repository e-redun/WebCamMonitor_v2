using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    /// <summary>
    /// (Базовые) настройки в дополнение в настройкам простых каналов
    /// образуют Главные каналы
    /// </summary>
    public interface IMained
    {
        string BaseLink { get; set; }
        string DataTableName { get; set; }
        string Login { get; set; }
        string ResolutionX { get; set; }
        string ResolutionY { get; set; }
        string Fps { get; set; }
    }
}