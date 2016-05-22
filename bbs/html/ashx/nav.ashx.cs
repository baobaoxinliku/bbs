using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// nav 的摘要说明
    /// </summary>
    public class nav : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["Action"];
            string json = "{}";
            if (action == "Load")
            {
                if (context.Session["ID"] != null)
                {
                    json = "{\"info\":\"" + context.Session["Name"] + "\"}";
                }

            }

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