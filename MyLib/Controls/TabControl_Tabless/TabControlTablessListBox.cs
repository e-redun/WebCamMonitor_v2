using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.Processors;
using System.Reflection;

namespace MyLib.Controls.TabControls
{
    public class TabControlTablessListBox : ListBox
    {
        public List<SettingsTabPage> SettingsPages { get; set; }
        public TabControl TabControlTabLess { get; set; }

        public void Initialize()
        {

            this.SuspendLayout();

            SettingsPages = new List<SettingsTabPage>
            {
                new SettingsTabPage { Name = "MainChannelsSettings", Description = "Настройки главных каналов" },
                new SettingsTabPage { Name = "MainChannels", Description = "Главные каналы" },
                new SettingsTabPage { Name = "OtherChannels", Description = "Прочие каналы" },
                new SettingsTabPage { Name = "OtherSettings", Description = "Прочие настройки" },
                //new SettingsTabPage { Name = "MonitorLayouts", Description = "Шаблоны мониторов" },
            };
            
            this.DataSource = SettingsPages;
            this.DisplayMember = "Description";
            this.ValueMember = "Name";
            this.SelectedIndexChanged += new System.EventHandler(this.SelectTabPage);
            
            this.ResumeLayout(false);
        }
        /// <summary>
        /// Выделяет страницу TabControl согласно выбранному пункту списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTabPage(object sender, EventArgs e)
        {
            string tabPageName = "tabPage" + ((ListBox)sender).SelectedValue.ToString();

            try
            {
                TabControlTabLess.SelectTab(tabPageName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageProcessor.ExceptionDescriptor(MethodInfo.GetCurrentMethod().Name, ex));
            }
        }
    }
}