using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// list_section 的摘要说明
    /// </summary>
    public class list_section : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{}";
            string action = context.Request.Form["Action"];

            int displayStart = int.Parse(context.Request["offset"]);
            int displayLength = int.Parse(context.Request["limit"]);

            BLL.Admin bll = new BLL.Admin();
            int total = bll.GetRecordCount("");
            DataSet ds = bll.GetListByPage("", "", displayStart + 1, displayStart + displayLength);
            ds.Tables[0].TableName = "rows";
            //返回列表
            json = Web.DataConvertJson.DataTable2Json(ds.Tables[0]);

            json = "{\"total\":" + total + "," + json.Substring(1);

            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}