using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    public class K101_DLL
    {
        #region 发卡部分
        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CommOpen", CharSet = CharSet.Ansi)]//打开端口
        public static extern IntPtr K101_CommOpen(string port);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CommOpenWithBaud", CharSet = CharSet.Ansi)]//打开端口（设置固定波特率 默认9600）
        public static extern IntPtr K101_CommOpenWithBaud(string port, int data);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CommClose", CharSet = CharSet.Ansi)]
        public static extern int K101_CommClose(IntPtr ComHandle);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_GetSysVersion", CharSet = CharSet.Ansi)]
        public static extern int K101_GetSysVersion(IntPtr ComHandle, StringBuilder strVersion);



        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SetCommBaud", CharSet = CharSet.Ansi)]//关闭端口
        public static extern int K101_SetCommBaud(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _Baud, StringBuilder RecrodInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_AutoTestMachine", CharSet = CharSet.Ansi)]
        public static extern int K101_AutoTestMachine(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] _VerCode, StringBuilder RecrodInfo);


        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_Reset", CharSet = CharSet.Ansi)]
        public static extern int K101_Reset(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _PM, byte[] _VerCode, StringBuilder RecrodInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CheckCardPosition", CharSet = CharSet.Ansi)]
        public static extern int K101_CheckCardPosition(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] CardStates, StringBuilder RecrodInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CheckSensorStates", CharSet = CharSet.Ansi)]
        public static extern int K101_CheckSensorStates(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] SensorStates, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_CheckSensorVoltage", CharSet = CharSet.Ansi)]
        public static extern int K101_CheckSensorVoltage(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] SensorVoltage, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_EnterCard", CharSet = CharSet.Ansi)]
        public static extern int K101_EnterCard(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte EnterType, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_MoveCard", CharSet = CharSet.Ansi)]
        public static extern int K101_MoveCard(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _PM, StringBuilder RecordInfo);


        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_Eot", CharSet = CharSet.Ansi)]
        public static extern int K101_Eot(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_GetMachineID", CharSet = CharSet.Ansi)]
        public static extern int K101_GetMachineID(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte pMachineID, StringBuilder RecordInfo);

        #endregion

        //------磁卡操作函数------------------------------------------------------

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_ReadMagcardDecode", CharSet = CharSet.Ansi)]
        public static extern int K101_ReadMagcardDecode(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _track, byte[] _DataLen, StringBuilder _BlockData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_ReadMagcardUNDecode", CharSet = CharSet.Ansi)]
        public static extern int K101_ReadMagcardUNDecode(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _track, uint _DataLen, byte[] _BlockData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_ClearMagCardData", CharSet = CharSet.Ansi)]
        public static extern int K101_ClearMagCardData(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, StringBuilder RecordInfo);

        //-----------IC卡操作函数----------

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_AutoTestICCard", CharSet = CharSet.Ansi)]
        public static extern int K101_AutoTestICCard(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] _IcCardType, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_IcCardPowerOn", CharSet = CharSet.Ansi)]
        public static extern int K101_IcCardPowerOn(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _Voltage, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_IcCardPowerOff", CharSet = CharSet.Ansi)]
        public static extern int K101_IcCardPowerOff(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, StringBuilder RecordInfo);

        //-------------4442卡操作-----------------
        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4442VerifyPWD", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4442VerifyPWD(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] _PWData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4442Read", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4442Read(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, int _Address, int _DataLen, byte[] _BlockData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4442Write", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4442Write(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, int _Address, int _DataLen, byte[] _BlockData, StringBuilder RecordInfo);

        //-------------4428卡操作-----------------
        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4428VerifyPWD", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4428VerifyPWD(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte[] _PWData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4428Read", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4428Read(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, int _Address, int _DataLen, byte[] _BlockData, StringBuilder RecordInfo);

        [DllImport("K101_DLL\\K101_DLL.dll", EntryPoint = "K101_SLE4428Write", CharSet = CharSet.Ansi)]
        public static extern int K101_SLE4428Write(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, int _Address, int _DataLen, byte[] _BlockData, StringBuilder RecordInfo);


    }
}
