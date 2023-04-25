  using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class classes_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
ddlspid.DataSource = DbHelperSQL.Query("select spid,spname from special");
            ddlspid.DataTextField = "spname";
            ddlspid.DataValueField = "spid";
            ddlspid.DataBind();

        ddlspid.Items.Insert(0, new ListItem("  ", ""));


            bind();
        }
    }

    /// <summary>
    /// 绑定班级
    /// </summary>
    private void bind()
    {       
        string where = " where 1=1 ";

        if (ddlspid.SelectedValue!= "")
        {
            where += " and a.spid=" + ddlspid.SelectedValue + "";
        }



        GridView1.DataSource = DbHelperSQL.Query("select a.*,b.* from classes a  left join special b on a.spid=b.spid " + where );
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
    /// 删除班级
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     protected void btnDele_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        //设置删除sql
        string strSql = string.Format("delete from  classes where clid={0}", btn.CommandName);

        //删除相应的记录
        DbHelperSQL.ExecuteSql(strSql);

        //重新绑定数据源
        bind();
    }




}

