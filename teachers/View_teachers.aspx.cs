using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class teachers_Show : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化教师
            chushi();
        }
    }

    /// <summary>
    /// 初始化教师
    ///</summary>
    protected void chushi()
    {
        //判断url传递的id是否为null
        if (Request.QueryString["id"] != null)
        {

            string sql="";
            sql="select a.*,b.coname from teachers a  left join course b on a.coid=b.coid where tno='"+ Request.QueryString["id"]+"' ";
            //根据编号得到相应的记录
            SqlDataReader sdr = DbHelperSQL.ExecuteReader(sql);
            if (sdr.Read())
            {
                lbltno.Text = sdr["tno"].ToString();
                lblpassword.Text = sdr["password"].ToString();
                lbltname.Text = sdr["tname"].ToString();
                lblsex.Text = sdr["sex"].ToString();
                lbljob.Text = sdr["job"].ToString();
                lbltel.Text = sdr["tel"].ToString();
                lblemail.Text = sdr["email"].ToString();
                lblmemo.Text = sdr["memo"].ToString();
                lblcoid.Text = sdr["coname"].ToString();
            }

        }
    }
}

