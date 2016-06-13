using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.SDK;
using HospitalSelfSystem;
using HospitalSelfSystem.Properties;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// M100读卡器
    /// 作者：李新华
    /// DATE：2013.1.14
    /// </summary>
    class M100ReadCard
    {
        /// <summary>
        /// 读卡器初始化
        /// </summary>
        /// <param name="add">机器地址 0——15</param>
        /// <returns>返回串口句柄</returns>
        public int Init(int port)
        {
            int mes = M100_DLL.CRTInit(port, 0);
            return mes;
        }

        /// <summary>
        /// 检查卡机状态
        /// </summary>
        /// <returns></returns>
        public bool CheckCardPosition()
        {
            try
            {
                byte[] ByteArray2 = new byte[1];
                int i = M100_DLL.GetCardReaderStatus(ByteArray2);
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
            int hadler = Init(Convert.ToInt32(port) - 1);
            if (hadler != 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return string.Empty;
            }

            try
            {
                int i = M100_DLL.IntakeCard(3000);
                if (i != 0)
                {
                    //MyMsg.MsgInfo("进卡失败");
                    return string.Empty;
                }

                //int cardState = 0;
                //while (cardState == 0)
                //{
                //    bool mes = CheckCardPosition();
                //    if (mes == true)
                //    {
                //        cardState = 1;
                //    }
                //}

                string cardNo = string.Empty;
                StringBuilder sb = new StringBuilder(1024);
                StringBuilder sb2 = new StringBuilder(1024);
                StringBuilder sb3 = new StringBuilder(1024);
                i = M100_DLL.ReadMagCard(sb, sb2, sb3);
                if (i != 0)
                {
                    MyMsg.MsgInfo("读取卡片信息失败");
                    return string.Empty;

                }
                else
                {
                    cardNo = sb2.ToString();
                }

                i = M100_DLL.Eject();
                if (i != 0)
                {
                    MyMsg.MsgInfo("退卡失败");
                    return string.Empty;
                }

                return cardNo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
