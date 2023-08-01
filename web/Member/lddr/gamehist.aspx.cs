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

public partial class Member_lddr_gamehist : Ronaldo.uibase.PageBase
{
    protected override GridView getGridControl()
    {
        return gvContent;
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();
    }

    protected override void LoadData()
    {
        base.LoadData();
        Dictionary<string, object> dicParams = new Dictionary<string, object>();
        string strDate = Request.Params["date"];
        DateTime dtSearchDate = new DateTime();
        dtSearchDate = string.IsNullOrEmpty(strDate) ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) : Convert.ToDateTime(strDate);

        dicParams.Add("@lottery", Constants.GAMETYPE_LADDER);
        dicParams.Add("@rowcount", 288);
        dicParams.Add("@result", 1);
        dicParams.Add("@sdate", dtSearchDate);
        dicParams.Add("@edate", dtSearchDate.AddDays(1).AddSeconds(-1));

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST, dicParams);

        TimeSpan tsDiff = DateTime.Now - dtSearchDate;
        if(tsDiff.TotalDays < 1)
            liToday.Attributes["class"] = "AwardDiff active";
        else if(tsDiff.TotalDays < 2)
            liYesterday.Attributes["class"] = "AwardDiff active";
        else if (tsDiff.TotalDays < 3)
            li2DaysAgo.Attributes["class"] = "AwardDiff active";

        dateSelect.Attributes["value"] = string.Format("{0:yyyy-MM-dd}", dtSearchDate);

    }

    protected override void InitControls()
    {
        base.InitControls();
        gvContent.PageSize = 288;
    }

    protected override void gvContent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        base.gvContent_RowDataBound(sender, e);
    }
}
