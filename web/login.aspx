<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" MasterPageFile="~/MainMaster.master" %>
<%@ MasterType VirtualPath="~/MainMaster.master" %>

<asp:Content ContentPlaceHolderID="HeadContent" ID="headCont" runat="server">
    <asp:Label ID="ltlScript" runat="server"></asp:Label>
    <script type="text/javascript" language="javascript">
        $(function() {
            $("#txt_username").focus();
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyContent" ID="bodyCont" runat="server">
    <div id="content-wrap">
        <div class="main" id="content">
            <!--login start-->
            <div class="row sign-panel" id="sp-login">

                <!--logo start-->
                <div class="logo"> <span>K彩在线娱乐</span> </div>
                <!--logo end-->
                <!--tab-box start-->
                <div class="tab-box">

                    <!--tb-nav start-->
                    <ul class="tb-nav">
                        <li class="active"><a href="javascript:void(0);">会员登录</a></li>
                    </ul>
                    <!--tb-nav end-->
                    <!--guest-tip start-->
                    <div class="guest-tip">
                        <i>&nbsp;</i>
                        <span>有问题咨询在线客服？</span>
                        <a href="javascript:goLink('online');">点击此处</a>
                    </div>
                    <!--guest-tip end-->

                </div>
                <!--tab-box end-->
                <!--panel start-->
                <div class="row panel">
                    <div class="column b-35">

                        <!--form start-->
                        <div class="form-table">

                            <!--row start-->
                            <div class="form-row">
                                <input type="text" tabindex="1" id="txt_username" placeholder="用户名" class="signin-form-text" data-icon="sigin-user" />
                            </div>
                            <!--row end-->
                            <!--row start-->
                            <div class="form-row">
                                <input type="password" tabindex="2" placeholder="密码" id="txt_pwd" class="signin-form-text signin-login-password" data-icon="sigin-password" />
                                <a href="javascript:void(0);" title="忘记密码？点击找回" class="input-in-option" id="repassword-pop"><i>忘记密码？</i></a>
                                <a href="javascript:void(0);" title="显示密码" class="input-in-option" id="show-password-text"><i>显示密码</i></a>
                            </div>
                            <!--row end-->
                            <!--row start-->
                            <div class="form-row">
                                <input type="submit" tabindex="4" id="login-submit-button" class="signin-form-submit" data-type="submit" value="会员登录" />
                                <br />
                                <input type="submit" tabindex="5" id="join-submit-button" class="signin-form-submit" data-type="submit" value="会员注册" style="margin-top:4px;" />
                            </div>
                            <!--row end-->

                        </div>
                        <!--form end-->
                        <!--options start-->
                        <div class="login-options">
                            <span class="lo-mobile-token"><a href="javascript:alert('安全、公正、公平、合理，值得信赖！ 就是这么自信！');">彩界信誉第一平台</a></span>
                        </div>
                        <!--options end-->


                    </div>

                    <div class="column b-65">

                        <!--banner start-->
                        <div id="login-banner">
                            <img src="/uploads/slideshow/ns-008.jpg" alt="" />
                            <!--
                            <a href="http://appdownload.kcai111.com/" target="_blank"><img src="/uploads/slideshow/ns-00101.jpg" alt="" /></a>
                                -->
                        </div>
                        <!--banner end-->

                    </div>
                    <div class="clear"></div>
                </div>
                <!--panel end-->

            </div>
            <!--login end-->

        </div>
    </div>
    <!--content-wrap end-->
    <!--browser-mode-fixed start-->
    <div id="browser-mode-fixed">
        <ul class="bmf-browser">
            <li><a class="b-b-chrome" href="http://rj.baidu.com/soft/detail/14744.html?ald" title="快速、简单且安全的浏览器" target="_blank">google Chrome</a></li>
            <li><a class="b-b-firefox" href="http://rj.baidu.com/soft/detail/11843.html?ald" title="屡获大奖的开源浏览器" target="_blank">Mozilla Firefox</a></li>
            <li><a class="b-b-safari" href="http://rj.baidu.com/soft/detail/12966.html?ald" title="提供极致愉悦的网络体验方式" target="_blank">Apple safari</a></li>
            <li><a class="b-b-ie" href="http://rj.baidu.com/soft/detail/14917.html?ald" title="全面升级的IE浏览器" target="_blank">Internet Explorer 10</a></li>
        </ul>
        <p>为了获得更好的操作体验，建议使用Google Chrome、Firefox 或 IE10 浏览器，点击图标立即下载。</p>
    </div>
</asp:Content>