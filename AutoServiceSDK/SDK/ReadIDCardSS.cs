using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;
using System.IO;
using System.Collections;

/// <summary>
/// 读取二代身份证 卡机型号：ICR-100M(B)
/// </summary>
/// <remarks>
/// 作者：陈昭
/// 
/// 版本 ： 1.0.0.0
/// 
/// 开发时间 ： 2010-05-06
/// 
/// 最后修改人：
/// 
/// 最后修改时间：
/// </remarks>
namespace AutoServiceSDK.SDK
{
    public class Human
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNo { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        public string IssuingGovernment { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public string InceptDate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public string ExpireDate { get; set; }

        /// <summary>
        /// 照片地址
        /// </summary>
        public string PhotoLocation { get; set; }

        /// <summary>
        /// 最后地址
        /// </summary>
        public string LastAddress { get; set; }
    }

    public enum ReadType
    {
        读基本信息=1,
        只读文字信息=2,
        读最新住址信息=3
    }

    public class ReadEventArgs : EventArgs
    {
        public Human NewHuman { get; set; }
        public ReadEventArgs(Human human)
        {
            NewHuman = human;
        }
    }

    public class ReadErrorEventArgs : EventArgs
    {
        public string Error { get; set; }
        public ReadErrorEventArgs(string error)
        {
            Error = error;
        }
    }

    public class ReadIDCardSS
    {
        //[DllImport("termb.dll")]
        //private static extern int InitComm(int Port);

        //[DllImport("termb.dll")]
        //private static extern int InitCommExt();

        //[DllImport("termb.dll")]
        //private static extern int CloseComm();

        //[DllImport("termb.dll")]
        //private static extern int Authenticate();

        //[DllImport("termb.dll")]
        //private static extern int Read_Content(int Active);

        //[DllImport("termb.dll")]
        //private static extern int Read_Content_Path(string cPath, int Active);

        //[DllImport("termb.dll")]
        //private static extern int GetSAMID(string cSAMID);


        [DllImport("TanReadCard.dll")]
        private static extern int OpenComm();

        [DllImport("TanReadCard.dll")]
        private static extern int CloseComm();

        [DllImport("TanReadCard.dll")]
        private static extern int ReadCard();

        private volatile bool _isRun;

        public bool IsRun
        {
            get { return _isRun; }
            set { _isRun = true; }
        }

        private Hashtable _nation;
        private BackgroundWorker _backgroundWorker;

        /// <summary>
        /// 读取信息后
        /// </summary>
        public event EventHandler<ReadEventArgs> OnReadedInfo;

        /// <summary>
        /// 发生错误
        /// </summary>
        public event EventHandler<ReadErrorEventArgs> OnReadError;

        private ReadIDCardSS()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;

            _backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);

            _nation = new Hashtable();

            _nation.Add("01", "汉");
            _nation.Add("02", "蒙古");
            _nation.Add("03", "回");
            _nation.Add("04", "藏");
            _nation.Add("05", "维吾尔");
            _nation.Add("06", "苗");
            _nation.Add("07", "彝");
            _nation.Add("08", "壮");
            _nation.Add("09", "布依");
            _nation.Add("10", "朝鲜");
            _nation.Add("11", "满");
            _nation.Add("12", "侗");
            _nation.Add("13", "瑶");
            _nation.Add("14", "白");
            _nation.Add("15", "土家");
            _nation.Add("16", "哈尼");
            _nation.Add("17", "哈萨克");
            _nation.Add("18", "傣");
            _nation.Add("19", "黎");
            _nation.Add("20", "傈僳");
            _nation.Add("21", "佤");
            _nation.Add("22", "畲");
            _nation.Add("23", "高山");
            _nation.Add("24", "拉祜");
            _nation.Add("25", "水");
            _nation.Add("26", "东乡");
            _nation.Add("27", "纳西");
            _nation.Add("28", "景颇");
            _nation.Add("29", "柯尔克孜");
            _nation.Add("30", "土");
            _nation.Add("31", "达翰尔");
            _nation.Add("32", "仫佬");
            _nation.Add("33", "羌");
            _nation.Add("34", "布朗");
            _nation.Add("35", "撒拉");
            _nation.Add("36", "毛南");
            _nation.Add("37", "仡佬");
            _nation.Add("38", "锡伯");
            _nation.Add("39", "阿昌");
            _nation.Add("40", "普米");
            _nation.Add("41", "塔吉克");
            _nation.Add("42", "怒");
            _nation.Add("43", "乌孜别克");
            _nation.Add("44", "俄罗斯");
            _nation.Add("45", "鄂温克");
            _nation.Add("46", "德昂");
            _nation.Add("47", "保安");
            _nation.Add("48", "裕固");
            _nation.Add("49", "京");
            _nation.Add("50", "塔塔尔");
            _nation.Add("51", "独龙");
            _nation.Add("52", "鄂伦春");
            _nation.Add("53", "赫哲");
            _nation.Add("54", "门巴");
            _nation.Add("55", "珞巴");
            _nation.Add("56", "基诺");
            _nation.Add("57", "其它");
            _nation.Add("98", "外国人入籍");
        }

        private static ReadIDCardSS _instance = null;
        public static ReadIDCardSS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReadIDCardSS();
                }
                return _instance;
            }
        }


        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] obj = e.UserState as object[];
            switch (obj[0].ToString())
            {
                case "AllInfo":
                case "StringInfo":
                case "LastAddress":
                    if (OnReadedInfo != null)
                    {
                        OnReadedInfo(this, new ReadEventArgs((Human)obj[1]));
                    }
                    break;
                case "error":
                    if (OnReadError != null)
                    {
                        if (!obj[1].ToString().StartsWith("读卡错误"))
                        {
                            OnReadError(this, new ReadErrorEventArgs(obj[1].ToString()));
                        }
                    }
                    _backgroundWorker.CancelAsync();
                    break;

                default:
                    break;
            }
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (OpenComm() == 0)
                {
                    while (_isRun)
                    {
                        if (_isRead)
                        {
                            Thread.Sleep(1500);
                            continue;
                        }

                        string error = ReadCard((ReadType)e.Argument);

                        if (error == "OK")
                        {
                            Human human = new Human();
                            string text = string.Empty;

                            switch ((ReadType)e.Argument)
                            {
                                case ReadType.读基本信息:
                                case ReadType.只读文字信息:
                                    text = File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "WZ.TXT", Encoding.Unicode);

                                    human.Name = text.Substring(0, 15).Trim();
                                    text = text.Substring(15);

                                    switch (text.Substring(0, 1))
                                    {
                                        case "0":
                                            human.Gender = "未知";
                                            break;
                                        case "1":
                                            human.Gender = "男";
                                            break;
                                        case "2":
                                            human.Gender = "女";
                                            break;
                                        case "9":
                                            human.Gender = "未说明";
                                            break;
                                        default:
                                            break;
                                    }
                                    text = text.Substring(1);

                                    human.Nation = _nation[text.Substring(0, 2)].ToString();
                                    text = text.Substring(2);

                                    string temp = text.Substring(0, 8);
                                    temp = temp.Substring(0, 4) + "." + temp.Substring(4, 2) + "." + temp.Substring(6, 2);
                                    human.BirthDay = Convert.ToDateTime(temp);
                                    text = text.Substring(8);

                                    human.Address = text.Substring(0, 35).Trim();
                                    text = text.Substring(35);

                                    human.IDCardNo = text.Substring(0, 18);
                                    text = text.Substring(18);

                                    human.IssuingGovernment = text.Substring(0, 15).Trim();
                                    text = text.Substring(15);

                                    human.InceptDate = text.Substring(0, 8);
                                    human.InceptDate = human.InceptDate.Substring(0, 4) + "." + human.InceptDate.Substring(4, 2) + "." + human.InceptDate.Substring(6, 2);
                                    text = text.Substring(8);

                                    human.ExpireDate = text.Substring(0, 8).Trim();
                                    if (human.ExpireDate != "长期")
                                    {
                                        human.ExpireDate = human.ExpireDate.Substring(0, 4) + "." + human.ExpireDate.Substring(4, 2) + "." + human.ExpireDate.Substring(6, 2);
                                    }
                                    text = text.Substring(8);


                                    if ((ReadType)e.Argument == ReadType.只读文字信息)
                                    {
                                        _backgroundWorker.ReportProgress(0, new object[] { "StringInfo", human });
                                    }
                                    else
                                    {
                                        human.PhotoLocation = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ZP.BMP";
                                        _backgroundWorker.ReportProgress(0, new object[] { "AllInfo", human });
                                    }
                                    break;
                                case ReadType.读最新住址信息:
                                    text = File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "NEWADD.TXT", Encoding.Unicode);
                                    human.LastAddress = text.Trim();
                                    _backgroundWorker.ReportProgress(0, new object[] { "LastAddress", human });
                                    break;
                            }
                        }
                        else
                        {
                            _backgroundWorker.ReportProgress(0, new object[] { "error", error });
                        }


                        Thread.Sleep(1500);
                    }

                    CloseComm();
                }
                else
                {
                    _backgroundWorker.ReportProgress(0, new object[] { "error", "设备初始化失败，请检查设备是否正常接入！" });
                }
            }
            catch (Exception ex)
            {
                _isRun = false;
                _backgroundWorker.ReportProgress(0, new object[] { "error", ex.Message });
            }
        }

        private string ReadCard(ReadType readType)
        {
            switch (ReadCard())
            {
                case 1:
                    return "机具无法打开!";
                case 2:
                    return "读卡生成文件不存在!";
                case 3:
                    return "验证卡失败!";
                case -1:
                    return "相片解码错误!";
                case -2:
                    return "wlt文件后缀错误!";
                case -3:
                    return "wlt文件打开错误!";
                case -4:
                    return "wlt文件格式错误!";
                case -5:
                    return "软件未授权!";
                case -6:
                    return "设备连接错误!";
                case -7:
                    return "未知错误!";

                default:
                    return "OK";
            }
        }

        public void Start(ReadType readType)
        {
            if(!_isRun && !_backgroundWorker.IsBusy)
            {
                _isRun = true;
                _backgroundWorker.RunWorkerAsync(readType);
            }
        }

        public void Over()
        {
            _isRun = false;
        }

        /// <summary>
        /// 是否注册过事件
        /// </summary>
        public bool IsRegister
        {
            get
            {
                return OnReadedInfo != null && OnReadError != null;
            }
        }

        bool _isRead = false;
        public Human ReadCardRun()
        {
            Human hm = null;
            CloseComm();
            _isRead = true;
            if (OpenComm() == 0)
            {
                Thread.Sleep(310);
             
                    string error = ReadCard(ReadType.读基本信息);
                    if (error == "OK")
                    {
                        hm = readinfo(ReadType.读基本信息);
                    }
                
            }
            if (CloseComm() == 1)
            {
                OpenComm();
            }
            _isRead = false;
            return hm;
        }

        private Human readinfo(ReadType type)
        {

            Human human = new Human();
            string text = string.Empty;

            switch (type)
            {
                case ReadType.读基本信息:
                case ReadType.只读文字信息:
                    text = File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "WZ.TXT", Encoding.Unicode);

                    human.Name = text.Substring(0, 15).Trim();
                    text = text.Substring(15);

                    switch (text.Substring(0, 1))
                    {
                        case "0":
                            human.Gender = "未知";
                            break;
                        case "1":
                            human.Gender = "男";
                            break;
                        case "2":
                            human.Gender = "女";
                            break;
                        case "9":
                            human.Gender = "未说明";
                            break;
                        default:
                            break;
                    }
                    text = text.Substring(1);

                    human.Nation = _nation[text.Substring(0, 2)].ToString();
                    text = text.Substring(2);

                    string temp = text.Substring(0, 8);
                    temp = temp.Substring(0, 4) + "." + temp.Substring(4, 2) + "." + temp.Substring(6, 2);
                    human.BirthDay = Convert.ToDateTime(temp);
                    text = text.Substring(8);

                    human.Address = text.Substring(0, 35).Trim();
                    text = text.Substring(35);

                    human.IDCardNo = text.Substring(0, 18);
                    text = text.Substring(18);

                    human.IssuingGovernment = text.Substring(0, 15).Trim();
                    text = text.Substring(15);

                    human.InceptDate = text.Substring(0, 8);
                    human.InceptDate = human.InceptDate.Substring(0, 4) + "." + human.InceptDate.Substring(4, 2) + "." + human.InceptDate.Substring(6, 2);
                    text = text.Substring(8);

                    human.ExpireDate = text.Substring(0, 8).Trim();
                    if (human.ExpireDate != "长期")
                    {
                        human.ExpireDate = human.ExpireDate.Substring(0, 4) + "." + human.ExpireDate.Substring(4, 2) + "." + human.ExpireDate.Substring(6, 2);
                    }
                    text = text.Substring(8);




                    break;
                case ReadType.读最新住址信息:
                    text = File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "NEWADD.TXT", Encoding.Unicode);
                    human.LastAddress = text.Trim();

                    break;

            }
            return human;
        }
    }
}
