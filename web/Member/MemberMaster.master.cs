using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using DataAccess;
using Ronaldo.common;

public partial class Member_MemberMaster : Ronaldo.uibase.MasterPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        DataSet dsUser = CurrentPage.DBConn.RunStoreProcedure("sp_getUser", new string[] { "@id" }, new object[] { CurrentPage.AuthUser.ID });
        ltlLoginID.Text = CurrentPage.AuthUser.LoginID;
        ltlAvatar.Text = string.Format("<img name=\"user-avatar\" src=\"{0}\" alt=\"\" />", DataSetUtil.RowStringValue(dsUser, "avatar", 0));
        ltlUserCash.Text = string.Format("<em id=\"userGamePointId\" title=\"双击刷新游戏分数\" data=\"{0:F2}\">{1:F2}</em>", CurrentPage.UserCash, CurrentPage.UserCash);

        DataTable dtLotterys = new DataTable();
        dtLotterys.Columns.Add("lotteryID", Type.GetType("System.Int32"));
        dtLotterys.Columns.Add("nick", Type.GetType("System.String"));
        dtLotterys.Columns.Add("title", Type.GetType("System.String"));
        dtLotterys.Columns.Add("desc", Type.GetType("System.String"));

        List<int> LotteryKeys = CurrentPage.Lotterys.Keys.ToList();

        foreach (int key in LotteryKeys)
            dtLotterys.Rows.Add(new object[] { CurrentPage.Lotterys[key].ID, CurrentPage.Lotterys[key].Nick, CurrentPage.Lotterys[key].Name, CurrentPage.Lotterys[key].Description });

        DataSet dsLotterys = new DataSet();
        dsLotterys.Tables.Add(dtLotterys);

        rptLotterySelector.DataSource = dsLotterys;
        rptLotterySelector.DataBind();
    }
}
