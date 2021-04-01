using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Controls.TabPages;

namespace MyLib.Controls.TabControls
{

    public class TabControlDynamic : System.Windows.Forms.TabControl
    {
        public delegate void SettingsSelection(MonitorTabPage tabPage);
        public SettingsSelection SettingsSelectionDelegate;
        public Image AddIcon { get; set; }
        public Image EditIcon { get; set; }
        public Image DelIcon { get; set; }
        public int IconDistance { get; set; }
        public string TabPageAddName { get; set; }
        public string TabPageSettingsName { get; set; }
        //public string NewTabPageDefaultName { get; set; }
        public string NewTabPageDefaultTitle { get; set; }
        public string NewTabPageTitleWhiteSpace { get; set; }
        public Size IconSize { get; set; }

        public TabControlDynamic()
        {

            // устанавливает самостоятельную отрисовку закладок
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            // отрисовка закладок
            this.DrawItem += Handler_DrawItem;
            // нажатие мышки
            this.MouseDown += Handler_MouseDown;
            // обработчик создания
            this.HandleCreated += Handler_HandleCreated;

        }


        /// <summary>
        /// Обработчик нажатия мышкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handler_MouseDown(object sender, MouseEventArgs e)
        {
            // отключение в режиме конструктора
            if (!DesignMode) 
            {
                if (this.SelectedTab.Name == TabPageAddName)
                {
                    // создание страницы с дефолтным шаблоном
                    MonitorTabPage newTabPage = new MonitorTabPage();

                    // дефолтная шапка страницы
                    newTabPage.Text = NewTabPageDefaultTitle + NewTabPageTitleWhiteSpace;

                    // вставка новой страницы в TabControl на место страницы добавления
                    this.TabPages.Insert(SelectedIndex, newTabPage);
                    
                    // переход на вновь вставленную страницу
                    this.SelectedIndex = this.SelectedIndex - 1;
                }

                // если страница Монитор (не Добавить и не Настройки)
                if (this.SelectedTab.Name != TabPageAddName && this.SelectedTab.Name != TabPageSettingsName)
                {   
                    var tabRect = this.GetTabRect(this.SelectedIndex);

                    // получени Rectangle иконки Удалить
                    var delImageRect = GetDelImageRectangle(this.SelectedIndex);

                    // получени Rectangle иконки Редактировать
                    var editImageRect = GetEditImageRectangle(this.SelectedIndex);

                    if (delImageRect.Contains(e.Location))
                    {
                        this.TabPages.RemoveAt(this.SelectedIndex);
                    }

                    if (editImageRect.Contains(e.Location))
                    {

                        TabPage tabPage = ((TabControl)sender).SelectedTab;

                        // вызов делегата для редактирования страницы
                        SettingsSelectionDelegate?.Invoke((MonitorTabPage)tabPage);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовывает заголовки и символы добавления/редактирования/удаления 
        /// на соотв. страницах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handler_DrawItem(object sender, DrawItemEventArgs e)
        {

            int tabPageIndex = e.Index;
            TabPage tabPage = this.TabPages[tabPageIndex];
            Rectangle tabRect = this.GetTabRect(tabPageIndex);
            
            // уменьшение поля для вывода текста и иконок 
            tabRect.Inflate(-2, -2);

            // фрейм (прямоугольник) по иконку
            Rectangle imageRect;
            // страница Добавить
            if (tabPage.Name == TabPageAddName)
            {   
                // иконка Добавить
                imageRect = GetAddImageRectangle(tabPageIndex);
                e.Graphics.DrawImage(AddIcon, imageRect);
            }
            // прочие страницы
            else
            {   
                if (tabPage.Name != TabPageSettingsName)
                {   // страница не Настройки
                    
                    // иконка Удалить
                    imageRect = GetDelImageRectangle(tabPageIndex);
                    e.Graphics.DrawImage(DelIcon, imageRect);

                    // иконка Редактировать
                    imageRect = GetEditImageRectangle(tabPageIndex);
                    e.Graphics.DrawImage(EditIcon, imageRect);
                }

                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            }

        }
        /// <summary>
        /// Возвращает Rectangle для символа добавления страницы
        /// </summary>
        /// <param name="tabPageIndex">Индекс страницы</param>
        /// <returns></returns>
        private Rectangle GetAddImageRectangle(int tabPageIndex)//TabPage tabPage
        {
            Rectangle tabRect = this.GetTabRect(tabPageIndex);

            return new Rectangle(tabRect.Right - (tabRect.Width + IconSize.Width) / 2,
                                 tabRect.Top + (tabRect.Height - IconSize.Height) / 2,
                                 IconSize.Width,
                                 IconSize.Height);
        }

        /// <summary>
        /// Возвращает Rectangle для символа редактирования страницы
        /// </summary>
        /// <param name="tabPageIndex">Индекс страницы</param>
        /// <returns></returns>
        private Rectangle GetEditImageRectangle(int tabPageIndex)
        {
            Rectangle tabRect = this.GetTabRect(tabPageIndex);

            return new Rectangle(tabRect.Right - 2 * IconSize.Width - 2 * IconDistance,
                                 tabRect.Top + (tabRect.Height - IconSize.Height) / 2,
                                 IconSize.Width,
                                 IconSize.Height);
        }

        /// <summary>
        /// Возвращает Rectangle для символа удаления страницы 
        /// </summary>
        /// <param name="tabPageIndex">Индекс страницы</param>
        /// <returns></returns>
        private Rectangle GetDelImageRectangle(int tabPageIndex)
        {
            Rectangle tabRect = this.GetTabRect(tabPageIndex);

            return new Rectangle(tabRect.Right - IconSize.Width - IconDistance,
                                 tabRect.Top + (tabRect.Height - IconSize.Height) / 2,
                                 IconSize.Width,
                                 IconSize.Height);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 49;
        private void Handler_HandleCreated(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                SendMessage(this.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
            }
        }
    }
}
