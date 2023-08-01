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
using System.Text;
using System.Text.RegularExpressions;

using DataAccess;
using Ronaldo.common;

public partial class Member_cash_getChargeTradeInfo : Ronaldo.uibase.AjaxPageBase
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        string strFormat1 = "{{\"Status\":{0}, " +
                            "\"Tip\":\"{1}\"}}";

        int nStatus = 0;
        string strTip = "";
        try
        {
            string strTradeNo = Request.Params["trade_no"].ToString();
            if (string.IsNullOrEmpty(strTradeNo) || strTradeNo.Length <= 12)
                throw new Exception("Trade No Invalid");

            strTradeNo = strTradeNo.Substring(13, strTradeNo.Length - 13);
            long lChargeID = 0;
            if (!long.TryParse(strTradeNo, out lChargeID))
                throw new Exception("Trade No Invalide");

            DataSet dsCharge = DBConn.RunStoreProcedure(Constants.SP_GETMONEYINOUTS, new string[] { "@id", "@kind" }, new object[] { lChargeID, Constants.MONEYINOUT_CHARGE });
            if (DataSetUtil.IsNullOrEmpty(dsCharge))
                throw new Exception("No Trade");

            nStatus = DataSetUtil.RowIntValue(dsCharge, "status", 0);
            if (nStatus == Constants.MONEYINOUT_APPLY)
            {
                double fMoney = DataSetUtil.RowDoubleValue(dsCharge, "reqmoney", 0);
                strTip = string.Format("您已成功充值 {0:F2}元", fMoney);
            }
            else if (nStatus == Constants.MONEYINOUT_CANCEL)
                strTip = "充值失败";

        }
        catch (Exception ex)
        {
            Response.Write(string.Format(strFormat1, -1, ex.Message));
            Response.End();
        }

        Response.Write(string.Format(strFormat1, nStatus, strTip));
        Response.End();

    }
}
