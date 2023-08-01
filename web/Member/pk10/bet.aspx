﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bet.aspx.cs" Inherits="Member_pk10_bet" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('bet');
    });
</script>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="row" id="ticket-base">
    <div class="main">
        <div class="tb-body">
            <div class="tb-b-column" id="ticket-cutdown">
                <div class="tb-sub">
                    <div class="sub tc-refer title">
                        <span>第<em id="curIssueNumberId"></em>期</span>
                        <span>距投注截止还有</span>
                    </div>
                    <div class="sub" id="cutdown-clock-base">
                        <ul id="timeContainerId">
                            <li class="cb-0"></li>
                            <li class="cb-0"></li>
                            <li class="cb-dot"><span>:</span></li>
                            <li class="cb-0"></li>
                            <li class="cb-0"></li>
                        </ul>
                        <div class="clear"></div>
                    </div>
                    <div class="sub" id="voice-toggle"> <a href="javascript:void(0);" title="声音：开"><em>&nbsp;</em></a> </div>
                    <div style="left: 10px; display: none;" id="cutdown-clock-fixed">
                        <h4><em>&nbsp;</em><span>投注截止</span></h4>
                        <ul>
                            <li><span id="leftTimeContainerId">00:00</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--column start-->
            <div class="tb-b-column" id="ticker-drawing-last" style="display:none;">

                <!--sub start-->
                <div class="tb-sub">

                    <!--title start-->
                    <div class="sub title">
                        <em>第<i id="preIssueNumberId"></i>期</em>
                        <a href="javascript:goLink('gamehist')">开奖号码</a>
                    </div>
                    <!--title end-->
                    <!--viewer start-->
                    <div class="sub viewer ticker-drawing-viewer ticker-drawing-viewer-base">
                        <div class="tdl-viewer-sub number tdl-vs-base tdl-vs-base-pks">
                    <ul></ul>
                        </div>
                    </div>
                    <!--viewer end-->
                    <!--option start-->
                    <div class="sub option">
                        <a href="javascript:goLink('chart');" class="tdl-o-chart" target="_blank">号码走势<i>&nbsp;</i></a>
                        <a href="javascript:goLink('ask');" class="tdl-o-remark" target="_blank">游戏说明<i>&nbsp;</i></a>
                    </div>
                    <!--option end-->

                </div>
                <!--sub end-->
            </div>
            <!--column start-->
        </div>
    </div>
</div>
<div class="main" id="content">
    <div class="betting-player">
        <iframe name="liveplayer" width="980px" height="630px" id="liveplayer" src="http://101.102.186.5:800/cargame/" frameborder="0" scrolling="no"></iframe> 
    </div>
    <div id="betting-type-nav">
        <ul>
            <li><span>常规</span></li>
            <li><a href="javascript:;">趣味</a></li>
        </ul>
    </div>
    <div class="row">
        <div class="row layout-base cont" id="betting-panel">
            <div class="column b-75 main-body">
                <div class="ticket-play-type">
                    <ul class="b-column b-column-6">
                            <li class="betTypeClass active" distinct="0" isfun="0" bettype="814" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>定位胆</span><em>奖金<br>￥<asp:Literal ID="ltlRatio14" runat="server" Text="19.4"></asp:Literal></em></a>
                                    <span class="tpt-tag">人气旺</span>
                            </li>
                            <li class="betTypeClass" distinct="1" isfun="0" bettype="801" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>猜冠军</span><em>奖金<br>￥<asp:Literal ID="ltlRatio1" runat="server" Text="19.4"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="2" isfun="0" bettype="802" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>猜冠亚军</span><em>奖金<br>￥<asp:Literal ID="ltlRatio2" runat="server" Text="174.6"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="3" isfun="0" bettype="803" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>猜前三名</span><em>奖金<br>￥<asp:Literal ID="ltlRatio3" runat="server" Text="1396.8"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="4" isfun="0" bettype="804" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>猜前四名</span><em>奖金<br>￥<asp:Literal ID="ltlRatio4" runat="server" Text="9777.6"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="5" isfun="0" bettype="805" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>猜前五名</span><em>奖金<br>￥<asp:Literal ID="ltlRatio5" runat="server" Text="58665.6"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="0" isfun="1" bettype="811" single="0" norepeat="0" style="display:none;">
                                <a href="javascript:void(0);"><span>前三和值</span><em>最高奖金<br>￥<asp:Literal ID="ltlRatio11" runat="server" Text="232.8"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="0" isfun="1" bettype="812" single="0" norepeat="0" style="display:none;">
                                <a href="javascript:void(0);"><span>自由双面</span><em>奖金<br>￥<asp:Literal ID="ltlRatio12" runat="server" Text="3.88"></asp:Literal></em></a>
                                    <span class="tpt-tag">易中奖</span>
                            </li>
                            <li class="betTypeClass" distinct="0" isfun="1" bettype="813" single="0" norepeat="0" style="display:none;">
                                <a href="javascript:void(0);"><span>猜名次</span><em>奖金<br>￥<asp:Literal ID="ltlRatio13" runat="server" Text="6.44"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="0" isfun="1" bettype="815" single="0" norepeat="0" style="display:none;">
                                <a href="javascript:void(0);"><span>猜前四名</span><em>奖金<br>￥<asp:Literal ID="ltlRatio15" runat="server" Text="4888.8"></asp:Literal></em></a>
                            </li>
                            <li class="betTypeClass" distinct="0" isfun="1" bettype="816" single="0" norepeat="0" style="display:none;">
                                <a href="javascript:void(0);"><span>猜前五名</span><em>奖金<br>￥<asp:Literal ID="ltlRatio16" runat="server" Text="19555.2"></asp:Literal></em></a>
                            </li>
                    </ul>
                    <div class="clear"></div>
                </div>
                <div class="betting-checker-panel">
                    <!--betting-checker-type start-->
                    <div>
                        <div class="bcp-type-base" style="display: block;">
                            <ul>
                                <li class="betRuleClass" isfun="0" bettype="801" betrule="8010101" style="display:none;">
                                    <a href="javascript:void(0);">猜冠军</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="802" betrule="8020101" style="display:none;">
                                    <a href="javascript:void(0);">猜冠亚军</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="802" betrule="8020201" style="display:none;">
                                    <a href="javascript:void(0);">猜冠亚军单式</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="803" betrule="8030101" style="display:none;">
                                    <a href="javascript:void(0);">猜前三名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="803" betrule="8030201" style="display:none;">
                                    <a href="javascript:void(0);">猜前三名单式</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="804" betrule="8040101" style="display:none;">
                                    <a href="javascript:void(0);">猜前四名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="804" betrule="8040201" style="display:none;">
                                    <a href="javascript:void(0);">猜前四名单式</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="805" betrule="8050101" style="display:none;">
                                    <a href="javascript:void(0);">猜前五名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="805" betrule="8050201" style="display:none;">
                                    <a href="javascript:void(0);">猜前五名单式</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="806" betrule="8060101" style="display:none;">
                                    <a href="javascript:void(0);">猜前六名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="807" betrule="8070101" style="display:none;">
                                    <a href="javascript:void(0);">猜前七名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="808" betrule="8080101" style="display:none;">
                                    <a href="javascript:void(0);">猜前八名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="809" betrule="8090101" style="display:none;">
                                    <a href="javascript:void(0);">猜前九名</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="810" betrule="8100101" style="display:none;">
                                    <a href="javascript:void(0);">猜前十名</a>
                                </li>
                                <li class="betRuleClass  active" isfun="0" bettype="814" betrule="8140101" style="display:inline-block;">
                                    <a href="javascript:void(0);">前五定位胆</a>
                                </li>
                                <li class="betRuleClass" isfun="0" bettype="814" betrule="8140102" style="display:inline-block;">
                                    <a href="javascript:void(0);">后五定位胆</a>
                                </li>
                                <li class="betRuleClass" isfun="1" bettype="811" betsubtype="81101" style="display:none;">
                                    <a href="javascript:void(0);">前三和值</a>
                                </li>
                                <li class="betRuleClass" isfun="1" bettype="812" betsubtype="81201" style="display:none;">
                                    <a href="javascript:void(0);">自由双面</a>
                                </li>
                                <li class="betRuleClass" isfun="1" bettype="813" betsubtype="81301" style="display:none;">
                                    <a href="javascript:void(0);">猜名次</a>
                                </li>
                                <li class="betRuleClass" isfun="1" bettype="815" betsubtype="81501" style="display:none;">
                                    <a href="javascript:void(0);">猜前四名</a>
                                </li>
                                <li class="betRuleClass" isfun="1" bettype="816" betsubtype="81601" style="display:none;">
                                    <a href="javascript:void(0);">猜前五名</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                    <!--betting-checker-type end-->
                    <!--betting-checker-base start-->
                    <div class="bcp-base">
                        <!--bcp-tips start-->
                        <div class="bcp-tips">
                            <div class="tips"> <span class="title">玩法提示：</span> <span id="betRuleTip">在任意位置选择任意数字进行投注，投注的数字和位置与开奖号码一致，即中奖。</span> </div>
                            <div class="demo">
                                <h4 title="投注示例"><a href="javascript:void(0);"><i>示例</i></a></h4>
                                <dl>
                                    <dt> <span>投注示例</span></dt>
                                    <dd id="betRuleTipExample" style="min-width: 210px;">选号：亚军8<br>开奖：- 8 - - -</dd>
                                </dl>
                            </div>
                        </div>
                        <!--bcp-tips end-->
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="1" style="display: block;">
                            <div class="title"><span>冠军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                            <div class="optimize showStatisticsClass option-large" miss-target="冠军走势" style=""></div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="2" style="display: block;">
                            <div class="title"><span>亚军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>        
                            <div class="optimize showStatisticsClass option-large" miss-target="亚军走势" style=""></div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="3" style="display: block;">
                            <div class="title"><span>季军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>        
                            <div class="optimize showStatisticsClass option-large" miss-target="季军走势" style=""></div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="4" style="display: block;">
                            <div class="title"><span>第四名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第四名走势" style=""></div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="5" style="display: block;">
                            <div class="title"><span>第五名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第五名走势" style=""></div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="6" style="display: none;">
                            <div class="title"><span>第六名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第六名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="7" style="display: none;">
                            <div class="title"><span>第七名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第七名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="8" style="display: none;">
                            <div class="title"><span>第八名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第八名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="9" style="display: none;">
                            <div class="title"><span>第九名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第九名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="10" style="display: none;">
                            <div class="title"><span>第十名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第十名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                         </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81501" style="display: none;">
                            <div class="title"><span>冠军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="冠军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81501" style="display: none;">
                            <div class="title"><span>亚军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="亚军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81501" style="display: none;">
                            <div class="title"><span>季军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="季军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81501" style="display: none;">
                            <div class="title"><span>第四名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第四名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81601" style="display: none;">
                            <div class="title"><span>冠军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="冠军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81601" style="display: none;">
                            <div class="title"><span>亚军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="亚军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81601" style="display: none;">
                            <div class="title"><span>季军：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="季军走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81601" style="display: none;">
                            <div class="title"><span>第四名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第四名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <!--betting-checker-sub start-->
                        <div class="bc-sub" panelindex="81601" style="display: none;">
                            <div class="title"><span>第五名：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option" id="option-buttons">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                                    
                            <div class="optimize showStatisticsClass option-large" miss-target="第五名走势">
                                <div style="text-align:center;display:none;" id="statinfo-loading">数据加载中...</div>
                            </div>
                        </div>
                        <div class="bc-sub" isfun="1" panelindex="81101" style="display: none;">
                            <div class="title"><span>和值通选：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-4 ball-rectangle">
                                        <li class="numBallClass" ruleid="8110101"><a href="javascript:void(0);"><span>大</span><em></em><em>¥<asp:Literal ID="ltlRatio11_1" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110102"><a href="javascript:void(0);"><span>小</span><em></em><em>¥<asp:Literal ID="ltlRatio11_2" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110103"><a href="javascript:void(0);"><span>单</span><em></em><em>¥<asp:Literal ID="ltlRatio11_3" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110104"><a href="javascript:void(0);"><span>双</span><em></em><em>¥<asp:Literal ID="ltlRatio11_4" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                </ul>
                            </div>
                            <div class="button">
                                <ul class="b-column b-column-7 ball-rectangle">
                                        <li class="numBallClass" ruleid="8110105"><a href="javascript:void(0);"><span>6</span><em>¥<asp:Literal ID="ltlRatio11_5" runat="server" Text="232.8"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110106"><a href="javascript:void(0);"><span>7</span><em>¥<asp:Literal ID="ltlRatio11_6" runat="server" Text="232.8"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110107"><a href="javascript:void(0);"><span>8</span><em>¥<asp:Literal ID="ltlRatio11_7" runat="server" Text="116.4"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110108"><a href="javascript:void(0);"><span>9</span><em>¥<asp:Literal ID="ltlRatio11_8" runat="server" Text="77.6"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110109"><a href="javascript:void(0);"><span>10</span><em>¥<asp:Literal ID="ltlRatio11_9" runat="server" Text="58.2"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110110"><a href="javascript:void(0);"><span>11</span><em>¥<asp:Literal ID="ltlRatio11_10" runat="server" Text="46.56"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110111"><a href="javascript:void(0);"><span>12</span><em>¥<asp:Literal ID="ltlRatio11_11" runat="server" Text="33.24"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110112"><a href="javascript:void(0);"><span>13</span><em>¥<asp:Literal ID="ltlRatio11_12" runat="server" Text="29.1"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110113"><a href="javascript:void(0);"><span>14</span><em>¥<asp:Literal ID="ltlRatio11_13" runat="server" Text="25.84"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110114"><a href="javascript:void(0);"><span>15</span><em>¥<asp:Literal ID="ltlRatio11_14" runat="server" Text="23.28"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110115"><a href="javascript:void(0);"><span>16</span><em>¥<asp:Literal ID="ltlRatio11_15" runat="server" Text="23.28"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110116"><a href="javascript:void(0);"><span>17</span><em>¥<asp:Literal ID="ltlRatio11_16" runat="server" Text="23.28"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110117"><a href="javascript:void(0);"><span>18</span><em>¥<asp:Literal ID="ltlRatio11_17" runat="server" Text="23.28"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110118"><a href="javascript:void(0);"><span>19</span><em>¥<asp:Literal ID="ltlRatio11_18" runat="server" Text="25.84"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110119"><a href="javascript:void(0);"><span>20</span><em>¥<asp:Literal ID="ltlRatio11_19" runat="server" Text="29.1"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110120"><a href="javascript:void(0);"><span>21</span><em>¥<asp:Literal ID="ltlRatio11_20" runat="server" Text="33.24"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110121"><a href="javascript:void(0);"><span>22</span><em>¥<asp:Literal ID="ltlRatio11_21" runat="server" Text="46.56"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110122"><a href="javascript:void(0);"><span>23</span><em>¥<asp:Literal ID="ltlRatio11_22" runat="server" Text="58.2"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110123"><a href="javascript:void(0);"><span>24</span><em>¥<asp:Literal ID="ltlRatio11_23" runat="server" Text="77.6"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110124"><a href="javascript:void(0);"><span>25</span><em>¥<asp:Literal ID="ltlRatio11_24" runat="server" Text="116.4"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110125"><a href="javascript:void(0);"><span>26</span><em>¥<asp:Literal ID="ltlRatio11_25" runat="server" Text="232.8"></asp:Literal></em></a></li>
                                        <li class="numBallClass" ruleid="8110126"><a href="javascript:void(0);"><span>27</span><em>¥<asp:Literal ID="ltlRatio11_26" runat="server" Text="232.8"></asp:Literal></em></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="bc-sub numPanelClass" panelindex="81201" style="display: none;">
                            <div class="title"><span>冠军：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-4 ball-rectangle">
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>大</span><em>6 - 10</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>小</span><em>1 - 5</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>单</span><em>1 3 5 7 9</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>双</span><em>2 4 6 8 10</em></a></li>
                                </ul>
                            </div>
                            <div class="optimize showStatisticsClass option-large" miss-target="冠军形态" style=""></div>
                        </div>
                        <div class="bc-sub numPanelClass" panelindex="81201" style="display: none;">
                            <div class="title"><span>亚军：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-4 ball-rectangle">
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>大</span><em>6 - 10</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>小</span><em>1 - 5</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>单</span><em>1 3 5 7 9</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>双</span><em>2 4 6 8 10</em></a></li>
                                </ul>
                            </div>
                            <div class="optimize showStatisticsClass option-large" miss-target="亚军形态" style=""></div>
                        </div>
                        <div class="bc-sub numPanelClass" panelindex="81201" style="display: none;">
                            <div class="title"><span>季军：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-4 ball-rectangle">
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>大</span><em>6 - 10</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>小</span><em>1 - 5</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>单</span><em>1 3 5 7 9</em></a></li>
                                    <li class="numBallClass" ruleid="8120101"><a href="javascript:void(0);"><span>双</span><em>2 4 6 8 10</em></a></li>
                                </ul>
                            </div>
                            <div class="optimize showStatisticsClass option-large" miss-target="季军形态" style=""></div>
                        </div>
                        <div class="bc-sub numPanelClass" panelindex="81301" style="display: none;">
                            <div class="title"><span>选择车辆：</span></div>
                            <div class="button option-large">
                                <ul class="b-column b-column-10 ball-round ball-round-minute">
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>01</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>02</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>03</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>04</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>05</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>06</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>07</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>08</span></a></li>
                                        <li class="numBallClass"><a href="javascript:void(0);"><span>09</span></a></li>
                                    <li class="numBallClass"><a href="javascript:void(0);"><span>10</span></a></li>
                                </ul>
                            </div>
                            <div class="option">
                                <ul>
                                    <li otype="all"><a href="javascript:void(0);">全</a></li>
                                    <li otype="big"><a href="javascript:void(0);">大</a></li>
                                    <li otype="small"><a href="javascript:void(0);">小</a></li>
                                    <li otype="single"><a href="javascript:void(0);">单</a></li>
                                    <li otype="double"><a href="javascript:void(0);">双</a></li>
                                    <li otype="clear"><a href="javascript:void(0);">清</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="bc-sub numPanelClass" panelindex="81301" style="display: none;">
                            <div class="title"><span>选择名次：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-3 ball-rectangle" id="n2n-panel">
                                        <li class="numBallClass notSelNum" ruleid="8130101"><a href="javascript:void(0);"><span>1至3</span><em>¥<asp:Literal ID="ltlRatio13_1" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                        <li class="numBallClass notSelNum" ruleid="8130102"><a href="javascript:void(0);"><span>4至6</span><em>¥<asp:Literal ID="ltlRatio13_2" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                        <li class="numBallClass notSelNum" ruleid="8130103"><a href="javascript:void(0);"><span>7至10</span><em>¥<asp:Literal ID="ltlRatio13_3" runat="server" Text="4.86"></asp:Literal></em></a></li>
                                        <li class="numBallClass notSelNum" ruleid="8130104"><a href="javascript:void(0);"><span>1至5</span><em>¥<asp:Literal ID="ltlRatio13_4" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                        <li class="numBallClass notSelNum" ruleid="8130105"><a href="javascript:void(0);"><span>6至10</span><em>¥<asp:Literal ID="ltlRatio13_5" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                </ul>
                            </div>
                        </div>

                        <!--optimize-control 遗漏checkbox面板 start-->
                        <div class="optimize-control">
                            <ul>
                                <li>
                                    <label>
                                        <div class="tp-ui-item tp-ui-forminput tp-ui-checkbox"><div class="tp-ui-sub tp-ui-checkbox-base"><input type="checkbox" class="oc-checkbox"></div><div class="tp-ui-sub tp-ui-handle-link tp-ui-checkbox-handle"><a href="javascript:void(0);"><em>&nbsp;</em></a></div></div>
                                        <h4>120期冷热</h4>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        <div class="tp-ui-item tp-ui-forminput tp-ui-checkbox"><div class="tp-ui-sub tp-ui-checkbox-base"><input type="checkbox" class="oc-checkbox"></div><div class="tp-ui-sub tp-ui-handle-link tp-ui-checkbox-handle"><a href="javascript:void(0);"><em>&nbsp;</em></a></div></div>
                                        <h4>当前遗漏</h4>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        <div class="tp-ui-item tp-ui-forminput tp-ui-checkbox"><div class="tp-ui-sub tp-ui-checkbox-base"><input type="checkbox" class="oc-checkbox"></div><div class="tp-ui-sub tp-ui-handle-link tp-ui-checkbox-handle"><a href="javascript:void(0);"><em>&nbsp;</em></a></div></div>
                                        <h4>最大遗漏</h4>
                                    </label>
                                </li>
                                <li>
                                    <label>
                                        <div class="tp-ui-item tp-ui-forminput tp-ui-checkbox"><div class="tp-ui-sub tp-ui-checkbox-base"><input type="checkbox" class="oc-checkbox"></div><div class="tp-ui-sub tp-ui-handle-link tp-ui-checkbox-handle"><a href="javascript:void(0);"><em>&nbsp;</em></a></div></div>
                                        <h4>上次遗漏</h4>
                                    </label>
                                </li>
                            </ul>
                        </div>
                        <!--optimize-control end-->
                    </div>

                    <!--betting-checker-base end-->
                    <!--单式输入框 betting-checker-clipboard start-->
                    <div class="bcp-clipboard numPanelClass" style="display: none;">
                        <!--explain start-->
                        <div class="explain">
                            <dl>
                                <dt><span>格式说明：</span></dt>
                                <dd></dd>
                            </dl>
                        </div>
                        <!--explain end-->
                        <!--inputbox start-->
                        <div class="inputbox">
                            <textarea id="singleNumberInput" placeholder="在此输入您的选号"></textarea>
                        </div>
                        <!--inputbox end-->
                    </div>
                    <!--betting-checker-clipboard end-->
                    <!--betting-checker-option start-->
                    <div class="bcp-option">
                        <!--statistic start-->
                        <div class="statistic"> <span>您选中了<em id="emBetNumber">0</em>注，共<em id="emBetAmount">0</em>元，若中奖，奖金<em id="emBetBonus">0</em>元，可盈利<em id="emBetProfit">0</em>元</span> </div>
                        <!--statistic end-->
                        <!--button start-->
                        <div class="button">
                            <!--mode start-->
                            <div class="mode" style="">
                                <ul id="priceModeId">
                                    <li class="active" pricemode="0">
                                        <label><input type="radio" name="mode" value="0"><span>元</span></label>
                                    </li>
                                    <li pricemode="1">
                                        <label><input type="radio" name="mode" value="1"><span>角</span></label>
                                    </li>
                                    <li pricemode="2">
                                        <label><input type="radio" name="mode" value="2"><span>分</span></label>
                                    </li>
                                </ul>
                            </div>
                            <!--mode end-->
                            <button id="addBettingNumberId" title="添加所选号码到号码列表" onclick="return false;"><i>确认选号</i></button>
                        </div>
                        <!--button end-->
                    </div>
                    <!--betting-checker-option end-->
                </div>
                <div class="betting-order-form">
                    <div class="bof-table" id="bof-table-base">
                        <div class="head">
                            <ul>
                                <li class="bof-th-mode"><span>玩法</span></li>
                                <li class="bof-th-number"><span>选号</span></li>
                                <li class="bof-th-count"><span>注数</span></li>
                                <li class="bof-th-multiple"><span>倍数</span></li>
                                <li class="bof-th-method"><span>模式</span></li>
                                <li class="bof-th-total-price"><span>总额(元)</span></li>
                                <li class="bof-th-option"><span>操作</span></li>
                            </ul>
                        </div>
                        <div class="body">
                            <ul id="selectNumsContainerId"></ul>
                        </div>
                    </div>
                    <div class="bof-operate">
                        <div class="bof-o-random">
                            <label>
                                <input id="randomSelNumInput" type="text" value="1" min="1" max="999" data-type="depart" class="random-selection myNumClass0" />
                                <h4>注</h4>
                            </label>
                            <button id="randomSelBtn" onclick="javascript:return false;"><span>机选</span></button>
                        </div>
                        <div class="bof-o-tools">
                            <ul>
                                <li>
                                    <a href="javascript:void(0);" title="把当前投注方案收藏到快捷投注，方便下次快速投注" id="shortcut-create-handle"> <em>&nbsp;</em> <span>收藏快捷投注</span> </a>
                                </li>
                                
                            </ul>
                        </div>
                        <div class="bof-o-button" id="clearBetItemsId"> <a href="javascript:void(0);"><span>清空列表</span></a> </div>
                    </div>
                    <div class="bof-count">
                        共选择了<span id="totalBetsId" class="bc-zs">0</span>注，<span id="totalTimesSpan">我要买 <input type="text" id="totalTimesInput" class="tpui-number" value="1" min="0" />倍，</span>共<span id="totalAmountId" class="bc-total">0.00</span>元
                    </div>
                </div>
                <!--betting-order-config start-->
                <div class="betting-order-config">
                    <!--config start-->
                    <div class="config" id="trace-number">
                        <div class="head">
                            <h2><span>购买方式:</span></h2>

                            <!--options start-->
                            <div class="tn-options">
                                <label>
                                    <input type="radio" value="0" class="tn-radio" name="order-config" checked />
                                    <h4>普通投注</h4>
                                </label>
                                <label>
                                    <input type="radio" value="1" class="tn-radio" name="order-config" />
                                    <h4>倍数追号</h4>
                                </label>
                                <label>
                                    <input type="radio" value="2" class="tn-radio" name="order-config" />
                                    <h4>高级追号</h4>
                                </label>
                            </div>
                            <!--options end-->
                            <!--submit start-->
                            <div class="submit">

                                <!--button start-->
                                <div class="button"> <a id="bettingBtn" href="javascript:void(0);" title="立即投注"><i>立即投注</i></a> </div>
                                <!--button end-->
                                <!--pact-checker start-->
                                <div class="pact-checker">
                                    <label>
                                        <input id="hadCheckedWeiTuoId" type="checkbox" class="tn-checkbox" checked />
                                        <h4><a href="/home/entrust" target="_blank">《投注协议》</a></h4>
                                    </label>
                                </div>
                                <!--pact-checker end-->

                            </div>
                            <!--submit end-->
                        </div>
                        <div class="body">
                            <!--sub start-->
                            <div class="config-sub trace-number" id="traceContainerId" style="display: none;">
                                <!-- trace-number-option start-->
                                <div class="trace-number-option">
                                    <!--form-table start-->
                                    <div class="form-table">
                                        <!--column satrt-->
                                        <div class="form-column">
                                            <h4>追号金额:</h4>
                                            <span><em id="traceMoneyId" class="fc-red">0.00</em></span>
                                        </div>
                                        <div class="form-column">
                                            <label>
                                                <input id="traceStopWhenBonusInput" type="checkbox" class="trace-switch" checked />
                                                <h4>中奖后停止追号</h4>
                                            </label>
                                        </div>
                                        <!--column end-->
                                        <!--倍数追号选项column satrt-->
                                        <div class="form-column" id="timesTraceOptionId">
                                            <h4>追号计划:</h4>
                                            <span>
                                                起始倍数
                                                <input id="traceInitInput" type="text" class="trace-text" value="1">
                                                <em>隔</em>
                                                <input id="traceSepInput" type="text" class="trace-text" value="1">
                                                <em>期 倍×</em>
                                                <input id="traceTimesInput" type="text" class="trace-text" value="2">
                                                <em>追号期数</em>
                                                <input id="traceIssuesInput" type="text" class="trace-text" value="5">
                                            </span>
                                        </div>
                                        <!--column end-->
                                        <br class="advanceTraceOption" />
                                        <!--高级追号选项  只差选项column satrt-->
                                        <div class="form-column advanceTraceOption" style="display: none;">
                                            <h4>追号计划:</h4>
                                            <span>
                                                起始倍数
                                                <input id="traceAdvanceInitInput" type="text" class="trace-text" value="1">
                                                <em> 追号期数</em>
                                                <input id="traceAdvanceIssueInput" type="text" class="trace-text" value="5">
                                            </span>
                                        </div>
                                        <!--column end-->
                                        <!--column satrt-->
                                        <div class="form-column advanceTraceOption">
                                            <h4>预期盈利:</h4>
                                            <div class="trace-build trace-profit" id="trace-profit">
                                                <label class="active" avalue="0">
                                                    <input type="radio" name="trace-radio-a" class="trace-radio" value="0" checked />
                                                    <h4>全程最低盈利率</h4>
                                                    <input id="traceLimitRateInput" type="text" class="trace-text" value="50">
                                                    <h4>&#37;</h4>
                                                </label>
                                                <label avalue="1">
                                                    <input type="radio" name="trace-radio-a" class="trace-radio" value="1" />
                                                    <h4>全程最低盈利金额</h4>
                                                    <input id="traceLimitAmountInput" type="text" class="trace-text" value="100">
                                                    <h4>元</h4>
                                                </label>
                                                <label avalue="2">
                                                    <input type="radio" name="trace-radio-a" class="trace-radio" value="2" />
                                                    <h4>我的全程金额不超过</h4>
                                                    <input id="myTraceTotalAmountInput" type="text" class="trace-text" value="100" />
                                                    <h4>元</h4>
                                                </label>
                                            </div>
                                        </div>
                                        <!--column end-->
                                    </div>
                                    <!--form-table end-->
                                    <!--tno-confirm start-->
                                    <div class="trace-number-confirm">
                                        <button title="生成追号方案" onclick="return false;"><i>生成追号方案</i></button>
                                    </div>
                                    <!--tno-confirm end-->

                                </div>
                                <!--trace-number-option end-->
                                <!--trace-number-table start-->
                                <div class="trace-number-table">
                                    <table class="table ta-center table-even-dark">
                                        <thead>
                                            <tr>
                                                <td style="width: 32px;">追号</td>
                                                <td>期次</td>
                                                <td>位数</td>
                                                <td style="width: 64px;">当前投入</td>
                                                <td class="timesTraceClass">投注截止时间</td>
                                                <td class="advanceTraceClass" style="width: 60px;">累计投入</td>
                                                <td class="advanceTraceClass" style="width: 60px;">盈利</td>
                                                <td class="advanceTraceClass" style="width: 64px;">盈利率</td>
                                            </tr>
                                        </thead>
                                        <tbody id="traceListTableId">
                                            <asp:Literal ID="ltlTraceList" runat="server" Text=""></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                                <!--trace-number-table end-->
                            </div>
                            <!--sub end-->
                        </div>
                    </div>
                    <!--config end-->
                </div>
                <!--betting-order-config end-->
            </div>
            <div class="column b-25 sidebar">
                <div class="row">
                    <div class="cont cont-betting">
                        <div class="cont-head">
                            <div class="title">
                                <h2><span>最新开奖</span><em>&nbsp;</em></h2>
                            </div>
                            <div class="side-handle">
                                <ul>
                                        <li><a class="sh-chart" href="javascript:goLink('chart', 'pk10', 'jiben');" target="_blank">走势图</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="cont-body">
                            <!--module start-->
                            <div class="module" id="drawing-lite">
                                <table>
                                    <thead>
                                        <tr>
                                            <th class="dl-period"><span>期号</span></th>
                                            <th class="dl-number"><span>开奖号码</span></th>
                                            


                                        </tr>
                                    </thead>
                                    <tbody data-bind="foreach:{data:dataList(),as:'o'}">
                                        <tr>
                                            <td><span title="" data-bind="attr:{title:'第'+o.IssueNumber+'期'},html:o.IssueNumber"></span></td>
                                                <td data-bind="attr:{title:o.BonusNumber}">
                                                    <span data-bind="foreach:{data:o.BonusNumberX,as:'x'}">
                                                        <em data-bind="html:x"></em>
                                                    </span>
                                                </td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!--module end-->
                        </div>
                    </div>
                </div>
                <!--cont start-->
                <div class="row">
                    <div class="cont cont-betting">
                        <div class="cont-head">
                            <div class="title">
                                <h2><span>我的最近追号</span><em>&nbsp;</em></h2>
                            </div>
                            <div class="refresh trace-keeper-refresh" id="refreshRightTraceId"> <a href="javascript:void(0);"><i>&nbsp;</i>刷新</a> </div>
                            <div class="cb-toggle"><a href="javascript:void(0);" title="收起栏目"><i>收起</i></a></div>
                        </div>
                        <div class="cont-body">
                            
                            <asp:Literal ID="ltlRightTraceList" runat="server" Text=""></asp:Literal>
                        </div>
                    </div>
                </div>
                <!--cont end-->
                <!--cont start-->
                <div class="row">
                    <div class="cont cont-betting">
                        <div class="cont-head">
                            <div class="title">
                                <h2><span title="当前彩种的快捷投注方案">我的快捷投注</span><em>&nbsp;</em></h2>
                            </div>
                            <div class="cb-toggle"><a href="javascript:void(0);" title="收起栏目"><i>收起</i></a></div>
                        </div>
                        <div class="cont-body">
                            <!--shortcut-list start-->
                            <div class="module ta-center shortcut-list" id="shortcut-base" style="display:none;">
                                <ul>
                                    <li>
                                        <div class="base sl-head">
                                            <span class="title">标题</span>
                                            <span class="score">投注总额</span>
                                        </div>
                                    </li>
                                    <!--ko foreach:{data:favListObservable(),as:'o'}-->
                                    <li>
                                        <div class="base">
                                            <a class="o-betting" data-bind="attr:{'favId':o.Id},click:$root.importOkClick" href="javascript:void(0);" title="添加到投注">投注</a>
                                            <span class="ta-left title" data-bind="html:o.FavName">数据加载中...</span>
                                            <span class="ta-right score"><em data-bind="html:'&yen;'+o.FavTotalPrice.toFixedNum(3)">1.00</em>元</span>
                                            <a class="o-delete" data-bind="attr:{'favId':o.Id},click:$root.delFav,html:'删除'" href="javascript:void(0);" title="删除">删除</a>
                                        </div>
                                    </li>
                                    <!--/ko -->
                                </ul>
                            </div>            
                            <!--shortcut-list end-->                            <!--complete start-->
                            <div class="complete">
                                <!--image start-->
                                <div class="complete-sub image"> <span><img src="/images/status/empty-flat.png" alt=""></span> </div>
                                <!--image end-->
                                <!--title start-->
                                <div class="complete-sub title">
                                        <h4>暂无快捷投注</h4>
                                </div>
                                <!--title end-->
                            </div>
                            <!--complete end-->
                        </div>
                    </div>
                </div>
                <!--cont end-->
                <!--keeper-create start-->
                <div class="keeper-dialog" id="keeper-create" title="添加到收藏" style="display:none;">
                    <div class="forms-table">

                        <!--form-row start-->
                        <div class="row form-row new-keeper-row">
                            <div class="form-input">
                                <label>
                                    <input type="radio" class="tpui-radio" name="keeper-mode" value="new" checked />
                                    新建收藏
                                </label>
                            </div>
                            <div class="form-input">
                                <input type="text" class="tpui-text" value="新建收藏" id="add-fav-name" />
                            </div>
                        </div>
                        <!--form-row end-->
                        <!--form-row start-->
                        <div class="row form-row">
                            <div class="form-input">
                                <label>
                                    <input type="radio" class="tpui-radio" name="keeper-mode" value="cover" />
                                    追加到现有收藏
                                </label>
                            </div>
                        </div>
                        <!--form-row end-->
                        <!--keeper-list start-->
                        <div class="keeper-list table ta-center table-even-dark" id="keeper-list-base" style="display:none;">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width: 32px; "><span>-</span></th>
                                        <th><span>标题</span></th>
                                        <th style="width: 64px; "><span>金额</span></th>
                                        <th><span>日期</span></th>
                                        <th style="width: 32px; "><span>操作</span></th>
                                    </tr>
                                </thead>
                                <tbody data-bind="foreach:{data:favListObservable(),as:'o'}">
                                    <tr>
                                        <td><input type="radio" name="keeper-item" data-bind="attr:{'favId':o.Id}" /></td>
                                        <td data-bind="html:o.FavName">新建收藏 001</td>
                                        <td><span data-bind="html:'&yen;'+o.FavTotalPrice"> 220 元</span></td>
                                        <td><span data-bind="html:o.CreateTimeISO">2014-12-11</span></td>
                                        <td><a data-bind="attr:{'favId':o.Id},click:$root.delFav" href="javascript:void(0);">删除</a></td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                        <!--keeper-list end-->
                        <!--form-row start-->
                        <div class="row form-row">
                            <div class="form-input">
                                <input type="reset" data-type="cancel" class="tpui-button" id="fav-add-cancel" value="取消" />
                                <input type="button" data-type="submit" class="tpui-button" id="fav-add-submit" value="添加" />
                            </div>
                        </div>
                        <!--form-row end-->

                    </div>
                </div>
                <!--keeper-create end-->
            </div>
        </div>
    </div>
    <div class="row">
        <div class="layout-base cont cont-full" id="betting-history">
            <div class="cont-head">
                <div class="title"><h2><a href="javascript:goLink('bethist');"><span>投注记录</span><em>&nbsp;</em></a></h2></div>
                <div class="bh-refresh" id="refreshBettingHistory"> <a href="javascript:void(0);"><i>&nbsp;</i>刷新</a> </div>
                <div class="more"><a href="#memberbetrecord" title="查看更多"><em>更多</em></a></div>
            </div>
            <div class="cont-body">
                <div class="module">
                    <div class="table ta-center">
                        <table>
                            <thead>
                                <tr>
                                    <th style="width:92px"><span>订单编号</span></th>
                                    <th style="width:76px"><span>彩种</span></th>
                                    <th><span>期号</span></th>
                                    <th><span>玩法</span></th>
                                    <th style="width:82px"><span>总赔率</span></th>
                                    <th><span>选号</span></th>
                                    <th style="width:60px"><span>投注金额</span></th>
                                    <th style="width:60px"><span>盈亏金额</span></th>
                                    <th><span>说明</span></th>
                                    <th><span>投注时间</span></th>
                                </tr>
                            </thead>
                            <tbody id="recentContainerId"></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        init_betComm(gl.lotteryId);
    });
</script>
</asp:Content>