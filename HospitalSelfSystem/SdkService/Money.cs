using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoRegisterManager.SDK;
using HospitalSelfSystem.Properties;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 纸币器
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class Money
    {

        /// <summary>
        /// 设备初始化
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="add">机器地址 纸币器为3</param>
        /// <returns></returns>
        public bool init(int port,int add)
        {
            try
            {
                int rs = DMoney.InitComm(port);
                if (rs != 0)
                {
                    throw new Exception("打开端口失败！错误码：" + Convert.ToString(rs, 16));
                }
                byte brs = DMoney.ResetCMD(add);
                if (brs != 0)
                {
                    throw new Exception("设备初始化失败！错误码：" + Convert.ToString(brs, 16));
                }
                enablebilltype();
                return true;
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.Message );
            }
        }
        /// <summary>
        /// 启动验钞
        /// </summary>
        /// <returns></returns>
        public int enablebilltype()
        {
            getstatus();
            //int[] D3 = new int[3] { 14745599, 0, 0 }; //设置识别面额  FBFFFF  P3=11100000
            //int[] D3 = new int[3] { 16777215, 0, 0 }; //设置识别面额  FBFFFF  P3=11100000
            int[] D3 = new int[3] { Settings.Default.识别面额, 0, 0 }; //设置识别面额  FBFFFF  P3=11100000
            int[] D4 = new int[3] { 0, 0, 0 };
            byte rs = DMoney.SetSecurity(3, D4);
            return DMoney.CmdBillType(3, D3, D4);
        }
        /// <summary>
        /// 发送接收纸币指令，需要连续不断发送此指令
        /// </summary>
        /// <returns>读取的纸币金额</returns>
        public int poll()
        {
            byte D1 = new byte();
            byte D2 = new byte();

            int rs1 = DMoney.PollCMD(3, ref D1, ref D2);
            int moneycount = 0;
            switch (Convert.ToString(D1, 16))
            {
                case "19":
                    enablebilltype();
                    break;
                case "80":
                    byte rsstack = DMoney.CmdStack(3);
                   
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
        /// 得到纸币器可识别的纸币面额
        /// 
        /// </summary>
        /// <returns></returns>
        public DMoney.dBILLTABLE[] getstatus()
        {
           DMoney.dBILLTABLE[] db1 = new DMoney.dBILLTABLE[24];

            IntPtr pt = new IntPtr();
            try
            {

                pt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DMoney.dBILLTABLE)) * 24);

                byte rs = DMoney.GetBillTable(3, pt);
                if (rs != 0)
                {

                }
                else
                {
                    for (int j = 0; j < 24; j++)
                    {
                        db1[j] =
                        (DMoney.dBILLTABLE)Marshal.PtrToStructure((IntPtr)((UInt32)pt + j * Marshal.SizeOf(typeof(DMoney.dBILLTABLE)))
                        , typeof(DMoney.dBILLTABLE));

                    }
                }
                return db1;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(pt);
            }
        }
        /// <summary>
        /// 停止接收纸币
        /// </summary>
        /// <returns></returns>
        public bool CloseInit()
        {

            int[] D3 = new int[3] { 0, 0, 0 };
            int[] D4 = new int[3] { 0, 0, 0 };
            DMoney.CmdBillType(3, D3, D4);
            int rs = DMoney.ClosePort();
            if (rs != 0)
            {
                return false;
            }
            return true;
        }
    }
}
