using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class students_Show : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化学生
            chushi();
        }
    }

    /// <summary>
    /// 初始化学生
    ///</summary>
    protected void chushi()
    {
        //判断url传递的id是否为null
        if (Request.QueryString["id"] != null)
        {

            string sql="";
            sql="select a.*,b.spname,c.clname from students a  left join special b on a.spid=b.spid left join classes c on a.clid=c.clid where sno='"+ Request.QueryString["id"]+"'";
            //根据编号得到相应的记录
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sql);
            if (sdr.Read())
            {
                lblsno.Text = sdr["sno"].ToString();
                lblpassword.Text = sdr["password"].ToString();
                lblstname.Text = sdr["stname"].ToString();
                lblsex.Text = sdr["sex"].ToString();
                lblage.Text = sdr["age"].ToString();
                lbltel.Text = sdr["tel"].ToString();
                lblemail.Text = sdr["email"].ToString();
                lblspid.Text = sdr["spname"].ToString();
                lblclid.Text = sdr["clname"].ToString();
            }

        }
    }
}

