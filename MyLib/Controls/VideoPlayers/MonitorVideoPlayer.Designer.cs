namespace MyLib.Controls.VideoPlayers
{
    partial class MonitorVideoPlayer
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = true;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.FlatAppearance.BorderSize = 0;
            this.buttonStartStop.Location = new System.Drawing.Point(1, 201);
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Size = new System.Drawing.Size(300, 224);
            this.pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragDrop);
            this.pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragEnter);
            // 
            // splitContainer
            // 
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.SplitterDistance = 224;
            // 
            // buttonTakeSnapshot
            // 
            this.buttonTakeSnapshot.FlatAppearance.BorderSize = 0;
            this.buttonTakeSnapshot.Location = new System.Drawing.Point(22, 201);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // MonitorVideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "MonitorVideoPlayer";
            this.Controls.SetChildIndex(this.splitContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    }
}
