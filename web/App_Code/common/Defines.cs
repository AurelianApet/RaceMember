using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Ronaldo.common
{
    /// <summary>
    /// Summary description for Defines
    /// </summary>
    public class Defines
    {
        #region 페이지 관련 정보
        public static string URL_LOGIN
        {
            get { return ConfigurationManager.AppSettings["URL_LOGIN"]; }
        }
        public static string URL_LOGOUT
        {
            get { return ConfigurationManager.AppSettings["URL_LOGOUT"]; }
        }
        public static string URL_DEFAULT
        {
            get { return ConfigurationManager.AppSettings["URL_DEFAULT"]; }
        }
        public static string URL_PREFIX_MEMBER
        {
            get { return ConfigurationManager.AppSettings["URL_PREFIX_MEMBER"]; }
        }
        public static string URL_MOBILE
        {
            get { return ConfigurationManager.AppSettings["URL_MOBILE"]; }
        }
        public static string URL_SITENAME
        {
            get { return ConfigurationManager.AppSettings["URL_SITENAME"]; }
        }
        public static string URL_SMS
        {
            get { return ConfigurationManager.AppSettings["URL_SMS"]; }
        }
        public static string MAIL_ADMIN
        {
            get { return ConfigurationManager.AppSettings["MAIL_ADMIN"]; }
        }
        #endregion

        #region 쿠키 관련 정보
        public static bool COOKIE_INUSED
        {
            get { return (ConfigurationManager.AppSettings["COOKIE_INUSED"].ToLower() == "true"); }
        }
        public static int COOKIE_TIMEOUT
        {
            get
            {
                int iTimeOut = 0;
                return (int.TryParse(ConfigurationManager.AppSettings["COOKIE_TIMEOUT"], out iTimeOut) && iTimeOut > 0 ? iTimeOut : 24);
            }
        }
        #endregion

        #region 세션 관련 정보
        public static int SESSION_TIMEOUT
        {
            get
            {
                int iTimeOut = 0;
                return (int.TryParse(ConfigurationManager.AppSettings["SESSION_TIMEOUT"], out iTimeOut) && iTimeOut > 0 ? iTimeOut : 30);
            }
        }
        #endregion
    }
}