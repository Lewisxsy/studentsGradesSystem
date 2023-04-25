<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" ValidateRequest="false"  CodeFile="total1.aspx.cs" Inherits="classes_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-wrap">
				<section class="page-hd">
					<header>
						<h2 class="title">总成绩统计</h2>
						
					</header>
					<hr>
				</section>
				
	
				<table class="auto-style1">
                       
                    <tr><td valign="top">

                            <table style="width:100%;">

    <tr>
        <td>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Width="100%" GridLines="None" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
        <RowStyle Height="25px" HorizontalAlign="Center" />
        <Columns>       
           <asp:TemplateField ControlStyle-Width="50" HeaderText="名次"    >
                    <ItemTemplate>
                         第<font style="color:red; font-size:14px;"><%#Container.DataItemIndex+1%></font>名
                    </ItemTemplate>

<ControlStyle Width="50px"></ControlStyle>

                    <ItemStyle Width="50px" />
                </asp:TemplateField>  
        </Columns>
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>

            
            
        </td>
    </tr>
</table>   <table width="100%">
      
<tr><td align="center" style="text-align:center;">

    <input id="Button1" type="button" value="打印报表"  class="btn btn-info-outline" onclick="window.print();" />
    <asp:Button ID="Button2" runat="server" Text="导出为Excel文档"  class="btn btn-info-outline" OnClick="Button2_Click" />
    </td></tr>
    </table>

                        </td></tr>
                    </table>
			</div>
     
</asp:Content>


