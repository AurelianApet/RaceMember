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

using DataAccess;
using Ronaldo.common;

public partial class Member_lddr_chart : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        string strType = Request.Params["mode"].ToString();
        string strRet = "<script language=\"javascript\" type=\"text/javascript\">\n";
        strRet += "(function() {\n";
        strRet += "gl.title = \"走势图 - K彩\";\n";
        strRet += "ctx.trendReadyNotice = {};\n";
        strRet += "var lotteryId = 25;\n";
        strRet += "var trendClient = null;\n";
        
        DataSet dsChartData = DBConn.RunSelectQuery("select top(121) * from chartdatas_ladder order by sdate desc");
        DateTime dtStartTime = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(dsChartData, "sdate", 0));
        long lRound = DataSetUtil.RowLongValue(dsChartData, "round", 0);
        DataSet dsGame = DBConn.RunSelectQuery("select * from gamehist_ladder where sdate = @sdate and round = @round", new string[] { "@sdate", "@round" }, new object[] { dtStartTime, lRound });
        
        string strChartData = "";
        string strOneDataFormat = ", \"{0};{1};{2};{3};{4};{5};{6};{7}\"";
        for (int i = 0; i < DataSetUtil.RowCount(dsChartData); i++)
        {
            string strOneGameChartData = "";
            string strResult = DataSetUtil.RowStringValue(dsChartData, "result", i);
            long lGameRound = DataSetUtil.RowLongValue(dsChartData, "round", i);
            DateTime dtSDate = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(dsChartData, "sdate", i));
            string[] strResultParam = strResult.Split(',');
            strResult = string.Format("{0},{1},{2}", Convert.ToInt32(strResultParam[0]) == 1 ? "<font color='blue'>左</font>" : "右", Convert.ToInt32(strResultParam[1]) == 1 ? "<font color='blue'>3</font>" : "4", Convert.ToInt32(strResultParam[2]) == 1 ? "<font color='blue'>单</font>" : "双");
            if (dtSDate.AddMinutes(5) >= DateTime.Now)
                continue;

            if (dtSDate >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                lGameRound += 1000;

            bool bFirst = false;
            if (strType == "jiben" || strType == "startpos")
            {
                string strStartPosVal = DataSetUtil.RowStringValue(dsChartData, "startpos_val", i);
                string strStartPosSta = DataSetUtil.RowStringValue(dsChartData, "startpos_sta", i);
                strOneGameChartData += string.Format(strOneDataFormat,
                            !bFirst ? lGameRound.ToString() : "",
                            !bFirst ? strResult : "",
                            0,
                            "左",
                            Convert.ToInt32(strStartPosVal.Split('-')[0]),
                            strStartPosSta.Split('-')[0].Split(',')[0],
                            strStartPosSta.Split('-')[0].Split(',')[1],
                            Convert.ToInt32(strResultParam[0]) == 1 ? 1 : 0);

                strOneGameChartData += string.Format(strOneDataFormat,
                            "",
                            "",
                            0,
                            "右",
                            Convert.ToInt32(strStartPosVal.Split('-')[1]),
                            strStartPosSta.Split('-')[1].Split(',')[0],
                            strStartPosSta.Split('-')[1].Split(',')[1],
                            Convert.ToInt32(strResultParam[0]) == 1 ? 0 : 1);

                bFirst = true;
            }
            if (strType == "jiben" || strType == "laddercount")
            {
                string strLadderCountVal = DataSetUtil.RowStringValue(dsChartData, "laddercount_val", i);
                string strLadderCountSta = DataSetUtil.RowStringValue(dsChartData, "laddercount_sta", i);
                strOneGameChartData += string.Format(strOneDataFormat,
                            !bFirst ? lGameRound.ToString() : "",
                            !bFirst ? strResult : "",
                            !bFirst ? 0 : 1,
                            "3",
                            Convert.ToInt32(strLadderCountVal.Split('-')[0]),
                            strLadderCountSta.Split('-')[0].Split(',')[0],
                            strLadderCountSta.Split('-')[0].Split(',')[1],
                            Convert.ToInt32(strResultParam[1]) == 1 ? 1 : 0);

                strOneGameChartData += string.Format(strOneDataFormat,
                            "",
                            "",
                            !bFirst ? 0 : 1,
                            "4",
                            Convert.ToInt32(strLadderCountVal.Split('-')[1]),
                            strLadderCountSta.Split('-')[1].Split(',')[0],
                            strLadderCountSta.Split('-')[1].Split(',')[1],
                            Convert.ToInt32(strResultParam[1]) == 1 ? 0 : 1);
                bFirst = true;
            }
            if (strType == "jiben" || strType == "oddeven")
            {
                string strOddEvenVal = DataSetUtil.RowStringValue(dsChartData, "oddeven_val", i);
                string strOddEvenSta = DataSetUtil.RowStringValue(dsChartData, "oddeven_sta", i);
                strOneGameChartData += string.Format(strOneDataFormat,
                            !bFirst ? lGameRound.ToString() : "",
                            !bFirst ? strResult : "",
                            !bFirst ? 0 : 2,
                            "单",
                            Convert.ToInt32(strOddEvenVal.Split('-')[0]),
                            strOddEvenSta.Split('-')[0].Split(',')[0],
                            strOddEvenSta.Split('-')[0].Split(',')[1],
                            Convert.ToInt32(strResultParam[2]) == 1 ? 1 : 0);

                strOneGameChartData += string.Format(strOneDataFormat,
                            "",
                            "",
                            !bFirst ? 0 : 2,
                            "双",
                            Convert.ToInt32(strOddEvenVal.Split('-')[1]),
                            strOddEvenSta.Split('-')[1].Split(',')[0],
                            strOddEvenSta.Split('-')[1].Split(',')[1],
                            Convert.ToInt32(strResultParam[2]) == 1 ? 0 : 1);
                bFirst = true;
            }
            strChartData = strOneGameChartData + strChartData;
        }

        switch (strType)
        {
            case "jiben":
                strChartData = "trendClient = new TrendClient(25, [\"左右走势,34走势,单双走势\"" + strChartData + "]);\n";
                strRet += strChartData;
                break;
            case "startpos":
                strChartData = "trendClient = new TrendClient(25, [\"左右走势\"" + strChartData + "]);\n";
                strRet += strChartData;
                break;
            case "laddercount":
                strChartData = "trendClient = new TrendClient(25, [\"34走势\"" + strChartData + "]);\n";
                strRet += strChartData;
                break;
            case "oddeven":
                strChartData = "trendClient = new TrendClient(25, [\"单双走势\"" + strChartData + "]);\n";
                strRet += strChartData;
                break;
            default:
                break;
        }
        strRet += "trendClient.init();\n";
        strRet += "})();\n";
        strRet += "</script>";
        ltlScript.Text += strRet;
    }
}
