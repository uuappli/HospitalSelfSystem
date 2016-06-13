using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoServiceSDK.ISdkService
{
    public interface IMoneyService
    {
        /// <summary>
        /// 打开纸币器端口
        /// </summary>
         bool OpenPort();
        /// <summary>
        /// 得到进入纸币面额
        /// </summary>
        /// <returns>返回纸币面额</returns>
         int GetInMoney();
        /// <summary>
        /// 关闭纸币器端口
        /// </summary>
         bool ClosePort();
    }
}
