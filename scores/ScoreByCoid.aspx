<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="ScoreByCoid.aspx.cs" Inherits="scores_ScoreByCoid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-wrap">
        <section class="page-hd">
            <header>
                <h2 class="title">管理成绩信息</h2>

            </header>
            <hr>
        </section>


        <table class="auto-style1">

            <tr>
                <td valign="top">

                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <strong>学号:</strong><asp:TextBox ID="txt_sno" runat="server" Width="150"></asp:TextBox>

                                <asp:Button ID="Button1" runat="server" Text="检 索" class="btn btn-info-outline" OnClick="btnSearch_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                    <RowStyle Height="25px" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField HeaderText="课程名称" DataField="coname" />
                                        <asp:BoundField HeaderText="学年" DataField="cyear" />
                                        <asp:BoundField HeaderText="学期" DataField="cteam" />
                                        <asp:BoundField HeaderText="学号" DataField="sno" />
                                        <asp:BoundField HeaderText="姓名" DataField="stname" />
                                        <asp:BoundField HeaderText="班级" DataField="clname" />
                                        <asp:BoundField HeaderText="日常分数" DataField="ordScore" />
                                        <asp:BoundField HeaderText="考试分数" DataField="score" />
                                        <asp:BoundField HeaderText="分数" DataField="totalscore" />


                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:Button ID="btnScore" runat="server" Text="录入成绩" CausesValidation="False" CommandName='<%#Eval("sno") %>' class="btn btn-info-outline" />
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" />
                                </asp:GridView>



                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </div>

    <link href="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/theme/default/layer.min.css" rel="stylesheet">
    <script src="../css/disk/jquery.js"></script>
    <script type="text/javascript" src="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/layer.js">
    </script>
    <script type="text/javascript">
        function scores(sno) {
            layer.open({
                title: "录入成绩",
                type: 2,
                area: ["800px", "800px"],
                closeBtn: 2,
                shade: 0.4,
                closeBtn: 0,
                content: "Add_scores.aspx?sno=" + sno
            })
            return false;
        }
    </script>
</asp:Content>


