using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["bh"] == null)
        {
            Response.Write("<script>top.location='login.aspx';</script>");
            Response.End();
        }

        if (!IsPostBack)
        {
            lt1.Text = Session["mc"].ToString();
            lt2.Text = Session["qx"].ToString();
        }
    }
}