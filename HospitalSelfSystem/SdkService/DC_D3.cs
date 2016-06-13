using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.SDK;

namespace CardInterface.D3_DLL
{
    public class DC_D3 
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="parent">载体</param>
        private int _icdev = -1;//通讯设备标识符
        int sector = 2;//扇区号
        public int IcDev
        {
            get { return _icdev; }
            set { _icdev = value; }
        } 
        protected  void Open()
        {
            //初始化串口1
            try
            {
                Close();
                if (_icdev < 0)
                {
                    _icdev = DC_D3_DLL.dc_init(100, 115200);
                }
                if (_icdev <= 0)
                {
                    throw new Exception("卡机端口打开失败，错误代码：" + _icdev.ToString());
                }
                else
                {
                    string key = "ffffffffffff";
                    int rs = DC_D3_DLL.dc_load_key_hex(_icdev, 0, sector, key);
                    this.IcDev = _icdev;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public  void Write(string cardNo)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(cardNo))
        //            throw new Exception("卡号不能为空！");
        //        Open();
        //        if (!checkPass(ref message))
        //        {
        //            throw new Exception("卡密码有误！");
        //        }
        //        int st = -1;
        //        if (message.CardNo.Length > 16)
        //        {
        //             st = DC_D3_DLL.dc_write(this.IcDev, sector * 4, message.CardNo.Substring(0, 16));
        //            st.CheckBackValue();
        //            st = DC_D3_DLL.dc_write(this.IcDev, sector * 4 + 1, message.CardNo.Substring(16));
        //            st.CheckBackValue();
        //        }
        //        else
        //        {
        //            st = DC_D3_DLL.dc_write(this.IcDev, sector * 4 + 1, message.CardNo);
        //            st.CheckBackValue();
        //        }
        //        DC_D3_DLL.dc_beep(this.IcDev, 10);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message );
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //}

        public  string Read()
        {
            try
            {
                Open();
                string cardNo = string.Empty;
                if (!checkPass(ref cardNo))
                {
                    throw new Exception("");
                }
                StringBuilder temp = new StringBuilder(64);
                StringBuilder temp1 = new StringBuilder(64);
                int st = DC_D3_DLL.dc_read(this.IcDev, sector*4, temp);
                if (st != 0)
                {
                    throw new Exception("") ;
                }
                st = DC_D3_DLL.dc_read(this.IcDev, sector*4+1, temp1);
                if (st != 0)
                {
                    throw new Exception("");
                }
                string strCardNo = string.Empty;
                foreach (Char c in temp.Append(temp1).ToString())
                {
                    if (Char.IsDigit(c))
                    {
                        strCardNo += c;
                    }
                }
                cardNo = strCardNo.ToString();
                DC_D3_DLL.dc_beep(this.IcDev, 10);
                return cardNo;
            }
            catch (Exception )
            {
                return string.Empty;
            }
            finally
            {
                Close();
            }
        }

        protected  void Close()
        {
            
            int rs=DC_D3_DLL.dc_exit((Int16)this.IcDev);
            this.IcDev = -1;
            if (rs == -35)
            {

            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 核对密码
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        private bool checkPass( ref string  cardNo)
        {
            try
            {
                ulong icCardNo = 0;
                char tt = (char)0;
                uint ss = 0;
               
                int st = DC_D3_DLL.dc_reset(this.IcDev, ss);
                st = DC_D3_DLL.dc_card(this.IcDev, tt, ref icCardNo);
                if (st != 0)
                {
                    return false;
                }
                //核对密码
                st = DC_D3_DLL.dc_authentication(this.IcDev, 0, sector);
                if (st != 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
       
        
    }
}
