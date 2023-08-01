<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpRegist.aspx.cs" Inherits="Member_help_helpRegist" MasterPageFile="~/Member/MemberMaster.master" %>
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
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>如何成为K彩会员</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-head"><h2>如何成为K彩会员</h2></div>
                    <div class="module article-overview"><p style="font-size: small;">K彩只能通过介绍人链接注册</p></div>
                    <div class="module article-detial">
                        <p style="text-indent: 8mm;font-size: small;">a.打开介绍人链接注册地址</p>
                        <p style="text-align:center;"><img src="/Images/articles/helperRegist/one.png" style="max-width: 600px;" /></p>
                        <p style="text-indent: 8mm;font-size: small;">b.完善相关资料，点击【立即注册】，即可完成注册</p>
                    </div>
                    <div class="article-navigation">
                        <ul>
                            <li><span>上一篇：</span><a href="javascript:goLink('help');">常见问题</a></li>
                            <li><span>下一篇：</span><a href="javascript:goLink('helperrecharge');">如何充值</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>