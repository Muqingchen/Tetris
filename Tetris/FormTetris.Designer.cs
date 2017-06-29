namespace Tetris
{
    partial class FormTetris
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelScore = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.panelNext = new System.Windows.Forms.Panel();
            this.Btn_start = new System.Windows.Forms.Button();
            this.Btn_pause = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panelScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.WindowText;
            this.panelMain.Controls.Add(this.textBox1);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(200, 400);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 480);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTetris_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormTetris_KeyUp);
            // 
            // panelScore
            // 
            this.panelScore.BackColor = System.Drawing.SystemColors.WindowText;
            this.panelScore.Controls.Add(this.label2);
            this.panelScore.Controls.Add(this.label1);
            this.panelScore.Controls.Add(this.lblScore);
            this.panelScore.Controls.Add(this.lblRow);
            this.panelScore.Controls.Add(this.panelNext);
            this.panelScore.Location = new System.Drawing.Point(206, -5);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(167, 259);
            this.panelScore.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "分数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "行数：";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(70, 193);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(11, 12);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.ForeColor = System.Drawing.Color.White;
            this.lblRow.Location = new System.Drawing.Point(69, 155);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(11, 12);
            this.lblRow.TabIndex = 1;
            this.lblRow.Text = "0";
            // 
            // panelNext
            // 
            this.panelNext.Location = new System.Drawing.Point(30, 27);
            this.panelNext.Name = "panelNext";
            this.panelNext.Size = new System.Drawing.Size(121, 100);
            this.panelNext.TabIndex = 0;
            this.panelNext.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNext_Paint);
            // 
            // Btn_start
            // 
            this.Btn_start.Location = new System.Drawing.Point(229, 288);
            this.Btn_start.Name = "Btn_start";
            this.Btn_start.Size = new System.Drawing.Size(75, 23);
            this.Btn_start.TabIndex = 2;
            this.Btn_start.Text = "开始";
            this.Btn_start.UseVisualStyleBackColor = true;
            this.Btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // Btn_pause
            // 
            this.Btn_pause.Location = new System.Drawing.Point(229, 319);
            this.Btn_pause.Name = "Btn_pause";
            this.Btn_pause.Size = new System.Drawing.Size(75, 23);
            this.Btn_pause.TabIndex = 3;
            this.Btn_pause.Text = "暂停";
            this.Btn_pause.UseVisualStyleBackColor = true;
            this.Btn_pause.Click += new System.EventHandler(this.Btn_pause_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(377, 400);
            this.Controls.Add(this.Btn_pause);
            this.Controls.Add(this.Btn_start);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelScore);
            this.Name = "FormTetris";
            this.Text = "俄罗斯方块";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelScore.ResumeLayout(false);
            this.panelScore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Panel panelNext;
        private System.Windows.Forms.Button Btn_start;
        private System.Windows.Forms.Button Btn_pause;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

