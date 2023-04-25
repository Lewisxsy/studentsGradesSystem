﻿<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Modify_special.aspx.cs" Inherits="special_Edit" %>
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
						<h2 class="title">编辑专业信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>专业名称:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_spname" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_spnameTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>
            <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>学院名称:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="TextBox1" runat="server" width="200"></asp:TextBox></div>
 </td></tr>


    <tr>
        <td>&nbsp;</td>
        <td align="left">
            <asp:Button ID="btnUpdate" runat="server" Text="确 定"  class="btn btn-info-outline" OnClick="btnSave_Click" />
            <asp:Button ID="btnCan" runat="server" Text="返 回"  class="btn btn-warning-outline" OnClientClick="document.location='Manage_special.aspx';return false;" CausesValidation="false" />
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     <script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $.formValidator.initConfig({ onError: function(msg) { alert(msg) } });
        $("#ctl00_ContentPlaceHolder1_txt_spname").formValidator({ onshow: "请输入专业名称", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，专业名称不能为空" });
    });
</script>

</asp:Content>


