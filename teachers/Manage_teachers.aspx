<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Manage_teachers.aspx.cs" Inherits="teachers_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">管理教师信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
        <td align="center">
            <strong> 教师编号:</strong><asp:TextBox ID="txt_tno" runat="server" width="150"></asp:TextBox>
<strong> 姓名:</strong><asp:TextBox ID="txt_tname" runat="server" width="150"></asp:TextBox>

    <asp:Button ID="Button1" runat="server" Text="检 索"  class="btn btn-info-outline"  onclick="btnSearch_Click" />

        </td>
    </tr>
    <tr>
        <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle Height="25px" HorizontalAlign="Center" />
        <Columns>       
            <asp:BoundField HeaderText="教师编号" DataField="tno" />
            <asp:BoundField HeaderText="登录密码" DataField="password" />
            <asp:BoundField HeaderText="姓名" DataField="tname" />
            <asp:BoundField HeaderText="性别" DataField="sex" />
            <asp:BoundField HeaderText="职称" DataField="job" />
            <asp:BoundField HeaderText="联系方式" DataField="tel" />
            <asp:BoundField HeaderText="电子邮箱" DataField="email" />
            <asp:BoundField HeaderText="任教课程" DataField="coname" />
            <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
<input id="btnShow" type="button" value="详情"  onclick="location.href = 'View_teachers.aspx?id=<%#Eval("tno") %>'; "  class="btn btn-info-outline" />
<input id="btnEdit" type="button" value="修改"  onclick="location.href = 'Modify_teachers.aspx?id=<%#Eval("tno") %>'; "  class="btn btn-info-outline" />
<asp:Button ID="btnDele" runat="server" Text="删除"  CausesValidation="False"   CommandName='<%#Eval("tno") %>'  OnClick="btnDele_Click"  class="btn btn-info-outline" />
            </ItemTemplate>
             <ItemStyle Width="210px" />
            </asp:TemplateField>
        </Columns>
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>

            
            
        </td>
    </tr>
</table>

                        </td></tr>
                    </table>
			</div>
     
</asp:Content>


