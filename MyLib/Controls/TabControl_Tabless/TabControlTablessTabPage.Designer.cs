namespace MyLib.Controls.TabControl_Tabless
{
    partial class TabControlTablessTabPage
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridViewChannels = new System.Windows.Forms.DataGridView();
            this.buttonSelectSettingsFile = new System.Windows.Forms.Button();
            this.labelChannelSettingsFilePath = new System.Windows.Forms.Label();
            this.textBoxChannelSettingsFile = new System.Windows.Forms.TextBox();
            this.buttonLoadChannelsToSystem = new System.Windows.Forms.Button();
            this.buttonSaveChannelSettings = new System.Windows.Forms.Button();
            this.buttonGetChannelsSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChannels)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.buttonSelectSettingsFile);
            this.splitContainer.Panel1.Controls.Add(this.labelChannelSettingsFilePath);
            this.splitContainer.Panel1.Controls.Add(this.buttonGetChannelsSettings);
            this.splitContainer.Panel1.Controls.Add(this.textBoxChannelSettingsFile);
            this.splitContainer.Panel1.Controls.Add(this.buttonSaveChannelSettings);
            this.splitContainer.Panel1.Controls.Add(this.buttonLoadChannelsToSystem);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridViewChannels);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(730, 503);
            this.splitContainer.SplitterDistance = 91;
            this.splitContainer.TabIndex = 19;
            // 
            // dataGridViewChannels
            // 
            this.dataGridViewChannels.AllowUserToAddRows = false;
            this.dataGridViewChannels.AllowUserToDeleteRows = false;
            this.dataGridViewChannels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewChannels.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewChannels.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewChannels.Name = "dataGridViewChannels";
            this.dataGridViewChannels.RowHeadersVisible = false;
            this.dataGridViewChannels.RowHeadersWidth = 20;
            this.dataGridViewChannels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewChannels.Size = new System.Drawing.Size(730, 408);
            this.dataGridViewChannels.TabIndex = 12;
            // 
            // buttonSelectSettingsFile
            // 
            this.buttonSelectSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectSettingsFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectSettingsFile.Location = new System.Drawing.Point(680, 20);
            this.buttonSelectSettingsFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectSettingsFile.Name = "buttonSelectSettingsFile";
            this.buttonSelectSettingsFile.Size = new System.Drawing.Size(30, 20);
            this.buttonSelectSettingsFile.TabIndex = 24;
            this.buttonSelectSettingsFile.Text = "...";
            this.buttonSelectSettingsFile.UseVisualStyleBackColor = true;
            // 
            // labelChannelSettingsFilePath
            // 
            this.labelChannelSettingsFilePath.AutoSize = true;
            this.labelChannelSettingsFilePath.Location = new System.Drawing.Point(17, 20);
            this.labelChannelSettingsFilePath.Name = "labelChannelSettingsFilePath";
            this.labelChannelSettingsFilePath.Size = new System.Drawing.Size(124, 13);
            this.labelChannelSettingsFilePath.TabIndex = 23;
            this.labelChannelSettingsFilePath.Text = "Путь к файлу настроек";
            // 
            // textBoxChannelSettingsFile
            // 
            this.textBoxChannelSettingsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChannelSettingsFile.Location = new System.Drawing.Point(150, 20);
            this.textBoxChannelSettingsFile.Name = "textBoxChannelSettingsFile";
            this.textBoxChannelSettingsFile.ReadOnly = true;
            this.textBoxChannelSettingsFile.Size = new System.Drawing.Size(520, 20);
            this.textBoxChannelSettingsFile.TabIndex = 22;
            // 
            // buttonLoadChannelsToSystem
            // 
            this.buttonLoadChannelsToSystem.Location = new System.Drawing.Point(347, 50);
            this.buttonLoadChannelsToSystem.Name = "buttonLoadChannelsToSystem";
            this.buttonLoadChannelsToSystem.Size = new System.Drawing.Size(200, 30);
            this.buttonLoadChannelsToSystem.TabIndex = 20;
            this.buttonLoadChannelsToSystem.Text = "Загрузить каналы в систему";
            this.buttonLoadChannelsToSystem.UseVisualStyleBackColor = true;
            // 
            // buttonSaveChannelSettings
            // 
            this.buttonSaveChannelSettings.Location = new System.Drawing.Point(237, 50);
            this.buttonSaveChannelSettings.Name = "buttonSaveChannelSettings";
            this.buttonSaveChannelSettings.Size = new System.Drawing.Size(100, 29);
            this.buttonSaveChannelSettings.TabIndex = 17;
            this.buttonSaveChannelSettings.Text = "Сохранить";
            this.buttonSaveChannelSettings.UseVisualStyleBackColor = true;
            // 
            // buttonGetChannelsSettings
            // 
            this.buttonGetChannelsSettings.Location = new System.Drawing.Point(17, 50);
            this.buttonGetChannelsSettings.Name = "buttonGetChannelsSettings";
            this.buttonGetChannelsSettings.Size = new System.Drawing.Size(210, 30);
            this.buttonGetChannelsSettings.TabIndex = 16;
            this.buttonGetChannelsSettings.Text = "Загрузить настройки в таблицу";
            this.buttonGetChannelsSettings.UseVisualStyleBackColor = true;
            // 
            // TabControlTablessTabPage
            // 
            this.Controls.Add(this.splitContainer);
            this.Name = "TabControlTablessTabPage";
            this.Size = new System.Drawing.Size(730, 503);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChannels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonSelectSettingsFile;
        private System.Windows.Forms.Label labelChannelSettingsFilePath;
        private System.Windows.Forms.Button buttonGetChannelsSettings;
        private System.Windows.Forms.TextBox textBoxChannelSettingsFile;
        private System.Windows.Forms.Button buttonSaveChannelSettings;
        private System.Windows.Forms.Button buttonLoadChannelsToSystem;
        private System.Windows.Forms.DataGridView dataGridViewChannels;
    }
}
