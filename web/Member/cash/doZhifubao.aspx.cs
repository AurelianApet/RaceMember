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

public partial class Member_cash_doZhifubao : Ronaldo.uibase.PageBase
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        writeLog("dozhifubao 결제 응답 접수! Page Initing... ");
    }
    protected override void Page_Load(object sender, EventArgs e)
    {
        writeLog("dozhifubao 결제 응답 접수! Page Loading...");
    }
}
