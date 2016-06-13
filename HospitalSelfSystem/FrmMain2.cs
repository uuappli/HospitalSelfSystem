using AutoRegisterManager;
using AutoServiceSDK.SdkData;
using CardInterface;
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
    public partial class FrmMain2 : Form
    {
        public static DataSet parInfo = new DataSet();
        public static CardInformationStruct cardInfoStruct = new CardInformationStruct();
        public static DataSet cardData = new DataSet();
        public static DataSet doctorData = new DataSet();
        public static DataSet RegType = new DataSet();
        public static IDCardInfo userInfo = new IDCardInfo();
        public static Decimal cardBlance = 0;
        private int setting = 0;

        public FrmMain2()
        {
            InitializeComponent();

            if (Settings.Default.运行模式 == "RUN")
            {
                this.WindowState = FormWindowState.Maximized;
            }

            timer1.Start();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            labHosName.Text = Settings.Default.医院名称;
            try
            {
                pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\" + Settings.Default.医院LOGO, false);
            }
            catch
            {
                pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\默认logo.png", false);
            }

            SkyComm.Init();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString("HH:mm");

            setting++;
            if (setting == 5)
            {
                setting = 0;
                pSetting.Visible = false;
            }
        }

        private void pYYJS_Click(object sender, EventArgs e)
        {
            FrmHOSSummary frm = new FrmHOSSummary();
            frm.ShowDialog();
        }

        private void pZZFK_Click(object sender, EventArgs e)
        {
            FrmTakeCard frm = new FrmTakeCard();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                FrmGetCard fc = new FrmGetCard();
                fc.ShowDialog();
            }
        }

        private void pXFCX_Click(object sender, EventArgs e)
        {
            FormConsumption frm = new FormConsumption();
            frm.ShowDialog();
        }

        private void pZZCZ_Click(object sender, EventArgs e)
        {
            FrmRecharge frm = new FrmRecharge();
            frm.ShowDialog();
        }

        private void pYECX_Click(object sender, EventArgs e)
        {
            FrmBalance frm = new FrmBalance();
            frm.ShowDialog();
        }

        private void pZZGH_Click(object sender, EventArgs e)
        {
            FrmRegisterReadCard frm = new FrmRegisterReadCard();
            frm.ShowDialog();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            pSetting.Visible = true;
            setting = 0;
        }

        private void pSetting_Click(object sender, EventArgs e)
        {
            FrmPassWord frmPass = new FrmPassWord();
            frmPass.ShowDialog();
            if (frmPass.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (frmPass.passWord == Settings.Default.系统管理密码)
                {
                    FrmBackstageManage frm = new FrmBackstageManage();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FrmRecharge frm = new FrmRecharge();
            frm.ShowDialog();
        }

        private void lblFk_Click(object sender, EventArgs e)
        {
            FrmTakeCard frm = new FrmTakeCard();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                FrmGetCard fc = new FrmGetCard();
                fc.ShowDialog();
            }
        }

        private void lblguahao_Click(object sender, EventArgs e)
        {
            FrmRegisterReadCard frm = new FrmRegisterReadCard();
            frm.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FrmHOSSummary frm = new FrmHOSSummary();
            frm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormConsumption frm = new FormConsumption();
            frm.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FrmBalance frm = new FrmBalance();
            frm.ShowDialog();
        }
    }
}
