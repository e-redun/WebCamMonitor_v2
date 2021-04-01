namespace MyLib.Controls
{
    partial class ComboToggler
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
            this.panelPlayers = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonToggler
            // 
            this.buttonToggler.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonToggler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonToggler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonToggler.Image = global::MyLib.Properties.Resources.arrowDownIcon;
            this.buttonToggler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonToggler.Location = new System.Drawing.Point(0, 0);
            this.buttonToggler.Margin = new System.Windows.Forms.Padding(0);
            this.buttonToggler.Name = "buttonToggler";
            this.buttonToggler.Size = new System.Drawing.Size(291, 30);
            this.buttonToggler.TabIndex = 0;
            this.buttonToggler.Text = "button1";
            this.buttonToggler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonToggler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonToggler.UseVisualStyleBackColor = true;
            this.buttonToggler.Click += new System.EventHandler(this.buttonToggler_Click);
            // 
            // panelPlayers
            // 
            this.panelPlayers.AutoSize = true;
            this.panelPlayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayers.Location = new System.Drawing.Point(0, 30);
            this.panelPlayers.Margin = new System.Windows.Forms.Padding(0);
            this.panelPlayers.Name = "panelPlayers";
            this.panelPlayers.Size = new System.Drawing.Size(291, 0);
            this.panelPlayers.TabIndex = 1;
            this.panelPlayers.Visible = false;
            // 
            // ComboToggler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelPlayers);
            this.Controls.Add(this.buttonToggler);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ComboToggler";
            this.Size = new System.Drawing.Size(291, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonToggler;
        private System.Windows.Forms.Panel panelPlayers;
    }
}
