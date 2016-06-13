using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.SDK;
using CardInterface;
using HospitalSelfSystem;
using HospitalSelfSystem.Properties;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// M100读卡器
    /// 作者：李新华
    /// DATE：2013.1.14
    /// </summary>
    class M100ICReadCard
    {
        /// <summary>
        /// 读卡器初始化
        /// </summary>
        /// <param name="add">机器地址 0——15</param>
        /// <returns>返回串口句柄</returns>
        public IntPtr Init(int port)
        {
            string _port = "com" + port;
            IntPtr hadler = M100IC_DLL.M100_CommOpenWithBaud(_port, 9600);
            return hadler;
        }

        /// <summary>
        /// 检查卡机状态
        /// </summary>
        /// <returns></returns>
        public bool CheckCardPosition(IntPtr hadler)
        {
            try
            {
                byte[] ByteArray2 = new byte[2];
                int i = M100IC_DLL.M100_CheckCardPosition(hadler, ByteArray2);
                if (i != 0)
                {
                    MyMsg.MsgInfo("读取卡片在机器里的位置失败");
                    return false;
                }

                string state = string.Empty;
                switch (ByteArray2[0])
                {
                    case 0x30:
                        state = "卡片在前端不夹卡位置";
                        break;
                    case 0x31:
                        state = "卡片在前端夹卡位置";
                        break;
                    //case 0x32:
                    //    state = "卡片在读卡机射频卡位置";
                    //    break;
                    //case 0x33:
                    //    state = "卡片在IC卡位置";
                    //    break;
                    case 0x34:
                        state = "卡片在后端夹卡位置";
                        break;
                    case 0x35:
                        state = "读卡机内无卡";
                        break;
                    case 0x36:
                        state = "卡不在标准位置";
                        break;

                }


                if (state != string.Empty)
                {
                    //MyMsg.MsgInfo(state);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           

        }

        public string ReadCard()
        {
            string port = Settings.Default.读卡器端口;
            IntPtr hadler = Init(Convert.ToInt32(port));
            if (hadler.ToInt32() == 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return string.Empty;
            }

            try
            {
                int i = M100IC_DLL.M100_EnterCard(hadler, 0x30, 3000);
                if (i != 0)
                {
                    //MyMsg.MsgInfo("进卡失败");
                    return string.Empty;
                }

                i = M100IC_DLL.M100_MoveCard(hadler, 0x31);
                if (i != 0)
                {
                    MyMsg.MsgInfo("卡片传动IC卡位失败");
                    return string.Empty;
                }

                i = M100IC_DLL.M100_IcCardPowerOn(hadler);
                if (i != 0)
                {
                    MyMsg.MsgInfo("上电失败");
                    return string.Empty;
                }

                byte[] buf = new byte[3];
                buf[0] = Convert.ToByte("FF", 16);
                buf[1] = Convert.ToByte("FF", 16);
                buf[2] = Convert.ToByte("FF", 16);
                i = M100IC_DLL.M100_SLE4442VerifyPWD(hadler, buf);
                if (i != 0)
                {
                    MyMsg.MsgInfo("密码验证失败");
                    return string.Empty;
                }

                byte[] _data = new byte[88];
                i = M100IC_DLL.M100_SLE4442Read(hadler, 27, 88, _data);
                if (i != 0)
                {
                    MyMsg.MsgInfo("读卡失败");
                    return string.Empty;
                }

                i = M100IC_DLL.M100_IcCardPowerOff(hadler);
                if (i != 0)
                {
                    MyMsg.MsgInfo("下电失败");
                    return string.Empty;
                }

                i = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                if (i != 0)
                {
                    MyMsg.MsgInfo("退卡失败");
                    return string.Empty;
                }

                string cardNo = string.Empty;

                try
                {
                    
                    string msg = Encoding.ASCII.GetString(_data);
                    string returnstr = Pub.Decrypt(msg, "SOFT-HIS");
                    cardNo = returnstr;
                }
                catch
                {
                    MyMsg.MsgInfo("卡片数据错误！或卡插入方向不正确");
                    return string.Empty;
                }

                return cardNo;
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

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        public void ClosePort(IntPtr hadler)
        {
            int i = M100IC_DLL.M100_CommClose(hadler);
        }
    }
}
