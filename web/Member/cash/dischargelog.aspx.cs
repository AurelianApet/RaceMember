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

public partial class Member_dischargelog : Ronaldo.uibase.PageBase
{
    protected override GridView getGridControl()
    {
        return gvRecentHist;
    }


    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void LoadData()
    {
        base.LoadData();

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETMONEYINOUTS,
            new string[] {
                "@kind",
                "@user_id",
                "@sdate",
                "@edate",
                "@deldate"
            },
            new object[] {
                Constants.MONEYINOUT_DISCHARGE,
                AuthUser.ID,
                StartDate,
                EndDate,
                DateTime.Now
            });
    }

    protected override void InitControls()
    {
        base.InitControls();

        StartDate = DateTime.Now.AddDays(-3);
        EndDate = DateTime.Now;

        tbxStartDate.Text = string.Format("{0:yyyy-MM-dd}", StartDate);
        tbxEndDate.Text = string.Format("{0:yyyy-MM-dd}", EndDate);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StartDate = Convert.ToDateTime(tbxStartDate.Text + " 00:00:00");
        EndDate = Convert.ToDateTime(tbxEndDate.Text + " 23:59:59");

        PageDataSource = null;
        BindData();
    }
}
