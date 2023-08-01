<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bet.aspx.cs" Inherits="Member_lddr_bet" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('lottery');
        init_betComm(gl.lotteryId);
    });
</script>
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
        </div>
    </div>
</div>
<div class="main" id="content">
    <div class="betting-player" style="margin-left:75px;">
        <iframe name="liveplayer" width="830px" height="632px" id="liveplayer" src="http://101.102.186.7/lddr/ladder.aspx" frameborder="0" scrolling="no"></iframe> 
    </div>
    <div class="row">
        <div class="row layout-base cont" id="betting-panel">
            <div class="column b-75 main-body">
                <div class="ticket-play-type">
                    <ul class="b-column b-column-0">
                            <li class="betTypeClass active" distinct="0" bettype="250101" single="0" norepeat="0" style="display:inline-block;">
                                <a href="javascript:void(0);"><span>幸运梯子</span><em>奖金<br>￥<asp:Literal ID="ltlRatio25_one" runat="server" Text="19.4"></asp:Literal></em></a>
                            </li>
                    </ul>
                    <div class="clear"></div>
                </div>
                <div class="betting-checker-panel">
                    <!--betting-checker-type start-->
                    <div>
                        <div class="bcp-type-base" style="display: block;">
                            <ul>
                                <li class="betRuleClass" isfun="1" bettype="250101" betsubtype="250101" style="display:none;">
                                    <a href="javascript:void(0);">猜幸运梯子</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!--betting-checker-type end-->
                    <!--betting-checker-base start-->
                    <div class="bcp-base">
                        <div class="bc-sub numPanelClass" panelindex="250101">
                            <div class="title"><span>选择：</span></div>
                            <div class="button">
                                <ul class="b-column b-column-2 ball-rectangle">
                                    <li class="numBallClass notSelNum" ruleid="25010105"><a href="javascript:void(0);"><span>单</span><em>¥<asp:Literal ID="ltlRatio25_5" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25010106"><a href="javascript:void(0);"><span>双</span><em>¥<asp:Literal ID="ltlRatio25_6" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                </ul>
                                <ul class="b-column b-column-4 ball-rectangle">
                                    <li class="numBallClass notSelNum" ruleid="25010101"><a href="javascript:void(0);"><span>左</span><em>¥<asp:Literal ID="ltlRatio25_1" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25010102"><a href="javascript:void(0);"><span>右</span><em>¥<asp:Literal ID="ltlRatio25_2" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25010103"><a href="javascript:void(0);"><span>3</span><em>¥<asp:Literal ID="ltlRatio25_3" runat="server" Text="4.86"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25010104"><a href="javascript:void(0);"><span>4</span><em>¥<asp:Literal ID="ltlRatio25_4" runat="server" Text="3.88"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25020101"><a href="javascript:void(0);"><span>3 单</span><em>¥<asp:Literal ID="ltlRatio25_7" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25020102"><a href="javascript:void(0);"><span>3 双</span><em>¥<asp:Literal ID="ltlRatio25_8" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25020103"><a href="javascript:void(0);"><span>4 单</span><em>¥<asp:Literal ID="ltlRatio25_9" runat="server" Text="6.44"></asp:Literal></em></a></li>
                                    <li class="numBallClass notSelNum" ruleid="25020104"><a href="javascript:void(0);"><span>4 双</span><em>¥<asp:Literal ID="ltlRatio25_10" runat="server" Text="6.44"></asp:Literal></em></a></li>
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
                                        <li><a class="sh-chart" href="javascript:goLink('chart', 'lddr', 'jiben');" target="_blank">走势图</a></li>
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
                                                        <em data-bind="html:x,attr:{class:'lddr-'+x}"></em>
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
</asp:Content>