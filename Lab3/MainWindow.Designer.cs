namespace Lab3
{
    partial class MainWindow
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
            this.heading = new System.Windows.Forms.Label();
            this.Clean_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heading.Location = new System.Drawing.Point(441, 9);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(348, 23);
            this.heading.TabIndex = 0;
            this.heading.Text = "Поставьте 4 точки левой кнопкой мыши: ";
            // 
            // Clean_btn
            // 
            this.Clean_btn.Location = new System.Drawing.Point(13, 8);
            this.Clean_btn.Name = "Clean_btn";
            this.Clean_btn.Size = new System.Drawing.Size(422, 34);
            this.Clean_btn.TabIndex = 1;
            this.Clean_btn.Text = "Очистить все";
            this.Clean_btn.UseVisualStyleBackColor = true;
            this.Clean_btn.Click += new System.EventHandler(this.Clean_btn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 670);
            this.Controls.Add(this.Clean_btn);
            this.Controls.Add(this.heading);
            this.Name = "MainWindow";
            this.Text = "Task3";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Button Clean_btn;
    }
}

