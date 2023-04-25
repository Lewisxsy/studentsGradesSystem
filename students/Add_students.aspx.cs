using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class students_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        ddlspid.DataSource = DbHelperSQL.Query("select spid,spname from special");
            ddlspid.DataTextField = "spname";
            ddlspid.DataValueField = "spid";
            ddlspid.DataBind();

ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes"+ " where spid="+ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();


        }
    }

    /// <summary>
    /// 添加学生
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
        //验证是否已经存在
        if (DbHelperSQL.Exists("select count(*) from students where sno='" + txt_sno.Text + "'"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('该学号已存在，请重新输入！');</script>");
            return;
        }

       
       //设置添加sql
       string strSql=String.Format(@"insert into students(sno,password,stname,sex,age,tel,email,spid,clid)
                                values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8})",
                                txt_sno.Text,txt_password.Text,txt_stname.Text,ddlsex.SelectedValue,txt_age.Text,txt_tel.Text,txt_email.Text,ddlspid.SelectedValue,ddlclid.SelectedValue);
        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());


        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Add_students.aspx';</script>");
    }

        protected void ddlspid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes"+ " where spid="+ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();

    }

}

