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

public partial class ajax_lottery_StickLottery : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        string strMainLotterys = Request.Params["val"];

        string strResult = "{{\"success\":{0}{1}}}";
        try
        {
            if (strMainLotterys.IndexOf(",") >= 0)
                strMainLotterys = strMainLotterys.Replace(",", "-");
            else
            {
                DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { AuthUser.ID });
                string strUserMainLottery = DataSetUtil.RowStringValue(dsUser, "main_lottery", 0);
                if (strUserMainLottery.IndexOf(strMainLotterys) < 0)
                    throw new Exception("The Selected Lottery is not in Base Lotterys!");

                string[] strTmp = strUserMainLottery.Split('-');
                strUserMainLottery = strMainLotterys;
                for (int i = 0; i < strTmp.Length; i++)
                {
                    if (strMainLotterys != strTmp[i])
                        strUserMainLottery += "-" + strTmp[i];
                }
                strMainLotterys = strUserMainLottery;
            }
            DBConn.RunStoreProcedure(Constants.SP_UPDATEUSER, new string[] { "@id", "@mainlottery" }, new object[] { AuthUser.ID, strMainLotterys });
            strResult = string.Format(strResult, "true", "");

        }
        catch (Exception ex)
        {
            Response.Write(string.Format(strResult, "false", ", \"msg\":\"" + ex.Message + "\""));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
