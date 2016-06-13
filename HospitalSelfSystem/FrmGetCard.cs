using HospitalSelfSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HospitalSelfSystem
{   
    public partial class FrmGetCard : Form
    {
        private int times = 0;
        public FrmGetCard()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }

            timer1.Start();
        }

        private void FrmGetCard_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            this.lblage.Text = SkyComm.getage(FrmMain.userInfo.Birthday);
            this.lblCardNo.Text = FrmMain.userInfo.Number;
            this.lblName.Text = FrmMain.userInfo.Name;
            this.lblSex.Text = FrmMain.userInfo.Sex;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pExit.Enabled = false;
            while (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(100);
            }
            backgroundWorker1.RunWorkerAsync();

            //FrmWarn frm = new FrmWarn();
            //frm.lblMsg.Text = "发卡成功!";
            //frm.ShowDialog();
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
                {
                    Msgvisable(this.lblMsg, true);
                    PutCardUniversal pc = new PutCardUniversal();
                    int i = pc.OutCard(0, 0, FrmMain.userInfo, 0);
                    if (i == -1)
                    {
                        throw new Exception("发卡失败!");
                    }
                }
                else
                {
                    Msgvisable(this.lblMsg, true);
                    FrmWarn frm = new FrmWarn();
                    frm.lblMsg.Text = "发卡成功!";
                    frm.ShowDialog();
                }
            }catch(Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MyMsg.MsgInfo(e.Error.Message);
                this.Close();
            }
            else
            {
                Msgvisable(this.lblMsg, false);
                this.DialogResult = DialogResult.OK;
            }
        }

        #region 线程提示区
        private delegate void Demsgvisable(Label lv, bool isvisable);
        //提示信息
        void Msgvisable(Label lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
                pictureBox1.Enabled = !isvisable;
                lv.Visible = isvisable;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                Demsgvisable de = Msgvisable;
                this.Invoke(de, lv, isvisable);
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            times++;
            if (times == 15)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
