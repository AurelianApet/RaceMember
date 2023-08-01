<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpRecharge.aspx.cs" Inherits="Member_help_helpRecharge" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftRuleMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {    
    ChangeMenuImageSelected('help');
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
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>如何充值</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-head"><h2>如何充值</h2></div>
                    <div class="module article-overview"><p style="font-size: small;">K彩支持多种充值方式：普通充值通道（包括工商银行、财付通、支付宝），以及第三方支付通道</p></div>
                    <div class="module article-detial">
                        <p style="text-indent: 8mm;font-size: small;">1.点击页面头部的【充值】按钮</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/one.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">2.选择充值通道</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/two.png" style="max-width: 600px;">
                        </p>
                        <p style="line-height: 16px;">&nbsp;</p>
                        <p style="text-indent: 8mm;font-size: small;">a.普通充值通道，输入金额与资金密码，点击【提交充值申请】按钮</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/three.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">工商银行方式：</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/four.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">财付通方式：</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/five.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">支付宝方式：</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/six.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">b.第三方支付通道，输入金额，点击【提交充值申请】</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/seven.png" style="max-width: 600px;">
                        </p>
                        <p style="text-indent: 8mm;font-size: small;">在第三方支付平台按步骤进行操作即可</p>
                        <p style="text-align:center;">
                            <img src="/Images/articles/helperRecharge/eight.png" style="max-width: 600px;">
                        </p>
                    </div>
                    <div class="article-navigation">
                        <ul>
                            <li><span>上一篇：</span><a href="javascript:goLink('helperregist');">如何成为K彩会员</a></li>
                            <li><span>下一篇：</span><a href="javascript:goLink('helperrechargeways');">充值有哪几种方式</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>