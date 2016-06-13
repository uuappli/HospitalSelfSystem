using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AutoServiceSDK.SDK;
using AutoServiceSDK.ISdkService;
using Skynet.Framework.Common;
using System.Xml;
using Skynet.LoggingService;

namespace AutoServiceSDK.SdkService
{
    /// <summary>
    /// 热敏打印机
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class PosPrint:IPrintService
    {
        private string cardBlance;
        private string identityCardID;
        private string operatorName;
        private string serverTime;
        public PosPrint(string CardBlance, string IdentityCardID, string OperatorName,string ServerTime)
        {
            this.cardBlance = CardBlance;
            this.identityCardID = IdentityCardID;
            this.operatorName = OperatorName;
            this.serverTime = ServerTime;

        }
        public PosPrint()
        {

        }
        /// <summary>
        /// 打印机初始化
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public bool InitPrint()
        {
            short a = POS_PRINT_DLL.ComInit(Convert.ToChar(3));
            if (a != 0)
            {
                return false;
            }
            short init = POS_PRINT_DLL.InitPrinter();
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

                POS_PRINT_DLL.PrintMode(mode);
                POS_PRINT_DLL.SetFontSize(fontsize);
                POS_PRINT_DLL.SetLMargin(50, 0);
                if (ismiddile)
                {
                    POS_PRINT_DLL.JustMode((char)1);
                }
                else
                {
                    POS_PRINT_DLL.JustMode((char)0);
                }
                short print = POS_PRINT_DLL.Sprint((char)0, (char)0, value);
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
            int cut = POS_PRINT_DLL.CutPaper((char)1);
        }


        public void PrintReport(DataSet ds, string hosname, string regmoney, int titleFontsize)
        {
            // CommonFacade commonFacade = new CommonFacade();
            InitPrint();
            POS_PRINT_DLL.LineFeed();
            PrintContent(hosname, 144, (char)titleFontsize, true);
            PrintContent("----------------------------------------------------", 11, (char)0, false);

            PrintContent("姓  名：" + ds.Tables[0].Rows[0]["PATIENTNAME"].ToString() + " ", 0, (char)0, false);
            PrintContent("科  室：" + ds.Tables[0].Rows[0]["OFFICE"].ToString() + "", 0, (char)0, false); ;
            PrintContent("挂号费：" + regmoney + "元 ", 0, (char)0, false);


            PrintContent("操作员：" + SysOperatorInfo.OperatorName + " ", 0, (char)0, false);
            PrintContent("挂号日期：" + DateTime.Now.ToString(), 0, (char)0, false);
            PrintContent("挂号号：" + ds.Tables[0].Rows[0]["REGISTERID"].ToString() + "", 0, (char)0, false);
            PrintContent("发票号：" + ds.Tables[0].Rows[0]["INVOICEID"].ToString() + " ", 0, (char)0, false);
            PrintContent("----------------------------------------------------", 11, (char)0, false);
            PrintContent("提示：此小票作为挂号凭证，请妥善保管！", 0, (char)0, false);
            POS_PRINT_DLL.LineFeed();

            POS_PRINT_DLL.LineFeed();
            PrintContent(hosname, 144, (char)titleFontsize, true);
            PrintContent("----------------------------------------------------", 11, (char)0, false);

            PrintContent("姓  名：" + ds.Tables[0].Rows[0]["PATIENTNAME"].ToString() + " ", 0, (char)0, false);
            PrintContent("科  室：" + ds.Tables[0].Rows[0]["OFFICE"].ToString() + "", 0, (char)0, false); ;
            PrintContent("挂号费：" + regmoney + "元 ", 0, (char)0, false);


            PrintContent("操作员：" + SysOperatorInfo.OperatorName + " ", 0, (char)0, false);
            PrintContent("挂号日期：" + DateTime.Now.ToString(), 0, (char)0, false);
            PrintContent("挂号号：" + ds.Tables[0].Rows[0]["REGISTERID"].ToString() + "", 0, (char)0, false);
            PrintContent("发票号：" + ds.Tables[0].Rows[0]["INVOICEID"].ToString() + " ", 0, (char)0, false);
            PrintContent("----------------------------------------------------", 11, (char)0, false);
            PrintContent("提示：此小票作为挂号凭证，请妥善保管！", 0, (char)0, false);
            POS_PRINT_DLL.LineFeed();
            this.cutPage();

            //ax.RPPrintText("科  室： ");
            //ax.RPPrintText(dszs.Tables[0].Rows[0]["EXAMINENAME"].ToString() + "\n");
            //ax.RPPrintText("挂号费： ");
            //ax.RPPrintText(regmoney + "元\n");
            //ax.RPPrintText("操作员： ");
            //ax.RPPrintText(SysOperatorInfo.OperatorName + "\n");
            //ax.RPPrintText("排队号： ");
            //ax.RPPrintText(ds.Tables[0].Rows[0]["WORKTYPE"] == null ? "" : ds.Tables[0].Rows[0]["WORKTYPE"].ToString() + "：");
            //ax.RPPrintText(ds.Tables[0].Rows[0]["QUEUEID"] == null ? "" : dszs.Tables[0].Rows[0]["QUEUEID"].ToString() + "\n");
            //ax.RPPrintText("挂号日期： ");
            //ax.RPPrintText(DateTime.Now.ToString() + "\n");
            //ax.RPPrintText("挂号号： ");
            //ax.RPPrintText(ds.Tables[0].Rows[0]["REGISTERID"].ToString() + "\n");
        }
        
        
        #region IPrintService 成员

        public void PrintReport()
        {
            InitPrint();
            POS_PRINT_DLL.LineFeed();
            //PrintContent("延安大学附属医院", 144, (char)25, true);
            //PrintContent("心脑血管病区", 144, (char)15, true);
            //PrintContent("----------------------------------------------------", 11, (char)0, false);
            //PrintContent("收据号：" + ds.Tables[0].Rows[0]["TRANSACTION_ID"].ToString() + "", 0, (char)0, false);
            //PrintContent("姓  名：" + name + " ", 0, (char)0, false);
            //PrintContent("充值金额：" + sum + "元 ", 0, (char)0, false); ;
            //PrintContent("卡余额：" + cardBlance + "元 ", 0, (char)0, false);

            //PrintContent("证件号码：" + identityCardID, 0, (char)0, false);
            //PrintContent("操作员：" + operatorName + " ", 0, (char)0, false);
            //PrintContent("充值类型：现金 ", 0, (char)0, false);

            //PrintContent("卡票号：" + ds.Tables[0].Rows[0]["CHECKLOT"].ToString() + " ", 0, (char)0, false);
            //PrintContent("充值日期：" + serverTime, 0, (char)0, false);
            //PrintContent("----------------------------------------------------", 11, (char)0, false);
            //PrintContent("提示：此小票作为退卡凭证，请妥善保管！", 0, (char)0, false);
            POS_PRINT_DLL.LineFeed();
            this.cutPage();
        }

        #endregion
    }
}
