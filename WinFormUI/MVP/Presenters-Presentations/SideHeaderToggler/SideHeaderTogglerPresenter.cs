using MyLib.Models;
using MyLib.Views;

namespace WebCamMonitor.Presenters
{
    class ChannelTogglerPresenter
    {
        IChannelToggler ChannelView;
        ChannelTogglerModel ChannelToggler;
        public ChannelTogglerPresenter(IChannelToggler view)
        {
            ChannelView = view;

            ChannelToggler = new ChannelTogglerModel();
            ChannelToggler.splitContainer = ChannelView.splitContainer;
            ChannelToggler.buttonToggle = ChannelView.toggleButton;
        }
        public void ToggleSplitContainerPanel()
        {
            ChannelToggler.ToggleSplitContainerPanel();
        }
        public void ToggleButtonSign()
        {
            ChannelToggler.ToggleButtonSign();
        }
    }
}
