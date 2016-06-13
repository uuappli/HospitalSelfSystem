using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using AutoServiceSDK.ISdkService;
using AutoServiceSDK.SDK;

namespace AutoServiceSDK.SdkService
{
    /// <summary>
    /// 纸币器
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class CashCodeMoney: IMoneyService
    {

      
        /// <summary>
        /// 启动验钞
        /// </summary>
        /// <returns></returns>
        public int enablebilltype()
        {
            getstatus();
            int[] D3 = new int[3] { 9240575, 0, 0 }; //设置识别面额  FBFFFF  P3=10001100 识别5、10
            int[] D4 = new int[3] { 0, 0, 0 };
            byte rs = CASHCODE_MONEY_DLL.SetSecurity(3, D4);
            return CASHCODE_MONEY_DLL.CmdBillType(3, D3, D4);
        }
        /// <summary>
        /// 得到纸币器可识别的纸币面额
        /// 
        /// </summary>
        /// <returns></returns>
        public CASHCODE_MONEY_DLL.dBILLTABLE[] getstatus()
        {
            CASHCODE_MONEY_DLL.dBILLTABLE[] db1 = new CASHCODE_MONEY_DLL.dBILLTABLE[24];

            IntPtr pt = new IntPtr();
            try
            {

                pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CASHCODE_MONEY_DLL.dBILLTABLE)) * 24);

                byte rs = CASHCODE_MONEY_DLL.GetBillTable(3, pt);
                if (rs != 0)
                {

                }
                else
                {
                    for (int j = 0; j < 24; j++)
                    {
                        db1[j] =
                        (CASHCODE_MONEY_DLL.dBILLTABLE)Marshal.PtrToStructure((IntPtr)((UInt32)pt + j * Marshal.SizeOf(typeof(CASHCODE_MONEY_DLL.dBILLTABLE)))
                        , typeof(CASHCODE_MONEY_DLL.dBILLTABLE));

                    }
                }
                return db1;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(pt);
            }
        }
        #region IMoneyService 成员

        /// <summary>
        /// 设备初始化
        /// </summary>
        public bool OpenPort()
        {
            try
            {
                int rs = CASHCODE_MONEY_DLL.InitComm(3);
                if (rs != 0)
                {
                    throw new Exception("打开端口失败！错误码：" + Convert.ToString(rs, 16));
                }
                byte brs = CASHCODE_MONEY_DLL.ResetCMD(3);
                if (brs != 0)
                {
                    throw new Exception("设备初始化失败！错误码：" + Convert.ToString(brs, 16));
                }
                enablebilltype();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 发送接收纸币指令，需要连续不断发送此指令
        /// </summary>
        /// <returns>读取的纸币金额</returns>
        public int GetInMoney()
        {
            byte D1 = new byte();
            byte D2 = new byte();

            int rs1 = CASHCODE_MONEY_DLL.PollCMD(3, ref D1, ref D2);
            int moneycount = 0;
            switch (Convert.ToString(D1, 16))
            {
                case "19":
                    enablebilltype();
                    break;
                case "80":
                    byte rsstack = CASHCODE_MONEY_DLL.CmdStack(3);

                    break;
                case "81":
                    switch (Convert.ToString(D2, 16))
                    {
                        case "0":
                            moneycount = 1;
                            break;
                        case "1":
                            moneycount = 2;
                            break;
                        case "2":
                            moneycount = 5;
                            break;
                        case "3":
                            moneycount = 10;
                            break;
                        case "4":
                            moneycount = 20;
                            break;
                        case "5":
                            moneycount = 50;
                            break;
                        case "6":
                            moneycount = 100;
                            break;
                        default:
                            moneycount = 0;
                            break;
                    }
                    break;
                default:
                    break;

            }
            return moneycount;
        }
        /// <summary>
        /// 停止接收纸币
        /// </summary>
        public bool ClosePort()
        {
            int[] D3 = new int[3] { 0, 0, 0 };
            int[] D4 = new int[3] { 0, 0, 0 };
            CASHCODE_MONEY_DLL.CmdBillType(3, D3, D4);
            int rs = CASHCODE_MONEY_DLL.ClosePort();
            if (rs != 0)
            {
                return false ;
            }
            return true;
            
        }

        #endregion
    }
}
