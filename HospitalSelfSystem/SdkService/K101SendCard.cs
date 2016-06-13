using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.SDK;
using CardInterface;
using HospitalSelfSystem.Properties;
using HospitalSelfSystem;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// K101发卡器
    /// 作者：李新华
    /// DATE：2013.1.10
    /// </summary>
    class K101SendCard
    {
        /// <summary>
        /// 发卡器初始化
        /// </summary>
        /// <param name="add">机器地址 0——15</param>
        /// <returns>返回串口句柄</returns>
        public IntPtr Init()
        {
            string port = Settings.Default.发卡器端口;
            port = "com" + port;
            IntPtr hadler = K101_DLL.K101_CommOpenWithBaud(port, 9600);

            return hadler;
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        public void ClosePort(IntPtr hadler)
        {
            int i = K101_DLL.K101_CommClose(hadler);
        }

        /// <summary>
        /// 检查卡机状态
        /// </summary>
        /// <returns></returns>
        public bool CheckCardPosition()
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
                StringBuilder sb = new StringBuilder(1024);
                byte[] ByteArray2 = new byte[2];
                int i = K101_DLL.K101_CheckCardPosition(hadler, false, Convert.ToByte(0), ByteArray2, sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("读取卡片在机器里的位置失败！");
                    return false;
                }

                string state = string.Empty;
                switch (ByteArray2[0])
                {
                    //case 0x30:
                    //    state = "通道无卡";
                    //    break;
                    case 0x31:
                        state = "读磁卡位置有卡";
                        break;
                    case 0x32:
                        state = "IC卡位置有卡";
                        break;
                    case 0x33:
                        state = "前端夹卡位置有卡";
                        break;
                    case 0x34:
                        state = "前端不夹卡位置有卡";
                        break;
                    case 0x35:
                        state = "卡不在标准位置";
                        break;
                    case 0x36:
                        state = "卡片正在传动过程中";
                        break;

                }

                if (state != string.Empty)
                {
                    MyMsg.MsgInfo(state);
                    return false;
                }

                switch (ByteArray2[1])
                {
                    case 0x30:
                        state = "卡箱无卡";
                        break;
                    //case 0x31:
                    //    state = "卡箱卡片不足, 提醒需要加卡";
                    //    break;
                    //case 0x32:
                    //    state = "IC卡箱卡片足够";
                    //    break;


                }

                if (state != string.Empty)
                {
                    MyMsg.MsgInfo(state);
                    return false;
                }

                return true;
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
        /// 传动卡片
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool MoveCard(string cmd)
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
                StringBuilder sb = new StringBuilder(1024);

                if (cmd != string.Empty)
                {
                    byte bt = new byte();
                    switch (cmd)
                    {
                        case "移动到读磁卡位":
                            bt = 0x30;
                            break;
                        case "传动到IC卡位":
                            bt = 0x31;
                            break;
                        case "传动到前端夹卡位":
                            bt = 0x32;
                            break;
                        case "弹出卡片":
                            bt = 0x33;
                            break;
                        case "回收卡片":
                            bt = 0x34;
                            break;
                        case "传动到射频卡位":
                            bt = 0x35;
                            break;
                        case "抖动弹出":
                            bt = 0x36;
                            break;
                    }



                    int i = K101_DLL.K101_MoveCard(hadler, false, Convert.ToByte(0), bt, sb);
                    if (i != 0)
                    {
                        MyMsg.MsgInfo("卡片传动失败");
                        return false;
                    }
                }

                return true;
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

        public string ReadCard()
        {
            IntPtr hadler = Init();
            int rs = 0;
            if (hadler.ToInt32() == 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return string.Empty;
            }

            try
            {
                string cardNo = string.Empty;
                StringBuilder sb = new StringBuilder(1024);
                StringBuilder ByteArray2 = new StringBuilder(1024);
                byte _track = Convert.ToByte(0x31);
                byte[] _DataLen = new byte[1];
                int i = K101_DLL.K101_ReadMagcardDecode(hadler, false, Convert.ToByte(0), _track, _DataLen, ByteArray2, sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("卡机读卡失败!");
                    return cardNo;
                }

                if (Convert.ToInt32(_DataLen[0]) > 0)
                {

                    cardNo = ByteArray2.ToString().Trim().Substring(2, Convert.ToInt32(_DataLen[0]) - 2);
                }
                else
                {
                    MyMsg.MsgInfo("磁卡数据错误！或是空卡");
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

        public int WriteCard(string cardData)
        {
            IntPtr hadler = Init();
            int rs = 0;
            if (hadler.ToInt32() == 0)
            {
                MyMsg.MsgInfo("端口打开失败！");
                return -1;
            }

            try
            {
                StringBuilder sb = new StringBuilder(1024);
                byte _Voltage = Convert.ToByte(0x30);
                int i = K101_DLL.K101_IcCardPowerOn(hadler, false, Convert.ToByte(0), _Voltage, sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("IC卡上电失败");
                    return -1;
                }


                byte[] _PWData = new byte[3];
                _PWData[0] = Convert.ToByte("FF", 16);
                _PWData[1] = Convert.ToByte("FF", 16);
                _PWData[2] = Convert.ToByte("FF", 16);
                i = K101_DLL.K101_SLE4442VerifyPWD(hadler, false, Convert.ToByte(0), _PWData, sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("SLE4442卡片验证密码失败");
                    return -1;
                }


                string msg = Pub.Encrypt(cardData, "SOFT-HIS");
                byte[] _data = Encoding.ASCII.GetBytes(msg);

                i = K101_DLL.K101_SLE4442Write(hadler, false, Convert.ToByte(0), 27, 88, _data, sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("写入SLE4442卡片数据失败");
                    return -1;
                }


                i = K101_DLL.K101_IcCardPowerOff(hadler, false, Convert.ToByte(0), sb);
                if (i != 0)
                {
                    MyMsg.MsgInfo("IC卡下电失败");
                    return -1;
                }

                return 0;
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
