  using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using am.Charts;

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
            if (Request.QueryString["coid"]!=null && Request.QueryString["coid"] !="")
            {
                ddlcoid.SelectedValue = Request.QueryString["coid"];
            }

            if (Request.QueryString["spid"] != null && Request.QueryString["spid"] != "")
            {
                ddlspid.SelectedValue = Request.QueryString["spid"];

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

            if (Request.QueryString["clid"] != null && Request.QueryString["clid"] != "")
            {
                ddlclid.SelectedValue = Request.QueryString["clid"];
            }

            bind();
        }
    }

    /// <summary>
    /// 绑定成绩
    /// </summary>
    private void bind()
    {       
        string where = " where 1=1 ";

        if (ddlcoid.SelectedValue!= "")
        {
            where += " and a.coid=" + ddlcoid.SelectedValue + "";
        }


        if (ddlspid.SelectedValue != "")
        {
            where += " and c.spid=" + ddlspid.SelectedValue + "";
        }

        if (ddlclid.SelectedValue != "")
        {
            where += " and c.clid=" + ddlclid.SelectedValue + "";
        }



        PieChartDataItem pcd1 = new PieChartDataItem();
        pcd1.Description = "90分及以上";
        pcd1.Title = "90分及以上";

        pcd1.LabelRadius = 1;
        pcd1.Value = DbHelperSQL.GetSingle(@" select count(*) from scores a  left
                     join course b on a.coid = b.coid left
                     join students c on a.sno = c.sno left
                    join special d on c.spid = d.spid left
                    join classes e on c.clid = e.clid" +where+ " and score>=90 ").ToString();
        pcd1.PullOut = true;
        PieChart1.Items.Add(pcd1);

        PieChartDataItem pcd2 = new PieChartDataItem();
        pcd2.Description = "80-89分";
        pcd2.Title = "80-89分";

        pcd2.LabelRadius = 1;
        pcd2.Value = DbHelperSQL.GetSingle(@" select count(*) from scores a  left
                     join course b on a.coid = b.coid left
                     join students c on a.sno = c.sno left
                    join special d on c.spid = d.spid left
                    join classes e on c.clid = e.clid" + where + " and score>=80 and score<90 ").ToString();
        pcd2.PullOut = true;
        PieChart1.Items.Add(pcd2);

        PieChartDataItem pcd3 = new PieChartDataItem();
        pcd3.Description = "70-79分";
        pcd3.Title = "70-79分";

        pcd3.LabelRadius = 1;
        pcd3.Value = DbHelperSQL.GetSingle(@" select count(*) from scores a  left
                     join course b on a.coid = b.coid left
                     join students c on a.sno = c.sno left
                    join special d on c.spid = d.spid left
                    join classes e on c.clid = e.clid" + where + " and score>=70 and score<80 ").ToString();
        pcd3.PullOut = true;
        PieChart1.Items.Add(pcd3);

        PieChartDataItem pcd4 = new PieChartDataItem();
        pcd4.Description = "60-69分";
        pcd4.Title = "60-69分";

        pcd4.LabelRadius = 1;
        pcd4.Value = DbHelperSQL.GetSingle(@" select count(*) from scores a  left
                     join course b on a.coid = b.coid left
                     join students c on a.sno = c.sno left
                    join special d on c.spid = d.spid left
                    join classes e on c.clid = e.clid" + where + " and score>=60 and score<70 ").ToString();
        pcd4.PullOut = true;
        PieChart1.Items.Add(pcd4);

        PieChartDataItem pcd5 = new PieChartDataItem();
        pcd5.Description = "60分以下";
        pcd5.Title = "60分以下";

        pcd5.LabelRadius = 1;
        pcd5.Value = DbHelperSQL.GetSingle(@" select count(*) from scores a  left
                     join course b on a.coid = b.coid left
                     join students c on a.sno = c.sno left
                    join special d on c.spid = d.spid left
                    join classes e on c.clid = e.clid" + where + " and score<60 ").ToString();
        pcd5.PullOut = true;
        PieChart1.Items.Add(pcd5);

        PieChart1.Width = 700;
        PieChart1.Height = 600;
        //设置链接的跳转方式
        //PieChart1.SliceLinkTarget = "_blank";
        PieChart1.ScientificMax = 20;
        PieChart1.Labels.Add(new ChartLabel("成绩统计", new Unit(100), new Unit(20)));
        PieChart1.ToolTip = "成绩统计";

    }


    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("total2.aspx?coid=" + ddlcoid.SelectedValue + "&spid=" + ddlspid.SelectedValue + "&clid=" + ddlclid.SelectedValue);
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



}

