<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生成绩管理系统</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1">
    <link rel="stylesheet" type="text/css" href="image/css/style.css" />
    <script src="image/js/jquery.js"></script>
    <script src="image/js/customScrollbar.min.js"></script>
    <script src="image/js/echarts.min.js"></script>
    <script src="image/js/plug-ins/layerUi/layer.js"></script>
    <script src="image/js/ueditor.config.js"></script>
    <script src="image/js/ueditor.all.js"></script>
    <script src="image/js/pagination.js"></script>
    <script src="image/js/public.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-wrap">
            <div class="side-nav">
                <div class="side-logo">
                    <div class="logo">
                        <span class="logo-ico">
                            <i class="i-l-1"></i>
                            <i class="i-l-2"></i>
                            <i class="i-l-3"></i>
                        </span>
                        <strong>学生成绩管理系统</strong>
                    </div>
                </div>

                <nav class="side-menu content mCustomScrollbar" data-mcs-theme="minimal-dark">
                    <h2>
                        <a href="#" class="InitialPage"><i class="icon-dashboard"></i>菜单列表</a>
                    </h2>
                    <ul>
                        <% if (Session["qx"] != null)
                            { %>
                        <% if (Session["qx"].ToString() == "管理员")
                            { %>




                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>基础信息管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="special/Add_special.aspx" target="right">添加专业信息</a>
                                </dd>
                                <dd>
                                    <a href="special/Manage_special.aspx" target="right">管理专业信息</a>
                                </dd>
                                <dd>
                                    <a href="classes/Add_classes.aspx" target="right">添加班级信息</a>
                                </dd>
                                <dd>
                                    <a href="classes/Manage_classes.aspx" target="right">管理班级信息</a>
                                </dd>
                            </dl>
                        </li>


                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>教师管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="teachers/Add_teachers.aspx" target="right">添加教师信息</a>
                                </dd>
                                <dd>
                                    <a href="teachers/Manage_teachers.aspx" target="right">管理教师信息</a>
                                </dd>
                            </dl>
                        </li>


                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>学生管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="students/Add_students.aspx" target="right">添加学生信息</a>
                                </dd>
                                <dd>
                                    <a href="students/Manage_students.aspx" target="right">管理学生信息</a>
                                </dd>
                            </dl>
                        </li>


                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>课程管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="course/Add_course.aspx" target="right">添加课程信息</a>
                                </dd>
                                <dd>
                                    <a href="course/Manage_course.aspx" target="right">管理课程信息</a>
                                </dd>
                            </dl>
                        </li>


                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>成绩管理<i class="icon-angle-right"></i>
                                </dt>

                                <dd>
                                    <a href="scores/Manage_scores3.aspx" target="right">管理成绩信息</a>
                                </dd>
                            </dl>
                        </li>

                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>新闻管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="news/modify.aspx" target="right">添加新闻</a>
                                </dd>
                                <dd>
                                    <a href="news/list.aspx" target="right">管理新闻</a>
                                </dd>
                            </dl>
                        </li>

                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>统计查询<i class="icon-angle-right"></i>
                                </dt>

                                <dd>
                                    <a href="total/total1.aspx" target="right">总成绩统计</a>
                                </dd>
                                <dd>
                                    <a href="scores/Manage_scores4.aspx" target="right">不及格学生列表</a>
                                </dd>
                                <dd>
                                    <a href="total/total2.aspx" target="right">成绩统计</a>
                                </dd>

                            </dl>
                        </li>



                        <li>
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>系统管理<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="system/adminpass.aspx" target="right">修改登录密码</a>
                                </dd>
                            </dl>
                        </li>

                        <%} %>

                        <%  if (Session["qx"].ToString() == "学生")
                            { %>

                        <li class="open">
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>菜单列表<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="students/info.aspx" target="right">修改个人信息</a>
                                </dd>
                                <dd>
                                    <a href="course/Manage_course3.aspx" target="right">课程信息</a>
                                </dd>
                                <dd>
                                    <a href="scores/Manage_scores2.aspx" target="right">我的成绩</a>
                                </dd>
                                <dd>
                                    <a href="system/studentspass.aspx" target="right">修改登录密码</a>
                                </dd>
                                <dd>
                                    <a href="course/studentcourse.aspx" target="right">我的选课管理</a>
                                </dd>

                                <dd>
                                    <a href="course/ShowCourse.aspx" target="right">课程表</a>
                                </dd>
                            </dl>
                        </li>

                        <%} %>

                        <%  if (Session["qx"].ToString() == "教师")
                            { %>

                        <li class="open">
                            <dl>
                                <dt>
                                    <i class="icon-columns"></i>菜单列表<i class="icon-angle-right"></i>
                                </dt>
                                <dd>
                                    <a href="teachers/info.aspx" target="right">修改个人信息</a>
                                </dd>
                                <dd>
                                    <a href="course/Manage_course2.aspx" target="right">我任教的课程</a>
                                </dd>
                                <dd>
                                    <a href="scores/ScoreByCoid.aspx" target="right">录入成绩</a>
                                </dd>
                                <dd>
                                    <a href="scores/Manage_scores.aspx" target="right">管理成绩信息</a>
                                </dd>
                                <dd>
                                    <a href="scores/Manage_scores5.aspx" target="right">不及格学生列表</a>
                                </dd>
                                <dd>
                                    <a href="total/total3.aspx" target="right">成绩统计</a>
                                </dd>
                                <dd>
                                    <a href="system/teacherspass.aspx" target="right">修改登录密码</a>
                                </dd>
                            </dl>
                        </li>

                        <%} %>

                        <%} %>
                    </ul>
                </nav>
                <footer class="side-footer"></footer>
            </div>
            <div class="content-wrap">
                <header class="top-hd">
                    <div class="hd-lt">
                        <a class="icon-reorder"></a>
                    </div>
                    <div class="hd-rt">
                        <ul>


                            <li>
                                <a><i class="icon-user"></i>
                                    <asp:Literal ID="lt2" runat="server"></asp:Literal>:<em><asp:Literal ID="lt1" runat="server"></asp:Literal></em></a>
                            </li>

                            <li>
                                <a href="javascript:void(0)" id="JsSignOut"><i class="icon-signout"></i>安全退出</a>
                            </li>
                        </ul>
                    </div>
                </header>
                <main class="main-cont content mCustomScrollbar" style="height: 100%">
                    <!--开始::内容-->



                    <iframe scrolling="auto" frameborder="0" src="main.aspx" name="right" width="100%" height="100%"></iframe>

                    <!--开始::结束-->
                </main>
                <footer class="btm-ft">
                    <p class="clear">
                        <span class="fl">©Copyright 2021 学生成绩管理系统</span>

                    </p>
                </footer>
            </div>
        </div>
    </form>
</body>
</html>

