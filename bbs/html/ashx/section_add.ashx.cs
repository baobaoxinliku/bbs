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

            string json = "{'info':'增加版块失败'}";
            //获取GET方法传递参数：Request.QueryString["参数名称"];
            //获取POST方法传递参数：Request.Form["参数名称"];
            string SName = context.Request.Form["SName"];
            string SMasterID = context.Request.Form["SMasterID"];
            string SStatement = context.Request.Form["SStatement"];

            Model.BBSSection model = new Model.BBSSection();
            model.SName = SName;
            model.SMasterID = int.Parse(SMasterID);
            model.SStatement = SStatement;
            model.SClickCount = 0;
            model.STopicCount = 0;

            Bll.Admin bll = new Bll.Admin();
            int n = bll.Add(model);
            if (n > 0)
            {
                json = "{'info':'增加版块成功，编号是：" + n + "'}";
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