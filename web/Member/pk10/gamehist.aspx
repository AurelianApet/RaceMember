<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gamehist.aspx.cs" Inherits="Member_pk10_gamehist" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<link href="/css/pk10.css" rel="stylesheet"/>
<script type="text/javascript" language="javascript">
$(document).ready(function() {
    ChangeMenuImageSelected('gamehist');
});
$(function() {
    $("#ball-choose b[class!=inputBtn]").click(function() {
        
        var c = $(this).attr("data-c");

        if ($(this).attr("class") == "newCheckBox") {
            $(this).addClass("true");
        } else {
            $(this).removeClass("true");
        }
        if (typeof showNum != 'undefined' && showNum instanceof Function) {
            showNum();
        }
    });
    $("#bsoe-choose b[class!=inputBtn][id!='duizi']").click(function() {
        var c = $(this).attr("data-c");
        var g = $(this).attr("data-g");
        if (c) {
            if ($(this).attr("class").indexOf("true") < 0) {
                $("#bsoe-choose b[data-g=" + g + "]").removeClass("true");
                $(this).addClass("true");
            } else {
                $(this).removeClass("true");
            }

            if (typeof showNum != 'undefined' && showNum instanceof Function) {
                showNum();
            }
        }
    });
    function clearChk(noaction) {
        $("#ball-choose b").removeClass("true");
        if (typeof noaction == 'undefined')
            showNum();
    }
    function clearBsoeChk() {
        $("#bsoe-choose b[id!=duizi]").removeClass("true");
        if (typeof noaction == 'undefined')
            showNum();
    }
    $("#duizi").bind("click", function() {
        var flag = $(this).attr("enable") == "0";
        if (flag) return;

        clearChk(1);
        clearBsoeChk(1);

        if ($(this).attr("class") == "newCheckBox") {
            $(this).addClass("true");
            checkDuizi();
        } else {
            $(this).removeClass("true");
            $(".nums i").removeClass("noshade");
            $(".nums").removeClass("shade");
            showNum();
        }
    });
    $(".show-type a").live("click", function() {
        if ($("#duizi").attr("class").indexOf("true") > 0)
            return;

        $(".show-type a").removeClass("cur");
        $(this).addClass("cur");
        showNum();
        if ($(this).attr("data-type") != "num") {
            $("#duizi").css({ cursor: "default" }).attr("enable", "0");
        } else {
            $("#duizi").css({ cursor: "pointer" }).attr("enable", "1");
        }
    });
});
function showNum() {
    if ($("#duizi").attr("class").indexOf("true") < 0) {
        var datas = [];
        var ckbeds = $("#ball-choose b.true");
        var ckbedBsoe = $("#bsoe-choose b.true");

        for (var i = 0; i < ckbeds.length; i++) {
            datas.push($(ckbeds[i]).attr("data-c"));
        }
        var chkD = [];
        for (var i = 0; i < ckbedBsoe.length; i++) {
            var t = $(ckbedBsoe[i]).attr("data-c");
            chkD.push(t);
        }

        if (chkD.length == 1) {
            if ($.inArray("s", chkD) > -1) {
                datas.push(1, 2, 3, 4, 5);
            } else if ($.inArray("o", chkD) > -1) {
                datas.push(1, 3, 5, 7, 9);
            } else if ($.inArray("e", chkD) > -1) {
                datas.push(2, 4, 6, 8, 10);
            } else if ($.inArray("b", chkD) > -1) {
                datas.push(6, 7, 8, 9, 10);
            }
        } else {
            if ($.inArray("s", chkD) > -1 && $.inArray("e", chkD) > -1) {
                datas.push(2, 4);
            } else if ($.inArray("s", chkD) > -1 && $.inArray("o", chkD) > -1) {
                datas.push(1, 3, 5);
            } else if ($.inArray("b", chkD) > -1 && $.inArray("e", chkD) > -1) {
                datas.push(6, 8, 10);
            } else if ($.inArray("b", chkD) > -1 && $.inArray("o", chkD) > -1) {
                datas.push(7, 9);
            }
        }

        var showtype = $(".show-type .cur").attr("data-type");

        $(".nums").removeClass("num-bs num-oe shade-num shade-oe shade-bs");
        $(".nums i").removeClass("noshade-num noshade-oe noshade-bs");

        if (datas.length > 0) {
            $(".nums").addClass("shade-" + showtype);
        }
        for (var i = 0; i < datas.length; i++) {
            var c = ".pk-no" + datas[i];
            $(c).addClass("noshade-" + showtype);
        }
        if (datas.length == 0 && showtype != "num") {
            $(".nums").addClass("num-" + showtype);
        }
    } else {
        checkDuizi();
    }
}
$("#ball-choose b[class!=inputBtn],#bsoe-choose b[class!=inputBtn][id!=duizi]").click(function() {
    clearDuiziChk();
});
function checkDuizi() {
    $(".nums").removeClass("num-bs num-oe shade-num shade-oe shade-bs");
    $(".nums i").removeClass("noshade-num noshade-oe noshade-bs");
    $(".nums").addClass("shade-num");
    var nums = $(".nums");
    var length = nums.length;
    if (length <= 1) {
        return;
    }
    var tmp = [];
    var num_i = $(nums[length - 1]).find('i');
    for (var j = 0; j < 10; j++) {
        tmp.push($(num_i[j]).attr("class"));
    }

    for (var i = nums.length - 2; i >= 0; i--) {
        var num_i = $(nums[i]).find('i');
        for (var j = 0; j < 10; j++) {
            var t = $(num_i[j]).attr("class");
            if (t == tmp[j]) {
                $(num_i[j]).addClass("noshade-num");
                $($(nums[i + 1]).find('i')[j]).addClass("noshade-num");
            }
            tmp[j] = t;
        }
    }
}
function clearDuiziChk() {
    $("#duizi").removeClass("true");
    $(".nums i").removeClass("noshade");
    $(".nums").removeClass("shade");
}
function clearChk(noaction) {
    $("#ball-choose b").removeClass("true");
    if (typeof noaction == 'undefined')
        showNum();
}
function clearBsoeChk() {
    $("#bsoe-choose b[id!=duizi]").removeClass("true");
    if (typeof noaction == 'undefined')
        showNum();
}

</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="lot-wrap">
        <div class="checkBlock">
	        <div class="checkBlockList" id="ball-choose">
		        <i>查看车号分布：</i>
		        <div class="listCons">
			        <b class="newCheckBox" data-c="1">号1</b>
			        <b class="newCheckBox" data-c="2">号2</b>
			        <b class="newCheckBox" data-c="3">号3</b>
			        <b class="newCheckBox" data-c="4">号4</b>
			        <b class="newCheckBox" data-c="5">号5</b>
			        <b class="newCheckBox" data-c="6">号6</b>
			        <b class="newCheckBox" data-c="7">号7</b>
			        <b class="newCheckBox" data-c="8">号8</b>
			        <b class="newCheckBox" data-c="9">号9</b>
                    <b class="newCheckBox" data-c="10">号10</b>
                    <b class="inputBtn"><input type="button" value="还原" onclick="clearChk()"></b>
		        </div>
	        </div>
	        <div class="checkBlockList" id="bsoe-choose">
		        <i>大小单双分布：</i>
		        <div class="listCons">
			        <b class="newCheckBox" data-c="b" data-g="bs">大</b>
			        <b class="newCheckBox second" data-c="s" data-g="bs">小</b>
                    <i class="line">|</i>
			        <b class="newCheckBox" data-c="o" data-g="oe">单</b>
			        <b class="newCheckBox" data-c="e" data-g="oe">双</b>
                    <b class="inputBtn"><input type="button" value="还原" onclick="clearBsoeChk()"></b>
                    <b class="newCheckBox" id="duizi" style="width:80px;margin-left:40px">查看对子号</b>
		        </div>
	        </div>
        </div>
        <div id="history-table">
            <asp:GridView ID="gvContent" runat="server" GridLines="None"
                Width="100%" CssClass="lot-table"
                AutoGenerateColumns="false"
                AllowPaging="true"
                AllowSorting="true" 
                OnRowCreated="gvContent_RowCreated"
                OnPageIndexChanging="gvContent_PageIndexChange"
                OnRowDataBound="gvContent_RowDataBound">
            <AlternatingRowStyle CssClass="odd" />
            <Columns>
                <asp:TemplateField HeaderText="时间">
                    <HeaderStyle CssClass="head" Width="160px"/>
                    <ItemTemplate>
                        <p class="p"><%#Eval("round") %></p>
                        <p class="t"><%#string.Format("{0:MM-dd HH:mm}", Eval("sdate")) %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="nums" />
                    <HeaderStyle CssClass="head show-type" Width="550px" />
                    <HeaderTemplate>
                        <a href="javascript:void(0);" data-type="num" class="cur">显示号码</a>
                        <a href="javascript:void(0);" data-type="bs">显示大小</a>
                        <a href="javascript:void(0);" data-type="oe">显示单双</a>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="ltlNumber" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="冠亚军和">
                    <HeaderStyle CssClass="head" />
                    <ItemTemplate>
                        <asp:Literal ID="ltlSum" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="冠亚军和">
                    <HeaderStyle CssClass="head" />
                    <ItemTemplate>
                        <asp:Literal ID="ltlOverUnder" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="冠亚军和">
                    <HeaderStyle CssClass="head" />
                    <ItemTemplate>
                        <asp:Literal ID="ltlOddEven" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle VerticalAlign="Middle" />
            <EmptyDataTemplate>
                <table class="clstableborder" width="100%">
                <tr>
                    <td class="clsemptyrow">
                        <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:Str, STR_NODATA %>"></asp:Literal>
                    </td>
                </tr>
                </table>
            </EmptyDataTemplate>
            <PagerSettings Mode="Numeric" Position="Bottom"
                FirstPageText="<%$Resources:Str, STR_FIRST %>"
                PreviousPageText="<%$Resources:Str, STR_PREV %>"
                NextPageText="<%$Resources:Str, STR_NEXT %>"
                LastPageText="&nbsp;<%$Resources:Str, STR_LAST %>"
                PageButtonCount="10" />
            <PagerStyle CssClass="clspager" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
