<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Add_scores.aspx.cs" Inherits="scores_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/formValidator.js" type="text/javascript"></script>
    <script src="../js/formValidatorRegex.js" type="text/javascript"></script>
    <link href="../css/validator.css" rel="stylesheet" type="text/css" />

    <link href="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/theme/default/layer.min.css" rel="stylesheet">
    <script src="../css/disk/jquery.js"></script>
    <script type="text/javascript" src="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrap">
        <%--  <section class="page-hd">
            <header>
                <h2 class="title">录入成绩</h2>

            </header>
            <hr>
        </section>--%>


        <table class="auto-style1">

            <tr>
                <td valign="top">

                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>课程名称:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:DropDownList ID="ddlcoid" runat="server" Width="200">
                                    </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>学号:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txt_sno" runat="server" Width="200"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder1_txt_snoTip" style="width: 250px; display: inline; float: left; text-align: left;"></div>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>日常表现分数:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txt_OrderScore" runat="server" Width="200"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder1_txt_OrderScoreTip" style="width: 250px; display: inline; float: left; text-align: left;"></div>

                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>分数:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txt_score" runat="server" Width="200"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder1_txt_scoreTip" style="width: 250px; display: inline; float: left; text-align: left;"></div>
                            </td>
                        </tr>



                        <tr>
                            <td>&nbsp;</td>
                            <td align="left">
                                <asp:Button ID="btnAdd" runat="server" Text="确 定" class="btn btn-info-outline" OnClick="btnSave_Click" OnClientClick="return jQuery.formValidator.PageIsValid('1');" />
                                <asp:Button ID="btnCan" runat="server" Text="返 回" Visible="false" class="btn btn-warning-outline" OnClientClick="document.location='Manage_scores.aspx';return false;" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $.formValidator.initConfig({ onError: function (msg) { alert(msg) } });
            $("#ctl00_ContentPlaceHolder1_txt_sno").formValidator({ onshow: "请输入学号", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，学号不能为空" });
            $("#ctl00_ContentPlaceHolder1_txt_OrderScore").formValidator({ empty: false, onshow: "请输入分数", onfocus: "只能输入数字", oncorrect: "合法" }).RegexValidator({ regexp: "num", datatype: "enum", onerror: "只能为数字" });
            $("#ctl00_ContentPlaceHolder1_txt_score").formValidator({ empty: false, onshow: "请输入分数", onfocus: "只能输入数字", oncorrect: "合法" }).RegexValidator({ regexp: "num", datatype: "enum", onerror: "只能为数字" });
        });
    </script>
</asp:Content>


