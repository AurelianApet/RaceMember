<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gamehist.aspx.cs" Inherits="Member_lddr_gamehist" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('gamehist');
    });
    function SearchDate(obj) {
        goLink('gamehist', 'lddr', "date-" + $(obj).val());
    }
</script>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <!--main-body start-->
    <div class="row" id="award_content">
        <div class="layout-base main-body cont drawing-cont">

            <!--cont start-->
            <div class="row" id="dc-ssc" style="min-height: 450px;">
                <div class="cont drawing-base">
                    <!--head satrt-->
                    <div class="drawing-head">
                        <div class="image">
                            <a class="ticket-icon t-s-32 ti-lddr" href="javascript:goLink('bet', 'lddr');"></a>
                        </div>
                        <div class="info" style="width:134px;">
                            <h2><a href="javascript:goLink('bet', 'lddr');">幸运梯子</a></h2>
                            <h4><span>5分钟一期 娱乐不打烊</span></h4>
                        </div>

                        <!--db-checker start-->
                        <div class="db-checker">
                            
                        </div>
                        <!--db-checker end-->
                        <!--db-config start-->
                        <div class="db-config">
                            <ul>
                                <li id="liToday" runat="server" class="AwardDiff" daydiff="0"><a href="javascript:goLink('gamehist', 'lddr', '0')">今天</a></li>
                                <li id="liYesterday" runat="server" class="AwardDiff" daydiff="-1"><a href="javascript:goLink('gamehist', 'lddr', '-1')">昨天</a></li>
                                <li id="li2DaysAgo" runat="server" class="AwardDiff" daydiff="-2"><a href="javascript:goLink('gamehist', 'lddr', '-2')">前天</a></li>
                                <li>
                                    <label>按日期：</label>
                                    <input runat="server" type="text" class="tpui-text kc-calendar" data-icon-after="kc-calendar" id="dateSelect" value="2016-07-30" onchange="javascript:SearchDate(this);" />
                                </li>
                            </ul>
                        </div>
                        <!--db-config end-->

                    </div>
                    <!--head end-->
                    <!--table satrt-->
                    <div class="drawing-table" >
                        <!--table start-->
                        <div class="table ta-center" id="drawing_tableDetail">
                            <asp:GridView ID="gvContent" runat="server" GridLines="None"
                                Width="100%"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="true" 
                                OnPageIndexChanging="gvContent_PageIndexChange"
                                OnRowDataBound="gvContent_RowDataBound">
                            <AlternatingRowStyle CssClass="odd" />
                            <Columns>
                                <asp:TemplateField HeaderText="期号">
                                    <HeaderStyle CssClass="dl-period"/>
                                    <ItemTemplate>
                                        <span title="第 <%#Eval("round") %> 期"></span><%#Eval("round") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开奖号码">
                                    <HeaderStyle CssClass="dl-number" />
                                    <ItemTemplate>
                                        <div class="list-inline numbers number-rectangle">
                                            <ul>
                                                <li><span class='<%#Convert.ToInt32(Eval("startpos")) == 1 ? "blue" : "" %>'><%#Convert.ToInt32(Eval("startpos")) == 1 ? "左" : "右" %></span></li>
                                                <li><span class='<%#Convert.ToInt32(Eval("laddercount")) == 1 ? "blue" : "" %>'><%#Convert.ToInt32(Eval("laddercount")) == 1 ? "3" : "4" %></span></li>
                                                <li><span class='<%#Convert.ToInt32(Eval("oddeven")) == 1 ? "blue" : "" %>'><%#Convert.ToInt32(Eval("oddeven")) == 1 ? "单" : "双" %></span></li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle VerticalAlign="Middle" />
                            <EmptyDataTemplate>
                                <table class="clstableborder" width="100%">
                                <tr>
                                    <td class="clsemptyrow">
                                        <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:Str, STR_NODATA %>"></asp:Literal>
                                    </td>
                                </tr>
                                </table>
                            </EmptyDataTemplate>
                            <PagerSettings Mode="Numeric" Position="Bottom"
                                FirstPageText="<%$Resources:Str, STR_FIRST %>"
                                PreviousPageText="<%$Resources:Str, STR_PREV %>"
                                NextPageText="<%$Resources:Str, STR_NEXT %>"
                                LastPageText="&nbsp;<%$Resources:Str, STR_LAST %>"
                                PageButtonCount="10" />
                            <PagerStyle CssClass="clspager" HorizontalAlign="Center" />
                            </asp:GridView>                        </div>
                        <!--table end-->
                    </div>
                    <!--table end-->

                </div>
            </div>
            <!--cont end-->
        </div>
    </div>
</div>
</asp:Content>