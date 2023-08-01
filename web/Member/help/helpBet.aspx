<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpBet.aspx.cs" Inherits="Member_help_helpBet" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftRuleMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {    
    ChangeMenuImageSelected('ask');
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row">
        <ucLeftfix:ucLeft runat="server" ID="usLeft" />
        <div class="column b-85 mainbody">
            <div class="layout-base cont cont-full">
                <div class="cont-head">
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>如何购彩</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-head"><h2>如何购彩</h2></div>
                    <div class="module article-overview"><p style="font-size: small;">K彩提供丰富的彩种</p></div>
                    <div class="module article-detial">
                        <p style="text-indent: 8mm;font-size: small;">1.选择彩种，可以在平台的左上角选择彩种，也可以在首页直接选择某个彩种进入</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperBet/one.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">2.选择相应的彩种玩法进行投注，并点击【确认选号】</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperBet/two.png" style="max-width: 600px;">
                        </p>
                        <p style="line-height: 16px;">&nbsp;</p>
                        <p style="text-indent: 8mm;font-size: small;">3.点击[确认投注]</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperBet/three.png" style="max-width: 600px;">
                        </p>
                        <p style="line-height: 16px;">&nbsp;</p>
                        <p style="text-indent: 8mm;font-size: small;">4.点击[提交订单]即可完成投注</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperBet/four.png" style="max-width: 600px;">
                        </p>
                    </div>
                    <div class="article-navigation">
                        <ul>
                            <li><span>上一篇：</span><a href="javascript:goLink('helperrechargeways');">充值有哪几种方式</a></li>
                            <li><span>下一篇：</span><a href="javascript:goLink('helperlottery');">平台有几个彩种</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>