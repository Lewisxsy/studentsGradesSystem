<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="View_teachers.aspx.cs" Inherits="teachers_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">查看教师信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
     <tr>
	<td height="25" width="20%" align="right">教师编号：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lbltno" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">登录密码：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lblpassword" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">姓名：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lbltname" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">性别：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lblsex" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">职称：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lbljob" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">联系方式：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lbltel" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">电子邮箱：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lblemail" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">个人简介：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lblmemo" runat="server" Text=""></asp:Label></td>
	</tr>
 <tr>
	<td height="25" width="20%" align="right">任教课程：</td>
	<td height="25" width="*" align="left" style="text-align:left"><asp:Label ID="lblcoid" runat="server" Text=""></asp:Label></td>
	</tr>


    <tr>
        <td>&nbsp;</td>
        <td align="left">   

            <asp:Button ID="btnReturn" runat="server" Text="返 回"  class="btn btn-warning-outline" OnClientClick="history.go(-1); return false;" CausesValidation="false" />
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     
</asp:Content>


