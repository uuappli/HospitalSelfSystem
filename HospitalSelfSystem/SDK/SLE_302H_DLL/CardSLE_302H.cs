using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardInterface;


namespace AutoRegisterManager
{
    /// <summary>
    /// mzq 20100624
    /// 
    /// 配置 <add key="卡机类型" value="CardInterface.SLE_302H_DLL.CardSLE_302H" />
    /// </summary>
    public class CardSLE_302H : CardBase
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="parent">载体</param>
        public CardSLE_302H(object parent)
            : base(parent) 
        {
        }

        //Skynet.Framework.Common.WaitDialogForm dialog;

        private int _comIndex = 0;

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Open()
        {
            StringBuilder openSstringB = new StringBuilder(1024);

            //dialog = new Skynet.Framework.Common.WaitDialogForm("请刷卡...");
            //if (_comIndex != 0)
            //{
            //    openSstringB.Append(_comIndex + ",9600,N,8,1");
            //    int resVal = SLE_302H_DLL.Init_com(openSstringB);
            //    if (resVal == 1)
            //    {
            //        return;
            //    }
            //}

            int returnValue = 0;
            for (_comIndex = 1; _comIndex < 5; _comIndex++)
            {
                openSstringB.Append(_comIndex + ",9600,N,8,1");
                returnValue = SLE_302H_DLL.Init_com(openSstringB);
                switch (returnValue)
                {
                    case 1:
                        break;
                    case -1:
                        //dialog.Close();
                        //throw new Exception("串口打开失败！");
                        continue;
                    case -2:
                        //dialog.Close();
                        //throw new Exception("串口设置错误！");
                        continue;
                    case -4:
                        continue;
                }
            }

            if (returnValue != 1)
            {
                _comIndex = 0;
                throw new Exception("没有检测到设备！");
            }
        }

        /// <summary>
        /// 写卡,第1磁道为卡帐号，第2磁道为卡面号
        /// </summary>
        /// <param name="message">卡信息</param>
        public override void Write(CardInformationStruct message)
        {
            if (string.IsNullOrEmpty(message.CardNo))
                throw new Exception("卡号不能为空！");

            StringBuilder setdata = new StringBuilder(1024);
            setdata.Append(message.CardNo);
            Open();

            int returnValue = SLE_302H_DLL.Wcard(setdata, 2);

            Close();

            switch (returnValue)
            {
                case -1:
                    throw new Exception("串口打开失败！");
                case -8:
                    throw new Exception("写磁卡失败！");
                case -3:
                    throw new Exception("串口没有打开！");
                case -4:
                    throw new Exception("(发给动态库的)命令参数错！");
                case -5:
                    throw new Exception("与磁卡读写机通信失败(磁卡机没有与主机连接或连接不正确)！");
                case -6:
                    throw new Exception("操作超时,退出操作！");
                case -7:
                    throw new Exception("按 ESC 键退出当前操作！");
            }
        }

        /// <summary>
        /// 读卡,第1磁道为卡帐号，第2磁道为卡面号
        /// </summary>
        /// <returns>卡信息</returns>
        public override CardInformationStruct Read()
        {
            Open();

            StringBuilder message = new StringBuilder(1024);

            int returnValue = SLE_302H_DLL.Rcard(message, 2);

            Close();

            switch (returnValue)
            {
                case -1:
                    throw new Exception("串口打开失败！");
                case -8:
                    throw new Exception("写磁卡失败！");
                case -3:
                    throw new Exception("串口没有打开！");
                case -4:
                    throw new Exception("(发给动态库的)命令参数错！");
                case -5:
                    throw new Exception("与磁卡读写机通信失败(磁卡机没有与主机连接或连接不正确)！");
                case -6:
                    throw new Exception("操作超时,退出操作！");
                case -7:
                    throw new Exception("按 ESC 键退出当前操作！");
            }

            return new CardInformationStruct(message.ToString());
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected override void Close()
        {
            //dialog.Close();

            if (_comIndex == 0)
            {
                throw new Exception("请先初始化设备！");
            }

            SLE_302H_DLL.close_com();
        }


    }
}
