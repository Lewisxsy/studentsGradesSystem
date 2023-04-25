<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="Modify.aspx.cs" Inherits="news_Modify" %>

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
						<h2 class="title">添加课程信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>标题:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_coname" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_conameTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>
                                   <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>类型:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:DropDownList ID="ddlptype" runat="server">
    <asp:ListItem>综合新闻</asp:ListItem>
    <asp:ListItem>湖大学子</asp:ListItem>
    <asp:ListItem>疫情防控</asp:ListItem>
    <asp:ListItem>不忘初心，牢记使命</asp:ListItem>
   
</asp:DropDownList>
    

</div>
 </td></tr>
                             
  
                                   <tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>图片:</td>
<td class="tbright"><div style="display:inline;float:left;">
 <asp:TextBox ID="txtimg" runat="server" width="200"></asp:TextBox><asp:FileUpload ID="FileUpload1" runat="server" />

</div>
 </td></tr>
<tr>
<td  style=" text-align:right; width:20%;"><font style='color:red'>*&nbsp;</font>发布者:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_cotime" runat="server" width="200"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_cotimeTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>
    

<tr>
<td  style=" text-align:right; width:20%;">内容:</td>
<td class="tbright"><div style="display:inline;float:left;">
<asp:TextBox ID="txt_comemo" runat="server" width="291px" Height="102px" TextMode="MultiLine"></asp:TextBox></div><div id="ctl00_ContentPlaceHolder1_txt_comemoTip" style="width:250px;display:inline;float:left;text-align:left;"></div>
 </td></tr>



    <tr>
        <td>&nbsp;</td>
        <td align="left">
            <asp:Button ID="btnAdd" runat="server" Text="确 定"  class="btn btn-info-outline" OnClick="btnSave_Click" OnClientClick="return jQuery.formValidator.PageIsValid('1');" />
            <asp:Button ID="btnCan" runat="server" Text="返 回"  class="btn btn-warning-outline" OnClientClick="document.location='Manage_course.aspx';return false;" CausesValidation="false" />
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     <script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $.formValidator.initConfig({ onError: function(msg) { alert(msg) } });
        $("#ctl00_ContentPlaceHolder1_txt_coname").formValidator({ onshow: "请输入标题", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，标题不能为空" });
        $("#ctl00_ContentPlaceHolder1_txt_cotime").formValidator({ onshow: "请输入发布者", onfocus: "必填", oncorrect: "合法" }).InputValidator({ min: 1, onerror: "必填，发布者不能为空" });
        
    });
</script>
</asp:Content>

