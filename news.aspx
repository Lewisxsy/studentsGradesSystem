<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/css/news.css">
    <style>
     .search {
    float: left;
    width: 400px;
    height: 50px;
    margin-left: 300px;
    position: relative;
    margin-top: 10px;
}
     .container .search .txt {
    width: 380px;
    height: 36px;
    padding: 5px;
    font-size: 20px;
    line-height: 36px;
    margin-top: 10px;
}
     .container .search button {
    position: absolute;
    width: 48px;
    height: 48px;
    top: 11px;
    left: 345px;
    border: none;
}
    </style>
    <title>湖大学子</title>
</head>
<body>
    <div class="header">
        <img src="/img/hubu.png">
    </div>
    <div class="container">
        <div class="search">
            <form action="news.aspx" method="get">
                <input type="text" class="txt" placeholder="请输入新闻名称" name="key">
                <button type="submit">
                    <i><img class="search-ico" src="/img/search.ico" alt=""></i>
                </button>   
            </form>
        </div>
        <img src="/img/news.jpeg" alt="">

        <div class="aside-left clearfix">
            <div class="list">
                <div class="index">
                    网站首页
                </div>
                <ul>
                    <li><a href="news.aspx?id=综合新闻">综合新闻</a></li>
                    <li><a href="news.aspx?id=湖大学子">湖大学子</a></li>
                    <li><a href="news.aspx?id=疫情防控">疫情防控</a></li>
                    <li><a href="news.aspx?id=不忘初心，牢记使命">不忘初心，牢记使命</a></li>
                   
                    <li><a href=""></a></li>
                    <li><a href=""></a></li>
                    <li><a href=""></a></li>
                    <li><a href=""></a></li>

                </ul>
            </div>
            <div class="recommend">
                <div class="tit">
                    推荐新闻
                    <div class="more">
                        <a href="#">
                            <img src="/img/more.jpeg">
                        </a>
                    </div>
                    
                </div>
                <ul>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36489.htm " target="_blank">省长王忠林到湖北大学调研</a></li>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36458.htm" target="_blank">田子渝教授荣获湖北省第二届“最美社科人”称号</a></li>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36433.htm" target="_blank">扎根荆楚建设一流大学</a></li>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36419.htm" target="_blank">我校获批19项国家社科基金项目</a></li>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36390.htm" target="_blank">我校软件工程专业接受中国工程教育专业认证专家组现场考查</a></li>
                    <li><a href="https://www.hubu.edu.cn/info/1316/36363.htm" target="_blank">【党风廉政教育】学校开展警示教育暨党风廉政建设宣教月活动推进会</a></li>
                </ul>
            </div>
        </div>
            
        <div class="text clearfix">
            <div class="header2">
                <span class="title"><%=Request.QueryString["id"]??"新闻信息" %>
                </span>
                <span class="local">您的当前位置:&nbsp;
                    <a href="index.aspx">网站首页 > </a>
                    <a href="news.aspx?id=<%=Request.QueryString["id"] %>"><%=Request.QueryString["id"]??"新闻信息" %></a>
                </span>
            </div>
            <div class="content">
                <ul>
                   
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                             <li><a href="newsinfo.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>

    <div class="footer">
        <img src="/img/F6AEA146-3006-4408-9EAE-20E3E226CC2B.png" width="1440px" alt="">
    </div>
</body>
</html>
