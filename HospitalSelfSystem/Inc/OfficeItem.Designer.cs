namespace AutoRegisterManager.Inc
{
    partial class OfficeItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficeItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblOffice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.LblOffice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 91);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.LblOffice_Click);
            // 
            // LblOffice
            // 
            this.LblOffice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.LblOffice.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblOffice.ForeColor = System.Drawing.Color.Teal;
            this.LblOffice.Location = new System.Drawing.Point(4, 27);
            this.LblOffice.Name = "LblOffice";
            this.LblOffice.Size = new System.Drawing.Size(147, 28);
            this.LblOffice.TabIndex = 1;
            this.LblOffice.Text = "科室名称";
            this.LblOffice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblOffice.Click += new System.EventHandler(this.LblOffice_Click);
            // 
            // OfficeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.panel1);
            this.Name = "OfficeItem";
            this.Size = new System.Drawing.Size(163, 91);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label LblOffice;


    }
}
