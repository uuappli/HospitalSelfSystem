using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Skynet.Framework.Common;
using System.Data;
using Skynet.Data;
using Skynet.ExceptionManagement;
using System.Data.SqlClient;
using HospitalSelfSystem.Properties;
using Oracle.DataAccess.Client;

namespace HospitalSelfSystem
{
    public class SkyComm
    {
        
        public static void Init()
        {
            Skynet.Data.PersistenceProperty.ConnectionString = ConnString;
            Skynet.Data.PersistenceProperty.DatabaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), Settings.Default.数据库类型);

            //SkyComm skyComm = new SkyComm();
            //skyComm.CreatCard("lxh", "lxh", "lxh", DateTime.Now, "lxh", "lxh", "lxh");
        }
     
    
        /// <summary>
        /// 根据生日得到年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static string getage(string birthday)
        {
            int age = DateTime.Today.Year - Convert.ToDateTime(birthday).Year;
            if (age > 0)
            {
                return age.ToString() + "岁";
            }
            else
            {
                int month = DateTime.Today.Month - Convert.ToDateTime(birthday).Month;
                if (month > 0)
                {
                    return month.ToString() + "月";
                }
                else
                {
                    int day = DateTime.Today.Day - Convert.ToDateTime(birthday).Day;
                    if (day >= 0)
                    {
                        return day.ToString() + "天";
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 卡信息查询
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public DataSet QueryCardInfo(string cardID)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardInfo WHERE 卡号 = '" + cardID + "'";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    QueryParameterCollection para;
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM V_CARDINFO WHERE 卡号 = :CARDNO";
                    para = new QueryParameterCollection(1);
                    para.Add(":CARDNO", cardID);
                    data.ExecuteDataset(sql, para, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

        /// <summary>
        /// 根据身份证号查询卡信息
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        public DataSet QueryCardInfoBySID(string sID)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardInfo WHERE 身份证号 = '" + sID + "'";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    QueryParameterCollection para;
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM V_CARDINFO WHERE 身份证号 = :SID";
                    para = new QueryParameterCollection(1);
                    para.Add(":SID", sID);
                    data.ExecuteDataset(sql, para, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

        /// <summary>
        /// 卡消费信息查询
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public DataSet QueryCardConsumeInfo(string cardID,DateTime qDate)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardConsumeInfo WHERE 卡号 = '" + cardID + "' and 消费日期 >='" + qDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    QueryParameterCollection para;
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardConsumeInfo WHERE 卡号 = :CARDNO and 消费日期 >= :QDATE";
                    para = new QueryParameterCollection();
                    para.Add(":CARDNO", cardID);
                    para.Add(":QDATE", qDate);
                    data.ExecuteDataset(sql, para, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

        /// <summary>
        /// 卡充值记录查询
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public DataSet QueryCardRechargeDetail(string cardID)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardRechargeDetail WHERE 卡号 = '" + cardID + "'";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    QueryParameterCollection para;
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_CardRechargeDetail WHERE 卡号 = :CARDNO";
                    para = new QueryParameterCollection(1);
                    para.Add(":CARDNO", cardID);
                    data.ExecuteDataset(sql, para, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

        /// <summary>
        /// 科室信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryDepartmentsInfo()
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_DepartmentsInfo";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_DepartmentsInfo";
                    data.ExecuteDataset(sql, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

        /// <summary>
        /// 医生信息
        /// </summary>
        /// <param name="officeid"></param>
        /// <returns></returns>
        public DataSet QueryDoctorInfo(string officeid)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {

                    string sql = "";
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_DoctorInfo where 所属科室编号 = '" + officeid + "'";
                    SqlDataAdapter myDataAdapter;
                    myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                    myDataAdapter.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    string sql = "";
                    QueryParameterCollection para;
                    DataSet ds = new DataSet();
                    sql = "SELECT * FROM v_DoctorInfo WHERE 所属科室编号 = :OFFICEID";
                    para = new QueryParameterCollection(1);
                    para.Add(":OFFICEID", officeid);
                    data.ExecuteDataset(sql, para, ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new LogonException(ex.Message, ex);
                }
                finally
                {
                    data.Close();
                }
            }
        }

      
        /// <summary>
        /// 发卡存储
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Birthday"></param>
        /// <param name="IDNumber"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        public int CreatCard(string CardNo, string Name, string Sex, DateTime Birthday, string IDNumber, string Address, string Nation)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {
                    SqlCommand command = new SqlCommand("p_CreateCard", sqlconn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CardNo", SqlDbType.NVarChar);
                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters.Add("@Sex", SqlDbType.NVarChar);
                    command.Parameters.Add("@Birthday", SqlDbType.DateTime);
                    command.Parameters.Add("@IDNumber", SqlDbType.NVarChar);
                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters.Add("@Nation", SqlDbType.NVarChar);

                    command.Parameters["@CardNo"].Value = CardNo;
                    command.Parameters["@Name"].Value = Name;
                    command.Parameters["@Sex"].Value = Sex;
                    command.Parameters["@Birthday"].Value = Birthday;
                    command.Parameters["@IDNumber"].Value = IDNumber;
                    command.Parameters["@Address"].Value = Address;
                    command.Parameters["@Nation"].Value = Nation;
                    command.ExecuteNonQuery();

                    return 0;
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                    //return -1;
                }
                finally
                {
                    sqlconn.Close();
                }
            } 
            if (Settings.Default.数据库类型 == DatabaseType.Oracle.ToString())
            {
                OracleConnection data = new OracleConnection(ConnString);
                data.Open();
                try
                {
                    OracleCommand cmd = data.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_CreateCard";

                    cmd.Parameters.Add("CardNo", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["CardNo"].Value = CardNo;

                    cmd.Parameters.Add("Name", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["Name"].Value = Name;

                    cmd.Parameters.Add("Sex", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["Sex"].Value = Sex;

                    cmd.Parameters.Add("Birthday", OracleDbType.TimeStamp).Direction = ParameterDirection.Input;
                    cmd.Parameters["Birthday"].Value = Birthday;

                    cmd.Parameters.Add("IDNumber", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["IDNumber"].Value = IDNumber;

                    cmd.Parameters.Add("Address", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["Address"].Value = Address;

                    cmd.Parameters.Add("Nation", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["Nation"].Value = Nation;

                    cmd.Parameters.Add("return_int", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("return_msg", OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["return_int"].Value.ToString() == "-1")
                    {
                        throw new LogonException("发卡失败!原因 :" + cmd.Parameters["return_msg"].Value.ToString());
                    }

                    return 0;
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                }
                finally
                {
                    data.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    QueryParameterCollection qpc = new QueryParameterCollection();
                    QueryParameter qp = null;
                    qp = new QueryParameter("CardNo", CardNo, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Name", Name, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Sex", Sex, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Birthday", Birthday, "TIMESTAMP", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("IDNumber", IDNumber, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Address", Address, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Nation", Nation, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);

                    string s = new StringBuilder(1024).ToString();
                    QueryParameter qp1 = new QueryParameter("return_int", 0, "INTEGER", ParameterDirection.Output);
                    qpc.Add(qp1);
                    QueryParameter qp2 = new QueryParameter("return_msg", s, "VARCHAR", ParameterDirection.Output);
                    qpc.Add(qp2);
              
                    data.ExecuteNonQuery(CommandType.StoredProcedure, "p_CreateCard", qpc);

                    if (Convert.ToInt32(qp1.Value) == -1)
                    {
                        throw new LogonException("发卡失败!原因 :" + qp2.Value.ToString());
                    }
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                }
                finally
                {
                    data.Close();
                }

                return 0;
            }

        }

        /// <summary>
        /// 充值存储
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        public int CardRecharge(string CardNo, decimal Money, ref string rcptNo)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {
                    SqlCommand command = new SqlCommand("p_CardRecharge", sqlconn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CardNo", SqlDbType.NVarChar);
                    command.Parameters.Add("@Money", SqlDbType.Decimal);

                    command.Parameters["@CardNo"].Value = CardNo;
                    command.Parameters["@Money"].Value = Money;

                    command.ExecuteNonQuery();
                    return 0;
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                    //return -1;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            if (Settings.Default.数据库类型 == DatabaseType.Oracle.ToString())
            {
                OracleConnection data = new OracleConnection(ConnString);
                data.Open();
                try
                {
                    OracleCommand cmd = data.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_CardRecharge";
                    cmd.Parameters.Add("CardNo", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
                    cmd.Parameters["CardNo"].Value = CardNo;

                    cmd.Parameters.Add("Money", OracleDbType.Decimal).Direction = ParameterDirection.Input;
                    cmd.Parameters["Money"].Value = Money;

                    cmd.Parameters.Add("rcpt_no", OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("return_int", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("return_msg", OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["return_int"].Value.ToString() == "-1")
                    {
                        throw new LogonException("充值失败!原因 :" + cmd.Parameters["return_msg"].Value.ToString());
                    }

                    rcptNo = cmd.Parameters["rcpt_no"].Value.ToString();

                    return 0;
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                }
                finally
                {
                    data.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    QueryParameterCollection qpc = new QueryParameterCollection();
                    QueryParameter qp = null;
                    qp = new QueryParameter("CardNo", CardNo, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("Money", Money, "DECIMAL", ParameterDirection.Input);
                    qpc.Add(qp);

                    string s = new StringBuilder(1024).ToString();
                    QueryParameter qp1 = new QueryParameter("return_int", 0, "INTEGER", ParameterDirection.Output);
                    qpc.Add(qp1);
                    QueryParameter qp2 = new QueryParameter("return_msg", s, "VARCHAR", ParameterDirection.Output);
                    qpc.Add(qp2);

                    data.ExecuteNonQuery(CommandType.StoredProcedure, "p_CardRecharge", qpc);

                    if (Convert.ToInt32(qp1.Value) == -1)
                    {
                        throw new LogonException("充值失败!原因 :" + qp2.Value.ToString());
                    }
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                }
                finally
                {
                    data.Close();
                }

                return 0;
            }
        }

        /// <summary>
        /// 挂号存储
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="RegisterOfficeID"></param>
        /// <param name="RegisterDoctorID"></param>
        /// <param name="RegisterMoney"></param>
        /// <returns></returns>
        public int Register(string CardNo, string RegisterOfficeID, string RegisterDoctorID, decimal RegisterMoney)
        {
            if (Settings.Default.数据库类型 == DatabaseType.MSSQLServer.ToString())
            {
                SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
                sqlconn.Open();
                try
                {
                    SqlCommand command = new SqlCommand("p_Register", sqlconn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CardNo", SqlDbType.NVarChar);
                    command.Parameters.Add("@RegisterOfficeID", SqlDbType.NVarChar);
                    command.Parameters.Add("@RegisterDoctorID", SqlDbType.NVarChar);
                    command.Parameters.Add("@RegisterMoney", SqlDbType.Decimal);

                    command.Parameters["@CardNo"].Value = CardNo;
                    command.Parameters["@RegisterOfficeID"].Value = RegisterOfficeID;
                    command.Parameters["@RegisterDoctorID"].Value = RegisterDoctorID;
                    command.Parameters["@RegisterMoney"].Value = RegisterMoney;

                    command.ExecuteNonQuery();
                    return 0;
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                    //return -1;
                }
                finally
                {
                    sqlconn.Close();
                }
            }
            else
            {
                IDataAccess data = DataAccessFactory.instance.CreateDataAccess();
                data.Open();
                try
                {
                    QueryParameterCollection qpc = new QueryParameterCollection();
                    QueryParameter qp = null;
                    qp = new QueryParameter("CardNo", CardNo, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("RegisterOfficeID", RegisterOfficeID, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("RegisterDoctorID", RegisterDoctorID, "VARCHAR", ParameterDirection.Input);
                    qpc.Add(qp);
                    qp = new QueryParameter("RegisterMoney", RegisterMoney, "DECIMAL", ParameterDirection.Input);
                    qpc.Add(qp);

                    data.ExecuteNonQuery(CommandType.StoredProcedure, "p_Register", qpc);
                }
                catch (Exception e)
                {
                    throw new LogonException(e.Message, e);
                }
                finally
                {
                    data.Close();
                }

                return 0;
            }
        }

        public static string ConnString
        {
            get
            {

                if (Settings.Default.数据库类型 == DatabaseType.Oracle.ToString())
                {

                    return string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={3})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={0})));User Id={1};Password={2};Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Timeout=60;Connection Lifetime=0;Persist Security Info=true ",
                        Settings.Default.数据库名称, Settings.Default.用户名, Settings.Default.密码, Settings.Default.数据库IP);

                }
                else if (Settings.Default.数据库类型 == DatabaseType.DB2.ToString())
                {
                    string format = "Database={0};user id={1};password={2};server={3}";
                    return string.Format(format, Settings.Default.数据库名称, Settings.Default.用户名, Settings.Default.密码, Settings.Default.数据库IP);
                }
                else
                {
                    string format = "Data Source={0};Initial Catalog={1};User Id={2};Password={3}";
                    return string.Format(format, Settings.Default.数据库IP, Settings.Default.数据库名称, Settings.Default.用户名, Settings.Default.密码);
                }
            }
        }

    }
}
