
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
            this.labelPlayer = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelEnemy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // HPPlayerBar
            // 
            this.HPPlayerBar.BackColor = System.Drawing.Color.FloralWhite;
            this.HPPlayerBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HPPlayerBar.Location = new System.Drawing.Point(118, 46);
            this.HPPlayerBar.Name = "HPPlayerBar";
            this.HPPlayerBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HPPlayerBar.Size = new System.Drawing.Size(406, 22);
            this.HPPlayerBar.TabIndex = 0;
            this.HPPlayerBar.Value = 100;
            // 
            // HPEnemyBar
            // 
            this.HPEnemyBar.BackColor = System.Drawing.SystemColors.MenuText;
            this.HPEnemyBar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HPEnemyBar.Location = new System.Drawing.Point(721, 46);
            this.HPEnemyBar.Name = "HPEnemyBar";
            this.HPEnemyBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HPEnemyBar.RightToLeftLayout = true;
            this.HPEnemyBar.Size = new System.Drawing.Size(404, 22);
            this.HPEnemyBar.TabIndex = 1;
            this.HPEnemyBar.Value = 100;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.MidnightBlue;
            this.labelPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft YaHei", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelPlayer.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelPlayer.Location = new System.Drawing.Point(146, 91);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(85, 19);
            this.labelPlayer.TabIndex = 3;
            this.labelPlayer.Text = "labelPlayer";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelEnemy
            // 
            this.labelEnemy.AutoSize = true;
            this.labelEnemy.BackColor = System.Drawing.Color.MidnightBlue;
            this.labelEnemy.Font = new System.Drawing.Font("Microsoft YaHei", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelEnemy.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelEnemy.Location = new System.Drawing.Point(1015, 91);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelEnemy.Size = new System.Drawing.Size(89, 19);
            this.labelEnemy.TabIndex = 5;
            this.labelEnemy.Text = "labelEnemy";
            this.labelEnemy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarHero" +
    ".png";
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 107);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ImageLocation = "D:\\Ilyxa\\УЧЕБА\\Прога\\GAME\\GameForULearnCourse\\Arena\\Arena\\Arena\\Sprites\\HpBarEnem" +
    "y.png";
            this.pictureBox2.Location = new System.Drawing.Point(706, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(526, 107);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 528);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.HPEnemyBar);
            this.Controls.Add(this.HPPlayerBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar HPPlayerBar;
        private System.Windows.Forms.ProgressBar HPEnemyBar;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

