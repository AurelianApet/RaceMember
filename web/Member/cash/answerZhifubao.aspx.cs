using System;
using System.Collections;
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

using Ronaldo.common;
using DataAccess;


public partial class Member_cash_answerZhifubao : Ronaldo.uibase.PageBase
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
        writeLog("answer_zhifubao 결제 응답 접수! Page Initing...");
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        writeLog("answer_zhifubao 결제 응답 접수! Page Loading...");

        string strBody = Request.Params["body"];
        string strIsSuccess = Request.Params["is_success"];
        string strTradeStatus = Request.Params["trade_status"];
        long lChargeID = 0;
        if (!long.TryParse(strBody.Substring(13, strBody.Length - 13), out lChargeID))
            Response.Redirect("/Member/cash/charge.aspx");

        writeLog(string.Format("충환전 {0} 응답", lChargeID));
        if (lChargeID <= 0)
        {
            writeLog("충환전 아이디 오유");
            Response.Redirect("/Member/cash/charge.aspx");
            return;
        }

        if (strIsSuccess == "T" && strTradeStatus == "TRADE_SUCCESS")
            processApply(lChargeID);
        else
            processCancel(lChargeID);

        Response.Redirect("/Member/cash/charge.aspx");
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
