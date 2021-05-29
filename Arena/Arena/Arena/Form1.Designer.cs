
namespace Arena
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HPPlayerBar = new System.Windows.Forms.ProgressBar();
            this.HPEnemyBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // HPPlayerBar
            // 
            this.HPPlayerBar.BackColor = System.Drawing.SystemColors.MenuText;
            this.HPPlayerBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HPPlayerBar.Location = new System.Drawing.Point(15, 12);
            this.HPPlayerBar.Name = "HPPlayerBar";
            this.HPPlayerBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HPPlayerBar.Size = new System.Drawing.Size(550, 21);
            this.HPPlayerBar.TabIndex = 0;
            this.HPPlayerBar.Value = 100;
            // 
            // HPEnemyBar
            // 
            this.HPEnemyBar.BackColor = System.Drawing.SystemColors.MenuText;
            this.HPEnemyBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HPEnemyBar.Location = new System.Drawing.Point(682, 12);
            this.HPEnemyBar.Name = "HPEnemyBar";
            this.HPEnemyBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HPEnemyBar.RightToLeftLayout = true;
            this.HPEnemyBar.Size = new System.Drawing.Size(550, 21);
            this.HPEnemyBar.TabIndex = 1;
            this.HPEnemyBar.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 528);
            this.Controls.Add(this.HPEnemyBar);
            this.Controls.Add(this.HPPlayerBar);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar HPPlayerBar;
        private System.Windows.Forms.ProgressBar HPEnemyBar;
    }
}

