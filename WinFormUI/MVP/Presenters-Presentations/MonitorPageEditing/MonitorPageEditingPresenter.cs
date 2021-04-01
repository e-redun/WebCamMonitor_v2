using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Controls.TabControls;
using MyLib.Controls.TabPages;
using MyLib.Models;
using MyLib.Views;


namespace WebCamMonitor.Presenters
{
    public class MonitorPageEditingPresenter
    {
        IMonitorPageView MonitorPageView;

        MonitorTabPage MonitorTabPage;

        public MonitorPageEditingPresenter(IMonitorPageView view, TabPage tabPage)
        {

            // представление
            MonitorPageView = view;

            // редактируемая MonitorTabPage
            MonitorTabPage = (MonitorTabPage)tabPage;
        }

        public void LoadTitleTextBox(TextBox textBox)
        {
            // поле для переименования MonitorTabPage
            textBox.Text = GetMonitorTabPageTitleWithoutWhiteSpace();
        }

        /// <summary>
        /// Помещает шаблон в панель
        /// </summary>
        /// <param name="panel"></param>
        public void LoadLayoutPanel(Panel panel)
        {
            // получение типа шаблона
            Type pageLayoutType = MonitorTabPage.PageLayout.GetType();

            // помещение шаблона в панель
            ReloadLayoutPanel(panel, pageLayoutType);
        }

        public void ReloadLayoutPanel(Panel panel, Type pageLayoutType)
        {
            // очистка панели шаблона
            panel.Controls.Clear();

            // получение шаблона
            MonitorTabPageLayout monitorTabPageLayout = (MonitorTabPageLayout)Activator.CreateInstance(pageLayoutType);

            // постановка шаблона в панель
            monitorTabPageLayout.Dock = DockStyle.Fill;
            panel.Controls.Add(monitorTabPageLayout);
        }
        public void PopulateLayoutFilesListBox(ListBox listBoxLayouts)
        {
            // список моделей шаблонов
            List<MonitorTabPageLayoutsListModel> layouts = new List<MonitorTabPageLayoutsListModel>();

            // коренной тип шаблонов
            Type rootMonitorTabPageLayoutType = typeof(MonitorTabPageLayout);
            
            // все наследники коренного типа шаблонов
            var childLayoutsTypes = Assembly.GetAssembly(rootMonitorTabPageLayoutType).
                                             GetTypes().
                                             Where(type => type.IsSubclassOf(rootMonitorTabPageLayoutType)).
                                             OrderBy(type => type.Name);

            foreach (var layoutType in childLayoutsTypes)
            {
                // создание экземпляра модели
                MonitorTabPageLayoutsListModel layoutModel = new MonitorTabPageLayoutsListModel
                {
                    LayoutName = layoutType.Name,
                    LayoutType = layoutType
                };

                // добавление экземпляра модели шаблона в список
                layouts.Add(layoutModel);
            }
            //listBoxLayouts.Sorted = true;
            listBoxLayouts.DataSource = layouts;
            listBoxLayouts.DisplayMember = "LayoutName";
            listBoxLayouts.ValueMember = "LayoutType";
        }

        /// <summary>
        /// Выделяет элемент в listBoxLayoutsFiles соответствующего шаблона
        /// </summary>
        /// <param name="listBoxFiles"></param>
        public void SelectCurrentLayoutItem(ListBox listBoxFiles)
        {
            // тип 
            Type type = MonitorTabPage.PageLayout.GetType();

            listBoxFiles.SelectedValue = MonitorTabPage.PageLayout.GetType();
        }
        private MonitorPageModel GetData()
        {
            return new MonitorPageModel
            {
                PageTitle = MonitorPageView.PageTitle,
            };
        }

        public string GetMonitorTabPageTitleWithoutWhiteSpace()
        {
            // старое название закладки с пробелами
            string output = MonitorTabPage.Text;

            // очистка старого названия закладки от пробелов
            output = output.Trim();

            return output;
        }
    }
}
