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

            bind();
        }
    }

    /// <summary>
    /// 绑定班级
    /// </summary>
    private void bind()
    {       
 

        GridView1.DataSource = DbHelperSQL.Query(@"declare @sql varchar(8000)
                                    set @sql = 'select a.sno as 学号,stname as ' + '姓名'
                                    select @sql = @sql + ' , max(case coname when ''' + coname + ''' then score else 0 end) [' + coname + ']'
                                    from (select distinct coname from course) as a
                                    set @sql = @sql +', cast(avg(score*1.0) as decimal(18,2)) 平均分,sum(score) 总分'
                                        + ' from scores a left join students b on a.sno=b.sno left join course c on a.coid=c.coid group by a.sno,stname order by 总分 desc'
                                    exec(@sql) ");
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


    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
   

        bind();  //你绑定gridview1数据源的那个函数。

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=总成绩统计.xls"); //.xls的文件名可修改
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

