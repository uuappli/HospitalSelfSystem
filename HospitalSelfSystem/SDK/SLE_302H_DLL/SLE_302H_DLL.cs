using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoRegisterManager
{
    public class SLE_302H_DLL
    {
        /// <summary>
        ///   功能：初始化串口,并且打开串口
        /// 返回值：整型
        ///     = 1：正确。     
        ///      -1：串口打开失败
        ///      -2：串口设置错误
        ///      -4：(发给动态库的)命令参数错         
        ///   参数：
        ///      set: 字符串,用来设置串口
        ///     格式:  "1,9600,N,8,1" 
        ///     ------ (1=com1或2=com2),
        ///     (9600=baud9600或4800=baud4800或2400=baud2400或1200=baud1200),
        ///     (N=无校验或O=奇校验或E=偶校验),
        ///     (8=8个数据位或7=7个数据位),
        ///     (1=1个停止位或2=2个停止位).	    			
        ///       如:   "1,9600,N,8,1" 
        ///     表示:  串口1,波特率9600.无校验,8个数据位,1个停止位.
        /// </summary>
        /// <param name="set">字符串,用来设置串口</param>
        /// <returns></returns>
        [DllImport("SLE_302H_DLL\\ICcard_dll.dll")]
        public static extern int Init_com(StringBuilder set);

        /// <summary>
        /// 关闭Init_com函数打开的串口.
        /// </summary>
        /// <returns></returns>
        [DllImport("SLE_302H_DLL\\ICcard_dll.dll")]
        public static extern void close_com();

        /// <summary>
        /// 功能:控制磁卡读写机进行写磁卡操作,按 ESC 键可退出
        /// 
        /// "磁道1数据"	           
        ///     ------  写第1轨数据（此时 track 为1）
        ///"磁道2数据"            
        ///     ------  写第2轨数据（此时 track 为2）  	    
        ///"磁道3数据"            
        ///     ------  写第3轨数据（此时 track 为3）
        ///"磁道2数据a磁道1数据"  
        ///     ------写第2轨数据和第1轨数据（此时 track 为4,小写字符a
        ///作为磁道2和磁道1的数据的分隔符）  	  
        ///"磁道2数据a磁道3数据"  
        ///     ------写第2轨数据和第3轨数据（此时 track 为5,小写字符a
        ///作为磁道2和磁道3的数据的分隔符）

        ///其中: 小写字符a为磁道2与磁道1（或磁道2与磁道3）的数据的分隔符
        ///1轨数据可为字母或数字,最多76个
        ///2轨数据只可为数字,最多104个 	
        ///3轨数据只可为数字,最多104个

        ///如:   Wcard("1111111111",1)
        /// -------- 表示向第1磁轨中写入数据：1111111111

        ///Wcard("2222222222",2)
        /// -------- 表示向第2磁轨中写入数据：2222222222

        ///Wcard("3333333333",3)
        /// -------- 表示向第3磁轨中写入数据：3333333333

        ///Wcard("2222222222a1111111111",4)
        /// -------- 表示向第2磁轨中写入数据：2222222222 
        ///并且向第1磁轨中写入数据：1111111111

        ///Wcard("2222222222a3333333333",5)
        ///-------- 表示向第2磁轨中写入数据：2222222222 
        ///并且向第3磁轨中写入数据：3333333333 
        /// </summary>
        /// <param name="setdata">字符串,所要向卡上写的数据</param>
        /// <param name="track">1：选择第1磁轨 	 2：选择第2磁轨	 3：选择第3磁轨  4：选择第2和第1磁轨  5：选择第2和第3磁轨</param>
        /// <returns>	1: 写卡正确  -1：串口打开失败 -3:：串口没有打开 -4：(发给动态库的)命令参数错 -5： 与磁卡读写机通信失败(磁卡机没有与主机连接或连接不正确)-6： 操作超时,退出操作-7： 按 ESC 键退出当前操作 -8：写磁卡失败</returns>
        [DllImport("SLE_302H_DLL\\ICcard_dll.dll")]
        public static extern int Wcard(StringBuilder setdata, int track);

        /// <summary>
        /// 控制磁卡读写机进行读磁卡操作,按 ESC 键可退出.
        /// 
        /// 读卡成功返回格式(Rcard函数返回值为1): 
        ///getdata = "磁道1数据" 	     			 
        ///------- 返回磁道1数据（此时 track 为1）
        ///getdata = "磁道2数据"             
        ///------- 返回磁道2数据（此时 track 为2）	          
        ///getdata = "磁道3数据"             
        ///------- 返回磁道3数据（此时 track 为3）
        ///getdata = "磁道2数据a磁道1数据"   
        ///------- 返回磁道2数据和磁道1数据（此时 track 为4）
        ///getdata = "磁道2数据a磁道3数据"   
        ///------- 返回磁道2数据和磁道3数据（此时 track 为5）     

        ///其中: 小写字符a为磁道2与磁道1（或磁道2与磁道3）的数据的分隔符

        ///如：
        ///Rcard(getdata,1)
        ///-------- 表示从第1磁轨中读取数据（存放在getdata中）

        ///Rcard(getdata,2)
        ///-------- 表示从第2磁轨中读取数据（存放在getdata中）     

        ///Rcard(getdata,3)
        ///-------- 表示从第3磁轨中读取数据（存放在getdata中） 

        ///Rcard(getdata,4)
        ///-------- 表示从第2磁轨和第1磁轨中读取数据
        ///（存放在getdata中，中间以小写字符a作分隔）    

        ///Rcard(getdata,5)
        ///-------- 表示从第2磁轨和第3磁轨中读取数据
        ///（存放在getdata中，中间以小写字符a作分隔） 
        /// </summary>
        /// <param name="getdata">读卡数据输出缓冲区（用于存放读卡成功后的返回数据）字符串,长度不少于300字节.</param>
        /// <param name="track">1：选择第1磁轨 	 2：选择第2磁轨	 3：选择第3磁轨  4：选择第2和第1磁轨  5：选择第2和第3磁轨</param>
        /// <returns>	1: 写卡正确  -1：串口打开失败 -3:：串口没有打开 -4：(发给动态库的)命令参数错 -5： 与磁卡读写机通信失败(磁卡机没有与主机连接或连接不正确)-6： 操作超时,退出操作-7： 按 ESC 键退出当前操作 -8：写磁卡失败</returns>
        [DllImport("SLE_302H_DLL\\ICcard_dll.dll")]
        public static extern int Rcard(StringBuilder getdata, int track);

    }
}