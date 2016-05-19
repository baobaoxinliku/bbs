using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// reply 的摘要说明
    /// </summary>
    public class reply : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'回复失败'}";
            string RContents = context.Request.Form["RContents"];

            Model.BBSReply model = new Model.BBSReply();
            model.RContents = RContents;

            model.RTime = DateTime.Now;
            model.RClickCount = 0;

            Bll.Admin bll = new Bll.Admin();

            int n = bll.reply(model);
            if (n > 0)
            {
                json = "{'info':'回复成功！'}";
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