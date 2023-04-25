using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSource = DbHelperSQL.Query("select * from coursetype where pid=0 order by id asc").Tables[0];
            Repeater1.DataBind();

            Bind();
        }
    }

    public void Bind()
    {
        string strwhere = "where 1=1 ";
        if(!string.IsNullOrEmpty(Request.QueryString["sid"]))
        {
            strwhere += " and typeid=" + Request.QueryString["sid"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
        {
            strwhere += " and ptypeid=" + Request.QueryString["pid"];
        }
        if (!string.IsNullOrEmpty(Request.QueryString["key"]))
        {
            strwhere += " and coname like '%" + Request.QueryString["key"]+"%'";
        }
        Repeater3.DataSource = DbHelperSQL.Query("select * from course "+strwhere+" order by coid desc");
        Repeater3.DataBind();
    }

    public DataTable GetTypeList(string pid)
    {
        return DbHelperSQL.Query("select * from coursetype where pid="+pid+" order by id asc").Tables[0];
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("Repeater2") as Repeater;//找到里层的repeater对象
            DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
            int typeid = Convert.ToInt32(rowv["id"]); //获取填充子类的id 
            rep.DataSource =GetTypeList(typeid.ToString());
            rep.DataBind();
        }
    }
}