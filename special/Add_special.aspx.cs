using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class special_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        }
    }

    /// <summary>
    /// 添加专业
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
       
       //设置添加sql
       string strSql=String.Format(@"insert into special(spname,spcollege)
                                values ('{0}','{1}')",
                                txt_spname.Text,TextBox1.Text);
        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());


        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Add_special.aspx';</script>");
    }

    
}

