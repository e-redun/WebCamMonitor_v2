using MyLib.Controls.ChannelDashboard.Models;
using MyLib.Controls.ChannelDashboard.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Presenters
{
    public class ContextMenuPresenter
    {
        IContextMenu ContextMenuView;
        ContextMenuModel ContextMenu;

        public ContextMenuPresenter(IContextMenu view)
        {
            ContextMenuView = view;

            ContextMenu = new ContextMenuModel
            {
                ComboTogglers = view.ComboTogglers,
                AllowMultiplePanelsOpen = view.AllowMultiplePanelsOpen,
                contextMenuStrip = view.contextMenuStrip,
            };
        }
        /// <summary>
        /// Заполнение контекстного меню
        /// </summary>
        internal void Initialize()
        {
            ContextMenuStrip contextMenuStrip = ContextMenu.contextMenuStrip;
            
            // непрозрачность
            contextMenuStrip.Opacity = 0.9;

            // шапка
            // Разрешить открытие нескольких панелей
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("AllowMultiplePanelsOpen", "Разрешить открытие нескольких пакетов", true));
            contextMenuStrip.Items["AllowMultiplePanelsOpen"].Click += AllowMultiplePanelsOpen_Click;

            // сепаратор
            contextMenuStrip.Items.Add(CreateMenuSeparator());

            // подвал
            // сепаратор
            contextMenuStrip.Items.Add(CreateMenuSeparator());

            // Раскрыть все пакеты каналов
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("ExpandAllPackages", "Развернуть все пакеты", false));
            contextMenuStrip.Items["ExpandAllPackages"].Click += ExpandAllPackagesHandler;

            // Свернуть все пакеты каналов
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("CollapseAllPackages", "Cвернуть все пакеты", false));
            contextMenuStrip.Items["CollapseAllPackages"].Click += CollapseAllPackagesHandler;

            // Закрыть меню
            contextMenuStrip.Items.Add(LibFactory.CreateMenuItem("Close", "Закрыть", false));
            contextMenuStrip.Items["Close"].Click += contextMenuStrip_Close;
        }

        /// <summary>
        /// Создает разделитель меню
        /// </summary>
        /// <returns></returns>
        private ToolStripSeparator CreateMenuSeparator()
        {
            ToolStripSeparator output = new ToolStripSeparator
            {
                AutoSize = true,
            };
            return output;
        }

        /// <summary>
        /// Вставляет пункт меню
        /// </summary>
        internal void InsertComboTogglerMenuItem(int index)
        {
            ComboToggler comboToggler = ContextMenu.ComboTogglers[index];
            ContextMenuStrip contextMenuStrip = ContextMenu.contextMenuStrip;

            // имя/описание для пункта меню
            string itemName = comboToggler.Name;
            string itemDescription = comboToggler.Text;

            // индекс вставки увеличивается на два
            // так как ComboTogglers следуют после шапки меню из двух пунктов
            index += 2;

            // вставка пункта меню
            contextMenuStrip.Items.Insert(index, LibFactory.CreateMenuItem(itemName, itemDescription, true));

            // получение нового рункта меню
            ToolStripItem menuItem = contextMenuStrip.Items[index];
            
            // подписка на обработку клика на пункте меню
            menuItem.Click += ToggleComboTogglerVisability;
        }
        /// <summary>
        /// Удаляет пункт меню
        /// </summary>
        internal void RemoveComboTogglerMenuItem(int index)
        {
            ContextMenuStrip contextMenuStrip = ContextMenu.contextMenuStrip;

            // индекс меню увеличивается на два
            // так как ComboTogglers следуют после шапки меню из двух пунктов
            index += 2;

            // получение пункта меню
            ToolStripItem menuItem = contextMenuStrip.Items[index];

            // отписка на обработку клика на пункте меню
            menuItem.Click -= null;

            // удаление пункта меню
            contextMenuStrip.Items.RemoveAt(index);
        }


        #region Обработчики событий

        /// <summary>
        /// Обрабатывает щелчек мышки по пункту AllowMultiplePanelsOpen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllowMultiplePanelsOpen_Click(object sender, EventArgs e)
        {
            ContextMenuView.AllowMultiplePanelsOpen = ((ToolStripMenuItem)sender).Checked;

            if (ContextMenuView.AllowMultiplePanelsOpen)
            { /*ничего не делаем*/ }
            else
            {
                // выбрать все открытые ComboTogglers кроме первого
                var openTogglers = ContextMenu.ComboTogglers.Where(t => t.State == ExpColState.Expanded)
                                                            .Skip(1);

                // закрыть выбранные ComboTogglers
                foreach (var openToggler in openTogglers)
                {
                    openToggler.State = ExpColState.Collapsed;
                }
            }
        }

        /// <summary>
        /// Распахивает все ComboTogglers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllPackagesHandler(object sender, EventArgs e)
        {
            foreach (ComboToggler comboToggler in ContextMenu.ComboTogglers)
            {
                comboToggler.State = ExpColState.Expanded;
            }

            // закрытие меню
            contextMenuStrip_Close(null, null);
        }

        /// <summary>
        /// Сворачивает все ComboTogglers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllPackagesHandler(object sender, EventArgs e)
        {
            foreach (ComboToggler comboToggler in ContextMenu.ComboTogglers)
            {
                comboToggler.State = ExpColState.Collapsed;
            }
            // закрытие меню
            contextMenuStrip_Close(null, null);
        }

        /// <summary>
        /// Переключает видимость ComboToggler-а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleComboTogglerVisability(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            ComboToggler comboToggler = ContextMenu.ComboTogglers.Where(c => c.Name == menuItem.Name).First();

            comboToggler.Visible = menuItem.Checked;
        }

        private void contextMenuStrip_Close(object sender, EventArgs e)
        {
            ContextMenu.contextMenuStrip.Close();
        }

        #endregion
    }
}