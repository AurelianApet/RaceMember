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

public partial class Member_chargelog : Ronaldo.uibase.PageBase
{
    int nDayType = 0;
    protected override GridView getGridControl()
    {
        return gvRecentHist;
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (int.TryParse(Request.Params["type"], out nDayType))
            {
                if (nDayType != 2 && nDayType != 17)
                    nDayType = 0;
            }
        }
        base.Page_Load(sender, e);

    }

    protected override void LoadData()
    {
        base.LoadData();

        DateTime dtTime = DateTime.Now;
        dtTime = dtTime.AddDays(-1 - nDayType);

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETMONEYINOUTS,
            new string[] {
                "@kind",
                "@user_id",
                "@sdate",
                "@deldate"
            },
            new object[] {
                Constants.MONEYINOUT_CHARGE,
                AuthUser.ID,
                dtTime.ToString("yyyy-MM-dd HH:mm:ss"),
                DateTime.Now
            });
    }

    protected override void BindData()
    {
        base.BindData();

        string strRet = "<script language=\"javascript\" type=\"text/javascript\">\n";
        strRet += "$(document).ready(function() {\n";
        strRet += string.Format("init_memberRechargeLog(\"0\", \"{0}\", 'memberrechargelog');\n", (0 - nDayType));
        strRet += "});\n";
        strRet += "</script>";

        ltlScript.Text = strRet;
    }
}
