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


public partial class Member_zhuihaodetail : Ronaldo.uibase.PageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void LoadData()
    {
        base.LoadData();

        long lZhuihaoID = 0;
        if (!long.TryParse(Request.Params["type"], out lZhuihaoID))
            Response.Redirect("/Member/zhuihaolist.aspx");

        PageDataSource = DBConn.RunStoreProcedure(Constants.SP_GETZHUIHAOHIST, new string[] { "@id" }, new object[] { lZhuihaoID });
        if (DataSetUtil.IsNullOrEmpty(PageDataSource))
            Response.Redirect("/Member/zhuihaolist.aspx");

        if (DataSetUtil.RowLongValue(PageDataSource, "userid", 0) != AuthUser.ID)
            Response.Redirect("/Member/zhuihaolist.aspx");
    }

    protected override void BindData()
    {
        base.BindData();

        long lID = DataSetUtil.RowLongValue(PageDataSource, "id", 0);
        int nLottery = DataSetUtil.RowIntValue(PageDataSource, "lottery", 0);
        DateTime dtRegDate = Convert.ToDateTime(DataSetUtil.RowDateTimeValue(PageDataSource, "regdate", 0));
        double fBetMoney = DataSetUtil.RowDoubleValue(PageDataSource, "betmoney", 0);
        double fWinMoney = DataSetUtil.RowDoubleValue(PageDataSource, "winmoney", 0);
        int nTotalStep = DataSetUtil.RowIntValue(PageDataSource, "totalstep", 0);
        int nCurrentStep = DataSetUtil.RowIntValue(PageDataSource, "curstep", 0);
        int nStatus = DataSetUtil.RowIntValue(PageDataSource, "status", 0);
        string[] strBetInfoParams = DataSetUtil.RowStringValue(PageDataSource, "betinfo", 0).Split('-');
        string[] strZhuihaoInfoParams = DataSetUtil.RowStringValue(PageDataSource, "zhuihaoinfo", 0).Split(';');
        ltlID.Text = lID.ToString();
        ltlLottery.Text = Lotterys[nLottery].Name;
        ltlRegDate.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dtRegDate);
        ltlBetMoney.Text = string.Format("{0:F2}", fBetMoney);
        ltlWinMoney.Text = string.Format("{0:F2}", fWinMoney);
        ltlBenefitMoney.Text = string.Format("{0:F2}", fWinMoney - fBetMoney);
        ltlTotalStep.Text = nTotalStep.ToString();
        ltlCurrentStep.Text = nCurrentStep.ToString();
        ltlStatus.Text = nStatus == 1 ? "已完成" : "进行中";
        string strBetMode = getBetMode(Convert.ToInt32(strBetInfoParams[4]));
        string strBetVal = strBetInfoParams[5];
        ltlBetMode.Text = string.Format("<span class=\"fc-red\">[{0}]</span> <span class=\"trace-logs-number\" title=\"{1}\"><i>{2}</i></span> </li>", strBetMode, strBetVal, strBetVal);

        string strQuery = string.Format("select * from {0} where zhuihao_id = @id", nLottery == Constants.GAMETYPE_RACE ? "bettings_race" : "bettings_ladder");
        DataSet dsBet = DBConn.RunSelectQuery(strQuery, new string[] { "@id" }, new object[] { lID });
        string strBetDetail = "";
        string strBetFormat = "<tr data-id=\"\">\n" +
                                    "<td class=\"center\">\n" +
                                    "</td>" +
                                    "<td class=\"center\"><span class=\"fc-blue\">{0}</span></td>\n" +
                                    "<td class=\"center\"><span>{1} 倍</span></td>\n" +
                                    "<td class=\"center\"><span class=\"fc-green\">{2}</span></td>\n" +
                                "</tr>\n";
        for (int i = 0; i < strZhuihaoInfoParams.Length; i++)
        {
            string[] strParams = strZhuihaoInfoParams[i].Split('-');
            strBetDetail += string.Format(strBetFormat,
                                strParams[0],
                                strParams[1],
                                i >= nCurrentStep ? "进行中" : "已完成");

        }
        ltlBetDetail.Text = strBetDetail;
    }
}
