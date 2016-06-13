using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoServiceSDK.SdkData;

namespace AutoServiceSDK.ISdkService
{
    public interface IIdentityCardService
    {
        /// <summary>
        /// 打开身份证读卡器端口
        /// </summary>
        /// <returns></returns>
        bool OpenPort();
        /// <summary>
        /// 获取身份证信息
        /// </summary>
        /// <returns></returns>
        IDCardInfo ReadCard();
        /// <summary>
        /// 关闭身份证读卡器端口
        /// </summary>
        /// <returns></returns>
        bool ClosePort(); 
    }
}
