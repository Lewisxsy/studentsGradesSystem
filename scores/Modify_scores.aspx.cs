using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class scores_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化成绩
            chushi();
        }
    }

    /// <summary>
    /// 初始化成绩
    /// </summary>
    protected void chushi()
    {
        ddlcoid.DataSource = DbHelperSQL.Query("select coid,coname from course");
        ddlcoid.DataTextField = "coname";
        ddlcoid.DataValueField = "coid";
        ddlcoid.DataBind();


        string strSql = string.Format("select * from scores where  id={0}", Request.QueryString["id"]);

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcoid.SelectedValue = ds.Tables[0].Rows[0]["coid"].ToString();
            txt_sno.Text = ds.Tables[0].Rows[0]["sno"].ToString();
            txt_score.Text = ds.Tables[0].Rows[0]["score"].ToString();
            this.txtOrdscore.Text = ds.Tables[0].Rows[0]["ordscore"].ToString();
        }
    }

    /// <summary>
    /// 编辑成绩
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   


        string strSql = String.Format(@"update scores set 
                                    coid = {0},sno = '{1}',score = {2},ordscore='{3}'
                                    where id={4}",
        ddlcoid.SelectedValue, txt_sno.Text, decimal.Parse(txt_score.Text), decimal.Parse(txtOrdscore.Text), int.Parse(Request.QueryString["id"]));

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Manage_scores.aspx';</script>");
    }




}

