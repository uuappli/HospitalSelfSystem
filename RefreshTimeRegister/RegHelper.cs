
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Management;
using System.Collections.Generic;
namespace RefreshTimeRegister
{
    public sealed class RegHelper
    {
        private string _organization, _validity, _currentMachine, _publicKey, _signature;

        public string Validity
        {
            get { return _validity; }
        }

        public string Organization
        {
            get { return _organization; }
        }

        private RSACryption myRSA = new RSACryption();

        public RegHelper()
        {
            GetRegInfo();
        }

        #region 注册表操作

        private void GetInfo()
        {
            _organization = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Organization", "Err").ToString();
            _validity = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Validity", "Err").ToString();
            _currentMachine = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Machine", "Err").ToString();
            _publicKey = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "PublicKey", "Err").ToString();
            _signature = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Signature", "Err").ToString();
        }

        private void SetRegInfo(string Organization, string Validity, string MachineCode, string PublicKey, string Signature)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Organization", Organization);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Validity", Validity);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Machine", MachineCode);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "PublicKey", PublicKey);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\SoftAuthor", "Signature", Signature);
        }

        /// <summary>
        /// 从注册表中获取机构、期限信息
        /// </summary>
        private void GetRegInfo()
        {
            try
            {
                GetInfo();
            }
            catch
            {
                SetRegInfo("未注册用户", DateTime.Now.ToString(), MachineCode, "", "");
                GetInfo();
            }
        }

        #endregion

        #region 如果为单用户通过机器码获取注册码

        /// <summary>
        /// 获取CPUID
        /// </summary>
        /// <returns></returns>
        private string GetCpuID()
        {
            try
            {
                string cpuInfo = "";//cpu序列号   
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
        }

        #region 未处理移动盘

        ///// <summary>
        ///// 获取硬盘ID
        ///// </summary>
        ///// <returns></returns>
        //private string GetDiskID()
        //{
        //    try
        //    {
        //        String HDid = "";
        //        ManagementClass mc = new ManagementClass("Win32_DiskDrive");
        //        ManagementObjectCollection moc = mc.GetInstances();
        //        foreach (ManagementObject mo in moc)
        //        {
        //            HDid = (string)mo.Properties["Model"].Value;
        //        }
        //        moc = null;
        //        mc = null;
        //        return HDid;
        //    }
        //    catch
        //    {
        //        return "unknow";
        //    }
        //}

        #endregion

        /// <summary> 
        /// 获取网卡物理地址 
        /// </summary> 
        /// <returns></returns> 
        private string GetMacAddr()
        {
            try
            {
                string madAddr = null;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                    {
                        madAddr = mo["MacAddress"].ToString();
                        madAddr = madAddr.Replace(':', '-');
                    }
                    mo.Dispose();
                }
                return madAddr;
            }
            catch
            {
                return null;
            }
        }

        internal string MachineCode
        {
            get
            {
                return MD5Crytion.Encrypt(GetCpuID() + GetMacAddr()).ToUpper();
            }
        }

        #endregion

        #region 验证信息
        /// <summary>
        /// 验证是否为当前机器
        /// </summary>
        /// <param name="RegString"></param>
        /// <returns></returns>
        private bool IsCurrentMachine
        {
            get
            {
                return _currentMachine == MachineCode ? true : false;
            }
        }

        /// <summary>
        /// 效期是否有效
        /// </summary>
        private bool IsValidity
        {
            get
            {
                DateTime Rst = DateTime.Now;
                DateTime.TryParse(_validity, out Rst);
                return TimeSpan.Compare(new TimeSpan(Rst.Ticks), new TimeSpan(DateTime.Now.Ticks)) > 0 ? true : false;
            }
        }

        internal bool IsCheckOut(string RegInfo)
        {
            try
            {
                string BaseInfo = "", HashData = "", organization = "", validity = "", machineCode = "", publicKey = "", signature = "";
                string[] Reg = AES.AESDecrypt(RegInfo, "23686922SKYNETDEV1F04DFA4DB538").Split('|');
                organization = Reg[1];
                validity = Reg[2];
                machineCode = Reg[3];
                publicKey = Reg[4];
                signature = Reg[5];
                BaseInfo = "RegistrationInfo:|" + organization + "|" + validity + "|" + machineCode + "|" + publicKey + "|";
                myRSA.GetHash(BaseInfo, ref HashData);
                if (myRSA.SignatureDeformatter(publicKey, HashData, signature))
                {
                    SetRegInfo(organization, validity, machineCode, publicKey, signature);
                    GetInfo();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private bool checkInfo()
        {
            try
            {
                string BaseInfo = "", HashData = "";
                BaseInfo = "RegistrationInfo:|" + _organization + "|" + _validity + "|" + _currentMachine + "|" + _publicKey + "|";
                myRSA.GetHash(BaseInfo, ref HashData);
                if (myRSA.SignatureDeformatter(_publicKey, HashData, _signature))
                {
                    //是否需要判断独立机器使用
                    if (!IsCurrentMachine)
                    {
                        MessageBox.Show("非当前机器注册信息，请核对", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //注释段
                    else if (!IsValidity)
                    {
                        MessageBox.Show("授权时间已经到期，请注册", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    MessageBox.Show("注册信息不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("注册信息不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 校验注册信息
        /// </summary>
        /// <returns></returns>
        public bool CheckRegInfo()
        {
            if (!checkInfo())
            {
                new FrmRegister().ShowDialog();
                return false;
            }
            else
                return true;
        }

        #endregion

    }
}
