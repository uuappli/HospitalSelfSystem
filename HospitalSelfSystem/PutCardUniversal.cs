using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Skynet.Framework.Common;
using Skynet.LoggingService;
using System.IO;
using System.Windows.Forms;
using HospitalSelfSystem.Properties;
using AutoServiceSDK.SdkData;
using AutoRegisterManager.SdkService;
using AutoRegisterManager;

namespace HospitalSelfSystem
{
    /// <summary>
    /// 发卡
    /// 作者：李新华
    /// DATE：2013.1.10
    /// </summary>
    public class PutCardUniversal
    {
        K101SendCard k101 = new K101SendCard();

        public int OutCard(int sqadd, int blockAddr, IDCardInfo userInfo, decimal sumChargeMoney)
        {
            try
            {
                if (k101.CheckCardPosition() == false)
                {
                    MyMsg.MsgInfo("卡机状态不正确，不能继续发卡，请联系管理员!");
                    return -1;
                }

                //   //吐出卡片
                //k101.MoveCard("传动到前端夹卡位");
                //MyMsg.MsgInfo("发卡成功！");
                //return;

                string cardTemp = string.Empty;
                string cardType = Settings.Default.卡类型;

                if (cardType == "磁条卡")
                {
                    k101.MoveCard("移动到读磁卡位");
                    if (k101.MoveCard("移动到读磁卡位") == false)
                    {
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请联系管理员!");
                        return -1;
                    }

                    cardTemp = k101.ReadCard();
                    if (cardTemp == string.Empty)
                    {
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("磁卡数据错误，或是空卡，不能继续发卡，请联系管理员!");
                        return -1;
                    }

                    FrmMain.cardInfoStruct.CardNo = cardTemp;
                }

                string CardNo = cardTemp;

                if (Settings.Default.运行模式 == "RUN")
                {
                    LogService.GlobalInfoMessage("调用发卡存储过程");
                    SkyComm skyComm = new SkyComm();
                    skyComm.CreatCard(CardNo, FrmMain.userInfo.Name, FrmMain.userInfo.Sex, Convert.ToDateTime(FrmMain.userInfo.Birthday), FrmMain.userInfo.Number, FrmMain.userInfo.Address, FrmMain.userInfo.People);
                    LogService.GlobalInfoMessage("调用发卡存储过程成功");
                }

                bool isSuccess = true;
                if (cardType == "IC卡")
                {
                    LogService.GlobalInfoMessage("传动到IC卡位");
                    k101.MoveCard("传动到IC卡位");
                    if (k101.MoveCard("传动到IC卡位") == false)
                    {
                        LogService.GlobalInfoMessage("回收卡片");
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请通过补办卡重新发卡!");
                        return -1;
                    }

                    //写卡，如果失败则重试
                    int state = -1;
                    while (0 != state)
                    {
                        LogService.GlobalInfoMessage("写卡");
                        state = k101.WriteCard(CardNo);
                        LogService.GlobalInfoMessage("写卡完成");
                        if (state != 0)
                        {
                            MyAlert my = new MyAlert();
                            my.Msg = "写卡失败，是否重试?";
                            my.alerttype = "确认取消";
                            if (my.ShowDialog() == DialogResult.OK)
                            {
                                state = -1;
                            }
                            else
                            {
                                state = 0;
                            }
                            isSuccess = false;
                        }
                        else
                        {
                            isSuccess = true;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(cardTemp))
                {
                    if (isSuccess == true)
                    {
                        LogService.GlobalInfoMessage("传动到前端夹卡位");
                        //吐出卡片
                        if (k101.MoveCard("传动到前端夹卡位") == false)
                        {
                            LogService.GlobalInfoMessage("吐卡失败！请通过补办卡重新发卡！");
                            MyMsg.MsgInfo("吐卡失败！请通过补办卡重新发卡！");
                            isSuccess = false;
                            return -1;
                        }
                        else
                        {
                            LogService.GlobalInfoMessage("发卡成功");
                            isSuccess = true;
                            MyMsg.MsgInfo("发卡成功！");
                        }
                    }

                    if (isSuccess == false)
                    {
                        LogService.GlobalInfoMessage("回收卡片");
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("写卡失败，请通过补办卡重新发卡！");
                        return -1;
                    }

                }
                return 0;
            }
            catch (Exception err)
            {
                LogService.GlobalInfoMessage("吐卡失败！请重试自助发卡！" + err.Message);
                k101.MoveCard("回收卡片");
                MyMsg.MsgInfo("吐卡失败！请重试自助发卡！" + err.Message);
                return -1;

            }
        }

        public void OutCardD1000(int sqadd, int blockAddr, IDCardInfo userInfo, decimal sumChargeMoney)
        {
            try
            {
                D1000Card d1000 = new D1000Card();
                string cardstate = d1000.CheckState();
                if (cardstate != string.Empty)
                {
                    MyMsg.MsgInfo(cardstate);
                    return;
                }

                if (d1000.sendcmd("DC") == false)
                {
                    MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请通过补办卡重新发卡!");
                    return;
                }


                string CardNo = string.Empty;
                //FrmInCardUniversalSend fi = new FrmInCardUniversalSend();
                //if (fi.ShowDialog() == DialogResult.OK)
                //{
                //    CardNo = FrmMain.cardInfoStruct.CardNo;
                //    SkyComm skyComm = new SkyComm();
                //    skyComm.CreatCard(CardNo, FrmMain.userInfo.Name, FrmMain.userInfo.Number, FrmMain.userInfo.Address, sumChargeMoney);


                //    //bool isSuccess = true;
                MyMsg.MsgInfo("办卡成功！");
                //}
                //else
                //{
                //    MyMsg.MsgInfo("发卡失败！请重试自助发卡！");
                //    return;
                //}


            }
            catch (Exception err)
            {
                //k101.MoveCard("回收卡片");
                MyMsg.MsgInfo("吐卡失败！请重试自助发卡！" + err.Message);
                //this.eLCardAuthorizationData.Clear();
            }

        }

        /// <summary>
        /// 检查此卡号是否已经发过卡
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public string check(string cardID)
        {
            //CardAuthorizationFacade eCardAuthorizationFacade = new CardAuthorizationFacade();
            //DataSet ds = eCardAuthorizationFacade.SelectPatientAndCardInfoByCardID(cardID);//this.tbxCardID.Text.Trim()
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return "该病人已发卡，不能重复发卡！";

            //}
            return string.Empty;
        }
        /// <summary>
        /// 得到卡类型
        /// </summary>
        /// <returns></returns>
        public DataRow cardType()
        {
            //CardTypesFacade cardTypesFacade = new CardTypesFacade();
            //DataSet dscardTypes = cardTypesFacade.SelectAllItems();
            //if (dscardTypes==null ||dscardTypes.Tables[0].Rows.Count == 0)
            //{
            //    MyMsg.MsgInfo("没有得到卡类型数据，请维护");
            //    return null;
            //}
            //return dscardTypes.Tables[0].Select("TYPE_NAME like '%一卡通%'")[0];//需要改动
            return null;

        }
    }
}
