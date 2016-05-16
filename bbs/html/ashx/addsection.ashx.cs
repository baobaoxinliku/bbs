using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// addsection 的摘要说明
    /// </summary>
    public class addsection : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'增加数据失败'}";

            string sname = context.Request.Form["sname"];
            string smasterid = context.Request.Form["smasterid"];
            string sstatement = context.Request.Form["sstatemen"];

            Model.BBSSection model = new Model.BBSSection();
            model.SName = sname;
            model.SMasterID = int.Parse(smasterid);


            Bll.Admin bll = new Bll.Admin();
            int n = bll.add_setion(model);
            if (n > 0)
            {
                json = "{'info':'增加数据成功，编号是：" + n + "'}";
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