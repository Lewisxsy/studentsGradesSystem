using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class teachers_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化教师
            chushi();
        }
    }

    /// <summary>
    /// 初始化教师
    /// </summary>
    protected void chushi()
    {
ddlcoid.DataSource = DbHelperSQL.Query("select coid,coname from course");
            ddlcoid.DataTextField = "coname";
            ddlcoid.DataValueField = "coid";
            ddlcoid.DataBind();


        string strSql = string.Format("select * from teachers where  tno='{0}'", Request.QueryString["id"]);

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_tno.Text = ds.Tables[0].Rows[0]["tno"].ToString();
            txt_password.Text = ds.Tables[0].Rows[0]["password"].ToString();
            txt_tname.Text = ds.Tables[0].Rows[0]["tname"].ToString();
            ddlsex.SelectedValue=ds.Tables[0].Rows[0]["sex"].ToString();
            txt_job.Text = ds.Tables[0].Rows[0]["job"].ToString();
            txt_tel.Text = ds.Tables[0].Rows[0]["tel"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txt_memo.Text = ds.Tables[0].Rows[0]["memo"].ToString();
            ddlcoid.SelectedValue = ds.Tables[0].Rows[0]["coid"].ToString();
        }
    }

    /// <summary>
    /// 编辑教师
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   


        string strSql=String.Format(@"update teachers set 
                                    tno = '{0}',password = '{1}',tname = '{2}',sex = '{3}',job = '{4}',tel = '{5}',email = '{6}',memo = '{7}',coid={8}
                                    where tno='{9}' ",
        txt_tno.Text,txt_password.Text,txt_tname.Text,ddlsex.SelectedValue,txt_job.Text,txt_tel.Text,txt_email.Text,txt_memo.Text,ddlcoid.SelectedValue ,int.Parse(Request.QueryString["id"]));

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Manage_teachers.aspx';</script>");
    }



    
}

