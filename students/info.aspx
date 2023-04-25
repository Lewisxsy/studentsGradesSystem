<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="info.aspx.cs" Inherits="students_info" %>
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
						<h2 class="title">修改个人信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>学号:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_sno" runat="server" width="200" Enabled="False"></asp:TextBox></div>
 </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>姓名:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_stname" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_stnameTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
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
<td  style=" text-align:right; width:20%;">年龄:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_age" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_ageTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
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
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>专业:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:DropDownList ID="ddlspid" runat="server" Width="200" Enabled="false">
</asp:DropDownList> </td></tr>

<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>班级:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:DropDownList ID="ddlclid" runat="server" Width="200" Enabled="false">
</asp:DropDownList> </td></tr>


    <tr>
        <td>&nbsp;</td>
        <td align="left">
            <asp:Button ID="Button2" runat="server" Text="确 定"  class="btn btn-info-outline" OnClick="btnSave_Click" OnClientClick="return jQuery.formValidator.PageIsValid('1');" />
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     <script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $.formValidator.initConfig({ onError: function(msg) { alert(msg) } });
        $("#ctl00_ContentPlaceHolder1_txt_sno").formValidator({ onshow: "请输入学号", onfocus: "学号不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "学号不能为空,请确认" });
        $("#ctl00_ContentPlaceHolder1_txt_password").formValidator({ onshow: "请输入登录密码", onfocus: "登录密码不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "登录密码不能为空,请确认" });
        $("#ctl00_ContentPlaceHolder1_txt_stname").formValidator({ onshow: "请输入姓名", onfocus: "姓名不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "姓名不能为空,请确认" });
        $("#ctl00_ContentPlaceHolder1_txt_tel").formValidator({ onshow: "请输入联系方式", onfocus: "联系方式不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "联系方式不能为空,请确认" });
        $("#ctl00_ContentPlaceHolder1_txt_email").formValidator({ onshow: "请输入电子邮箱", onfocus: "电子邮箱不能为空", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "电子邮箱不能为空,请确认" });
    });
</script>

</asp:Content>


