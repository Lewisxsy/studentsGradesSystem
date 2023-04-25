using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class teachers_info : System.Web.UI.Page
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


        string strSql = string.Format("select * from teachers where  tno='{0}'", Session["bh"].ToString());

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_tno.Text = ds.Tables[0].Rows[0]["tno"].ToString();
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
                                    tname = '{0}',sex = '{1}',job = '{2}',tel = '{3}',email = '{4}',memo = '{5}'
                                    where tno='{6}'",
        txt_tname.Text,ddlsex.SelectedValue,txt_job.Text,txt_tel.Text,txt_email.Text,txt_memo.Text,Session["bh"].ToString());

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改成功!');</script>");
    }



 
}

