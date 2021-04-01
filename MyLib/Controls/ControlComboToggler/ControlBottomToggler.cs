using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace MyLib.Controls
{
    public partial class ControlBottomToggler : UserControl
    {
        public static Image leftIcon { get; set; }
        public static Image upIcon { get; set; }
        public static Image rightIcon { get; set; }
        public static Image downIcon { get; set; }

        // текст на переключателе
        //string _header;

        ExpandDirection _expandDirection;

        /// <summary>
        /// Состояние включено/выключено
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Элеменет управления для переключения
        /// </summary>
        public Control ControlToToggle { get; set; }

        /// <summary>
        /// Направление раскрытия
        /// </summary>
        public ExpandDirection ExpandDirection
        {
            get
            {
                return _expandDirection;
            }
            set
            {
                _expandDirection = value;
                //MessageBox.Show("_expandDirection = " + _expandDirection);
                //MessageBox.Show(DesignMode.ToString());
                SetIcon();
            }
        }

        /// <summary>
        /// Иконка на кнопке переключателя
        /// </summary>
        public Image Icon
        {
            get
            {
                return buttonToggler.Image;
            }
            set
            {
                buttonToggler.Image = value;
            }
        }

        /// <summary>
        /// Текст на переключателе
        /// </summary>
        public string Header
        {
            get
            {
                return buttonToggler.Text;
            }
            set
            {
                //_header = value;
                buttonToggler.Text = value;
            }
        }

        ///// <summary>
        ///// Ориентация 
        ///// </summary>
        //public Orientation Orientation { get; set; } = Orientation.Horizontal;


        //public ContentAlignment ContentAlignment { get; set; } = ContentAlignment.
        public ControlBottomToggler()
        {
            InitializeComponent();
            
            //SetIcon();
        }
        /// <summary>
        /// Установка иконки в зависимости от направления разворота и состояния
        /// </summary>
        private void SetIcon()
        {
            
            if (State == State.Off) // если выключено = свернуто
            {
                switch (ExpandDirection)
                {
                    case ExpandDirection.Left:
                        Icon = leftIcon;
                        break;
                    case ExpandDirection.Up:
                        Icon = upIcon;
                        break;
                    case ExpandDirection.Right:
                        Icon = rightIcon;
                        break;
                    case ExpandDirection.Down:
                        Icon = downIcon;
                        break;
                }
            }
            else
            {
                switch (ExpandDirection)
                {
                    case ExpandDirection.Left:
                        Icon = rightIcon;
                        break;
                    case ExpandDirection.Up:
                        Icon = downIcon;
                        break;
                    case ExpandDirection.Right:
                        Icon = leftIcon;
                        break;
                    case ExpandDirection.Down:
                        Icon = upIcon;
                        break;
                }
            }
            buttonToggler.Refresh();
        }
        private void buttonToggler_Click(object sender, EventArgs e)
        {   
            // переключение состояния 
            State = (State == State.On) ? State.Off : State.On;

            // переключение видимости
            ControlToToggle.Visible = !ControlToToggle.Visible;
      
            // установка иконки
            SetIcon();
        }
    }

    public enum ExpandDirection
    {
        Left,
        Up,
        Right,
        Down
    }
}
