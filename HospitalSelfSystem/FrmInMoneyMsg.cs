using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HospitalSelfSystem;

namespace AutoRegisterManager
{
    public partial class FrmInMoneyMsg : Form
    {
        public FrmInMoneyMsg()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
           //退卡
            this.DialogResult = DialogResult.Cancel ;
            //this.icMsg1.timer1.Stop();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmInMoneyMsg_Load(object sender, EventArgs e)
        {
            this.lblyue.Text = FrmMain.cardBlance.ToString();
        }
    }
}
