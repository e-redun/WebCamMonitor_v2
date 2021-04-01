namespace MyLib.Controls.VideoPlayers
{
    partial class VideoPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayer));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.labelState = new System.Windows.Forms.Label();
            this.labelChannelDescription = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonTakeSnapshot = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.labelState);
            this.splitContainer.Panel1.Controls.Add(this.labelChannelDescription);
            this.splitContainer.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer.Panel1.Controls.Add(this.buttonTakeSnapshot);
            this.splitContainer.Panel1.Controls.Add(this.buttonStartStop);
            this.splitContainer.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(300, 250);
            this.splitContainer.SplitterDistance = 224;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labelState.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelState.Location = new System.Drawing.Point(0, 16);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(51, 16);
            this.labelState.TabIndex = 33;
            this.labelState.Text = "On/Off";
            this.labelState.Visible = false;
            // 
            // labelChannelDescription
            // 
            this.labelChannelDescription.AutoSize = true;
            this.labelChannelDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labelChannelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelChannelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChannelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelChannelDescription.Location = new System.Drawing.Point(0, 0);
            this.labelChannelDescription.Name = "labelChannelDescription";
            this.labelChannelDescription.Size = new System.Drawing.Size(138, 16);
            this.labelChannelDescription.TabIndex = 30;
            this.labelChannelDescription.Text = "Описание канала";
            this.labelChannelDescription.Visible = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.Image = global::MyLib.Properties.Resources.delIcon2;
            this.buttonDelete.Location = new System.Drawing.Point(278, 2);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(20, 20);
            this.buttonDelete.TabIndex = 32;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.MouseEnter += new System.EventHandler(this.buttonDelete_MouseEnter);
            // 
            // buttonTakeSnapshot
            // 
            this.buttonTakeSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTakeSnapshot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonTakeSnapshot.FlatAppearance.BorderSize = 0;
            this.buttonTakeSnapshot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTakeSnapshot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTakeSnapshot.Image = global::MyLib.Properties.Resources.cameraIconYellow;
            this.buttonTakeSnapshot.Location = new System.Drawing.Point(23, 205);
            this.buttonTakeSnapshot.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTakeSnapshot.Name = "buttonTakeSnapshot";
            this.buttonTakeSnapshot.Size = new System.Drawing.Size(20, 20);
            this.buttonTakeSnapshot.TabIndex = 31;
            this.buttonTakeSnapshot.UseVisualStyleBackColor = false;
            this.buttonTakeSnapshot.Visible = false;
            this.buttonTakeSnapshot.Click += new System.EventHandler(this.buttonTakeSnapshot_Click);
            this.buttonTakeSnapshot.MouseEnter += new System.EventHandler(this.buttonTakeSnapshot_MouseEnter);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonStartStop.FlatAppearance.BorderSize = 0;
            this.buttonStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartStop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStartStop.Image = global::MyLib.Properties.Resources.playIconGreen;
            this.buttonStartStop.Location = new System.Drawing.Point(2, 205);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(20, 20);
            this.buttonStartStop.TabIndex = 31;
            this.buttonStartStop.UseVisualStyleBackColor = false;
            this.buttonStartStop.Visible = false;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            this.buttonStartStop.MouseEnter += new System.EventHandler(this.buttonStartStop_MouseEnter);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 224);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 29;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.splitContainer);
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(300, 250);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label labelState;
        public System.Windows.Forms.Label labelChannelDescription;
        public System.Windows.Forms.Button buttonDelete;
        public System.Windows.Forms.Button buttonStartStop;
        public System.Windows.Forms.PictureBox pictureBox;
        protected System.Windows.Forms.SplitContainer splitContainer;
        public System.Windows.Forms.Button buttonTakeSnapshot;
    }
}
