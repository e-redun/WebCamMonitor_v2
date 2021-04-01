using System;
using MyLib.Controls.MonitorTabPageLayouts;

namespace MyLib.Models
{
    public interface IMonitorTabPageLayoutList
    {
        string LayoutName { get; set; }
        Type LayoutType { get; set; }
    }
}