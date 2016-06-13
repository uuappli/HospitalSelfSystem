using AutoRegisterManager.SdkService;
using HospitalSelfSystem.Properties;
using Skynet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalSelfSystem
{
    public partial class FrmBackstageManage : Form
    {
        public FrmBackstageManage()
        {
            InitializeComponent();
        }

        private void FrmBackstageManage_Load(object sender, EventArgs e)
        {
            try
            {
                pFK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                pCX.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                pSFZ.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                pZL.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);

                cboDBType.Text = Settings.Default.数据库类型;
                txtDBName.Text = Settings.Default.数据库名称;
                txtDBUser.Text = Settings.Default.用户名;
                txtDBPassword.Text = Settings.Default.密码;
                txtDBIP.Text = Settings.Default.数据库IP;

                cboFKPort.Text = Settings.Default.发卡器端口;
                cboDKPort.Text = Settings.Default.读卡器端口;
                cboCXPort.Text = Settings.Default.钞箱端口;
                cboCardType.Text = Settings.Default.卡类型;

                txtHosName.Text = Settings.Default.医院名称;

                if (Settings.Default.运行模式 == "DEMO")
                {
                    cboYxms.Text = "演示运行";
                }
                else if (Settings.Default.运行模式 == "RUN")
                {
                    cboYxms.Text = "正式运行";
                }
                else
                {
                    cboYxms.Text = "硬件演示";
                }

                txtSysPass.Text = Settings.Default.系统管理密码;

              
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            try
            {
                pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\" + Settings.Default.医院LOGO, false);
            }
            catch
            {
                pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\默认logo.png", false);
            }
        }

        private void btnTestDrive_Click(object sender, EventArgs e)
        {
            try
            {
                K101SendCard k101SendCard = new K101SendCard();
                IntPtr hadler = k101SendCard.Init();
                if (hadler.ToInt32() == 0)
                {
                    pFK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                }
                else
                {
                    pFK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\勾.png", false);
                }

                k101SendCard.ClosePort(hadler);
            }
            catch
            {
                pFK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
            }

            try
            {
                string cardType = Settings.Default.卡类型;

                if (cardType == "磁条卡")
                {
                    M100ReadCard m100ReadCard = new M100ReadCard();
                    string port = Settings.Default.读卡器端口;
                    int hadler = m100ReadCard.Init(Convert.ToInt32(port) - 1);
                    if (hadler != 0)
                    {
                        pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                    }
                    else
                    {
                        pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\勾.png", false);
                    }
                }
                else if (cardType == "IC卡")
                {
                    M100ICReadCard m100ICReadCard = new M100ICReadCard();
                    string port = Settings.Default.读卡器端口;
                    IntPtr hadler = m100ICReadCard.Init(Convert.ToInt32(port));
                    if (hadler.ToInt32() == 0)
                    {
                        pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
                    }
                    else
                    {
                        pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\勾.png", false);
                    }

                    m100ICReadCard.ClosePort(hadler);
                }
            }
            catch
            {
                pDK.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
            }

            try
            {
                Money money = new Money();
                string port = Settings.Default.钞箱端口;
                money.init(Convert.ToInt32(port), 3);
                money.CloseInit();
                pCX.Image = Image.FromFile(Application.StartupPath + @"\\Image\\勾.png", false);
            }
            catch 
            {
                pCX.Image = Image.FromFile(Application.StartupPath + @"\\Image\\叉.png", false);
            }


            pSFZ.Image = Image.FromFile(Application.StartupPath + @"\\Image\\勾.png", false);
        }

        private void btnHISSetting_Click(object sender, EventArgs e)
        {
            Settings.Default.数据库类型 = cboDBType.Text;
            Settings.Default.数据库名称 = txtDBName.Text;
            Settings.Default.用户名 = txtDBUser.Text;
            Settings.Default.密码 = txtDBPassword.Text;
            Settings.Default.数据库IP = txtDBIP.Text;

            Settings.Default.Save();
            MessageBox.Show("保存成功!");
        }

        private void btnDriveSetting_Click(object sender, EventArgs e)
        {
            Settings.Default.发卡器端口 = cboFKPort.Text;
            Settings.Default.读卡器端口 = cboDKPort.Text;
            Settings.Default.钞箱端口 = cboCXPort.Text;
            Settings.Default.卡类型 = cboCardType.Text;

            Settings.Default.Save();
            MessageBox.Show("保存成功!");
        }

        private void btnSysSetting_Click(object sender, EventArgs e)
        {
            Settings.Default.医院名称 = txtHosName.Text;

            if (cboYxms.Text == "演示运行")
            {
                Settings.Default.运行模式 = "DEMO";
            }
            else if (cboYxms.Text == "正式运行")
            {
                Settings.Default.运行模式 = "RUN";
            }
            else
            {
                Settings.Default.运行模式 = "TEST";
            }

            Settings.Default.系统管理密码 = txtSysPass.Text;

            Settings.Default.Save();
            MessageBox.Show("保存成功!");
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            DatabaseType type = (DatabaseType)Enum.Parse(typeof(DatabaseType), this.cboDBType.Text);
            if (IsTestOK(ConnString, type))
            {
                MessageBox.Show("连接成功");
            }
        }

        public string ConnString
        {
            get
            {

                if (cboDBType.Text == DatabaseType.Oracle.ToString())
                {

                    return string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={3})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={0})));User Id={1};Password={2};Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Timeout=60;Connection Lifetime=0;Persist Security Info=true ",
                        txtDBName.Text, txtDBUser.Text, txtDBPassword.Text, txtDBIP.Text);

                }
                else if (cboDBType.Text == DatabaseType.DB2.ToString())
                {
                    string format = "Database={0};user id={1};password={2};server={3}";
                    return string.Format(format, txtDBName.Text, txtDBUser.Text, txtDBPassword.Text, txtDBIP.Text);
                }
                else
                {
                    string format = "Data Source={0};Initial Catalog={1};User Id={2};Password={3}";
                    return string.Format(format, txtDBIP.Text,txtDBName.Text, txtDBUser.Text, txtDBPassword.Text);
                }
            }
        }

        public static bool IsTestOK(string conn, DatabaseType dbtype)
        {
            try
            {
                if (dbtype == DatabaseType.MSSQLServer)
                {
                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    sqlconn.Close();
                    return true;
                }
                else
                {
                    PersistenceProperty.ConnectionString = conn;
                    PersistenceProperty.DatabaseType = dbtype;
                    IDataAccess data = DataAccessFactory.instance.CreateDataAccess();

                    data.Open();
                    data.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("连接失败:{0}", ex.Message));
                return false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "PNG文件(*.png)|*.png";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string sourcePath = openFileDialog1.FileName;
                    string targetPath = Application.StartupPath + @"\\Image\\" + openFileDialog1.SafeFileName;
                    System.IO.File.Copy(sourcePath, targetPath, true);

                    Settings.Default.医院LOGO = openFileDialog1.SafeFileName;

                    try
                    {
                        pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\" + Settings.Default.医院LOGO, false);
                    }
                    catch
                    {
                        pLogo.Image = Image.FromFile(Application.StartupPath + @"\\Image\\默认logo.png", false);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
