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
    public partial class FrmCardConsumeDetail : Form
    {
        /// <summary>
        /// 查询月数
        /// </summary>
        public int month = 0;

        public FrmCardConsumeDetail()
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

        private void FrmCardConsumeDetail_Load(object sender, EventArgs e)
        {
            lbXm.Text = FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString();
            lbKh.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString();
            lbYe.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡余额"].ToString();

            try
            {
                DataSet dsConsumeDetail = new DataSet();
                if (Settings.Default.运行模式 == "RUN")
                {
                    LogService.GlobalInfoMessage("查询消费记录");
                    SkyComm skyComm = new SkyComm();
                    dsConsumeDetail = skyComm.QueryCardConsumeInfo(FrmMain.cardInfoStruct.CardNo, DateTime.Now.AddMonths(month * -1));

                    if (dsConsumeDetail.Tables.Count > 0 && dsConsumeDetail.Tables[0].Rows.Count > 0)
                    {
                        lbZHF.Text = Convert.ToDecimal(dsConsumeDetail.Tables[0].Compute("SUM(金额)", "")).ToString("0.00");
                    }
                    else
                    {
                        lbZHF.Text = "0.00";
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "卡号";
                    dc.DataType = typeof(System.String);
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "收费项目名称";
                    dc.DataType = typeof(System.String);
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "单价";
                    dc.DataType = typeof(System.Decimal);
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "数量";
                    dc.DataType = typeof(System.Decimal);
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "金额";
                    dc.DataType = typeof(System.Decimal);
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "消费日期";
                    dc.DataType = typeof(System.DateTime);
                    dt.Columns.Add(dc);

                    DataRow drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = "西药费";
                    drNew["单价"] = 10;
                    drNew["数量"] = 10;
                    drNew["金额"] = 100;
                    drNew["消费日期"] = Convert.ToDateTime("2013-06-01");
                    dt.Rows.Add(drNew);

                    drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = "中成药";
                    drNew["单价"] = 5;
                    drNew["数量"] = 10;
                    drNew["金额"] = 50;
                    drNew["消费日期"] = Convert.ToDateTime("2013-06-2");
                    dt.Rows.Add(drNew);
                    
                    drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = " CT费";
                    drNew["单价"] = 500;
                    drNew["数量"] = 1;
                    drNew["金额"] = 500;
                    drNew["消费日期"] = Convert.ToDateTime("2013-05-1");
                    dt.Rows.Add(drNew);

                    drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = "血常规";
                    drNew["单价"] = 20;
                    drNew["数量"] = 1;
                    drNew["金额"] = 20;
                    drNew["消费日期"] = Convert.ToDateTime("2013-05-2");
                    dt.Rows.Add(drNew);

                    drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = " 核磁共振";
                    drNew["单价"] = 500;
                    drNew["数量"] = 1;
                    drNew["金额"] = 500;
                    drNew["消费日期"] = Convert.ToDateTime("2013-04-1");
                    dt.Rows.Add(drNew);

                    drNew = dt.NewRow();
                    drNew["卡号"] = FrmMain.cardInfoStruct.CardNo;
                    drNew["收费项目名称"] = "手术费";
                    drNew["单价"] = 1000;
                    drNew["数量"] = 1;
                    drNew["金额"] = 1000;
                    drNew["消费日期"] = Convert.ToDateTime("2013-04-2");
                    dt.Rows.Add(drNew);
                    dsConsumeDetail.Tables.Add(dt);
                }

                DataView dv = dsConsumeDetail.Tables[0].DefaultView;
                //dv.RowFilter = "消费日期 >= '" + DateTime.Now.AddMonths(month * -1).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                gridControl1.DataSource = dv;
            }
            catch (Exception err)
            {
                MyMsg.MsgInfo(err.Message);
            }
        }    
    }
}
