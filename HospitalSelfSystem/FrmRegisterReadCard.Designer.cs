namespace HospitalSelfSystem
{
    partial class FrmRegisterReadCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegisterReadCard));
            this.label5 = new System.Windows.Forms.Label();
            this.pGH = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pExit = new System.Windows.Forms.PictureBox();
            this.pReturn = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pGH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(439, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 33);
            this.label5.TabIndex = 17;
            this.label5.Text = "自助挂号";
            // 
            // pGH
            // 
            this.pGH.Image = ((System.Drawing.Image)(resources.GetObject("pGH.Image")));
            this.pGH.Location = new System.Drawing.Point(375, 518);
            this.pGH.Name = "pGH";
            this.pGH.Size = new System.Drawing.Size(278, 117);
            this.pGH.TabIndex = 18;
            this.pGH.TabStop = false;
            this.pGH.Visible = false;
            this.pGH.Click += new System.EventHandler(this.pGH_Click);
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
            // pExit
            // 
            this.pExit.BackColor = System.Drawing.SystemColors.Control;
            this.pExit.Image = ((System.Drawing.Image)(resources.GetObject("pExit.Image")));
            this.pExit.Location = new System.Drawing.Point(791, 698);
            this.pExit.Name = "pExit";
            this.pExit.Size = new System.Drawing.Size(221, 69);
            this.pExit.TabIndex = 20;
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
            this.pReturn.TabIndex = 19;
            this.pReturn.TabStop = false;
            this.pReturn.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(535, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "您好  卡号 : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(277, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "李新华";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(391, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "您好  卡号 : ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(213, 430);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmRegisterReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pExit);
            this.Controls.Add(this.pReturn);
            this.Controls.Add(this.pGH);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegisterReadCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegisterReadCard";
            this.Load += new System.EventHandler(this.FrmRegisterReadCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pGH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pGH;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pExit;
        private System.Windows.Forms.PictureBox pReturn;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}