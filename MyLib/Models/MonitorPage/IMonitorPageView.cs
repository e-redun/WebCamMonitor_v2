using MyLib.Controls.MonitorTabPageLayouts;

namespace MyLib.Views
{
    public interface IMonitorPageView
    {
        string PageTitle { get; set; }
        MonitorTabPageLayout PageLayout { get; set; }

        //string LayoutFileName { get; set; }
        //string LayoutsFolder { get; set; }
        
    }
}