using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalSelfSystem
{
    public partial class FrmHOSSummary : Form
    {
        int index = 0;
        ArrayList imageList = new ArrayList();

        public FrmHOSSummary()
        {
            InitializeComponent();
        }

        private void FrmHOSSummary_Load(object sender, EventArgs e)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(Application.StartupPath + @"\\SummaryImage");
                foreach (string f in files)
                {
                    string fileName = System.IO.Path.GetFullPath(f);
                    imageList.Add(fileName);
                }

                if (imageList.Count > 0)
                {
                    pictureBox1.Image = Image.FromFile(imageList[0].ToString(), false);
                    btnBeforePage.Enabled = false;
                }
                else
                {
                    btnBeforePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    label1.Visible = true;
                }
            }
            catch
            {
                btnBeforePage.Enabled = false;
                btnNextPage.Enabled = false;
                label1.Visible = true;
            }
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            index--;
            if (index <= 0)
            {
                btnBeforePage.Enabled = false;
                index = 0;
                pictureBox1.Image = Image.FromFile(imageList[index].ToString(), false);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(imageList[index].ToString(), false);
                btnNextPage.Enabled = true;
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            index++;
            if (index >= imageList.Count - 1)
            {
                btnNextPage.Enabled = false;
                index = imageList.Count - 1;
                pictureBox1.Image = Image.FromFile(imageList[index].ToString(), false);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(imageList[index].ToString(), false);
                btnBeforePage.Enabled = true;
            }
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
