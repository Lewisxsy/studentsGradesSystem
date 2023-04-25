using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class coursedetail : System.Web.UI.Page
{
    public System.Data.DataRow row = null;
    public System.Data.DataRow row2 = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if(!IsPostBack)
        {
            Repeater1.DataSource = DbHelperSQL.Query("select * from teachers where coid=" + id);
            Repeater1.DataBind();

            row = DbHelperSQL.Query("select * from course where coid=" + id).Tables[0].Rows[0];
            row2 = DbHelperSQL.Query("select * from coursetype where id=" + row["ptypeid"].ToString()).Tables[0].Rows[0];
        }
       
    }
}