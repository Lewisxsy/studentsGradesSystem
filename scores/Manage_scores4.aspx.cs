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
    /// 绑定成绩
    /// </summary>
    private void bind()
    {       
        string where = " where a.score<60 ";

        if (ddlcoid.SelectedValue!= "")
        {
            where += " and a.coid=" + ddlcoid.SelectedValue + "";
        }

        if (txt_sno.Text != "")
        {
            where += " and a.sno like '%" + txt_sno.Text + "%' ";
        }


        if (ddlspid.SelectedValue != "")
        {
            where += " and c.spid=" + ddlspid.SelectedValue + "";
        }

        if (ddlclid.SelectedValue != "")
        {
            where += " and c.clid=" + ddlclid.SelectedValue + "";
        }


        GridView1.DataSource = DbHelperSQL.Query("select a.*,b.coname,spname,clname,c.stname,b.* from scores a  left join course b on a.coid=b.coid left join students c on a.sno=c.sno left join special d on c.spid=d.spid left join classes e on c.clid=e.clid" + where + " order by id desc");
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
    /// 删除成绩
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     protected void btnDele_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        //设置删除sql
        string strSql = string.Format("delete from  scores where id={0}", btn.CommandName);

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
            ddlclid.DataSource = DbHelperSQL.Query("select clid,clname from classes" + " where spid=" + ddlspid.SelectedValue);
            ddlclid.DataTextField = "clname";
            ddlclid.DataValueField = "clid";
            ddlclid.DataBind();

        }
        ddlclid.Items.Insert(0, new ListItem("---全部---", ""));
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void Button2_Click(object sender, EventArgs e)
    {


        bind();  //你绑定gridview1数据源的那个函数。

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=不及格学生列表.xls"); //.xls的文件名可修改
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/ms-excel";      //设置输出文件类型为excel文件。   
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        GridView1.RenderControl(oHtmlTextWriter);
        Response.Output.Write(oStringWriter.ToString());
        Response.Flush();
        Response.End();
        GridView1.AllowSorting = true; //恢复分页          GridView1.AllowPaging = true;  //恢复排序
        bind(); //再次绑定    }
    }

}

