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

public partial class Member_gamehist : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();


        Dictionary<string, object> dicParams = new Dictionary<string, object>();
        dicParams.Add("@lottery", Constants.GAMETYPE_RACE);
        dicParams.Add("@rowcount", 1);
        dicParams.Add("@result", 1);

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST, dicParams);

        ltlPk10Round.Text = DataSetUtil.RowIntValue(PageDataSource, "round", 0).ToString();
        ltlPk10Time.Text = string.Format("{0:YYYYY-MM-DD HH:mm:ss}", DataSetUtil.RowDateTimeValue(PageDataSource, "sdate", 0));
        ltlPk10Result.Text = string.Format("<li><span>{0:D2}</span></li><li><span>{1:D2}</span></li><li><span>{2:D2}</span></li><li><span>{3:D2}</span></li><li><span>{4:D2}</span></li><li><span>{5:D2}</span></li><li><span>{6:D2}</span></li><li><span>{7:D2}</span></li><li><span>{8:D2}</span></li><li><span>{9:D2}</span></li>",
            DataSetUtil.RowIntValue(PageDataSource, "rank1", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank2", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank3", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank4", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank5", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank6", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank7", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank8", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank9", 0),
            DataSetUtil.RowIntValue(PageDataSource, "rank10", 0));

        dicParams["@lottery"] = Constants.GAMETYPE_LADDER;
        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETGAMEHIST, dicParams);
        
        ltlLadderRound.Text = DataSetUtil.RowIntValue(PageDataSource, "round", 0).ToString();
        ltlLadderTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", Convert.ToDateTime(DataSetUtil.RowDateTimeValue(PageDataSource, "sdate", 0)).AddMinutes(5));
        ltlLadderResult.Text = string.Format("<li><span class='{3}'>{0}</span></li><li><span class='{4}'>{1}</span></li><li><span class='{5}'>{2}</span></li>",
            DataSetUtil.RowIntValue(PageDataSource, "startpos", 0) == 1 ? "左" : "右",
            DataSetUtil.RowIntValue(PageDataSource, "laddercount", 0) == 1 ? "3" : "4",
            DataSetUtil.RowIntValue(PageDataSource, "oddeven", 0) == 1 ? "单" : "双",
            DataSetUtil.RowIntValue(PageDataSource, "startpos", 0) == 1 ? "blue" : "",
            DataSetUtil.RowIntValue(PageDataSource, "laddercount", 0) == 1 ? "blue" : "",
            DataSetUtil.RowIntValue(PageDataSource, "oddeven", 0) == 1 ? "blue" : "");

    }
}
