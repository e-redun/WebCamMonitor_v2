using MyLib.Controls.ChannelDashboard.Models;
using MyLib.Controls.ChannelDashboard.Views;
using MyLib.Models;
using MyLib.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MyLib.Controls.ChannelDashboard.Presenters
{
    public class TogglerHandlerPresenter : TogglerHandlerModel
    {
        ITogglerHandler TogglerHandlerView;
        TogglerHandlerModel TogglerHandler;
        
        public TogglerHandlerPresenter(ITogglerHandler view)
        {
            TogglerHandlerView = view;
            TogglerHandler = new TogglerHandlerModel();
        }

        private void GetViewData(ITogglerHandler view)
        {
            TogglerHandler.PanelTogglers = view.PanelTogglers;
            TogglerHandler.ComboTogglers = view.ComboTogglers;
            TogglerHandler.ChannelPackages = view.ChannelPackages;
            TogglerHandler.AllowMultiplePanelsOpen = view.AllowMultiplePanelsOpen;
        }

        /// <summary>
        /// Добавляет ComboToggler на форму
        /// </summary>
        /// <param name="channelPackage"></param>
        public void AddChannelPackage(IChannelPackage channelPackage)
        {
            GetViewData(TogglerHandlerView);

            BindingList<ComboToggler> ComboTogglers = TogglerHandler.ComboTogglers;
            List <IChannelPackage> ChannelPackages = TogglerHandler.ChannelPackages;
            Panel panelTogglers = TogglerHandler.PanelTogglers;

            try
            {
                if (channelPackage == null) return;
                
                if (ChannelPackages.Contains(channelPackage))
                {
                }
                else
                {
                    //// добавление в список пакетов каналов
                    ChannelPackages.Add(channelPackage);

                    // получение нового ComboToggler
                    ComboToggler comboToggler = LibFactory.CreateComboToggler(channelPackage);

                    comboToggler.Name = channelPackage.Name;
                    comboToggler.Text = channelPackage.Description;

                    // подписка на событие разворачивания ComboToggler
                    comboToggler.ComboTogglerExpantion += ComboTogglerExpantionHandler;

                    // Подписка на запрос на удаление/Dispose ComboToggler-a
                    comboToggler.DisposeRequest += ComboTogglerDisposedRequestHandler;

                    // добавление в список ComboTogglers
                    ComboTogglers.Add(comboToggler);

                    // добавление в панель
                    panelTogglers.Controls.Add(comboToggler);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }


        /// <summary>
        /// TODO проверить переделать на "попроще"??? Обработчик самовыпиливания ComboToggler-a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboTogglerDisposedRequestHandler(object sender, EventArgs e)
        {
            GetViewData(TogglerHandlerView);

            BindingList<ComboToggler> ComboTogglers = TogglerHandler.ComboTogglers;
            List<IChannelPackage> ChannelPackages = TogglerHandler.ChannelPackages;
            Panel panelTogglers = TogglerHandler.PanelTogglers;

            ComboToggler comboToggler = (ComboToggler)sender;

            // удаление с панели
            panelTogglers.Controls.Remove(comboToggler);

            // отписка от события разворачивания ComboToggler
            comboToggler.ComboTogglerExpantion += null;

            // отписка от события удаление/Dispose ComboToggler-a
            comboToggler.DisposeRequest += null;

            // удаление пакета
            IChannelPackage channelPackage = comboToggler.ChannelPackage;
            ChannelPackages.Remove(channelPackage);

            // индекс ComboToggler в колекции ComboTogglers
            int index = ComboTogglers.IndexOf(comboToggler);

            // получение view формы ChannelDashboard
            IContextMenu view = (IContextMenu)panelTogglers.Parent;

            // удаление из списка ComboTogglers
            ComboTogglers.Remove(comboToggler);

            comboToggler.Dispose();
            comboToggler = null;
        }


        /// <summary>
        /// Обработчик события раскрытия одного ComboToggler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboTogglerExpantionHandler(object sender, EventArgs e)
        {
            GetViewData(TogglerHandlerView);

            BindingList<ComboToggler> ComboTogglers = TogglerHandler.ComboTogglers;
            bool AllowMultiplePanelsOpen = TogglerHandler.AllowMultiplePanelsOpen;

            ComboToggler openedComboToggler = (ComboToggler)sender;

            if (AllowMultiplePanelsOpen)// && ComboTogglers.Count > 0)
            { } /*ничего не делаем*/
            else
            {
                // найти все распахнутые, кроме только что открытого
                var openTogglers = ComboTogglers.Where(t => t.State == ExpColState.Expanded). // все открытые
                                                 Where(t => t != openedComboToggler); // кроме только что открытого

                // свернуть все найденные
                foreach (var openToggler in openTogglers)
                {
                    openToggler.State = ExpColState.Collapsed;
                }
            }
        }
    }
}
