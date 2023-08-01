<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bethist.aspx.cs" Inherits="Member_bethist" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {
    ChangeMenuImageSelected('bethist');
    ChangeUserInfoMenuSelected('bethist');
});
gl.title = '彩票投注记录 - K彩';
$(document).ready(function() {
    gl.memberBetRecordData = [];
    init_memberBetRecord("0");
});

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
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>游戏记录 &gt; 投注记录</span> </div>
                    </div>
                    <div class="cont-body">
                        <div class="module operate-bar operate-bar-hor data-table-option">
                            <ul>
                                <li>
                                    <label>起始日期:</label>
                                    <asp:TextBox ID="tbxStartDate" runat="server" CssClass="tpui-text kc-calendar startDateClass" size="8" data-icon-after="kc-calendar" Text="2016-06-17"></asp:TextBox>
                                    <span>-</span>
                                    <asp:TextBox ID="tbxEndDate" runat="server" CssClass="tpui-text kc-calendar endDateClass"  size="8" data-icon-after="kc-calendar" Text="2016-06-19"></asp:TextBox>
                                </li>
                                <li>
                                    <label>彩种:</label>
                                    <select id="selLottery" runat="server" class="tpui-select lotteryCodeClass" data-height="280">
                                        <option value="8">极速赛车</option>
                                        <option value="25">幸运梯子</option>
                                    </select>
                                </li>
                                <li style="display: none;">
                                    <label>投注批号:</label>
                                    <input type="text" class="tpui-text batchNoClass" value="" />
                                </li>
                                <li>
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="tpui-button GetDataByPageIndex" OnClick="btnSearch_Click" /> 
                                </li>
                            </ul>
                        </div>
                        <!--operate end-->
                        <!--table start-->
                        <div class="module table ta-center table-even-dark table-responsive">
                            <asp:GridView ID="gvBetContent" runat="server" GridLines="None"
                                Width="100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="true" 
                                OnRowDataBound="gvContent_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate><span>订单编号</span></HeaderTemplate>
                                    <ItemTemplate>
                                        <span><%#Eval("id") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="彩种">
                                    <ItemTemplate>
                                        <span><asp:Literal ID="ltlLotteryName" runat="server" Text=""></asp:Literal></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="期号">
                                    <HeaderStyle CssClass="dl-number" />
                                    <ItemTemplate>
                                        <span><%#Eval("round")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="玩法">
                                    <ItemTemplate>
                                        <span class="fc-yellow"><%#getBetMode(Convert.ToInt32(Eval("betpos")))%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总赔率">
                                    <HeaderStyle Width="82px" />
                                    <ItemTemplate>
                                        <span class="fc-orgen"><%#string.Format("{0:F1}", Convert.ToDouble(Eval("ratio")) * 2) %> / <%#Eval("ratio")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="选号">
                                    <ItemTemplate>
                                        <span><%#Eval("betval") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="投注金额">
                                    <HeaderStyle Width="60px" />
                                    <ItemTemplate>
                                        <span class="fc-blue betAmount"><%#Eval("betmoney")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="盈亏金额">
                                    <HeaderStyle Width="60px" />
                                    <ItemTemplate>
                                        <span class="fc-blue betAmount"><asp:Literal ID="ltlBenefit" runat="server"></asp:Literal></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="说明">
                                    <ItemTemplate>
                                        <span class="fc-green"><%# string.IsNullOrEmpty(Eval("descript").ToString()) ? "普通投注" : Eval("descript") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="投注时间">
                                    <ItemTemplate>
                                        <span><%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("regdate")) %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle VerticalAlign="Middle" />
                            <EmptyDataTemplate>
                                <div class="complete">
                                    <div class="complete-sub image"> <span><img src="/images/status/empty.png" alt=""></span> </div>
                                    <div class="complete-sub title">
                                        <h2>呃...没有投注记录!</h2>
                                    </div>
                                </div>
                            </EmptyDataTemplate>
                            </asp:GridView>    
                        </div>
                    </div>
                </div>
                <!--cont-base end-->


                </div>
        </div>
    </div>
</div>
</asp:Content>