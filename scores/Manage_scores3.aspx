<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="Manage_scores3.aspx.cs" Inherits="scores_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">管理成绩信息</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">
    <tr>
        <td align="center">
            <strong> 课程名称</strong><asp:DropDownList ID="ddlcoid" runat="server" Width="150">

</asp:DropDownList> 专业</strong><asp:DropDownList ID="ddlspid" runat="server" Width="150"  AutoPostBack="True" OnSelectedIndexChanged="ddlspid_SelectedIndexChanged">
</asp:DropDownList><strong> 班级</strong><asp:DropDownList ID="ddlclid" runat="server" Width="150">
</asp:DropDownList><strong> 学号:</strong><asp:TextBox ID="txt_sno" runat="server" width="150"></asp:TextBox>
<strong> 学年:</strong><asp:TextBox ID="dyear" runat="server" width="150"></asp:TextBox>
            <strong> 学期:</strong><asp:TextBox ID="dteam" runat="server" width="150"></asp:TextBox>


    <asp:Button ID="Button1" runat="server" Text="检 索"  class="btn btn-info-outline"  onclick="btnSearch_Click" />

        </td>
    </tr>
    <tr>
        <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle Height="25px" HorizontalAlign="Center" />
        <Columns>       
            <asp:BoundField HeaderText="课程名称" DataField="coname" />
            <asp:BoundField HeaderText="学年" DataField="cyear" />
            <asp:BoundField HeaderText="学期" DataField="cteam" />
            <asp:BoundField HeaderText="学号" DataField="sno" />
             <asp:BoundField HeaderText="姓名" DataField="stname" />
            <asp:BoundField HeaderText="专业" DataField="spname" />
            <asp:BoundField HeaderText="班级" DataField="clname" />
             <asp:BoundField HeaderText="日常分数" DataField="ordscore" />
            <asp:BoundField HeaderText="分数" DataField="score" />
            <asp:BoundField HeaderText="总分" DataField="totalscore" />
            <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
<asp:Button ID="btnDele" runat="server" Text="删除"  CausesValidation="False"   CommandName='<%#Eval("id") %>'  OnClick="btnDele_Click"  class="btn btn-info-outline" />
            </ItemTemplate>
             <ItemStyle Width="150px" />
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


