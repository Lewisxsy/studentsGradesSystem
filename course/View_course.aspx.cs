using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class course_Show : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化课程
            chushi();
        }
    }

    /// <summary>
    /// 初始化课程
    ///</summary>
    protected void chushi()
    {
        //判断url传递的id是否为null
        if (Request.QueryString["id"] != null)
        {

            string sql="";
            sql="select * from course where coid="+ Request.QueryString["id"];
            //根据编号得到相应的记录
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sql);
            if (sdr.Read())
            {
                lblcoid.Text = sdr["coid"].ToString();
                lblconame.Text = sdr["coname"].ToString();
                lblcotime.Text = sdr["cotime"].ToString();
                lblcoscore.Text = sdr["coscore"].ToString();
                lblcomemo.Text = sdr["comemo"].ToString();
                cyear.Text= sdr["cyear"].ToString();
                cteam.Text= sdr["cteam"].ToString();
            }

        }
    }
}

