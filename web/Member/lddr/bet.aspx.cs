using System;
using System.Collections;
using System.Collections.Generic;
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

using DataAccess;
using Ronaldo.common;

public partial class Member_lddr_bet : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        DataSet dsConfig = DBConn.RunSelectQuery(Constants.SP_GETCONFIG, new string[] { "@type" }, new object[] { Constants.GAMETYPE_LADDER });

        Dictionary<string, string> dicConfigs = new Dictionary<string, string>();
        for (int i = 0; i < DataSetUtil.RowCount(dsConfig); i++)
            dicConfigs.Add(DataSetUtil.RowStringValue(dsConfig, "conf_name", i), DataSetUtil.RowStringValue(dsConfig, "conf_value", i));

        string[] strRatios = dicConfigs["ladder_betratio"].Split(';');

        ltlRatio25_one.Text = string.Format("{0:F2} ~ {1:F2}", 2 * Convert.ToDouble(strRatios[0]), 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio25_1.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        ltlRatio25_2.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        ltlRatio25_3.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[1]));
        ltlRatio25_4.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[1]));
        ltlRatio25_5.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[2]));
        ltlRatio25_6.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[2]));

        ltlRatio25_7.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio25_8.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio25_9.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio25_10.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        string strRules = "[{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010101, \"RuleName\": \"左\", \"DisplayName\": \"单式-左右\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^左$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010102, \"RuleName\": \"右\", \"DisplayName\": \"单式-左右\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^右$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010103, \"RuleName\": \"3\", \"DisplayName\": \"单式-34\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^3$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010104, \"RuleName\": \"4\", \"DisplayName\": \"单式-34\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^4$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[2])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010105, \"RuleName\": \"单\", \"DisplayName\": \"单式-单双\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^单$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[2])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25010106, \"RuleName\": \"双\", \"DisplayName\": \"单式-单双\", \"SubTypeId\": 250101, \"MatchType\": \"单式\", \"SelectedRegex\": \"^双$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25020101, \"RuleName\": \"3 单\", \"DisplayName\": \"双式\", \"SubTypeId\": 250101, \"MatchType\": \"双式\", \"SelectedRegex\": \"^3 单$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25020102, \"RuleName\": \"3 双\", \"DisplayName\": \"双式\", \"SubTypeId\": 250101, \"MatchType\": \"双式\", \"SelectedRegex\": \"^3 双$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25020103, \"RuleName\": \"4 单\", \"DisplayName\": \"双式\", \"SubTypeId\": 250101, \"MatchType\": \"双式\", \"SelectedRegex\": \"^4 单$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, " +
                            "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 25020104, \"RuleName\": \"4 双\", \"DisplayName\": \"双式\", \"SubTypeId\": 250201, \"MatchType\": \"双式\", \"SelectedRegex\": \"^4 双$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }]";

        #region 최신게임결과부분
        DataSet GameDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST,
            new string[] { "@lottery", "@rowcount" }, new object[] { Constants.GAMETYPE_LADDER, 6 });
        string strTop5GameHist = "";
        string strUnitFormat = "{{ \"LotteryCode\": 25, \"LotteryHash\": \"lddr\", \"Id\": {0}, \"IssueNumber\": \"{1}\", \"BonusNumber\": \"{2}\", \"LotteryName\": \"LADDER\", \"BonusDateTime\": \"{3:yyyy-MM-dd HH:mm:ss}\" }}";
        string strComma = "";
        for (int i = 0; i < DataSetUtil.RowCount(GameDataSource); i++)
        {
            if (DataSetUtil.RowIntValue(GameDataSource, "startpos", i) == 0 || Convert.ToDateTime(DataSetUtil.RowDateTimeValue(GameDataSource, "sdate", i)).AddMinutes(5) >= DateTime.Now)
                continue;
            string strNumber = string.Format("{0},{1},{2}",
                                            DataSetUtil.RowIntValue(GameDataSource, "startpos", i) == 1 ? "左" : "右",
                                            DataSetUtil.RowIntValue(GameDataSource, "laddercount", i) == 1 ? "3" : "4",
                                            DataSetUtil.RowIntValue(GameDataSource, "oddeven", i) == 1 ? "单" : "双");

            strTop5GameHist += strComma + string.Format(strUnitFormat,
                                                        DataSetUtil.RowLongValue(GameDataSource, "id", i),
                                                        DataSetUtil.RowLongValue(GameDataSource, "round", i),
                                                        strNumber,
                                                        Convert.ToDateTime(DataSetUtil.RowDateTimeValue(GameDataSource, "sdate", i)));
            strComma = ", ";
        }
        strTop5GameHist = "[" + strTop5GameHist + "];";
        #endregion

        outputRes2JS(
            new string[] { "gl.lddr", "gl.lotteryId", "gl.lotteryName", "gl.rules", "gl.betAssistData", "gl.betAssistData.top5" },
            new string[] { "{}", Constants.GAMETYPE_LADDER.ToString(), "\"" + Lotterys[Constants.GAMETYPE_LADDER].Name + "\"", strRules, "{}", strTop5GameHist });

        #region Zhuihao배팅설정부분
        DataSet dsGame = DBConn.RunStoreProcedure(Constants.SP_GETCURRENTGAME, new string[] { "@lottery" }, new object[] { Constants.GAMETYPE_LADDER });
        long lCurRound = DataSetUtil.RowLongValue(dsGame, "round", 0);
        DateTime dtCurStart = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(dsGame, "sdate", 0));
        string strChuihaoFormat = "<tr issuenumber=\"{0}\">" +
                                        "<td><input type=\"checkbox\" class=\"trace-checkbox\" /></td>" +
                                        "<td><span>{1}</span></td>" +
                                        "<td><input type=\"text\" class=\"trace-text traceTimes\" value=\"1\" disabled=\"disabled\">倍</td>" +
                                        "<td>&yen;<span class=\"traceUnitPrice\">0.00</span></td>" +
                                        "<td class=\"timesTraceClass\"><span>{2}</span></td>" +
                                        "<td class=\"jiLeiAmount advanceTraceClass\"><span>--</span></td>" +
                                        "<td class=\"jiLeiProfit advanceTraceClass\"><span>--</span></td>" +
                                        "<td class=\"jiLeiProfitPercent advanceTraceClass\"><span>--</span></td>" +
                                    "</tr>";
        string strTraceList = "";
        for (int i = 0; i < 60; i++)
        {
            strTraceList += string.Format(strChuihaoFormat, lCurRound, lCurRound, dtCurStart.ToString("yyyy-MM-dd HH:mm:ss"));
            lCurRound = lCurRound == 288 ? 1 : lCurRound + 1;
            dtCurStart = dtCurStart.AddMinutes(5);
        }
        ltlTraceList.Text = strTraceList;
        #endregion

        #region Zhuihao배팅리력부분
        DataSet dsZhuiHaoBet = DBConn.RunSelectQuery("select top(5) * from zhuihaos where lottery = 25 and userid = @userid", new string[] { "@userid" }, new object[] { AuthUser.ID });
        string strRightTraceList = "";

        strRightTraceList += "<div class=\"module trace-keeper-list\">\n" +
                                "<ul id=\"rightTraceListId\">\n";
        if (DataSetUtil.IsNullOrEmpty(dsZhuiHaoBet))
        {
            strRightTraceList += "</ul>\n" +
                                "</div>\n" +
                                "<div class=\"complete\" id=\"rightTraceListNoData\">\n" +
                                "<div class=\"complete-sub image\"> <span><img src=\"/images/status/empty-flat.png\" alt=\"\"></span> </div>\n" +
                                    "<div class=\"complete-sub title\">\n" +
                                        "<h4 id=\"rightTraceListH4\">暂无追号记录</h4>\n" +
                                    "</div>\n" +
                                "</div>\n";

            ltlRightTraceList.Text = strRightTraceList;
        }
        else
        {
            string strZhuihaoFormat = "<li title =\"点击期号进入追号详情页面\">\n" +
                                            "<span class=\"title\">幸运梯子</span>\n" +
                                            "<a href=\"javascript:goLink('zhuihaodetail', '{4}');\">\n" +
                                            "<span class=\"period\">第一期:<em>{0}</em></span>\n" +
                                            "</a>\n" +
                                            "<span class=\"count\"><em>{1}</em>期</span>\n" +
                                            "<span class=\"mode\"><em>{2}</em></span>\n" +
                                            "<span class=\"status fc-green\">{3}</span>\n" +
                                        "</li>\n";
            for (int i = 0; i < DataSetUtil.RowCount(dsZhuiHaoBet); i++)
            {
                long lStartRound = DataSetUtil.RowLongValue(dsZhuiHaoBet, "startround", i);
                int nTotalStep = DataSetUtil.RowIntValue(dsZhuiHaoBet, "totalstep", i);
                int nStatus = DataSetUtil.RowIntValue(dsZhuiHaoBet, "status", i);
                string strBetInfo = DataSetUtil.RowStringValue(dsZhuiHaoBet, "betinfo", i);
                string[] strParams = strBetInfo.Split('-');
                strRightTraceList += string.Format(strZhuihaoFormat, lStartRound, nTotalStep, getBetMode(Convert.ToInt32(strParams[4])), nStatus == 1 ? "已完成" : "进行中", DataSetUtil.RowLongValue(dsZhuiHaoBet, "id", i));
            }

            strRightTraceList += "</ul>\n" +
                                "</div>\n";

            ltlRightTraceList.Text = strRightTraceList;
        }
        #endregion
    }

    public void outputRes2JS(string[] strNames, string[] strValues)
    {
        if (strNames.Length != strValues.Length)
            return;

        string strRet = "<script language=\"javascript\" type=\"text/javascript\">\n";
        for (int i = 0; i < strNames.Length; i++)
        {
            strRet += strNames[i] + " = " + strValues[i] + ";\n";
        }
        strRet += "</script>";

        ltlScript.Text += strRet;
    }
}
