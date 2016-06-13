using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skynet.Framework.Common;
using Skynet.ExceptionManagement;
using HospitalSelfSystem;
using AutoRegisterManager.SdkService;
using HospitalSelfSystem.Properties;
using Skynet.LoggingService;

namespace AutoRegisterManager.Inc
{
    public partial class DoctorList : UserControl
    {
        private DataTable dtDoctor = new DataTable();
        DataTable dt = new DataTable();//显示医生数据源
        private bool isZJ = false;//是否是专家
        public string officeName = string.Empty;
        public string officeID = string.Empty;
        private int startIndex=0;
        //专家列表
        public DataTable DtDoctor
        {
            get { return dtDoctor; }
            set { dtDoctor = value; }
        }

        public DoctorList()
        {
            InitializeComponent();
            startIndex = 0;
           
        }

        //数据绑定
        public void DataBind(bool iszhuanjia)
        {
            this.isZJ = iszhuanjia;

            DataSet dsPlusFee = new DataSet();
          
            dt = DtDoctor.Clone();
            dt.Clear();

            for (int i = 0; i < 3; i++)
            {
                if (startIndex > DtDoctor.Rows.Count - 1)
                {
                    startIndex++;
                    continue;
                }
                
                dt.ImportRow(DtDoctor.Rows[startIndex]);
                startIndex++;
            }
            this.lblName.Text = dt.Rows[0]["医生姓名"] == null ? "无" : dt.Rows[0]["医生姓名"].ToString();
            this.lblzhicheng.Text = dt.Rows[0]["职称"] == null ? "无" : dt.Rows[0]["职称"].ToString();
            this.progressBar1.Maximum = (dt.Rows[0]["挂号限数"] == null || dt.Rows[0]["挂号限数"].ToString().Length <= 0) ? 0 : Convert.ToInt32(dt.Rows[0]["挂号限数"]);
            this.progressBar1.Value = dt.Rows[0]["已挂号数"] == null ? 0 : Convert.ToInt32(dt.Rows[0]["已挂号数"]);
            this.lblNum.Text = (progressBar1.Maximum - progressBar1.Value).ToString();
            this.lblGhMoney.Text = dt.Rows[0]["挂号金额"] == null ? "无" : dt.Rows[0]["挂号金额"].ToString();
            this.lblRegister.Enabled = this.isvisable(progressBar1);
            if (dt.Rows.Count >= 2)
            {
                panel3.Visible = true;
                this.lblname2.Text = dt.Rows[1]["医生姓名"] == null ? "无" : dt.Rows[1]["医生姓名"].ToString();
                this.lblzhicheng2.Text = dt.Rows[1]["职称"] == null ? "无" : dt.Rows[1]["职称"].ToString();
                this.progressBar2.Maximum = dt.Rows[1]["挂号限数"] == null ? 0 : Convert.ToInt32(dt.Rows[1]["挂号限数"]);
                this.progressBar2.Value = dt.Rows[1]["已挂号数"] == null ? 0 : Convert.ToInt32(dt.Rows[1]["已挂号数"]);
                this.lblnum2.Text = (progressBar2.Maximum - progressBar2.Value).ToString();
                this.lblGhMoney2.Text = dt.Rows[1]["挂号金额"] == null ? "无" : dt.Rows[1]["挂号金额"].ToString();
                this.lblRegister2.Enabled = this.isvisable(progressBar2);
            }
            else
            {
                panel3.Visible = false;
            }
            if (dt.Rows.Count >= 3)
            {
                panel4.Visible = true;
                this.lblname3.Text = dt.Rows[2]["医生姓名"] == null ? "无" : dt.Rows[2]["医生姓名"].ToString();
                this.lblzhicheng3.Text = dt.Rows[2]["职称"] == null ? "无" : dt.Rows[2]["职称"].ToString();
                this.progressBar3.Maximum = dt.Rows[2]["挂号限数"] == null ? 0 : Convert.ToInt32(dt.Rows[2]["挂号限数"]);
                this.progressBar3.Value = dt.Rows[2]["已挂号数"] == null ? 0 : Convert.ToInt32(dt.Rows[2]["已挂号数"]);
                this.lblnum3.Text = (progressBar3.Maximum - progressBar3.Value).ToString();
                this.lblGhMoney3.Text = dt.Rows[2]["挂号金额"] == null ? "无" : dt.Rows[2]["挂号金额"].ToString();
                this.lblRegister3.Enabled = this.isvisable(progressBar3);
            }
            else
            {
                panel4.Visible = false;
            }
            if (startIndex % 3 > 0)
            {
                this.lblNowPage.Text = String.Format("第{0}页", (startIndex / 3) + 1);
            }
            else
            {
                this.lblNowPage.Text = String.Format("第{0}页", startIndex / 3);
            }
            if (DtDoctor.Rows.Count % 3 > 0)
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", (DtDoctor.Rows.Count / 3) + 1);
            }
            else
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", DtDoctor.Rows.Count / 3);
            }

        }
       public bool isvisable(BSE.Windows .Forms .ProgressBar p)
       {
           if (p.Maximum <= p.Value)
           {
               return false;
           }
           return true;
       }
       private void btnNextPage_Click(object sender, EventArgs e)
       {
           if (startIndex > DtDoctor.Rows.Count - 1)
           {
               MyMsg.MsgInfo("已经是最后一页了！");
               return;
           }
           DataBind(isZJ);
       }

       private void btnBeforePage_Click(object sender, EventArgs e)
       {
           if (startIndex -6 < 0)
           {
               MyMsg.MsgInfo("已经是第一页了！");
               return;
           }
           startIndex = startIndex - 6;
           DataBind(isZJ);
       }
        //挂号一
       private void lblRegister_Click(object sender, EventArgs e)
       {
           
           MyAlert m = new MyAlert();
           m.alerttype = "确认取消";
           m.Msg = "您确认要挂此" + (isZJ ? "门诊专家" : "门诊普通") + "号吗？";
           if (m.ShowDialog() == DialogResult.Cancel)
           {
               return ;
           }
           backgroundWorker2.RunWorkerAsync(1);
           //this.ParentForm.Close();
       }
       //挂号二
       private void lblRegister2_Click(object sender, EventArgs e)
       {
          
           MyAlert m = new MyAlert();
           m.alerttype = "确认取消";
           m.Msg = "您确认要挂此" + (isZJ ? "门诊专家" : "门诊普通") + "号吗？";
           if (m.ShowDialog() == DialogResult.Cancel)
           {
               return;
           }
           backgroundWorker2.RunWorkerAsync(2);
           //this.ParentForm.Close();
       }
       //挂号三
       private void lblRegister3_Click(object sender, EventArgs e)
       {
         
           MyAlert m = new MyAlert();
           m.alerttype = "确认取消";
           m.Msg = "您确认要挂此" + (isZJ ? "门诊专家" : "门诊普通") + "号吗？";
           if (m.ShowDialog() == DialogResult.Cancel)
           {
               return;
           }
           backgroundWorker2.RunWorkerAsync(3);
           //this.ParentForm.Close();
       }

        //专家介绍一
       private void lblIntroduction_MouseClick(object sender, MouseEventArgs e)
       {
           Label lb=sender as Label ;
           FrmCommData fc = new FrmCommData();
           fc.lblName.Text = dt.Rows[0]["医生姓名"].ToString();
           Point p = lb.PointToScreen(e.Location);
           fc.Location = new Point(p.X, p.Y - fc.Height);
           fc.ShowDialog();
       }
        //专家介绍二
       private void lblIntroduction2_MouseClick(object sender, MouseEventArgs e)
       {
           Label lb = sender as Label;
           FrmCommData fc = new FrmCommData();
           fc.lblName.Text = dt.Rows[1]["医生姓名"].ToString();
           Point p = lb.PointToScreen(e.Location);
           fc.Location = new Point(p.X, p.Y - fc.Height);
           fc.ShowDialog();
       }
       //专家介绍二
       private void lblIntroduction3_MouseClick(object sender, MouseEventArgs e)
       {
           Label lb = sender as Label;
           FrmCommData fc = new FrmCommData();
           fc.lblName.Text = dt.Rows[1]["医生姓名"].ToString();
           Point p = lb.PointToScreen(e.Location);
           fc.Location = new Point(p.X-fc.Width, p.Y - fc.Height);
           fc.ShowDialog();
       }

       private void DoctorList_Load(object sender, EventArgs e)
       {
           startIndex = 0;
       }
       //挂号
       public bool Register(int dataindex, bool iszhuanjia)//挂号（专家）
       {
           try
           {
               if (Settings.Default.运行模式 == "RUN")
               {
                   LogService.GlobalInfoMessage("调用挂号存储过程");
                   SkyComm skyComm = new SkyComm();
                   skyComm.Register(FrmMain.cardInfoStruct.CardNo, officeID, dt.Rows[dataindex - 1]["医生编号"].ToString(), Convert.ToDecimal(dt.Rows[dataindex - 1]["挂号金额"]));
               }

               MyMsg.MsgInfo("恭喜您已挂号成功，请取走您的就诊卡！");

               #region 打印

               //Print cp = new Print();
               //cp.PrintRegister("李新华");
               #endregion

           }
           catch (Exception ex)
           {

               SkynetMessage.MsgInfo(ex.Message);
               return false;
           }

           return true;

       }

       /// <summary>
       /// 得到服务器时间
       /// </summary>
       /// <returns></returns>
       private DateTime GetServerDateTime()
       {
           return DateTime.Now;
       }

        //异步挂号
       private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
       {
           this.guahaoVisable(false);
           if (e.Argument.Equals(1))
           {
               this.LableVisable(lblmsg1, true );
           }
           else if (e.Argument.Equals(2))
           {
               this.LableVisable(lblmsg2, true);
           }
           else if (e.Argument.Equals(3))
           {
               this.LableVisable(lblmsg3, true);
           }
           try
           {
               Register(Convert.ToInt32(e.Argument), isZJ);
           }
           catch (Exception err)
           {
               throw new Exception(err.Message);
           }
       }

       private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
           if (e.Error != null)
           {
               MyMsg.MsgInfo(e.Error.Message);
               this.ParentForm.DialogResult = DialogResult.Cancel;
           }
           else
           {
               this.guahaoVisable(false);
               this.LableVisable(lblmsg1, false);
               this.LableVisable(lblmsg2, false);
               this.LableVisable(lblmsg3, false);
               this.ParentForm.DialogResult = DialogResult.OK;
           }

       }
       private void guahaoVisable(bool isvisable)
       {
           this.LableEnable(lblRegister, isvisable);
           this.LableEnable(lblRegister2, isvisable);
           this.LableEnable(lblRegister3, isvisable);
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
       //Lable Text 设置
       private delegate void DLableText(Label lv, string text);
       void LableText(Label lv, string text)
       {
           if (!lv.InvokeRequired)
           {
               lv.Text = text;
           }
           else
           {
               DLableVisable de = LableVisable;
               this.Invoke(de, lv, text);
           }
       }
       #endregion
    }
}
