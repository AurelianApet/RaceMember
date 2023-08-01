using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

using Ronaldo.common;
using Ronaldo.model;
using DataAccess;

namespace Ronaldo.uibase
{
    /// <summary>
    /// Summary description for PageBase
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        #region 속성 및 상수정의부
        
        // 경기시간으로부터 몇초전에 배팅마감
        public int TIME_GAMEEND
        {
            get { return 0; }
        }

        //디비
        protected MSSqlAccess _dbconn = null;
        public MSSqlAccess DBConn
        {
            get
            {
                return _dbconn;
            }
        }
        //Lottery Topic
        private string _Lottery_topic = null;
        public string Lottery_Topic
        {
            get { return _Lottery_topic; }
        }
        //Lotterys
        private Dictionary<int, Lottery> _Lotterys = null;
        public Dictionary<int, Lottery> Lotterys
        {
            get { return _Lotterys; }
        }
        
        //환경설정
        private Config _config = null;
        public Config SiteConfig
        {
            get { return _config; }
        }

        protected bool _isInited = false;
        public bool IsInited
        {
            get { return _isInited; }
        }

        protected string strCurDate = null;
        public string CurrentDate
        {
            get { return strCurDate; }
        }

        protected string _userip = "";
        public string UserIP
        {
            get { return _userip; }
        }

        // 유저의 보유머니
        private double _usercash = 0;
        public double UserCash
        {
            get
            {
                readUserMoney();
                return _usercash;
            }
        }

        //인증된 유저
        public AuthUser AuthUser
        {
            get
            {
                try
                {
                    // 세션에 유저정보가 등록되어있는 경우
                    if (Session[Constants.SESSION_KEY_USERINFO] != null &&
                        Session[Constants.SESSION_KEY_USERINFO] as AuthUser != null)
                    {
                        return Session[Constants.SESSION_KEY_USERINFO] as AuthUser;
                    }
                    else
                    {
                        // 세션에 없다면 쿠키 검사
                        // 쿠키에는 아이디;로그인아이디;암호화된패스워드;닉네임;레벨;추천인아이디;로그인시간 형태로 보관됨
                        if (getCookie(Constants.COOKIE_KEY_USERINFO) != null)
                        {
                            string strCookie = getCookie(Constants.COOKIE_KEY_USERINFO);

                            strCookie = CryptSHA256.Decrypt(strCookie);
                            string[] arrTemp = strCookie.Split(';');

                            // 보관된 자료개수가 정확한 경우
                            if (arrTemp.Length == 7)
                            {
                                // 로그인한 시간을 검사
                                // 만일 하루이전에 로그인한것이면 다시 로그인정보를 세션에 기록함
                                DateTime dtLoginDate = DateTime.Parse(arrTemp[6]);
                                if ((DateTime.Now - dtLoginDate).Hours < 24)
                                {
                                    System.Data.DataSet dsUser = DBConn.RunStoreProcedure(
                                            Constants.SP_GETUSER,
                                                new string[] {
                                                "@loginid"
                                            },
                                            new object[] {
                                                arrTemp[1]
                                            });

                                    if (DataSetUtil.IsNullOrEmpty(dsUser))
                                        return null;

                                    // 쿠키에 저장된 암호와 디비의 암호가 맞지 않는 경우 & 쿠기에 저장된 싸이트와 디비의 싸이트가 다른 경우
                                    //if (DataSetUtil.RowStringValue(dsUser, "loginpwd", 0) != arrTemp[2] || DataSetUtil.RowStringValue(dsUser, "site", 0) != arrTemp[6])
                                    if (DataSetUtil.RowStringValue(dsUser, "loginpwd", 0) != arrTemp[2])
                                        return null;

                                    AuthUser _authUser = new AuthUser(
                                        DataSetUtil.RowLongValue(dsUser, "id", 0),
                                        DataSetUtil.RowStringValue(dsUser, "loginid", 0),
                                        DataSetUtil.RowStringValue(dsUser, "loginpwd", 0),
                                        DataSetUtil.RowStringValue(dsUser, "nick", 0),
                                        DataSetUtil.RowStringValue(dsUser, "hp", 0),
                                        DataSetUtil.RowIntValue(dsUser, "site", 0));

                                    Session[Constants.SESSION_KEY_USERINFO] = _authUser;
                                    return _authUser;
                                }
                            }
                        }
                    }
                }
                catch { }

                return null;
            }
        }

        public int PageNumber
        {
            get
            {
                if (ViewState[Constants.VS_PAGENUMBER] != null)
                    return Convert.ToInt32(ViewState[Constants.VS_PAGENUMBER]);
                else
                    return 0;
            }
            set
            {
                ViewState[Constants.VS_PAGENUMBER] = value;
            }
        }

        private DataSet _dsPageData = null;
        public System.Data.DataSet PageDataSource
        {
            get
            {
                return _dsPageData;
            }
            set
            {
                _dsPageData = value;
            }
        }

        public string SortColumn
        {
            get
            {
                return ViewState[Constants.VS_SORTCOLUMN] as string;
            }
            set
            {
                ViewState[Constants.VS_SORTCOLUMN] = value;
            }
        }
        public SortDirection SortDirection
        {
            get
            {
                return (SortDirection)ViewState[Constants.VS_SORTDIRECTION];
            }
            set
            {
                ViewState[Constants.VS_SORTDIRECTION] = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtRet = DateTime.Now;

                if (dtNow.Hour < 15)
                    dtRet = DateTime.Parse(dtNow.AddDays(-1).ToString("yyyy-MM-dd 15:00:00"));
                else
                    dtRet = DateTime.Parse(dtNow.ToString("yyyy-MM-dd 15:00:00"));

                if (ViewState[Constants.VS_STARTDATE] != null)
                {
                    try
                    {
                        dtRet = Convert.ToDateTime(ViewState[Constants.VS_STARTDATE]);
                    }
                    catch { }
                }
                else
                {
                    ViewState[Constants.VS_STARTDATE] = dtRet;
                }
                return dtRet;
            }
            set
            {
                ViewState[Constants.VS_STARTDATE] = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtRet = DateTime.Now;

                if (dtNow.Hour < 15)
                    dtRet = DateTime.Parse(dtNow.ToString("yyyy-MM-dd 14:59:00"));
                else
                    dtRet = DateTime.Parse(dtNow.AddDays(1).ToString("yyyy-MM-dd 14:59:00"));

                if (ViewState[Constants.VS_ENDDATE] != null)
                {
                    try
                    {
                        dtRet = Convert.ToDateTime(ViewState[Constants.VS_ENDDATE]);
                    }
                    catch { }
                }
                else
                {
                    ViewState[Constants.VS_ENDDATE] = dtRet;
                }
                return dtRet;
            }
            set
            {
                ViewState[Constants.VS_ENDDATE] = value;
            }
        }
        public DateTime SearchDate
        {
            get
            {
                DateTime dtRet = DateTime.Now;

                if (Session[Constants.VS_SEARCHDATE] != null)
                {
                    try
                    {
                        dtRet = Convert.ToDateTime(Session[Constants.VS_SEARCHDATE]);
                    }
                    catch { }
                }
                else
                {
                    Session[Constants.VS_SEARCHDATE] = dtRet;
                }
                return dtRet;
            }
            set
            {
                Session[Constants.VS_SEARCHDATE] = value;
            }
        }
        #endregion

        public PageBase()
        {   
        }

        #region 유저관리부분
        protected bool UserLogin(string strLoginID, string strLoginPwd)
        {
            try
            {
                string strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
                string strUserIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(strUserIP))
                    strUserIP = Request.ServerVariables["REMOTE_ADDR"];
                string strUrl = Request.Url.AbsolutePath;
                string strSite = Request.Url.Host;
                strSite.Replace("www.", "");

                DataSet dsSite = DBConn.RunStoreProcedure(
                    Constants.SP_GETSITE,
                    new string[]{
                        "@siteurl"
                    },
                    new object[]{
                        strSite
                    });

                if (!DataSetUtil.IsNullOrEmpty(dsSite))
                    strSite = DataSetUtil.RowStringValue(dsSite, "site_name", 0);


                System.Data.DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER,
                    new string[] {
                        "@loginid"
                    },
                    new object[] {
                        strLoginID
                    });

                if (DataSetUtil.IsNullOrEmpty(dsUser))
                    return false;
                
                string sLoginPwd = DataSetUtil.RowValue(dsUser, "loginpwd", 0).ToString();
                int nLoginSite = DataSetUtil.RowIntValue(dsUser, "site", 0);

                //if (strLoginPwd != CryptSHA256.Decrypt(sLoginPwd) || strSite != sLoginSite)
                if(strLoginPwd != CryptSHA256.Decrypt(sLoginPwd))
                {
                    DBConn.RunStoreProcedure(Constants.SP_CREATELOGIN,
                        new string[] {
                            "@user_id",
                            "@user_ip",
                            "@site",
                            "@url",
                            "@agent",
                            "@success",
                            "@is_adminpage"
                        },
                        new object[] {
                            DataSetUtil.RowLongValue(dsUser, "id", 0),
                            strUserIP,
                            nLoginSite,
                            strUrl,
                            strUserAgent,
                            0,
                            0
                        });
                    return false;
                }

                long lID = long.Parse(DataSetUtil.RowValue(dsUser, "id", 0).ToString());
                string sLoginID = DataSetUtil.RowValue(dsUser, "loginid", 0).ToString();
                string sUserName = DataSetUtil.RowStringValue(dsUser, "nick", 0).ToString();
                string strHP = DataSetUtil.RowStringValue(dsUser, "hp", 0).ToString();

                AuthUser _authUser = new AuthUser(lID, sLoginID, sLoginPwd, sUserName, strHP, nLoginSite);
                Session[Constants.SESSION_KEY_USERINFO] = _authUser;

                if (Defines.COOKIE_INUSED)
                {
                    string strCookieData = string.Format("{0};{1};{2};{3};{4};{5};{6}",
                        _authUser.ID,
                        _authUser.LoginID,
                        _authUser.LoginPwd,
                        _authUser.NickName,
                        _authUser.HP,
                        _authUser.Site,
                        CurrentDate);

                    setCookie(Constants.COOKIE_KEY_USERINFO, CryptSHA256.Encrypt(strCookieData));
                }

                DBConn.RunStoreProcedure(Constants.SP_CREATELOGIN,
                    new string[] {
                        "@user_id",
                        "@user_ip",
                        "@site",
                        "@url",
                        "@agent",
                        "@success",
                        "@is_adminpage"
                    },
                    new object[] {
                        _authUser.ID,
                        strUserIP,
                        nLoginSite,
                        strUrl,
                        strUserAgent,
                        1,
                        0
                    });

                DBConn.RunStoreProcedure(Constants.SP_UPDATEUSERINFO,
                    new string[] {
                        "@id",
                        "@user_ip"
                    },
                    new object[] {
                        _authUser.ID,
                        strUserIP
                    });
            }
            catch
            {
                return false;
            }

            return true;
        }
        public void UserLogout()
        {
            if (DBConn != null && DBConn.IsConnected && AuthUser != null)
            {
                DBConn.RunStoreProcedure(Constants.SP_UPDATELOGIN,
                    new string[] {
                        "@user_id",
                        "@logout"
                    },
                    new object[] {
                        AuthUser.ID,
                        1
                    });
            }

            Session[Constants.SESSION_KEY_USERINFO] = null;
            Session.Remove(Constants.SESSION_KEY_USERINFO);

            if (Request.Cookies[Constants.COOKIE_KEY_SITE] != null)
            {
                HttpCookie hcCookie = Request.Cookies[Constants.COOKIE_KEY_SITE];
                hcCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(hcCookie);
            }
        }

        public void LockBetCancel()
        {
            // 배팅취소를 악용해서 배팅금액을 2번 환불받는것을 방지하기 위해 배팅취소중인지 확인
            Application.Lock();
            if (Application[AuthUser.LoginID] != null && Application[AuthUser.LoginID].ToString() == "BETCANCEL")
            {
                Alert(Resources.Err.ERR_INVALID_ACCESS, "default.aspx");
                Application.UnLock();
                return;
            }

            // 전역변수에 배팅취소상태 저장
            Application[AuthUser.LoginID] = "BETCANCEL";
            Application.UnLock();
        }
        public void UnlockUser()
        {
            Application.Lock();
            Application[AuthUser.LoginID] = null;
            Application.UnLock();
        }

        public bool InsertCash(long lUserID, double dCredit, double dDebit, string strDesc)
        {
            return InsertCash(lUserID, dCredit, dDebit, strDesc, "");
        }
        protected bool InsertCash(long lUserID, double dCredit, double dDebit, string strDesc, string strRel)
        {
            if (lUserID < 1)
                return false;

            if (dCredit <= 0.0f && dDebit <= 0.0f)
                return false;

            if (dCredit > 0.0f && dDebit > 0.0f)
                return false;

            string strLoginID = "";
            string strNick = "";
            int nSite = 0;

            DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER,
                new string[] { "@id" }, new object[] { lUserID });
            if (!DataSetUtil.IsNullOrEmpty(dsUser))
            {
                strLoginID = DataSetUtil.RowStringValue(dsUser, "loginid", 0);
                strNick = DataSetUtil.RowStringValue(dsUser, "nick", 0);
                nSite = DataSetUtil.RowIntValue(dsUser, "site", 0);
            }

            try
            {
                DBConn.RunStoreProcedure(Constants.SP_CREATEMONEYINFO,
                    new string[] {
                        "@user_id",
                        "@loginid",
                        "@nick",
                        "@site",
                        "@credit",
                        "@debit",
                        "@description",
                        "@rel"
                    },
                    new object[] {
                        lUserID,
                        strLoginID,
                        strNick,
                        nSite,
                        dCredit,
                        dDebit,
                        strDesc,
                        strRel
                    });
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 기타 유틸 함수
        public string MD5(string strSrc)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(strSrc, "MD5");
        }
        public void ShowMessageBox(string strMsg)
        {
            if (string.IsNullOrEmpty(strMsg))
                return;

            ClientScript.RegisterStartupScript(GetType(),
                "MessageBox",
                "alertTip('" + strMsg.Replace("'", "\'") + "');",
                true);
        }
        public void ShowMessageBox(string strMsg, string strUrl)
        {
            if (string.IsNullOrEmpty(strMsg))
                return;

            ClientScript.RegisterStartupScript(GetType(),
                "MessageBox",
                "alert('" + strMsg.Replace("'", "\'") + "');" +
                "location.href='" + strUrl + "';",
                true);
        }
        public void ShowConfirm(string strMsg, string strUrl)
        {
            if (string.IsNullOrEmpty(strMsg))
                return;

            ClientScript.RegisterStartupScript(GetType(),
                "ShowConfirm",
                "if(confirm('" + strMsg.Replace("'", "\'") + "') == true) {" +
                "location.href='" + strUrl + "';" +
                "}",
                true);
        }
        public void Alert(string strMsg, string strUrl)
        {
            if (strMsg == null)
                return;

            Response.Write("<script lanuage=\"javascript\" type=\"text/javascript\">\n" +
                            "alert('" + strMsg.Replace("'", "\'") + "');\n" +
                            "location.href='" + strUrl + "';\n" +
                            "</script>");
            Response.End();
        }
        public void AlertAndClose(string strMsg)
        {
            if (string.IsNullOrEmpty(strMsg))
                return;

            Response.Write("<script lanuage=\"javascript\" type=\"text/javascript\">\n" +
                            "alert('" + strMsg.Replace("'", "\'") + "');\n" +
                            "window.opener.location.href=window.opener.location.href;\n" +
                            "window.close();\n" +
                            "</script>");
            Response.End();
        }
        public void ShowError(string strMsg)
        {
            if (strMsg != null)
                Response.Write("<h4><font color=\"red\">" + strMsg + "</font></h4>");

            Response.End();
        }
        public bool checkAuth()
        {
            if (AuthUser == null)
            {
                Alert(Resources.Err.ERR_REQUIRED_AUTH, Defines.URL_LOGIN);
                return false;
            }

            return true;
        }
        public bool checkRequest()
        {
            string strKeyWord = "select|insert|delete|from|drop table|update|truncate|exec master|netlocalgroup administrators|:|net user|or|and";
            string strRegEx = "!|'|+";

            string strUrl = Request.Url.ToString();
            int nPos = strUrl.IndexOf("?");
            if (nPos < 0)
                return true;
            else
                strUrl = strUrl.Substring(nPos + 1, strUrl.Length - nPos - 1);

            string[] pattern = strKeyWord.Split('|');
            for (int i = 0; i < pattern.Length; i++)
            {
                if (strUrl.IndexOf(" " + pattern[i]) >= 0 || strUrl.IndexOf(pattern[i] + " ") >= 0)
                    return false;
            }

            pattern = strRegEx.Split('|');
            for (int i = 0; i < pattern.Length; i++)
            {
                if (strUrl.IndexOf(pattern[i]) >= 0)
                    return false;
            }
            return true;
        }
        public bool checkBlockOrLeave(out string strMsg)
        {
            strMsg = "";

            // 차단 또는 삭제되었는가 검사
            if (AuthUser != null)
            {
                System.Data.DataSet dsUser = DBConn.RunStoreProcedure(Constants.SP_GETUSER,
                    new string[] { "@id" }, new object[] { AuthUser.ID });

                if (DataSetUtil.IsNullOrEmpty(dsUser))
                {
                    strMsg = Resources.Err.ERR_LOGINID_INVALID;
                    return true;
                }
                string strLeaveDate = DataSetUtil.RowDateTimeValue(dsUser, "leavedate", 0);
                if (!string.IsNullOrEmpty(strLeaveDate))
                {
                    strMsg = string.Format(Resources.Err.ERR_USER_LEAVE, strLeaveDate);
                    return true;
                }
                string strBlockDate = DataSetUtil.RowDateTimeValue(dsUser, "interceptdate", 0);
                if (!string.IsNullOrEmpty(strBlockDate))
                {
                    strMsg = string.Format(Resources.Err.ERR_USER_INTERCEPT, strBlockDate);
                    return true;
                }
            }

            return false;
        }
        public string cutString(string strValue, int iLength)
        {
            return cutString(strValue, iLength, "...");
        }
        public string cutString(string strValue, int iLength, string strFooter)
        {
            if (string.IsNullOrEmpty(strValue))
                return "";

            if (iLength < 1 || strValue.Length <= iLength)
                return strValue;

            return strValue.Substring(0, iLength) + strFooter;
        }
        public string cutHTML(string strValue, int iLength)
        {
            return cutHTML(strValue, iLength, "...");
        }
        public string cutHTML(string strValue, int iLength, string strFooter)
        {
            if (string.IsNullOrEmpty(strValue))
                return "";

            string strRet = "";
            bool bIsTag = false;
            for (int i = 0; i < strValue.Length; i++)
            {
                string strChar = strValue.Substring(i, 1);
                if (strChar == "<") bIsTag = true;
                if (!bIsTag) strRet += strChar;
                if (strRet.Length >= iLength)
                {
                    strRet += strFooter;
                    break;
                }
                if (strChar == ">") bIsTag = false;
            }
            return strRet;
        }
        public int null2Zero(object objValue)
        {
            try
            {
                return int.Parse(objValue.ToString());
            }
            catch
            {
            }

            return 0;
        }
        public string text2Html(string strValue)
        {
            return strValue.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }
        public string html2Text(string strValue)
        {
            return strValue.Replace("<br />", "\r\n");
        }
        public string getCookie(string strKey)
        {
            HttpCookie hcCookie = Request.Cookies[Constants.COOKIE_KEY_SITE];
            if (hcCookie == null || hcCookie[strKey] == null)
                return null;

            return hcCookie[strKey];
        }
        public void setCookie(string strKey, string strValue)
        {
            HttpCookie hc = null;

            if (Request.Cookies[Constants.COOKIE_KEY_SITE] != null)
                hc = Request.Cookies[Constants.COOKIE_KEY_SITE];
            else
                hc = new HttpCookie(Constants.COOKIE_KEY_SITE);

            hc.Values.Set(strKey, strValue);

            hc.Expires = DateTime.Now.AddHours(Defines.COOKIE_TIMEOUT);

            Response.Cookies.Add(hc);
        }
        protected virtual void visibleEmptyRow(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpCtrl = sender as Repeater;
            if (rpCtrl == null)
                return;

            if (rpCtrl.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("rowEmpty");
                    if (tr != null)
                        tr.Visible = true;
                }
            }
        }
        public void setLiteralValue(GridViewRow gvRow, string strID, string strValue)
        {
            Literal ltlTarget = (Literal)gvRow.FindControl(strID);
            if (ltlTarget != null)
                ltlTarget.Text = strValue;
        }
        public void setItemValue(RepeaterItem rpItem, string strID, string strValue)
        {
            Literal ltlTarget = (Literal)rpItem.FindControl(strID);
            if (ltlTarget != null)
                ltlTarget.Text = strValue;
        }

        protected string getChkSum(long lGameID, long lGameDetailID, long lBetID, int iBetKind, int iBetType, int iTarget, string strIP, long lBetMoney, double fBetRatio)
        {
            return CryptSHA256.Encrypt(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                            lGameID,
                            lGameDetailID,
                            lBetID,
                            iBetKind,
                            iBetType,
                            iTarget,
                            strIP,
                            lBetMoney,
                            fBetRatio));
        }
        protected void readUserMoney()
        {
            if (AuthUser != null)
            {
                System.Data.DataSet dsTemp = DBConn.RunStoreProcedure(
                    Constants.SP_GETCURRENTMONEY,
                    new string[] {
                        "@user_id"
                    },
                    new object[] {
                        AuthUser.ID
                    });

                _usercash = DataSetUtil.RowDoubleValue(dsTemp, 0, 0);
            }
            else
            {
                _usercash = 0;
            }
        }
        public void readSiteConfig()
        {
            // 사이트 설정정보 조회
            System.Data.DataSet dsConfig = DBConn.RunStoreProcedure(Constants.SP_GETCONFIG, new string[] { "@type" }, new object[] { Constants.GAMETYPE_NORMAL });
            if (DataSetUtil.IsNullOrEmpty(dsConfig))
                throw new Exception();

            Dictionary<string, string> dicConfigs = new Dictionary<string, string>();
            for (int i = 0; i < DataSetUtil.RowCount(dsConfig); i++)
                dicConfigs.Add(DataSetUtil.RowStringValue(dsConfig, "conf_name", i), DataSetUtil.RowStringValue(dsConfig, "conf_value", i));

            _config = new Config();
            _config.initConfig(
               dicConfigs["title"],
                Convert.ToInt32(dicConfigs["member_join"]),
                Convert.ToInt32(dicConfigs["page_rows"]),
                Convert.ToInt32(dicConfigs["login_minutes"]),
                dicConfigs["intercept_ip"],
                dicConfigs["prohibit_id"]
            );

            string strLotterys = dicConfigs["lotterys"];
            string[] tmpLotterys = strLotterys.Split(';');

            _Lotterys = new Dictionary<int, Lottery>();

            for (int i = 0; i < tmpLotterys.Length; i++)
            {
                int nLotteryID = Convert.ToInt32(tmpLotterys[i].Split('-')[0]);
                string strLotteryNick = tmpLotterys[i].Split('-')[1];
                string strLotteryName = tmpLotterys[i].Split('-')[2];
                string strLotteryDesc = tmpLotterys[i].Split('-')[3];
                bool bLotteryPlaying = tmpLotterys[i].Split('-')[4] == "1";

                if (nLotteryID <= 0 || _Lotterys.Keys.Contains(nLotteryID))
                    continue;
                _Lotterys.Add(nLotteryID, new Lottery(nLotteryID, strLotteryNick, strLotteryName, strLotteryDesc, bLotteryPlaying));
            }

            _Lottery_topic = dicConfigs["lottery_topic"];

        }

        public void CreateHistory(long lUserID, string strHistory)
        {
            if (lUserID < 0)
                return;
            DBConn.RunStoreProcedure(Constants.SP_CREATEHISTORY,
                new string[]{
                    "@user_id",
                    "@history"
                },
                new object[]{
                    lUserID,
                    strHistory
                });
        }
        
        /// <summary>
        /// 유저가입 또는 정보수정시에 입력값 검사부분
        /// </summary>
        /// <returns></returns>
        protected bool validateInput(
            string strLoginID,
            string strLoginPwd,
            string strLoginPwdConfirm,
            string strNickName,
            string strTelNo,
            bool bRegister,
            out string strMsg)
        {
            strMsg = "";
            if (bRegister)
            {
                // 아이디 검사
                if (string.IsNullOrEmpty(strLoginID))
                {
                    strMsg = Resources.Err.ERR_LOGINID_INPUT;
                    return false;
                }
                if (!Regex.Match(strLoginID, Resources.RegEx.REGEX_LOGINID).Success)
                {
                    strMsg = Resources.Err.ERR_LOGINID_FORMAT;
                    return false;
                }

                // 닉네임 검사
                if (string.IsNullOrEmpty(strNickName))
                {
                    strMsg = Resources.Err.ERR_NICKNAME_INPUT;
                    return false;
                }
                if (!Regex.Match(strNickName, Resources.RegEx.REGEX_NICKNAME).Success)
                {
                    strMsg = Resources.Err.ERR_NICKNAME_FORMAT;
                    return false;
                }

                // 사용할수 없는 아이디,닉네임인가 검사
                string[] arrProhibitID = SiteConfig.ProhibitID.Split(',');
                if (arrProhibitID.Contains(strLoginID))
                {
                    strMsg = Resources.Err.ERR_LOGINID_CANNOTUSE;
                    return false;
                }

                if (arrProhibitID.Contains(strNickName))
                {
                    strMsg = Resources.Err.ERR_NICKNAME_CANNOTUSE;
                    return false;
                }

                // 패스워드 검사
                if (string.IsNullOrEmpty(strLoginPwd))
                {
                    strMsg = Resources.Err.ERR_LOGINPWD_INPUT;
                    return false;
                }
                if (!Regex.Match(strLoginPwd, Resources.RegEx.REGEX_LOGINPWD).Success)
                {
                    strMsg = Resources.Err.ERR_LOGINPWD_FORMAT;
                    return false;
                }

                // 확인용 패스워드 검사
                if (string.IsNullOrEmpty(strLoginPwdConfirm))
                {
                    strMsg = Resources.Err.ERR_LOGINPWDCONF_INPUT;
                    return false;
                }
                if (strLoginPwd != strLoginPwdConfirm)
                {
                    strMsg = Resources.Err.ERR_LOGINPWDCONF_FORMAT;
                    return false;
                }
                /*
                // 연락처 검사
                if (string.IsNullOrEmpty(strTelNo))
                {
                    strMsg = Resources.Err.ERR_TELNO_INPUT;
                    return false;
                }
                if (!Regex.Match(strTelNo, Resources.RegEx.REGEX_TELNO).Success)
                {
                    strMsg = Resources.Err.ERR_TELNO_FORMAT;
                    return false;
                }*/
            }
            else
            {
                // 패스워드 검사
                if (!string.IsNullOrEmpty(strLoginPwd))
                {
                    if (!Regex.Match(strLoginPwd, Resources.RegEx.REGEX_LOGINPWD).Success)
                    {
                        strMsg = Resources.Err.ERR_LOGINPWD_FORMAT;
                        return false;
                    }

                    // 확인용 패스워드 검사
                    if (string.IsNullOrEmpty(strLoginPwdConfirm))
                    {
                        strMsg = Resources.Err.ERR_LOGINPWDCONF_INPUT;
                        return false;
                    }
                    if (strLoginPwd != strLoginPwdConfirm)
                    {
                        strMsg = Resources.Err.ERR_LOGINPWDCONF_FORMAT;
                        return false;
                    }
                }
            }

            return true;
        }

        protected bool validateInput(
            string strLoginPwd,
            string strLoginPwdConfirm,
            string strTelNo,
            out string strMsg)
        {
            return validateInput(null, strLoginPwd, strLoginPwdConfirm, null, strTelNo, false, out strMsg);
        }
        protected bool validateInput(
            string strLoginID,
            string strLoginPwd,
            string strLoginPwdConfirm,
            string strNickName,
            string strTelNo,
            out string strMsg)
        {
            return validateInput(strLoginID, strLoginPwd, strLoginPwdConfirm, strNickName, strTelNo, true, out strMsg);
        }

        public string getBetMode(int nBetMode)
        {
            string strBetMode = "";
            switch (nBetMode)
            {
                case 8010101:
                    strBetMode = "猜冠军";
                    break;
                case 8020101:
                    strBetMode = "猜冠亚军";
                    break;
                case 8020201:
                    strBetMode = "猜冠亚军单式";
                    break;
                case 8030101:
                    strBetMode = "猜前三名";
                    break;
                case 8030201:
                    strBetMode = "猜前三名单式";
                    break;
                case 8040101:
                    strBetMode = "猜前四名";
                    break;
                case 8040201:
                    strBetMode = "猜前四名单式";
                    break;
                case 8050101:
                    strBetMode = "猜前五名";
                    break;
                case 8050201:
                    strBetMode = "猜前五名单式";
                    break;
                case 8060101:
                    strBetMode = "猜前六名";
                    break;
                case 8070101:
                    strBetMode = "猜前七名";
                    break;
                case 8080101:
                    strBetMode = "猜前八名";
                    break;
                case 8090101:
                    strBetMode = "猜前九名";
                    break;
                case 8100101:
                    strBetMode = "猜前十名";
                    break;
                case 8140101:
                    strBetMode = "前五定位胆";
                    break;
                case 8140102:
                    strBetMode = "后五定位胆";
                    break;
                case 8120101:
                    strBetMode = "自由双面";
                    break;
                case 8130101:
                    strBetMode = "1至3";
                    break;
                case 8130102:
                    strBetMode = "4至6";
                    break;
                case 8130103:
                    strBetMode = "7至10";
                    break;
                case 8130104:
                    strBetMode = "1至5";
                    break;
                case 8130105:
                    strBetMode = "6至10";
                    break;
                case 8150101:
                    strBetMode = "猜前四名";
                    break;
                case 8160101:
                    strBetMode = "猜前五名";
                    break;
                case 25010101:
                case 25010102:
                    strBetMode = "单式 - 左右";
                    break;
                case 25010103:
                case 25010104:
                    strBetMode = "单式 - 34";
                    break;
                case 25010105:
                case 25010106:
                    strBetMode = "单式 - 单双";
                    break;
                case 25020101:
                case 25020102:
                case 25020103:
                case 25020104:
                    strBetMode = "双式";
                    break;
                default:
                    break;
            }
            if (nBetMode > 8110100 && nBetMode < 8110130)
                strBetMode = "前三和值";
            
            return strBetMode;
        }
        #endregion

        #region 사건처리부
        protected virtual void Page_PreInit(object sender, EventArgs e)
        {
            // 디비 초기 연결 작업 시작...
            _dbconn = new MSSqlAccess();
            _dbconn.DBServer    = Constants.DB_CONN_HOST;
            _dbconn.DBPort      = Constants.DB_CONN_PORT;
            _dbconn.DBName      = Constants.DB_CONN_NAME;
            _dbconn.DBID        = Constants.DB_CONN_USER;
            _dbconn.DBPwd       = Constants.DB_CONN_PASS;
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

                if (!checkRequest())
                {
                    _isInited = false;
                    return;
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

        protected virtual void Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsInited)
            {
                ShowError(Resources.Err.ERR_CONFIG_INVALID);
            }
        }

        protected virtual void Page_Init(object sender, EventArgs e)
        {
            PageDataSource = null;

            checkAuth();

            // 중복 로그인 검사
            System.Data.DataSet dsLogin = DBConn.RunStoreProcedure(Constants.SP_GETLOGINS,
                new string[] {
                    "@user_id",
                    "@time"
                },
                new object[] {
                    AuthUser.ID,
                    SiteConfig.LoginMinutes
                });

            string strUserAgent = Request.ServerVariables["HTTP_USER_AGENT"];
            string strUserIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(strUserIP))
                strUserIP = Request.ServerVariables["REMOTE_ADDR"];

            if (!DataSetUtil.IsNullOrEmpty(dsLogin) &&
                (DataSetUtil.RowStringValue(dsLogin, "user_ip", 0) != strUserIP ||
                DataSetUtil.RowStringValue(dsLogin, "agent", 0) != strUserAgent))
            {
                Alert(string.Format(Resources.Msg.MSG_ALEADYLOGIN, DataSetUtil.RowStringValue(dsLogin, "user_ip", 0)), Defines.URL_LOGOUT);
                return;
            }
            if (SiteConfig.InterceptIP.IndexOf(strUserIP) >= 0)
            {
                Alert(string.Format("싸이트에 대한 접근이 차단되였습니다."), Defines.URL_LOGOUT);
                return;
            }
            ////////////////////////////////////////////////////////////////////////////
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            string strMsg = "";
            if (checkBlockOrLeave(out strMsg))
            {
                UserLogout();
                Alert(strMsg, Defines.URL_LOGIN);
            }

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["page"]))
                    PageNumber = Convert.ToInt32(Request.Params["page"]);

                InitControls();

                BindData();
            }
            //else
            //    LoadData();
        }

        protected virtual void Page_PreRender(object sender, EventArgs e)
        {
            MasterPageBase master = Master as MasterPageBase;
            if (master != null)
                master.UpdateUserInfo();
        }

        protected virtual void LoadData()
        {
        }
        protected virtual void BindData()
        {
            if (PageDataSource == null)
                LoadData();

            if (getGridControl() != null)
            {
                DataView dv = null;
                if (PageDataSource != null && PageDataSource.Tables.Count > 0)
                    dv = PageDataSource.Tables[0].DefaultView;

                if (DataSetUtil.IsNullOrEmpty(PageDataSource))
                    PageNumber = 0;
                else
                {
                    int iPageCount = PageDataSource.Tables[0].Rows.Count / getGridControl().PageSize;
                    if (iPageCount < PageNumber)
                    {
                        PageNumber = iPageCount;
                    }

                    if (!string.IsNullOrEmpty(SortColumn))
                    {
                        string strSort = (SortDirection == SortDirection.Ascending) ? SortColumn : SortColumn + " DESC";
                        dv.Sort = strSort;
                    }
                }

                if (dv != null)
                {
                    getGridControl().PageIndex = PageNumber;
                    getGridControl().DataSource = dv;
                    getGridControl().DataBind();
                }
            }
        }
        protected virtual void InitControls()
        {
            if (getGridControl() != null)
                getGridControl().PageSize = SiteConfig.PageRows;
        }
        protected virtual GridView getGridControl()
        {
            return null;
        }
        
        protected virtual void Page_Unload(object sender, EventArgs e)
        {
            // 디비 연결 닫기
            if (_dbconn != null)
            {
                _dbconn.Disconnect();
                _dbconn = null;
            }
        }

        protected virtual void gvContent_PageIndexChange(object sender, GridViewPageEventArgs e)
        {
            PageNumber = e.NewPageIndex;
            BindData();
        }
        protected virtual void gvContent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected virtual void gvContent_Sorting(object sender, GridViewSortEventArgs e)
        {
            // 요청되는 정돈항이 이전과 같으면 정돈방향을 바꾼다
            if (e.SortExpression == SortColumn)
            {
                SortDirection = (SortDirection == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            else
            {
                // 정돈항에 새 정돈항을 넣어주고 정돈방향은 Descending 으로 설정한다.
                SortColumn = e.SortExpression;
                SortDirection = SortDirection.Descending;
            }

            BindData();
        }
       
        #endregion

        public void writeLog(string strMsg)
        {
            try
            {
                string strLogDir = Server.MapPath("/logs");
                if (!Directory.Exists(strLogDir))
                    Directory.CreateDirectory(strLogDir);

                StreamWriter sWriter = new StreamWriter(strLogDir + "\\error.log", true);
                sWriter.WriteLine(string.Format("[{0:yyyy-MM-dd HH:mm:ss}] --> [{1}] : {2}",
                    DateTime.Now, Request.ServerVariables["REMOTE_ADDR"], strMsg));
                sWriter.Close();
            }
            catch
            {

            }
        }
    }
}