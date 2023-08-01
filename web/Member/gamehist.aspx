<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gamehist.aspx.cs" Inherits="Member_gamehist" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('gamehist');
    });
</script>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="award_content">
        <div class="layout-base main-body cont drawing-cont">
            <div class="row">
                <div class="cont drawing-base">                    <!--table satrt-->
                    <div class="drawing-table">
                        <div class="table ta-center" id="drawing_tableAll">
                            <table>
                                <thead>
                                    <tr>
                                        <th style=" width: 96px;"><span>彩种</span></th>
                                        <th style=" width: 96px;"><span>期号</span></th>
                                        <th><span>开奖时间</span></th>
                                        <th style=" width: 288px;"><span>开奖号码</span></th>
                                        <th style=" width: 64px;"><span>热门玩法</span></th>
                                        <th><span>投注提示</span></th>
                                        <th style=" width: 64px;"><span>开奖详情</span></th>
                                        <th style=" width: 64px;"><span>走势</span></th>
                                        <th style=" width: 64px;"><span>购买</span></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td><span style="color:rgb(30, 80, 162);">极速赛车</span></td>
                                        <td><span><asp:Literal ID="ltlPk10Round" runat="server" Text=""></asp:Literal></span></td>
                                        <td><span><asp:Literal ID="ltlPk10Time" runat="server" Text=""></asp:Literal></span></td>
                                        <td>
                                            <div class="list-inline numbers number-circle">
                                                <ul>
                                                    <asp:Literal ID="ltlPk10Result" runat="server" Text=""></asp:Literal>
                                                </ul>
                                            </div>
                                        </td>
                                        <td><span>猜前三名</span></td>
                                        <td><span>边玩赛车边中奖</span></td>
                                        <td><a href="javascript:goLink('gamehist', 'pk10');">详情</a></td>
                                        <td><a href="javascript:goLink('chart', 'pk10', 'jiben');">走势</a></td>
                                        <td><a href="javascript:goLink('bet', 'pk10');">立即投注</a></td>
                                    </tr>
                                    <tr>
                                        <td><span style="color:rgb(30, 80, 162);">幸运梯子</span></td>
                                        <td><span><asp:Literal ID="ltlLadderRound" runat="server" Text=""></asp:Literal></span></td>
                                        <td><span><asp:Literal ID="ltlLadderTime" runat="server" Text=""></asp:Literal></span></td>
                                        <td>
                                            <div class="list-inline numbers number-rectangle">
                                                <ul>
                                                    <asp:Literal ID="ltlLadderResult" runat="server" Text=""></asp:Literal>
                                                </ul>
                                            </div>
                                        </td>
                                        <td><span>猜单双</span></td>
                                        <td><span>边玩幸运梯子边中奖</span></td>
                                        <td><a href="javascript:goLink('gamehist', 'lddr');">详情</a></td>
                                        <td><a href="javascript:goLink('chart', 'lddr', 'jiben');">走势</a></td>
                                        <td><a href="javascript:goLink('bet', 'lddr');">立即投注</a></td>
                                    </tr>                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!--table end-->                </div>            </div>        </div>    </div>
</div>
</asp:Content>