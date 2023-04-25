<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Modify_teachers.aspx.cs" Inherits="teachers_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="../js/jquery.js" type="text/javascript"></script>
<script src="../js/formValidator.js" type="text/javascript"></script>  
<script src="../js/formValidatorRegex.js" type="text/javascript"></script>
<link href="../css/validator.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">编辑教师信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>教师编号:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_tno" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_tnoTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>登录密码:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_password" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_passwordTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>姓名:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_tname" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_tnameTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>性别:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:DropDownList ID="ddlsex" runat="server" >
    <asp:ListItem >男</asp:ListItem>
    <asp:ListItem>女</asp:ListItem>
</asp:DropDownList>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>职称:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_job" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_jobTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>联系方式:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_tel" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_telTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>电子邮箱:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_email" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_emailTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;">个人简介:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_memo" runat="server" width="310px" Height="98px" TextMode="MultiLine"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_memoTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>任教课程:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:DropDownList ID="ddlcoid" runat="server" Width="200">
</asp:DropDownList> </td></tr>


    <tr>
        <td>&nbsp;</td>
        <td align="left">
            <asp:Button ID="btnUpdate" runat="server" Text="确 定"  class="btn btn-info-outline" OnClick="btnSave_Click" />
            <asp:Button ID="btnCan" runat="server" Text="返 回"  class="btn btn-warning-outline" OnClientClick="document.location='Manage_teachers.aspx';return false;" CausesValidation="false" />
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     <script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $.formValidator.initConfig({ onError: function(msg) { alert(msg) } });
        $("#ctl00_ContentPlaceHolder1_txt_tno").formValidator({ onshow: "请输入教师编号", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，教师编号不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_password").formValidator({ onshow: "请输入登录密码", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，登录密码不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_tname").formValidator({ onshow: "请输入姓名", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，姓名不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_job").formValidator({ onshow: "请输入职称", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，职称不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_tel").formValidator({ onshow: "请输入联系方式", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，联系方式不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_email").formValidator({ onshow: "请输入电子邮箱", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，电子邮箱不能为空" });
    });
</script>

</asp:Content>


