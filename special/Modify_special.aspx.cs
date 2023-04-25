using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class special_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化专业
            chushi();
        }
    }

    /// <summary>
    /// 初始化专业
    /// </summary>
    protected void chushi()
    {

        string strSql = string.Format("select * from special where  spid={0}", Request.QueryString["id"]);

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_spname.Text = ds.Tables[0].Rows[0]["spname"].ToString();
        }
    }

    /// <summary>
    /// 编辑专业
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   


        string strSql=String.Format(@"update special set 
                                    spname = '{0}',spcollege='"+TextBox1.Text+"' where spid='{1}'",
        txt_spname.Text,int.Parse(Request.QueryString["id"]));

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Manage_special.aspx';</script>");
    }



    
}

