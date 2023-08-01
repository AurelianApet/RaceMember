<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftUseInfoMenu.ascx.cs" Inherits="Member_uc_LeftUseInfoMenu" %>
<div class="column b-15 sidebar">

    <!--user-card start-->
    <div id="user-card">
        <div class="image"><a href="javascript:goLink('myinfo');"><asp:Literal ID="ltlAvatar" runat="server" Text=""></asp:Literal></a></div>
    </div>
    <!--user-card end-->
    <!--user-menu start-->
    <div id="user-menu">
        <ul>
            <li class="parentMemberMenu">
                <a href="javascript:void(0);">我的账户</a>
                <ul>
                    <li class="memberinfo"><a href="javascript:goLink('myinfo');">个人资料</a></li>
                </ul>
            </li>
            <li class="parentMemberMenu">    
                <a href="javascript:void(0);">资金操作</a>
                <ul>
                    <li class="membershowcarddetail"><a href="javascript:goLink('carddetail');">银行卡信息</a></li>
                    <li class="memberrecharge"><a href="javascript:goLink('charge');">充值</a></li>
                    <li class="memberwithdraw"><a href="javascript:goLink('discharge');">提现</a></li>
                </ul>
            </li>
            <li class="parentMemberMenu">    
                <a href="javascript:void(0);">投注记录</a>
                <ul>
                    <li class="zhuihaolist"><a href="javascript:goLink('zhuihaolist');">追号记录</a></li>
                </ul>
            </li>
            <li class="parentMemberMenu">    
                <a href="javascript:void(0);">投注记录</a>
                <ul>
                    <li class="bethist"><a href="javascript:goLink('bethist');">彩票投注记录</a></li>
                </ul>
            </li>
        </ul>
    </div>
</div>
