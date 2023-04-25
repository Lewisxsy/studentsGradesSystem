using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class scores_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcoid.DataSource = DbHelperSQL.Query("select coid,coname from course");
            ddlcoid.DataTextField = "coname";
            ddlcoid.DataValueField = "coid";
            ddlcoid.DataBind();

            ddlcoid.SelectedValue = Session["coid"].ToString();
            ddlcoid.Enabled = false;

            this.txt_sno.Text = Request.QueryString["sno"].ToString();
            this.txt_sno.ReadOnly = true;
        }
    }

    /// <summary>
    /// 添加成绩
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //验证是否已经存在
        if (!DbHelperSQL.Exists("select count(*) from students where sno='" + txt_sno.Text + "'"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('该学号不存在，请重新输入！');</script>");
            return;
        }
        if (DbHelperSQL.Exists("select count(*) from scores where sno='" + txt_sno.Text + "' and coid=" + ddlcoid.SelectedValue))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('该学生该课程成绩已添加！');</script>");
            return;
        }

        //设置添加sql
        string strSql = String.Format(@"insert into scores(coid,sno,score,ordScore)
                                values ({0},'{1}',{2},{3})",
                                ddlcoid.SelectedValue, txt_sno.Text, decimal.Parse(txt_score.Text), decimal.Parse(this.txt_OrderScore.Text));
        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());


        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');parent.layer.closeAll();parent.location.reload();</script>");
    }


}

