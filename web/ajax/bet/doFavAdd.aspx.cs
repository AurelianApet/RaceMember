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

public partial class ajax_bet_doFavAdd : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        string strReturnData = "";
        try
        {
            string strEncodedParam = Request.Form["info"];

            int nLotteryID = Convert.ToInt32(Request.Params["lotteryId"]);
            int nN = Convert.ToInt32(Request.Params["n"]);
            string strTitle = Request.Params["t"].ToString();
            string strList = Request.Params["list"].ToString();
            double dPrice = Convert.ToDouble(Request.Params["totalPrice"]);

            long lID = DataSetUtil.GetID(DBConn.RunStoreProcedure(Constants.SP_CREATEFAV,
                new string[]{
                    "@user_id",
                    "@lotteryId",
                    "@num",
                    "@title",
                    "@list",
                    "@totalPrice"
                },
                new object[]{
                    AuthUser.ID,
                    nLotteryID,
                    nN,
                    strTitle,
                    strList,
                    dPrice
                }));

            string[] strListParams = strList.Split(';');
            string strContent = "[";
            string strComma = "";
            for (int i = 0; i < strListParams.Length; i++)
            {
                strContent = strContent + strComma + "{";
                string[] strOneParams = strListParams[i].Split('-');
                strContent += "\\\"ItemTimes\\\":" + strOneParams[1] + ",\\\"SelNums\\\":\\\"" + strOneParams[4] + "\\\",\\\"RuleId\\\":" + strOneParams[3] + ",\\\"BetNum\\\":" + strOneParams[0] + ",\\\"PriceMode\\\":" + strOneParams[2];
                strContent += "}";
                strComma = ",";
            }
            strContent += "]";

            strReturnData += "{";
            strReturnData += "\"CreateTimeISO\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\", ";
            strReturnData += "\"Id\": " + lID.ToString() + ", ";
            strReturnData += "\"LotteryCode\": " + nLotteryID.ToString() + ", ";
            strReturnData += "\"UserId\": " + AuthUser.ID.ToString() + ", ";
            strReturnData += "\"FavName\": \"" + strTitle + "\", ";
            strReturnData += "\"FavContent\": \"" + strContent + "\", ";
            strReturnData += "\"CreateTime\": \"\\/Date(1466288351345)\\/\", ";
            strReturnData += "\"FavTotalPrice\": " + string.Format("{0:F2}", dPrice);
            strReturnData += "}";


        }
        catch (Exception ex)
        {
            Response.Write(string.Format("{{Ok:0, Tip:\"{0}\"}}", ex.Message));
            Response.End();
        }
        Response.Write(string.Format("{{\"Ok\":1, \"Tip\":\"\", \"Fav\":{0}}}", strReturnData));
        Response.End();
    }
}
