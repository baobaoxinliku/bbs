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
            string json = "";
            string action = context.Request.Form["Action"];

            if (action == "Show")//显示
            {
                Bll.Admin bll = new Bll.Admin();
                DataSet ds = bll.GetList("");
                ds.Tables[0].TableName = "Admin";
                //返回列表
                json = Web.DataConvertJson.DataTable2Json(ds.Tables[0]);
            }
            else if (action == "Del")//删除操作
            {
                string DelNumS = context.Request.Form["DelNumS"];//获取批量删除的编号
                Bll.Admin bll = new Bll.Admin();
                if (bll.DeleteList(DelNumS))
                {
                    json = "{'info':'删除成功'}";
                }
                else
                { json = "{'info':'删除失败'}"; }
            }
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