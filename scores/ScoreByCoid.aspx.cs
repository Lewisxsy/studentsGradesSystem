using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class scores_ScoreByCoid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    /// <summary>
    /// 绑定学生
    /// </summary>
    private void bind()
    {
        string where = " where 1=1";
        if (txt_sno.Text != "")
        {
            where += " and s.sno like '%" + txt_sno.Text + "%' ";
        }

        GridView1.DataSource = DbHelperSQL.Query(@"SELECT  *,(scs.ordScore*0.6)+(scs.score*0.4) AS totalscore
FROM    dbo.students s
        INNER JOIN[dbo].[studentcourse] sc
        INNER JOIN dbo.course c ON sc.coid = c.coid ON s.sno = sc.sno
        AND sc.coid =  " + Session["coid"].ToString() + " INNER JOIN dbo.classes cs ON s.clid=cs.clid 	" +
        "left JOIN dbo.scores scs ON s.sno=scs.sno AND scs.coid=sc.coid" + where);
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


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!string.IsNullOrEmpty(e.Row.Cells[6].Text.Trim()) && e.Row.Cells[6].Text.Trim() != "&nbsp;")
            {
                Button b = ((Button)e.Row.FindControl("btnScore"));
                b.Visible = false;
            }
            else
            {
                string pa = e.Row.Cells[3].Text;//模板列取字段数值
                ((Button)e.Row.FindControl("btnScore")).Attributes.Add("onclick", "return scores('" + pa + "')");
            }
        }

    }
}

