using System;
using System.Collections;
using System.Collections.Generic;
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


public partial class Member_discharge : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { AuthUser.ID });
        string strBankName = DataSetUtil.RowStringValue(dsUser, "bankname", 0);
        string strBankNum = DataSetUtil.RowStringValue(dsUser, "banknum", 0);
        string strOwnerName = DataSetUtil.RowStringValue(dsUser, "bankowner", 0);

        strBankNum = strBankNum.Length >= 8 ? strBankNum.Substring(0, 4) + "******************" + strBankNum.Substring(strBankNum.Length - 3) : strBankNum;
        strOwnerName = strOwnerName.Length >= 2 ? strOwnerName.Substring(0, 1) + "*" + strOwnerName.Substring(strOwnerName.Length - 1) : strOwnerName;

        string strRet = "<script language=\"javascript\" type=\"text/javascript\">\n";
        strRet += "gl.title = '提现 - K彩';\n";
        strRet += "var withdraw_WithDrawTitle = \"" + strBankName + "\"\n";
        strRet += "var withdraw_AccoutNo = \"" + strBankNum + "\";\n";
        strRet += "var withdraw_AccoutName = \"" + strOwnerName + "\";\n";
        strRet += "var withdraw_AvailablePoint = \"" + string.Format("{0:F2}", UserCash) + "\";\n";
        strRet += "var withdraw_MaxWithdrawCount = \"5\";\n";
        strRet += "var withdraw_MinWithdrawAmount = \"100\";\n";
        strRet += "var withdraw_MaxWithdrawAmount = \"100000\";\n";
        strRet += "var withdraw_RemainWithdrawCount = \"5\";\n";
        strRet += "var withdraw_hasSerialNumber = \"False\";\n";
        strRet += "$(function() {\n";
        strRet += "init_memberWithdraw();\n";
        strRet += "});\n";
        strRet += "</script>";

        ltlScript.Text = strRet;
    }
}
