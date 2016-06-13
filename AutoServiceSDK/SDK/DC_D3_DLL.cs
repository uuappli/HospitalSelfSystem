using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    /// <summary>
    /// 德卡D3射频卡读写卡机驱动
    /// 2053 2012-03-28 Add
    /// </summary>
    public class DC_D3_DLL
    {
        #region 对USB接口的使用(PHILIPH卡)
        /// <summary>
        /// 初试化
        /// </summary>
        /// <param name="port">端口 USB端口为100</param>
        /// <param name="baud">波特率 USB无效</param>
        /// <returns>返回通讯设备标识符</returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern int dc_init(Int16 port, Int32 baud);
        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <returns>0为成功其他值为失败</returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_exit(int icdev);
        /// <summary>
        /// 射频复位函数
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="sec">复位时间 （单位为毫秒）</param>
        /// <returns>0为成功其他值为失败</returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_reset(int icdev, uint sec);
        /// <summary>
        /// 寻卡请求
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="_Mode">寻卡模式
        /// 寻卡模式分三种情况：IDLE模式、ALL模式及指定卡模式。
        ///0——表示IDLE模式，一次只对一张卡操作；
        ///1——表示ALL模式，一次可对多张卡操作；
        ///2——表示指定卡模式，只对序列号等于snr的卡操作（高级函数才有）
        /// </param>
        /// <param name="TagType">卡类型值</param>
        /// <returns>0为成功其他值为失败</returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_request(int icdev, char _Mode, ref uint TagType);
        /// <summary>
        /// 寻卡，能返回在工作区域内某张卡的序列号(该函数包含了dc_request,dc_anticoll,dc_select的整体功能)
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="_Mode">寻卡模式</param>
        /// <param name="Snr">返回的卡序列号</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_card(int icdev, char _Mode, ref ulong Snr);
        /// <summary>
        /// 终止对该卡操作，适用于寻卡模式为单卡模式
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_halt(int icdev);
        /// <summary>
        /// 防卡冲突，返回卡的序列号（注：request指令之后应立即调用anticoll，除非卡的序列号已知）
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="_Bcnt">设为0</param>
        /// <param name="IcCardNo">返回卡的序列号</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_anticoll(int icdev, char _Bcnt, ref ulong IcCardNo);
        /// <summary>
        /// 蜂鸣
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="_Msec">蜂鸣时间，单位是10毫秒</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_beep(int icdev, uint _Msec);
        /// <summary>
        /// 核对密码函数
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="_Mode">密码校验模式
        /// 对于M1卡的每个扇区，在读写器中均对应有三套密码（KEYSET0、KEYSET1、KEYSET2），每套密码包括A密码（KEYA）和B密码（KEYB），共六个密码，用0～2、4～6来表示这六个密码：
        ///0——KEYSET0的KEYA`
        ///1——KEYSET1的KEYA
        ///2——KEYSET2的KEYA
        ///4——KEYSET0的KEYB
        ///5——KEYSET1的KEYB
        ///6——KEYSET2的KEYB
        /// </param>
        /// <param name="_SecNr">要验证密码的扇区号</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_authentication(int icdev, int _Mode, int _SecNr);
        /// <summary>
        /// 将密码装入读写模块的RAM中
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">装入密码模式（同上密码验证模式）</param>
        /// <param name="secnr">扇区号</param>
        /// <param name="nkey">写入读写器中的卡密码</param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_load_key(int icdev, int mode, int secnr, [In] byte[] nkey);  //密码装载到读写模块中
        /// <summary>
        /// 密码装载到读写模块中
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="mode"></param>
        /// <param name="secnr"></param>
        /// <param name="nkey"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_load_key_hex(int icdev, int mode, int secnr, string nkey);  
        /// <summary>
        /// 向卡中写入数据
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_write(int icdev, int adr, [In] byte[] sdata);  
        /// <summary>
        /// 向卡中写入数据
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_write(int icdev, int adr, [In] string sdata);  
        /// <summary>
        /// 向卡中写入数据(转换为16进制)
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_write_hex(int icdev, int adr, [In] string sdata);  
        /// <summary>
        /// 从卡中读数据
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [Out] byte[] sdata);
        /// <summary>
        /// 从卡中读数据
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  
        /// <summary>
        /// 从卡中读数据(转换为16进制)
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="adr"></param>
        /// <param name="sdata"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  
        /// <summary>
        /// 普通字符转换成十六进制字符
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern int a_hex(string oldValue, ref string newValue, Int16 len);  
        /// <summary>
        /// 十六进制字符转换成普通字符
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="len"></param>
        [DllImport("D3_DLL\\dcrf32.dll")]
        public static extern void hex_a(ref string oldValue, ref string newValue, int len);  
        #endregion
    }
}
