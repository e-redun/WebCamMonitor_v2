using System;
using System.Drawing;

namespace MyLib.Processors.MJPEG
{
    public class FrameReadyEventArgs : EventArgs
    {
        public Bitmap Bitmap;
    }
}
