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

public partial class ajax_main_getZhuihaoInfo : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        string strFormat = "[{0}]";
        string strUnitFormat = "\"EncodeId\":\"{0}\",\"RuleName\":\"{1}\",\"LotteryName\":\"{2}\",\"TStatus\":\"{3}\",\"IssueNumber\":\"{4}\",\"LotteryCode\":8,\"BetRuleId\":{5},\"Id\":{6},\"CreateTime\":\"/Date(1465985120000)/\",\"BetContent\":\"{7}\",\"TotalAmount\":{8},\"IsStopWhenBonus\":{9},\"TotalIssue\":{10},\"OverIssue\":{11},\"CancelIssue\":{12},\"Mark\":\"\"";
        string strResult = "";
        try
        {
            DataSet dsBetHist = DBConn.RunSelectQuery("select top(5) * from zhuihaos where userid = @userid order by regdate desc", new string[] { "@userid" }, new object[] { AuthUser.ID });
            string strBetData = "";
            string strComma = "";
            for (int i = 0; i < DataSetUtil.RowCount(dsBetHist); i++)
            {
                int nLottery = DataSetUtil.RowIntValue(dsBetHist, "lottery", i);
                int nStatus = DataSetUtil.RowIntValue(dsBetHist, "status", i);
                long lStartRound = DataSetUtil.RowLongValue(dsBetHist, "startround", i);
                string strBetInfo = DataSetUtil.RowStringValue(dsBetHist, "betinfo", i);
                string[] strBetParams = strBetInfo.Split('-');
                int nBetType = Convert.ToInt32(strBetParams[4]);
                string strBetVal = strBetParams[5];

                strBetData += strComma + "{" + string.Format(strUnitFormat,
                                    DataSetUtil.RowLongValue(dsBetHist, "id", i),
                                    getBetMode(nBetType),
                                    Lotterys[nLottery].Name,
                                    nStatus == 1 ? "已完成" : "进行中",
                                    lStartRound,
                                    nBetType,
                                    800932,
                                    strBetVal,
                                    string.Format("{0:F2}", DataSetUtil.RowStringValue(dsBetHist, "betmoney", i)),
                                    "true",
                                    DataSetUtil.RowIntValue(dsBetHist, "totalstep", i),
                                    DataSetUtil.RowIntValue(dsBetHist, "curstep", i),
                                    0) + "}";
                strComma = ",";
            }
            strResult = "[" + strBetData + "]";
        }
        catch (Exception ex)
        {
            Response.Write(string.Format(strFormat, "[]"));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
