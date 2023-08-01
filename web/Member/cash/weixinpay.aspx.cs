using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
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

public partial class Member_cash_weixinpay : Ronaldo.uibase.PageBase
{
    private Dictionary<string, object> dicParams = null;
    DataSet dsConfig = null;
    Dictionary<string, string> dicConfigs = new Dictionary<string, string>();
    private Random m_rand = new Random();

    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected override void BindData()
    {
        base.BindData();

        string strScript = "<script>\n" +
                                "if (1) {\n";

        string strUrl = getResult();
        if (string.IsNullOrEmpty(strUrl))
            return;

        strScript += "var url = \"" + strUrl + "\";\n";
        strScript += "var qr = qrcode(10, 'M');\n" +
                        "qr.addData(url);\n" +
                        "qr.make();\n" +
                        "var wording = document.createElement('p');\n" +
                        "wording.innerHTML = \"扫我，扫我\";\n" +
                        "var code = document.createElement('DIV');\n" +
                        "code.innerHTML = qr.createImgTag();\n" +
                        "var element = document.getElementById(\"qrcode\");\n" +
                        "element.appendChild(wording);\n" +
                        "element.appendChild(code);\n" +
                        "}\n" +
                    "</script>\n";

        ltlScript.Text = strScript;

        string strHeadScript = "<script language=\"javascript\" type=\"text/javascript\">\n";
        strHeadScript += "var trade_no = " + Request.Params["out_trade_no"].ToString() + ";\n";
        strHeadScript += "</script>\n";
        ltlHeadScript.Text = strHeadScript;
    }

    protected string getValue(string strSource, string strTarget)
    {
        int nPos1 = strSource.IndexOf(strTarget);
        if (nPos1 < 0)
            return null;
        int nPos2 = strSource.IndexOf("/" + strTarget);
        if (nPos2 < 0 || nPos2 < nPos1)
            return null;

        return strSource.Substring(nPos1 + strTarget.Length + 1, nPos2 - nPos1 - strTarget.Length - 2);

    }

    protected string getResult()
    {
        dsConfig = DBConn.RunStoreProcedure(Constants.SP_GETCONFIG, new string[] { "@type" }, new object[] { Constants.GAMETYPE_NORMAL });
        
        for (int i = 0; i < DataSetUtil.RowCount(dsConfig); i++)
            dicConfigs.Add(DataSetUtil.RowStringValue(dsConfig, "conf_name", i), DataSetUtil.RowStringValue(dsConfig, "conf_value", i));

        string[] strTmpParams = dicConfigs["money_auto_wx"].Split(';');

        dicParams = new Dictionary<string, object>();
        dicParams.Add("appid", strTmpParams[1]);                //公众账号ID  DataSetUtil.RowStringValue(dsConfig, "cf_weixin_appid", 0)
        dicParams.Add("body", "payweixin");
        dicParams.Add("mch_id", strTmpParams[2]);               //商户号  DataSetUtil.RowStringValue(dsConfig, "cf_weixin_mchid", 0)
        dicParams.Add("nonce_str", createNoncestr());                                                      //随机字符串
        dicParams.Add("notify_url", "http://101.102.186.5:8080/Member/doWeixin.aspx");
        dicParams.Add("out_trade_no", Request.Params["out_trade_no"].ToString());
        dicParams.Add("spbill_create_ip", UserIP); //终端ip	    
        dicParams.Add("total_fee", Request.Params["total_fee"].ToString());
        dicParams.Add("trade_type", "NATIVE");

        string strResponse = postXmlSSL();

        string strReturnCode = getValue(strResponse, "return_code");

        if (strReturnCode.IndexOf("SUCCESS") < 0)
            return null;

        string strUrl = getValue(strResponse, "code_url");

        return strUrl.Substring(9, strUrl.Length - 12);
    }

    protected string postXmlSSL()
    {
        string strXml = createXml();
        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        Stream responseStream;
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        if (request == null)
        {
            throw new ApplicationException(string.Format("Invalid url string: {0}", url));
        }
        // request.UserAgent = sUserAgent;  
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        request.ContentLength = strXml.Length;
        Stream requestStream = request.GetRequestStream();

        requestStream.Write(Encoding.ASCII.GetBytes(strXml), 0, strXml.Length);
        requestStream.Close();
        try
        {
            responseStream = request.GetResponse().GetResponseStream();
        }
        catch (Exception exception)
        {
            throw exception;
        }
        string str = string.Empty;
        using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
        {
            str = reader.ReadToEnd();
        }
        responseStream.Close();
        return str;
    }

    protected string createXml()
    {
        try
        {
            //检测必填参数
            if (!dicParams.Keys.Contains("out_trade_no"))
                throw new Exception("缺少统一支付接口必填参数out_trade_no！");
            else if (!dicParams.Keys.Contains("body"))
                throw new Exception("缺少统一支付接口必填参数body！");
            else if (!dicParams.Keys.Contains("total_fee"))
                throw new Exception("缺少统一支付接口必填参数total_fee！");
            else if (!dicParams.Keys.Contains("notify_url"))
                throw new Exception("缺少统一支付接口必填参数notify_url！");
            else if (!dicParams.Keys.Contains("trade_type"))
                throw new Exception("缺少统一支付接口必填参数trade_type！");
            else if (dicParams["trade_type"].ToString() == "JSAPI" && !dicParams.Keys.Contains("openid"))
                throw new Exception("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");

            dicParams.Add("sign", getSign());                                                         //签名
            return arrayToXml();
        }
        catch (Exception ex)
        {
            ShowMessageBox(ex.Message);
            return null;
        }
    }

    private string formatBizQueryParaMap()
    {
        string buff = "";
        foreach (KeyValuePair<string, object> kvp in dicParams)
        {
            buff += kvp.Key + "=" + kvp.Value.ToString() + "&";
        }

        if (buff.Length > 0)
        {
            buff = buff.Substring(0, buff.Length - 1);
        }
        return buff;
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

    private string getSign()
    {
        //签名步骤一：按字典序排序参数
        string String = formatBizQueryParaMap();
        //echo '【string1】'.$String.'</br>';
        //签名步骤二：在string后加入KEY
        String += "&key=" + dicConfigs["money_auto_wx"].Split(';')[4];  //DataSetUtil.RowStringValue(dsConfig, "cf_weixin_shopkey", 0)
        //echo "【string2】".$String."</br>";
        //签名步骤三：MD5加密
        String = GetMD5(String);
        //echo "【string3】 ".$String."</br>";
        //签名步骤四：所有字符转为大写
        return String.ToLower();
    }

    protected string createNoncestr()
    {
        int nLen = 32;
        string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        string str = "";
        for (int i = 0; i < nLen; i++)
        {
            str += chars.Substring(m_rand.Next(chars.Length - 1), 1);
        }
        return str;
    }

    protected string arrayToXml()
    {
        string strxml = "<xml>";
        foreach (KeyValuePair<string, object> kvp in dicParams)
        {
            if (!Regex.IsMatch(kvp.Value.ToString(), @"^[0-9.]{1,40}$"))
                strxml += "<" + kvp.Key + "><![CDATA[" + kvp.Value.ToString() + "]]></" + kvp.Key + ">";
            else
                strxml += "<" + kvp.Key + ">" + kvp.Value.ToString() + "</" + kvp.Key + ">";
        }


        strxml += "</xml>";
        return strxml;
    }
    public string getUTF8String(object objSrc)
    {
        if (objSrc == null)
            return "";

        if (string.IsNullOrEmpty(objSrc.ToString()))
            return "";

        return new string(Encoding.UTF8.GetChars(Encoding.UTF8.GetBytes(objSrc.ToString())));
    }
}
