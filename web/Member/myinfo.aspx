<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myinfo.aspx.cs" Inherits="Member_myinfo" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>


<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
gl.title = '个人资料';
$(document).ready(function() {
    ChangeMenuImageSelected('myinfo');
    ChangeUserInfoMenuSelected('memberinfo');
    init_memberInfo();
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="memberSideBarId" style="">
        <div class="row layout-base cont" id="member-cont">
            <ucLeftfix:ucLeft runat="server" ID="usLeft" />
            <div class="column b-85 mainbody" id="main-body">
                <div class="column b-75 mainbody">
                    <!--cont-base start-->
                    <div class="cont cont-base">
                        <div class="cont-head">
                            <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>个人资料</span> </div>
                        </div>
                        <div class="cont-body">
                            <!--forms-table start-->
                            <div class="forms-table uc-forms">
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0"><label>&nbsp;</label></div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <!--avatar-checker start-->
                                        <div id="avatar-checker">
                                            <div class="image"> <a href="javascript:void(0);"><asp:Literal ID="ltlAvatar" runat="server" Text=""></asp:Literal></a> </div>
                                            <div class="handle">
                                                <button title="更改头像" onclick="return false;"><i>更改头像</i></button>
                                            </div>
                                            <div class="file">
                                                <input type="file" name="avatar" />
                                            </div>
                                            <div class="refer">
                                                <ul>
                                                    <li class="active">
                                                        <a href="javascript:void(0);" data-name="001"><img src="/images/avatar/001.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="002"><img src="/images/avatar/002.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="003"><img src="/images/avatar/003.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="004"><img src="/images/avatar/004.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="005"><img src="/images/avatar/005.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="006"><img src="/images/avatar/006.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="007"><img src="/images/avatar/007.jpg" alt=""></a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0);" data-name="008"><img src="/images/avatar/008.jpg" alt=""></a>
                                                    </li>
                                                </ul>
                                                <a class="close" href="javascript:void(0);">关闭</a>
                                            </div>
                                        </div>
                                        <!--avatar-checker end-->
                                    </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>用户名:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0" id="withdraw_account"> <span class="fw-text"><asp:Literal ID="ltlLoginID" runat="server" Text=""></asp:Literal></span> </div>
                                </div>
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>真实姓名:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <asp:TextBox ID="tbxNick" runat="server" CssClass="tpui-text" placeholder="您的称呼和个性名称" Text=""></asp:TextBox>
                                    </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>输入原密码:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <asp:TextBox ID="tbxOldPwb" runat="server" CssClass="tpui-text" placeholder="* 如不修改密码直接留空即可。" TextMode="Password" Text=""></asp:TextBox>
                                    </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>输入新密码:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <asp:TextBox ID="tbxNewPwb" runat="server" CssClass="tpui-text" placeholder="* 如不修改密码直接留空即可。" TextMode="Password" Text=""></asp:TextBox>
                                    </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>输入新密码确认:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <asp:TextBox ID="tbxConfirmPwb" runat="server" CssClass="tpui-text" placeholder="* 如不修改密码直接留空即可。" TextMode="Password" Text=""></asp:TextBox>
                                    </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0"><label>&nbsp;</label></div>
                                    <div class="column form-sub form-input b-75 mb-0">
                                        <asp:Button ID="ltlSave" runat="server" CssClass="tpui-button" Text="保存修改" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                                <!--form-row end-->

                            </div>
                            <!--operate end-->

                        </div>
                    </div>
                    <!--cont-base end-->
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
