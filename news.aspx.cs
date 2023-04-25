using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bind();
        }
    }

    public void Bind()
    {
        string str = " where 1=1 ";
        if(!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            str += "and typename='" + Request.QueryString["id"] + "'";
        }
        if (!string.IsNullOrEmpty(Request.QueryString["key"]))
        {
            str += " and title like '%" + Request.QueryString["key"] + "%'";
        }
        string sql = "select * from news " + str + " order by id desc";
        Repeater1.DataSource = DbHelperSQL.Query(sql).Tables[0];
        Repeater1.DataBind();
    }
}