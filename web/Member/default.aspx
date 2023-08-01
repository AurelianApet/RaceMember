﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Member_default" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(function() {
        ChangeMenuImageSelected('home');
        gl.title = "首页 - K彩";
        gl.FileServerUrl = "";
        delete gl.hall;
        gl.hall = new Hall();
        gl.hall.init();
    });
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
<!--section start-->
<div class="row section-base">
    <div class="column b-75">
        <div class="layout-base cont">
            <div class="slideshow slideshow-kc" id="slideshow">
                <div class="slideshow-content">
                    <ul>
                        <li><img src="/uploads/slideshow/ns-008.jpg" alt="" /></li>
                        
                        <li ><a href="http://appdownload.kcai111.com/" target="_blank"><img style="cursor: pointer;" src="/uploads/slideshow/ns-007.jpg" alt="" /></a></li>
                        <li><img src="/uploads/slideshow/ns-001.jpg" alt="" /></li>
                        
                        
                    </ul>
                </div>
                <div class="slideshow-page"></div>
                <div class="slideshow-option so-prev"><a href="javascript:void(0);">上翻</a></div>
                <div class="slideshow-option so-next"><a href="javascript:void(0);">下翻</a></div>
            </div>
        </div>
    </div>
    <!--slideshow end-->
    <div class="column b-25">
        <div class="layout-base cont" id="notice">
            <div class="cont-head">
                <div class="title"> <span>公告通知</span><i>&nbsp;</i> </div>
                <div class="more" id="notice-more"><a href="javascript:void(0);">更多</a></div>
            </div>
            <div class="cont-body">
                <!--notice-list start-->
                <div class="notice-list">
                    <ul>
                </div>
                <!--notice-list end-->

            </div>
        </div>
    </div>
    <!--notice end-->
    <div class="clear"></div>
</div>
<!--section end-->
<!--section start-->
<div class="row section-base">
    <div class="column b-0">
        <div class="layout-base cont cont-full" style="background:white">
            <div class="cont-body">

                <div class="row lottery-dragbel">

                    <div class="column ld-topic" id="ld-topic">
                        <ul>
                            <asp:Literal ID="ltlMainLottery" runat="server" Text=""></asp:Literal>
                        </ul>
                    </div>
                    <!--ld-topic end-->
                    <!--ld-base start-->
                    <div class="column ld-base" id="ld-base">
                        <ul>
                                    <span class="image">
                                        <i class="ticket-icon t-s-96 ti-<%#Eval("nick") %>"><%#Eval("title") %></i>
                                    </span>
                                    <span class="opeart">
                                        <a class="ldb-betting" href="javascript:goLink('bet', '<%#Eval("nick") %>');">立即投注</a>
                                        <a class="ldb-option lo-topic" href="javascript:void(0);">
                                            <i>&nbsp;</i>
                                            <em>置顶</em>
                                        </a>
                                        <a class="ldb-option lo-replace" href="javascript:void(0);">
                                            <i>&nbsp;</i>
                                            <em>替换</em>
                                        </a>
                                    </span>
                                </li>
                    </div>
                    <!--ld-base end-->
                    <div class="clear"></div>
                </div>
                <!--lottery-dragbel end-->
                <div id="lottery-more" title="更多彩种"><a href="javascript:goLink('lottery');"><i>更多彩种</i></a></div>
                <!--lottery-more end-->
                <div class="ld-checker" id="ld-checker">
                    <ul>
                                <div title="<%#Eval("title") %>" class="image">
                                    <span class="ticket-icon t-s-64 ti-<%#Eval("nick") %>"> </span>
                                    
                                </div>
                                <div class="title"><span><%#Eval("title") %></span></div>
                            </li>
                    <a id="lc-close" title="关闭彩种替换">关闭</a>
                </div>
                <!--ld-checker end-->

            </div>
        </div>
        <!--cont end-->

    </div>
    <div class="clear"></div>
</div>
<!--section end-->
</asp:Content>