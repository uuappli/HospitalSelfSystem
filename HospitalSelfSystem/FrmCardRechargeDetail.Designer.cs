namespace HospitalSelfSystem
{
    partial class FrmCardRechargeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardRechargeDetail));
            this.label5 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pExit = new System.Windows.Forms.PictureBox();
            this.pReturn = new System.Windows.Forms.PictureBox();
            this.lbYe = new System.Windows.Forms.Label();
            this.lbKh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbXm = new System.Windows.Forms.Label();
            this.lbZE = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).BeginInit();
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
            this.label5.TabIndex = 16;
            this.label5.Text = "充值记录";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(26, 176);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(971, 503);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Teal;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 30;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn1.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn1.Caption = "充值金额";
            this.gridColumn1.FieldName = "充值金额";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "充值时间";
            this.gridColumn2.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "充值时间";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // pExit
            // 
            this.pExit.BackColor = System.Drawing.SystemColors.Control;
            this.pExit.Image = ((System.Drawing.Image)(resources.GetObject("pExit.Image")));
            this.pExit.Location = new System.Drawing.Point(791, 697);
            this.pExit.Name = "pExit";
            this.pExit.Size = new System.Drawing.Size(221, 69);
            this.pExit.TabIndex = 68;
            this.pExit.TabStop = false;
            this.pExit.Click += new System.EventHandler(this.pExit_Click);
            // 
            // pReturn
            // 
            this.pReturn.BackColor = System.Drawing.SystemColors.Control;
            this.pReturn.Image = ((System.Drawing.Image)(resources.GetObject("pReturn.Image")));
            this.pReturn.Location = new System.Drawing.Point(12, 697);
            this.pReturn.Name = "pReturn";
            this.pReturn.Size = new System.Drawing.Size(225, 69);
            this.pReturn.TabIndex = 67;
            this.pReturn.TabStop = false;
            this.pReturn.Visible = false;
            // 
            // lbYe
            // 
            this.lbYe.BackColor = System.Drawing.Color.Transparent;
            this.lbYe.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbYe.ForeColor = System.Drawing.Color.Red;
            this.lbYe.Location = new System.Drawing.Point(858, 130);
            this.lbYe.Name = "lbYe";
            this.lbYe.Size = new System.Drawing.Size(118, 33);
            this.lbYe.TabIndex = 76;
            this.lbYe.Text = "1000";
            this.lbYe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbKh
            // 
            this.lbKh.AutoSize = true;
            this.lbKh.BackColor = System.Drawing.Color.Transparent;
            this.lbKh.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbKh.ForeColor = System.Drawing.Color.Teal;
            this.lbKh.Location = new System.Drawing.Point(305, 134);
            this.lbKh.Name = "lbKh";
            this.lbKh.Size = new System.Drawing.Size(60, 24);
            this.lbKh.TabIndex = 75;
            this.lbKh.Text = "卡号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(754, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 74;
            this.label2.Text = "卡余额:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(226, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 73;
            this.label1.Text = "卡号:";
            // 
            // lbXm
            // 
            this.lbXm.AutoSize = true;
            this.lbXm.BackColor = System.Drawing.Color.Transparent;
            this.lbXm.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbXm.ForeColor = System.Drawing.Color.Teal;
            this.lbXm.Location = new System.Drawing.Point(62, 134);
            this.lbXm.Name = "lbXm";
            this.lbXm.Size = new System.Drawing.Size(60, 24);
            this.lbXm.TabIndex = 72;
            this.lbXm.Text = "姓名";
            // 
            // lbZE
            // 
            this.lbZE.BackColor = System.Drawing.Color.Transparent;
            this.lbZE.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbZE.ForeColor = System.Drawing.Color.Red;
            this.lbZE.Location = new System.Drawing.Point(630, 130);
            this.lbZE.Name = "lbZE";
            this.lbZE.Size = new System.Drawing.Size(118, 33);
            this.lbZE.TabIndex = 78;
            this.lbZE.Text = "1000";
            this.lbZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(501, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 77;
            this.label4.Text = "充值总额:";
            // 
            // FrmCardRechargeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lbZE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbYe);
            this.Controls.Add(this.lbKh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbXm);
            this.Controls.Add(this.pExit);
            this.Controls.Add(this.pReturn);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCardRechargeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCardRechargeDetail";
            this.Load += new System.EventHandler(this.FrmCardRechargeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.PictureBox pExit;
        private System.Windows.Forms.PictureBox pReturn;
        private System.Windows.Forms.Label lbYe;
        private System.Windows.Forms.Label lbKh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbXm;
        private System.Windows.Forms.Label lbZE;
        private System.Windows.Forms.Label label4;
    }
}