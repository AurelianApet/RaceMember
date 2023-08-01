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

public partial class Member_default : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        DataTable dtLotterys = new DataTable();
        dtLotterys.Columns.Add("lotteryID", Type.GetType("System.Int32"));
        dtLotterys.Columns.Add("num", Type.GetType("System.Int32"));
        dtLotterys.Columns.Add("nick", Type.GetType("System.String"));
        dtLotterys.Columns.Add("title", Type.GetType("System.String"));

        List<int> LotteryKeys = Lotterys.Keys.ToList();
        
        int nNum = 0;
        foreach (int key in LotteryKeys)
            dtLotterys.Rows.Add(new object[] { Lotterys[key].ID, nNum++, Lotterys[key].Nick, Lotterys[key].Name });

        DataSet dsLotterys = new DataSet();
        dsLotterys.Tables.Add(dtLotterys);

        rptChecker.DataSource = dsLotterys;
        rptChecker.DataBind();

        DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { AuthUser.ID });

        string[] strMainLotteryIDs = DataSetUtil.RowStringValue(dsUser, "main_lottery", 0).Split('-');

        int nTmpID = Convert.ToInt32(strMainLotteryIDs[0]);
        string strMainLottery = "";
        if(Lotterys.Keys.Contains(nTmpID))
            strMainLottery = "<li code=\"" + Lotterys[nTmpID].ID.ToString() + "\" data-title=\"" + Lotterys[nTmpID].Name + "\" data-name=\"" + Lotterys[nTmpID].Nick +"\">\n" +
                                    "<!--image start-->\n" +
                                    "<div class=\"image\" id=\"ticket-icon\">\n" +
                                        "<span class=\"ticket-icon t-s-96 ti-" + Lotterys[nTmpID].Nick + "\">" + Lotterys[nTmpID].Name + "</span>\n" +
                                    "</div>\n" +
                                    "<!--image end-->\n" +
                                    "<!--title start-->\n" +
                                    "<div class=\"title\">\n" +
                                        "<h4><a href=\"javascript:goLink('bet', '" + Lotterys[nTmpID].Nick + "');\">" + Lotterys[nTmpID].Name + "</a></h4>\n" +
                                    "</div>\n" +
                                    "<!--title end-->\n" +
                                    "<!--cutdown start-->\n" +
                                    "<div class=\"cutdown\">\n" + 
                                        "<h4><span id=\"hallIssueId\"></span>开奖时间：</h4>\n" + 
                                        "<div class=\"cutdown-lite\" id=\"hallIssueTimeId\">\n" + 
                                            "<ul>\n" + 
                                                "<li><span></span></li>\n" + 
                                                "<li><span></span></li>\n" + 
                                                "<li><span></span></li>\n" + 
                                                "<li><span></span></li>\n" + 
                                                "<li><span></span></li>\n" + 
                                            "</ul>\n" + 
                                        "</div>\n" + 
                                    "</div>\n" + 
                                    "<!--cutdown end-->\n" + 
                                    "<!--betting-btn start-->\n" +
                                    "<div class=\"betting-btn\"> <a href=\"javascript:goLink('bet', '" + Lotterys[nTmpID].Nick + "');\">立即投注</a> </div>\n" + 
                                    "<!--betting-btn end-->\n" + 
                                "</li>";

        ltlMainLottery.Text = strMainLottery;

        DataTable dtBaseLotterys = new DataTable();
        dtBaseLotterys.Columns.Add("lotteryID", Type.GetType("System.Int32"));
        dtBaseLotterys.Columns.Add("nick", Type.GetType("System.String"));
        dtBaseLotterys.Columns.Add("title", Type.GetType("System.String"));

        for (int i = 1; i < strMainLotteryIDs.Length; i++)
        {
            nTmpID = Convert.ToInt32(strMainLotteryIDs[i]);
            if (Lotterys.Keys.Contains(nTmpID))
                dtBaseLotterys.Rows.Add(new object[] { Lotterys[nTmpID].ID, Lotterys[nTmpID].Nick, Lotterys[nTmpID].Name });
        }

        DataSet dsBaseLotterys = new DataSet();
        dsBaseLotterys.Tables.Add(dtBaseLotterys);

        rptBaseLottery.DataSource = dsBaseLotterys;
        rptBaseLottery.DataBind();

        DataSet dsNotice = DBConn.RunStoreProcedure(Constants.SP_GETNOTICELIST, new string[] { "@kind" }, new object[] { Constants.NOTICEKIND_NOTICE });

        rptNotice.DataSource = dsNotice;
        rptNotice.DataBind();

    }
}
