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

public partial class ajax_main_postDischarge : Ronaldo.uibase.AjaxPageBase
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

            string strPw = Request.Params["pw"].ToString();
            double dPrice = Convert.ToDouble(Request.Params["reqmoney"]);

            DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { AuthUser.ID });

            if (DataSetUtil.IsNullOrEmpty(dsUser))
                throw new Exception("您的情报不一致！");

            string strDischargePw = DataSetUtil.RowStringValue(dsUser, "discharge_pwd", 0);
            if (strPw != strDischargePw)
                throw new Exception("提现密码不正确！");

            if (dPrice < 10)
                throw new Exception("10元以下无法提现！");

            if (dPrice > UserCash)
                throw new Exception("提现额度高于保有金额，请重新确认提现金额。");

            string strBankName = DataSetUtil.RowStringValue(dsUser, "bankname", 0);
            string strBankNum = DataSetUtil.RowStringValue(dsUser, "banknum", 0);
            string strOwnerName = DataSetUtil.RowStringValue(dsUser, "bankowner", 0);

            if (InsertCash(AuthUser.ID, 0, dPrice, string.Format(Resources.Desc.DESC_DISCHARGE, dPrice)) &&
            !DataSetUtil.IsNullOrEmpty(DBConn.RunStoreProcedure(Constants.SP_CREATEMONEYINOUT,
            new string[] {
                "@user_id",
                "@loginid",
                "@nick",
                "@site",
                "@bankname",
                "@ownernum",
                "@ownername",
                "@reqmoney",
                "@kind"
            },
            new object[] {
                AuthUser.ID,
                DataSetUtil.RowStringValue(dsUser, "loginid", 0),
                DataSetUtil.RowStringValue(dsUser, "nick", 0),
                DataSetUtil.RowStringValue(dsUser, "site", 0),
                strBankName,
                strBankNum,
                strOwnerName,
                dPrice,
                Constants.MONEYINOUT_DISCHARGE
            })))
            {
                strReturnData = Resources.Msg.MSG_DISCHARGE_REQUEST;
            }
            else
                throw new Exception(Resources.Err.ERR_DISCHARGE_ERROR);
        }
        catch (Exception ex)
        {
            Response.Write(string.Format("\"{0}\"", ex.Message));
            Response.End();
        }
        Response.Write(string.Format("\"{0}\"", strReturnData));
        Response.End();
    }
}
