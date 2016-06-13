using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRegisterManager.SDK;
using System.Windows.Forms;
using System.Data;
using Skynet.Framework.Common;
using HospitalSelfSystem;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 热敏打印机
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class Print
    {
        /// <summary>
        /// 打印机初始化
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public bool InitPrint()
        {
            short a = DPrinter.ComInit(Convert.ToChar(4));
            if (a != 0)
            {
                return false;
            }
            short init = DPrinter.InitPrinter();
            if (init != 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="value">打印内容</param>
        /// <param name="type">打印设置</param>
        public void PrintContent(string value, int mode, char fontsize,bool  ismiddile)
        {
            
            try
            {

                DPrinter.PrintMode(mode);
                DPrinter.SetFontSize(fontsize);
                DPrinter.SetLMargin(50, 0);
                if (ismiddile)
                {
                    DPrinter.JustMode((char)1);
                }
                else
                {
                    DPrinter.JustMode((char)0);
                }
                short print = DPrinter.Sprint((char)0, (char)0, value);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 切纸
        /// </summary>
        public void cutPage()
        {
            int cut = DPrinter.CutPaper((char)1);
        }
        public void PrintReport(string sum, string rcptNo)
        {
            InitPrint();
            DPrinter.LineFeed();
            PrintContent("巩义市人民医院", 0, (char)1, true);
            PrintContent("门诊一卡通预缴款收据", 0, (char)1, true);
            PrintContent("----------------------------------------------------", 11, (char)0, false);
            PrintContent("日  期：" + DateTime.Now.ToShortDateString() + " ", 0, (char)0, false);
            PrintContent("卡  号：" + FrmMain.parInfo.Tables[0].Rows[0]["卡号"].ToString() + " ", 0, (char)0, false);
            PrintContent("今收到：" + FrmMain.parInfo.Tables[0].Rows[0]["姓名"].ToString() + " ", 0, (char)0, false);
            PrintContent("缴费类型： 门诊预交金" + " ", 0, (char)0, false);
            PrintContent("金额（人民币）：" + sum + "元 ", 0, (char)0, false);
            PrintContent("卡余额（人民币）：" + FrmMain.cardBlance.ToString() + "元 ", 0, (char)0, false);
            PrintContent("交款形式： 现金 ", 0, (char)0, false);
            PrintContent("收款员：6666 ", 0, (char)0, false);
            PrintContent("备  注： ", 0, (char)0, false);
            PrintContent("流水号：" + rcptNo + " ", 0, (char)0, false);
            PrintContent("1.请当面核对票款金额，如有疑问即时查询", 0, (char)0, false);
            PrintContent("2.请妥善保管此收据，发现差错，退款时须交验本单", 0, (char)0, false);
            PrintContent("3.此系临时收据，不做报销凭证", 0, (char)0, false);

            DPrinter.LineFeed();
            this.cutPage();
          
        }
    }
}
