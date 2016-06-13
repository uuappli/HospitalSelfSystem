using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    /// <summary>
    /// 射频卡发卡、读卡、写卡
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class CRTCard
    {
        #region 发卡部分
        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_CommOpen", CharSet = CharSet.Ansi)]//打开端口
        public static extern IntPtr D1000_CommOpen(string port);
        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_CommOpenWithBaud", CharSet = CharSet.Ansi)]//打开端口（设置固定波特率 默认9600）
        public static extern IntPtr CommOpenWithBaud(string port,int data);

        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_Query", CharSet = CharSet.Ansi)]
        public static extern int D1000_Query(IntPtr ComHandle, int MacAddr, ref byte[] strVersion);
        
        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_GetMacVersion", CharSet = CharSet.Ansi)]
        public static extern int D1000_GetMacVersion(IntPtr ComHandle, byte MacAddr, ref string strVersion);
        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_CommClose", CharSet = CharSet.Ansi)]//关闭端口
        public static extern int D1000_CommClose(IntPtr ComHandle);

        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_GetDllVerion", CharSet = CharSet.Ansi)]
        public static extern int D1000_GetDllVerion(IntPtr ComHandle, ref string strversion);//获取动态库版本信息


        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_SendCmd", CharSet = CharSet.Ansi)]
        public static extern int D1000_SendCmd(IntPtr ComHandle, byte add, string cmd,int cmdlen);//发送指令

        [DllImport("CRTCard\\D1000DLL.dll", EntryPoint = "D1000_SensorQuery", CharSet = CharSet.Ansi)]
        public static extern int D1000_SensorQuery(IntPtr ComHandle, byte add,  byte[] stateInfo);//获取动态库版本信息
        #endregion
        #region 读卡写卡部分

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_CommOpenWithBaud", CharSet = CharSet.Ansi)]
        public static extern IntPtr RF610_CommOpenWithBaud(string port, int data);//打开端口 （设置波特率）

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_GetSysVersion", CharSet = CharSet.Ansi)]
        public static extern int RF610_GetSysVersion(IntPtr ComHandle,  string strVersion);

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_Reset", CharSet = CharSet.Ansi)]
        public static extern int RF610_Reset(IntPtr ComHandle, ref StringBuilder strVersion, ref byte[] recordInfo);


        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_S50DetectCard", CharSet = CharSet.Ansi)]//寻卡 =0寻卡成功 其余失败
        public static extern int RF610_S50DetectCard(IntPtr ComHandle, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_S50ReadBlock", CharSet = CharSet.Ansi)]//读卡（先寻卡再校验密码后才可以操作此项）
        public static extern int RF610_S50ReadBlock(IntPtr ComHandle, byte SectorAddr, byte BlockAddr,  byte[] _BlockData,  string RecordInfo);

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_S50LoadSecKey", CharSet = CharSet.Ansi)]//校验扇区密码，密码一般写在每个扇区的第三块 后六个字节
        public static extern int RF610_S50LoadSecKey(IntPtr ComHandle, byte SectorAddr, byte KeyType, ref long Key, string RecordInfo);

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_S50WriteBlock", CharSet = CharSet.Ansi)]//写卡 （先寻卡再校验密码后才可以操作此项）写入内容为ASCII码形式。
        public static extern int RF610_S50WriteBlock(IntPtr ComHandle, byte SectorAddr, byte BlockAddr, byte[] _BlockData, string RecordInfo);

        [DllImport("RF610\\RF610_DLL.dll", EntryPoint = "RF610_CommClose", CharSet = CharSet.Ansi)]
        public static extern IntPtr RF610_CommClose(IntPtr ComHandle);//关闭端口
        #endregion

    }
}
