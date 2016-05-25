using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bbs.html.ashx
{
    /// <summary>
    /// section_add 的摘要说明
    /// </summary>
    public class section_add : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json = "{'info':'增加数据失败'}";
            //获取GET方法传递参数：Request.QueryString["参数名称"];
            //获取POST方法传递参数：Request.Form["参数名称"];
            string uname = context.Request.Form["uname"];


            string upassword = context.Request.Form["upassword"];
            string uemail = context.Request.Form["uemail"];
            string ubirthday = context.Request.Form["ubirthday"];
            string usex = context.Request.Form["usex"];
            string ustatement = context.Request.Form["ustatement"];

            Model.BBSUsers model1 = new Model.BBSUsers();
            model1.UName = uname;
            model1.UPassword = upassword;
            model1.UEmail = uemail;
            model1.UBirthday = DateTime.Parse(ubirthday);
            model1.USex = false;

            //初始值为0
            model1.UClass = 0;
            model1.UPoint = 0;
            model1.URegDate = DateTime.Now;

            if (usex == "true")
            { model1.USex = true; }
            model1.UStatement = ustatement;
            Bll.Admin bll = new Bll.Admin();
            int n = bll.register(model1);
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