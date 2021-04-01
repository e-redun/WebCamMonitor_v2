namespace WebCamMonitor
{
    partial class FormEditMonitorPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTabPageTitle = new System.Windows.Forms.TextBox();
            this.labelMonitorName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxLayoutsFiles = new System.Windows.Forms.ListBox();
            this.labelFilesNames = new System.Windows.Forms.Label();
            this.panelLayout = new System.Windows.Forms.Panel();
            this.labelLayout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTabPageTitle
            // 
            this.textBoxTabPageTitle.Location = new System.Drawing.Point(117, 25);
            this.textBoxTabPageTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTabPageTitle.Name = "textBoxTabPageTitle";
            this.textBoxTabPageTitle.Size = new System.Drawing.Size(419, 22);
            this.textBoxTabPageTitle.TabIndex = 0;
            // 
            // labelMonitorName
            // 
            this.labelMonitorName.AutoSize = true;
            this.labelMonitorName.Location = new System.Drawing.Point(23, 25);
            this.labelMonitorName.Name = "labelMonitorName";
            this.labelMonitorName.Size = new System.Drawing.Size(65, 16);
            this.labelMonitorName.TabIndex = 1;
            this.labelMonitorName.Text = "Название";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(348, 432);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(117, 37);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(488, 432);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(117, 37);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(23, 80);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxLayoutsFiles);
            this.splitContainer1.Panel1.Controls.Add(this.labelFilesNames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelLayout);
            this.splitContainer1.Panel2.Controls.Add(this.labelLayout);
            this.splitContainer1.Size = new System.Drawing.Size(583, 283);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 12;
            this.splitContainer1.TabIndex = 43;
            // 
            // listBoxLayoutsFiles
            // 
            this.listBoxLayoutsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLayoutsFiles.FormattingEnabled = true;
            this.listBoxLayoutsFiles.ItemHeight = 16;
            this.listBoxLayoutsFiles.Location = new System.Drawing.Point(0, 28);
            this.listBoxLayoutsFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxLayoutsFiles.Name = "listBoxLayoutsFiles";
            this.listBoxLayoutsFiles.Size = new System.Drawing.Size(250, 255);
            this.listBoxLayoutsFiles.TabIndex = 9;
            this.listBoxLayoutsFiles.DoubleClick += new System.EventHandler(this.listBoxLayoutsFiles_DoubleClick);
            // 
            // labelFilesNames
            // 
            this.labelFilesNames.AutoSize = true;
            this.labelFilesNames.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFilesNames.Location = new System.Drawing.Point(0, 0);
            this.labelFilesNames.Name = "labelFilesNames";
            this.labelFilesNames.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.labelFilesNames.Size = new System.Drawing.Size(126, 28);
            this.labelFilesNames.TabIndex = 3;
            this.labelFilesNames.Text = "Шаблоны в системе";
            // 
            // panelLayout
            // 
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 28);
            this.panelLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.Size = new System.Drawing.Size(321, 255);
            this.panelLayout.TabIndex = 8;
            // 
            // labelLayout
            // 
            this.labelLayout.AutoSize = true;
            this.labelLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLayout.Location = new System.Drawing.Point(0, 0);
            this.labelLayout.Name = "labelLayout";
            this.labelLayout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.labelLayout.Size = new System.Drawing.Size(53, 28);
            this.labelLayout.TabIndex = 3;
            this.labelLayout.Text = "Шаблон";
            // 
            // FormEditMonitorPage
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(630, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelMonitorName);
            this.Controls.Add(this.textBoxTabPageTitle);
            this.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormEditMonitorPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditMonitorPage";
            this.Load += new System.EventHandler(this.FormEditMonitorPage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTabPageTitle;
        private System.Windows.Forms.Label labelMonitorName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxLayoutsFiles;
        private System.Windows.Forms.Label labelFilesNames;
        private System.Windows.Forms.Panel panelLayout;
        private System.Windows.Forms.Label labelLayout;
    }
}