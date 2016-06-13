using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoRegisterManager.SDK
{
    public class DPrinter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port">串口初始化，在使用之前调用一次，参数为串口通道号，串口一为0</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "COMInit")]
        public static extern short ComInit(char port);
        /// <summary>
        /// 打印模式
        /// </summary>
        /// <param name="type">	Type-模式设置：1个字节，Bit0~Bit7
        //            Bit0：为0：Font A(12*24)；为1：Font B(9*17)
        //            Bit1：未定义
        //Bit2：未定义
        //            Bit3：为0：正常打印；为1：加黑打印
        //Bit4：为0：正常高度；为1：双倍高度
        //            Bit5：为0：正常宽度；为1：双倍宽度
        //Bit6：未定义
        //        Bit7：为0：不加下划线；为1：加下划线	</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "PrintMode")]
        public static extern short PrintMode(int type);

        /// <summary>
        /// 设置行距
        /// </summary>
        /// <param name="space">Space—>间距值：间距=Space*0.125mm；系统默认值为30，0 ≤ Space ≤ 255 ；</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "SetLineSpace")]
        public static extern short SetLineSpace(char space);
        /// <summary>
        /// 设置字号
        /// </summary>
        /// <param name="size">Size—>字号：一个字节，Bit0~Bit7，0 ≤ Size ≤ 255；</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "SetFontSize")]
        public static extern int SetFontSize(char size);
        /// <summary>
        /// 设置对齐方式
        /// </summary>
        /// <param name="mode">Mode—>对齐方式：0左对齐；1居中；2右对齐</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "JustMode")]
        public static extern int JustMode(char mode);
        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="nl">nL，nH：各为一个字节，左边距=(nL+nH*256)*0.125mm</param>
        /// <param name="nh"></param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "SetLMargin")]
        public static extern int SetLMargin(int nl,int nh);

        /// <summary>
        /// 换行
        /// </summary>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "LineFeed")]
        public static extern short LineFeed();
        /// <summary>
        /// 空多行
        /// </summary>
        /// <param name="nlinem">设置要空的行数</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "FeedNline")]
        public static extern int FeedNline(int nlinem);

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="line">自打印头位置开始的行</param>
        /// <param name="row">从左至右开始的位置，单位：mm</param>
        /// <param name="content">打印的内容</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "Sprint", CharSet = CharSet.Ansi)]//设置其他编码方式会乱码
        public static extern short Sprint(char line, char row, string content);

        /// <summary>
        /// 切纸
        /// </summary>
        /// <param name="space">留下距离在切，单位：mm</param>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "CutPaper")]
        public static extern short CutPaper(char space);

        /// <summary>
        /// 获取打印机状态
        /// </summary>
        /// <returns></returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "GetPRNState")]
        public static extern short GetPRNState();

        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <returns>0成功  1失败</returns>
        [DllImport("Print\\PrintApi.dll", EntryPoint = "InitPrinter")]
        public static extern short InitPrinter();
    }

}
