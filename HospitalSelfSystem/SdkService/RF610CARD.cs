using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AutoServiceSDK.SDK;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 读卡、写卡器
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class RF610CARD
    {
        

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns>打开串口句柄</returns>
        public IntPtr OpenPort()
        {

            IntPtr hadler = CRTCard.RF610_CommOpenWithBaud("com5", 9600);
            return hadler;
        }
        /// <summary>
        /// 寻卡
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        /// <returns>true 寻卡成功，false 寻卡失败</returns>
        public bool FindCard(IntPtr hadler)
        {
            StringBuilder temp = new StringBuilder(64);
            int rs = CRTCard.RF610_S50DetectCard(hadler, temp);
            if (rs == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 卡密校验
        /// </summary>
        /// <param name="sqadd">扇区地址 s50 三个扇区，第三扇区为密码存储扇区 占后6个字节，谨慎写操作</param>
        /// <param name="KeyType">密码类型</param>
        /// <param name="key">密码</param>
        /// <returns></returns>
        public bool ValidPass(IntPtr hadler)
        {
            long Key = 281474976710655;
            int rskey = CRTCard.RF610_S50LoadSecKey(hadler, Convert.ToByte(2), Convert.ToByte(48), ref Key, "");
            if (rskey == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        /// <param name="sqadd">扇区地址</param>
        /// /// <param name="blockAddr">扇区块地址 0——2  第三块地址为密码存储块</param>
        /// <param name="value">写入的值，一个扇区块值不能超过10个字节</param>
        /// <returns></returns>
        public bool WriteCard( IntPtr hadler, string value)
        {
            ASCIIEncoding AE1 = new ASCIIEncoding();
             int rs=-1;
             if (value.Length > 16)
             {
                 byte[] ByteArray1 = AE1.GetBytes(value.Substring(0, 16));
                 byte[] ByteArray2 = AE1.GetBytes(value.Substring(16));
                 rs = CRTCard.RF610_S50WriteBlock(hadler, Convert.ToByte(2), Convert.ToByte(0), ByteArray1, "");
                 rs = CRTCard.RF610_S50WriteBlock(hadler, Convert.ToByte(2), Convert.ToByte(1), ByteArray2, "");
             }
             else
             {
                 byte[] ByteArray1 = AE1.GetBytes(value);
                 rs = CRTCard.RF610_S50WriteBlock(hadler, Convert.ToByte(2), Convert.ToByte(0), ByteArray1, "");
             }
            if (rs == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 写卡 界面调用
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public int WriteCardFacade(string cardNo)
        {
            IntPtr ip = OpenPort();
            if (ip.ToInt32() == 0)
            {
                return 1;  
            }
            try
            {
                if (!FindCard(ip))
                {
                    return 2;
                }
                if (!ValidPass(ip))
                {
                    return 3;
                }
                if (!WriteCard(ip, cardNo))
                {
                    return 5;
                }
                return 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CRTCard.RF610_CommClose(ip);
            }

        }
        ///// <summary>
        ///// 读卡
        ///// </summary>
        ///// <param name="hadler">打开的串口句柄</param>
        ///// <param name="sqadd">扇区地址</param>
        ///// <param name="blockAddr">扇区块地址</param>
        ///// <returns>读取的值</returns>
        //public string ReadCard(int sqadd,int blockAddr)
        //{
        //    byte[] _BlockData = new byte[10];
        //    int rs = CRTCard.RF610_S50ReadBlock(RF610CARD.hadler, Convert.ToByte(sqadd), Convert.ToByte(blockAddr), _BlockData, "");
        //    if (rs == 0)
        //    {
        //        return dis_package(_BlockData);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        public string dis_package(byte[] reb)
        {
            string temp = "";


            ASCIIEncoding AE2 = new ASCIIEncoding();
            char[] CharArray = AE2.GetChars(reb);
            for (int x = 0; x <= CharArray.Length - 1; x++)
            {
                temp = temp + CharArray[x].ToString();
            }
            return temp;

        }
    }
}
