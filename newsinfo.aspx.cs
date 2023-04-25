using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsinfo : System.Web.UI.Page
{
    public System.Data.DataRow row = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (!IsPostBack)
        {
            row = DbHelperSQL.Query("select * from news where id=" + id).Tables[0].Rows[0];         
        }
    }
}