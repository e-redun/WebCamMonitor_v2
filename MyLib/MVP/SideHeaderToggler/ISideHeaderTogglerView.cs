using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLib.Views
{
    public interface IChannelToggler
    {
        SplitContainer splitContainer { get;  }
        Button toggleButton { get; }
    }
}
