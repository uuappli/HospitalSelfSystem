using HospitalSelfSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalSelfSystem
{
    public partial class FrmNewDoctor : Form
    {
        public FrmNewDoctor()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmNewDoctor_Load(object sender, EventArgs e)
        {
            lblName.Text = FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString();
            lblAge.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString();
            lblMoney.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡余额"].ToString();

            this.lblOffice.Text = string.Format(this.lblOffice.Text, this.doctorList1.officeName);
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
