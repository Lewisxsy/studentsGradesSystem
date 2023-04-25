<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Manage_course.aspx.cs" Inherits="course_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">管理课程信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
        <td align="center">
            <strong> 课程名称:</strong><asp:TextBox ID="txt_coname" runat="server" width="150"></asp:TextBox>

    <asp:Button ID="Button1" runat="server" Text="检 索"  class="btn btn-info-outline"  onclick="btnSearch_Click" />

        </td>
    </tr>
    <tr>
        <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle Height="25px" HorizontalAlign="Center" />
        <Columns>       
            <asp:BoundField HeaderText="课程名称" DataField="coname" />
            <asp:ImageField HeaderText="图片" DataImageUrlField="img" DataImageUrlFormatString="{0}" ControlStyle-Width="50px" ControlStyle-Height="50px"></asp:ImageField>
            <asp:BoundField HeaderText="大类" DataField="ptype" />
            <asp:BoundField HeaderText="类型" DataField="type" />
            <asp:BoundField HeaderText="课时" DataField="cotime" />
            <asp:BoundField HeaderText="学分" DataField="coscore" />
            <asp:BoundField HeaderText="学年" DataField="cyear" />
            <asp:BoundField HeaderText="学期" DataField="cteam" />
            <asp:TemplateField HeaderText="课程简介">
            <ItemTemplate>
            <%# StringHelper.SubStringHtml( Eval("comemo").ToString(),40) %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
<input id="btnShow" type="button" value="详情"  onclick="location.href = 'View_course.aspx?id=<%#Eval("coid") %>'; "  class="btn btn-info-outline" />
<input id="btnEdit" type="button" value="修改"  onclick="location.href = 'Modify_course.aspx?id=<%#Eval("coid") %>'; "  class="btn btn-info-outline" />
<asp:Button ID="btnDele" runat="server" Text="删除"  CausesValidation="False"   CommandName='<%#Eval("coid") %>'  OnClick="btnDele_Click"  class="btn btn-info-outline" />
            </ItemTemplate>    <ItemStyle Width="210px" />
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


