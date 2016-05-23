using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// modify 的摘要说明
    /// </summary>
    public class modify : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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