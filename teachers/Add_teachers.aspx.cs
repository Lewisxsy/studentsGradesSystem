using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class teachers_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        ddlcoid.DataSource = DbHelperSQL.Query("select coid,coname from course");
            ddlcoid.DataTextField = "coname";
            ddlcoid.DataValueField = "coid";
            ddlcoid.DataBind();


        }
    }

    /// <summary>
    /// 添加教师
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
        //验证是否已经存在
        if (DbHelperSQL.Exists("select count(*) from teachers where tno='" + txt_tno.Text + "'"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('该教师编号已存在，请重新输入！');</script>");
            return;
        }

       
       //设置添加sql
       string strSql=String.Format(@"insert into teachers(tno,password,tname,sex,job,tel,email,memo,coid)
                                values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})",
                                txt_tno.Text,txt_password.Text,txt_tname.Text,ddlsex.SelectedValue,txt_job.Text,txt_tel.Text,txt_email.Text,txt_memo.Text,ddlcoid.SelectedValue);
        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());


        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Add_teachers.aspx';</script>");
    }

    
}

