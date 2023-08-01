<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhuihaodetail.aspx.cs" Inherits="Member_zhuihaodetail" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script language="javascript" type="text/javascript" src="/js/betcommon1.js"></script>
<script type="text/javascript" language="javascript">
    gl.title = '追号明细记录 - K彩';
    $(document).ready(function() {
        gl.memberTraceOrderDetail = {};
        gl.memberTraceOrderDetail.curTraceOrderId = '800932';
        init_memberTraceBetRecordDetail();
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
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>追号明细记录</span> </div>
                    </div>
                    <div class="cont-body">

                        <!--tracr-viewer start-->
                        <div class="module" id="tracr-viewer">

                            <!--table start-->
                            <div class="table table-layout-fixed table-line-hor table-even-dark">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 96px;">追号编号：</td>
                                            <td><span class="fc-orgen"><asp:Literal ID="ltlID" runat="server" Text=""></asp:Literal></span></td>
                                            <td style="width: 96px;">追号时间：</td>
                                            <td><span class="fc-green"><asp:Literal ID="ltlRegDate" runat="server" Text=""></asp:Literal></span></td>
                                        </tr>
                                        <tr>
                                            <td>追号彩种：</td>
                                            <td><span class="fc-yellow"><asp:Literal ID="ltlLottery" runat="server" Text=""></asp:Literal></span></td>
                                            <td>追号金额：</td>
                                            <td><span class="fc-yellow"><asp:Literal ID="ltlBetMoney" runat="server" Text=""></asp:Literal></span></td>
                                        </tr>
                                        <tr>
                                            <td>取消金额：</td>
                                            <td><span class="fc-red">0</span></td>
                                            <td>总中奖金额：</td>
                                            <td><span class="fc-red"><asp:Literal ID="ltlWinMoney" runat="server" Text="0"></asp:Literal></span></td>
                                        </tr>
                                        <tr>
                                            <td>盈亏金额：</td>
                                            <td><span class="fc-red"><asp:Literal ID="ltlBenefitMoney" runat="server" Text=""></asp:Literal></span></td>
                                            <td>中奖后终止：</td>
                                            <td><span class="fc-green">是</span></td>
                                        </tr>
                                        <tr>
                                            <td>追号期数：</td>
                                            <td><span class="fc-blue"><asp:Literal ID="ltlTotalStep" runat="server" Text=""></asp:Literal></span></td>
                                            <td>完成期数：</td>
                                            <td><span class="fc-blue"><asp:Literal ID="ltlCurrentStep" runat="server" Text=""></asp:Literal></span></td>
                                        </tr>
                                        <tr>
                                            <td>取消期数：</td>
                                            <td><span class="fc-blue">0</span></td>
                                            <td>追号状态：</td>
                                            <td><span class="fc-green"><asp:Literal ID="ltlStatus" runat="server" Text=""></asp:Literal></span></td>
                                        </tr>
                                        <tr>
                                            <td>投注号码：</td>
                                            <td colspan="3">
                                                <!--trace-number-toggle start-->
                                                <dl class="trace-number-toggle" id="trace-number-toggle">
                                                    <dd>
                                                        <ul>

                                                                <li> <asp:Literal ID="ltlBetMode" runat="server" Text=""></asp:Literal></li>
                                                        </ul>
                                                    </dd>
                                                </dl>
                                                <!--trace-number-toggle end-->

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!--table end-->
                            <!--option start-->
                            <div class="operate-bar operate-bar-hor">
                                <ul>
                                    <li>
                                        <button id="stopTraceBtn" class="tpui-button" data-type="cancel" title="终止选中追号" style="display:none;">终止追号</button>
                                    </li>
                                    <li>
                                        <button id="refreshTraceDetail" class="tpui-button" title="刷新追号明细">刷新</button>
                                    </li>
                                    <li>
                                        <asp:Button ID="btnGoBack" runat="server" Text="返回" title="返回追号记录列表" CssClass="tpui-button" OnClientClick="javascript:goLink('zhuihaolist');return false;" />
                                    </li>
                                </ul>
                            </div>
                            <!--option end-->

                        </div>
                        <!--tracr-viewer end-->
                        <!--table start-->
                        <div class="module table ta-center table-even-dark">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width:30px;"><input id="traceCheckAllId" type="checkbox" class="tpui-checkbox" /></th>
                                        <th>奖期</th>
                                        <th>追号倍数</th>
                                        <th>追号状态</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltlBetDetail" runat="server" Text=""></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                        <!--table end-->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>