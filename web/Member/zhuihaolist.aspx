<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhuihaolist.aspx.cs" Inherits="Member_zhuihaolist" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script language="javascript" type="text/javascript" src="/js/betcommon1.js"></script>
<script type="text/javascript" language="javascript">
    gl.title = '追号记录 - K彩';
    $(document).ready(function() {
        init_memberTraceBetRecord("0");
        ChangeUserInfoMenuSelected('zhuihaolist');
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
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>游戏记录 > 追号记录</span> </div>
                    </div>
                    <div class="cont-body">

                        <!--operate start-->
                        <div class="module operate-bar operate-bar-hor data-table-option">
                            <ul>
                                <li>
                                    <label>起始日期:</label>
                                    <asp:TextBox ID="tbxStartDate" runat="server" CssClass="tpui-text kc-calendar startDateClass" size="8" data-icon-after="kc-calendar" Text=""></asp:TextBox>
                                    <span>-</span>
                                    <asp:TextBox ID="tbxEndDate" runat="server" CssClass="tpui-text kc-calendar endDateClass"  size="8" data-icon-after="kc-calendar" Text=""></asp:TextBox>
                                </li>
                                <li style="display:none;">
                                    <label>彩种:</label>
                                    <select class="tpui-select lotteryCodeClass" data-height="280">
                                                <option value="0" selected="selected">所有彩种</option>
                                                <option value="1">重庆时时彩</option>
                                                <option value="2">天津时时彩</option>
                                                <option value="9">KC五分彩</option>
                                                <option value="11">刮刮彩</option>
                                                <option value="14">新疆时时彩</option>
                                                <option value="20">KC分分彩</option>
                                                <option value="5">排列3</option>
                                                <option value="6">福彩3D</option>
                                                <option value="13">KC极速3D</option>
                                                <option value="3">吉林快3</option>
                                                <option value="4">江苏快3</option>
                                                <option value="12">KC快3</option>
                                                <option value="15">广西快3</option>
                                                <option value="16">安徽快3</option>
                                                <option value="17">湖北快3</option>
                                                <option value="25">刮刮快3</option>
                                                <option value="7">快乐扑克</option>
                                                <option value="26">刮刮扑克</option>
                                                <option value="8">PK10</option>
                                                <option value="10">山东11选5</option>
                                                <option value="21">广东11选5</option>
                                                <option value="22">江西11选5</option>
                                                <option value="23">上海11选5</option>
                                                <option value="24">黑龙江11选5</option>
                                    </select>
                                </li>
                                <li>
                                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="tpui-button GetDataByPageIndex" OnClick="btnSearch_Click" /> 
                                </li>
                            </ul>
                        </div>
                        <!--operate end-->
                        <!--table start-->
                        <div class="module table ta-center table-even-dark">
                            <asp:GridView ID="gvBetContent" runat="server" GridLines="None"
                                Width="100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="true" 
                                OnRowDataBound="gvContent_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="订单编号">
                                    <ItemTemplate>
                                        <a class="bl-order-id fc-red traceOrderClass" href="javascript:goLink('zhuihaodetail', '<%#Eval("id") %>');"><%#Eval("id") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="彩种">
                                    <ItemTemplate>
                                        <span><%#Lotterys[Convert.ToInt32(Eval("lottery"))].Name %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="追号第一期">
                                    <ItemTemplate>
                                        <span><%#Eval("startround")%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单金额">
                                    <ItemTemplate>
                                        <span class="fc-blue"><%#string.Format("{0:F2}", Convert.ToDouble(Eval("betmoney")))%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总期数">
                                    <HeaderStyle Width="82px" />
                                    <ItemTemplate>
                                        <%#Eval("totalstep")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中奖后停止">
                                    <ItemTemplate>
                                        <span class="fc-green">是</span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <HeaderStyle Width="60px" />
                                    <ItemTemplate>
                                        <span class="fc-yellow"><%# Convert.ToInt32(Eval("status")) == 1 ? "已完成" : "进行中"%></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="	追号时间">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                        <%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("regdate")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle VerticalAlign="Middle" />
                            <EmptyDataTemplate>
                                <div class="complete">
                                    <div class="complete-sub image"> <span><img src="/images/status/empty.png" alt=""></span> </div>
                                    <div class="complete-sub title">
                                        <h2>呃...没有追号记录!</h2>
                                    </div>
                                </div>
                            </EmptyDataTemplate>
                            </asp:GridView>    
                        </div>
                        <!--table end-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>