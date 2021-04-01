using MyLib.Controls.ChannelDashboard.Models;
using MyLib.Controls.ChannelDashboard.Views;
using MyLib.Controls.ChannelDashboard.Presenters;
using MyLib.Models;
using MyLib.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard
{
    public partial class ChannelDashboard : UserControl, IContextMenu, ITogglerHandler
    {
        /// <summary>
        /// Делегат пакетной обработки канлалов
        /// </summary>
        public delegate void PackageOperations(Operations operation);
        public PackageOperations PackageOperationsDelegate;


        /// <summary>
        /// Список каналов
        /// </summary>
        List<IChannelPackage> ChannelPackages;

        /// <summary>
        /// Список ComboToggler
        /// </summary>
        public BindingList<ComboToggler> ComboTogglers;

        /// <summary>
        /// Список картинок для кнопки вызова меню
        /// </summary>
        ImageList imageList;

        /// <summary>
        /// Флаг - Разрешить открывать несколько панелей одновременно
        /// </summary>
        public bool AllowMultiplePanelsOpen { get; set; }// = true;

        private ExpColState MenuState { get; set; } = ExpColState.Collapsed;

        #region Интерфейс IContextMenu
        BindingList<ComboToggler> IContextMenu.ComboTogglers
        {
            get
            {
                return this.ComboTogglers;
            }
            set
            {
                this.ComboTogglers = value;
            }
        }

        bool IContextMenu.AllowMultiplePanelsOpen
        {
            get
            {
                return this.AllowMultiplePanelsOpen;
            }
            set
            {
                this.AllowMultiplePanelsOpen = value;
            }
        }

        ContextMenuStrip IContextMenu.contextMenuStrip
        {
            get
            {
                return this.contextMenuStrip;
            }
            set
            {
                this.contextMenuStrip = value;
            }
        }
        #endregion

        #region Интерфейс ITogglerHandler
        BindingList<ComboToggler> ITogglerHandler.ComboTogglers
        {
            get
            {
                return this.ComboTogglers;
            }
            set
            {
                this.ComboTogglers = value;
            }
        }
        List<IChannelPackage> ITogglerHandler.ChannelPackages
        {
            get
            {
                return this.ChannelPackages;
            }
            set
            {
                this.ChannelPackages = value;
            }
        }
        Panel ITogglerHandler.PanelTogglers
        { 
            get
            {
                return this.panelTogglers;
            }
            set
            {
                this.panelTogglers = value;
            }
        }
        bool ITogglerHandler.AllowMultiplePanelsOpen
              {
            get
            {
                return this.AllowMultiplePanelsOpen;
            }
            set
            {
                this.AllowMultiplePanelsOpen = value;
            }
        }
        #endregion

        public ChannelDashboard()
        {
            InitializeComponent();

            ChannelPackages = new List<IChannelPackage>();

            ComboTogglers = new BindingList<ComboToggler>();

            // инициализация контекстного меню
            InitializeMenu();

            // инициализация списка иконок для кнопки вызова меню
            InitializeListImage();

            // первоначальная иконка на кнопке вызова меню
            buttonContextMenu.Image = imageList.Images["Normal"];

            // подписка на изменения списка ComboTogglers
            ComboTogglers.ListChanged += ComboTogglers_ListChanged;
        }

        /// <summary>
        /// Инициализация меню
        /// </summary>
        private void InitializeMenu()
        {
            ContextMenuPresenter contextMenuPresenter = new ContextMenuPresenter(this);
            contextMenuPresenter.Initialize();
        }

        /// <summary>
        /// Обрабатчик измений в списке BindingList<ComboToggler>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboTogglers_ListChanged(object sender, ListChangedEventArgs e)
        {
            // контроль Controls Enabled
            DashboardControlsEnabling(sender);

            ContextMenuPresenter contextMenuPresenter = new ContextMenuPresenter(this);

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:

                    contextMenuPresenter.InsertComboTogglerMenuItem(e.NewIndex);
                    break;

                case ListChangedType.ItemDeleted:

                    contextMenuPresenter.RemoveComboTogglerMenuItem(e.NewIndex);
                    break;
            }
        }

        /// <summary>
        /// Контролирует свойство Enabled некоторых контролов
        /// </summary>
        /// <param name="sender"></param>
        private void DashboardControlsEnabling(object sender)
        {
            BindingList<ComboToggler> comboTogglers = (BindingList<ComboToggler>)sender;

            if (comboTogglers.Count > 0)
            {
                SetControlsEnabled(true);
            }
            else
            {
                SetControlsEnabled(false);
            }
        }

        /// <summary>
        /// Устанавливает Enabled для элементов управления
        /// </summary>
        /// <param name="myBool"></param>
        private void SetControlsEnabled(bool myBool)
        {
            // Enabling
            buttonStart.Enabled = myBool;
            buttonStop.Enabled = myBool;
            buttonDelete.Enabled = myBool;
            panelContextMenu.Enabled = myBool;
        }
        

        /// <summary>
        /// Добавляет ComboToggler на форму
        /// </summary>
        /// <param name="channelPackage"></param>
        public void AddChannelPackage(IChannelPackage channelPackage)
        {
            TogglerHandlerPresenter togglerHandler = new TogglerHandlerPresenter(this);
            togglerHandler.AddChannelPackage(channelPackage);
        }
        

        /// <summary>
        /// Инициализирует список иконок для кнопки для конт. меню
        /// </summary>
        private void InitializeListImage()
        {
            imageList = new ImageList();

            // задание размерности массиву imageList
            Image image = Properties.Resources.normalListIcon;
            imageList.ImageSize = image.Size;

            // заполнение массива
            imageList.Images.Add("Normal", Properties.Resources.normalListIcon);
            imageList.Images.Add("Enter", Properties.Resources.enterListIcon);
            imageList.Images.Add("Down", Properties.Resources.selectedListIcon);
        }

        #region Подсказки ToolTips
        private void buttonReload_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPackagesTips.ReloadChannelsPackages);
        }

        private void buttonLoad_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPackagesTips.LoadChannelsPackages);
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPackagesTips.StartAllChannels);
        }

        private void buttonStop_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPackagesTips.StopAllChannels);
        }

        private void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ToolTip toolTip = LibFactory.CreatNewTooltip();
            toolTip.SetToolTip(button, MessageProcessor.ChannelPackagesTips.DeleteAllChannels);
        }
        #endregion

        #region Изменение иконки кнопки вызова контекстного меню
        private void buttonContextMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonContextMenu.Image = imageList.Images["Enter"];
        }

        private void buttonContextMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonContextMenu.Image = imageList.Images["Normal"];
        }

        private void buttonContextMenu_MouseDown(object sender, MouseEventArgs e)
        {
            // иконка
            buttonContextMenu.Image = imageList.Images["Down"];

            if (MenuState == ExpColState.Expanded)
            {               
                // закрытие
                contextMenuStrip.Close();
                
                // состояние Свернуто
                MenuState = ExpColState.Collapsed;
            }
            else
            {
                // координаты вывода меню
                int pointX = panelContextMenu.Width - contextMenuStrip.Width; // "выравнивание" по правому краю панели
                int pointY = panelContextMenu.Height; // сразу под панелью
                
                // проявление меню
                contextMenuStrip.Show(panelContextMenu, new Point(pointX, pointY));
                
                // состояние Развернуто
                MenuState = ExpColState.Expanded;
            }
        }
        #endregion

        #region Нажатие кнопок Load(Reload)/Start/Stop

        /// <summary>
        /// Вызывает делегат загрузки всех каналов из файлов данных каналов
        /// </summary>
        private void buttonReload_Click(object sender, EventArgs e)
        {
            // вызов делегата загрузки всех каналов
            PackageOperationsDelegate?.Invoke(Operations.Reload);
        }

        /// <summary>
        /// Вызывает делегат загрузки всех каналов из таблиц
        /// </summary>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // вызов делегата загрузки всех каналов
            PackageOperationsDelegate?.Invoke(Operations.Load);
        }

        /// <summary>
        /// Вызывает делегат Старта всех каналов
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            PackageOperationsDelegate?.Invoke(Operations.Start);
        }

        /// <summary>
        /// Вызывает делегат остановки всех каналов
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            PackageOperationsDelegate?.Invoke(Operations.Stop);
        }

        /// <summary>
        /// Удаляет все пакеты (ComboTogglers) каналов из боковой панели
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            PackageOperationsDelegate?.Invoke(Operations.Delete);
        }

        #endregion

        /// <summary>
        /// Закрывает контекстное меню по нажатию Escape
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                contextMenuStrip.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string tmp = "";
            tmp += "ChannelPackages.Count = " + ChannelPackages.Count + "\n";
            tmp += "ComboTogglers.Count = " + ComboTogglers.Count + "\n";
            tmp += "contextMenuStrip.Items.Count = " + contextMenuStrip.Items.Count + "\n";
            MessageBox.Show(tmp);
        }
    }
}
