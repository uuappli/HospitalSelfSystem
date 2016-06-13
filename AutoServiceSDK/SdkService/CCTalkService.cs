using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.ISdkService;
using AutoServiceSDK.SDK;
using Skynet.LoggingService;

namespace AutoServiceSDK.SdkService
{
    public  class CCTalkService:ICCTalkService
    {
        #region ICCTalkService 成员

        public bool OpenPort(int port)
        {
             LogService.GlobalDebugMessage("找零机端口:" + port.ToString());
             int rs = CCTalk_DLL.ccTalkOpenPort(port);
             if (rs == 0)
             {
                 return true;
             }
             else
             {
                 LogService.GlobalDebugMessage("端口打开失败！");
                 return false;
             }
        }
        public int Valid()
        {
            int rs = CCTalk_DLL.SimplePoll();
            if (rs != 0)
            {
                LogService.GlobalDebugMessage("检验失败！" + rs.ToString());
            }
            return rs;
        }
        public int TakeMoney(int count)
        {
            LogService.GlobalDebugMessage("开始找零！");
           // OpenPort(7);
            ReSet();
            Valid();
            int rs = CCTalk_DLL.PayoutCoins(count);

            if (rs != 0)
            {
                LogService.GlobalDebugMessage("找零失败！" + rs.ToString());
            }
            return rs;
        }
        public string[] poll()
        {
            LogService.GlobalDebugMessage("获取Hopper状态");
            StringBuilder bstatus =new StringBuilder ();
            int rs = CCTalk_DLL.ReqHopperStatus(bstatus);
            LogService.GlobalDebugMessage("test"+bstatus.ToString());
           // return bstatus;
            if (bstatus.Length != 8)
            {
                return new  string[1];
            }
            return new string[4] { bstatus.ToString().Substring(0, 2), bstatus.ToString().Substring(2, 2), bstatus.ToString().Substring(4, 2), bstatus.ToString().Substring(6, 2) };
        }

        public int ClosePort()
        {
            LogService.GlobalDebugMessage("关闭端口");
            return CCTalk_DLL.ccTalkClosePort();
        }
        public int ReSet()
        {
            LogService.GlobalDebugMessage("复位");
            int rs = CCTalk_DLL.ResetHopper();
            if (rs != 0)
            {
                LogService.GlobalDebugMessage("复位失败！" + rs.ToString());
            }
            return rs;
        }

        #endregion
    }
}
