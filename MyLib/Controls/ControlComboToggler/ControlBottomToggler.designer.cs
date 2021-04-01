namespace MyLib.Controls
{
    partial class ControlBottomToggler
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
            this.buttonToggler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonToggler
            // 
            this.buttonToggler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToggler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonToggler.Location = new System.Drawing.Point(0, 0);
            this.buttonToggler.Name = "buttonToggler";
            this.buttonToggler.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonToggler.Size = new System.Drawing.Size(260, 40);
            this.buttonToggler.TabIndex = 0;
            this.buttonToggler.Text = "button1";
            this.buttonToggler.UseVisualStyleBackColor = true;
            this.buttonToggler.Click += new System.EventHandler(this.buttonToggler_Click);
            // 
            // ControlBottomToggler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.buttonToggler);
            this.Name = "ControlBottomToggler";
            this.Size = new System.Drawing.Size(260, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonToggler;
    }
}
