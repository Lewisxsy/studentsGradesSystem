using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class scores_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcoid.DataSource = DbHelperSQL.Query("select coid,coname from course");
            ddlcoid.DataTextField = "coname";
            ddlcoid.DataValueField = "coid";
            ddlcoid.DataBind();

            ddlcoid.Items.Insert(0, new ListItem("  ", ""));
            bind();
        }
    }

    /// <summary>
    /// 绑定成绩
    /// </summary>
    private void bind()
    {

        string where = " where t.sno='" + Session["bh"].ToString() + "' ";

        if (ddlcoid.SelectedValue != "")
        {
            where += " and t.coid=" + ddlcoid.SelectedValue + "";
        }

        if (dyear.Text != "")
        {
            where += " and t.cyear=" + dyear.Text + "";
        }
        if (dteam.Text != "")
        {
            where += " and t.cteam='" + dteam.Text + "'";
        }

        GridView1.DataSource = DbHelperSQL.Query(@"SELECT *
FROM(SELECT    a.sno,
                    a.score,
                    a.id,
                    a.ordscore,
                    a.score * 0.6 + a.ordscore * 0.4 AS totalscore,
                    spname,
                    clname,
                    c.stname,
                    b.*,
                    e.spid,
                    c.clid
          FROM      scores a
                    LEFT JOIN course b ON a.coid = b.coid
                    LEFT JOIN students c ON a.sno = c.sno
                    LEFT JOIN special d ON c.spid = d.spid
                    LEFT JOIN classes e ON c.clid = e.clid
        ) t" + where + " order by id desc");
        GridView1.DataBind();

    }

    /// <summary>
    /// 分页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }


}

