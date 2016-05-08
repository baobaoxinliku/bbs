using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// posting 的摘要说明
    /// </summary>
    public class posting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'发帖失败'}";

            string ttopic = context.Request.Form["ttopic"];
            string tcontents = context.Request.Form["tcontents"];

            Model.BBSTopic model = new Model.BBSTopic();
            model.TTopic = ttopic;
            model.TContents = tcontents;

            model.TTime = DateTime.Now;
            model.TClickCount = 0;
            model.TLastClickT = DateTime.Now;
            model.TReplyCount = 0;

            Bll.Admin bll = new Bll.Admin();
            int n = bll.posting(model);
            if (n > 0)
            {
                json = "{'info':'发帖成功，编号是：" + n + "'}";
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