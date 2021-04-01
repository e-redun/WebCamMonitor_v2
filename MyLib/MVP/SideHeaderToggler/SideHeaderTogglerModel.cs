using MyLib.Views;
using System;
using System.Windows.Forms;

namespace MyLib.Models
{
    public class ChannelTogglerModel
    {
        public SplitContainer splitContainer;
        public Button buttonToggle;
        public bool Collapsed = true;

        public void ToggleSplitContainerPanel()
        {
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;
        }
        public void ToggleButtonSign()
        {
            if (splitContainer.Panel2Collapsed)
            {
                char leftArrow = '\x7C';
                buttonToggle.Text = leftArrow.ToString();
            }
            else
            {
                char rightArrow = '\x7D';
                buttonToggle.Text = rightArrow.ToString();
            }
        }
    }
}