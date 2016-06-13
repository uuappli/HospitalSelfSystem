namespace HospitalSelfSystem
{
    partial class FormConsumption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsumption));
            this.pExit = new System.Windows.Forms.PictureBox();
            this.pReturn = new System.Windows.Forms.PictureBox();
            this.p1M = new System.Windows.Forms.PictureBox();
            this.p2M = new System.Windows.Forms.PictureBox();
            this.p3M = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pExit
            // 
            this.pExit.BackColor = System.Drawing.SystemColors.Control;
            this.pExit.Image = ((System.Drawing.Image)(resources.GetObject("pExit.Image")));
            this.pExit.Location = new System.Drawing.Point(802, 698);
            this.pExit.Name = "pExit";
            this.pExit.Size = new System.Drawing.Size(221, 69);
            this.pExit.TabIndex = 6;
            this.pExit.TabStop = false;
            this.pExit.Click += new System.EventHandler(this.pExit_Click);
            // 
            // pReturn
            // 
            this.pReturn.BackColor = System.Drawing.SystemColors.Control;
            this.pReturn.Image = ((System.Drawing.Image)(resources.GetObject("pReturn.Image")));
            this.pReturn.Location = new System.Drawing.Point(12, 698);
            this.pReturn.Name = "pReturn";
            this.pReturn.Size = new System.Drawing.Size(225, 69);
            this.pReturn.TabIndex = 5;
            this.pReturn.TabStop = false;
            this.pReturn.Visible = false;
            // 
            // p1M
            // 
            this.p1M.Image = ((System.Drawing.Image)(resources.GetObject("p1M.Image")));
            this.p1M.Location = new System.Drawing.Point(160, 500);
            this.p1M.Name = "p1M";
            this.p1M.Size = new System.Drawing.Size(168, 70);
            this.p1M.TabIndex = 7;
            this.p1M.TabStop = false;
            this.p1M.Visible = false;
            this.p1M.Click += new System.EventHandler(this.p1M_Click);
            // 
            // p2M
            // 
            this.p2M.Image = ((System.Drawing.Image)(resources.GetObject("p2M.Image")));
            this.p2M.Location = new System.Drawing.Point(432, 502);
            this.p2M.Name = "p2M";
            this.p2M.Size = new System.Drawing.Size(169, 68);
            this.p2M.TabIndex = 8;
            this.p2M.TabStop = false;
            this.p2M.Visible = false;
            this.p2M.Click += new System.EventHandler(this.p2M_Click);
            // 
            // p3M
            // 
            this.p3M.Image = ((System.Drawing.Image)(resources.GetObject("p3M.Image")));
            this.p3M.Location = new System.Drawing.Point(696, 499);
            this.p3M.Name = "p3M";
            this.p3M.Size = new System.Drawing.Size(170, 71);
            this.p3M.TabIndex = 9;
            this.p3M.TabStop = false;
            this.p3M.Visible = false;
            this.p3M.Click += new System.EventHandler(this.p3M_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(157, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "最近一个月内消费记录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(429, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "最近二个月内消费记录";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(693, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "最近三个月内消费记录";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(439, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 33);
            this.label4.TabIndex = 13;
            this.label4.Text = "消费查询";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(224, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "李新华";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(338, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "您好  卡号 : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(160, 420);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(482, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "您好  卡号 : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // FormConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p3M);
            this.Controls.Add(this.p2M);
            this.Controls.Add(this.p1M);
            this.Controls.Add(this.pExit);
            this.Controls.Add(this.pReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConsumption";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormConsumption_FormClosed);
            this.Load += new System.EventHandler(this.FormConsumption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pExit;
        private System.Windows.Forms.PictureBox pReturn;
        private System.Windows.Forms.PictureBox p1M;
        private System.Windows.Forms.PictureBox p2M;
        private System.Windows.Forms.PictureBox p3M;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}