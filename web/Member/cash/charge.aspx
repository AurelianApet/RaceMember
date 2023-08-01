<%@ Page Language="C#" AutoEventWireup="true" CodeFile="charge.aspx.cs" Inherits="Member_charge" MasterPageFile="~/Member/MemberMaster.master" %>
<%@ MasterType VirtualPath="~/Member/MemberMaster.master" %>

<%@ Register TagName="ucLeft" TagPrefix="ucLeftfix" Src="~/Member/uc/LeftUseInfoMenu.ascx" %>

<asp:Content ContentPlaceHolderID="MemberHeadContent" ID="memberHead" runat="server">
<script type="text/javascript" language="javascript">
    $(document).ready(function() {
        ChangeMenuImageSelected('myinfo');
        ChangeUserInfoMenuSelected('memberrecharge');
    });
    gl.title = '充值 - K彩';
    $(document).ready(function() {
        init_memeberRecharge();
    });
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MemberBodyContent" ID="memberBody" runat="server">
<div class="main" id="content">
    <div class="row" id="memberSideBarId">
        <div class="row layout-base cont" id="member-cont">
            <ucLeftfix:ucLeft runat="server" ID="usLeft" />
            <div class="column b-85 mainbody" id="main-body">
                <!--cont-base start-->
                <div class="cont cont-base">
                    <div class="cont-head">
                        <div class="title"> <em class="tp-ui-icon tp-ui-icon-before icon-cont"><i>&nbsp;</i></em> <span>充值</span> </div>
                    </div>
                    <div class="cont-body">
                        <!--tab-nav start-->
                        <div class="module tab-nav member-tab">
                            <ul>
                                <li class="active"><a href="javascript:goLink('charge');">充值</a></li>
                                <li><a href="javascript:goLink('chargelog');">充值记录</a></li>
                                <li style="display:none;"><a href="javascript:goLink('chargeerrorlog');">充值异常记录</a></li>
                            </ul>
                        </div>
                        <!--tab-nav end-->
                        <!--tab-content-module start-->
                        <div class="tab-content">

                            <!--recharge-model start-->
                            <div class="module" id="recharge-model">
                                <ul>
                                    <li><a id="rm-less" data-model="0" href="javascript:void(0);"><span></span></a></li>
                                    <li><a id="rm-more" data-model="1" href="javascript:void(0);"><span></span></a></li>
                                </ul>
                            </div>
                            <!--recharge-model start-->
                            <span style="color: red;margin-left: 50px;font-size: 15px;">温馨提醒: 请注意您的可用分数并提前充值，如遇充值未及时到账，影响投注，造成的损失，由您自行承担！</span>
                        </div>
                        <!--tab-content-module end-->

                    </div>
                </div>
                <!--cont-base end-->
                <span style="display: none;">
                    <!-- 用户充值 recharge-order-dialog start-->
                    <div id="recharge-order" title="普通充值">

                        <!--forms-table start-->
                        <div class="forms-table uc-forms">

                            <!--form-row start-->
                            <div id="normalRechargeTr" class="row form-row">
                                <div class="column form-sub form-title b-25 mb-0">
                                    <label>账户类型:</label>
                                </div>
                                <div class="column form-sub form-input b-75 mb-0">

                                    <!--recharge-account-checker start-->
                                    <div id="recharge-account-checker">
                                        <ul>
                                            <li>
                                                <label class="rac-gsyh">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="gsyh" checked />
                                                    <h4><i>中国工商银行</i></h4>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="rac-cft">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="cft" />
                                                    <h4><i>腾讯财付通</i></h4>
                                                </label>
                                            </li>
                                            <li>
                                                <label class="rac-zfb">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="zfb" />
                                                    <h4><i>支付宝</i></h4>
                                                </label>
                                            </li>
                                            <li  style="display: none;"><!--打开pc微信支付，这边显示即可-->
                                                <label class="rac-wx" style="background: #92c922;border-color: #78bd00;">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="wx" />
                                                    <h4 style ="background-image :none;font-size :18px;font-family :lisu;">
                                                        <i style="margin-left: 12px;">微信支付</i>
                                                    </h4>
                                                </label>
                                            </li>
                                        </ul>
                                    </div>
                                    <!--recharge-account-checker end-->

                                </div>
                            </div>
                            <div id="normalRechargeTr1" class="row form-row">
                                <div class="column form-sub form-title b-25 mb-0">
                                    <label>账户类型:</label>
                                </div>
                                <div class="column form-sub form-input b-75 mb-0">

                                    <!--recharge-account-checker start-->
                                    <div id="recharge-account-checker1">
                                        <ul>
                                            <li>
                                                <label class="rac-zfb">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="zfb" />
                                                    <h4><i>支付宝</i></h4>
                                                </label>
                                            </li>
                                            <li><!--打开pc微信支付，这边显示即可-->
                                                <label class="rac-wx" style="background: #92c922;border-color: #78bd00;">
                                                    <input type="radio" name="recharge-account" class="tpui-radio" value="wx" />
                                                    <h4 style ="background-image :none;font-size :18px;font-family :lisu;">
                                                        <i style="margin-left: 12px;">微信支付</i>
                                                    </h4>
                                                </label>
                                            </li>
                                        </ul>
                                    </div>
                                    <!--recharge-account-checker end-->

                                </div>
                            </div>
                            <!--form-row end-->
                            <!--form-row start-->
                            <div class="row form-row">
                                <div class="column form-sub form-title b-25 mb-0">
                                    <label>充值金额:</label>
                                </div>
                                <div class="column form-sub form-input b-75 mb-0">
                                    <input class="myNumClass0" type="text" id="tpui-funds-sum" min="1" step="1" data-type="d" value="1">
                                </div>
                            </div>
                            <!--form-row end-->
                            <!--form-row start-->
                            <div id="normalRechargeTr2" class="row form-row">
                                <div class="column form-sub form-title b-25 mb-0">
                                    <label>账号:</label>
                                </div>
                                <div class="column form-sub form-input b-75 mb-0">
                                    <input id="rechargeInfo" type="text" class="tpui-text" placeholder="卡号，ID或账户信息" />
                                </div>
                            </div>
                            <div class="row form-row">
                                <div class="column form-sub form-title b-25 mb-hidden">&nbsp;</div>
                                <div class="column form-sub form-tips b-75 mb-0">
                                    <p>
                                        <lable style="color: red">温馨提示：</lable>
                                        <br />
                                        <lable style="color: red">注：如不充值，请不要点提交充值申请菜单。<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;如恶意3次以上提交充值申请，直接会被注销账号。</lable>
                                        <span id="rechargeBanktips">单笔最低充值10元！<br />以上银行帐号限本次存款用，帐号不定时更新！<br />每次存款前请依照本页所显示的银行帐号入款。<br />只有工行充值到工行，才能立即到账喔！</span>
                                    </p>
                                </div>
                            </div>
                            <!--form-row end-->
                            <!--form-row start-->
                            <div class="row form-row">
                                <div class="column form-sub form-title b-25 mb-0">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="column form-sub form-input b-75 mb-0">
                                    <input type="submit" class="tpui-button" data-type="submit" id="recharge-order-submit" value="提交充值申请">
                                    <input type="submit" class="tpui-button" data-type="submit" id="rechargeOrderCancelBtn" value="取消">
                                </div>
                            </div>
                            <!--form-row end-->

                        </div>
                        <!--forms-table end-->

                    </div>
                    <!--recharge-order-dialog end-->
                    <!--recharge-order-refer-dialog start-->
                    <div id="recharge-order-refer" title="订单详情">

                        <!--recharge-tips start-->
                        <div class="module" id="recharge-tips">
                            <p> 当前订单<span class="fc-green">有效期为30分钟</span>，请尽快充值！距离超时：<span id="rt-cutdown"></span><a href="javascript:void(0);" id="rt-reload" title="点击重新获取账户信息！">重新获取</a> </p>
                        </div>
                        <!--recharge-tips end-->
                        <!--table start-->
                        <form name="alipay" id="recharge_zfb_btn" method="post" target="_blank" action="https://shenghuo.alipay.com/send/payment/fill.htm" accept-charset="gbk">
                            <div id="rechargeInfoId" class="module table">
                                <table>
                                    <tbody id="normalTBodyId">
                                        <tr>
                                            <td><span>支付方式：</span></td>
                                            <td class="ta-left"><span id="rc-bankname">loading...</span></td>
                                        </tr>
                                        <tr>
                                            <td><span>银行户名：</span></td>
                                            <td class="ta-left"><span id="rc-username">loading...</span><a id="CopyBankName" class="rc-copy" href="javascript:void(0);" title="复制到剪贴板">[复制]</a></td>
                                        </tr>
                                        <tr>
                                            <td><span>银行账户：</span></td>
                                            <td class="ta-left"><span id="rc-useraccount">loading...</span><a id="CopyBankAccount" class="rc-copy" href="javascript:void(0);" title="复制到剪贴板">[复制]</a></td>
                                        </tr>
                                        <tr>
                                            <td><span>充值金额：</span></td>
                                            <td class="ta-left"><span id="rc-sum">loading...</span><a id="CopyBankAmount" class="rc-copy" href="javascript:void(0);" title="复制到剪贴板">[复制]</a></td>
                                        </tr>
                                        <tr>
                                            <td><span>订单编号：</span></td>
                                            <td class="ta-left"><span id="rc-orderid">loading...</span><a id="CopyBankOrder" class="rc-copy" href="javascript:void(0);" title="复制到剪贴板">[复制]</a></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><span style="color:red;"> 务必复制"订单编号"到汇款页面的"附言"栏中进行粘帖(键盘Ctrl+V)，否则无法充值到帐!</span></td>
                                        </tr>
                                    </tbody>
                                    <tbody id="wxTBodyId" style="display: none;">
                                        <tr>
                                            <td><img id="wxPayImgId" src="" style="width: 200px;height: 200px;"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            
                            <input type="hidden" name="_ad" value="c">
                            <input name="_adType" type="hidden" value="alipay_my_home_aide01">
                            <input name="optEmail" type="hidden" id="hidRCUserAccount" value="">
                            <input name="payAmount" type="hidden" id="hidRCSum" value="">
                            <input name="title" type="hidden" id="hidRCOrderId" value="">
                            <input name="memo" type="hidden" value="请不要修改付款说明，否则无法自动到账。">
                            <input name="_input_charset" type="hidden" value="utf-8">
                        </form>
                        <!--table end-->
                        <!--button-group start-->
                        <div class="module button-group button-group-hor">
                            <!--<button id="recharge-order-back">返回</button>-->
                            <div class="btnsClass tp-ui-item tp-ui-forminput tp-ui-button-noselect tp-ui-button tp-ui-button-default"><div class="tp-ui-sub tp-ui-button-base"><a href="https://www.alipay.com/" target="_blank">打开支付宝网站</a></div></div>
                            <button id="recharge-order-prop" class="btnsClass">loading...</button>
                            <button id="recharge-order-demo" class="btnsClass">普通转账演示</button>
                            <button id="recharge-order-close">关闭</button>
                        </div>
                        <!--button-group end-->

                    </div>
                    <!--recharge-order-refer-dialog end-->
                    <!--recharge-demo-gsyh start-->
                    <div class="recharge-demo" id="rd-gsyh" title="中国工商银行 - 充值演示"> <img src="/images/recharge/r_demo_gh.jpg" alt="" /> </div>
                    <!--recharge-demo-gsyh end-->
                    <!--recharge-demo-cft start-->
                    <div class="recharge-demo" id="rd-cft" title="腾讯财付通 - 充值演示"> <img src="/images/recharge/r_demo_cft.jpg" alt="" /> </div>
                    <!--recharge-demo-cft end-->
                    <!--recharge-demo-zfb start-->
                    <div class="recharge-demo" id="rd-zfb" title="支付宝 - 充值演示"> <img src="/images/recharge/r_demo_zfb.jpg" alt="支付宝充值演示" /> </div>
                    <!--recharge-demo-zfb end-->
                </span>
            </div>
        </div>
    </div>
</div>
</asp:Content>