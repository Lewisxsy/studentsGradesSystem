using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class teachers_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    /// <summary>
    /// 修改密码
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
               //判断两次密码输入是否相同
        if (TextBox1.Text == TextBox2.Text)
        {
            //根据用户编号和原密码得到用户信息
            SqlDataReader sdr = DbHelperSQL.ExecuteReader("select * from teachers where tno='" + Session["bh"].ToString() + "' and password='" + txt_pwd.Text + "'");

            //判断原密码是否正确
            if (sdr.Read())
            {
                //更新新密码
                DbHelperSQL.ExecuteSql("update teachers set password='" + TextBox1.Text + "' where tno='" + Session["bh"].ToString()+ "'");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('修改成功！');</script>");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('原密码不正确！');</script>");
            }
            sdr.Close();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('两次密码输入不一致！');</script>");
        }

    }

}

