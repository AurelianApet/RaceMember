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

public partial class Member_pk10_gamehist : Ronaldo.uibase.PageBase
{
    protected override GridView getGridControl()
    {
        return gvContent;
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void LoadData()
    {
        base.LoadData();
        Dictionary<string, object> dicParams = new Dictionary<string, object>();
        dicParams.Add("@lottery", Constants.GAMETYPE_RACE);
        dicParams.Add("@rowcount", 169);
        dicParams.Add("@result", 1);

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST, dicParams);

    }

    protected override void InitControls()
    {
        base.InitControls();
        gvContent.PageSize = 169;
    }

    protected override void gvContent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        base.gvContent_RowDataBound(sender, e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strNumber = "";
            int[] nNum = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 10; i++)
            {
                nNum[i] = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "rank" + (i + 1).ToString()));
                strNumber += string.Format("<i class=\"pk-no{0}\" data-no=\"{1}\"></i>", nNum[i], nNum[i]);
            }
            setLiteralValue(e.Row, "ltlNumber", strNumber);
            int nSum = nNum[0] + nNum[1];
            string strOverUnder = "";
            string strOddEven = "";
            if (nSum < 12)
                strOverUnder = "<p>小</p>";
            else
                strOverUnder = "<p class=\"r\">大</p>";
            if (nSum % 2 == 1)
                strOddEven = "<p class=\"r\">单</p>";
            else
                strOddEven = "<p>双</p>";

            setLiteralValue(e.Row, "ltlSum", nSum.ToString());
            setLiteralValue(e.Row, "ltlOverUnder", strOverUnder);
            setLiteralValue(e.Row, "ltlOddEven", strOddEven);
        }
    }
    protected void gvContent_RowCreated(object sender, GridViewRowEventArgs e)
    {
        TableRow tr;                         //행
        TableCell tcSum;                     //사이트
        if (e.Row.RowType == DataControlRowType.Header)
        {
            tr = (TableRow)e.Row;

            tcSum = (TableCell)e.Row.Cells[2];
            tcSum.ColumnSpan = 3;
            e.Row.Cells.RemoveAt(3);
            e.Row.Cells.RemoveAt(3);
        }
    }
}
