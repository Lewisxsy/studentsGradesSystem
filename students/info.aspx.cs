using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class students_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化学生
            chushi();
        }
    }

    /// <summary>
    /// 初始化学生
    /// </summary>
    protected void chushi()
    {
ddlspid.DataSource = DbHelperSQL.Query("select spid,spname from special");
            ddlspid.DataTextField = "spname";
            ddlspid.DataValueField = "spid";
            ddlspid.DataBind();


        string strSql = string.Format("select * from students where  sno='{0}'", Session["bh"].ToString());

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_sno.Text = ds.Tables[0].Rows[0]["sno"].ToString();
            txt_stname.Text = ds.Tables[0].Rows[0]["stname"].ToString();
            ddlsex.SelectedValue=ds.Tables[0].Rows[0]["sex"].ToString();
            txt_age.Text = ds.Tables[0].Rows[0]["age"].ToString();
            txt_tel.Text = ds.Tables[0].Rows[0]["tel"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            ddlspid.SelectedValue=ds.Tables[0].Rows[0]["spid"].ToString();
ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes"+ " where spid="+ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();

            ddlclid.SelectedValue=ds.Tables[0].Rows[0]["clid"].ToString();
        }
    }

    /// <summary>
    /// 编辑学生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   


        string strSql=String.Format(@"update students set 
                                    stname = '{0}',sex = '{1}',age = '{2}',tel = '{3}',email = '{4}',spid = {5},clid = {6}
                                    where sno='{7}'",
        txt_stname.Text,ddlsex.SelectedValue,txt_age.Text,txt_tel.Text,txt_email.Text,ddlspid.SelectedValue,ddlclid.SelectedValue,Session["bh"].ToString());

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改成功!');</script>");
    }



     protected void ddlspid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes"+ " where spid="+ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();

    }

}

