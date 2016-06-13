using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoServiceSDK.SDK;
using HospitalSelfSystem;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 发卡器
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class D1000Card
    {
        
        /// <summary>
        /// 发卡器初始化
        /// </summary>
        /// <param name="add">机器地址 0——15</param>
        /// <returns>返回串口句柄</returns>
        public IntPtr Init()
        {
           
               IntPtr hadler = CRTCard.CommOpenWithBaud("com2", 9600);

               return hadler;
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        public void ClosePort(IntPtr hadler)
        {
            int rs = CRTCard.D1000_CommClose(hadler);
        }
        /// <summary>
        /// 得到发卡机状态
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        /// <param name="add">机器地址：0——15</param>
        /// <returns>状态byte数组 具体含义参照发卡机文档</returns>
        public string  getstatus(IntPtr hadler)
        {
            byte[] stateinfo = new byte[4];
            int rs = CRTCard.D1000_SensorQuery(hadler, Convert.ToByte(0), stateinfo);
            if (rs == 0)
            {
                return stateinfo[0].ToString() +  stateinfo[1].ToString() +  stateinfo[2].ToString() + stateinfo[3].ToString();
            }
            return string.Empty; ;
        }
        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        /// <param name="add">机器地址 0——15</param>
        /// <param name="cmd">指令内容 具体参考发卡器文档</param>
        /// <returns></returns>
        public bool sendcmd(string cmd)
        {
            IntPtr hadler = Init();
            int rs = 0;
            if (hadler.ToInt32() == 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return false;
            }
            try
            {
                
                rs = CRTCard.D1000_SendCmd(hadler, Convert.ToByte(0), "RS", 2);
                if (rs == 0)
                {
                    Thread.Sleep(2000);
                    string rsmsg = checkD1000(getstatus(hadler));
                    if (rsmsg == string.Empty)
                    {
                        rs = CRTCard.D1000_SendCmd(hadler, Convert.ToByte(0), cmd, cmd.Length);
                        if (rs == 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MyMsg.MsgInfo(rsmsg);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                ClosePort(hadler);
            }
        }
        public string checkD1000(string state)
        {
            string result = string.Empty;
            switch (state)
            { 
                case "48484956":
                    result = "机内无卡";
                    break;
                case "48484856":
                    result = "机内无卡";
                    break;
                case "50484848":
                    result = "卡机故障";
                    break;
                case"48504848":
                    result = "发卡错误";
                    break;
                case "48485648":
                    result = "无捕卡";
                    break;
                case"48485248":
                    result = "重叠卡";
                    break;
                case"48485048":
                    result = "堵塞卡";
                    break;
                case"48484948":
                    result = "卡预空";
                    break;
                   
            }
            return result;
        }

        public string CheckState()
        {
            IntPtr hadler = Init();
            int rs = 0;
            if (hadler.ToInt32() == 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return "端口打开失败";
            }
            try
            {
                string rsmsg = checkD1000(getstatus(hadler));
                if (rsmsg != string.Empty)
                {
                    return rsmsg;
                }

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ClosePort(hadler);
            }
        }
    }
}
