<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpPk10.aspx.cs" Inherits="Member_help_helpPk10" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftRuleMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
$(document).ready(function() {    
    ChangeMenuImageSelected('help');
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content" style="width: 980px;">
    <div class="row">
        <ucLeftfix:ucLeft runat="server" ID="usLeft" />
        <div class="column b-85 mainbody">
            <div class="layout-base cont cont-full">
                <div class="cont-head">
                    <div class="title"><em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em><span>PK10</span></div>
                </div>
                <div class="cont-body">
                    <div class="module article-head"><h2>PK10说明</h2></div>
                    <div class="module article-overview">
                        <p style="font-size: small;width: 70%;">PK10，开奖效率高</p>
                        <div class="tp-ui-item tp-ui-forminput tp-ui-button-noselect tp-ui-button tp-ui-button-submit">
                            <div class="tp-ui-sub tp-ui-button-base"><input type="button" class="tpui-button" data-type="submit" value="立即投注" onclick="javascript:goLink('bet', 'pk10');" /></div>
                        </div>
                    </div>
                    <div class="module article-detial">
                        <p style="text-indent: 8mm;font-size: small;">PK10:</p>
                        <p style="text-indent: 8mm;font-size: small;">销售时间：09:07-23:57（5分钟一期，共179期）。每期开奖号码为1-10的排列组合共10个号码。</p>
                        <p style="line-height: 16px;">&nbsp;</p>
                        <p style="text-indent: 8mm;font-size: small;">玩法介绍如下：</p>
                        <table style="text-align:center;font-size: small; ">
                        <tr>
                            <th style="width: 40px;">类型</th>
                            <th style="width: 40px;">玩法</th>
                            <th style="width: 40px;">子玩法</th>
                            <th>玩法说明</th>
                            <th>中奖举例</th>
                        </tr>
                        <tr>
                            <td rowspan="10">常规玩法</td>
                            <td>猜冠军</td>
                            <td>猜冠军</td>
                            <td>选号与开奖号码中第一位一致即中奖。</td>
                            <td>投注：1，开奖：1*********，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜冠亚军</td>
                            <td>猜冠亚军</td>
                            <td>选号与开奖号码按位猜对1-2位即中奖。</td>
                            <td>投注：冠军1、亚军3，开奖：13********，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前三名</td>
                            <td>猜前三名</td>
                            <td>选号与开奖号码按位猜对1-3位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4，开奖：134*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前四名</td>
                            <td>猜前四名</td>
                            <td>选号与开奖号码按位猜对1-4位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5，开奖：1345******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前五名</td>
                            <td>猜前五名</td>
                            <td>选号与开奖号码按位猜对1-5位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6，开奖：13456*****，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前六名</td>
                            <td>猜前六名</td>
                            <td>选号与开奖号码按位猜对1-6位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6、第六名8，开奖：134568****，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前七名</td>
                            <td>猜前七名</td>
                            <td>选号与开奖号码按位猜对1-7位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6、第六名8、第七名2，开奖：1345682***，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前八名</td>
                            <td>猜前八名</td>
                            <td>选号与开奖号码按位猜对1-8位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6、第六名8、第7名2、第八名7，开奖：13456827**，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前九名</td>
                            <td>猜前九名</td>
                            <td>选号与开奖号码按位猜对1-9位即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6、第六名8、第7名2、第八名7、第九名9，开奖：134568279*，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>猜前十名</td>
                            <td>猜前十名</td>
                            <td>选号与开奖号码按位猜对10位或一位没中即中奖。</td>
                            <td>投注：冠军1、亚军3、第三名4、第四名5、第五名6、第六名8、第7名2、第八名7、第九名9、第十名10，开奖：134568279'10'(最后的10算一个数字)，即为中奖。</td>
                        </tr>
                        <tr>
                            <td rowspan="16">趣味玩法</td>
                            <td rowspan="5">前三和值</td>
                            <td>大</td>
                            <td>开奖结果前三个数字相加的和在17－27的范围内，即为中奖。</td>
                            <td>投注：大，开奖，378*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>小</td>
                            <td>开奖结果前三个数字相加的和在6－16的范围内，即为中奖。</td>
                            <td>投注：小，开奖，123*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>单</td>
                            <td>开奖结果前三个数字相加的和为单数，即为中奖。</td>
                            <td>投注：单，开奖，124*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>双</td>
                            <td>开奖结果前三个数字相加的和为双数，即为中奖。</td>
                            <td>投注：双，开奖，123*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>具体和值(6-27)</td>
                            <td>选择具体和值,开奖结果前三个数字相加的和等于所选的值，即为中奖。</td>
                            <td>投注：13，开奖，157*******，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>自由双面</td>
                            <td>大小单双</td>
                            <td>在冠军、亚军、第三名上选择相应的大、小、单、双进行投注，投注的大、小、单、双与开奖结果相应位置的大、小、单、双一致，即为中奖。</td>
                            <td>投注：冠军、大，开奖：6*********，即为中奖。</td>
                        </tr>
                        <tr>
                            <td rowspan="5">猜名次</td>
                            <td>1至3</td>
                            <td>选择一个或者多个号车号，若所选车号在比赛结果中的1-3个数字中出现，即中奖。</td>
                            <td>投注：选择车号01、第1名-第3名，开奖：1*********，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>4至6</td>
                            <td>选择一个或者多个号车号，若所选车号在比赛结果中的4-6个数字中出现，即中奖。</td>
                            <td>投注：选择车号01、第4名-第6名，开奖：****1*****，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>7至10</td>
                            <td>选择一个或者多个号车号，若所选车号在比赛结果中的7-10个数字中出现，即中奖。</td>
                            <td>投注：选择车号01、第7名-第10名，开奖：*******1**，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>1至5</td>
                            <td>选择一个或者多个号车号，若所选车号在比赛结果中的1-5个数字中出现，即中奖。</td>
                            <td>投注：选择车号01、第1名-第5名，开奖：****1*****，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>6至10</td>
                            <td>选择一个或者多个号车号，若所选车号在比赛结果中的6-10个数字中出现，即中奖。</td>
                            <td>投注：选择车号01、第6-第10名，开奖：*********1，即为中奖。</td>
                        </tr>
                        <tr>
                            <td rowspan="5">跨度</td>
                            <td>大</td>
                            <td>选择投注位置(全五、前三、中三、后三)，开奖号码对应投注位置上的最大数字减去最小数字范围为6-10，即为中奖。</td>
                            <td>投注：选择全五、大，开奖：01 03 02 04 10(跨度为10-1=9)，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>小</td>
                            <td>选择投注位置(全五、前三、中三、后三)，开奖号码对应投注位置上的最大数字减去最小数字范围为1-5，即为中奖。</td>
                            <td>投注：选择前三、小，开奖：01 02 04 08 11(跨度为4-1=3)，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>单</td>
                            <td>选择投注位置(全五、前三、中三、后三)，开奖号码对应投注位置上的最大数字减去最小数字为单数，即为中奖。</td>
                            <td>投注：选择前三、单，开奖：01 02 04 08 11(跨度为4-1=3)，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>双</td>
                            <td>选择投注位置(全五、前三、中三、后三)，开奖号码对应投注位置上的最大数字减去最小数字为双数，即为中奖。</td>
                            <td>投注：选择中三、双，开奖：01 02 04 08 11(跨度为8-2=6)，即为中奖。</td>
                        </tr>
                        <tr>
                            <td>具体跨度值(1-10)</td>
                            <td>选择投注位置(全五、前三、中三、后三)，开奖号码对应投注位置上的最大数字减去最小数字为选择的跨度值，即为中奖。</td>
                            <td>投注：选择后三、5，开奖：01 02 06 08 11(跨度为11-6=5)，即为中奖。</td>
                        </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>