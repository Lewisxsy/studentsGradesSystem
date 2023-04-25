<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Modify_scores.aspx.cs" Inherits="scores_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/formValidator.js" type="text/javascript"></script>
    <script src="../js/formValidatorRegex.js" type="text/javascript"></script>
    <link href="../css/validator.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrap">
        <section class="page-hd">
            <header>
                <h2 class="title">编辑成绩信息</h2>

            </header>
            <hr>
        </section>


        <table class="auto-style1">

            <tr>
                <td valign="top">

                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>课程名称:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:DropDownList ID="ddlcoid" runat="server" Width="200" Enabled="false">
                                    </asp:DropDownList>
                            </td>
                        </tr>

                        <%--                                <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>学年:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="cyear" runat="server" width="200" Enabled="false"></asp:TextBox></div>
 </td></tr>
                                <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>学期:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="cteam" runat="server" width="200" Enabled="false"></asp:TextBox></div>
 </td></tr>--%>


                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>学号:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txt_sno" runat="server" Width="200" Enabled="false"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder1_txt_snoTip" style="width: 250px; display: inline; float: left; text-align: left;"></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>日常表现分数:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txtOrdscore" runat="server" Width="200"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder2_txt_scoreTip" style="width: 250px; display: inline; float: left; text-align: left;">占比40%</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 20%;"><font style='color: red'>*&nbsp;</font>分数:</td>
                            <td class="tbright">
                                <div style="display: inline; float: left;">
                                    <asp:TextBox ID="txt_score" runat="server" Width="200"></asp:TextBox>
                                </div>
                                <div id="ctl00_ContentPlaceHolder1_txt_scoreTip" style="width: 250px; display: inline; float: left; text-align: left;">占比60%</div>
                            </td>
                        </tr>



                        <tr>
                            <td>&nbsp;</td>
                            <td align="left">
                                <asp:Button ID="btnUpdate" runat="server" Text="确 定" class="btn btn-info-outline" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCan" runat="server" Text="返 回" class="btn btn-warning-outline" OnClientClick="document.location='Manage_scores.aspx';return false;" CausesValidation="false" />
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
            $("#ctl00_ContentPlaceHolder1_txt_score").formValidator({ empty: false, onshow: "请输入分数", onfocus: "只能输入数字", oncorrect: "合法" }).RegexValidator({ regexp: "num", datatype: "enum", onerror: "只能为数字" });
        });
</script>

</asp:Content>


