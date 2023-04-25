<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="/css/homePage.css" rel="stylesheet">
    <title>首页</title>
</head>
<body>
    <div class="header">
        <img class="hubu-img" src="/img/湖北大学.png" alt="湖北大学">
    </div>
    <div class="container clearfix">
        <div class="system-out">
            <div class="system-font">
                <h3>成绩管理系统</h3>
                
            </div>
            <div class="search">
                <img src="/img/管理员.ico" >            
                <p> <a href="default.aspx" target="parent" >登录</a></p>
            </div>

        </div>
        <div class="nav">
            <div class="index">
                <a href="Index.aspx" target="blank">首页</a>
            </div>
            <div class="course">
                <a href="course.aspx" target="blank">课程库</a>
            </div>

        </div>

        <div class="news1">
            <div class="bannerimage">
                <div class='box'>
                    <div class='img-g' style='left: 0px; transition: left 1s;'>
                        <img src="/img/img_1.jpg" alt="1">
                        <img src="/img/img_2.jpg" alt="2">
                        <img src="/img/img_3.jpg" alt="3">
                        <img src="/img/img_4.jpg" alt="4">
                        <img src="/img/img_5.jpg" alt="5">
                        <img src="/img/img_6.jpg" alt="6">
                        <img src="/img/img_1.jpg" alt="1">
                    </div>
                    <div class='button-g'>
                        <span data-index='0' style="background-color: #eeeeee"></span>
                        <span data-index='1' style="background-color: rgba(255, 255, 255, 0.5)"></span>
                        <span data-index='2' style="background-color: rgba(255, 255, 255, 0.5)"></span>
                        <span data-index='3' style="background-color: rgba(255, 255, 255, 0.5)"></span>
                        <span data-index='4' style="background-color: rgba(255, 255, 255, 0.5)"></span>
                        <span data-index='5' style="background-color: rgba(255, 255, 255, 0.5)"></span>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="news">
        <div class="hudayaowen">
            湖大要闻
       
        </div>
        <a href="news.aspx" target="_blank">
            <div class="news_more">
                more>>
           
            </div>
        </a>
        <div class="newscharts clearfix">

            <ul class="img">
                <li class="active"><a href="">
                    <img src="/img/newschart_01.jpg" alt=""></a></li>
                <li><a href="">
                    <img src="/img/newschart_02.jpg" alt=""></a></li>
                <li><a href="">
                    <img src="/img/newschart_03.jpg" alt=""></a></li>
                <li><a href="">
                    <img src="/img/newschart_04.jpg" alt=""></a></li>
                <li><a href="">
                    <img src="/img/newschart_05.png" alt=""></a></li>
                <li><a href="">
                    <img src="/img/newschart_06.jpg" alt=""></a></li>
            </ul>

            <div class="leftBtn"></div>
            <div class="rightBtn"></div>

            <div class="circle">
                <span class="active"></span>
                <span></span>
                <span></span>
                <span></span>
                <span></span>
                <span></span>
            </div>
        </div>
        <div class="newslist clearfix">
            <ul>
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="newsinfo.aspx?id=<%#Eval("id") %>" target="blank">
                                <div class="item clearfix">
                                    <img src="<%#Eval("img") %>" alt="" class="img-thummb">
                                    <div>
                                        <h3><%#Eval("title") %></h3>
                                    </div>
                                </div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>


            </ul>
        </div>
    </div>

    <div class="coursenav clearfix">
        <div class="remen_course">最新热门课程</div>
        <a href="course.aspx" class="more">
            <div class="more">更多>></div>
        </a>
        <br>
        <div class="courselist clearfix">
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="coursedetail.aspx?id=<%#Eval("coid") %>">
                                <div class="item">
                                    <img src="<%#Eval("img") %>" alt="" class="img-thummb">
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
    <div class="footer" style="text-align: center">
        
        <img class="footer-img" src="/img/页脚.png" alt="">
    </div>
    <script src="/js/newscharts.js"></script>
</body>
</html>



<script type="text/javascript" src="/js/jquery-3.6.0.min.js">
</script>

<script type="text/javascript">
    $(function () {
        // 实现自动播放
        var p = document.getElementsByClassName('img-g')[0];
        var button = document.querySelectorAll('.button-g span')
        // 设置3秒播放
        window.timer = setInterval(move, 3000);
        // 轮播设置
        function move() {
            // bannerimage的宽度乘以图片的个数
            if (parseInt(p.style.left) > -7200) {
                // 和bannerimage的宽度保持一致即可：1000
                p.style.left = parseInt(p.style.left) - 1200 + 'px'
                p.style.transition = 'left 1s';
                tog(-Math.round(parseInt(p.style.left) / 1200))
                if (parseInt(p.style.left) <= -7200) {
                    setTimeout(function () {
                        tog(0)
                        p.style.left = '0px'
                        p.style.transition = 'left 0s';
                    }, 1000)
                }
            } else {
                p.style.left = '0px'
                p.style.transition = 'left 0s';
            }


        }

        // 设置小圆点
        for (var i = 0; i < button.length; i++) {
            // button[i].style.backgroundColor='#eee';
            button[i].onclick = function () {
                p.style.left = -1200 * this.getAttribute('data-index') + 'px'
                tog(this.getAttribute('data-index'))
                clearInterval(window.timer)
                window.timer = setInterval(move, 3000);
            }
        }
        // 设置小圆点
        function tog(index) {
            if (index > 5) {
                tog(0);
                return;
            }
            for (var i = 0; i < button.length; i++) {
                button[i].style.backgroundColor = 'rgba(255, 255, 255, 0.5)';
            }
            button[index].style.backgroundColor = 'rgb(255, 255, 255)';
        }

        // 鼠标移上事件
        p.onmouseover = function () {
            clearInterval(window.timer)
        }
        // 鼠标移除事件
        p.onmouseout = function () {
            window.timer = setInterval(move, 3000);
        }
    });
	</script>

