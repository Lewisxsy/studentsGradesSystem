<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course.aspx.cs" Inherits="course" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/css/course.css">
    <title>课程列表</title>
</head>
<body>
    <div class="header clearfix">
        <div id="top">
            <h1 >成绩管理系统</h1>
        </div>  
    </div>

    <div class="container clearfix">
        <div class="search">
            <form action="course.aspx" method="get">
                <input type="text" class="txt" placeholder="请输入课程名称" name="key">
                <button type="submit">
                    <i><img class="search-ico" src="/img/search.ico" alt=""></i>
                </button>   
            </form>
        </div>
    </div>

    <div class="section1 clearfix">
        <div class="course-rcm clearfix">
                <ul>
                    <li class='item'>
                        <a href="course.aspx">
                           全部课程 
                        </a>
                    </li>
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <li class="list">
                        <a href="course.aspx?pid=<%#Eval("id") %>">
                            <%#Eval("typename") %>
                        </a>
                        <ul>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                     <li><a href="course.aspx?sid=<%#Eval("id") %>"> <%#Eval("typename") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
        </ItemTemplate>
    </asp:Repeater>
                  
                    
                </ul>
                <div class="hotclass main">
                    <span>热门课程 · · · · · · </span>
                    <!-- <a href="" target="blank"><更多></a> -->
                </div> 
        </div>
        <div class="courselist clearfix">
            <ul>
                 <asp:Repeater ID="Repeater3" runat="server">
                   <ItemTemplate>
                        <li>
                      <a href="coursedetail.aspx?id=<%#Eval("coid") %>">
                        <div class="item">
                            <img src="<%#Eval("img") %>" alt="">
                            <h1><%#Eval("coname") %></h1>
                            <div class="explain">
                                <%#Eval("comemo") %>
                            </div>
                        </div>
                    </a>
                </li>
                   </ItemTemplate>
               </asp:Repeater>   
            </ul>
        </div>
    </div>
    <a href="#top">
        <div class="totop">
            <span class="iconfont">
                &#xe61f;
            </span>
        </div>
    </a>
</body>
</html>
