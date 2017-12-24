namespace Task1
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewBig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewSmall,
            this.menuNewMedium,
            this.menuNewBig});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(121, 20);
            this.menuNew.Text = "Новый поиск пути";
            // 
            // menuNewSmall
            // 
            this.menuNewSmall.Name = "menuNewSmall";
            this.menuNewSmall.Size = new System.Drawing.Size(152, 22);
            this.menuNewSmall.Text = "Маленький";
            this.menuNewSmall.Click += new System.EventHandler(this.menuNewSmall_Click);
            // 
            // menuNewMedium
            // 
            this.menuNewMedium.Name = "menuNewMedium";
            this.menuNewMedium.Size = new System.Drawing.Size(152, 22);
            this.menuNewMedium.Text = "Средний";
            this.menuNewMedium.Click += new System.EventHandler(this.menuNewMedium_Click);
            // 
            // menuNewBig
            // 
            this.menuNewBig.Name = "menuNewBig";
            this.menuNewBig.Size = new System.Drawing.Size(152, 22);
            this.menuNewBig.Text = "Большой";
            this.menuNewBig.Click += new System.EventHandler(this.menuNewBig_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(68, 20);
            this.menuHelp.Text = "Помощь";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Поиск пути - волновой алгоритм";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuNewSmall;
        private System.Windows.Forms.ToolStripMenuItem menuNewMedium;
        private System.Windows.Forms.ToolStripMenuItem menuNewBig;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
    }
}

