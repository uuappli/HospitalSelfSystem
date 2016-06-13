using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    #region 附录一（错误代码表）
    //    返回名称	 返回值	说明
    //Re_NONE	0	没有发生错误
    //RE_TIMEOUT	F1	通讯超时
    //RE_SYNC	F2	SYN信号错误
    //RE_DATA	F3	接收数据失败
    //RE_CRC	F4	CRC错误
    //ER_NAK	F5	设备无回应
    //ER_INVALID_CMD	F6	无效命令
    //ER_EXECUTION	F7	执行错误回应
    //ERR_INVALID_STATE	F8	设备回应状态无效
    #endregion
    #region 附录二
    //00H    Forbidden
    //01H    Bill-to-Bill unit
    //02H    Coin Changer
    //03H    Bill Validator
    //04H    Card Reader
    //05H    Reserved for Future Standard Peripherals
    //.    .
    //.    .
    //.    .
    //0DH    Reserved for Future Standard Peripherals
    //0EH    Reserved for Future Broadcast Transmissions
    //0FH    Reserved for Future Standard Peripherals
    #endregion
    
    /// <summary>
    /// 精致思达自助设备驱动
    /// 模块：纸币器模块
    /// 作者：田虎
    /// DATE：2012-03-01
    /// </summary>
    public class CASHCODE_MONEY_DLL
    {
        /// <summary>
        /// 纸币器初始化
        /// </summary>
        /// <param name="port">设备端口号，如串口１，port=1;</param>
        /// <returns> 成功返回零，失败返回其它值</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern int InitComm(int port);
        /// <summary>
        /// 发送RESET命令,重新初始化设备
        /// </summary>
        /// <param name="adr">
        /// Addr  BYTE  设备标示,详见附录二
        /// </param>
        /// <returns>成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它</returns>
        [DllImport("Money\\CashCodeApi.dll", EntryPoint="ResetCMD", CharSet = CharSet.Auto)]
        public static extern byte ResetCMD(int adr);
        /// <summary>
        /// 发送POLL指令，使验钞设备处于激活状态
        /// </summary>
        /// <param name="adr">Addr  BYTE  设备标示,详见附录二</param>
        /// <param name="z1">用于保存接收数据的第三位数据</param>
        /// <param name="z2">用于保存接收数据的第四位数据</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", EntryPoint = "PollCMD", CharSet = CharSet.Auto)]
        public static extern byte PollCMD(int adr, ref byte z1, ref byte z2);

        /// <summary>
        /// 发送IDENTIFICATION 指令，获得产品Part No和Serial No
        /// </summary>
        /// <param name="adr">Addr  BYTE  设备标示,详见附录二</param>
        /// <param name="partNo">指向一个char 类型的数组，该数组用于保存设备part number</param>
        /// <param name="serNo">指向一个char 类型的数组，该数组用于保存设备Serial number</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它具体你可以参见附录一 错误代码说明</returns>
        /// 例子:	Char sPartNumber[20]=””,sSerialNumber[20]=””;  Identification(3, sPartNumber, sSerialNumber)
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern byte Identification(int adr, char[] partNo, char[] serNo);
        /// <summary>
        /// 发送GET STATUS 指令.
        /// </summary>
        /// <param name="adr">	设备标示，详细的说明请参见附录二</param>
        /// <param name="billStatus">	指向一个char类型的数组，该数组里存放的是设备发出的数据</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它 具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", EntryPoint = "CmdStatus", CharSet = CharSet.Auto)]
        public static extern byte CmdStatus(int adr, ref byte[] billStatus);

        /// <summary>
        /// 发送GET BILL TABLE指令。该指令是获得该Bill Validate设备所支持的所有纸币类型，从设备中将获得两个重要信息：纸币面值和纸币所属国家。
        /// </summary>
        /// <param name="adr">设备标示，详细的说明请参见附录二</param>
        /// <param name="dbill">指向BillTable结构体指针，</param>
        /// <returns></returns>
        [DllImport("Money\\CashCodeApi.dll", EntryPoint="GetBillTable")]
        public static extern byte GetBillTable(int adr, IntPtr dbill); 


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct dBILLTABLE
        {
            [MarshalAs(UnmanagedType.I4)]
            public int iCashValue;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
            public string sCountryCode;
        }
        /// <summary>
        ///  发送HOLD命令。允许控制器持有Bill Validator（验钞机）暂存10s,10s之后控制器就会发送RETURN或STACK指令。为了保持暂存状态，你必须重发这个命令，否则，Bill Validator将会退钞。
        /// </summary>
        /// <param name="adr">	设备标示，详细的说明请参见附录二</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它  具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern byte CmdHold(int adr);

        /// <summary>
        /// 	发送SET SECURITY指令，设置安全。
        /// </summary>
        /// <param name="adr">设备标示，详细的说明请参见附录二</param>
        /// <param name="ctldat">纸币类型的安全等级,3字节</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它  具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Ansi)]
        public static extern byte SetSecurity(int adr,  int[] ctldat);

        /// <summary>
        /// 发送ENABLE BILLTYPE指令，告诉控制器准备要验钞了。
        /// </summary>
        /// <param name="adr">设备标示，详细的说明请参见附录二</param>
        /// <param name="enBill">	一幅二进制位图，其中包含1的位置表示该编号的纸币类型有效。此处设置为：-1</param>
        /// <param name="disBill">	一幅二进制位图.此处设置为：0</param>
        /// <returns></returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Ansi)]
        public static extern byte CmdBillType(int adr,  int[] enBill, int[] disBill);

        /// <summary>
        /// 	发送STACK指令，这个指令将会导致验钞机发送纸币暂存位置让验钞盒关闭。
        /// </summary>
        /// <param name="adr">设备标示，详细的说明请参见附录二</param>
        /// <returns>	 成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern byte CmdStack(int adr);

        /// <summary>
        /// 发送RETURN指令，退钞。
        /// </summary>
        /// <param name="adr">	 BYTE  设备标示，详细的说明请参见附录二</param>
        /// <returns>	成功返回RE_NONE，否则返回ER_NAK、ER_INVALID_CMD或其它具体你可以参见附录一 错误代码说明</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern byte CmdReturn(int adr);

        /// <summary>
        /// 	关闭串口。
        /// </summary>
        /// <returns>	返回０成功，其它值失败</returns>
        [DllImport("Money\\CashCodeApi.dll", CharSet = CharSet.Auto)]
        public static extern byte ClosePort();


    }
}
