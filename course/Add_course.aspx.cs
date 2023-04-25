using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class course_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlptype.DataSource = DbHelperSQL.Query("select * from coursetype where pid=0 order by id asc").Tables[0];
            ddlptype.DataTextField = "typename";
            ddlptype.DataValueField = "id";
            ddltype.DataSource = DbHelperSQL.Query("select * from coursetype where pid=1  order by id asc").Tables[0];
            ddltype.DataTextField = "typename";
            ddltype.DataValueField = "id";
            DataBind();
        }
    }

    /// <summary>
    /// 添加课程
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
       if(!FileUpload1.HasFile)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请上传图片!');</script>");
            return;
        }
        string ext = Path.GetExtension(FileUpload1.FileName);
        if(ext!=".jpg"&&ext!=".jpeg"&&ext!=".png"&&ext!=".gif")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('只能上传扩展名为.jpg,.jpeg,.png和.gif的图片!');</script>");
            return;
        }
        string saveName = "/uploads/" + Guid.NewGuid().ToString() + ext;
        FileUpload1.PostedFile.SaveAs(Server.MapPath(saveName));

        txtimg.Text = saveName;

       //设置添加sql
       string strSql=String.Format(@"insert into course(coname,cotime,coscore,comemo,cyear,cteam,ptypeid,typeid,img)
                                values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}')",
                                txt_coname.Text,txt_cotime.Text,txt_coscore.Text,txt_comemo.Text,txt_cyear.Text,txt_cteam.Text,ddlptype.SelectedValue,ddltype.SelectedValue,txtimg.Text);
        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());


        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Add_course.aspx';</script>");
    }



    protected void ddlptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddltype.DataSource = DbHelperSQL.Query("select * from coursetype where pid="+ddlptype.SelectedValue+"  order by id asc").Tables[0];
        ddltype.DataTextField = "typename";
        ddltype.DataValueField = "id";
        DataBind();
    }
}

