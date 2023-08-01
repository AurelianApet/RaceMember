<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lotterys.aspx.cs" Inherits="Member_lotterys" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(function() {
        ChangeMenuImageSelected('lottery');
        gl.title = '购彩大厅 - K彩';
        $(function() {
            // 彩种热门滚动
            $('#lottery-topic .lottery-list:first').tpuiMarquee({
                stepInt: 2, // 移动2个格
                autoPlay: false, // 不自动播放
                optionToggle: false // 不自动隐藏翻动按钮
            });
        });
    });
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
<!--main-body start-->
<!--lottery-topic-cont start-->
<div class="row" style="display:none;">
    <div class="layout-base cont">
        <!--lottery-topic start-->
        <div id="lottery-topic">
            <div class="lottery-list">                <asp:Repeater runat="server" ID="rptLotteryTopic">                <ItemTemplate>                    <div class="column">
                        <div class="item">
                            <div class="lti-sub">
                                <div class="image">
                                    <a class="ticket-icon t-s-96 ti-<%# Eval("nick") %>" href="#<%# Eval("nick") %>"><%# Eval("title") %></a>
                                </div>
                                <div class="title">
                                    <h2><a href="javascript:goLink('bet', '<%#Eval("nick") %>');"><%# Eval("title") %></a></h2>
                                    <h4><span><%# Eval("desc") %></span></h4>
                                </div>
                                <div class="option">
                                    <a href="javascript:goLink('chart', '<%# Eval("nick") %>', 'jiben');">走势图</a>
                                    <a href="javascript:goLink('bet', '<%#Eval("nick") %>');">立即投注</a>
                                </div>
                            </div>
                        </div>
                    </div>                </ItemTemplate>                </asp:Repeater>            </div>
        </div>
        <!--lottery-topic end-->
    </div>
</div>
<!--lottery-topic-cont end-->
<!--lottery-category start-->
<div class="row">
    <div class="layout-base cont">
        <div class="cont-head">
            <div class="title">
                <h2><span>全部彩种</span><em>&nbsp;</em></h2>
            </div>
            
        </div>
        <div class="cont-body">

            <!--lottery-list start-->
            <div class="lottery-list">
                <ul>                    <asp:Repeater runat="server" ID="rptLotteryList" >
                    <ItemTemplate>
				        <li>
                            <!--item start-->
                            <div class="item">
                                <div class="lti-sub">
                                    <div class="image">
                                        <a class="ticket-icon t-s-96 ti-<%# Eval("nick") %>" href="#<%# Eval("nick") %>"><%# Eval("title") %></a>
                                    </div>
                                    <div class="title">
                                        <h2><a href="javascript:goLink('bet', '<%#Eval("nick") %>');"><%# Eval("title") %></a></h2>
                                        <h4><span><%# Eval("desc") %></span></h4>
                                    </div>
                                    <div class="option">
                                        <a href="javascript:goLink('chart', '<%# Eval("nick") %>', 'jiben');">走势图</a>
                                        <a href="javascript:goLink('bet', '<%#Eval("nick") %>');">立即投注</a>
                                    </div>
                                </div>
                            </div>
                            <!--item end-->
                        </li>
                    </ItemTemplate>                    </asp:Repeater>	                </ul>
                <div class="clear"></div>
            </div>
            <!--lottery-list end-->

        </div>
    </div>
</div>
<!--lottery-category end-->
<!--main-body end--></div></asp:Content>