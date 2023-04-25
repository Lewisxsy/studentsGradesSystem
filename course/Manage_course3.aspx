<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Manage_course3.aspx.cs" Inherits="course_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">课程信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
  
    <tr>
        <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" OnRowCommand="GridView1_RowCommand" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle Height="25px" HorizontalAlign="Center" />
        <Columns>       
            <asp:BoundField HeaderText="课程名称" DataField="coname" />
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
<asp:LinkButton ID="btnck" CommandName="ck" CommandArgument='<%#Eval("coid") %>' runat="server" class="btn btn-info-outline">选课</asp:LinkButton>

            </ItemTemplate>    <ItemStyle Width="150px" />
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


