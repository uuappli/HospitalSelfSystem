using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;//这是用到DllImport时候要引入的包

namespace AutoServiceSDK.SDK
{
    /// <summary>
    /// 身份证阅读类
    /// </summary>
    public class CVR_IDENTITY_DLL
    {
        [DllImport("IDCard\\termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//声明外部的标准动态库, 跟Win32API是一样的
        [DllImport("IDCard\\termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Authenticate();
        [DllImport("IDCard\\termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);
        [DllImport("IDCard\\termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_CloseComm();
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern unsafe int GetPeopleName(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);
        [DllImport("IDCard\\termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);


    }

}
