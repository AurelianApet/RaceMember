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

public partial class ajax_main_postCharge : Ronaldo.uibase.AjaxPageBase
{
    private DataSet dsConfig = null;
    Dictionary<string, string> dicConfigs = new Dictionary<string, string>();

    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        Response.Clear();
        Response.ContentType = "text/html";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        string strFormat = "{{\"Ok\":{0}, " +
                            "\"OrderNo\":\"{1}\", " +
                            "\"RechargeAmount\":{2}, " +
                            "\"AccName\":\"{3}\", " +
                            "\"AccNo\":\"{4}\"}}";

        string strFormat1 = "{{\"Ok\":{0}, " +
                            "\"Tip\":\"{1}\"}}";

        string strFormat2 = "{{\"Ok\":{0}, " +
                            "\"url\":\"{1}\"}}";
        long lReqMoney = 0;
        int nType = 0;
        string strChargeInfo = "";
        int nManualMode = 0;

        string strResult = "";
        try
        {
            if (!long.TryParse(Request.Params["s"], out lReqMoney))
                throw new Exception("Req money Invalid");

            if (!int.TryParse(Request.Params["f"], out nType))
                throw new Exception("Req type Invalid");

            if (!int.TryParse(Request.Params["mode"], out nManualMode))
                throw new Exception("Req mode Invalid");

            if (nManualMode == 1)
            {
                strChargeInfo = Request.Params["w"].ToString();
                if (string.IsNullOrEmpty(strChargeInfo))
                    throw new Exception("请正确输入账号！");
            }

            DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER,
            new string[] { "@id" }, new object[] { AuthUser.ID });

            if (DataSetUtil.IsNullOrEmpty(dsUser))
                throw new Exception(Resources.Err.ERR_INVALID_ACCESS);

            dsConfig = DBConn.RunStoreProcedure(Constants.SP_GETCONFIG, new string[] { "@type" }, new object[] { Constants.GAMETYPE_NORMAL });

            for (int i = 0; i < DataSetUtil.RowCount(dsConfig); i++)
                dicConfigs.Add(DataSetUtil.RowStringValue(dsConfig, "conf_name", i), DataSetUtil.RowStringValue(dsConfig, "conf_value", i));

            int nUse = 0;
            string strBankName = "";
            string strBankNum = "";
            string[] strTmpParams = null;
            if (nManualMode == 1)
            {
                strTmpParams = (nType == 1000) ? dicConfigs["money_bank_gsyh"].Split(';') : (nType == 1001 ? dicConfigs["money_bank_zfb"].Split(';') : dicConfigs["money_bank_cft"].Split(';'));
                nUse = Convert.ToInt32(strTmpParams[0]);
                strBankName = strTmpParams[1];
                strBankNum = strTmpParams[2];
            }
            else
            {
                strTmpParams = nType == 1001 ? dicConfigs["money_auto_zfb"].Split(';') : dicConfigs["money_auto_wx"].Split(';');
                nUse = Convert.ToInt32(strTmpParams[0]);
            }

            if (nUse == 1)
            {
                long lChargeID = 0;
                if (nManualMode == 0)
                {
                    lChargeID = DataSetUtil.GetID(DBConn.RunStoreProcedure(Constants.SP_CREATEMONEYINOUT,
                        new string[] {
                        "@user_id",
                        "@loginid",
                        "@nick",
                        "@site",
                        "@mode",
                        "@type",
                        "@ownername",
                        "@ownernum",
                        "@reqmoney",
                        "@kind"
                    },
                        new object[] {
                        AuthUser.ID,
                        DataSetUtil.RowStringValue(dsUser, "loginid", 0),
                        DataSetUtil.RowStringValue(dsUser, "nick", 0),
                        DataSetUtil.RowLongValue(dsUser, "site", 0),
                        1,
                        nType,
                        strChargeInfo,
                        "",
                        lReqMoney,
                        Constants.MONEYINOUT_CHARGE
                    }));

                    string url = getPayUrl(nType, lReqMoney, lChargeID);
                    strResult = string.Format(strFormat2, 1, url);
                }
                else
                {
                    lChargeID = DataSetUtil.GetID(DBConn.RunStoreProcedure(Constants.SP_CREATEMONEYINOUT,
                        new string[] {
                        "@user_id",
                        "@loginid",
                        "@nick",
                        "@site",
                        "@type",
                        "@ownername",
                        "@ownernum",
                        "@reqmoney",
                        "@kind"
                    },
                        new object[] {
                        AuthUser.ID,
                        DataSetUtil.RowStringValue(dsUser, "loginid", 0),
                        DataSetUtil.RowStringValue(dsUser, "nick", 0),
                        DataSetUtil.RowLongValue(dsUser, "site", 0),
                        nType,
                        strChargeInfo,
                        "",
                        lReqMoney,
                        Constants.MONEYINOUT_CHARGE
                    }));

                    strResult = string.Format(strFormat, 1, lChargeID, lReqMoney, strBankName, strBankNum);
                }


            }
            else
                strResult = string.Format(strFormat1, 0, "平台尚未配置有效当前充值帐号，请使用其他充值方式!");
            //strResult = string.Format(strFormat, 13777.0143206, 559720, "2016-06-17 05:16:32", "2016-06-17 09:07:00", 559721, 300, 559719);
        }
        catch (Exception ex)
        {
            Response.Write(string.Format(strFormat1, 0, ex.Message));
            Response.End();
        }
        Response.Write(strResult);
        Response.End();
    }

    private static string GetMD5(string s)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(System.Text.Encoding.GetEncoding("utf-8").GetBytes(s));
        System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    private string getPayUrl(int nType, long lReqMoney, long lChargeID)
    {
        if (nType == 1021)
        {
            return string.Format("/Member/cash/weixinpay.aspx?out_trade_no={0}&total_fee={1}", "1029767282378" + lChargeID.ToString(), lReqMoney * 100);
        }
        else
        {

            Dictionary<string, object> dicParams = new Dictionary<string, object>();
            string[] strTmpParams = dicConfigs["money_auto_zfb"].Split(';');

            dicParams.Add("service", "create_direct_pay_by_user");
            dicParams.Add("receive_name", "hanpin");                                // $_SESSION['member_name'],//收货人姓名
            dicParams.Add("_input_charset", "UTF-8");
            dicParams.Add("body", "1029767282378" + lChargeID.ToString());                            //$this->order['pay_sn'],	//商品描述
            dicParams.Add("extend_param", "isv^sh32");
            dicParams.Add("extra_common_param", "pd_order");                        //$this->order['order_type'],
            dicParams.Add("logistics_payment", "BUYER_PAY");//,				        //物流费用付款方式：SELLER_PAY(卖家支付)、BUYER_PAY(买家支付)、BUYER_PAY_AFTER_RECEIVE(货到付款)
            dicParams.Add("logistics_type", "EXPRESS");    //,					    //物流配送方式：POST(平邮)、EMS(EMS)、EXPRESS(其他快递)
            dicParams.Add("notify_url", "http://101.102.186.5:8080/Member/cash/doZhifubao.aspx");    //
            dicParams.Add("out_trade_no", "1029767282378" + lChargeID.ToString());                    //$this->order['pay_sn'],		//外部交易编号
            dicParams.Add("partner", strTmpParams[3]);          // DataSetUtil.RowStringValue(dsConfig, "cf_zhifubao_partner", 0)
            dicParams.Add("payment_type", 1);  //							        //支付类型
            dicParams.Add("price", lReqMoney.ToString());                                       //$this->order['api_pay_amount'],//订单总价
            dicParams.Add("quantity", 1);                                           //商品数量
            dicParams.Add("receive_address", "N");	                                //收货人地址
            dicParams.Add("receive_mobile", "N");                                   //收货人手机

            dicParams.Add("receive_phone", "N");                                    //收货人电话
            dicParams.Add("receive_zip", "N");                                      //收货人邮编
            dicParams.Add("return_url", "http://101.102.186.5:8080/Member/cash/answerZhifubao.aspx");//
            dicParams.Add("seller_email", strTmpParams[1]);                                        //DataSetUtil.RowStringValue(dsConfig, "cf_zhifubao_info", 0)
            dicParams.Add("subject", "预存款充值_1029767282378" + lChargeID.ToString());      //$this->order['subject'],	//商品名称

            dicParams.Add("key", strTmpParams[2]);                                  //DataSetUtil.RowStringValue(dsConfig, "cf_zhifubao_key", 0)
            dicParams.Add("sign", makeSign(dicParams));
            dicParams.Add("sign_type", "MD5");


            return Create_Url(dicParams);
        }
    }

    private string makeSign(Dictionary<string, object> dicParams)
    {
        string mysign = "";
        Dictionary<string, object> dicNewParams = new Dictionary<string, object>(dicParams);
        dicNewParams.Remove("sign");
        dicNewParams.Remove("sign_type");
        dicNewParams.Remove("key");

        List<string> list = dicNewParams.Keys.ToList();
        list.Sort();
        string arg = "";
        foreach (string key in list)
        {
            arg += key + "=" + getUTF8String(dicNewParams[key]) + "&";
        }

        string prestr = arg.Substring(0, arg.Length - 1);//去掉最后一个&号
        prestr += dicParams["key"];
        mysign = GetMD5(prestr);

        return mysign;
    }


    public string getUTF8String(object objSrc)
    {
        if (objSrc == null)
            return "";

        if (string.IsNullOrEmpty(objSrc.ToString()))
            return "";

        return new string(Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(objSrc.ToString())));
    }

    public string Create_Url(Dictionary<string, object> dicParams)
    {
        string strUrl = "https://mapi.alipay.com/gateway.do?";
        Dictionary<string, object> dicNewParams = new Dictionary<string, object>(dicParams);
        dicNewParams.Remove("sign");
        dicNewParams.Remove("sign_type");
        dicNewParams.Remove("key");

        string arg = "";
        foreach (KeyValuePair<string, object> kvp in dicNewParams)
        {
            object objValue = kvp.Value;
            arg += kvp.Key + "=" + Server.UrlEncode(kvp.Value.ToString()) + "&";
        }

        strUrl += arg + "sign=" + dicParams["sign"] + "&sign_type=" + dicParams["sign_type"];
        return strUrl;
    }
}
