using AutoServiceSDK.SDK;
using AutoServiceSDK.SdkData;
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
    public partial class FrmWaitCard : Form
    {
        private IDCardInfo idinfo = null;
        int sec = 15;
        public FrmWaitCard()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "DEMO" || Settings.Default.运行模式 == "TEST")
            {
                sec = 2;
            }

            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
                {
                    if (sec == 0)
                    {
                        this.timer1.Stop();
                        this.DialogResult = DialogResult.Cancel;
                    }
                    sec = sec - 1;
                    if (idinfo != null)
                    {
                        FrmMain.userInfo = idinfo;
                        if (FrmMain.userInfo != null)
                        {
                            timer1.Stop();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    if (sec == 0)
                    {
                        idinfo = new IDCardInfo();
                        idinfo.Name = "李某某";

                        idinfo.Address = "西安";
                        idinfo.Sex = "男";
                        idinfo.Birthday = "1983-12-03";
                        idinfo.Signdate = "2050-01-01";
                        idinfo.Number = "123456789";
                        idinfo.People = "汗";
                        idinfo.ValidDate = "2050-01-01";
                        FrmMain.userInfo = idinfo;
                        this.timer1.Stop();
                        this.DialogResult = DialogResult.OK;
                    }
                    sec = sec - 1;
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MyMsg.MsgInfo(ex.Message);

            }
        }

        private void FrmWaitCard_Load(object sender, EventArgs e)
        {
            if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
            {
                //读取二代身份证信息  
                ReadIDCardSS.Instance.OnReadedInfo += new EventHandler<ReadEventArgs>(readIDCrad_OnReadedInfo);
                ReadIDCardSS.Instance.OnReadError += new EventHandler<ReadErrorEventArgs>(readIDCrad_OnReadError);
                if (!ReadIDCardSS.Instance.IsRun)
                {
                    ReadIDCardSS.Instance.Start(ReadType.读基本信息);
                }
            }
        }

        private void FrmWaitCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.运行模式 == "RUN" || Settings.Default.运行模式 == "TEST")
            {
                ReadIDCardSS.Instance.OnReadedInfo -= readIDCrad_OnReadedInfo;
                ReadIDCardSS.Instance.OnReadError -= readIDCrad_OnReadError;
                if (!ReadIDCardSS.Instance.IsRegister)
                {
                    ReadIDCardSS.Instance.Over();
                }
            }
        }

        private void readIDCrad_OnReadedInfo(object sender, ReadEventArgs e)
        {
            idinfo = new IDCardInfo();
            idinfo.Name = e.NewHuman.Name;

            idinfo.Address = e.NewHuman.Address;
            idinfo.Sex = e.NewHuman.Gender;
            idinfo.Birthday = e.NewHuman.BirthDay.ToString("yyyy-MM-dd");
            idinfo.Signdate = e.NewHuman.InceptDate;
            idinfo.Number = e.NewHuman.IDCardNo;
            idinfo.Name = e.NewHuman.Name;
            idinfo.People = e.NewHuman.Nation;
            idinfo.ValidDate = e.NewHuman.ExpireDate;
        }

        private void readIDCrad_OnReadError(object sender, ReadErrorEventArgs e)
        {
            MyMsg.MsgInfo(e.Error);
            this.DialogResult = DialogResult.Cancel;
            

        }
    }
}
