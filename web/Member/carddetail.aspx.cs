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

public partial class Member_carddetail : Ronaldo.uibase.PageBase
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
        if (string.IsNullOrEmpty(strBankName))
        {
            pnlSetBankInfo.Visible = true;
            pnlViewBankInfo.Visible = false;
        }
        else
        {
            pnlSetBankInfo.Visible = false;
            pnlViewBankInfo.Visible = true;
            string strBankNum = DataSetUtil.RowStringValue(dsUser, "banknum", 0);
            string strOwnerName = DataSetUtil.RowStringValue(dsUser, "bankowner", 0);
            strBankNum = strBankNum.Length >= 8 ? strBankNum.Substring(0, 4) + "******************" + strBankNum.Substring(strBankNum.Length - 3) : strBankNum;
            strOwnerName = strOwnerName.Length >= 2 ? strOwnerName.Substring(0, 1) + "*" + strOwnerName.Substring(strOwnerName.Length - 1) : strOwnerName;

            ltlBankName.Text = strBankName;
            ltlBankNum.Text = strBankNum;
            ltlBankOwner.Text = strOwnerName;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbxBankName.Text))
        {
            ShowMessageBox("请输入持卡人姓名!");
            return;
        }
        if (string.IsNullOrEmpty(tbxBankOwner.Text))
        {
            ShowMessageBox("请输入持卡人姓名!");
            return;
        }
        if (string.IsNullOrEmpty(tbxBankNum.Text))
        {
            ShowMessageBox("请输入银行卡号!");
            return;
        }
        if (tbxBankNum.Text != tbxBankNumConfirm.Text)
        {
            ShowMessageBox("输入的银行卡号不一致!");
            return;
        }
        if (string.IsNullOrEmpty(tbxDischargePwd.Text))
        {
            ShowMessageBox("请输入提现密码!");
            return;
        }
        if (tbxDischargePwd.Text != tbxDischargePwdConfirm.Text)
        {
            ShowMessageBox("输入的提现密码不一致!");
            return;
        }

        DBConn.RunStoreProcedure(Constants.SP_UPDATEUSER,
                new string[]{
                    "@id",
                    "@bankname",
                    "@bankowner",
                    "@banknum",
                    "@discharge_pwd"
                },
                new object[]{
                    AuthUser.ID,
                    tbxBankName.Text,
                    tbxBankOwner.Text,
                    tbxBankNum.Text,
                    tbxDischargePwd.Text
                });

        ShowMessageBox("保存成功!");
        PageDataSource = null;
        BindData();
    }
}
