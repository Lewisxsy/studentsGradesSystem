using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class course_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlptype.DataSource = DbHelperSQL.Query("select * from coursetype where pid=0 order by id asc").Tables[0];
            ddlptype.DataTextField = "typename";
            ddlptype.DataValueField = "id";
           
            ddlptype.DataBind();
        }
        if (!IsPostBack)
        {
            //初始化课程
            chushi();
        }
    }

    /// <summary>
    /// 初始化课程
    /// </summary>
    protected void chushi()
    {

        string strSql = string.Format("select * from course where  coid={0}", Request.QueryString["id"]);

        //根据编号得到相应的记录
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlptype.SelectedValue = ds.Tables[0].Rows[0]["ptypeid"].ToString();
            
            txtimg.Text= ds.Tables[0].Rows[0]["img"].ToString();

            txt_coname.Text = ds.Tables[0].Rows[0]["coname"].ToString();
            txt_cotime.Text = ds.Tables[0].Rows[0]["cotime"].ToString();
            txt_coscore.Text = ds.Tables[0].Rows[0]["coscore"].ToString();
            txt_comemo.Text = ds.Tables[0].Rows[0]["comemo"].ToString();
            txt_cteam.Text = ds.Tables[0].Rows[0]["cteam"].ToString();
            txt_cyear.Text = ds.Tables[0].Rows[0]["cyear"].ToString();

            ddltype.DataSource = DbHelperSQL.Query("select * from coursetype where pid=" + ds.Tables[0].Rows[0]["ptypeid"].ToString() + "  order by id asc").Tables[0];
            ddltype.DataTextField = "typename";
            ddltype.DataValueField = "id";
            ddltype.DataBind();

            ddltype.SelectedValue = ds.Tables[0].Rows[0]["typeid"].ToString();
        }
    }

    /// <summary>
    /// 编辑课程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //更新   
        if (!FileUpload1.HasFile&&txtimg.Text.Trim().Length<=0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请上传图片!');</script>");
            return;
        }
        if(FileUpload1.HasFile)
        {
            string ext = Path.GetExtension(FileUpload1.FileName);
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".gif")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('只能上传扩展名为.jpg,.jpeg,.png和.gif的图片!');</script>");
                return;
            }
            string saveName = "/uploads/" + Guid.NewGuid().ToString() + ext;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(saveName));

            txtimg.Text = saveName;
        }
       

        string strSql=String.Format(@"update course set 
                                    coname = '{0}',cotime = '{1}',coscore = '{2}',comemo = '{3}',ptypeid={4},typeid={5},img='{6}',cteam='{7}',cyear='{8}'
                                    where coid='{9}'",
        txt_coname.Text,txt_cotime.Text,txt_coscore.Text,txt_comemo.Text,ddlptype.SelectedValue,ddltype.SelectedValue,txtimg.Text,txt_cteam.Text,txt_cyear.Text,int.Parse(Request.QueryString["id"]));

        //提交到数据库
        DbHelperSQL.ExecuteSql(strSql.ToString());

        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='Manage_course.aspx';</script>");
    }


    protected void ddlptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddltype.DataSource = DbHelperSQL.Query("select * from coursetype where pid=" + ddlptype.SelectedValue + "  order by id asc").Tables[0];
        ddltype.DataTextField = "typename";
        ddltype.DataValueField = "id";
        ddltype.DataBind();
    }

}

