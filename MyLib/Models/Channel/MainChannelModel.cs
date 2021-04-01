using System;
using System.Drawing;
using System.Windows.Forms;
using MyLib.Models;
using MyLib.Processors;

namespace MyLib.Models
{
    /// <summary>
    /// Главный канал
    /// </summary>
    public class MainChannelModel : ChannelModel, IMained
    {
        public string BaseLink { get; set; }
        public string Login { get; set; }
        public string ResolutionX { get; set; }
        public string ResolutionY { get; set; }
        public string Fps { get; set; }
        public string DataTableName { get; set; }
    }
}