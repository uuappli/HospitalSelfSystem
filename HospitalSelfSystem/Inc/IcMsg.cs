using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRegisterManager.Inc
{
    public partial class IcMsg : UserControl
    {
        int sec = 60;
        public IcMsg()
        {
            InitializeComponent();
            //timer1.Start();
            sec = 59;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                this.timer1.Stop();
                this.ParentForm.Close();
            }
            this.label1.Text = sec.ToString();
            sec = sec - 1;
        }
    }
}
