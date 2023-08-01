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

public partial class ajax_lottery_GetScheduleAndIssueNumber : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        string strFormat = "{{\"advance\":\"{7}\", " +
                            "\"differ\":\"{0}\", " +
                            "\"issue_number\":\"{1}\", " +
                            "\"lottery_get_time\":\"{2:yyyy-MM-dd HH:mm:ss}\", " +
                            "\"lottery_time\":\"{3:yyyy-MM-dd HH:mm:ss}\", " +
                            "\"nextIssueNumber\":\"{4}\", " +
                            "\"oneIssueTime\":\"{5}\", " +
                            "\"preIssueNumber\":\"{6}\"}}";

        string strResult = "";
        try
        {
            int nLotteryNum = Convert.ToInt32(Request.Params["sel"]);
            DataSet dsGame = DBConn.RunStoreProcedure(Constants.SP_GETCURRENTGAME, new string[] { "@lottery" }, new object[] { nLotteryNum });
            long lCurrRound = DataSetUtil.RowLongValue(dsGame, "round", 0);
            DateTime dtStartTime = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(dsGame, "sdate", 0));

            TimeSpan tsDiff = new TimeSpan();
            if(nLotteryNum == Constants.GAMETYPE_RACE)
                tsDiff = dtStartTime - DateTime.Now;
            else
                tsDiff = dtStartTime.AddMinutes(5) - DateTime.Now;
            if (nLotteryNum == Constants.GAMETYPE_RACE)
                strResult = string.Format(strFormat, tsDiff.TotalSeconds - 30 , lCurrRound, DateTime.Now, dtStartTime, lCurrRound + 1, 300, lCurrRound - 1, 50);
            else
                strResult = string.Format(strFormat, tsDiff.TotalSeconds - 30, lCurrRound, DateTime.Now, dtStartTime.AddMinutes(5), lCurrRound + 1, 300, lCurrRound - 1, 50);
        }
        catch (Exception ex)
        {
            writeLog(ex.Message);
            Response.Write(string.Format(strFormat, 0, 0, 0, 0, 0, 0, 0, 0));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
