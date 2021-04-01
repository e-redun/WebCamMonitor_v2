namespace MyLib.Controls.VideoPlayers
{
    partial class ChannelVideoPlayer
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChannelDescription
            // 
            this.labelChannelDescription.MaximumSize = new System.Drawing.Size(140, 16);
            this.labelChannelDescription.MinimumSize = new System.Drawing.Size(50, 16);
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
            this.pictureBox.Size = new System.Drawing.Size(300, 224);
            // 
            // splitContainer
            // 
            this.splitContainer.SplitterDistance = 224;
            // 
            // buttonTakeSnapshot
            // 
            this.buttonTakeSnapshot.FlatAppearance.BorderSize = 0;
            this.buttonTakeSnapshot.Location = new System.Drawing.Point(22, 201);
            // 
            // ChannelVideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ChannelVideoPlayer";
            this.Resize += new System.EventHandler(this.ChannelVideoPlayer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
