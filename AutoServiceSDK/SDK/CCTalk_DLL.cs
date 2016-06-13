using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    public class CCTalk_DLL
    {
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "ccTalkOpenPort")]//打开端口
        public static extern int ccTalkOpenPort(int Port);
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "ccTalkClosePort")]//关闭端口
        public static extern int ccTalkClosePort();
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "SimplePoll")]//工作检验
        public static extern int SimplePoll();
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "ReqHopperStatus",CharSet=CharSet.Auto)]
        public static extern int ReqHopperStatus([MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);//Hopper状态
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "TestHopper")]
        public static extern int TestHopper(byte aa);//得到设备状态

        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "ReqPayoutHLStat")]//获取支付传感器的状态
        public static extern int ReqPayoutHLStat([MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "PayoutCoins")]//执行支付
        public static extern int PayoutCoins(int mountcount);
        [DllImport("CCTalk\\CCTalkApi.dll", EntryPoint = "ResetHopper")]//设备复位
        public static extern int ResetHopper();



    }
}
