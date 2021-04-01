namespace MyLib.Controls.ChannelDashboard
{
    partial class ChannelDashboard
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
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelContextMenu = new System.Windows.Forms.Panel();
            this.buttonContextMenu = new System.Windows.Forms.Button();
            this.panelTogglers = new System.Windows.Forms.Panel();
            this.buttonTest = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.panelContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.buttonReload, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonDelete, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonStop, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonStart, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonLoad, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(330, 30);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // buttonReload
            // 
            this.buttonReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReload.Image = global::MyLib.Properties.Resources.reloadIconBlue;
            this.buttonReload.Location = new System.Drawing.Point(0, 0);
            this.buttonReload.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(66, 30);
            this.buttonReload.TabIndex = 5;
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            this.buttonReload.MouseEnter += new System.EventHandler(this.buttonReload_MouseEnter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.Image = global::MyLib.Properties.Resources.delIcon2;
            this.buttonDelete.Location = new System.Drawing.Point(264, 0);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(66, 30);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.MouseEnter += new System.EventHandler(this.buttonDelete_MouseEnter);
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.Image = global::MyLib.Properties.Resources.stopIconGreen;
            this.buttonStop.Location = new System.Drawing.Point(198, 0);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(66, 30);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            this.buttonStop.MouseEnter += new System.EventHandler(this.buttonStop_MouseEnter);
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStart.Enabled = false;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Image = global::MyLib.Properties.Resources.playIconRed;
            this.buttonStart.Location = new System.Drawing.Point(132, 0);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(66, 30);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseEnter += new System.EventHandler(this.buttonStart_MouseEnter);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoad.Image = global::MyLib.Properties.Resources.downloadIcon;
            this.buttonLoad.Location = new System.Drawing.Point(66, 0);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(66, 30);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            this.buttonLoad.MouseEnter += new System.EventHandler(this.buttonLoad_MouseEnter);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.AutoClose = false;
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // panelContextMenu
            // 
            this.panelContextMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelContextMenu.Controls.Add(this.buttonTest);
            this.panelContextMenu.Controls.Add(this.buttonContextMenu);
            this.panelContextMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContextMenu.Enabled = false;
            this.panelContextMenu.Location = new System.Drawing.Point(0, 30);
            this.panelContextMenu.Name = "panelContextMenu";
            this.panelContextMenu.Size = new System.Drawing.Size(330, 20);
            this.panelContextMenu.TabIndex = 2;
            // 
            // buttonContextMenu
            // 
            this.buttonContextMenu.ContextMenuStrip = this.contextMenuStrip;
            this.buttonContextMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonContextMenu.FlatAppearance.BorderSize = 0;
            this.buttonContextMenu.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonContextMenu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonContextMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContextMenu.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonContextMenu.Image = global::MyLib.Properties.Resources.enterListIcon;
            this.buttonContextMenu.Location = new System.Drawing.Point(300, 0);
            this.buttonContextMenu.Name = "buttonContextMenu";
            this.buttonContextMenu.Size = new System.Drawing.Size(30, 20);
            this.buttonContextMenu.TabIndex = 1;
            this.buttonContextMenu.Text = "";
            this.buttonContextMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonContextMenu.UseVisualStyleBackColor = true;
            this.buttonContextMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonContextMenu_MouseDown);
            this.buttonContextMenu.MouseEnter += new System.EventHandler(this.buttonContextMenu_MouseEnter);
            this.buttonContextMenu.MouseLeave += new System.EventHandler(this.buttonContextMenu_MouseLeave);
            // 
            // panelTogglers
            // 
            this.panelTogglers.AutoScroll = true;
            this.panelTogglers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTogglers.Location = new System.Drawing.Point(0, 50);
            this.panelTogglers.Name = "panelTogglers";
            this.panelTogglers.Size = new System.Drawing.Size(330, 3);
            this.panelTogglers.TabIndex = 3;
            // 
            // buttonTest
            // 
            this.buttonTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTest.Location = new System.Drawing.Point(0, 0);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(65, 20);
            this.buttonTest.TabIndex = 8;
            this.buttonTest.Text = "test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Visible = false;
            // 
            // ChannelDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelTogglers);
            this.Controls.Add(this.panelContextMenu);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ChannelDashboard";
            this.Size = new System.Drawing.Size(330, 53);
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Panel panelContextMenu;
        private System.Windows.Forms.Button buttonContextMenu;
        public System.Windows.Forms.Panel panelTogglers;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonTest;
    }
}
