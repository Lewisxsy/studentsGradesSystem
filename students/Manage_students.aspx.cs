  using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class students_List : System.Web.UI.Page
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

        ddlclid.Items.Insert(0, new ListItem("  ", ""));


            bind();
        }
    }

    /// <summary>
    /// 绑定学生
    /// </summary>
    private void bind()
    {       
        string where = " where 1=1 ";

        if (txt_sno.Text != "")
        {
            where += " and sno like '%" + txt_sno.Text + "%' ";
        }

        if (txt_stname.Text != "")
        {
            where += " and stname like '%" + txt_stname.Text + "%' ";
        }

        if (ddlspid.SelectedValue!= "")
        {
            where += " and a.spid=" + ddlspid.SelectedValue + "";
        }

        if (ddlclid.SelectedValue!= "")
        {
            where += " and a.clid=" + ddlclid.SelectedValue + "";
        }



        GridView1.DataSource = DbHelperSQL.Query("select a.*,b.spname,c.clname from students a  left join special b on a.spid=b.spid left join classes c on a.clid=c.clid " + where + " order by sno desc");
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
    /// 删除学生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     protected void btnDele_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        //设置删除sql
        string strSql = string.Format("delete from  students where sno='{0}'", btn.CommandName);

        //删除相应的记录
        DbHelperSQL.ExecuteSql(strSql);

        //重新绑定数据源
        bind();
    }



    protected void ddlspid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlclid.Items.Clear();
        if (ddlspid.SelectedValue != "")
        {
            ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes"+ " where spid="+ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();

        }
        ddlclid.Items.Insert(0, new ListItem("---全部---", ""));        
    }

}

