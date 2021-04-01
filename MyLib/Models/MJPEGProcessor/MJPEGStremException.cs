using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Processors.MJPEG
{
    public class MJPEGStremException : Exception
    {
        public MJPEGStremException(string message) : base(message)
        {
            
        }
    }
}
