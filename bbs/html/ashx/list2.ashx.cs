using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// list2 的摘要说明
    /// </summary>
    public class list2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{}";
            string action = context.Request.Form["Action"];

            int displayStart = int.Parse(context.Request["offset"]);
            int displayLength = int.Parse(context.Request["limit"]);

            Bll.Admin bll = new Bll.Admin();
            //int total = bll.GetRecordCount("");
            DataSet ds = bll.GetListByPage("", "", displayStart + 1, displayStart + displayLength);
            ds.Tables[0].TableName = "rows";
            //返回列表
            json = Web.DataConvertJson.DataTable2Json(ds.Tables[0]);
            //http://down.admin5.com/info/2015/1209/130229.html
            //??服务器端返回的数据中还要包括rows，total（数据总量）两个字段，前端要根据这两个字段分页。
            //json = "{\"total\":" + total + "," + json.Substring(1);

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