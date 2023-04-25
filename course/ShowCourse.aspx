<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="ShowCourse.aspx.cs" Inherits="course_ShowCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/3.3.7/css/bootstrap.min.css">
    <style type="text/css">
        table {
            width: 100%;
            border: 1px solid #ccc;
            padding: 10px;
            text-align: center;
        }

            table td {
                width: 20%;
                height: 30px;
                line-height: 30px;
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-wrap">
        <section class="page-hd">
            <header>
                <h2 class="title">课程表管理</h2>

            </header>
            <hr>
        </section>

        <div id="courseRandom" class="courseRandom" runat="server">
        </div>
    </div>
</asp:Content>

