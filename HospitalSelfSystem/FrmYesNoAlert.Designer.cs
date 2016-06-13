namespace AutoRegisterManager
{
    partial class FrmYesNoAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYesNoAlert));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOk = new System.Windows.Forms.Label();
            this.lblcancle = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblOk);
            this.panel1.Controls.Add(this.lblcancle);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 374);
            this.panel1.TabIndex = 3;
            // 
            // lblOk
            // 
            this.lblOk.BackColor = System.Drawing.Color.Transparent;
            this.lblOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOk.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lblOk.Image = ((System.Drawing.Image)(resources.GetObject("lblOk.Image")));
            this.lblOk.Location = new System.Drawing.Point(374, 166);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(146, 154);
            this.lblOk.TabIndex = 1;
            this.lblOk.Click += new System.EventHandler(this.lblOk_Click);
            // 
            // lblcancle
            // 
            this.lblcancle.BackColor = System.Drawing.Color.Transparent;
            this.lblcancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblcancle.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lblcancle.Image = ((System.Drawing.Image)(resources.GetObject("lblcancle.Image")));
            this.lblcancle.Location = new System.Drawing.Point(81, 166);
            this.lblcancle.Name = "lblcancle";
            this.lblcancle.Size = new System.Drawing.Size(146, 154);
            this.lblcancle.TabIndex = 1;
            this.lblcancle.Click += new System.EventHandler(this.lblcancle_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(100, 36);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(400, 34);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "您确认要挂此专家号吗？";
            // 
            // FrmYesNoAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 374);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYesNoAlert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOkAlert";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOk;
        private System.Windows.Forms.Label lblcancle;
        public System.Windows.Forms.Label lblMsg;


    }
}