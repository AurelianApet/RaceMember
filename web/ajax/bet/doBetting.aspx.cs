using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

using DataAccess;
using Ronaldo.common;

public partial class ajax_bet_doBetting : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        try
        {
            int nLottery = Convert.ToInt32(Request.Params["lottery"]);
            string strGameRound = Request.Params["game_round"];
            int nMultiTimes = Convert.ToInt32(Request.Params["multi"]);
            long lGameRound = Convert.ToInt64(strGameRound);
            string strBettingParam = Request.Params["bet_param"];
            string[] strBettingUnit = strBettingParam.Split(';');
            int nBetMode = Convert.ToInt32(Request.Params["bet_mode"]);
            string strZhuihaoParam = Request.Params["zhuihao"];
            string[] strZhuihaoUnit = strZhuihaoParam.Split(';');

            DataSet dsGame = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST,
                new string[] { "@lottery", "@round", "@sdate" }, new object[] { nLottery, lGameRound, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) });

            if (DataSetUtil.IsNullOrEmpty(dsGame))
            {
                throw new Exception("该场比赛资料没有!");
            }
            long lGameID = DataSetUtil.RowLongValue(dsGame, "id", 0);
            DateTime dtStart = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(dsGame, "sdate", 0));
            TimeSpan tsDiff = dtStart - DateTime.Now;
            if ((nLottery == Constants.GAMETYPE_RACE && (dtStart.AddSeconds(-30) < DateTime.Now || dtStart.AddSeconds(-330) > DateTime.Now)) ||
                (nLottery == Constants.GAMETYPE_LADDER && (dtStart.AddSeconds(270) < DateTime.Now || dtStart.AddSeconds(-30) > DateTime.Now)))
            {
                throw new Exception("竞技前1分钟无法下注，请在之前下注，谢谢！");
            }
            if (nBetMode == 0)//보통배팅방식이면
            {
                for (int i = 0; i < strBettingUnit.Length; i++)
                {
                    string[] strParams = strBettingUnit[i].Split('-');
                    int nBetNum = Convert.ToInt32(strParams[0]);
                    double dItemTimes = Convert.ToDouble(strParams[1]);
                    double dBetRatio = Convert.ToDouble(strParams[2]);
                    long lBetType = Convert.ToInt64(strParams[4]);
                    string strVal = strParams[5];

                    double dBetMoney = nBetNum * 2 * dItemTimes * nMultiTimes;
                    if (dBetMoney > UserCash)
                        throw new Exception(Resources.Err.ERR_BETMONEY_INVALID);

                    // 베팅내역표에 기록
                    string strQuery = string.Format("INSERT INTO {0} (userid, loginid, nick, site, gameid, betmoney,ratio, betpos, betval, bet_ip) VALUES (@userid, @loginid, @nick, @site, @gameid, @betmoney,@ratio, @betpos, @betval, @betip)", nLottery == 8 ? "bettings_race" : "bettings_ladder");
                    DBConn.RunInsertQuery(strQuery,
                            new string[] {
                                "@userid",
                                "@loginid",
                                "@nick",
                                "@site",
                                "@gameid",
                                "@betmoney",
                                "@ratio",
                                "@betpos",
                                "@betval",
                                "@betip"
                            },
                            new object[]{
                                AuthUser.ID,
                                AuthUser.LoginID,
                                AuthUser.NickName,
                                AuthUser.Site,
                                lGameID,
                                dBetMoney,
                                dBetRatio,
                                lBetType,
                                strVal,
                                UserIP
                            });
                    InsertCash(AuthUser.ID, 0, dBetMoney, string.Format(Resources.Desc.DESC_BETTING, dBetMoney), lGameID.ToString());
                }
            }
            else//zhuihao방식이면
            {
                if (strBettingUnit.Length != 1)
                    throw new Exception("一次追号只允许一条投注项，请删除多余投注项！");

                long lStartRound = 0;
                double fTotalBetMoney = 0;
                double fOneBetMoney = 0;

                string[] strParams = strBettingUnit[0].Split('-');
                int nBetNum = Convert.ToInt32(strParams[0]);
                double dItemTimes = Convert.ToDouble(strParams[1]);

                fOneBetMoney = nBetNum * 2 * dItemTimes;

                for (int i = 0; i < strZhuihaoUnit.Length; i++)
                {
                    strParams = strZhuihaoUnit[i].Split('-');
                    int nTimes = Convert.ToInt32(strParams[1]);

                    fTotalBetMoney += fOneBetMoney * nTimes;
                    if (i == 0)
                        lStartRound = Convert.ToInt64(strParams[0]);
                }

                if (fTotalBetMoney > UserCash)
                    throw new Exception(Resources.Err.ERR_BETMONEY_INVALID);

                InsertCash(AuthUser.ID, 0, fTotalBetMoney, string.Format(Resources.Desc.DESC_BETTING, fTotalBetMoney), lGameID.ToString());

                long lInsertID = DataSetUtil.GetID(DBConn.RunSelectQuery("insert into zhuihaos(lottery, userid, mode, betmoney, betinfo, zhuihaoinfo, startround, totalstep, curstep, status) values(@lottery, @userid, @mode, @betmoney, @betinfo, @zhuihao, @startround, @totalstep, @curstep, @status); SELECT @@IDENTITY;",
                    new string[]{
                        "@lottery",
                        "@userid",
                        "@mode",
                        "@betmoney",
                        "@betinfo",
                        "@zhuihao",
                        "@startround",
                        "@totalstep",
                        "@curstep",
                        "@status"
                    },
                    new object[]{
                        nLottery,
                        AuthUser.ID,
                        nBetMode,
                        fTotalBetMoney,
                        strBettingParam,
                        strZhuihaoParam,
                        lStartRound,
                        strZhuihaoUnit.Length,
                        0,          //아직 첫 회차 
                        0           //진행중
                    }));
                if (lStartRound == lGameRound)
                {
                    strParams = strBettingUnit[0].Split('-');
                    nBetNum = Convert.ToInt32(strParams[0]);
                    dItemTimes = Convert.ToDouble(strParams[1]);
                    double dBetRatio = Convert.ToDouble(strParams[2]);
                    long lBetType = Convert.ToInt64(strParams[4]);
                    string strVal = strParams[5];

                    double dBetMoney = nBetNum * 2 * dItemTimes;

                    // 베팅내역표에 기록
                    string strQuery = string.Format("INSERT INTO {0} (userid, loginid, nick, site, zhuihao_id, descript, gameid, betmoney,ratio, betpos, betval, bet_ip) VALUES (@userid, @loginid, @nick, @site, @zhuihao_id, @descript, @gameid, @betmoney,@ratio, @betpos, @betval, @betip)", nLottery == 8 ? "bettings_race" : "bettings_ladder");
                    DBConn.RunInsertQuery(strQuery,
                            new string[] {
                                "@userid",
                                "@loginid",
                                "@nick",
                                "@site",
                                "@zhuihao_id",
                                "@descript",
                                "@gameid",
                                "@betmoney",
                                "@ratio",
                                "@betpos",
                                "@betval",
                                "@betip"
                            },
                            new object[]{
                                AuthUser.ID,
                                AuthUser.LoginID,
                                AuthUser.NickName,
                                AuthUser.Site,
                                lInsertID,
                                string.Format("追号 1/{0} 期", strZhuihaoUnit.Length),
                                lGameID,
                                dBetMoney,
                                dBetRatio,
                                lBetType,
                                strVal,
                                UserIP
                            });

                    DBConn.RunSelectQuery("update zhuihaos set curstep = 1 where id = @id", new string[] { "@id" }, new object[] { lInsertID });
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write(string.Format("{{\"Ok\":\"0\", \"Tip\":\"{0}\"}}", ex.Message));
            Response.End();
        }
        Response.Write(string.Format("{{\"Ok\":\"1\", \"Tip\":\"111\", \"gamePoint\":\"{0:F2}\"}}", UserCash));
        Response.End();
    }
}
