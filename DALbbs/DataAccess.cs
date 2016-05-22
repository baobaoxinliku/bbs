using System;
using System.Reflection;
using System.Configuration;
using IDal;
namespace DALbbs
{
  
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        /// <summary>
        /// 创建数据层接口
        /// </summary>
        //public static t Create(string ClassName)
        //{
        //string ClassNamespace = AssemblyPath +"."+ ClassName;
        //object objType = CreateObject(AssemblyPath, ClassNamespace);
        //return (t)objType;
        //}
        /// <summary>
        /// 创建Admin数据层接口。
        /// </summary>
        public static IDal.IAdmin CreateAdmin()
        {

            string ClassNamespace = AssemblyPath + ".Admin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDal.IAdmin)objType;
        }
        public static IDal.IBBSSection CreateAdminsection()
        {

            string ClassNamespace = AssemblyPath + ".Admin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDal.IBBSSection)objType;
        }

        ///// <summary>
        ///// 创建Class数据层接口。
        ///// </summary>
        //public static IDal.IClass CreateClass()
        //{

        //    string ClassNamespace = AssemblyPath + ".Class";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDal.IClass)objType;
        //}


        ///// <summary>
        ///// 创建Grade数据层接口。
        ///// </summary>
        //public static IDal.IGrade CreateGrade()
        //{

        //    string ClassNamespace = AssemblyPath + ".Grade";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDal.IGrade)objType;
        //}


        ///// <summary>
        ///// 创建student数据层接口。
        ///// </summary>
        //public static IDal.Istudent Createstudent()
        //{

        //    string ClassNamespace = AssemblyPath + ".student";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDal.Istudent)objType;
        //}

    }
}