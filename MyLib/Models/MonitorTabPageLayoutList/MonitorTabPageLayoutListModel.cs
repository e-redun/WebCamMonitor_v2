using System;
using MyLib.Controls.MonitorTabPageLayouts;

namespace MyLib.Models
{
    /// <summary>
    /// Модель списка шаблонов
    /// </summary>
    public class MonitorTabPageLayoutsListModel : IMonitorTabPageLayoutList
    {
        public string LayoutName { get; set; }
        public Type LayoutType { get; set; }
    }
}
