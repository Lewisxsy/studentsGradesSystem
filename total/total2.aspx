<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="total2.aspx.cs" Inherits="scores_List" %>
<%@ Register Assembly="am.Charts" Namespace="am.Charts" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">成绩统计</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
        <td align="center">
            <strong> 课程名称</strong><asp:DropDownList ID="ddlcoid" runat="server" Width="150">
</asp:DropDownList> <strong> 专业</strong><asp:DropDownList ID="ddlspid" runat="server" Width="150"  AutoPostBack="True" OnSelectedIndexChanged="ddlspid_SelectedIndexChanged">
</asp:DropDownList><strong> 班级</strong><asp:DropDownList ID="ddlclid" runat="server" Width="150">
</asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="检 索"  class="btn btn-info-outline"  onclick="btnSearch_Click" />

        </td>
    </tr>
    <tr>
        <td align="center">
              

               <cc1:PieChart runat="server" ID="PieChart1"></cc1:PieChart> 
            
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     
</asp:Content>


