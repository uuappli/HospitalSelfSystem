using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using AutoRegisterManager.SdkService;
using HospitalSelfSystem;

namespace AutoRegisterManager
{
    public partial class MyAlert : Form
    {
        //FrmReadCard fr = new FrmReadCard();
        public string alerttype = string.Empty;
        public int PtMoney = 0;//普通号
        public int ZjMoney = 0;//专家号
        public string OfficeName = "";
        public string Msg = "";
        public int RegRs = 0;//挂号选择返回值 0，关闭 1，普通号，2，专家号
        public decimal sumChargeMoney = 0;
        
        public MyAlert()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (alerttype == "开始充值")
            {
                AddMoney();
            }
            else if (alerttype == "选择挂号")
            {
                //FrmRegSelect frm = new FrmRegSelect();
                //frm.icMsg1.timer1.Start();
                //frm.TopMost = true;
                //frm.lblOffice.Text  = OfficeName;
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    RegRs = frm.resutType;
                //    CloseWin(this,true );
                //    frm.icMsg1.timer1.Stop();
                //}
            }
            else if (alerttype == "确认取消")
            {
                FrmYesNoAlert frm = new FrmYesNoAlert();
                frm.TopMost = true;
                frm.lblMsg.Text = Msg;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    CloseWin(this, true);
                }
                else
                {
                    CloseWin(this, false);
                }
            }
            else if (alerttype == "信息")
            {
                //FrmInfoAlert frm = new FrmInfoAlert();
                //frm.TopMost = true;
               
                //frm.lblMsg.Text = Msg;
                //frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                //    CloseWin(this, true);
                //}

            }
        }
        //充值
        private void AddMoney()
        {
            FrmInMoney frm = new FrmInMoney();
            frm.icMsg1.timer1.Start();
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                frm.icMsg1.timer1.Stop();

                #region 打印小票模块

                Print cp = new Print();
                cp.PrintReport(frm.Sum.ToString(), frm.RcptNo);

                //PrintReport(frm.Sum.ToString(), frm.RcptNo);
                #endregion

                FrmInMoneyMsg fmm = new FrmInMoneyMsg();
                if (fmm.ShowDialog() == DialogResult.OK)
                {
                    this.AddMoney();

                }
                else
                {
                    CloseWin(this, true);
                }

            }
            else
            {
                CloseWin(this, false);
                frm.icMsg1.timer1.Stop();
            }
        }

       

        /// <summary>
        /// 打印自助充值
        /// </summary>
        private void PrintReport(string sum, string rcptNo)
        {
            string path = Application.StartupPath + @"\\Reports\\自助充值.rmf";

            if (System.IO.File.Exists(path) == false)
            {
                //MyMsg.MsgInfo("自助充值票据不存在,请联系管理员!");
                return;
            }

            //引用 RM.ReportEngine.dll
            RMReportEngine.RMReport rmReport1 = new RMReportEngine.RMReport();

            //FrmMain frm = new FrmMain();
            rmReport1.Init(this, RMReportEngine.RMReportType.rmrtReport);
            rmReport1.AddVariable("充值时间", DateTime.Now.ToShortDateString(), true);
            rmReport1.AddVariable("卡号", FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString(), true);
            rmReport1.AddVariable("姓名", FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString(), true);
            rmReport1.AddVariable("充值金额", sum, true);
            rmReport1.AddVariable("卡余额", FrmMain.cardBlance.ToString(), true);
            rmReport1.AddVariable("流水号", rcptNo, true);

            rmReport1.LoadFromFile(path);

            rmReport1.ShowPrintDialog = false;
            rmReport1.ShowProgress = false;
            rmReport1.ThreadPrepareReport = false;
            //rmReport1.ShowReport();
            rmReport1.PrintReport();
            rmReport1.Destroy();
        }

        private delegate void DeCloseWin(Form lv,bool isok);
        //提示信息
        void CloseWin(Form lv,bool  isok)
        {
            if (!lv.InvokeRequired)
            {
                if (isok)
                {
                    lv.DialogResult = DialogResult.OK;
                }
                else
                {
                    lv.DialogResult = DialogResult.Cancel;
                }
                
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeCloseWin de = CloseWin;
                this.Invoke(de, lv);
            }
        }

        private void MyAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alerttype == "WaitReadCard")
            {
                //fr.icMsg1.timer1.Stop();
                //fr.Close();
            }
        }

        private void MyAlert_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
