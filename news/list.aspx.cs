using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        string where = " where 1=1 ";

        if (txt_coname.Text != "")
        {
            where += " and title like '%" + txt_coname.Text + "%' ";
        }



        GridView1.DataSource = DbHelperSQL.Query("select * from news "+where+" order by id desc");
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

    /// <summary>
    /// 删除课程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDele_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        //设置删除sql
        string strSql = string.Format("delete from  news where id={0}", btn.CommandName);

        //删除相应的记录
        DbHelperSQL.ExecuteSql(strSql);

        //重新绑定数据源
        bind();
    }
}