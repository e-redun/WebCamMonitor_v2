using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Views;

namespace MyLib.Models
{
    public class MonitorPageModel : IMonitorPageView
    {
        public string PageTitle { get; set; }
        public MonitorTabPageLayout PageLayout { get; set; }

        //public string LayoutsFolder { get; set; }
        //public string LayoutFileName { get; set; }

    }
}
