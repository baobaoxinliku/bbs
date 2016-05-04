using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{'info':'登录失败'}";
            string uname = context.Request.Form["uname"];
            string upassword = context.Request.Form["upassword"];

            Model.BBSUsers model1 = new Model.BBSUsers();
            model1.UName = uname;
            model1.UPassword = upassword;

            Bll.Admin bll = new Bll.Admin();
            int n = bll.login(model1);
            if (n > 0)
            {
                json = "{'info':'登录成功！'}";
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