using MyLib;
using MyLib.Controls.VideoPlayers;
using MyLib.Controls.TabControls;
using MyLib.Controls.ChannelDashboard;
using System;
using System.Windows.Forms;

namespace WebCamMonitor
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            
            // остановить все каналы
            PackageOperations(Operations.Stop);

            // удалить все каналы
            PackageOperations(Operations.Delete);

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonToggleChannel = new System.Windows.Forms.Button();
            this.splitContainerFormMain = new System.Windows.Forms.SplitContainer();
            this.tabControlMonitors = new MyLib.Controls.TabControls.TabControlDynamic();
            this.tabPageMonitor2x2 = new MyLib.Controls.TabPages.MonitorTabPage();
            this.tabPageMonitor1x4 = new MyLib.Controls.TabPages.MonitorTabPage();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.splitContainerSettingsPage = new System.Windows.Forms.SplitContainer();
            this.listBoxSettingsPages = new MyLib.Controls.TabControls.TabControlTablessListBox();
            this.tabControlSettings = new MyLib.Controls.TabControls.TabControlTabLess();
            this.tabPageMainChannelsSettings = new System.Windows.Forms.TabPage();
            this.labelSettingsTable = new System.Windows.Forms.Label();
            this.textBoxSettingsDataTable = new System.Windows.Forms.TextBox();
            this.labelResolutionY = new System.Windows.Forms.Label();
            this.labelResolutionX = new System.Windows.Forms.Label();
            this.labelFps = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxResolutionY = new System.Windows.Forms.TextBox();
            this.textBoxFps = new System.Windows.Forms.TextBox();
            this.textBoxResolutionX = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelChannelBaseLink = new System.Windows.Forms.Label();
            this.textBoxChannelBaseLink = new System.Windows.Forms.TextBox();
            this.tabPageMainChannels = new System.Windows.Forms.TabPage();
            this.splitContainerMainChannels = new System.Windows.Forms.SplitContainer();
            this.dgvMainChannels = new System.Windows.Forms.DataGridView();
            this.buttonSelectMainSettingsFile = new System.Windows.Forms.Button();
            this.labelMainChannelSettingsFilePath = new System.Windows.Forms.Label();
            this.textBoxMainChannelSettingsFile = new System.Windows.Forms.TextBox();
            this.buttonLoadMainChannelsToSystem = new System.Windows.Forms.Button();
            this.buttonSaveMainChannelSettings = new System.Windows.Forms.Button();
            this.buttonGetMainChannelsSettings = new System.Windows.Forms.Button();
            this.tabPageOtherChannels = new System.Windows.Forms.TabPage();
            this.splitContainerOtherChannels = new System.Windows.Forms.SplitContainer();
            this.dgvOtherChannels = new System.Windows.Forms.DataGridView();
            this.buttonSelectOtherChannelSettingsFile = new System.Windows.Forms.Button();
            this.labelOtherChannelSettigsFilePath = new System.Windows.Forms.Label();
            this.textBoxOtherChannelSettingsFile = new System.Windows.Forms.TextBox();
            this.buttonGetOtherChannelsSettings = new System.Windows.Forms.Button();
            this.buttonLoadOtherChannelsToSystem = new System.Windows.Forms.Button();
            this.buttonSaveOtherChannelSettings = new System.Windows.Forms.Button();
            this.tabPageOtherSettings = new System.Windows.Forms.TabPage();
            this.buttonSelectPlayerSnapshotFolder = new System.Windows.Forms.Button();
            this.buttonSelectChannelSnapshotFolder = new System.Windows.Forms.Button();
            this.textBoxPlayerSnapshotFolder = new System.Windows.Forms.TextBox();
            this.textBoxChannelSnapshotFolder = new System.Windows.Forms.TextBox();
            this.linkPlayerSnapshotFolder = new System.Windows.Forms.LinkLabel();
            this.linkChannelSnapshotFolder = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanelStartChannels = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonStartAllChannels = new System.Windows.Forms.RadioButton();
            this.radioButtonStartLoadedChannels = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanelLoadChannels = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonLoadAllChannels = new System.Windows.Forms.RadioButton();
            this.radioButtonLoadLoadedChannels = new System.Windows.Forms.RadioButton();
            this.checkBoxStartChannels = new System.Windows.Forms.CheckBox();
            this.checkBoxLoadChannels = new System.Windows.Forms.CheckBox();
            this.tabPageMonitorLayouts = new System.Windows.Forms.TabPage();
            this.buttonSelectMonitorLayoutsFolder = new System.Windows.Forms.Button();
            this.textBoxMonitorLayoutsFolder = new System.Windows.Forms.TextBox();
            this.labelMonitorLayoutsFolder = new System.Windows.Forms.Label();
            this.channelsDashBoard = new MyLib.Controls.ChannelDashboard.ChannelDashboard();
            this.splitContainerChannelsHeader = new System.Windows.Forms.SplitContainer();
            this.labelChannels = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).BeginInit();
            this.splitContainerFormMain.Panel1.SuspendLayout();
            this.splitContainerFormMain.Panel2.SuspendLayout();
            this.splitContainerFormMain.SuspendLayout();
            this.tabControlMonitors.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsPage)).BeginInit();
            this.splitContainerSettingsPage.Panel1.SuspendLayout();
            this.splitContainerSettingsPage.Panel2.SuspendLayout();
            this.splitContainerSettingsPage.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageMainChannelsSettings.SuspendLayout();
            this.tabPageMainChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainChannels)).BeginInit();
            this.splitContainerMainChannels.Panel1.SuspendLayout();
            this.splitContainerMainChannels.Panel2.SuspendLayout();
            this.splitContainerMainChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainChannels)).BeginInit();
            this.tabPageOtherChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOtherChannels)).BeginInit();
            this.splitContainerOtherChannels.Panel1.SuspendLayout();
            this.splitContainerOtherChannels.Panel2.SuspendLayout();
            this.splitContainerOtherChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherChannels)).BeginInit();
            this.tabPageOtherSettings.SuspendLayout();
            this.flowLayoutPanelStartChannels.SuspendLayout();
            this.flowLayoutPanelLoadChannels.SuspendLayout();
            this.tabPageMonitorLayouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChannelsHeader)).BeginInit();
            this.splitContainerChannelsHeader.Panel1.SuspendLayout();
            this.splitContainerChannelsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonToggleChannel
            // 
            this.buttonToggleChannel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonToggleChannel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonToggleChannel.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonToggleChannel.Location = new System.Drawing.Point(1010, 0);
            this.buttonToggleChannel.Name = "buttonToggleChannel";
            this.buttonToggleChannel.Size = new System.Drawing.Size(20, 402);
            this.buttonToggleChannel.TabIndex = 2;
            this.buttonToggleChannel.UseVisualStyleBackColor = true;
            this.buttonToggleChannel.Click += new System.EventHandler(this.buttonToggleChannel_Click);
            // 
            // splitContainerFormMain
            // 
            this.splitContainerFormMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerFormMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerFormMain.IsSplitterFixed = true;
            this.splitContainerFormMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFormMain.Name = "splitContainerFormMain";
            // 
            // splitContainerFormMain.Panel1
            // 
            this.splitContainerFormMain.Panel1.Controls.Add(this.tabControlMonitors);
            // 
            // splitContainerFormMain.Panel2
            // 
            this.splitContainerFormMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerFormMain.Panel2.Controls.Add(this.channelsDashBoard);
            this.splitContainerFormMain.Panel2.Controls.Add(this.splitContainerChannelsHeader);
            this.splitContainerFormMain.Size = new System.Drawing.Size(1011, 402);
            this.splitContainerFormMain.SplitterDistance = 818;
            this.splitContainerFormMain.TabIndex = 1;
            // 
            // tabControlMonitors
            // 
            this.tabControlMonitors.AddIcon = global::WebCamMonitor.Properties.Resources.AddIcon;
            this.tabControlMonitors.Controls.Add(this.tabPageMonitor2x2);
            this.tabControlMonitors.Controls.Add(this.tabPageMonitor1x4);
            this.tabControlMonitors.Controls.Add(this.tabPageAdd);
            this.tabControlMonitors.Controls.Add(this.tabPageSettings);
            this.tabControlMonitors.DelIcon = global::WebCamMonitor.Properties.Resources.DelIcon;
            this.tabControlMonitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMonitors.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlMonitors.EditIcon = global::WebCamMonitor.Properties.Resources.EditIcon;
            this.tabControlMonitors.IconDistance = 5;
            this.tabControlMonitors.IconSize = new System.Drawing.Size(16, 16);
            this.tabControlMonitors.ItemSize = new System.Drawing.Size(10, 23);
            this.tabControlMonitors.Location = new System.Drawing.Point(0, 0);
            this.tabControlMonitors.Name = "tabControlMonitors";
            this.tabControlMonitors.NewTabPageDefaultTitle = "Новый монитор";
            this.tabControlMonitors.NewTabPageTitleWhiteSpace = "       ";
            this.tabControlMonitors.Padding = new System.Drawing.Point(12, 4);
            this.tabControlMonitors.SelectedIndex = 0;
            this.tabControlMonitors.Size = new System.Drawing.Size(818, 402);
            this.tabControlMonitors.TabIndex = 0;
            this.tabControlMonitors.TabPageAddName = "tabPageAdd";
            this.tabControlMonitors.TabPageSettingsName = "tabPageSettings";
            this.tabControlMonitors.SelectedIndexChanged += new System.EventHandler(this.tabControlMonitors_SelectedIndexChanged);
            // 
            // tabPageMonitor2x2
            // 
            this.tabPageMonitor2x2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageMonitor2x2.Location = new System.Drawing.Point(4, 27);
            this.tabPageMonitor2x2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageMonitor2x2.Name = "tabPageMonitor2x2";
            this.tabPageMonitor2x2.PageLayout = null;
            this.tabPageMonitor2x2.Size = new System.Drawing.Size(810, 371);
            this.tabPageMonitor2x2.TabIndex = 0;
            this.tabPageMonitor2x2.Text = "Монитор 2х2       ";
            // 
            // tabPageMonitor1x4
            // 
            this.tabPageMonitor1x4.Location = new System.Drawing.Point(4, 27);
            this.tabPageMonitor1x4.Name = "tabPageMonitor1x4";
            this.tabPageMonitor1x4.PageLayout = null;
            this.tabPageMonitor1x4.Size = new System.Drawing.Size(810, 371);
            this.tabPageMonitor1x4.TabIndex = 13;
            this.tabPageMonitor1x4.Text = "Монитор 1+4V       ";
            this.tabPageMonitor1x4.Visible = false;
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.Location = new System.Drawing.Point(4, 27);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Size = new System.Drawing.Size(810, 371);
            this.tabPageAdd.TabIndex = 12;
            this.tabPageAdd.Visible = false;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageSettings.Controls.Add(this.splitContainerSettingsPage);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 27);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(810, 371);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Настройки";
            // 
            // splitContainerSettingsPage
            // 
            this.splitContainerSettingsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSettingsPage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSettingsPage.Location = new System.Drawing.Point(3, 3);
            this.splitContainerSettingsPage.Name = "splitContainerSettingsPage";
            // 
            // splitContainerSettingsPage.Panel1
            // 
            this.splitContainerSettingsPage.Panel1.Controls.Add(this.listBoxSettingsPages);
            // 
            // splitContainerSettingsPage.Panel2
            // 
            this.splitContainerSettingsPage.Panel2.Controls.Add(this.tabControlSettings);
            this.splitContainerSettingsPage.Size = new System.Drawing.Size(804, 365);
            this.splitContainerSettingsPage.SplitterDistance = 200;
            this.splitContainerSettingsPage.TabIndex = 1;
            // 
            // listBoxSettingsPages
            // 
            this.listBoxSettingsPages.DisplayMember = "Description";
            this.listBoxSettingsPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSettingsPages.FormattingEnabled = true;
            this.listBoxSettingsPages.ItemHeight = 16;
            this.listBoxSettingsPages.Location = new System.Drawing.Point(0, 0);
            this.listBoxSettingsPages.Name = "listBoxSettingsPages";
            this.listBoxSettingsPages.SettingsPages = null;
            this.listBoxSettingsPages.Size = new System.Drawing.Size(200, 365);
            this.listBoxSettingsPages.TabControlTabLess = null;
            this.listBoxSettingsPages.TabIndex = 0;
            this.listBoxSettingsPages.ValueMember = "Name";
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageMainChannelsSettings);
            this.tabControlSettings.Controls.Add(this.tabPageMainChannels);
            this.tabControlSettings.Controls.Add(this.tabPageOtherChannels);
            this.tabControlSettings.Controls.Add(this.tabPageOtherSettings);
            this.tabControlSettings.Controls.Add(this.tabPageMonitorLayouts);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.Padding = new System.Drawing.Point(0, 0);
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(600, 365);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabPageMainChannelsSettings
            // 
            this.tabPageMainChannelsSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageMainChannelsSettings.Controls.Add(this.labelSettingsTable);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxSettingsDataTable);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelResolutionY);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelResolutionX);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelFps);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelResolution);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelLogin);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxResolutionY);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxFps);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxResolutionX);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxLogin);
            this.tabPageMainChannelsSettings.Controls.Add(this.labelChannelBaseLink);
            this.tabPageMainChannelsSettings.Controls.Add(this.textBoxChannelBaseLink);
            this.tabPageMainChannelsSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageMainChannelsSettings.Name = "tabPageMainChannelsSettings";
            this.tabPageMainChannelsSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainChannelsSettings.Size = new System.Drawing.Size(592, 336);
            this.tabPageMainChannelsSettings.TabIndex = 0;
            this.tabPageMainChannelsSettings.Text = "Настройки Main";
            // 
            // labelSettingsTable
            // 
            this.labelSettingsTable.AutoSize = true;
            this.labelSettingsTable.Location = new System.Drawing.Point(18, 20);
            this.labelSettingsTable.Name = "labelSettingsTable";
            this.labelSettingsTable.Size = new System.Drawing.Size(112, 16);
            this.labelSettingsTable.TabIndex = 28;
            this.labelSettingsTable.Text = "Таблица настроек";
            // 
            // textBoxSettingsDataTable
            // 
            this.textBoxSettingsDataTable.Location = new System.Drawing.Point(140, 20);
            this.textBoxSettingsDataTable.Name = "textBoxSettingsDataTable";
            this.textBoxSettingsDataTable.Size = new System.Drawing.Size(130, 22);
            this.textBoxSettingsDataTable.TabIndex = 27;
            this.textBoxSettingsDataTable.Text = "ChannelInfo";
            // 
            // labelResolutionY
            // 
            this.labelResolutionY.AutoSize = true;
            this.labelResolutionY.Location = new System.Drawing.Point(109, 170);
            this.labelResolutionY.Name = "labelResolutionY";
            this.labelResolutionY.Size = new System.Drawing.Size(17, 16);
            this.labelResolutionY.TabIndex = 22;
            this.labelResolutionY.Text = "Y";
            // 
            // labelResolutionX
            // 
            this.labelResolutionX.AutoSize = true;
            this.labelResolutionX.Location = new System.Drawing.Point(109, 141);
            this.labelResolutionX.Name = "labelResolutionX";
            this.labelResolutionX.Size = new System.Drawing.Size(15, 16);
            this.labelResolutionX.TabIndex = 23;
            this.labelResolutionX.Text = "X";
            // 
            // labelFps
            // 
            this.labelFps.AutoSize = true;
            this.labelFps.Location = new System.Drawing.Point(18, 210);
            this.labelFps.Name = "labelFps";
            this.labelFps.Size = new System.Drawing.Size(101, 16);
            this.labelFps.TabIndex = 24;
            this.labelFps.Text = "Частота кадров";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(18, 141);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(83, 16);
            this.labelResolution.TabIndex = 25;
            this.labelResolution.Text = "Разрешение";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(18, 101);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(43, 16);
            this.labelLogin.TabIndex = 26;
            this.labelLogin.Text = "Логин";
            // 
            // textBoxResolutionY
            // 
            this.textBoxResolutionY.Location = new System.Drawing.Point(140, 170);
            this.textBoxResolutionY.Name = "textBoxResolutionY";
            this.textBoxResolutionY.Size = new System.Drawing.Size(42, 22);
            this.textBoxResolutionY.TabIndex = 18;
            this.textBoxResolutionY.Text = "480";
            // 
            // textBoxFps
            // 
            this.textBoxFps.Location = new System.Drawing.Point(140, 210);
            this.textBoxFps.Name = "textBoxFps";
            this.textBoxFps.Size = new System.Drawing.Size(42, 22);
            this.textBoxFps.TabIndex = 19;
            this.textBoxFps.Text = "25";
            // 
            // textBoxResolutionX
            // 
            this.textBoxResolutionX.Location = new System.Drawing.Point(140, 141);
            this.textBoxResolutionX.Name = "textBoxResolutionX";
            this.textBoxResolutionX.Size = new System.Drawing.Size(42, 22);
            this.textBoxResolutionX.TabIndex = 20;
            this.textBoxResolutionX.Text = "640";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(140, 101);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(99, 22);
            this.textBoxLogin.TabIndex = 21;
            this.textBoxLogin.Text = "root";
            // 
            // labelChannelBaseLink
            // 
            this.labelChannelBaseLink.AutoSize = true;
            this.labelChannelBaseLink.Location = new System.Drawing.Point(18, 61);
            this.labelChannelBaseLink.Name = "labelChannelBaseLink";
            this.labelChannelBaseLink.Size = new System.Drawing.Size(105, 16);
            this.labelChannelBaseLink.TabIndex = 17;
            this.labelChannelBaseLink.Text = "Базовая ссылка";
            // 
            // textBoxChannelBaseLink
            // 
            this.textBoxChannelBaseLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChannelBaseLink.Location = new System.Drawing.Point(140, 61);
            this.textBoxChannelBaseLink.Name = "textBoxChannelBaseLink";
            this.textBoxChannelBaseLink.Size = new System.Drawing.Size(395, 22);
            this.textBoxChannelBaseLink.TabIndex = 16;
            this.textBoxChannelBaseLink.Text = "http://demo.macroscop.com:8080/mobile";
            // 
            // tabPageMainChannels
            // 
            this.tabPageMainChannels.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageMainChannels.Controls.Add(this.splitContainerMainChannels);
            this.tabPageMainChannels.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainChannels.Name = "tabPageMainChannels";
            this.tabPageMainChannels.Size = new System.Drawing.Size(592, 339);
            this.tabPageMainChannels.TabIndex = 1;
            this.tabPageMainChannels.Text = "Каналы Main";
            // 
            // splitContainerMainChannels
            // 
            this.splitContainerMainChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainChannels.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMainChannels.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainChannels.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMainChannels.Name = "splitContainerMainChannels";
            this.splitContainerMainChannels.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMainChannels.Panel1
            // 
            this.splitContainerMainChannels.Panel1.Controls.Add(this.dgvMainChannels);
            this.splitContainerMainChannels.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainerMainChannels.Panel2
            // 
            this.splitContainerMainChannels.Panel2.Controls.Add(this.buttonSelectMainSettingsFile);
            this.splitContainerMainChannels.Panel2.Controls.Add(this.labelMainChannelSettingsFilePath);
            this.splitContainerMainChannels.Panel2.Controls.Add(this.textBoxMainChannelSettingsFile);
            this.splitContainerMainChannels.Panel2.Controls.Add(this.buttonLoadMainChannelsToSystem);
            this.splitContainerMainChannels.Panel2.Controls.Add(this.buttonSaveMainChannelSettings);
            this.splitContainerMainChannels.Panel2.Controls.Add(this.buttonGetMainChannelsSettings);
            this.splitContainerMainChannels.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMainChannels.Size = new System.Drawing.Size(592, 339);
            this.splitContainerMainChannels.SplitterDistance = 241;
            this.splitContainerMainChannels.TabIndex = 18;
            // 
            // dgvMainChannels
            // 
            this.dgvMainChannels.AllowUserToAddRows = false;
            this.dgvMainChannels.AllowUserToDeleteRows = false;
            this.dgvMainChannels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvMainChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMainChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainChannels.Location = new System.Drawing.Point(0, 0);
            this.dgvMainChannels.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMainChannels.Name = "dgvMainChannels";
            this.dgvMainChannels.RowHeadersVisible = false;
            this.dgvMainChannels.RowHeadersWidth = 20;
            this.dgvMainChannels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMainChannels.Size = new System.Drawing.Size(592, 241);
            this.dgvMainChannels.TabIndex = 12;
            // 
            // buttonSelectMainSettingsFile
            // 
            this.buttonSelectMainSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectMainSettingsFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectMainSettingsFile.Location = new System.Drawing.Point(545, 20);
            this.buttonSelectMainSettingsFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectMainSettingsFile.Name = "buttonSelectMainSettingsFile";
            this.buttonSelectMainSettingsFile.Size = new System.Drawing.Size(30, 20);
            this.buttonSelectMainSettingsFile.TabIndex = 24;
            this.buttonSelectMainSettingsFile.Text = "...";
            this.buttonSelectMainSettingsFile.UseVisualStyleBackColor = true;
            this.buttonSelectMainSettingsFile.Click += new System.EventHandler(this.buttonSelectMainSettingsFile_Click);
            // 
            // labelMainChannelSettingsFilePath
            // 
            this.labelMainChannelSettingsFilePath.AutoSize = true;
            this.labelMainChannelSettingsFilePath.Location = new System.Drawing.Point(10, 20);
            this.labelMainChannelSettingsFilePath.Name = "labelMainChannelSettingsFilePath";
            this.labelMainChannelSettingsFilePath.Size = new System.Drawing.Size(144, 16);
            this.labelMainChannelSettingsFilePath.TabIndex = 23;
            this.labelMainChannelSettingsFilePath.Text = "Путь к файлу настроек";
            // 
            // textBoxMainChannelSettingsFile
            // 
            this.textBoxMainChannelSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMainChannelSettingsFile.Location = new System.Drawing.Point(163, 20);
            this.textBoxMainChannelSettingsFile.Name = "textBoxMainChannelSettingsFile";
            this.textBoxMainChannelSettingsFile.ReadOnly = true;
            this.textBoxMainChannelSettingsFile.Size = new System.Drawing.Size(367, 22);
            this.textBoxMainChannelSettingsFile.TabIndex = 22;
            // 
            // buttonLoadMainChannelsToSystem
            // 
            this.buttonLoadMainChannelsToSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadMainChannelsToSystem.Image = global::WebCamMonitor.Properties.Resources.downloadIcon;
            this.buttonLoadMainChannelsToSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadMainChannelsToSystem.Location = new System.Drawing.Point(360, 50);
            this.buttonLoadMainChannelsToSystem.Name = "buttonLoadMainChannelsToSystem";
            this.buttonLoadMainChannelsToSystem.Size = new System.Drawing.Size(220, 30);
            this.buttonLoadMainChannelsToSystem.TabIndex = 20;
            this.buttonLoadMainChannelsToSystem.Text = "Загрузить каналы в систему";
            this.buttonLoadMainChannelsToSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadMainChannelsToSystem.UseVisualStyleBackColor = true;
            this.buttonLoadMainChannelsToSystem.Click += new System.EventHandler(this.buttonLoadMainChannelsToSystem_Click);
            // 
            // buttonSaveMainChannelSettings
            // 
            this.buttonSaveMainChannelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveMainChannelSettings.Image = global::WebCamMonitor.Properties.Resources.saveIconBlue;
            this.buttonSaveMainChannelSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveMainChannelSettings.Location = new System.Drawing.Point(250, 50);
            this.buttonSaveMainChannelSettings.Name = "buttonSaveMainChannelSettings";
            this.buttonSaveMainChannelSettings.Size = new System.Drawing.Size(100, 29);
            this.buttonSaveMainChannelSettings.TabIndex = 17;
            this.buttonSaveMainChannelSettings.Text = "Сохранить";
            this.buttonSaveMainChannelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveMainChannelSettings.UseVisualStyleBackColor = true;
            this.buttonSaveMainChannelSettings.Click += new System.EventHandler(this.buttonSaveMainChannelSettings_Click);
            // 
            // buttonGetMainChannelsSettings
            // 
            this.buttonGetMainChannelsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetMainChannelsSettings.Image = global::WebCamMonitor.Properties.Resources.uploadIcon;
            this.buttonGetMainChannelsSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetMainChannelsSettings.Location = new System.Drawing.Point(10, 50);
            this.buttonGetMainChannelsSettings.Name = "buttonGetMainChannelsSettings";
            this.buttonGetMainChannelsSettings.Size = new System.Drawing.Size(230, 30);
            this.buttonGetMainChannelsSettings.TabIndex = 16;
            this.buttonGetMainChannelsSettings.Text = "Загрузить настройки в таблицу";
            this.buttonGetMainChannelsSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetMainChannelsSettings.UseVisualStyleBackColor = true;
            this.buttonGetMainChannelsSettings.Click += new System.EventHandler(this.buttonGetMainChannelsSettings_Click);
            // 
            // tabPageOtherChannels
            // 
            this.tabPageOtherChannels.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOtherChannels.Controls.Add(this.splitContainerOtherChannels);
            this.tabPageOtherChannels.Location = new System.Drawing.Point(4, 22);
            this.tabPageOtherChannels.Name = "tabPageOtherChannels";
            this.tabPageOtherChannels.Size = new System.Drawing.Size(592, 339);
            this.tabPageOtherChannels.TabIndex = 3;
            this.tabPageOtherChannels.Text = "Прочие каналы";
            // 
            // splitContainerOtherChannels
            // 
            this.splitContainerOtherChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOtherChannels.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerOtherChannels.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOtherChannels.Name = "splitContainerOtherChannels";
            this.splitContainerOtherChannels.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOtherChannels.Panel1
            // 
            this.splitContainerOtherChannels.Panel1.Controls.Add(this.dgvOtherChannels);
            this.splitContainerOtherChannels.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainerOtherChannels.Panel2
            // 
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.buttonSelectOtherChannelSettingsFile);
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.labelOtherChannelSettigsFilePath);
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.textBoxOtherChannelSettingsFile);
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.buttonGetOtherChannelsSettings);
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.buttonLoadOtherChannelsToSystem);
            this.splitContainerOtherChannels.Panel2.Controls.Add(this.buttonSaveOtherChannelSettings);
            this.splitContainerOtherChannels.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerOtherChannels.Size = new System.Drawing.Size(592, 339);
            this.splitContainerOtherChannels.SplitterDistance = 241;
            this.splitContainerOtherChannels.TabIndex = 19;
            // 
            // dgvOtherChannels
            // 
            this.dgvOtherChannels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvOtherChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOtherChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOtherChannels.Location = new System.Drawing.Point(0, 0);
            this.dgvOtherChannels.Name = "dgvOtherChannels";
            this.dgvOtherChannels.RowHeadersVisible = false;
            this.dgvOtherChannels.RowHeadersWidth = 20;
            this.dgvOtherChannels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOtherChannels.Size = new System.Drawing.Size(592, 241);
            this.dgvOtherChannels.TabIndex = 12;
            // 
            // buttonSelectOtherChannelSettingsFile
            // 
            this.buttonSelectOtherChannelSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectOtherChannelSettingsFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectOtherChannelSettingsFile.Location = new System.Drawing.Point(545, 20);
            this.buttonSelectOtherChannelSettingsFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectOtherChannelSettingsFile.Name = "buttonSelectOtherChannelSettingsFile";
            this.buttonSelectOtherChannelSettingsFile.Size = new System.Drawing.Size(30, 20);
            this.buttonSelectOtherChannelSettingsFile.TabIndex = 27;
            this.buttonSelectOtherChannelSettingsFile.Text = "...";
            this.buttonSelectOtherChannelSettingsFile.UseVisualStyleBackColor = true;
            this.buttonSelectOtherChannelSettingsFile.Click += new System.EventHandler(this.buttonSelectOtherChannelSettingsFile_Click);
            // 
            // labelOtherChannelSettigsFilePath
            // 
            this.labelOtherChannelSettigsFilePath.AutoSize = true;
            this.labelOtherChannelSettigsFilePath.Location = new System.Drawing.Point(10, 20);
            this.labelOtherChannelSettigsFilePath.Name = "labelOtherChannelSettigsFilePath";
            this.labelOtherChannelSettigsFilePath.Size = new System.Drawing.Size(144, 16);
            this.labelOtherChannelSettigsFilePath.TabIndex = 26;
            this.labelOtherChannelSettigsFilePath.Text = "Путь к файлу настроек";
            // 
            // textBoxOtherChannelSettingsFile
            // 
            this.textBoxOtherChannelSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOtherChannelSettingsFile.Location = new System.Drawing.Point(163, 20);
            this.textBoxOtherChannelSettingsFile.Name = "textBoxOtherChannelSettingsFile";
            this.textBoxOtherChannelSettingsFile.ReadOnly = true;
            this.textBoxOtherChannelSettingsFile.Size = new System.Drawing.Size(367, 22);
            this.textBoxOtherChannelSettingsFile.TabIndex = 25;
            this.textBoxOtherChannelSettingsFile.TextChanged += new System.EventHandler(this.textBoxOtherChannelSettigsFilePath_TextChanged);
            // 
            // buttonGetOtherChannelsSettings
            // 
            this.buttonGetOtherChannelsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGetOtherChannelsSettings.Image = global::WebCamMonitor.Properties.Resources.uploadIcon;
            this.buttonGetOtherChannelsSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetOtherChannelsSettings.Location = new System.Drawing.Point(10, 50);
            this.buttonGetOtherChannelsSettings.Name = "buttonGetOtherChannelsSettings";
            this.buttonGetOtherChannelsSettings.Size = new System.Drawing.Size(230, 30);
            this.buttonGetOtherChannelsSettings.TabIndex = 23;
            this.buttonGetOtherChannelsSettings.Text = "Загрузить настройки в таблицу";
            this.buttonGetOtherChannelsSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetOtherChannelsSettings.UseVisualStyleBackColor = true;
            this.buttonGetOtherChannelsSettings.Click += new System.EventHandler(this.buttonGetOtherChannelsSettings_Click);
            // 
            // buttonLoadOtherChannelsToSystem
            // 
            this.buttonLoadOtherChannelsToSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadOtherChannelsToSystem.Image = global::WebCamMonitor.Properties.Resources.downloadIcon;
            this.buttonLoadOtherChannelsToSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadOtherChannelsToSystem.Location = new System.Drawing.Point(360, 50);
            this.buttonLoadOtherChannelsToSystem.Name = "buttonLoadOtherChannelsToSystem";
            this.buttonLoadOtherChannelsToSystem.Size = new System.Drawing.Size(220, 30);
            this.buttonLoadOtherChannelsToSystem.TabIndex = 20;
            this.buttonLoadOtherChannelsToSystem.Text = "Загрузить каналы в систему";
            this.buttonLoadOtherChannelsToSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadOtherChannelsToSystem.UseVisualStyleBackColor = true;
            this.buttonLoadOtherChannelsToSystem.Click += new System.EventHandler(this.buttonLoadOtherChannelsToSystem_Click);
            // 
            // buttonSaveOtherChannelSettings
            // 
            this.buttonSaveOtherChannelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveOtherChannelSettings.Image = global::WebCamMonitor.Properties.Resources.saveIconBlue;
            this.buttonSaveOtherChannelSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveOtherChannelSettings.Location = new System.Drawing.Point(250, 50);
            this.buttonSaveOtherChannelSettings.Name = "buttonSaveOtherChannelSettings";
            this.buttonSaveOtherChannelSettings.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveOtherChannelSettings.TabIndex = 17;
            this.buttonSaveOtherChannelSettings.Text = "Сохранить";
            this.buttonSaveOtherChannelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveOtherChannelSettings.UseVisualStyleBackColor = true;
            this.buttonSaveOtherChannelSettings.Click += new System.EventHandler(this.buttonSaveOtherChannelSettings_Click);
            // 
            // tabPageOtherSettings
            // 
            this.tabPageOtherSettings.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOtherSettings.Controls.Add(this.buttonSelectPlayerSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.buttonSelectChannelSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.textBoxPlayerSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.textBoxChannelSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.linkPlayerSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.linkChannelSnapshotFolder);
            this.tabPageOtherSettings.Controls.Add(this.flowLayoutPanelStartChannels);
            this.tabPageOtherSettings.Controls.Add(this.flowLayoutPanelLoadChannels);
            this.tabPageOtherSettings.Controls.Add(this.checkBoxStartChannels);
            this.tabPageOtherSettings.Controls.Add(this.checkBoxLoadChannels);
            this.tabPageOtherSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageOtherSettings.Name = "tabPageOtherSettings";
            this.tabPageOtherSettings.Size = new System.Drawing.Size(592, 336);
            this.tabPageOtherSettings.TabIndex = 4;
            this.tabPageOtherSettings.Text = "Прочие настройки";
            // 
            // buttonSelectPlayerSnapshotFolder
            // 
            this.buttonSelectPlayerSnapshotFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectPlayerSnapshotFolder.Location = new System.Drawing.Point(540, 140);
            this.buttonSelectPlayerSnapshotFolder.Name = "buttonSelectPlayerSnapshotFolder";
            this.buttonSelectPlayerSnapshotFolder.Size = new System.Drawing.Size(30, 22);
            this.buttonSelectPlayerSnapshotFolder.TabIndex = 39;
            this.buttonSelectPlayerSnapshotFolder.Text = "...";
            this.buttonSelectPlayerSnapshotFolder.UseVisualStyleBackColor = true;
            this.buttonSelectPlayerSnapshotFolder.Click += new System.EventHandler(this.buttonSelectPlayerSnapshotFolder_Click);
            // 
            // buttonSelectChannelSnapshotFolder
            // 
            this.buttonSelectChannelSnapshotFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectChannelSnapshotFolder.Location = new System.Drawing.Point(540, 80);
            this.buttonSelectChannelSnapshotFolder.Name = "buttonSelectChannelSnapshotFolder";
            this.buttonSelectChannelSnapshotFolder.Size = new System.Drawing.Size(30, 22);
            this.buttonSelectChannelSnapshotFolder.TabIndex = 39;
            this.buttonSelectChannelSnapshotFolder.Text = "...";
            this.buttonSelectChannelSnapshotFolder.UseVisualStyleBackColor = true;
            this.buttonSelectChannelSnapshotFolder.Click += new System.EventHandler(this.buttonSelectChannelSnapshotFolder_Click);
            // 
            // textBoxPlayerSnapshotFolder
            // 
            this.textBoxPlayerSnapshotFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayerSnapshotFolder.Location = new System.Drawing.Point(20, 140);
            this.textBoxPlayerSnapshotFolder.Name = "textBoxPlayerSnapshotFolder";
            this.textBoxPlayerSnapshotFolder.ReadOnly = true;
            this.textBoxPlayerSnapshotFolder.Size = new System.Drawing.Size(510, 22);
            this.textBoxPlayerSnapshotFolder.TabIndex = 38;
            // 
            // textBoxChannelSnapshotFolder
            // 
            this.textBoxChannelSnapshotFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChannelSnapshotFolder.Location = new System.Drawing.Point(20, 80);
            this.textBoxChannelSnapshotFolder.Name = "textBoxChannelSnapshotFolder";
            this.textBoxChannelSnapshotFolder.ReadOnly = true;
            this.textBoxChannelSnapshotFolder.Size = new System.Drawing.Size(510, 22);
            this.textBoxChannelSnapshotFolder.TabIndex = 38;
            // 
            // linkPlayerSnapshotFolder
            // 
            this.linkPlayerSnapshotFolder.AutoSize = true;
            this.linkPlayerSnapshotFolder.Location = new System.Drawing.Point(20, 120);
            this.linkPlayerSnapshotFolder.Name = "linkPlayerSnapshotFolder";
            this.linkPlayerSnapshotFolder.Size = new System.Drawing.Size(222, 16);
            this.linkPlayerSnapshotFolder.TabIndex = 37;
            this.linkPlayerSnapshotFolder.TabStop = true;
            this.linkPlayerSnapshotFolder.Text = "Папка хранения снимков с плееров";
            this.linkPlayerSnapshotFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPlayerSnapshotFolder_LinkClicked);
            // 
            // linkChannelSnapshotFolder
            // 
            this.linkChannelSnapshotFolder.AutoSize = true;
            this.linkChannelSnapshotFolder.Location = new System.Drawing.Point(20, 60);
            this.linkChannelSnapshotFolder.Name = "linkChannelSnapshotFolder";
            this.linkChannelSnapshotFolder.Size = new System.Drawing.Size(210, 16);
            this.linkChannelSnapshotFolder.TabIndex = 37;
            this.linkChannelSnapshotFolder.TabStop = true;
            this.linkChannelSnapshotFolder.Text = "Папка хранения снимков каналов";
            this.linkChannelSnapshotFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChannelSnapshotFolder_LinkClicked);
            // 
            // flowLayoutPanelStartChannels
            // 
            this.flowLayoutPanelStartChannels.Controls.Add(this.radioButtonStartAllChannels);
            this.flowLayoutPanelStartChannels.Controls.Add(this.radioButtonStartLoadedChannels);
            this.flowLayoutPanelStartChannels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStartChannels.Location = new System.Drawing.Point(40, 280);
            this.flowLayoutPanelStartChannels.Name = "flowLayoutPanelStartChannels";
            this.flowLayoutPanelStartChannels.Size = new System.Drawing.Size(430, 60);
            this.flowLayoutPanelStartChannels.TabIndex = 34;
            this.flowLayoutPanelStartChannels.Visible = false;
            // 
            // radioButtonStartAllChannels
            // 
            this.radioButtonStartAllChannels.AutoSize = true;
            this.radioButtonStartAllChannels.Location = new System.Drawing.Point(3, 3);
            this.radioButtonStartAllChannels.Name = "radioButtonStartAllChannels";
            this.radioButtonStartAllChannels.Size = new System.Drawing.Size(282, 20);
            this.radioButtonStartAllChannels.TabIndex = 0;
            this.radioButtonStartAllChannels.TabStop = true;
            this.radioButtonStartAllChannels.Text = "все каналы в системе на момент закрытия";
            this.radioButtonStartAllChannels.UseVisualStyleBackColor = true;
            // 
            // radioButtonStartLoadedChannels
            // 
            this.radioButtonStartLoadedChannels.AutoSize = true;
            this.radioButtonStartLoadedChannels.Location = new System.Drawing.Point(3, 29);
            this.radioButtonStartLoadedChannels.Name = "radioButtonStartLoadedChannels";
            this.radioButtonStartLoadedChannels.Size = new System.Drawing.Size(387, 20);
            this.radioButtonStartLoadedChannels.TabIndex = 1;
            this.radioButtonStartLoadedChannels.TabStop = true;
            this.radioButtonStartLoadedChannels.Text = "активные каналы в системе на момент закрытия программы";
            this.radioButtonStartLoadedChannels.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelLoadChannels
            // 
            this.flowLayoutPanelLoadChannels.Controls.Add(this.radioButtonLoadAllChannels);
            this.flowLayoutPanelLoadChannels.Controls.Add(this.radioButtonLoadLoadedChannels);
            this.flowLayoutPanelLoadChannels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLoadChannels.Location = new System.Drawing.Point(40, 190);
            this.flowLayoutPanelLoadChannels.Name = "flowLayoutPanelLoadChannels";
            this.flowLayoutPanelLoadChannels.Size = new System.Drawing.Size(430, 60);
            this.flowLayoutPanelLoadChannels.TabIndex = 35;
            this.flowLayoutPanelLoadChannels.Visible = false;
            // 
            // radioButtonLoadAllChannels
            // 
            this.radioButtonLoadAllChannels.AutoSize = true;
            this.radioButtonLoadAllChannels.Location = new System.Drawing.Point(3, 3);
            this.radioButtonLoadAllChannels.Name = "radioButtonLoadAllChannels";
            this.radioButtonLoadAllChannels.Size = new System.Drawing.Size(209, 20);
            this.radioButtonLoadAllChannels.TabIndex = 0;
            this.radioButtonLoadAllChannels.Text = "все каналы из файла настроек";
            this.radioButtonLoadAllChannels.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoadLoadedChannels
            // 
            this.radioButtonLoadLoadedChannels.AutoSize = true;
            this.radioButtonLoadLoadedChannels.Location = new System.Drawing.Point(3, 29);
            this.radioButtonLoadLoadedChannels.Name = "radioButtonLoadLoadedChannels";
            this.radioButtonLoadLoadedChannels.Size = new System.Drawing.Size(328, 20);
            this.radioButtonLoadLoadedChannels.TabIndex = 1;
            this.radioButtonLoadLoadedChannels.Text = "каналы в системе на момент закрытия программы";
            this.radioButtonLoadLoadedChannels.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartChannels
            // 
            this.checkBoxStartChannels.AutoSize = true;
            this.checkBoxStartChannels.Location = new System.Drawing.Point(20, 260);
            this.checkBoxStartChannels.Name = "checkBoxStartChannels";
            this.checkBoxStartChannels.Size = new System.Drawing.Size(355, 20);
            this.checkBoxStartChannels.TabIndex = 33;
            this.checkBoxStartChannels.Text = "Активировать главные каналы при запуске программы";
            this.checkBoxStartChannels.UseVisualStyleBackColor = true;
            this.checkBoxStartChannels.Visible = false;
            // 
            // checkBoxLoadChannels
            // 
            this.checkBoxLoadChannels.AutoSize = true;
            this.checkBoxLoadChannels.Checked = global::WebCamMonitor.Properties.Settings.Default.checkBoxLoadChannelsChecked;
            this.checkBoxLoadChannels.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WebCamMonitor.Properties.Settings.Default, "checkBoxLoadChannelsChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxLoadChannels.Location = new System.Drawing.Point(20, 20);
            this.checkBoxLoadChannels.Name = "checkBoxLoadChannels";
            this.checkBoxLoadChannels.Size = new System.Drawing.Size(347, 20);
            this.checkBoxLoadChannels.TabIndex = 32;
            this.checkBoxLoadChannels.Text = "Загружать каналы в систему при запуске программы";
            this.checkBoxLoadChannels.UseVisualStyleBackColor = true;
            this.checkBoxLoadChannels.CheckedChanged += new System.EventHandler(this.checkBoxLoadChannels_CheckedChanged);
            // 
            // tabPageMonitorLayouts
            // 
            this.tabPageMonitorLayouts.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageMonitorLayouts.Controls.Add(this.buttonSelectMonitorLayoutsFolder);
            this.tabPageMonitorLayouts.Controls.Add(this.textBoxMonitorLayoutsFolder);
            this.tabPageMonitorLayouts.Controls.Add(this.labelMonitorLayoutsFolder);
            this.tabPageMonitorLayouts.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonitorLayouts.Name = "tabPageMonitorLayouts";
            this.tabPageMonitorLayouts.Size = new System.Drawing.Size(592, 339);
            this.tabPageMonitorLayouts.TabIndex = 2;
            this.tabPageMonitorLayouts.Text = "Шаблоны мониторов";
            // 
            // buttonSelectMonitorLayoutsFolder
            // 
            this.buttonSelectMonitorLayoutsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectMonitorLayoutsFolder.Location = new System.Drawing.Point(538, 20);
            this.buttonSelectMonitorLayoutsFolder.Name = "buttonSelectMonitorLayoutsFolder";
            this.buttonSelectMonitorLayoutsFolder.Size = new System.Drawing.Size(30, 20);
            this.buttonSelectMonitorLayoutsFolder.TabIndex = 41;
            this.buttonSelectMonitorLayoutsFolder.Text = "...";
            this.buttonSelectMonitorLayoutsFolder.UseVisualStyleBackColor = true;
            this.buttonSelectMonitorLayoutsFolder.Visible = false;
            // 
            // textBoxMonitorLayoutsFolder
            // 
            this.textBoxMonitorLayoutsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMonitorLayoutsFolder.Location = new System.Drawing.Point(190, 20);
            this.textBoxMonitorLayoutsFolder.Name = "textBoxMonitorLayoutsFolder";
            this.textBoxMonitorLayoutsFolder.Size = new System.Drawing.Size(338, 22);
            this.textBoxMonitorLayoutsFolder.TabIndex = 40;
            this.textBoxMonitorLayoutsFolder.Visible = false;
            // 
            // labelMonitorLayoutsFolder
            // 
            this.labelMonitorLayoutsFolder.AutoSize = true;
            this.labelMonitorLayoutsFolder.Location = new System.Drawing.Point(10, 20);
            this.labelMonitorLayoutsFolder.Name = "labelMonitorLayoutsFolder";
            this.labelMonitorLayoutsFolder.Size = new System.Drawing.Size(174, 16);
            this.labelMonitorLayoutsFolder.TabIndex = 39;
            this.labelMonitorLayoutsFolder.Text = "Папка шаблонов мониторов";
            this.labelMonitorLayoutsFolder.Visible = false;
            // 
            // channelsDashBoard
            // 
            this.channelsDashBoard.AllowMultiplePanelsOpen = true;
            this.channelsDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelsDashBoard.Location = new System.Drawing.Point(0, 24);
            this.channelsDashBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.channelsDashBoard.Name = "channelsDashBoard";
            this.channelsDashBoard.Size = new System.Drawing.Size(189, 378);
            this.channelsDashBoard.TabIndex = 6;
            // 
            // splitContainerChannelsHeader
            // 
            this.splitContainerChannelsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerChannelsHeader.Location = new System.Drawing.Point(0, 0);
            this.splitContainerChannelsHeader.Name = "splitContainerChannelsHeader";
            // 
            // splitContainerChannelsHeader.Panel1
            // 
            this.splitContainerChannelsHeader.Panel1.Controls.Add(this.labelChannels);
            this.splitContainerChannelsHeader.Panel1.Controls.Add(this.buttonTest);
            this.splitContainerChannelsHeader.Panel2Collapsed = true;
            this.splitContainerChannelsHeader.Size = new System.Drawing.Size(189, 24);
            this.splitContainerChannelsHeader.SplitterDistance = 115;
            this.splitContainerChannelsHeader.TabIndex = 0;
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChannels.Location = new System.Drawing.Point(50, 5);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(59, 16);
            this.labelChannels.TabIndex = 7;
            this.labelChannels.Text = "Каналы";
            // 
            // buttonTest
            // 
            this.buttonTest.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonTest.FlatAppearance.BorderSize = 0;
            this.buttonTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTest.Location = new System.Drawing.Point(140, 0);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(49, 24);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            this.buttonTest.MouseEnter += new System.EventHandler(this.buttonTest_MouseEnter);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1030, 402);
            this.Controls.Add(this.buttonToggleChannel);
            this.Controls.Add(this.splitContainerFormMain);
            this.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebCamMonitor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainerFormMain.Panel1.ResumeLayout(false);
            this.splitContainerFormMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFormMain)).EndInit();
            this.splitContainerFormMain.ResumeLayout(false);
            this.tabControlMonitors.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.splitContainerSettingsPage.Panel1.ResumeLayout(false);
            this.splitContainerSettingsPage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsPage)).EndInit();
            this.splitContainerSettingsPage.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageMainChannelsSettings.ResumeLayout(false);
            this.tabPageMainChannelsSettings.PerformLayout();
            this.tabPageMainChannels.ResumeLayout(false);
            this.splitContainerMainChannels.Panel1.ResumeLayout(false);
            this.splitContainerMainChannels.Panel2.ResumeLayout(false);
            this.splitContainerMainChannels.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainChannels)).EndInit();
            this.splitContainerMainChannels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainChannels)).EndInit();
            this.tabPageOtherChannels.ResumeLayout(false);
            this.splitContainerOtherChannels.Panel1.ResumeLayout(false);
            this.splitContainerOtherChannels.Panel2.ResumeLayout(false);
            this.splitContainerOtherChannels.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOtherChannels)).EndInit();
            this.splitContainerOtherChannels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherChannels)).EndInit();
            this.tabPageOtherSettings.ResumeLayout(false);
            this.tabPageOtherSettings.PerformLayout();
            this.flowLayoutPanelStartChannels.ResumeLayout(false);
            this.flowLayoutPanelStartChannels.PerformLayout();
            this.flowLayoutPanelLoadChannels.ResumeLayout(false);
            this.flowLayoutPanelLoadChannels.PerformLayout();
            this.tabPageMonitorLayouts.ResumeLayout(false);
            this.tabPageMonitorLayouts.PerformLayout();
            this.splitContainerChannelsHeader.Panel1.ResumeLayout(false);
            this.splitContainerChannelsHeader.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChannelsHeader)).EndInit();
            this.splitContainerChannelsHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonToggleChannel;
        private System.Windows.Forms.SplitContainer splitContainerFormMain;
        private TabControlDynamic tabControlMonitors;
        private System.Windows.Forms.TabPage tabPageAdd;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.SplitContainer splitContainerSettingsPage;
        private TabControlTablessListBox listBoxSettingsPages;
        private TabControlTabLess tabControlSettings;
        private System.Windows.Forms.TabPage tabPageMainChannelsSettings;
        private System.Windows.Forms.Label labelSettingsTable;
        private System.Windows.Forms.TextBox textBoxSettingsDataTable;
        private System.Windows.Forms.Label labelResolutionY;
        private System.Windows.Forms.Label labelResolutionX;
        private System.Windows.Forms.Label labelFps;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxResolutionY;
        private System.Windows.Forms.TextBox textBoxFps;
        private System.Windows.Forms.TextBox textBoxResolutionX;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelChannelBaseLink;
        private System.Windows.Forms.TextBox textBoxChannelBaseLink;
        private System.Windows.Forms.TabPage tabPageMainChannels;
        private System.Windows.Forms.SplitContainer splitContainerMainChannels;
        private System.Windows.Forms.DataGridView dgvMainChannels;
        private System.Windows.Forms.Button buttonLoadMainChannelsToSystem;
        private System.Windows.Forms.Button buttonSaveMainChannelSettings;
        private System.Windows.Forms.Button buttonGetMainChannelsSettings;
        private System.Windows.Forms.TabPage tabPageOtherChannels;
        private System.Windows.Forms.TabPage tabPageMonitorLayouts;
        private System.Windows.Forms.TabPage tabPageOtherSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStartChannels;
        private System.Windows.Forms.RadioButton radioButtonStartAllChannels;
        private System.Windows.Forms.RadioButton radioButtonStartLoadedChannels;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLoadChannels;
        private System.Windows.Forms.RadioButton radioButtonLoadAllChannels;
        private System.Windows.Forms.RadioButton radioButtonLoadLoadedChannels;
        private System.Windows.Forms.CheckBox checkBoxStartChannels;
        private System.Windows.Forms.CheckBox checkBoxLoadChannels;
        private MyLib.Controls.TabPages.MonitorTabPage tabPageMonitor2x2;
        private MyLib.Controls.TabPages.MonitorTabPage tabPageMonitor1x4;
        private System.Windows.Forms.SplitContainer splitContainerOtherChannels;
        private System.Windows.Forms.DataGridView dgvOtherChannels;
        private System.Windows.Forms.Button buttonLoadOtherChannelsToSystem;
        private System.Windows.Forms.Button buttonSaveOtherChannelSettings;
        private System.Windows.Forms.Button buttonGetOtherChannelsSettings;
        private System.Windows.Forms.Button buttonSelectMainSettingsFile;
        private System.Windows.Forms.Label labelMainChannelSettingsFilePath;
        private System.Windows.Forms.TextBox textBoxMainChannelSettingsFile;
        private System.Windows.Forms.Button buttonSelectOtherChannelSettingsFile;
        private System.Windows.Forms.Label labelOtherChannelSettigsFilePath;
        private System.Windows.Forms.TextBox textBoxOtherChannelSettingsFile;
        private System.Windows.Forms.Button buttonSelectMonitorLayoutsFolder;
        private System.Windows.Forms.TextBox textBoxMonitorLayoutsFolder;
        private System.Windows.Forms.Label labelMonitorLayoutsFolder;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.SplitContainer splitContainerChannelsHeader;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.LinkLabel linkChannelSnapshotFolder;
        private System.Windows.Forms.Button buttonSelectChannelSnapshotFolder;
        private System.Windows.Forms.TextBox textBoxChannelSnapshotFolder;
        private System.Windows.Forms.Button buttonSelectPlayerSnapshotFolder;
        private System.Windows.Forms.TextBox textBoxPlayerSnapshotFolder;
        private System.Windows.Forms.LinkLabel linkPlayerSnapshotFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private ChannelDashboard channelsDashBoard;
    }
}

