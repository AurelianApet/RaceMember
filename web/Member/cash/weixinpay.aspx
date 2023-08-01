<%@ Page Language="C#" AutoEventWireup="true" CodeFile="weixinpay.aspx.cs" Inherits="Member_cash_weixinpay" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script src="/js/qrcode.js"></script>
<asp:Literal ID="ltlHeadScript" runat="server" Text=""></asp:Literal>
<script type="text/javascript" language="javascript">
    var timer = null;
    $(document).ready(function() {
        timer = setInterval(check, 3000);
    });
    function check() {
        ctx.postTokenEx({
            url: "/Member/cash/getChargeTradeInfo.aspx?trade_no=" + trade_no,
            complete: function() {

            },
            success: function(n) {
                if (n.Status == 1 || n.Status == 2) {
                    alert(n.Tip);
                    clearInterval(timer);
                    setTimeout(gotoCharge, 5000);
                }
            }
        })
    }
    function gotoCharge() {
        goLink('charge');
    }
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="memberSideBarId">
        <div class="row layout-base cont" id="member-cont">
            <ucLeftfix:ucLeft runat="server" ID="usLeft" />
            <div class="column b-85 mainbody" id="main-body">
                <div class="cont cont-base">
                    <div class="cont-head">
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>订单支付</span> </div>
                    </div>
                    <div class="cont-body">
                        <div class="module article-overview">
                            <p style="font-size: small;width: 70%;">这是您的支付二维码。请用手机扫描二维码完成支付。</p>
                            <div align="center" id="qrcode">
	                        </div>
	                        <asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
            