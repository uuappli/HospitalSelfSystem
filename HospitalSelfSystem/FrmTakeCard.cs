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
    public partial class FrmTakeCard : Form
    {
        private int times = 0;
        public FrmTakeCard()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }

            timer1.Start();
        }

        private void FrmTakeCard_Load(object sender, EventArgs e)
        {

        }

        private void pReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pDJFK_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FrmWaitCard frm = new FrmWaitCard();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (Settings.Default.运行模式 == "RUN")
                {
                    SkyComm skyComm = new SkyComm();
                    FrmMain.parInfo = skyComm.QueryCardInfoBySID(FrmMain.userInfo.Number);
                    if (FrmMain.parInfo.Tables.Count > 0 && FrmMain.parInfo.Tables[0].Rows.Count > 0)
                    {
                        MyMsg.MsgInfo("该身份证已经办理过诊疗卡，不能重复办卡!");
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void pExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            times++;
            if(times == 15)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
