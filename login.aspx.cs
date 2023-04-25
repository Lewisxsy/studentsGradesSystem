using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";

        //验证输入
        if (adminName.Value == "")
        {
            str = "用户名不能为空！";
        }

        else if (adminPwd.Value == "")
        {
            str = "密码不能为空！";
        }
        else
        {
            #region
            //if(DropDownList1.SelectedValue=="管理员")
            //{
            //      DataSet ds = DbHelperSQL.Query("select * from admin where lname='" + adminName.Value + "' and pwd='" + adminPwd.Value + "'");

            ////判断用户名和密码是否正确
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow dr = ds.Tables[0].Rows[0];

            //    //把登录信息存到Session中
            //    Session["bh"] = dr["lname"].ToString();
            //    Session["mc"] = dr["lname"].ToString();
            //    Session["qx"] = "管理员";


            //    //跳转到后台
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('"+str+"！');</script>");
            //    return;
            //}
            //}
            //else if(DropDownList1.SelectedValue=="学生")
            //{
            //      DataSet ds = DbHelperSQL.Query("select * from students where sno='" + adminName.Value + "' and password='" + adminPwd.Value + "'");

            ////判断用户名和密码是否正确
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow dr = ds.Tables[0].Rows[0];

            //    //把登录信息存到Session中
            //    Session["bh"] = dr["sno"].ToString();
            //    Session["mc"] = dr["stname"].ToString();
            //    Session["qx"] = "学生";


            //    //跳转到后台
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('"+str+"！');</script>");
            //    return;
            //}
            //}
            //else if(DropDownList1.SelectedValue=="教师")
            //{
            //      DataSet ds = DbHelperSQL.Query("select * from teachers where tno='" + adminName.Value + "' and password='" + adminPwd.Value + "'");

            ////判断用户名和密码是否正确
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow dr = ds.Tables[0].Rows[0];
            #endregion
            string sql = string.Format(@"SELECT  lname AS strno ,
        lname AS strname,
        '管理员' AS stype, '' AS coid
FROM[admin]
WHERE   lname = '{0}'
        AND pwd = '{1}'
UNION ALL
SELECT  sno AS strno,
        stname AS strname,
        '学生' AS stype, '' AS coid
FROM    students
WHERE   sno = '{0}'
        AND password = '{1}'
UNION ALL
SELECT  tno AS strno,
        tname AS strname,
        '教师' AS stype,  coid
FROM    teachers
WHERE   tno = '{0}'
        AND password = '{1}'; ", adminName.Value, adminPwd.Value);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                //把登录信息存到session中
                Session["bh"] = dr["strno"].ToString();
                Session["mc"] = dr["strname"].ToString();
                Session["coid"] = dr["coid"].ToString();
                Session["qx"] = dr["stype"].ToString();

                //跳转到后台
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + str + "！');</script>");
                return;
            }
        }

        //弹出提示信息
        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + str + "！');</script>");
    }
}
