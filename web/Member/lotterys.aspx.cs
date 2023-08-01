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

public partial class Member_lotterys : Ronaldo.uibase.PageBase
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
        dtLotterys.Columns.Add("nick", Type.GetType("System.String"));
        dtLotterys.Columns.Add("title", Type.GetType("System.String"));
        dtLotterys.Columns.Add("desc", Type.GetType("System.String"));

        List<int> LotteryKeys = Lotterys.Keys.ToList();

        foreach (int key in LotteryKeys)
            dtLotterys.Rows.Add(new object[] { Lotterys[key].ID, Lotterys[key].Nick, Lotterys[key].Name, Lotterys[key].Description });

        DataSet dsLotterys = new DataSet();
        dsLotterys.Tables.Add(dtLotterys);

        rptLotteryList.DataSource = dsLotterys;
        rptLotteryList.DataBind();


        DataTable dtLotteryTopic = new DataTable();
        dtLotteryTopic.Columns.Add("lotteryID", Type.GetType("System.Int32"));
        dtLotteryTopic.Columns.Add("nick", Type.GetType("System.String"));
        dtLotteryTopic.Columns.Add("title", Type.GetType("System.String"));
        dtLotteryTopic.Columns.Add("desc", Type.GetType("System.String"));

        for (int i = 0; i < dtLotterys.Rows.Count; i++)
        {
            DataRow drRows = dtLotterys.Rows[i];
            string strLotteryID = drRows["lotteryID"].ToString();
            if (Lottery_Topic.IndexOf(strLotteryID + "-") >= 0 || Lottery_Topic.IndexOf("-" + strLotteryID) >= 0)
                dtLotteryTopic.Rows.Add(new object[] { strLotteryID, drRows["nick"].ToString(), drRows["title"].ToString(), drRows["desc"].ToString() });
        }

        DataSet dsLotteryTopic = new DataSet();
        dsLotteryTopic.Tables.Add(dtLotteryTopic);

        rptLotteryTopic.DataSource = dsLotteryTopic;
        rptLotteryTopic.DataBind();
    }
}
