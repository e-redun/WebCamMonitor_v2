using MyLib.Controls.MonitorTabPageLayouts;
using MyLib.Views;
using WebCamMonitor.Presenters;
using System;
using System.Windows.Forms;
using MyLib.Controls.TabPages;
using MyLib.Controls.TabControls;

namespace WebCamMonitor
{
    public partial class FormEditMonitorPage : IMonitorPageView
    {
        /// <summary>
        /// Презентер
        /// </summary>
        MonitorPageEditingPresenter monitorPageEditingPresenter;

        /// <summary>
        /// пробелы в старом названии закладки
        /// Прим. пробелы нужны для отображения иконок
        /// </summary>
        //private string OldNameWhiteSpace { get; set; }

        /// <summary>
        /// Редактируемая MonitorTabPage
        /// </summary>
        private MonitorTabPage MonitorTabPage { get; set; }
        

        public FormEditMonitorPage(MonitorTabPage tabPage)
        {
            InitializeComponent();

            MonitorTabPage = tabPage;
        }

        private void FormEditMonitorPage_Load(object sender, EventArgs e)
        {
            // инициализация презентера
            monitorPageEditingPresenter = new MonitorPageEditingPresenter(
                                                 this, // форма редактирования
                                                 MonitorTabPage // редактируемая страница MonitorTabPage
                                                 );

            // загрузка textBox для переименования редактируемой  MonitorTabPage
            monitorPageEditingPresenter.LoadTitleTextBox(
                                         textBoxTabPageTitle // textBox для переименования редактируемой  MonitorTabPage
                                         );

            // загрузка шапки формы редактирования
            Text = "Редактирование " + textBoxTabPageTitle.Text;

            // загрузка списка файлов listBoxLayoutsFiles из папки шаблонов
            monitorPageEditingPresenter.PopulateLayoutFilesListBox (
                                            listBoxLayoutsFiles // listBox с именами фалов listBoxLayoutsFiles
                                            );

            // подписка обработчика на выделение элемента в списке шаблонных файлов
            this.listBoxLayoutsFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxLayoutsFiles_SelectedIndexChanged);

            // выделение элемента в listBoxLayoutsFiles шаблона редактируемой страницы
            monitorPageEditingPresenter.SelectCurrentLayoutItem(
                                                listBoxLayoutsFiles // listBox с именами фалов listBoxLayoutsFiles
                                                );
        }
        /// <summary>
        /// Обработчик выделения элемента в списке шаблонных файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxLayoutsFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// Перезагружает шаблон в панель шаблонов
            monitorPageEditingPresenter.ReloadLayoutPanel(
                                             panelLayout, // панель содержащая эскиз шаблона редактируемой  MonitorTabPage
                                             (Type)listBoxLayoutsFiles.SelectedValue // тип шаблона 
                                             );
        }

        /// <summary>
        /// Сохраняет новый шаблон и Титульник редактируемой страницы
        /// </summary>
        private void SaveSettings()
        {
            // обновление заголовка в шапке
            MonitorTabPage.Text = textBoxTabPageTitle.Text + // отображаемый заголовок в шапке
                ((TabControlDynamic)MonitorTabPage.Parent).NewTabPageTitleWhiteSpace; // пробелы под размещение иконок
            
            // обновление шаблона
            MonitorTabPage.PageLayout = (MonitorTabPageLayout)panelLayout.Controls[0];

        }
        /// <summary>
        /// По двоеному щелчку перезагружает шаблон в панель шаблонов и закрывает диалоговое окно
        /// </summary>
        private void listBoxLayoutsFiles_DoubleClick(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
        /// <summary>
        /// Сохраняет изменения и закрывает диалоговое окно
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }
        /// <summary>
        /// Закрывает диалоговое окно
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Заглавие формы редактирования
        /// </summary>
        public string PageTitle
        {
            get
            {
                return MonitorTabPage.Text;
            }
            set
            {
                MonitorTabPage.Text = value;
            }
        }

        public MonitorTabPageLayout PageLayout
        {
            get
            {
                return MonitorTabPage.PageLayout;
            }
            set
            {
                MonitorTabPage.PageLayout = value;
            }
        }
    }
}