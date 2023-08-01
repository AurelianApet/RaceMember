<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpRechargeways.aspx.cs" Inherits="Member_help_helpRechargeways" MasterPageFile="~/Member/MemberMaster.master" %>
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
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>充值有哪几种方式</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-head"><h2>充值有哪几种方式</h2></div>
                    <div class="module article-overview"><p style="font-size: small;">K彩支持多种充值方式：普通充值通道（包括工商银行、财付通、支付宝），以及第三方快捷支付通道</p></div>
                    <div class="module article-detial">
                        <p style="text-indent: 8mm;font-size: small;">1.普通充值通道</p>
                        <p style="text-indent: 8mm;font-size: small;">a.工商银行充值方式</p>
                        <p style="text-indent: 8mm;font-size: small;">b.财付通充值方式</p>
                        <p style="text-indent: 8mm;font-size: small;">c.支付宝充值方式</p>
                        <p style="line-height: 16px;">&nbsp;</p>
                        <p style="text-indent: 8mm;font-size: small;">2.及第三方快捷支付通道</p>
                    </div>
                    <div class="article-navigation">
                        <ul>
                            <li><span>上一篇：</span><a href="javascript:goLink('helperrecharge');">如何充值</a></li>
                            <li><span>下一篇：</span><a href="javascript:goLink('helperbet');">如何购彩</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>