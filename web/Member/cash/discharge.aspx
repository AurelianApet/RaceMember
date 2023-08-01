<%@ Page Language="C#" AutoEventWireup="true" CodeFile="discharge.aspx.cs" Inherits="Member_discharge" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('myinfo');
        ChangeUserInfoMenuSelected('memberwithdraw');
    });
</script>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="memberSideBarId">
        <div class="row layout-base cont" id="member-cont">
            <ucLeftfix:ucLeft runat="server" ID="usLeft" />
            <div class="column b-85 mainbody" id="main-body">
                <div class="cont cont-base">
                    <div class="cont-head">
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>提现</span> </div>
                    </div>
                    <div class="cont-body">

                        <!--tab-nav start-->
                        <div class="module tab-nav member-tab">
                            <ul>
                                <li class="active"><a>提现</a></li>
                                <li><a href="javascript:goLink('dischargelog');">提现记录</a></li>
                            </ul>
                        </div>
                        <!--tab-nav end-->
                        <!--tab-content-module start-->
                        <div class="tab-content">

                            <!--forms-table start-->
                            <div class="forms-table uc-forms">
                                
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label id="withdraw_account_Title">收款账号:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0" id="withdraw_account"> <span class="fw-text"></span> </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label id="withdraw_name_Title">收款户名:</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0" id="withdraw_name"> <span class="fw-text"></span> </div>
                                </div>
                                <!--form-row end-->
                                <!--form-row start-->
                                <div class="row form-row">
                                    <div class="column form-sub form-title b-25 mb-0">
                                        <label>可用分数：</label>
                                    </div>
                                    <div class="column form-sub form-input b-75 mb-0" id="withdraw_AvailablePoint"> <span class="fw-text"></span> </div>
                                </div>
                                <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>提现金额：</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <input type="text" id="WithDraw_Money" class="myNumClass0" min="100" max="5000000" step="1" data-type="d" value="100"><label>* 最小提现金额<span style="color: red"> &yen; 100.00 </span>元 *</label>
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>资金密码：</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <input type="password" id="WithDraw_FundPassword" class="tpui-text" placeholder="请填写您的资金操作密码" />
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <!--form-row start-->
                                    <!--form-row start-->
                                    <div class="row form-row">
                                        <div class="column form-sub form-title b-25 mb-0">
                                            <label>&nbsp;</label>
                                        </div>
                                        <div class="column form-sub form-input b-75 mb-0">
                                            <label>&nbsp;&nbsp;&nbsp;</label>
                                            <input type="submit" class="tpui-button" data-type="submit" id="withdraw_submit" value="提交提现申请" onclick="return false;">
                                        </div>
                                    </div>
                                    <!--form-row end-->
                                    <div class="complete complete-warning">
                                        <div class="complete-sub title" id="withdraw_tips">
                                            <h2>今日提现次数已用完</h2><h4>同一账户每日最多提现两次，您已操作2次</h4>
                                        </div>
                                    </div>
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