namespace HospitalSelfSystem
{
    partial class FrmTakeCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTakeCard));
            this.pDJFK = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pReturn = new System.Windows.Forms.PictureBox();
            this.pExit = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pDJFK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pDJFK
            // 
            this.pDJFK.Image = ((System.Drawing.Image)(resources.GetObject("pDJFK.Image")));
            this.pDJFK.Location = new System.Drawing.Point(373, 489);
            this.pDJFK.Name = "pDJFK";
            this.pDJFK.Size = new System.Drawing.Size(278, 116);
            this.pDJFK.TabIndex = 0;
            this.pDJFK.TabStop = false;
            this.pDJFK.Click += new System.EventHandler(this.pDJFK_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(345, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "请准备好您的二代身份证";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pReturn
            // 
            this.pReturn.BackColor = System.Drawing.SystemColors.Control;
            this.pReturn.Image = ((System.Drawing.Image)(resources.GetObject("pReturn.Image")));
            this.pReturn.Location = new System.Drawing.Point(6, 696);
            this.pReturn.Name = "pReturn";
            this.pReturn.Size = new System.Drawing.Size(225, 69);
            this.pReturn.TabIndex = 2;
            this.pReturn.TabStop = false;
            this.pReturn.Visible = false;
            this.pReturn.Click += new System.EventHandler(this.pReturn_Click);
            // 
            // pExit
            // 
            this.pExit.BackColor = System.Drawing.SystemColors.Control;
            this.pExit.Image = ((System.Drawing.Image)(resources.GetObject("pExit.Image")));
            this.pExit.Location = new System.Drawing.Point(791, 696);
            this.pExit.Name = "pExit";
            this.pExit.Size = new System.Drawing.Size(221, 69);
            this.pExit.TabIndex = 6;
            this.pExit.TabStop = false;
            this.pExit.Click += new System.EventHandler(this.pExit_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmTakeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pExit);
            this.Controls.Add(this.pReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pDJFK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTakeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTakeCard";
            this.Load += new System.EventHandler(this.FrmTakeCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pDJFK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pDJFK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pReturn;
        private System.Windows.Forms.PictureBox pExit;
        private System.Windows.Forms.Timer timer1;
    }
}