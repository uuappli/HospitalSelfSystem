using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoServiceSDK.SDK
{
    public class M100_DLL
    {
        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "CRTInit", CharSet = CharSet.Ansi)]////port为串口号(从0开始),Type为卡机内有卡的处理方式,0保持,1前退卡,2后退卡
        public static extern int CRTInit(int port, int Type);

        /*CardIn:设置前端进卡方式
1 	禁止前端进卡
2		磁卡方式进卡使能
3		开关方式进卡使能,允许磁卡, ic卡,m1卡等
4		磁信号方式进卡,针对磁薄卡等一些纸卡进卡
EnableBackIn:设置是否允许后端进卡
0 	允充后端进卡
1		禁止后端进卡
*/
        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "CardSetting", CharSet = CharSet.Ansi)]//设置前端进卡方式
        public static extern int CardSetting(int CardIn, int EnableBackIn);



        /*
	atPosition:	=0x30：卡片在前端不夹卡位置。
				=0x31：卡片在前端夹卡位置。
				=0x32：卡片在读卡机射频卡位置。
				=0x33：卡片在IC卡位置。
				=0x34：卡片在后端夹卡位置。
				=0x35：读卡机内无卡。
				=0x36：卡不在标准位置
*/
        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "GetCardReaderStatus", CharSet = CharSet.Ansi)]
        public static extern int GetCardReaderStatus(byte[] atPosition);

        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "Eject", CharSet = CharSet.Ansi)]
        public static extern int Eject();

        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "reject", CharSet = CharSet.Ansi)]
        public static extern int reject();

        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "ReadMagCard", CharSet = CharSet.Ansi)]
        public static extern int ReadMagCard(StringBuilder track1, StringBuilder track2, StringBuilder track3);

        [DllImport("CRTAPI\\CrtApi.dll", EntryPoint = "IntakeCard", CharSet = CharSet.Ansi)]
        public static extern int IntakeCard(int timeout);
    }
}
