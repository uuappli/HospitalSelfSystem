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
    public partial class FrmWarn : Form
    {
        int sec = 3;
        public FrmWarn()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //sec = sec - 1;
            //if (sec == 0)
            //{
            //    FrmGetCard frm = new FrmGetCard();
            //    frm.ShowDialog();
            //}
        }
    }
}
