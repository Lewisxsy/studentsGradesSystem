using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class classes_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化班级
            chushi();
        }
    }

    /// <summary>
    /// 初始化班级
    /// </summary>
    protected void chushi()
    {
ddlspid.DataSource = DbHelperSQL.Query("select spid,spname from special");
            ddlspid.DataTextField = "spname";
            ddlspid.DataValueField = "spid";
            ddlspid.DataBind();


        string strSql = string.Format("select * from classes where  clid={0}", Request.QueryString["id"]);

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlspid.SelectedValue=ds.Tables[0].Rows[0]["spid"].ToString();
            txt_clname.Text = ds.Tables[0].Rows[0]["clname"].ToString();
        }
    }

    /// <summary>
    /// 编辑班级
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   


        string strSql=String.Format(@"update classes set 
                                    spid = {0},clname = '{1}'
                                    where clid='{2}'",
        ddlspid.SelectedValue,txt_clname.Text,int.Parse(Request.QueryString["id"]));

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Manage_classes.aspx';</script>");
    }



    
}

