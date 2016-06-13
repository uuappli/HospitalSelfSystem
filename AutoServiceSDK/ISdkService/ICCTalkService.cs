using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoServiceSDK.ISdkService
{
   public interface ICCTalkService
    {
        /// <summary>
        /// 打开纸币器端口
        /// </summary>
        bool OpenPort(int port);
        /// <summary>
        /// 找零
        /// </summary>
        /// <returns>0成功，1失败</returns>
        int TakeMoney(int count);
        /// <summary>
        /// 关闭纸币器端口
        /// </summary>
        int ClosePort();
    }
}
