using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///StringHelper 的摘要说明
/// </summary>
public class StringHelper
{
    public StringHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 取得固定长度的字符串(按单字节截取)
    /**/
    /// <summary>
    /// 取得固定长度的字符串(按单字节截取)。
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <param name="resultLength">截取长度</param>
    /// <returns></returns>
    #endregion
    public static string SubString(string source, int resultLength)
    {

        //判断字符串长度是否大于截断长度
        if (System.Text.Encoding.Default.GetByteCount(source) > resultLength)
        {
            //判断字串是否为空
            if (source == null)
            {
                return "";
            }

            //初始化
            int i = 0, j = 0;

            //为汉字或全脚符号长度加2否则加1
            foreach (char newChar in source)
            {
                if ((int)newChar > 127)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }
                if (i > resultLength)
                {
                    source = source.Substring(0, j)+"...";
                    break;
                }
                j++;
            }
        }
        return source;
    }

    /// <summary>
    /// 去除HTML标记
    /// </summary>
    public static string ReplaceHtml(string html)
    {
        string StrNohtml = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
        StrNohtml = System.Text.RegularExpressions.Regex.Replace(StrNohtml, "&[^;]+;", "");
        return StrNohtml;
    }

    /// <summary>
    /// 截取HTML字符串
    /// </summary>
    public static string SubStringHtml(string html, int resultLength)
    {
        string StrNohtml = ReplaceHtml(html);
        return SubString(StrNohtml,resultLength);
    }


    /**/
    /// <summary>
    /// 从GridView的数据生成DataTable
    /// </summary>
    /// <param name="gv">GridView对象</param>
    public static DataTable GridView2DataTable(GridView gv)
    {
        DataTable table = new DataTable();
        int rowIndex = 0;
        List<string> cols = new List<string>();
        if (!gv.ShowHeader && gv.Columns.Count == 0)
        {
            return table;
        }
        GridViewRow headerRow = gv.HeaderRow;
        int columnCount = headerRow.Cells.Count;
        for (int i = 0; i < columnCount; i++)
        {
            string text = GetCellText(headerRow.Cells[i]);
            cols.Add(text);
        }
        foreach (GridViewRow r in gv.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                DataRow row = table.NewRow();
                int j = 0;
                for (int i = 0; i < columnCount-1; i++)
                {
                    string text = GetCellText(r.Cells[i]);
                    if (!String.IsNullOrEmpty(text))
                    {
                        if (rowIndex == 0)
                        {
                            string columnName = cols[i];
                            if (String.IsNullOrEmpty(columnName))
                            {
                                continue;
                            }
                            if (table.Columns.Contains(columnName))
                            {
                                continue;
                            }
                            DataColumn dc = table.Columns.Add();
                            dc.ColumnName = columnName;
                            dc.DataType = typeof(string);
                        }
                        row[j] = text;
                        j++;
                    }
                }
                rowIndex++;
                table.Rows.Add(row);
            }
        }
        return table;
    }
    public static string GetCellText(TableCell cell)
    {
        string text = cell.Text;
        if (!string.IsNullOrEmpty(text))
        {
            return text;
        }
        foreach (Control control in cell.Controls)
        {
            if (control != null && control is IButtonControl)
            {
                IButtonControl btn = control as IButtonControl;
                text = btn.Text.Replace("/r/n", "").Trim();
                break;
            }
            if (control != null && control is ITextControl)
            {
                LiteralControl lc = control as LiteralControl;
                if (lc != null)
                {
                    continue;
                }
                ITextControl l = control as ITextControl;

                text = l.Text.Replace("/r/n", "").Trim();
                break;
            }
        }
        return text;
    }

    public static DataTable GetDgvToTable(GridView dgv)
    {
        DataTable dt = new DataTable();

        // 列强制转换
        for (int count = 0; count < dgv.Columns.Count; count++)
        {
            DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
            dt.Columns.Add(dc);
        }

        // 循环行
        for (int count = 0; count < dgv.Rows.Count; count++)
        {
            DataRow dr = dt.NewRow();
            for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
            {
                dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Text);
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }

    /// <summary>
    ///可导出多个sheet表
    /// </summary>
    /// <param name="Author">作者</param>
    /// <param name="Company">公司</param>
    /// <param name="dt">多个DataTable</param>
    /// <param name="fileName">文件名</param>
    public static void PushExcelToClientEx(string Author, string Company, string[] dt,string []tname, string fileName)
    {
        if (!fileName.Contains(".xls"))
        {
            fileName += ".xls";
        }

        StringBuilder sbBody = new StringBuilder();
        StringBuilder sbSheet = new StringBuilder();

        sbBody.AppendFormat(
                "MIME-Version: 1.0\r\n" +
                "X-Document-Type: Workbook\r\n" +
                "Content-Type: multipart/related; boundary=\"-=BOUNDARY_EXCEL\"\r\n\r\n" +
                "---=BOUNDARY_EXCEL\r\n" +
                "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
                "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
                "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
                "<head>\r\n" +
                "<xml>\r\n" +
                "<o:DocumentProperties>\r\n" +
                "<o:Author>{0}</o:Author>\r\n" +
                "<o:LastAuthor>{0}</o:LastAuthor>\r\n" +
                "<o:Created>{1}</o:Created>\r\n" +
                "<o:LastSaved>{1}</o:LastSaved>\r\n" +
                "<o:Company>{2}</o:Company>\r\n" +
                "<o:Version>11.5606</o:Version>\r\n" +
                "</o:DocumentProperties>\r\n" +
                "</xml>\r\n" +
                "<xml>\r\n" +
                "<x:ExcelWorkbook>\r\n" +
                "<x:ExcelWorksheets>\r\n"
               , Author
               , DateTime.Now.ToString()
               , Company);


        
        int tt = 0;
        foreach (string d in dt)
        {
            string gid = Guid.NewGuid().ToString();

            sbBody.AppendFormat("<x:ExcelWorksheet>\r\n" +
                "<x:Name>{0}</x:Name>\r\n" +
                "<x:WorksheetSource HRef=\"cid:{1}\"/>\r\n" +
                "</x:ExcelWorksheet>\r\n"
                , tname[tt].ToString()
                , gid);


            sbSheet.AppendFormat(
             "---=BOUNDARY_EXCEL\r\n" +
             "Content-ID: {0}\r\n" +
             "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
             "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
             "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
             "<head>\r\n" +
             "<xml>\r\n" +
             "<x:WorksheetOptions>\r\n" +
             "<x:ProtectContents>False</x:ProtectContents>\r\n" +
             "<x:ProtectObjects>False</x:ProtectObjects>\r\n" +
             "<x:ProtectScenarios>False</x:ProtectScenarios>\r\n" +
             "</x:WorksheetOptions>\r\n" +
             "</xml>\r\n" +
             "</head>\r\n" +
             "<body>\r\n"
             , gid);

       
            sbSheet.Append(d);
                sbSheet.Append("</body>\r\n" +
                "</html>\r\n\r\n");

            tt++;
        }

       StringBuilder   sb = new StringBuilder(sbBody.ToString());

        sb.Append("</x:ExcelWorksheets>\r\n" +
            "</x:ExcelWorkbook>\r\n" +
           "</xml>\r\n" +
            "</head>\r\n" +
            "</html>\r\n\r\n");

        sb.Append(sbSheet.ToString());

        sb.Append("---=BOUNDARY_EXCEL--");

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;

        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gbk");
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }



    /// <summary>
    ///可导出多个sheet表
    /// </summary>
    /// <param name="Author">作者</param>
    /// <param name="Company">公司</param>
    /// <param name="dt">多个DataTable</param>
    /// <param name="fileName">文件名</param>
    public static string getTables( DataTable[] dt, string []tName)
    {

        int tt = 0;
      
        StringBuilder sbSheet = new StringBuilder();
        foreach (DataTable d in dt)
        {


            sbSheet.Append("<table border='1'>");
            sbSheet.Append("<tr><td align='center' style='font-size:22px;'><b>"+tName[tt].ToString()+"<b></td></tr>");
            sbSheet.Append("<tr style='background-color: #CCC;'>");
            for (int i = 0; i < d.Columns.Count; i++)
            {
                sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;font-weight:bold'>{0}</td>", d.Columns[i].ColumnName);
            }
            sbSheet.Append("</tr>");
            for (int j = 0; j < d.Rows.Count; j++)
            {
                sbSheet.Append("<tr>");
                for (int k = 0; k < d.Columns.Count; k++)
                {
                    sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;'>{0}</td>", Convert.ToString(d.Rows[j][k]));
                }
                sbSheet.Append("</tr>");
            }
            sbSheet.Append("</table>");
            sbSheet.AppendLine();

            tt++;
        }


        return sbSheet.ToString();
    }

    public static string getTables2(DataTable d, string tName)
    {

     
        StringBuilder sbSheet = new StringBuilder();
      


            sbSheet.Append("<table border='1'>");
            sbSheet.Append("<tr><td align='center' style='font-size:22px;'><b>" + tName + "<b></td></tr>");
            sbSheet.Append("<tr style='background-color: #CCC;'>");
            for (int i = 0; i < d.Columns.Count; i++)
            {
                sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;font-weight:bold'>{0}</td>", d.Columns[i].ColumnName);
            }
            sbSheet.Append("</tr>");
            for (int j = 0; j < d.Rows.Count; j++)
            {
                sbSheet.Append("<tr>");
                for (int k = 0; k < d.Columns.Count; k++)
                {
                    sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;'>{0}</td>", Convert.ToString(d.Rows[j][k]));
                }
                sbSheet.Append("</tr>");
            }
            sbSheet.Append("</table>");
            sbSheet.AppendLine();

         

        return sbSheet.ToString();
    }



    public static void PushExcelToClientEx(GridView gv, string fileName)
    {
        if (!fileName.Contains(".xls"))
        {
            fileName += ".xls";
        }

        StringBuilder sbBody = new StringBuilder();
        StringBuilder sbSheet = new StringBuilder();

        sbBody.AppendFormat(
                "MIME-Version: 1.0\r\n" +
                "X-Document-Type: Workbook\r\n" +
                "Content-Type: multipart/related; boundary=\"-=BOUNDARY_EXCEL\"\r\n\r\n" +
                "---=BOUNDARY_EXCEL\r\n" +
                "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
                "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
                "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
                "<head>\r\n" +
                "<xml>\r\n" +
                "<o:DocumentProperties>\r\n" +
                "<o:Author>{0}</o:Author>\r\n" +
                "<o:LastAuthor>{0}</o:LastAuthor>\r\n" +
                "<o:Created>{1}</o:Created>\r\n" +
                "<o:LastSaved>{1}</o:LastSaved>\r\n" +
                "<o:Company>{2}</o:Company>\r\n" +
                "<o:Version>11.5606</o:Version>\r\n" +
                "</o:DocumentProperties>\r\n" +
                "</xml>\r\n" +
                "<xml>\r\n" +
                "<x:ExcelWorkbook>\r\n" +
                "<x:ExcelWorksheets>\r\n"
               , ""
               , DateTime.Now.ToString()
               , "");

        DataTable d = GetDgvToTable(gv);

        string gid = Guid.NewGuid().ToString();
        sbBody.AppendFormat("<x:ExcelWorksheet>\r\n" +
            "<x:Name>{0}</x:Name>\r\n" +
            "<x:WorksheetSource HRef=\"cid:{1}\"/>\r\n" +
            "</x:ExcelWorksheet>\r\n"
            , fileName
            , gid);


        sbSheet.AppendFormat(
         "---=BOUNDARY_EXCEL\r\n" +
         "Content-ID: {0}\r\n" +
         "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
         "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
         "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
         "<head>\r\n" +
         "<xml>\r\n" +
         "<x:WorksheetOptions>\r\n" +
         "<x:ProtectContents>False</x:ProtectContents>\r\n" +
         "<x:ProtectObjects>False</x:ProtectObjects>\r\n" +
         "<x:ProtectScenarios>False</x:ProtectScenarios>\r\n" +
         "</x:WorksheetOptions>\r\n" +
         "</xml>\r\n" +
         "</head>\r\n" +
         "<body>\r\n"
         , gid);

        sbSheet.Append("<table border='1'>");
        sbSheet.Append("<tr style='background-color: #CCC;'>");
        for (int i = 0; i < d.Columns.Count; i++)
        {
            sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;font-weight:bold'>{0}</td>", d.Columns[i].ColumnName);
        }
        sbSheet.Append("</tr>");
        for (int j = 0; j < d.Rows.Count; j++)
        {
            sbSheet.Append("<tr>");
            for (int k = 0; k < d.Columns.Count; k++)
            {
                sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;'>{0}</td>", Convert.ToString(d.Rows[j][k]));
            }
            sbSheet.Append("</tr>");
        }
        sbSheet.Append("</table>");
        sbSheet.Append("</body>\r\n" +
            "</html>\r\n\r\n");

        StringBuilder sb = new StringBuilder(sbBody.ToString());

        sb.Append("</x:ExcelWorksheets>\r\n" +
            "</x:ExcelWorkbook>\r\n" +
           "</xml>\r\n" +
            "</head>\r\n" +
            "</html>\r\n\r\n");

        sb.Append(sbSheet.ToString());

        sb.Append("---=BOUNDARY_EXCEL--");

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;

        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gbk");
        HttpContext.Current.Response.Write(sb.ToString());
        HttpContext.Current.Response.End();
    }
}