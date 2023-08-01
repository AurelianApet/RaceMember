<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carddetail.aspx.cs" Inherits="Member_carddetail" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('myinfo');
        ChangeUserInfoMenuSelected('membershowcarddetail');
    });
    $(document).ready(function() {
        init_showCardDetail();
    });
    function confirmCheck(confirmStr) {
        if (typeof (confirmStr) == "undefined" || confirmStr == "") {
            return true;
        } else {
            return confirm(confirmStr);
            
        }
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
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>银行卡资料</span> </div>
                    </div>
                    <div class="cont-body">
                        <!--tab-content-module start-->
                        <div class="tab-content">

                            <!--forms-table start-->
                            <div class="forms-table uc-forms">
                                <asp:Panel ID="pnlViewBankInfo" runat="server">
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label id="withdraw_account_Title">收款账号：</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0" id="withdraw_account"> <span class="fw-text"><asp:Literal ID="ltlBankName" runat="server" Text=""></asp:Literal></span> </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label id="withdraw_name_Title">收款户名：</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0" id="withdraw_name"> <span class="fw-text"><asp:Literal ID="ltlBankOwner" runat="server" Text=""></asp:Literal></span> </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>账户号码：</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0" id="withdraw_AvailablePoint"> <span class="fw-text"><asp:Literal ID="ltlBankNum" runat="server" Text=""></asp:Literal></span> </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--tips-base start-->
                                    <div class="tips-base">

                                        <!--item start-->
                                        <div class="radius-3 item">
                                            <p>支付资料已设置，用户无法修改！</p>
                                        </div>
                                        <!--item end-->
                                        <!--item start-->
                                        <div class="radius-3 item">
                                            <p>如需修改，请联系客服！</p>
                                        </div>
                                        <!--item end-->
                                    </div>
                                    <!--tips-base end-->
                                </asp:Panel>
                                <asp:Panel ID="pnlSetBankInfo" runat="server">
                                    <div class="tips-base">

                                        <!--item start-->
                                        <div class="radius-3 item">
                                            <p style="color:Red;">设置后无法更改，请认真填写</p>
                                        </div>
                                        <!--item end-->
                                        <!--item end-->
                                    </div>
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>银行名:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxBankName" runat="server" CssClass="tpui-text" placeholder="请输入收款账号，如 中国工商银行" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>持卡人姓名:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxBankOwner" runat="server" CssClass="tpui-text" placeholder="请输入持卡人姓名" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>银行卡号:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxBankNum" runat="server" CssClass="tpui-text" placeholder="请输入银行卡号" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>银行卡号确认:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxBankNumConfirm" runat="server" CssClass="tpui-text" placeholder="请输入银行卡号确认" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>提现密码:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxDischargePwd" runat="server" CssClass="tpui-text" TextMode="Password" placeholder="请输入提现密码" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>提现密码确认:</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:TextBox ID="tbxDischargePwdConfirm" runat="server" CssClass="tpui-text" TextMode="Password" placeholder="请输入提现密码确认" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--tips-base start-->
                                    <div class="tips-base">

                                        <!--item start-->
                                        <div class="radius-3 item">
                                            <p>提现账户和提现密码设置后无法修改，请确认清楚后再输入！</p>
                                        </div>
                                        <!--item end-->
                                        <!--item start-->
                                        <div class="radius-3 item">
                                            <p>如需要更改请联系客服。</p>
                                        </div>
                                        <!--item end-->
                                    </div>
                                    <!--tips-base end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0"><label>&nbsp;</label></div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <asp:Button ID="ltlSave" runat="server" CssClass="tpui-button" Text="保存" OnClientClick="return confirmCheck('提现账号设置后无法再更改，请确认您填写的信息是否正确，如正确 点确认，不设置或不正确请点取消。');" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                </asp:Panel>
                            </div>
                            <!--forms-table end-->
                        </div>
                        <!--tab-content-module end-->

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>