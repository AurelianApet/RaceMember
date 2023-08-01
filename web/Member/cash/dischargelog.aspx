<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dischargelog.aspx.cs" Inherits="Member_dischargelog" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('myinfo');
        ChangeUserInfoMenuSelected('memberwithdrawlog');
    });
    gl.title = '提现记录 - K彩';
    $(document).ready(function() {
        init_memberWithdrawList();
    });
    var TotalPages = 0;

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
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>提现记录</span> </div>
                    </div>
                    <div class="cont-body">

                        <!--tab-nav start-->
                        <div class="module tab-nav member-tab">
                            <ul>
                                <li><a href="javascript:goLink('discharge')">提现</a></li>
                                <li class="active"><a>提现记录</a></li>
                            </ul>
                        </div>
                        <!--tab-nav end-->
                        <!--tab-content-module start-->
                        <div class="tab-content">

                            <!--operate start-->
                            <div class="module operate-bar operate-bar-hor data-table-option">
                                <ul>
                                    <li>
                                        <label>起始日期:</label>
                                        <asp:TextBox ID="tbxStartDate" runat="server" CssClass="tpui-text kc-calendar startDateClass" data-end-date="" size="8" data-icon-after="kc-calendar" Text="2016-06-17"></asp:TextBox>
                                        <span>-</span>
                                        <asp:TextBox ID="tbxEndDate" runat="server" CssClass="tpui-text kc-calendar endDateClass" data-end-date="" size="8" data-icon-after="kc-calendar" value="2016-06-19"></asp:TextBox>
                                    </li>
                                    <li>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="tpui-button GetDataByPageIndex" page_index="1" page_change="0" data-type="submit" Text="查询" OnClick="btnSearch_Click" />
                                    </li>
                                </ul>
                            </div>
                            <!--operate end-->
                            <!--table start-->
                            <div class="module table ta-center table-even-dark table-hover">
                                <asp:GridView ID="gvRecentHist" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                                    AllowPaging="true" AllowSorting="false"
                                    GridLines="None"
                                    AutoGenerateColumns="false"
                                    OnPageIndexChanging="gvContent_PageIndexChange">
                                    <Columns>
                                        
                                        <asp:TemplateField HeaderText="类型">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%#Eval("ownername") %>        
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="金额(元)">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%#string.Format("{0:N0}", Eval("reqmoney")) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="交易日期" >
                                            <HeaderStyle HorizontalAlign="Center" CssClass="first" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="first" />
                                            <ItemTemplate>
                                                <%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("regdate")) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%#Convert.ToInt16(Eval("status")) == Ronaldo.common.Constants.MONEYINOUT_REQUEST ? "<font color='blue'><b>" + Resources.Str.STR_PROCESSING + "</b></font>" : ""%>
                                                <%#Convert.ToInt16(Eval("status")) == Ronaldo.common.Constants.MONEYINOUT_APPLY ? "<font color='red'><b>" + Resources.Str.STR_COMPLETE + "</b></font>" : ""%>
                                                <%#Convert.ToInt16(Eval("status")) == Ronaldo.common.Constants.MONEYINOUT_CANCEL ? "<font color='red'><b>" + Resources.Str.STR_CANCEL + "</b></font>" : ""%>
                                                <%#Convert.ToInt16(Eval("status")) == Ronaldo.common.Constants.MONEYINOUT_STANDBY ? "<b>" + Resources.Str.STR_STANDBY + "</b>" : ""%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle Height="28px" />
                                    <EmptyDataRowStyle VerticalAlign="Middle" CssClass="clsemptyrow"  />
                                    <EmptyDataTemplate>
                                        <div class="complete">
                                            <div class="complete-sub image"> <span><img src="/images/status/empty.png" alt=""></span> </div>
                                            <div class="complete-sub title">
                                                <h2>呃...没有提现记录!</h2>
                                            </div>
                                        </div>
                                    </EmptyDataTemplate>
                                    <PagerSettings Mode="Numeric" Position="Bottom"
                                        FirstPageText="<%$Resources:Str, STR_FIRST %>"
                                        PreviousPageText="<%$Resources:Str, STR_PREV %>"
                                        NextPageText="<%$Resources:Str, STR_NEXT %>"
                                        LastPageText="&nbsp;<%$Resources:Str, STR_LAST %>"
                                        PageButtonCount="10" />
                                    <PagerStyle CssClass="clspager" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                            <!--table end-->
                            <!--pagination start-->
                            <div class="module pagination pagination-depart" style="display:none;">
                                <ul>
                                    <li><a page_index="1" page_change="0" class="GetDataByPageIndex" href="javascript:void(0);">&lt;&lt; 首页</a></li>
                                    <li><a page_index="1" page_change="-1" class="GetDataByPageIndex" href="javascript:void(0);">&lt; 上一页</a></li>
                                    <li><a page_index="1" page_change="1" class="GetDataByPageIndex" href="javascript:void(0);">下一页 &gt;</a></li>
                                    <li><a page_index="0" page_change="0" class="GetDataByPageIndex" href="javascript:void(0);">最后页 &gt;&gt;</a></li>
                                    <li>
                                        <span>第<em>1</em><em>/</em><em>0</em>页</span>
                                    </li>
                                    <li>
                                        <span>共 0 笔记录</span>
                                    </li>
                                    <li><a page_index="1" page_change="0" class="GetDataByPageIndex" href="javascript:void(0);">刷新O</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>