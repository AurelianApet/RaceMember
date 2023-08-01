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

public partial class ajax_main_getUserGamePointData : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        string strResult = "";
        try
        {
            strResult = string.Format("\"GamePoint\":{0:F2}", UserCash);
        }
        catch (Exception ex)
        {
            Response.Write(string.Format("\"GamePoint\":0"));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
