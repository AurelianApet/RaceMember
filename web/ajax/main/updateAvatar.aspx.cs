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

public partial class ajax_main_updateAvatar : Ronaldo.uibase.AjaxPageBase
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
            string strEncodedParam = Request.Form["avatar"];

            DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { AuthUser.ID });
            if (DataSetUtil.IsNullOrEmpty(dsUser))
                throw new Exception("0");

            DBConn.RunStoreProcedure(Constants.SP_UPDATEUSER, new string[] { "@id", "@avatar" }, new object[] { AuthUser.ID, strEncodedParam });

        }
        catch (Exception ex)
        {
            Response.Write(string.Format("\"{0}\"", ex.Message));
            Response.End();
        }
        Response.Write(string.Format("\"1\"", strReturnData));
        Response.End();
    }
}
