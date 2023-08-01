function goLink(m, param, other) {
    var boolPopup = false;
    var w = 100;
    var h = 100;
    var url = "";


    switch (m.toLowerCase()) {
        case "login":
            url = "/login.aspx";
            break;
        case "join":
            url = "/join.aspx";
            break;
        case "home":
            url = "/Member/lotterys.aspx";
            break;
        case "lottery":
            url = "/Member/lotterys.aspx";
            break;
        case "bet":
            url = "/Member/" + param + "/bet.aspx";
            break;
        case "bethist":
            url = "/Member/bethist.aspx";
            break;
        case "carddetail":
            url = "/Member/carddetail.aspx";
            break;
        case "chart":
            if (param == undefined || param == '')
                url = "/Member/chart.aspx";
            else
                url = "/Member/" + param + "/chart.aspx";
            break;
        case "chart-zonghe":
            url = "/Member/chart_zonghe.aspx";
            break;
        case "help":
            url = "/Member/help/help.aspx";
            break;
        case "helperpk10":
            url = "/Member/help/helpPk10.aspx";
            break;
        case "helperregist":
            url = "/Member/help/helpRegist.aspx";
            break;
        case "helperrecharge":
            url = "/Member/help/helpRecharge.aspx";
            break;
        case "helperrechargeways":
            url = "/Member/help/helpRechargeways.aspx";
            break;
        case "helperbet":
            url = "/Member/help/helpBet.aspx";
            break;
        case "myinfo":
            url = "/Member/myinfo.aspx";
            break;
        case "charge":
            url = "/Member/cash/charge.aspx";
            break;
        case "chargelog":
            url = "/Member/cash/chargelog.aspx";
            break;
        case "discharge":
            url = "/Member/cash/discharge.aspx";
            break;
        case "dischargelog":
            url = "/Member/cash/dischargelog.aspx";
            break;
        case "gamehist":
            if (param == undefined || param == '')
                url = "/Member/gamehist.aspx";
            else
                url = "/Member/" + param + "/gamehist.aspx";
            break;
        case "zhuihaolist":
            url = "/Member/zhuihaolist.aspx";
            break;
        case "zhuihaodetail":
            url = "/Member/zhuihaodetail.aspx";
            break;
        case "online":
            boolPopup = true;
            w = 1024;
            h = 596;
            url = "/kefu.html";
            break;
        case "logout":
            url = "/logout.aspx";
            break;
    }
    if (param != "" && param != undefined) {
        url = url + "?type=" + param;
    }
    if (m.toLowerCase() == "chart" && other != "" && other != undefined) {
        url = url + "&mode=" + other;
    }
    else if (other != "" && other != undefined) {
        if (other.indexOf('date') < 0) {
            var tmpDate = (new Date).DateAdd("day", other).Format("YYYY-MM-DD")
            url = url + "&date=" + tmpDate;
        } else {
            url = url + "&date=" + other.substring(5);
        }
    }
    if (boolPopup)
        window.open(url, m, "width=" + w + ", height=" + h);
    else
        document.location.href = url;
}