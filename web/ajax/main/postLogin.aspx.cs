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

public partial class ajax_main_postLogin : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        string strLoginID = Request.Params["username"];
        string strLoginPwd = Request.Params["password"];
        string strValicode = Request.Params["valicode"];

        string strResult = "";
        try
        {
            if (string.IsNullOrEmpty(strLoginID) || strLoginID == Resources.Str.STR_LOGINID)
                throw new Exception();

            if (string.IsNullOrEmpty(strLoginPwd) || strLoginPwd == Resources.Str.STR_LOGINPWD)
                throw new Exception();

            if (!UserLogin(strLoginID, strLoginPwd))
                throw new Exception();

            strResult = "\"suc\"";
        }
        catch (Exception ex)
        {
            writeLog(ex.Message);
            Response.Write("\"fail\"");
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
