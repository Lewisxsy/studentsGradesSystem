using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news_Modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            if(!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string sql = "select * from news where id=" + Request.QueryString["id"];
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                if(dt.Rows.Count>0)
                {
                    DataRow row = dt.Rows[0];
                    txtimg.Text = row["img"].ToString();
                    ddlptype.Text = row["typename"].ToString();
                    txt_comemo.Text = row["msg"].ToString();
                    txt_coname.Text = row["title"].ToString();
                    txt_cotime.Text = row["puber"].ToString();
                }
            }
        }
    }

    /// <summary>
    /// 添加课程
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            if (!FileUpload1.HasFile)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请上传图片!');</script>");
                return;
            }
            string ext = Path.GetExtension(FileUpload1.FileName);
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".gif")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('只能上传扩展名为.jpg,.jpeg,.png和.gif的图片!');</script>");
                return;
            }
            string saveName = "/uploads/" + Guid.NewGuid().ToString() + ext;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(saveName));

            txtimg.Text = saveName;

            //设置添加sql
            string strSql = String.Format(@"insert into news(title,puber,typename,img,msg)
                                values ('{0}','{1}','{2}','{3}','{4}')",
                                     txt_coname.Text, txt_cotime.Text, ddlptype.SelectedValue, txtimg.Text, txt_comemo.Text);
            //提交到数据库
            DbHelperSQL.ExecuteSql(strSql.ToString());


            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='list.aspx';</script>");
        }
        else
        {
            if (!FileUpload1.HasFile && txtimg.Text.Trim().Length <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请上传图片!');</script>");
                return;
            }
            if (FileUpload1.HasFile)
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

           
            //设置添加sql
            string strSql = String.Format(@"update news set title='{0}',puber='{1}',typename='{2}',img='{3}',msg='{4}' where id={5}",
                                     txt_coname.Text, txt_cotime.Text, ddlptype.SelectedValue, txtimg.Text, txt_comemo.Text,Request.QueryString["id"]);
            //提交到数据库
            DbHelperSQL.ExecuteSql(strSql.ToString());


            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('操作成功，请返回!');location.href='list.aspx';</script>");
        }
    }



    
}