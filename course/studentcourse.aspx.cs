using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class course_studentcourse : System.Web.UI.Page
{
    string bh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bh = Session["bh"].ToString();
        if (!IsPostBack)
        {

            bind();
        }
    }

    /// <summary>
    /// 绑定课程
    /// </summary>
    private void bind()
    {

        GridView1.DataSource = DbHelperSQL.Query("select cr.* from studentcourse sc left join course cr on sc.coid=cr.coid where sc.sno='"+bh+"'");
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





    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        if (cmd == "ck")
        {
            string id = e.CommandArgument.ToString();
            string sql = string.Format("delete from studentcourse where sno='{0}' and coid={1}", bh, id);
            DbHelperSQL.ExecuteSql(sql);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功');</script>");
            bind();
        }
    }
}