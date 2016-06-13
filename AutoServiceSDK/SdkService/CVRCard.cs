using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using AutoServiceSDK.SdkData;
using AutoServiceSDK.SDK;
using AutoServiceSDK.ISdkService;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 精致思达身份证读卡器
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public unsafe class CVRCard:IIdentityCardService
    {
        int iRetUSB = 0;

        /// <summary>
        /// 得到身份证信息
        /// </summary>
        /// <returns>身份证信息实体</returns>
        public IDCardInfo FillData()
        {
            try
            {
                IDCardInfo cardInfo = new IDCardInfo();
               // cardInfo.ImagePath = Application.StartupPath + "\\zp.bmp";
                byte[] name = new byte[30];
                int length = 30;
                CVR_IDENTITY_DLL.GetPeopleName(ref name[0], ref length);
                //MessageBox.Show();
                byte[] number = new byte[30];
                length = 36;
                CVR_IDENTITY_DLL.GetPeopleIDCode(ref number[0], ref length);
                byte[] people = new byte[30];
                length = 3;
                CVR_IDENTITY_DLL.GetPeopleNation(ref people[0], ref length);
                byte[] validtermOfStart = new byte[30];
                length = 16;
                CVR_IDENTITY_DLL.GetStartDate(ref validtermOfStart[0], ref length);
                byte[] birthday = new byte[30];
                length = 16;
                CVR_IDENTITY_DLL.GetPeopleBirthday(ref birthday[0], ref length);
                byte[] address = new byte[30];
                length = 70;
                CVR_IDENTITY_DLL.GetPeopleAddress(ref address[0], ref length);
                byte[] validtermOfEnd = new byte[30];
                length = 16;
                CVR_IDENTITY_DLL.GetEndDate(ref validtermOfEnd[0], ref length);
                byte[] signdate = new byte[30];
                length = 30;
                CVR_IDENTITY_DLL.GetDepartment(ref signdate[0], ref length);
                byte[] sex = new byte[30];
                length = 3;
                CVR_IDENTITY_DLL.GetPeopleSex(ref sex[0], ref length);

                cardInfo.Address = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0","").Trim();
                cardInfo.Sex = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0","").Trim();
                cardInfo.Birthday = System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0","").Trim();
                cardInfo.Signdate = System.Text.Encoding.GetEncoding("GB2312").GetString(signdate).Replace("\0","").Trim();
                cardInfo.Number = System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0","").Trim();
                cardInfo.Name = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0","").Trim();
                cardInfo.People = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0","").Trim();
                cardInfo.ValidDate = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfStart).Replace("\0","").Trim()+ "-" + System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfEnd).Replace("\0","").Trim();
                return cardInfo;

            }
            catch (Exception ex)
            {
               throw new  Exception(ex.ToString());
            }
        }
       

        //扫描结构：
        [StructLayout(LayoutKind.Sequential, Size = 16, CharSet = CharSet.Ansi)]
        public struct IDCARD_ALL
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char name;     //姓名
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
            public char sex;      //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public char people;    //民族，护照识别时此项为空
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char birthday;   //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 70)]
            public char address;  //地址，在识别护照时导出的是国籍简码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public char number;  //地址，在识别护照时导出的是国籍简码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
            public char signdate;   //签发日期，在识别护照时导出的是有效期至 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfStart;  //有效起始日期，在识别护照时为空
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public char validtermOfEnd;  //有效截止日期，在识别护照时为空
        }


        #region IIdentityCardService 成员
        /// <summary>
        /// 打开身份证读卡器端口
        /// </summary>
        /// <returns>true成功 false失败</returns>
        public bool OpenPort()
        {
            try
            {
                int iPort = 1001;
                iRetUSB = CVR_IDENTITY_DLL.CVR_InitComm(iPort);
                if (iRetUSB == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <returns>身份证信息实体</returns>
        public IDCardInfo ReadCard()
        {
            try
            {


                int authenticate = CVR_IDENTITY_DLL.CVR_Authenticate();
                if (authenticate == 1)
                {
                    int readContent = CVR_IDENTITY_DLL.CVR_Read_Content(2);
                    if (readContent == 1)
                    {
                        return FillData();
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
       public bool ClosePort()
        {
            try
            {
                CVR_IDENTITY_DLL.CVR_CloseComm();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return true;
        }

        #endregion
    }
}
