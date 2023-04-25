<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsinfo.aspx.cs" Inherits="newsinfo" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/css/news.css">
    <title>综合新闻</title>
</head>

<body>
    <div class="header">
        <img src="/img/hubu.png">
    </div>
    <div class="container">
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
                <span class="title">综合新闻</span>
                <span class="local">您的当前位置:&nbsp;
                    <a href="index.aspx">网站首页 > </a>
                    <a href="news.aspx">新闻</a>
                </span>
            </div>
            <div class="content">
                <div class="content-con">
                    <div class="con-title">
                        <div class="con-title h3">
                            <div class="xwy">
                                <h1><%=row["title"].ToString() %></h1>
                            </div>
                        </div>
                        <h4 style=" font-size:16px; line-height:35px; padding:10px 0px;"></h4>

                       <div style="text-align:center;padding-bottom:10px;">
                            <i>作者：<%=row["puber"].ToString() %> 
                            &nbsp;发布时间：<%=row["createtime"].ToString() %> </i>
                       </div>
                            <p> </p>
                            <p></p>
                    </div>
                    <div class="content">
                        <div  style="text-align:center">
                            <img src=" <%=row["img"].ToString() %>" />
                        </div>
                        <div class="v_news_content" style="padding-top:10px;text-indent:2em">
                            
                            <p class="vsbcontent_start"> <%=row["msg"].ToString() %></p>
                          
                        </div>
                    
                        <div id="div_vote_id"></div>
                       
                    </div>
                    
                    <div class="clear"></div>
                </div>
            </div>

            <div class="footer">
                <img src="/img/F6AEA146-3006-4408-9EAE-20E3E226CC2B.png" width="1440px" alt="">
            </div>
</body>
</html>
