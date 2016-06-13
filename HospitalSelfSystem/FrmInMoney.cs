using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skynet.Framework.Common;
using AutoRegisterManager.SdkService;
using System.Threading;
using HospitalSelfSystem;
using HospitalSelfSystem.Properties;
using Skynet.LoggingService;
using Skynet.ExceptionManagement;

namespace AutoRegisterManager
{
    public partial class FrmInMoney : Form
    {
        public DataSet cardSavingData;
        Money money = new Money();
        private int sum = 0;//读入钱数
        private string rcptNo = string.Empty;

        public int Sum
        {
            get
            {
                return this.sum;
            }
            set
            {
                this.sum = value;
            }
        }

        public string RcptNo
        {
            get
            {
                return this.rcptNo;
            }
            set
            {
                this.rcptNo = value;
            }
        }

        public FrmInMoney()
        {
            InitializeComponent();
        }
       

        private void lblClose_Click(object sender, EventArgs e)
        {
            //this.icMsg1.timer1.Stop();
            this.timer1.Stop();

            if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
            {
                money.CloseInit();
            }
            backgroundWorker1.CancelAsync();
            this.DialogResult = DialogResult.Cancel;
        }
        //确认
        private void lblOK_Click(object sender, EventArgs e)
        {
            //MyAlert m = new MyAlert();
            //m.alerttype = "确认取消";
            //m.Msg = String.Format("本次充值金额：{0}元\n请核对您的充值金额是否正确？", sum.ToString());
            //if (m.ShowDialog() == DialogResult.Cancel)
            //{
            //    return;
            //}

            this.timer1.Stop();
            try
            {
                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                SkynetMessage.MsgInfo(ex.Message);
                return;
            }
            //调用充值业务
        }
        private void Save()
        {
            try
            {
                if (Settings.Default.运行模式 == "RUN")
                {
                    LogService.GlobalInfoMessage("调用充值存储过程");
                    SkyComm skyComm = new SkyComm();
                    skyComm.CardRecharge(FrmMain.cardInfoStruct.CardNo, Convert.ToDecimal(sum), ref rcptNo);
                    LogService.GlobalInfoMessage("完成调用充值存储过程");
                    LogService.GlobalInfoMessage("流水号 " + rcptNo);

                    DataSet parInfo = skyComm.QueryCardInfo(FrmMain.cardInfoStruct.CardNo);
                    FrmMain.cardBlance = Convert.ToDecimal(parInfo.Tables[0].Rows[0]["卡余额"]);
                }
                else
                {
                    FrmMain.cardBlance = Convert.ToDecimal(sum);
                }
            }
            catch(Exception err)
            {
                LogService.GlobalInfoMessage("充值存储过程错误" + err.Message);
                throw new LogonException(err.Message);
            }
        }

        private void FrmInMoney_Load(object sender, EventArgs e)
        {
            try
            {
                string port = Settings.Default.钞箱端口;
                cardSavingData = new DataSet();
                this.lblClose.Visible = true;
                this.lblOK.Visible = false;
                sum = 0;
                if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
                {
                    money.init(Convert.ToInt32(port), 3);
                }
                #region 纸币器开始接收纸币模块
                //打开验钞 等待纸币进入
                this.timer1.Start();
            }
            catch (Exception ex)
            {

                MyMsg.MsgInfo(ex.Message);
            }
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(100);
                return;
            }
            backgroundWorker1.RunWorkerAsync(); 
        }

        private void FrmInMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Stop();
            this.icMsg1.timer1.Stop();
            if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
            {
                money.CloseInit();
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LableEnable(lblOK, false);
            this.LableVisable(label2, true);
            this.Save();
          
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("捕获到" + e.Error.Message);
            }
            else
            {
                this.LableEnable(lblOK, false);
                this.LableVisable(label2, false);
                this.DialogResult = DialogResult.OK;
            }
        }


        #region 线程提示区
        private delegate void DLableEnable(Label lv, bool isenable);
        //Lable Enable设置
        void LableEnable(Label lv, bool isenable)
        {
            if (!lv.InvokeRequired)
            {
                lv.Enabled = isenable;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DLableEnable de = LableEnable;
                this.Invoke(de, lv, isenable);
            }
        }
        //Lable Visable设置
        private delegate void DLableVisable(Label lv, bool isvisable);
        void LableVisable(Label lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
                lv.Visible = isvisable;
            }
            else
            {
                DLableVisable de = LableVisable;
                this.Invoke(de,lv, isvisable);
            }
        }

        private delegate void DLableText(Label lv, string text);
        void LableText(Label lv, string text)
        {
            if (!lv.InvokeRequired)
            {
                lv.Text = text;
            }
            else
            {
                DLableText de = LableText;
                this.Invoke(de, lv, text);
            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int iMoney = 0;
            if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
            {
                iMoney = money.poll();//读取纸币面额
            }
            else
            {
                iMoney = 100;
            }

            if(iMoney >0)
            {
                sum = sum + iMoney;
                this.icMsg1.timer1.Stop();
                LableVisable(this.lblClose, false);
                LableVisable(this.lblOK, true);
                LableText(this.label1, string.Format("已读入金额：{0}元", sum));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void icMsg1_Load(object sender, EventArgs e)
        {
   
        }
    }
}
