using HospitalSelfSystem.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSelfSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMain());
            RegHelper reg = new RegHelper();
            if (reg.CheckRegInfo())
            {
                Application.Run(new FrmMain());
            }
            else
            {
                MessageBox.Show("授权到期或授权无效，请进行注册", "提示");
                if (new FrmReg().ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FrmMain());
                }
            }
        }
    }
}
