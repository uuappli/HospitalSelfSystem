using AutoRegisterManager.Inc;
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
    public partial class FrmNewOfficeList : Form
    {
        private DataTable dtOffice;
        private int startIndex = 0;
        private DataTable dtBind = new DataTable();
        private DataTable dtDoctor;


        public FrmNewOfficeList()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                LogService.GlobalInfoMessage("查询科室列表");
                this.WindowState = FormWindowState.Maximized;
                SkyComm skyComm = new SkyComm();
                dtOffice = skyComm.QueryDepartmentsInfo().Tables[0];
            }
            else
            {
                dtOffice = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "科室名称";
                dc.DataType = typeof(System.String);
                dtOffice.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "科室编号";
                dc.DataType = typeof(System.String);
                dtOffice.Columns.Add(dc);

                DataRow drNew = dtOffice.NewRow();
                drNew["科室名称"] = "外科";
                drNew["科室编号"] = "1";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "内科";
                drNew["科室编号"] = "2";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "妇科";
                drNew["科室编号"] = "3";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "产科";
                drNew["科室编号"] = "4";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "儿科";
                drNew["科室编号"] = "5";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "耳鼻喉科";
                drNew["科室编号"] = "6";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "口腔科";
                drNew["科室编号"] = "7";
                dtOffice.Rows.Add(drNew);

                drNew = dtOffice.NewRow();
                drNew["科室名称"] = "急诊科";
                drNew["科室编号"] = "8";
                dtOffice.Rows.Add(drNew);

                dtDoctor = new DataTable();
                dc = new DataColumn();
                dc.ColumnName = "医生编号";
                dc.DataType = typeof(System.String);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "医生姓名";
                dc.DataType = typeof(System.String);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "职称";
                dc.DataType = typeof(System.String);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "所属科室编号";
                dc.DataType = typeof(System.String);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "挂号金额";
                dc.DataType = typeof(System.Decimal);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "已挂号数";
                dc.DataType = typeof(System.Int32);
                dtDoctor.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "挂号限数";
                dc.DataType = typeof(System.Int32);
                dtDoctor.Columns.Add(dc);

                DataRow drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "1";
                drDoctor["医生姓名"] = "AAAA";
                drDoctor["职称"] = "aaaa";
                drDoctor["所属科室编号"] = "1";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 30;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "2";
                drDoctor["医生姓名"] = "BBBB";
                drDoctor["职称"] = "bbbb";
                drDoctor["所属科室编号"] = "1";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 20;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "3";
                drDoctor["医生姓名"] = "CCCC";
                drDoctor["职称"] = "cccc";
                drDoctor["所属科室编号"] = "1";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 40;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "4";
                drDoctor["医生姓名"] = "DDDD";
                drDoctor["职称"] = "dddd";
                drDoctor["所属科室编号"] = "1";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 50;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "2";
                drDoctor["医生姓名"] = "BBBB";
                drDoctor["职称"] = "bbbb";
                drDoctor["所属科室编号"] = "2";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 20;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "3";
                drDoctor["医生姓名"] = "CCCC";
                drDoctor["职称"] = "cccc";
                drDoctor["所属科室编号"] = "2";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 40;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "4";
                drDoctor["医生姓名"] = "DDDD";
                drDoctor["职称"] = "dddd";
                drDoctor["所属科室编号"] = "2";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 50;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "2";
                drDoctor["医生姓名"] = "BBBB";
                drDoctor["职称"] = "bbbb";
                drDoctor["所属科室编号"] = "3";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 20;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "3";
                drDoctor["医生姓名"] = "CCCC";
                drDoctor["职称"] = "cccc";
                drDoctor["所属科室编号"] = "3";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 40;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);

                drDoctor = dtDoctor.NewRow();
                drDoctor["医生编号"] = "4";
                drDoctor["医生姓名"] = "DDDD";
                drDoctor["职称"] = "dddd";
                drDoctor["所属科室编号"] = "3";
                drDoctor["挂号金额"] = 10;
                drDoctor["已挂号数"] = 50;
                drDoctor["挂号限数"] = 100;
                dtDoctor.Rows.Add(drDoctor);
            }

            startIndex = 0;
            //DataBind();
        }

        private void pExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNewOfficeList_Load(object sender, EventArgs e)
        {
            lblName.Text = FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString();
            lblAge.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString();
            lblMoney.Text = FrmMain.parInfo.Tables[0].Rows[0]["卡余额"].ToString();
            startIndex = 0;
            DataBind();
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            if (startIndex - 30 < 0)
            {
                //MyMsg.MsgInfo("已经是第一页了！");
                return;
            }
            startIndex = startIndex - 30;
            DataBind();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (startIndex > dtOffice.Rows.Count - 1)
            {
                //MyMsg.MsgInfo("已经是最后一页了！");
                return;
            }
            DataBind();
        }

        public void DataBind()
        {
            dtBind.Clear();
            dtBind = dtOffice.Clone();
            dtBind.Clear();
            for (int i = 0; i < 15; i++)
            {
                if (startIndex > dtOffice.Rows.Count - 1)
                {
                    startIndex++;
                    continue;
                }
                dtBind.ImportRow(dtOffice.Rows[startIndex]);
                startIndex++;
            }
            setValue(dtBind, this.office1, lblMsg1, 0);
            if (dtBind.Rows.Count >= 2)
            {
                SetVisable(office2, lblMsg2, true);
                setValue(dtBind, this.office2, lblMsg2, 1);
            }
            else
            {
                SetVisable(office2, lblMsg2, false);
            }
            if (dtBind.Rows.Count >= 3)
            {
                SetVisable(office3, lblMsg3, true);
                setValue(dtBind, this.office3, lblMsg3, 2);
            }
            else
            {
                SetVisable(office3, lblMsg3, false);
            }
            if (dtBind.Rows.Count >= 4)
            {
                SetVisable(office4, lblMsg4, true);
                setValue(dtBind, this.office4, lblMsg4, 3);
            }
            else
            {
                SetVisable(office4, lblMsg4, false);
            }
            if (dtBind.Rows.Count >= 5)
            {
                SetVisable(office5, lblMsg5, true);
                setValue(dtBind, this.office5, lblMsg5, 4);
            }
            else
            {
                SetVisable(office5, lblMsg5, false);
            }
            if (dtBind.Rows.Count >= 6)
            {
                SetVisable(office6, lblMsg6, true);
                setValue(dtBind, this.office6, lblMsg6, 5);
            }
            else
            {
                SetVisable(office6, lblMsg6, false);
            }
            if (dtBind.Rows.Count >= 7)
            {
                SetVisable(office7, lblMsg7, true);
                setValue(dtBind, this.office7, lblMsg7, 6);
            }
            else
            {
                SetVisable(office7, lblMsg7, false);
            }
            if (dtBind.Rows.Count >= 8)
            {
                SetVisable(office8, lblMsg8, true);
                setValue(dtBind, this.office8, lblMsg8, 7);
            }
            else
            {
                SetVisable(office8, lblMsg8, false);
            }
            if (dtBind.Rows.Count >= 9)
            {
                SetVisable(office9, lblMsg9, true);
                setValue(dtBind, this.office9, lblMsg9, 8);
            }
            else
            {
                SetVisable(office9, lblMsg9, false);
            }
            if (dtBind.Rows.Count >= 10)
            {
                SetVisable(office10, lblMsg10, true);
                setValue(dtBind, this.office10, lblMsg10, 9);
            }
            else
            {
                SetVisable(office10, lblMsg10, false);
            }
            if (dtBind.Rows.Count >= 11)
            {
                SetVisable(office11, lblMsg11, true);
                setValue(dtBind, this.office11, lblMsg11, 10);
            }
            else
            {
                SetVisable(office11, lblMsg11, false);
            }
            if (dtBind.Rows.Count >= 12)
            {
                SetVisable(office12, lblMsg12, true);
                setValue(dtBind, this.office12, lblMsg12, 11);
            }
            else
            {
                SetVisable(office12, lblMsg12, false);
            }
            if (dtBind.Rows.Count >= 13)
            {
                SetVisable(office13, lblMsg13, true);
                setValue(dtBind, this.office13, lblMsg13, 12);
            }
            else
            {
                SetVisable(office13, lblMsg13, false);
            }
            if (dtBind.Rows.Count >= 14)
            {
                SetVisable(office14, lblMsg14, true);
                setValue(dtBind, this.office14, lblMsg14, 13);
            }
            else
            {
                SetVisable(office14, lblMsg14, false);
            }
            if (dtBind.Rows.Count >= 15)
            {
                SetVisable(office15, lblMsg15, true);
                setValue(dtBind, this.office15, lblMsg15, 14);
            }
            else
            {
                SetVisable(office15, lblMsg15, false);
            }
            if (startIndex % 3 > 0)
            {
                this.lblNowPage.Text = String.Format("第{0}页", (startIndex / 15) + 1);
            }
            else
            {
                this.lblNowPage.Text = String.Format("第{0}页", startIndex / 15);
            }
            if (dtOffice.Rows.Count % 3 > 0)
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", (dtOffice.Rows.Count / 15) + 1);
            }
            else
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", dtOffice.Rows.Count / 15);
            }

        }

        //科室赋值
        private void setValue(DataTable dts, OfficeItem lb, Label lbmsg, int index)
        {
            lb.LblOffice.Text = dts.Rows[index]["科室名称"] == null ? "无" : dts.Rows[index]["科室名称"].ToString();
            lbmsg.Text = "可以挂号";
            lbmsg.ForeColor = Color.Green;
        }

        //设置科室可见性
        private void SetVisable(OfficeItem lb, Label lbmsg, bool isVisable)
        {
            lb.Visible = isVisable;
            lbmsg.Visible = isVisable;
        }

        private void office_Click(object sender, EventArgs e)
        {
            OfficeItem oi = sender as OfficeItem;
            string s = oi.Name.Substring(6);
            int OfficeIndex = Convert.ToInt32(oi.Name.Substring(6));

            if (Settings.Default.运行模式 == "RUN")
            {
                
                DataRow[] drArrayOffice = dtOffice.Select("科室名称 = '" + dtBind.Rows[OfficeIndex - 1]["科室名称"].ToString() + "'");
                LogService.GlobalInfoMessage("查询医生列表");
                SkyComm skyComm = new SkyComm();
                dtDoctor = skyComm.QueryDoctorInfo(drArrayOffice[0]["科室编号"].ToString()).Tables[0];
            }

            FrmNewDoctor frmNewDoctor = new FrmNewDoctor();
            frmNewDoctor.doctorList1.officeName = dtBind.Rows[OfficeIndex - 1]["科室名称"].ToString();
            frmNewDoctor.doctorList1.DtDoctor = dtDoctor;
            frmNewDoctor.doctorList1.DataBind(false);
            if (frmNewDoctor.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void office1_Load(object sender, EventArgs e)
        {

        }
    }
}
