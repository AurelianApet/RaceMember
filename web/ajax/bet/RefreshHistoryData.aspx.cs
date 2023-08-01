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

public partial class ajax_bet_RefreshHistoryData : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        string strFormat = "{{\"recentData\":[{0}]}}";
        string strUnitFormat = "\"EncodeId\":\"{0}\", " +
                                "\"Id\":{1}, " +
                                "\"Uid\":{2}, " +
                                "\"LotteryCode\":{3}, " +
                                "\"IssueNumber\":\"{4}\", " +
                                "\"OrderTime\":\"/{5}/\", " +
                                "\"CreateTime\":\"/{6}/\", " +
                                "\"BatchNo\":\"{7}\", " +
                                "\"BetContent\":\"{8}\", " +
                                "\"SortOrder\":{9}, " +
                                "\"BetRuleId\":{10}, " +
                                "\"Odds\":{11}, " +
                                "\"BetUnitPrice\":{12}, " +
                                "\"TotalBet\":{13}, " +
                                "\"TotalAmount\":{14}, " +
                                "\"BonusAmount\":{15}, " +
                                "\"BonusTotalNumber\":{16}, " +
                                "\"PlusOdds\":{17}, " +
                                "\"OrderStatus\":{18}, " +
                                "\"IsTraceOrder\":{19}, " +
                                "\"Mark\":\"{20}\", " +
                                "\"BoNums\":\"{21}\", " +
                                "\"InsertDate\":\"{22}\", " +
                                "\"CloseTime\":\"{23}\", " +
                                "\"BonusNumber\":\"{24}\", " +
                                "\"ReturnPoint\":{25}, " +
                                "\"LoginName\":\"{26}\", " +
                                "\"UserType\":{27}, " +
                                "\"RuleName\":\"{28}\", " +
                                "\"LotteryName\":\"{29}\", " +
                                "\"profit\":{30}, " +
                                "\"hasRunLottery\":\"{31}\"";
        
        string strResult = "";
        try
        {
            int nLotteryID = Convert.ToInt32(Request.Params["sel"]);
            DataSet dsBetHist = DBConn.RunStoreProcedure(Constants.SP_GETBETTINGHIST, new string[] { "@lottery", "@userid", "@rowcount" }, new object[] { nLotteryID, AuthUser.ID, 6 });
            string strBetData = "";
            string strComma = "";
            for (int i = 0; i < DataSetUtil.RowCount(dsBetHist); i++)
            {
                string strGameOrder = "";
                if(nLotteryID == Constants.GAMETYPE_RACE)
                    strGameOrder = string.Format("{0:D2},{1:D2},{2:D2},{3:D2},{4:D2},{5:D2},{6:D2},{7:D2},{8:D2},{9:D2}",
                                        DataSetUtil.RowIntValue(dsBetHist, "rank1", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank2", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank3", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank4", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank5", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank6", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank7", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank8", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank9", i),
                                        DataSetUtil.RowIntValue(dsBetHist, "rank10", i));
                else if(nLotteryID == Constants.GAMETYPE_LADDER)
                    strGameOrder = string.Format("{0},{1},{2}",
                                        DataSetUtil.RowIntValue(dsBetHist, "startpos", i) == 1 ? "左" : "右",
                                        DataSetUtil.RowIntValue(dsBetHist, "laddercount", i) == 1 ? "3" : "4",
                                        DataSetUtil.RowIntValue(dsBetHist, "oddeven", i) == 1 ? "单" : "双");


                strBetData += strComma + "{" + string.Format(strUnitFormat,
                                    Lotterys[nLotteryID].Nick + DataSetUtil.RowLongValue(dsBetHist, "id", i),
                                    DataSetUtil.RowLongValue(dsBetHist, "id", i),
                                    AuthUser.ID,
                                    Lotterys[nLotteryID].ID.ToString(),
                                    DataSetUtil.RowLongValue(dsBetHist, "round", i),
                                    "Date(1465985120000)",
                                    "Date(1465985102000)",
                                    "16061518050151901",
                                    DataSetUtil.RowStringValue(dsBetHist, "betval", i),
                                    "0",
                                    DataSetUtil.RowIntValue(dsBetHist, "betpos", i),
                                    DataSetUtil.RowDoubleValue(dsBetHist, "ratio", i),
                                    DataSetUtil.RowDoubleValue(dsBetHist, "betmoney", i),
                                    "1",
                                    DataSetUtil.RowDoubleValue(dsBetHist, "betmoney", i),
                                    string.Format("{0:F4}", DataSetUtil.RowDoubleValue(dsBetHist, "winmoney", i)),
                                    "0",
                                    string.Format("{0:F2}", 0.0),
                                    "1",
                                    "false",
                                    string.IsNullOrEmpty(DataSetUtil.RowStringValue(dsBetHist, "descript", i)) ? "普通投注" : DataSetUtil.RowStringValue(dsBetHist, "descript", i),
                                    "",
                                    DataSetUtil.RowDateTimeValue(dsBetHist, "regdate", i),
                                    "",
                                    strGameOrder,
                                    "0.1200",
                                    AuthUser.LoginID,
                                    "1",
                                    getBetMode(DataSetUtil.RowIntValue(dsBetHist, "betpos", i)),
                                    Lotterys[nLotteryID].Name,
                                    DataSetUtil.RowDoubleValue(dsBetHist, "betmoney", i) - DataSetUtil.RowDoubleValue(dsBetHist, "winmoney", i),
                                    "是") + "}";
                strComma = ",";
            }
            strResult = string.Format(strFormat, strBetData);
        }
        catch (Exception ex)
        {
            Response.Write(string.Format(strFormat, ex.Message));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();

    }
}
