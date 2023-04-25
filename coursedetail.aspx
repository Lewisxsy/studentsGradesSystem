<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coursedetail.aspx.cs" Inherits="coursedetail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/css/detail.css">
    <title>课程详情</title>
</head>
<body>
    <div class="header">
        <div class="title">
            课程详情
        </div>
        <div class="hubu-logo">
            <img src="../img/hubu-logo.png" alt="">
        </div>
        
    </div>

    <div class="container clearfix">
        <div class="book">
            <img  src="<%=row["img"].ToString() %>" alt="">
        </div>

        <div class="info clearfix">
            <ul>
               <%-- <li>作者：谭浩强</li>
                <li>出版社：清华大学出版社</li>--%>
                <li>类别：<%=row2["typename"].ToString()%></li>
                <li>学分：<%=row["coscore"].ToString() %></li>
                <%--<li>先修课程：c语言程序设计</li>--%>
                <%--<li>授课老师：###，###，###</li>--%>
                <li>课时：<%=row["cotime"].ToString() %>学时</li>

            </ul>
        </div>

    </div>

    <div class="content clearfix">
        <div class="aside-right clearfix">
            <div class="logo clearfix">
                <img class="logo1" src="../img/湖北大学.png" alt="">
            </div>
            <div class="teacher">
                <span>|</span>授课老师
            </div>
            <div class="box">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="smallbox clearfix">
                    <div class="circle">
                    </div>
                    <div class="information">
                        <ul>
                            <li><%#Eval("tname") %></li>
                            <li><span><%#Eval("job") %></span></li>
                        </ul>
                    </div>
                </div>
                    </ItemTemplate>
                </asp:Repeater>

                 

                
            </div>
        </div>

        <div class="main clearfix">
            <div class="sec-box">
                <div class="header2">
                    <div class="head">
                        课程详情
                    </div>
                </div>
            
            </div>

            <div class="introduction">
                <span class="icon">
                    <i><img  src="../img/课程.ico" alt=""></i>
                </span>
                <span class="intro">
                    课程概述
                </span>

                <div class="neirong">
                 <%=row["comemo"].ToString() %>
                    </div>
                
                <br>
                <br>
                <br>


                <%--<div class="aim">
                    <span ><img src="../img/博士帽.png" alt=""></span>
                    <div class="text">授课目标</div>
                    <div class="neirong">
                        学生通过本课程学习应达到如下目标：
                            <p>课程目标 1：掌握 C 语言的语法规则、程序结构、常用算法的设计方法。</p>
                            <p> 课程目标 2：具备使用集成开发环境进行程序设计、调试的综合能力；培养学生良好
                            的编程能力和风格。</p>
                            <p>课程目标 3：掌握模块化程序设计的方法，能正确分析现实生活中的问题，并抽象成
                                数学模型，进行模块分析和编程，具备初步的软件开发能力。</p>
                            <p>课程目标 4：培养学生严谨、求实、一丝不苟的工作作风和精益求精的工匠精神.</p>
                    </div>
                </div>--%>
            </div>
        </div>    
    </div>



</body>
</html>