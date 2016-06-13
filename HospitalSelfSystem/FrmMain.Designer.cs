namespace HospitalSelfSystem
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.labTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pSetting = new System.Windows.Forms.PictureBox();
            this.labHosName = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.lbJS = new System.Windows.Forms.Label();
            this.lbFK = new System.Windows.Forms.Label();
            this.lbCZ = new System.Windows.Forms.Label();
            this.lbXFCX = new System.Windows.Forms.Label();
            this.lbYECX = new System.Windows.Forms.Label();
            this.lbGH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Location = new System.Drawing.Point(889, 698);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(135, 70);
            this.pictureBox8.TabIndex = 8;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.DoubleClick += new System.EventHandler(this.pictureBox8_DoubleClick);
            // 
            // labTime
            // 
            this.labTime.BackColor = System.Drawing.Color.Transparent;
            this.labTime.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labTime.Location = new System.Drawing.Point(642, 95);
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
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 698);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 70);
            this.label2.TabIndex = 10;
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // pSetting
            // 
            this.pSetting.BackColor = System.Drawing.Color.Transparent;
            this.pSetting.Image = ((System.Drawing.Image)(resources.GetObject("pSetting.Image")));
            this.pSetting.Location = new System.Drawing.Point(812, 698);
            this.pSetting.Name = "pSetting";
            this.pSetting.Size = new System.Drawing.Size(71, 70);
            this.pSetting.TabIndex = 11;
            this.pSetting.TabStop = false;
            this.pSetting.Visible = false;
            this.pSetting.Click += new System.EventHandler(this.pSetting_Click);
            // 
            // labHosName
            // 
            this.labHosName.BackColor = System.Drawing.Color.Transparent;
            this.labHosName.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labHosName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labHosName.Location = new System.Drawing.Point(101, 83);
            this.labHosName.Name = "labHosName";
            this.labHosName.Size = new System.Drawing.Size(627, 64);
            this.labHosName.TabIndex = 13;
            this.labHosName.Text = "大沥医院";
            this.labHosName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picHome
            // 
            this.picHome.Location = new System.Drawing.Point(-1, 192);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(296, 452);
            this.picHome.TabIndex = 16;
            this.picHome.TabStop = false;
            // 
            // lbJS
            // 
            this.lbJS.BackColor = System.Drawing.Color.Transparent;
            this.lbJS.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbJS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbJS.Location = new System.Drawing.Point(386, 178);
            this.lbJS.Name = "lbJS";
            this.lbJS.Size = new System.Drawing.Size(222, 117);
            this.lbJS.TabIndex = 29;
            this.lbJS.Text = "       医院介绍";
            this.lbJS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbJS.Click += new System.EventHandler(this.lbJS_Click);
            // 
            // lbFK
            // 
            this.lbFK.BackColor = System.Drawing.Color.Transparent;
            this.lbFK.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbFK.Location = new System.Drawing.Point(699, 178);
            this.lbFK.Name = "lbFK";
            this.lbFK.Size = new System.Drawing.Size(222, 117);
            this.lbFK.TabIndex = 30;
            this.lbFK.Text = "       自助发卡";
            this.lbFK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFK.Click += new System.EventHandler(this.lbFK_Click);
            // 
            // lbCZ
            // 
            this.lbCZ.BackColor = System.Drawing.Color.Transparent;
            this.lbCZ.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbCZ.Location = new System.Drawing.Point(699, 349);
            this.lbCZ.Name = "lbCZ";
            this.lbCZ.Size = new System.Drawing.Size(222, 117);
            this.lbCZ.TabIndex = 31;
            this.lbCZ.Text = "       自助充值";
            this.lbCZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCZ.Click += new System.EventHandler(this.lbCZ_Click);
            // 
            // lbXFCX
            // 
            this.lbXFCX.BackColor = System.Drawing.Color.Transparent;
            this.lbXFCX.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbXFCX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbXFCX.Location = new System.Drawing.Point(386, 349);
            this.lbXFCX.Name = "lbXFCX";
            this.lbXFCX.Size = new System.Drawing.Size(222, 117);
            this.lbXFCX.TabIndex = 32;
            this.lbXFCX.Text = "       消费查询";
            this.lbXFCX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbXFCX.Click += new System.EventHandler(this.lbXFCX_Click);
            // 
            // lbYECX
            // 
            this.lbYECX.BackColor = System.Drawing.Color.Transparent;
            this.lbYECX.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbYECX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbYECX.Location = new System.Drawing.Point(386, 520);
            this.lbYECX.Name = "lbYECX";
            this.lbYECX.Size = new System.Drawing.Size(222, 117);
            this.lbYECX.TabIndex = 33;
            this.lbYECX.Text = "       余额查询";
            this.lbYECX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbYECX.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbGH
            // 
            this.lbGH.BackColor = System.Drawing.Color.Transparent;
            this.lbGH.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbGH.Location = new System.Drawing.Point(699, 520);
            this.lbGH.Name = "lbGH";
            this.lbGH.Size = new System.Drawing.Size(222, 117);
            this.lbGH.TabIndex = 34;
            this.lbGH.Text = "       自助挂号";
            this.lbGH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbGH.Click += new System.EventHandler(this.lbGH_Click);
            // 
            // FrmMain3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.lbGH);
            this.Controls.Add(this.lbYECX);
            this.Controls.Add(this.lbXFCX);
            this.Controls.Add(this.lbCZ);
            this.Controls.Add(this.lbFK);
            this.Controls.Add(this.lbJS);
            this.Controls.Add(this.labHosName);
            this.Controls.Add(this.pSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.pictureBox8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pSetting;
        private System.Windows.Forms.Label labHosName;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Label lbJS;
        private System.Windows.Forms.Label lbFK;
        private System.Windows.Forms.Label lbCZ;
        private System.Windows.Forms.Label lbXFCX;
        private System.Windows.Forms.Label lbYECX;
        private System.Windows.Forms.Label lbGH;
    }
}