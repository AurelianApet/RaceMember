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

public partial class Member_uc_LeftUseInfoMenu : Ronaldo.uibase.UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet dsUser = CurrentPage.DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { CurrentPage.AuthUser.ID });
        ltlAvatar.Text = string.Format("<img name=\"user-avatar\" id=\"avatar-img-bar\" src=\"{0}\" alt=\"\">", DataSetUtil.RowStringValue(dsUser, "avatar", 0));
    }
}
