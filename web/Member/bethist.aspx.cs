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

public partial class Member_bethist : Ronaldo.uibase.PageBase
{
    protected override GridView getGridControl()
    {
        return gvBetContent;
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void InitControls()
    {
        base.InitControls();

        StartDate = DateTime.Now.AddDays(-2);
        EndDate = DateTime.Now;

        tbxStartDate.Text = string.Format("{0:yyyy-MM-dd}", StartDate);
        tbxEndDate.Text = string.Format("{0:yyyy-MM-dd}", EndDate);
        selLottery.SelectedIndex = 0;
    }

    protected override void LoadData()
    {
        base.LoadData();

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETBETTINGHIST, new string[] { "@lottery", "@userid", "@sdate", "@edate" }, new object[] { selLottery.Value, AuthUser.ID, StartDate, EndDate });
    }

    protected override void gvContent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        base.gvContent_RowDataBound(sender, e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double fBetMoney = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "betmoney"));
            double fWinMoney = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "winmoney"));

            setLiteralValue(e.Row, "ltlBenefit", string.Format("{0:F2}({1})", fWinMoney - fBetMoney, fBetMoney < fWinMoney ? "盈" : "亏"));

            setLiteralValue(e.Row, "ltlLotteryName", Lotterys[Convert.ToInt32(selLottery.Value)].Name);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StartDate = Convert.ToDateTime(tbxStartDate.Text + " 00:00:00");
        EndDate = Convert.ToDateTime(tbxEndDate.Text + " 23:59:59");

        PageDataSource = null;
        BindData();
    }
}
