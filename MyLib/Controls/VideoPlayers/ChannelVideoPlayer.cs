using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.Controls.VideoPlayers
{
    public partial class ChannelVideoPlayer : VideoPlayer
    {
        public ChannelVideoPlayer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Изменяет размеры плеера согласно соотношению картинки высота/ширина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelVideoPlayer_Resize(object sender, EventArgs e)
        {
            // получение соотношения высота/ширина картинки
            Image image = pictureBox.Image;
            int pictureBoxNewHeight = this.Width * image.Height / image.Width;

            // растянуть
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // установка высоты плеера с учетом промежутока между карточками
            // роль промежутка играет splitContainer.Panel2
            this.Height = pictureBoxNewHeight + splitContainer.Height - splitContainer.SplitterDistance;
        }
    }
}