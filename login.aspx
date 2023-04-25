<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录-学生成绩管理系统</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1">
    <link rel="stylesheet" type="text/css" href="image/css/style.css" />

    <link href="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/theme/default/layer.min.css" rel="stylesheet">
    <script src="css/disk/jquery.js"></script>
    <script type="text/javascript" src="https://cdn.bootcdn.net/ajax/libs/layer/3.5.1/layer.js">

    </script>
</head>
<body class="login-page">
    <form id="form1" runat="server" style="height: 100%;">
        <section class="login-contain">
            <header>
                <h1>学生成绩管理系统</h1>
                <p>management system</p>
            </header>
            <div class="form-content">
                <ul>
                    <li>
                        <div class="form-group">
                            <label class="control-label">登录账号：</label>
                            <input type="text" placeholder="登录账号..." class="form-control form-underlined" id="adminName" runat="server">
                        </div>
                    </li>
                    <li>
                        <div class="form-group">
                            <label class="control-label">登录密码：</label>
                            <input type="password" placeholder="登录密码..." class="form-control form-underlined" id="adminPwd" runat="server">
                        </div>
                    </li>
                    <li></li>
                    <%-- <li>
 <div class="form-group">
<label class="control-label">用户身份：</label>
   <asp:DropDownList ID="DropDownList1" runat="server" Width="200">
                                <asp:ListItem>管理员</asp:ListItem>
                                <asp:ListItem>教师</asp:ListItem>
                                <asp:ListItem>学生</asp:ListItem>
                            </asp:DropDownList>

  </div></li>--%>

                    <li>
                        <asp:Button runat="server"   ID="hidBtn" Style="display: none" OnClick="Button1_Click"></asp:Button>
                        <asp:Button ID="Button1" runat="server" Text="立即登录" CssClass="btn btn-lg btn-block btn-primary" OnClientClick="return openValidate()"></asp:Button>

                    </li>
                    <li>
                        <p class="btm-info">©Copyright 2021 学生成绩管理系统</p>
                    </li>
                </ul>
            </div>
        </section>
        <div class="mask"></div>
    </form>
</body>

<script type="text/javascript">
    function openValidate() {
        layer.open({
            title: "",
            type: 2,
            area: ["500px", "500px"],
            shade: 0.4,
            closeBtn: 0,
            content: "slider.html"
        })
        return false;
    }
    //
    //    window.open("slider.html");
    //}
</script>
</html>

