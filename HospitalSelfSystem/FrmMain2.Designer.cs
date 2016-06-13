namespace HospitalSelfSystem
{
    partial class FrmMain2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain2));
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.labTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pSetting = new System.Windows.Forms.PictureBox();
            this.pLogo = new System.Windows.Forms.PictureBox();
            this.labHosName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblguahao = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblFk = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(889, 698);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(135, 70);
            this.pictureBox8.TabIndex = 8;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.DoubleClick += new System.EventHandler(this.pictureBox8_DoubleClick);
            // 
            // labTime
            // 
            this.labTime.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTime.ForeColor = System.Drawing.Color.Teal;
            this.labTime.Location = new System.Drawing.Point(654, 44);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(370, 52);
            this.labTime.TabIndex = 9;
            this.labTime.Text = "20:00";
            this.labTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 698);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 70);
            this.label2.TabIndex = 10;
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // pSetting
            // 
            this.pSetting.Image = ((System.Drawing.Image)(resources.GetObject("pSetting.Image")));
            this.pSetting.Location = new System.Drawing.Point(812, 698);
            this.pSetting.Name = "pSetting";
            this.pSetting.Size = new System.Drawing.Size(71, 70);
            this.pSetting.TabIndex = 11;
            this.pSetting.TabStop = false;
            this.pSetting.Visible = false;
            this.pSetting.Click += new System.EventHandler(this.pSetting_Click);
            // 
            // pLogo
            // 
            this.pLogo.Image = ((System.Drawing.Image)(resources.GetObject("pLogo.Image")));
            this.pLogo.Location = new System.Drawing.Point(-1, -1);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(145, 122);
            this.pLogo.TabIndex = 12;
            this.pLogo.TabStop = false;
            // 
            // labHosName
            // 
            this.labHosName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHosName.ForeColor = System.Drawing.Color.Gray;
            this.labHosName.Location = new System.Drawing.Point(159, 54);
            this.labHosName.Name = "labHosName";
            this.labHosName.Size = new System.Drawing.Size(215, 23);
            this.labHosName.TabIndex = 13;
            this.labHosName.Text = "大沥医院";
            this.labHosName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(380, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "自助发卡、充值、挂号、查询机";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(160, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(367, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hospital of self-registration recharge system";
            // 
            // lblguahao
            // 
            this.lblguahao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblguahao.Image = ((System.Drawing.Image)(resources.GetObject("lblguahao.Image")));
            this.lblguahao.Location = new System.Drawing.Point(675, 515);
            this.lblguahao.Name = "lblguahao";
            this.lblguahao.Size = new System.Drawing.Size(279, 128);
            this.lblguahao.TabIndex = 16;
            this.lblguahao.Click += new System.EventHandler(this.lblguahao_Click);
            // 
            // label13
            // 
            this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.Location = new System.Drawing.Point(675, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(279, 128);
            this.label13.TabIndex = 17;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // lblFk
            // 
            this.lblFk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFk.Image = ((System.Drawing.Image)(resources.GetObject("lblFk.Image")));
            this.lblFk.Location = new System.Drawing.Point(675, 151);
            this.lblFk.Name = "lblFk";
            this.lblFk.Size = new System.Drawing.Size(279, 128);
            this.lblFk.TabIndex = 18;
            this.lblFk.Click += new System.EventHandler(this.lblFk_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(408, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 28);
            this.label4.TabIndex = 19;
            this.label4.Text = "办理医卡通（就诊、挂号）";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(408, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 28);
            this.label5.TabIndex = 20;
            this.label5.Text = "需要二代身份证";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(456, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 28);
            this.label7.TabIndex = 21;
            this.label7.Text = "办理医卡通充值业务";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(456, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 28);
            this.label6.TabIndex = 22;
            this.label6.Text = "办理医卡通挂号业务";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(627, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 54);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(627, 373);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 54);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(627, 553);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 54);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(22, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(304, 84);
            this.label8.TabIndex = 26;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(22, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 84);
            this.label9.TabIndex = 27;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(22, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(304, 84);
            this.label10.TabIndex = 28;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label12
            // 
            this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Image = ((System.Drawing.Image)(resources.GetObject("label12.Image")));
            this.label12.Location = new System.Drawing.Point(22, 472);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(304, 84);
            this.label12.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(22, 579);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(304, 84);
            this.label11.TabIndex = 30;
            // 
            // FrmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblguahao);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblFk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labHosName);
            this.Controls.Add(this.pLogo);
            this.Controls.Add(this.pSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.pictureBox8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pSetting;
        private System.Windows.Forms.PictureBox pLogo;
        private System.Windows.Forms.Label labHosName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblguahao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblFk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}