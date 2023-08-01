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

public partial class Member_pk10_bet : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        #region 배당설정부분
        DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@loginid" }, new object[] { AuthUser.LoginID });
        bool bMajang = (DataSetUtil.RowIntValue(dsUser, "ulevel", 0) == 80);

        DataSet dsConfig = DBConn.RunSelectQuery(Constants.SP_GETCONFIG, new string[] { "@type" }, new object[] { Constants.GAMETYPE_RACE });

        Dictionary<string, string> dicConfigs = new Dictionary<string, string>();
        for (int i = 0; i < DataSetUtil.RowCount(dsConfig); i++)
            dicConfigs.Add(DataSetUtil.RowStringValue(dsConfig, "conf_name", i), DataSetUtil.RowStringValue(dsConfig, "conf_value", i));

        string[] strRatios = null;
        ltlRatio1.Text = string.Format("{0:F2}", 2 * (bMajang ? Convert.ToDouble(dicConfigs["race_betratio_m_1"]) : Convert.ToDouble(dicConfigs["race_betratio_1"])));
        strRatios = bMajang ? dicConfigs["race_betratio_m_2"].Split(';') : dicConfigs["race_betratio_2"].Split(';');
        ltlRatio2.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_3"].Split(';') : dicConfigs["race_betratio_3"].Split(';');
        ltlRatio3.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_4"].Split(';') : dicConfigs["race_betratio_4"].Split(';');
        ltlRatio4.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_5"].Split(';') : dicConfigs["race_betratio_5"].Split(';');
        ltlRatio5.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_11"].Split(';') : dicConfigs["race_betratio_11"].Split(';');
        ltlRatio11.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_12"].Split(';') : dicConfigs["race_betratio_12"].Split(';');
        ltlRatio12.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_13"].Split(';') : dicConfigs["race_betratio_13"].Split(';');
        ltlRatio13.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_14"].Split(';') : dicConfigs["race_betratio_14"].Split(';');
        ltlRatio14.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_15"].Split(';') : dicConfigs["race_betratio_15"].Split(';');
        ltlRatio15.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        strRatios = bMajang ? dicConfigs["race_betratio_m_16"].Split(';') : dicConfigs["race_betratio_16"].Split(';');
        ltlRatio16.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));

        strRatios = bMajang ? dicConfigs["race_betratio_m_11"].Split(';') : dicConfigs["race_betratio_11"].Split(';');
        ltlRatio11_1.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        ltlRatio11_2.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[1]));
        ltlRatio11_3.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[2]));
        ltlRatio11_4.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio11_5.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[4]));
        ltlRatio11_6.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[5]));
        ltlRatio11_7.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[6]));
        ltlRatio11_8.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[7]));
        ltlRatio11_9.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[8]));
        ltlRatio11_10.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[9]));
        ltlRatio11_11.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[10]));
        ltlRatio11_12.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[11]));
        ltlRatio11_13.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[12]));
        ltlRatio11_14.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[13]));
        ltlRatio11_15.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[14]));
        ltlRatio11_16.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[15]));
        ltlRatio11_17.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[16]));
        ltlRatio11_18.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[17]));
        ltlRatio11_19.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[18]));
        ltlRatio11_20.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[19]));
        ltlRatio11_21.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[20]));
        ltlRatio11_22.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[21]));
        ltlRatio11_23.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[22]));
        ltlRatio11_24.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[23]));
        ltlRatio11_25.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[24]));
        ltlRatio11_26.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[25]));

        strRatios = bMajang ? dicConfigs["race_betratio_m_13"].Split(';') : dicConfigs["race_betratio_13"].Split(';');
        ltlRatio13_1.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[0]));
        ltlRatio13_2.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[1]));
        ltlRatio13_3.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[2]));
        ltlRatio13_4.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[3]));
        ltlRatio13_5.Text = string.Format("{0:F2}", 2 * Convert.ToDouble(strRatios[4]));
        
        strRatios = bMajang ? dicConfigs["race_betratio_m_1"].Split(';') : dicConfigs["race_betratio_1"].Split(';');
        string strRules = "[{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8010101, \"RuleName\": \"1\", \"DisplayName\": \"猜冠军\", \"SubTypeId\": 80101, \"MatchType\": \"猜冠军\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 0, \"Length\": 1, \"BaseOdds\": 8.50, \"IsFixOdds\": false, \"Modulus\": 10.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 10.00, \"MaxBonusMode\": 9.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_2"].Split(';') : dicConfigs["race_betratio_2"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8020101, \"RuleName\": \"2\", \"DisplayName\": \"猜冠亚军\", \"SubTypeId\": 80201, \"MatchType\": \"猜冠亚军\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){1}$\", \"StartIndex\": 0, \"Length\": 2, \"BaseOdds\": 76.50, \"IsFixOdds\": false, \"Modulus\": 90.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 90.00, \"MaxBonusMode\": 88.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\t1,2\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8020201, \"RuleName\": \"猜冠亚军单式\", \"DisplayName\": \"猜冠亚军单式\", \"SubTypeId\": 80202, \"MatchType\": \"猜冠亚军单式\", \"SelectedRegex\": \"^((0[1-9])|10)[,| ]{1}((0[1-9])|10)$\", \"StartIndex\": 0, \"Length\": 2, \"BaseOdds\": 76.50, \"IsFixOdds\": false, \"Modulus\": 90.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 90.00, \"MaxBonusMode\": 88.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"100\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_3"].Split(';') : dicConfigs["race_betratio_3"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8030101, \"RuleName\": \"3\", \"DisplayName\": \"猜前三名\", \"SubTypeId\": 80301, \"MatchType\": \"猜前三名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){2}$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 612.00, \"IsFixOdds\": false, \"Modulus\": 720.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 720.00, \"MaxBonusMode\": 705.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8030201, \"RuleName\": \"猜前三名单式\", \"DisplayName\": \"猜前三名单式\", \"SubTypeId\": 80302, \"MatchType\": \"猜前三名单式\", \"SelectedRegex\": \"^((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 612.00, \"IsFixOdds\": false, \"Modulus\": 720.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 720.00, \"MaxBonusMode\": 705.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"100\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_4"].Split(';') : dicConfigs["race_betratio_4"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8040101, \"RuleName\": \"4\", \"DisplayName\": \"猜前四名\", \"SubTypeId\": 80401, \"MatchType\": \"猜前四名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){3}$\", \"StartIndex\": 0, \"Length\": 4, \"BaseOdds\": 4284.00, \"IsFixOdds\": false, \"Modulus\": 5040.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 5040.00, \"MaxBonusMode\": 4939.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8040201, \"RuleName\": \"猜前四名单式\", \"DisplayName\": \"猜前四名单式\", \"SubTypeId\": 80402, \"MatchType\": \"猜前四名单式\", \"SelectedRegex\": \"^((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)$\", \"StartIndex\": 0, \"Length\": 4, \"BaseOdds\": 4284.00, \"IsFixOdds\": false, \"Modulus\": 5040.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 5040.00, \"MaxBonusMode\": 4939.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"100\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_5"].Split(';') : dicConfigs["race_betratio_5"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8050101, \"RuleName\": \"5\", \"DisplayName\": \"猜前五名\", \"SubTypeId\": 80501, \"MatchType\": \"猜前五名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){4}$\", \"StartIndex\": 0, \"Length\": 5, \"BaseOdds\": 25704.00, \"IsFixOdds\": false, \"Modulus\": 30240.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 30240.00, \"MaxBonusMode\": 29635.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8050201, \"RuleName\": \"猜前五名单式\", \"DisplayName\": \"猜前五名单式\", \"SubTypeId\": 80502, \"MatchType\": \"猜前五名单式\", \"SelectedRegex\": \"^((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)[,| ]{1}((0[1-9])|10)$\", \"StartIndex\": 0, \"Length\": 5, \"BaseOdds\": 25704.00, \"IsFixOdds\": false, \"Modulus\": 30240.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 30240.00, \"MaxBonusMode\": 29635.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"100\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_6"].Split(';') : dicConfigs["race_betratio_6"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8060101, \"RuleName\": \"6\", \"DisplayName\": \"猜前六名\", \"SubTypeId\": 80601, \"MatchType\": \"猜前六名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){5}$\", \"StartIndex\": 0, \"Length\": 6, \"BaseOdds\": 8165.50, \"IsFixOdds\": false, \"Modulus\": 151200.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 151200.00, \"MaxBonusMode\": 148176.00, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5,6\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_7"].Split(';') : dicConfigs["race_betratio_7"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8070101, \"RuleName\": \"7\", \"DisplayName\": \"猜前七名\", \"SubTypeId\": 80701, \"MatchType\": \"猜前七名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){6}$\", \"StartIndex\": 0, \"Length\": 7, \"BaseOdds\": 16331.00, \"IsFixOdds\": false, \"Modulus\": 604800.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 604800.00, \"MaxBonusMode\": 592704.00, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5,6,7\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_8"].Split(';') : dicConfigs["race_betratio_8"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8080101, \"RuleName\": \"8\", \"DisplayName\": \"猜前八名\", \"SubTypeId\": 80801, \"MatchType\": \"猜前八名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){7}$\", \"StartIndex\": 0, \"Length\": 8, \"BaseOdds\": 32662.00, \"IsFixOdds\": false, \"Modulus\": 1814400.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 1814400.00, \"MaxBonusMode\": 1778112.00, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5,6,7,8\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_9"].Split(';') : dicConfigs["race_betratio_9"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8090101, \"RuleName\": \"9\", \"DisplayName\": \"猜前九名\", \"SubTypeId\": 80901, \"MatchType\": \"猜前九名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){8}$\", \"StartIndex\": 0, \"Length\": 9, \"BaseOdds\": 65324.00, \"IsFixOdds\": false, \"Modulus\": 3628800.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 3628800.00, \"MaxBonusMode\": 3556224.00, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5,6,7,8,9\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_10"].Split(';') : dicConfigs["race_betratio_10"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8100101, \"RuleName\": \"10\", \"DisplayName\": \"猜前十名\", \"SubTypeId\": 81001, \"MatchType\": \"猜前十名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){9}$\", \"StartIndex\": 0, \"Length\": 10, \"BaseOdds\": 725760.00, \"IsFixOdds\": false, \"Modulus\": 3628800.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 3628800.00, \"MaxBonusMode\": 3556224.00, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5,6,7,8,9,10\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_11"].Split(';') : dicConfigs["race_betratio_11"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110101, \"RuleName\": \"大\", \"DisplayName\": \"前三和值-大\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^大$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110102, \"RuleName\": \"小\", \"DisplayName\": \"前三和值-小\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^小$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[2])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110103, \"RuleName\": \"单\", \"DisplayName\": \"前三和值-单\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^单$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110104, \"RuleName\": \"双\", \"DisplayName\": \"前三和值-双\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^双$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[4])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110105, \"RuleName\": \"6\", \"DisplayName\": \"前三和值-6\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^6$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[5])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110106, \"RuleName\": \"7\", \"DisplayName\": \"前三和值-7\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^7$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[6])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110107, \"RuleName\": \"8\", \"DisplayName\": \"前三和值-8\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^8$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 51.00, \"IsFixOdds\": false, \"Modulus\": 60.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 60.00, \"MaxBonusMode\": 58.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[7])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110108, \"RuleName\": \"9\", \"DisplayName\": \"前三和值-9\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^9$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 34.00, \"IsFixOdds\": false, \"Modulus\": 40.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 40.00, \"MaxBonusMode\": 39.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[8])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110109, \"RuleName\": \"10\", \"DisplayName\": \"前三和值-10\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^10$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 25.50, \"IsFixOdds\": false, \"Modulus\": 30.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 30.00, \"MaxBonusMode\": 29.40, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[9])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110110, \"RuleName\": \"11\", \"DisplayName\": \"前三和值-11\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^11$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 20.40, \"IsFixOdds\": false, \"Modulus\": 24.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 24.00, \"MaxBonusMode\": 23.52, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[10])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110111, \"RuleName\": \"12\", \"DisplayName\": \"前三和值-12\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^12$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 14.57, \"IsFixOdds\": false, \"Modulus\": 17.14, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 17.14, \"MaxBonusMode\": 16.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[11])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110112, \"RuleName\": \"13\", \"DisplayName\": \"前三和值-13\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^13$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 12.75, \"IsFixOdds\": false, \"Modulus\": 15.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 15.00, \"MaxBonusMode\": 14.70, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[12])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110113, \"RuleName\": \"14\", \"DisplayName\": \"前三和值-14\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^14$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 11.33, \"IsFixOdds\": false, \"Modulus\": 13.33, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 13.33, \"MaxBonusMode\": 13.06, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[13])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110114, \"RuleName\": \"15\", \"DisplayName\": \"前三和值-15\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^15$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 10.20, \"IsFixOdds\": false, \"Modulus\": 12.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 12.00, \"MaxBonusMode\": 11.76, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[14])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110115, \"RuleName\": \"16\", \"DisplayName\": \"前三和值-16\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^16$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 10.20, \"IsFixOdds\": false, \"Modulus\": 12.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 12.00, \"MaxBonusMode\": 11.76, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[15])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110116, \"RuleName\": \"17\", \"DisplayName\": \"前三和值-17\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^17$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 10.20, \"IsFixOdds\": false, \"Modulus\": 12.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 12.00, \"MaxBonusMode\": 11.76, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[16])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110117, \"RuleName\": \"18\", \"DisplayName\": \"前三和值-18\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^18$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 10.20, \"IsFixOdds\": false, \"Modulus\": 12.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 12.00, \"MaxBonusMode\": 11.76, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[17])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110118, \"RuleName\": \"19\", \"DisplayName\": \"前三和值-19\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^19$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 11.33, \"IsFixOdds\": false, \"Modulus\": 13.33, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 13.33, \"MaxBonusMode\": 13.06, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[18])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110119, \"RuleName\": \"20\", \"DisplayName\": \"前三和值-20\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^20$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 12.75, \"IsFixOdds\": false, \"Modulus\": 15.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 15.00, \"MaxBonusMode\": 14.70, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[19])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110120, \"RuleName\": \"21\", \"DisplayName\": \"前三和值-21\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^21$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 14.57, \"IsFixOdds\": false, \"Modulus\": 17.14, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 17.14, \"MaxBonusMode\": 16.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[20])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110121, \"RuleName\": \"22\", \"DisplayName\": \"前三和值-22\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^22$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 20.40, \"IsFixOdds\": false, \"Modulus\": 24.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 24.00, \"MaxBonusMode\": 23.52, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[21])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110122, \"RuleName\": \"23\", \"DisplayName\": \"前三和值-23\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^23$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 25.50, \"IsFixOdds\": false, \"Modulus\": 30.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 30.00, \"MaxBonusMode\": 29.40, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[22])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110123, \"RuleName\": \"24\", \"DisplayName\": \"前三和值-24\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^24$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 34.00, \"IsFixOdds\": false, \"Modulus\": 40.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 40.00, \"MaxBonusMode\": 39.20, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[23])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110124, \"RuleName\": \"25\", \"DisplayName\": \"前三和值-25\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^25$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 51.00, \"IsFixOdds\": false, \"Modulus\": 60.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 60.00, \"MaxBonusMode\": 58.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[24])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110125, \"RuleName\": \"26\", \"DisplayName\": \"前三和值-26\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^26$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[25])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8110126, \"RuleName\": \"27\", \"DisplayName\": \"前三和值-27\", \"SubTypeId\": 81101, \"MatchType\": \"和值\", \"SelectedRegex\": \"^27$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 102.00, \"IsFixOdds\": false, \"Modulus\": 120.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 120.00, \"MaxBonusMode\": 117.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_12"].Split(';') : dicConfigs["race_betratio_12"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8120101, \"RuleName\": \"自由双面\", \"DisplayName\": \"自由双面\", \"SubTypeId\": 81201, \"MatchType\": \"自由双面\", \"SelectedRegex\": \"^(([大|小|单|双]{0,1})(( [大|小|单|双]){0,4}[,]?)){1,3}$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_13"].Split(';') : dicConfigs["race_betratio_13"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8130101, \"RuleName\": \"1至3\", \"DisplayName\": \"1至3\", \"SubTypeId\": 81301, \"MatchType\": \"猜名次\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 0, \"Length\": 3, \"BaseOdds\": 2.83, \"IsFixOdds\": false, \"Modulus\": 3.33, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 3.33, \"MaxBonusMode\": 3.26, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8130102, \"RuleName\": \"4至6\", \"DisplayName\": \"4至6\", \"SubTypeId\": 81301, \"MatchType\": \"猜名次\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 3, \"Length\": 3, \"BaseOdds\": 2.83, \"IsFixOdds\": false, \"Modulus\": 3.33, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 3.33, \"MaxBonusMode\": 3.26, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[2])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8130103, \"RuleName\": \"7至10\", \"DisplayName\": \"7至10\", \"SubTypeId\": 81301, \"MatchType\": \"猜名次\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 6, \"Length\": 4, \"BaseOdds\": 2.13, \"IsFixOdds\": false, \"Modulus\": 2.50, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.50, \"MaxBonusMode\": 2.45, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[3])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8130104, \"RuleName\": \"1至5\", \"DisplayName\": \"1至5\", \"SubTypeId\": 81301, \"MatchType\": \"猜名次\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 0, \"Length\": 5, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[4])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8130105, \"RuleName\": \"6至10\", \"DisplayName\": \"6至10\", \"SubTypeId\": 81301, \"MatchType\": \"猜名次\", \"SelectedRegex\": \"^(0[1-9]|10)( (0[1-9]|10)){0,9}$\", \"StartIndex\": 5, \"Length\": 5, \"BaseOdds\": 1.70, \"IsFixOdds\": false, \"Modulus\": 2.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2.00, \"MaxBonusMode\": 1.96, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_14"].Split(';') : dicConfigs["race_betratio_14"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8140101, \"RuleName\": \"前五定位胆\", \"DisplayName\": \"前五定位胆\", \"SubTypeId\": 81401, \"MatchType\": \"定位胆\", \"SelectedRegex\": \"^((0[1-9]| |10){0,19},?){1,5}$\", \"StartIndex\": 0, \"Length\": 10, \"BaseOdds\": 8.50, \"IsFixOdds\": false, \"Modulus\": 10.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 10.00, \"MaxBonusMode\": 9.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5\" }, ";
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[1])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8140102, \"RuleName\": \"后五定位胆\", \"DisplayName\": \"后五定位胆\", \"SubTypeId\": 81401, \"MatchType\": \"定位胆\", \"SelectedRegex\": \"^((0[1-9]| |10){0,19},?){1,5}$\", \"StartIndex\": 0, \"Length\": 10, \"BaseOdds\": 8.50, \"IsFixOdds\": false, \"Modulus\": 10.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 10.00, \"MaxBonusMode\": 9.80, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"6,7,8,9,10\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_15"].Split(';') : dicConfigs["race_betratio_15"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8150101, \"RuleName\": \"4\", \"DisplayName\": \"趣味猜前四名\", \"SubTypeId\": 81501, \"MatchType\": \"趣味猜前四名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){3}$\", \"StartIndex\": 0, \"Length\": 4, \"BaseOdds\": 2142.00, \"IsFixOdds\": false, \"Modulus\": 2520.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 2520.00, \"MaxBonusMode\": 2469.60, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4\" }, ";
        strRatios = bMajang ? dicConfigs["race_betratio_m_16"].Split(';') : dicConfigs["race_betratio_16"].Split(';');
        strRules += "{ \"UserOdds\": " + string.Format("{0:F2}", Convert.ToDouble(strRatios[0])) + ", \"UserPlusOdds\": 0.0, \"RuleId\": 8160101, \"RuleName\": \"5\", \"DisplayName\": \"趣味猜前五名\", \"SubTypeId\": 81601, \"MatchType\": \"趣味猜前五名\", \"SelectedRegex\": \"^(0[1-9]|10)( +(0[1-9]|10)){0,9}(,(0[1-9]|10)( +(0[1-9]|10)){0,9}){4}$\", \"StartIndex\": 0, \"Length\": 5, \"BaseOdds\": 8568.00, \"IsFixOdds\": false, \"Modulus\": 10080.00, \"SortOrder\": 0, \"IsEnable\": true, \"LotteryProbability\": 10080.00, \"MaxBonusMode\": 9878.40, \"ExtractingRate\": 98.00, \"MaxBetNum\": 0, \"RuleTip\": null, \"NumPanel\": \"1,2,3,4,5\"}]";
        #endregion

        #region 최신게임결과부분
        DataSet GameDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST,
            new string[] { "@lottery", "@rowcount" }, new object[] { Constants.GAMETYPE_RACE, 5 });
        string strTop5GameHist = "";
        string strUnitFormat = "{{ \"LotteryCode\": 8, \"LotteryHash\": \"pk10\", \"Id\": {0}, \"IssueNumber\": \"{1}\", \"BonusNumber\": \"{2}\", \"LotteryName\": \"PK10\", \"BonusDateTime\": \"{3:yyyy-MM-dd HH:mm:ss}\" }}";
        string strComma = "";
        for (int i = 0; i < DataSetUtil.RowCount(GameDataSource); i++)
        {
            string strNumber = string.Format("{0:D2},{1:D2},{2:D2},{3:D2},{4:D2},{5:D2},{6:D2},{7:D2},{8:D2},{9:D2}",
                                            DataSetUtil.RowIntValue(GameDataSource, "rank1", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank2", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank3", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank4", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank5", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank6", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank7", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank8", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank9", i),
                                            DataSetUtil.RowIntValue(GameDataSource, "rank10", i));

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
            new string[] { "gl.pk10", "gl.lotteryId", "gl.lotteryName", "gl.rules", "gl.betAssistData", "gl.betAssistData.top5" },
            new string[] { "{}", Constants.GAMETYPE_RACE.ToString(), "\"" + Lotterys[Constants.GAMETYPE_RACE].Name + "\"", strRules, "{}", strTop5GameHist });

        #region Zhuihao배팅설정부분
        DataSet dsGame = DBConn.RunStoreProcedure(Constants.SP_GETCURRENTGAME, new string[] { "@lottery" }, new object[] { Constants.GAMETYPE_RACE });
        string strTraceList = "";
        if (!DataSetUtil.IsNullOrEmpty(dsGame))
        {
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
            for (int i = 0; i < 60; i++)
            {
                strTraceList += string.Format(strChuihaoFormat, lCurRound, lCurRound, dtCurStart.ToString("yyyy-MM-dd HH:mm:ss"));
                lCurRound++;
                dtCurStart = dtCurStart.AddMinutes(5);
            }
        }
        ltlTraceList.Text = strTraceList;
        #endregion

        #region Zhuihao배팅리력부분
        DataSet dsZhuiHaoBet = DBConn.RunSelectQuery("select top(5) * from zhuihaos where lottery = 8 and userid = @userid", new string[] { "@userid" }, new object[] { AuthUser.ID });
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
                                            "<span class=\"title\">极速赛车</span>\n" +
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
