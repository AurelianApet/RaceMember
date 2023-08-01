using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ronaldo.common
{
    /// <summary>
    /// Summary description for Constants
    /// </summary>
    public class Constants
    {
        #region 쿠키 관련 상수
        public const string COOKIE_KEY_SITE             = "RACEMEMBER::COOKIE::KEY";
        public const string COOKIE_KEY_SITE_LANGUAGE    = "RACEMEMBER::COOKIE::KEY::SITE::LANGUAGE";
        public const string COOKIE_KEY_USERINFO         = "RACEMEMBER::COOKIE::KEY::USERINFO";
        public const string COOKIE_KEY_CREDITINFO       = "RACEMEMBER::COOKIE::KEY::CREDITINFO";
        public const string COOKIE_KEY_TEAMNAMEKR       = "RACEMEMBER::COOKIE::KEY::TEAMNAMEJR";
        #endregion

        #region 세션 관련 상수
        public const string SESSION_KEY_USERINFO        = "ACEMEMBER::SESSION::KEY::USERINFO";
        public const string SESSION_KEY_AUTOLOGOUT      = "ACEMEMBER::SESSION::KEY::AUTOLOGOUT";
        public const string SESSION_KEY_MOBILETYPE      = "ACEMEMBER::SESSION::KEY::MOBILETYPE";
        #endregion

        #region 뷰스테이트 관련 상수
        public const string VS_PAGENUMBER = "PageNumber";
        public const string VS_DATASOURCE = "DataSource";

        public const string VS_STARTDATE = "StartDate";
        public const string VS_ENDDATE = "EndDate";

        public const string VS_SORTCOLUMN = "SortColumn";
        public const string VS_SORTDIRECTION = "SortDirection";

        public const string VS_SEARCHDATE = "SearchDate";
        #endregion

        #region 디비관련상수
        /*
        public const string DB_CONN_HOST    = "127.0.0.1"; //192.168.30.1
        public const string DB_CONN_PORT    = "1433"; //56777
        public const string DB_CONN_NAME    = "RaceGame";
        public const string DB_CONN_USER    = "cargame";//"sa_ace";
        public const string DB_CONN_PASS    = "qweASDzxc!@#456";//"qweASDzxc!@#456";
        public const string DB_CONN_BACKUP  = "D:\\DBBackup\\";
        /*/
        public const string DB_CONN_HOST    = "127.0.0.1";
        public const string DB_CONN_PORT    = "1433";
        public const string DB_CONN_NAME    = "RaceGame";
        public const string DB_CONN_USER    = "sa";
        public const string DB_CONN_PASS    = "sa";
        public const string DB_CONN_BACKUP  = "D:\\DBBackup\\";
        /**/
        #endregion

        #region 충환전 상수
        public const int MONEYINOUT_CHARGE = 0;
        public const int MONEYINOUT_DISCHARGE = 1;

        public const int MONEYINOUT_REQUEST = 0;
        public const int MONEYINOUT_APPLY = 1;
        public const int MONEYINOUT_CANCEL = 2;
        public const int MONEYINOUT_STANDBY = 3;
        #endregion

        #region Stored Procedure 이름 정의
        public static string SP_GETCONFIG = "sp_getConfig";

        public static string SP_GETSITE = "sp_getSite";
        public static string SP_CREATEUSER = "sp_createUser";
        public static string SP_GETUSER = "sp_getUser";
        public static string SP_UPDATEUSER = "sp_updateUser";
        public static string SP_UPDATEUSERINFO = "sp_updateUserInfo";
        public static string SP_GETCURRENTMONEY = "sp_getCurrentMoney";

        public static string SP_CREATEMONEYINOUT = "sp_createMoneyInOut";
        public static string SP_GETMONEYINOUTS = "sp_getMoneyInOuts";
        public static string SP_UPDATEMONEYINOUTS = "sp_updateMoneyInOuts";
        
        public static string SP_CREATEMONEYINFO = "sp_createMoneyInfo";

        public static string SP_CREATEHISTORY = "sp_createHistory";

        public static string SP_CREATELOGIN = "sp_createLogin";
        public static string SP_GETLOGINS = "sp_getLogins";
        public static string SP_UPDATELOGIN = "sp_updateLogin";

        public static string SP_GETCURRENTGAME = "sp_getCurrentGame";
        public static string SP_GETGAMEHIST = "sp_getGameHist";

        public static string SP_GETBETTINGHIST = "sp_getBettingHist";

        public static string SP_GETFAVS = "sp_getFavs";
        public static string SP_CREATEFAV = "sp_createFav";
        public static string SP_DELETEFAV = "sp_deleteFav";

        public static string SP_GETZHUIHAOHIST = "sp_getZhuihaoHist";

        public static string SP_GETNOTICELIST = "sp_getNoticeList";
        #endregion

        #region 지급상태 상수
        public const int CALC_NOPAY = 0;        // 미지급
        public const int CALC_PAYED = 1;        // 지급
        #endregion

        #region 게임 상태
        public const int GAMESTATE_STANDBY = 0;     // 등록대기
        public const int GAMESTATE_RUNNING = 1;     // 진행중
        public const int GAMESTATE_RESULTINPUT = 2; // 결과입력(배팅마감)
        public const int GAMESTATE_END = 3;         // 경기마감
        public const int GAMESTATE_CNACEL = 4;      // 경기취소
        #endregion

        #region 정렬상수
        public const int SORTTYPE_DESC = 0;
        public const int SORTTYPE_ASC = 1;
        #endregion

        #region 게임류형상수
        public const int GAMETYPE_NORMAL = 0;   //일반적으로 게임 전체를 나타낸다.
        public const int GAMETYPE_RACE = 8;     //경주경기
        public const int GAMETYPE_LADDER = 25;   //사다리경기
        #endregion

        #region 게시글 종류
        public const int NOTICEKIND_NOTICE = 0;        // 공지사항
        public const int NOTICEKIND_MESSAGE = 4;        // 쪽지
        #endregion
    }
}