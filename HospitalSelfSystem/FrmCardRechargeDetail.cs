using HospitalSelfSystem.Properties;
using Skynet.LoggingService;
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
    public partial class FrmCardRechargeDetail : Form
    {
        public FrmCardRechargeDetail()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCardRechargeDetail_Load(object sender, EventArgs e)
        {
            lbXm.Text = FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString();
            lbKh.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString();
            lbYe.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡余额"].ToString();

            if (Settings.Default.运行模式 == "RUN")
            {
                LogService.GlobalInfoMessage("查询充值记录");
                SkyComm skyComm = new SkyComm();
                DataSet dsRechargeDetail = skyComm.QueryCardRechargeDetail(FrmMain.cardInfoStruct.CardNo);
                gridControl1.DataSource = dsRechargeDetail.Tables[0];

                if(dsRechargeDetail.Tables.Count > 0 && dsRechargeDetail.Tables[0].Rows.Count > 0)
                {
                    lbZE.Text = Convert.ToDecimal(dsRechargeDetail.Tables[0].Compute("SUM(充值金额)","")).ToString("0.00");
                }
                else
                {
                    lbZE.Text = "0.00";
                }
            }
            else
            {
                DataSet dsRechargeDetail = new DataSet();
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "卡号";
                dc.DataType = typeof(System.String);
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "充值金额";
                dc.DataType = typeof(System.Decimal);
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "充值时间";
                dc.DataType = typeof(System.DateTime);
                dt.Columns.Add(dc);

                DataRow drNew = dt.NewRow();
                drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                drNew["充值金额"] = 100;
                drNew["充值时间"] = Convert.ToDateTime("2013-07-01");
                dt.Rows.Add(drNew);

                drNew = dt.NewRow();
                drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                drNew["充值金额"] = 200;
                drNew["充值时间"] = Convert.ToDateTime("2013-07-02");
                dt.Rows.Add(drNew);

                drNew = dt.NewRow();
                drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                drNew["充值金额"] = 300;
                drNew["充值时间"] = Convert.ToDateTime("2013-07-03");
                dt.Rows.Add(drNew);

                drNew = dt.NewRow();
                drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                drNew["充值金额"] = 400;
                drNew["充值时间"] = DateTime.Now;
                dt.Rows.Add(drNew);

                dsRechargeDetail.Tables.Add(dt);
                gridControl1.DataSource = dsRechargeDetail.Tables[0];
            }
        }
    }
}
