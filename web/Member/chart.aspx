<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="Member_chart" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('chart');
    });
</script>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row">
        <div class="layout-base main-body cont">
            <!--chart-list start-->
            <div class="chart-list">
                <!--item start-->
                <div class='ci-item'>
                    <div class="head">
                        <div class="image"><a href="javascript:goLink('chart', 'pk10', 'jiben');"><span class="ticket-icon t-s-64 ti-pk10"> </span></a></div>
                        <div class="title"><a href="javascript:goLink('chart', 'pk10', 'jiben');">极速赛车</a></div>
                    </div>
                    <div class="content">
                        <!--chart-menu-item start-->
                        <dl>
                            <dt><span>基本分布:</span></dt>
                            <dd> <a href="javascript:goLink('chart', 'pk10', 'jiben');">前三名基本走势</a></dd>
                        </dl>
                        <!--chart-menu-item end-->
                        <!--chart-menu-item start-->
                        <dl>
                            <dt><span>定位走势:</span></dt>
                            <dd>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei1');">冠军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei2');">亚军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei3');">季军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei4');">第四名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei5');">第五名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei6');">第六名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei7');">第七名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei8');">第八名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei9');">第九名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei10');">第十名</a>
                            </dd>
                        </dl>
                        <!--chart-menu-item end-->

                    </div>
                </div>
                <!--item end-->
            </div>
            <!--chart-list end-->
            <!--chart-list start-->
            <div class="chart-list">
                <!--item start-->
                <div class='ci-item'>
                    <div class="head">
                        <div class="image"><a href="javascript:goLink('chart', 'lddr', 'jiben');"><span class="ticket-icon t-s-64 ti-lddr"> </span></a></div>
                        <div class="title"><a href="javascript:goLink('chart', 'lddr', 'jiben');">幸运梯子</a></div>
                    </div>
                    <div class="content">
                        <!--chart-menu-item start-->
                        <dl>
                            <dt><span>基本分布:</span></dt>
                            <dd> <a href="javascript:goLink('chart', 'lddr', 'jiben');">结果走势</a></dd>
                        </dl>
                        <!--chart-menu-item end-->
                        <!--chart-menu-item start-->
                        <dl>
                            <dt><span>定位走势:</span></dt>
                            <dd>
                                <a href="javascript:goLink('chart', 'lddr', 'startpos');">左右</a>
                                <a href="javascript:goLink('chart', 'lddr', 'laddercount');">34</a>
                                <a href="javascript:goLink('chart', 'lddr', 'oddeven');">单双</a>
                            </dd>
                        </dl>
                        <!--chart-menu-item end-->

                    </div>
                </div>
                <!--item end-->
            </div>
            <!--chart-list end-->
        </div>
    </div>
</div>
</asp:Content>