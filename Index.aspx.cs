using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater1.DataSource = DbHelperSQL.Query("select top 10 * from course order by coid desc");
        Repeater1.DataBind();

        Repeater2.DataSource = DbHelperSQL.Query("select top 6 * from news order by id desc");
        Repeater2.DataBind();
    }
}