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

public partial class ajax_main_postJoin : Ronaldo.uibase.AjaxPageBase
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
        string strNick = Request.Params["usernick"];
        string strLoginPwd = Request.Params["password"];
        string strConfirmLoginPwd = Request.Params["confirmpassword"];

        string strResult = "";
        string strErr = "";
        try
        {
            string strSite = Request.Url.Host;
            strSite.Replace("www.", "");
            DataSet dsSite = DBConn.RunStoreProcedure(Constants.SP_GETSITE,
                    new string[] { "@siteurl" }, new object[] { strSite });
            int nSite = 0;
            if (!DataSetUtil.IsNullOrEmpty(dsSite))
                nSite = DataSetUtil.RowIntValue(dsSite, "id", 0);

            if (!validateInput(strLoginID, strLoginPwd, strConfirmLoginPwd, strNick, null, true, out strErr))
                throw new Exception(strErr);

            // 아이디중복검사
            if (!DataSetUtil.IsNullOrEmpty(DBConn.RunStoreProcedure(
                Constants.SP_GETUSER,
                new string[] {
                    "@loginid"
                },
                new object[] {
                    strLoginID
                })
            ))
                throw new Exception("用户名已在使用中。");

            // 닉네임중복검사
            if (!DataSetUtil.IsNullOrEmpty(DBConn.RunStoreProcedure(
                Constants.SP_GETUSER,
                    new string[] {
                    "@nick"
                },
                new object[] {
                    strNick
                })
            ))
                throw new Exception("署名已在使用中。");

            long lUserID = DataSetUtil.GetID(
                DBConn.RunStoreProcedure(Constants.SP_CREATEUSER,
                    new string[] {
                        "@loginid",
                        "@loginpwd",
                        "@nick",
                        "@site",
                        "@reg_ip"
                    },
                    new object[] {
                        strLoginID,
                        CryptSHA256.Encrypt(strLoginPwd),
                        strNick,
                        nSite,
                        UserIP
                    })
                );

            strResult = string.Format("{{\"status\":\"suc\", \"msg\":\"\"}}");
        }
        catch (Exception ex)
        {
            Response.Write(string.Format("{{\"status\":\"fail\", \"msg\":\"{0}\"}}", ex.Message));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }
}
