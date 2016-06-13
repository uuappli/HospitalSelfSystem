namespace AutoRegisterManager
{
    partial class FrmInMoney
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInMoney));
            this.label1 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.icMsg1 = new AutoRegisterManager.Inc.IcMsg();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(32, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "充值口准备接收您的纸币，请插入纸币，如果您不想充值，请点击取消";
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(550, 279);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(187, 49);
            this.lblClose.TabIndex = 3;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblOK
            // 
            this.lblOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOK.Image = ((System.Drawing.Image)(resources.GetObject("lblOK.Image")));
            this.lblOK.Location = new System.Drawing.Point(334, 281);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(183, 47);
            this.lblOK.TabIndex = 3;
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Location = new System.Drawing.Point(33, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "数据处理中，请稍候 ......";
            this.label2.Visible = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // icMsg1
            // 
            this.icMsg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icMsg1.Location = new System.Drawing.Point(0, 0);
            this.icMsg1.Name = "icMsg1";
            this.icMsg1.Size = new System.Drawing.Size(799, 362);
            this.icMsg1.TabIndex = 0;
            this.icMsg1.Load += new System.EventHandler(this.icMsg1_Load);
            // 
            // FrmInMoney
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(799, 362);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.icMsg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInMoney";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInMoney";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInMoney_FormClosing);
            this.Load += new System.EventHandler(this.FrmInMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblOK;
        //private AxTTDRIVERMGRLib.AxTTDriverMgr axTTDriverMgr1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public Inc.IcMsg icMsg1;
    }
}