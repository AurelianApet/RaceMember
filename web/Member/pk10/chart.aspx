<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="Member_pk10_chart" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {    
    ChangeMenuImageSelected('chart');
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content" style="width: 980px;">
    <div class="row">
        <div class="layout-base main-body cont">
            <div class="chart-detial" id="chart-detial-layout">
                <div class="cd-head">
                    <div class="head">
                        <div class="image"><a href="javascript:goLink('chart', 'pk10', 'jiben');"><span class="ticket-icon t-s-64 ti-pk10"></span></a></div>
                        <div class="title"><a href="javascript:goLink('chart', 'pk10', 'jiben');">极速赛车</a></div>
                    </div>
                    <div class="content">
                        <dl>
                            <dt><span>基本分布:</span></dt>
                            <dd>
                                <a href="javascript:goLink('chart', 'pk10', 'jiben');" class="jiben">前三名基本走势</a>
                                <a class="zonghe">前三名综合走势</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt><span>定位走势:</span></dt>
                            <dd>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei1');" class="dingwei1">冠军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei2');" class="dingwei2">亚军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei3');" class="dingwei3">季军</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei4');" class="dingwei4">第四名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei5');" class="dingwei5">第五名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei6');" class="dingwei6">第六名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei7');" class="dingwei7">第七名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei8');" class="dingwei8">第八名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei9');" class="dingwei9">第九名</a>
                                <a href="javascript:goLink('chart', 'pk10', 'dingwei10');" class="dingwei10">第十名</a>
                            </dd>
                        </dl>
                    </div>
                </div>
                <div class="cd-main">
                    <div class="cd-m-body">
                        <div class="chart-table-config">
                            <div class="operate-bar operate-bar-hor ctc-table">
                                <ul>
                                    <li>
                                        <label>
                                            <input type="checkbox" class="tpui-checkbox" id="cross-toggle" /><h4>十字线</h4>
                                        </label>
                                    </li>
                                    <li>
                                        <label>
                                            <input type="checkbox" class="tpui-checkbox" id="line-toggle" /><h4>折线</h4>
                                        </label>
                                    </li>
                                    <li>
                                        <label>
                                            <input type="checkbox" class="tpui-checkbox" id="omission-toggle" /><h4>清除遗漏值</h4>
                                        </label>
                                    </li>
                                    <li>
                                        <label>
                                            <input type="checkbox" class="tpui-checkbox" id="layer-toggle" />
                                            <h4>遗漏分层</h4>
                                        </label>
                                    </li>
                                    <li>
                                        <label style="display:none" class="trend-processing">
                                            <h4>数据加载中 . . .</h4>
                                        </label>
                                    </li>
                                </ul>
                            </div>
                            <div class="operate-bar chart-tool-right">
                                <ul>
                                    <li> <a class="issue-selector-active" count="30" href="javascript:void(0);">最新30期 |</a> </li>
                                    <li> <a count="50" href="javascript:void(0);">最新50期 |</a> </li>
                                    <li> <a count="80" href="javascript:void(0);">最新80期 |</a> </li>
                                    <li> <a count="120" href="javascript:void(0);">最新120期 </a> </li>
                                </ul>
                            </div>
                            <div class="bh-refresh">
                                <a href="javascript:void(0);" id="refreshPage">
                                    <i>&nbsp;</i>刷新
                                </a>
                            </div>
                        </div>
                        <div class="table chart-table cd-table-head-fixd" style="width:965px;" id="chart-table-head-fixd"></div>
                        <div class="table chart-table cd-table" id="chart-table-base">
                            <div data-bind="visible:!showDatagrid()" style="text-align: center;">数据加载中...</div>
                            <table data-bind="visible:showDatagrid()" style="table-layout: auto;">
                                <thead>
                                    <tr>
                                        <th rowspan="2" data-bind="attr:{style:'width:'+issueWidth()+'px'}"><span>期号</span></th>
                                        <th rowspan="2" class="lc-split">&nbsp;</th>
                                        <th rowspan="2" data-bind="attr:{style:'width:'+bonusWidth()+'px'}">
                                            <span>
                                                开奖<br>
                                                号码
                                            </span>
                                        </th>
                                        <!--ko foreach:{data:targetAndStats,as:'o'}-->
                                        <th rowspan="2" class="lc-split">&nbsp;</th>
                                        <th data-bind="attr:{colspan:o.stats.length}"><span data-bind="html:o.target">万位</span></th>
                                        <!--/ko-->
                                    </tr>
                                    <tr>
                                        <!--ko foreach:{data:$root.targetAndStats,as:'o'}-->
                                        <!--ko foreach:{data:o.stats,as:'x'}-->
                                        <th><span data-bind="html:x.TargetStat"></span></th>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                </thead>
                                <!--ko foreach:{data:observableFlag(),as:'flag'}-->
                                <tbody data-bind="html:$root.buildTable()"></tbody>
                                <!--/ko-->
                            </table>
                            <div class="lc-layout lc-canvas">
                            </div>
                        </div>
                        <!--cd-table end-->
                        <!--extend start-->
                        <div class="chart-table-extend" data-bind="visible:showDatagrid()">                            <div class="cte-head">
                                <h2 class="title">数据分析</h2>
                                <div class="operate-bar operate-bar-hor operate-bar-dev">
                                    <input type="radio" name="cte-option" id="radio-history" data-bind="event:{change:switchTab}" checked />
                                    <h4>历史数据分析</h4>&nbsp;
                                    <input type="radio" name="cte-option" id="radio-this-page" data-bind="event:{change:switchTab}" />
                                    <h4>本页数据分析</h4>
                                </div>
                            </div>                            <div class="cte-body table chart-table">                                <table class="dataTable fixed" style="table-layout:auto;">
                                <thead>
                                    <tr>
                                        <th rowspan="2" style="width: 72px;"><strong>统计类型</strong></th>
                                        <!--ko foreach:{data:targetAndStats,as:'o'}-->
                                        <th rowspan="2" class="lc-split">&nbsp;</th>
                                        <th data-bind="attr:{colspan:o.stats.length}"><span data-bind="html:o.target">万位</span></th>
                                        <!--/ko-->
                                    </tr>
                                    <tr>
                                        <!--ko foreach:{data:$root.targetAndStats,as:'o'}-->
                                        <!--ko foreach:{data:o.stats,as:'x'}-->
                                        <th><span data-bind="html:x.TargetStat"></span></th>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                </thead>
                                <tfoot id="now_gross" style="display: table-footer-group;">
                                    <tr data-bind="visible:!isHistory()">
                                        <td>出现总次数</td>
                                        <!--ko foreach:pageStat().hit-->
                                        <!--ko if:$data==-1-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <!--ko ifnot:$data==-1-->
                                        <td data-bind="html:$data"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                    <tr class="even" data-bind="visible:!isHistory()">
                                        <td>平均遗漏值</td>
                                        <!--ko foreach:pageStat().avg-->
                                        <!--ko if:$data==-1-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <!--ko ifnot:$data==-1-->
                                        <td data-bind="html:$data"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                    <tr>
                                        <td>最大遗漏值</td>
                                        <!--ko ifnot:isHistory()-->
                                        <!--ko foreach:pageStat().maxMiss-->
                                        <!--ko if:$data==-1-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <!--ko ifnot:$data==-1-->
                                        <td data-bind="html:$data"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                        <!--/ko-->
                                        <!--ko if:isHistory()-->
                                        <!--ko foreach:{data:_dataList[_dataList.length-1],as:'bo'}-->
                                        <!--ko if:$root.isTargetSplit($index())-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <td data-bind="html:bo.MaxMiss"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                    <tr class="even">
                                        <td>最大连出值</td>
                                        <!--ko ifnot:isHistory()-->
                                        <!--ko foreach:pageStat().maxConti-->
                                        <!--ko if:$data==-1-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <!--ko ifnot:$data==-1-->
                                        <td data-bind="html:$data"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                        <!--/ko-->
                                        <!--ko if:isHistory()-->
                                        <!--ko foreach:{data:_dataList[_dataList.length-1],as:'bo'}-->
                                        <!--ko if:$root.isTargetSplit($index())-->
                                        <td class="lc-split">&nbsp;</td>
                                        <!--/ko-->
                                        <td data-bind="html:bo.MaxConti"></td>
                                        <!--/ko-->
                                        <!--/ko-->
                                    </tr>
                                </tfoot>
                            </table>                            </div>
                            <div class="cte-foot">
                                <dl id="chart-tips">
                                    <dt>参数说明</dt>
                                    <dd>
                                        <ul>
                                            <li>遗漏：自上期开出到本期间隔的期数。</li>
                                            <li>分隔线：每五期使用分隔线，使横向导航更加清晰。</li>
                                            <li>遗漏分层：将当前遗漏以柱状图标示出。<a href="javascript:void(0)" id="tip-show-all">＋显示全部</a></li>
                                        </ul>

                                    </dd>
                                </dl>
                            </div>                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:Literal ID="ltlScript" runat="server" Text=""></asp:Literal>
</asp:Content>