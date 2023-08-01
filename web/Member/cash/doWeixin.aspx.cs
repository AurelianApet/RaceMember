using System;
using System.Collections;
using System.Configuration;
using System.IO;
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
using System.Net;

using DataAccess;
using Ronaldo.common;

public partial class Member_cash_doWeixin : Ronaldo.uibase.PageBase
{
    protected override void Page_PreInit(object sender, EventArgs e)
    {
        // 디비 초기 연결 작업 시작...
        _dbconn = new MSSqlAccess();
        _dbconn.DBServer = Constants.DB_CONN_HOST;
        _dbconn.DBPort = Constants.DB_CONN_PORT;
        _dbconn.DBName = Constants.DB_CONN_NAME;
        _dbconn.DBID = Constants.DB_CONN_USER;
        _dbconn.DBPwd = Constants.DB_CONN_PASS;
        _dbconn.Connect();

        // 디비 연결 끝

        // 페이지 설정 시작
        strCurDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _userip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(_userip))
            _userip = Request.ServerVariables["REMOTE_ADDR"];
        Session.Timeout = Defines.SESSION_TIMEOUT;

        try
        {
            readSiteConfig();

            // 로그인한 유저의 개인정보 갱신
            if (AuthUser != null)
            {
                System.Data.DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER,
                    new string[] { "@id" }, new object[] { AuthUser.ID });

                if (DataSetUtil.IsNullOrEmpty(dsUser))
                {
                    Alert(Resources.Err.ERR_REQUIRED_AUTH, Defines.URL_LOGOUT);
                    return;
                }

                AuthUser.NickName = DataSetUtil.RowStringValue(dsUser, "nick", 0);
            }

            // 방문 URL 저장
            if (AuthUser != null)
            {
                DBConn.RunStoreProcedure(Constants.SP_UPDATELOGIN,
                    new string[] {
                            "@user_id",
                            "@url",
                            "@logout"
                        },
                        new object[] {
                            AuthUser.ID,
                            Request.Url.ToString(),
                            0
                        });
            }
        }
        catch
        {
            _isInited = false;
            return;
        }

        _isInited = true;
        // 페이지 설정 끝
    }

    protected override void Page_Init(object sender, EventArgs e)
    {
        writeLog("doWeixin 결제 응답 접수! Page Initing... ");
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        writeLog("doWeixin 결제 응답 접수! Page Loading...");

        Stream responseStream;
        responseStream = Request.InputStream;
        StreamReader stReader = new StreamReader(responseStream, Encoding.UTF8);
        string strResponse = stReader.ReadToEnd();

        string strTradeNo = getValue(strResponse, "out_trade_no");
        string strResultCode = getValue(strResponse, "result_code");
        string strReturnCode = getValue(strResponse, "return_code");

        if (string.IsNullOrEmpty(strTradeNo) || string.IsNullOrEmpty(strResultCode) || string.IsNullOrEmpty(strReturnCode))
            return;
        strTradeNo = strTradeNo.Substring(9, strTradeNo.Length - 12);

        writeLog(string.Format("weixin 응답 {0} -> {1}, {2}", strTradeNo, strResultCode, strReturnCode));

        long lChargeID = 0;
        if (!long.TryParse(strTradeNo.Substring(13, strTradeNo.Length - 13), out lChargeID))
            Response.Redirect("/Member/cash/charge.aspx");

        if (strResultCode.IndexOf("SUCCESS") >= 0 && strReturnCode.IndexOf("SUCCESS") >= 0)
            processApply(lChargeID);
        else
            ShowMessageBox("充值失败");

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

    protected bool processApply(long lID)
    {
        DataSet dsInfo = DBConn.RunStoreProcedure(Constants.SP_GETMONEYINOUTS,
            new string[] { "@id", "@kind" }, new object[] { lID, Constants.MONEYINOUT_CHARGE });

        if (DataSetUtil.IsNullOrEmpty(dsInfo))
            return false;

        int iStatus = DataSetUtil.RowIntValue(dsInfo, "status", 0);
        if (iStatus != Constants.MONEYINOUT_REQUEST)
            return false;

        long iUserID = DataSetUtil.RowLongValue(dsInfo, "user_id", 0);
        string strLoginID = DataSetUtil.RowStringValue(dsInfo, "loginid", 0);
        double fReqMoney = DataSetUtil.RowDoubleValue(dsInfo, "reqmoney", 0);
        string strGid = DataSetUtil.RowLongValue(dsInfo, "id", 0).ToString();

        DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER, new string[] { "@id" }, new object[] { iUserID });

        if (iUserID < 1 || fReqMoney < 0)
            return false;

        if (InsertCash(
                iUserID,
                fReqMoney,
                0,
                string.Format(Resources.Desc.DESC_CHARGE, fReqMoney)))
        {

            DBConn.RunStoreProcedure(Constants.SP_UPDATEMONEYINOUTS,
                new string[] {
                    "@id",
                    "@kind",
                    "@reqmoney",
                    "@status"
                },
                new object[] {
                    lID,
                    Constants.MONEYINOUT_CHARGE,
                    fReqMoney,
                    Constants.MONEYINOUT_APPLY
                });
        }
        else
            return false;

        return true;
    }

    protected bool processCancel(long lID)
    {
        DataSet dsInfo = DBConn.RunStoreProcedure(Constants.SP_GETMONEYINOUTS,
                    new string[] { "@id", "@kind" }, new object[] { lID, Constants.MONEYINOUT_CHARGE });
        if (DataSetUtil.IsNullOrEmpty(dsInfo))
            return false;

        int iStatus = DataSetUtil.RowIntValue(dsInfo, "status", 0);
        if (iStatus != Constants.MONEYINOUT_REQUEST)
            return false;

        long iUserID = DataSetUtil.RowLongValue(dsInfo, "user_id", 0);
        string strLoginID = DataSetUtil.RowStringValue(dsInfo, "loginid", 0);
        double fReqMoney = DataSetUtil.RowDoubleValue(dsInfo, "reqmoney", 0);
        string strGid = DataSetUtil.RowLongValue(dsInfo, "id", 0).ToString();

        if (iUserID < 1 || fReqMoney < 0)
            return false;

        if (iStatus == Constants.MONEYINOUT_REQUEST || iStatus == Constants.MONEYINOUT_STANDBY)
        {
            DBConn.RunStoreProcedure(Constants.SP_UPDATEMONEYINOUTS,
                new string[] {
                            "@id",
                            "@kind",
                            "@reqmoney",
                            "@status"
                        },
                new object[] {
                            lID,
                            Constants.MONEYINOUT_CHARGE,
                            fReqMoney,
                            Constants.MONEYINOUT_CANCEL
                        });
            return true;
        }
        else
            return false;
    }
}
