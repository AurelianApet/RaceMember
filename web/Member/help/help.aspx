<%@ Page Language="C#" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="Member_help_help" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftRuleMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
gl.title = "帮助";
$(function() {
    ChangeMenuImageSelected('help');
    init_HelperComm();
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <!--main-body start-->
    <div class="row">
        <ucLeftfix:ucLeft runat="server" ID="usLeft" />
        <div class="column b-85 mainbody">
            <div class="layout-base cont cont-full">
                <div class="cont-head">
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>常见问题</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-list active">
                        <ul>
                            <li> <a href="javascript:goLink('helperregist');">如何成为K彩会员？</a></li>
                            <li> <a href="javascript:goLink('helperrecharge');">如何充值？</a></li>
                            <li> <a href="javascript:goLink('helperrechargeways');">充值有哪几种方式？</a></li>
                            <li> <a href="javascript:goLink('helperbet');">如何购彩？</a></li>
                            <li> <a href="javascript:goLink('helperlottery');">平台有几个彩种？</a></li>
                            <li> <a href="javascript:goLink('helperpeakmoney');">如何提款？</a></li>
                            <li> <a href="javascript:goLink('helpermoneyreach');">提款多长时间可以到账？</a></li>
                            <li> <a href="javascript:goLink('helperbetrecord');">如何查看投注记录？</a></li>
                            <li> <a href="javascript:goLink('helperzhuihao');">如何进行追号？</a></li>
                            <li> <a href="javascript:goLink('helperzhuihaoways');">有哪几种追号方式？</a></li>
                            <li> <a href="javascript:goLink('helperquerybonus');">如何查看奖金多少？</a></li>
                            <li> <a href="javascript:goLink('helpermultipleaccount');">一个人可以拥有多个平台账号不？</a></li>
                            <li> <a href="javascript:goLink('helpernameorbankwrong');">注册时真实姓名跟银行卡号填写有误怎么办</a></li>
                            <li> <a href="javascript:goLink('helpercustomer');">如何与客服取得联系？</a></li>
                            <li> <a href="javascript:goLink('helperbetsecurity');">参与游戏是否安全？</a></li>
                            <li> <a href="javascript:goLink('helperfundsecurity');">K彩娱乐网上充值安全吗？</a></li>
                            <li> <a href="javascript:goLink('helpermobilesecurity');">手机安全中心是什么？</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--main-body end--> 
</div>
</asp:Content>