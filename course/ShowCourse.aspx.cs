using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class course_ShowCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string sno = Session["bh"].ToString();
            BindBySno(sno);
        }
    }

    private void BindBySno(string sno)
    {
        string sql = string.Format("select  c.coname from [dbo].[studentcourse]  sc left join course c on sc.coid=c.coid where sno='{0}'", sno);
        DataSet ds = DbHelperSQL.Query(sql);
        if (ds == null || ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('请先选择课程')</script>");
        }
        else
        {
            List<string> random = new List<string>();
            List<string> list = new List<string>();
            while (list.Count < 28)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr["coname"].ToString());
                }
            }
            string html = "<table border='1' cellspacing='1' padding='1'><tr><td><td>上午</td><td>上午</td><td>下午</td><td>下午</td></tr>";
            for (int i = 0; i < 35; i++)
            {
                if (i % 5 == 0)
                {
                    html += "<tr><td>星期" + ((i / 5) + 1);
                }
                else if ((i + 1) % 5 == 0)
                {
                    Random r = new Random();
                    int index = r.Next(0, list.Count);
                    html += "<td>" + list[index] + "</td>";
                    list.RemoveAt(index);
                    html += "</tr>";
                }
                else
                {
                    Random r = new Random();
                    int index = r.Next(0, list.Count);
                    html += "<td>" + list[index] + "</td>";
                    list.RemoveAt(index);
                }

            }

            foreach (string name in random)
            {
                html += name + "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            this.courseRandom.InnerHtml = html;
        }
    }
}