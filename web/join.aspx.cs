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

public partial class join : Ronaldo.uibase.PageBase
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        if (AuthUser != null)
        {
            Alert("로그인 회원은 이용하실 수 없습니다.", Defines.URL_LOGOUT);
        }
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!SiteConfig.MemberJoin)
        {
            Alert(Resources.Msg.MSG_CANNOT_MEMBERJOIN, Defines.URL_LOGIN);
            return;
        }
    }

    
}
