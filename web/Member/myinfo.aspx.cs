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

using DataAccess;
using Ronaldo.common;

public partial class Member_myinfo : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        ltlLoginID.Text = AuthUser.LoginID;
        DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@loginid" }, new object[] { AuthUser.LoginID });
        ltlAvatar.Text = string.Format("<img name=\"user-avatar\" id=\"current-avatar\" src=\"{0}\" alt=\"\" />", DataSetUtil.RowStringValue(dsUser, "avatar", 0));
        tbxNick.Text = DataSetUtil.RowStringValue(dsUser, "nick", 0);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbxNick.Text))
        {
            ShowMessageBox("请输入真实姓名!");
            return;
        }
        if (!string.IsNullOrEmpty(tbxOldPwb.Text) && AuthUser.LoginPwd != CryptSHA256.Encrypt(tbxOldPwb.Text))
        {
            ShowMessageBox("输入的原密码错误！");
            return;
        }
        if ((!string.IsNullOrEmpty(tbxNewPwb.Text) && tbxNewPwb.Text != tbxConfirmPwb.Text) || (!string.IsNullOrEmpty(tbxConfirmPwb.Text) && tbxNewPwb.Text != tbxConfirmPwb.Text))
        {
            ShowMessageBox("输入的新密码不一致！");
            return;
        }

        DBConn.RunStoreProcedure(Constants.SP_UPDATEUSER,
                new string[]{
                    "@id",
                    "@nick",
                    "@loginpwd"
                },
                new object[]{
                    AuthUser.ID,
                    tbxNick.Text,
                    (string.IsNullOrEmpty(tbxNewPwb.Text) ? null : CryptSHA256.Encrypt(tbxNewPwb.Text))
                });

        ShowMessageBox("修改成功!");
        PageDataSource = null;
        BindData();
    }
}
