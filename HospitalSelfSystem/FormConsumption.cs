using AutoRegisterManager;
using AutoRegisterManager.SdkService;
using HospitalSelfSystem.Properties;
using Skynet.LoggingService;
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
    public partial class FormConsumption : Form
    {
        private int times = 0;
        MyAlert m = new MyAlert();
        M100ReadCard m100ReadCard = new M100ReadCard();
        M100ICReadCard m100ICReadCard = new M100ICReadCard();
        private int state = 0;

        public FormConsumption()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }

            timer2.Start();
        }

        private void FormConsumption_Load(object sender, EventArgs e)
        {
            FrmMain.cardData = new DataSet();
            FrmMain.cardBlance = 0;
            timer1.Start();
        }

        private void p1M_Click(object sender, EventArgs e)
        {
            FrmCardConsumeDetail frm = new FrmCardConsumeDetail();
            frm.month = 1;
            frm.ShowDialog();
        }

        private void p2M_Click(object sender, EventArgs e)
        {
            FrmCardConsumeDetail frm = new FrmCardConsumeDetail();
            frm.month = 2;
            frm.ShowDialog();
        }

        private void p3M_Click(object sender, EventArgs e)
        {
            FrmCardConsumeDetail frm = new FrmCardConsumeDetail();
            frm.month = 3;
            frm.ShowDialog();
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.Close();
        }

        private void FormConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Settings.Default.运行模式 == "RUN")
            {
                try
                {
                    string cardid = string.Empty;
                    string cardType = Settings.Default.卡类型;
                    if (cardType == "磁条卡")
                    {
                        cardid = m100ReadCard.ReadCard();
                    }
                    else if (cardType == "IC卡")
                    {
                        cardid = m100ICReadCard.ReadCard();
                    }

                    if (cardid == string.Empty)
                    {
                        throw new Exception("异常卡片！");
                    }

                    FrmMain.cardInfoStruct.CardNo = cardid;

                    LogService.GlobalInfoMessage("查询卡信息");
                    SkyComm skyComm = new SkyComm();
                    FrmMain.parInfo = skyComm.QueryCardInfo(FrmMain.cardInfoStruct.CardNo);
                    if (FrmMain.parInfo.Tables.Count > 0 && FrmMain.parInfo.Tables[0].Rows.Count > 0)
                    {
                        FrmMain.cardBlance = Convert.ToDecimal(FrmMain.parInfo.Tables[0].Rows[0]["卡余额"]);
                    }
                    else
                    {
                        throw new Exception("没有此卡信息！");
                    }
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            
            }
            else
            {
                if (Settings.Default.运行模式 == "TEST")
                {
                    string cardid = string.Empty;
                    string cardType = Settings.Default.卡类型;
                    if (cardType == "磁条卡")
                    {
                        cardid = m100ReadCard.ReadCard();
                    }
                    else if (cardType == "IC卡")
                    {
                        cardid = m100ICReadCard.ReadCard();
                    }
                }

                FrmMain.cardInfoStruct.CardNo = "123456789";

                DataTable dtParInfo = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "卡号";
                dc.DataType = typeof(System.String);
                dtParInfo.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "姓名";
                dc.DataType = typeof(System.String);
                dtParInfo.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "性别";
                dc.DataType = typeof(System.String);
                dtParInfo.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "出生日期";
                dc.DataType = typeof(System.DateTime);
                dtParInfo.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "身份证号";
                dc.DataType = typeof(System.String);
                dtParInfo.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "卡余额";
                dc.DataType = typeof(System.Decimal);
                dtParInfo.Columns.Add(dc);

                DataRow drNew = dtParInfo.NewRow();
                drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                drNew["姓名"] = "李某某";
                drNew["性别"] = "男";
                drNew["出生日期"] = Convert.ToDateTime("1983-12-03");
                drNew["身份证号"] = "610123456789654120";
                drNew["卡余额"] = "1000";
                dtParInfo.Rows.Add(drNew);

                FrmMain.parInfo.Tables.Add(dtParInfo);
                FrmMain.cardBlance = 1000;

                Thread.Sleep(1000);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (e.Error.Message != "异常卡片！")
                {
                    MyMsg.MsgInfo(e.Error.Message);
                }

                this.Close();
            }
            else
            {
                LableText(this.label5, FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString());
                LableText(this.label7, FrmMain.cardInfoStruct.CardNo);

                PictureBoxVisable(this.pictureBox1, true);
                LableVisable(this.label5, true);
                LableVisable(this.label6, true);
                LableVisable(this.label7, true);

                PictureBoxVisable(this.p1M, true);
                PictureBoxVisable(this.p2M, true);
                PictureBoxVisable(this.p3M, true);

                LableVisable(this.label1, true);
                LableVisable(this.label2, true);
                LableVisable(this.label3, true);


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state = 1;
                backgroundWorker1.RunWorkerAsync();
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
                this.Invoke(de, lv, isvisable);
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

        private delegate void DPictureBoxVisable(PictureBox lv, bool isvisable);
        void PictureBoxVisable(PictureBox lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
                lv.Visible = isvisable;
            }
            else
            {
                DPictureBoxVisable de = PictureBoxVisable;
                this.Invoke(de, lv, isvisable);
            }
        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            times++;
            if (times == 15)
            {
                timer2.Stop();
                this.Close();
            }
        }
    }
}
