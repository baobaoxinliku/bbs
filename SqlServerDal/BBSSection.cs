using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SqlServerDal
{
    public class BBSSection//板块信息的增删改查
    {
        public bool DeleteList(string SId)//section删除
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BBSSection ");
            strSql.Append("where SId in (" + SId + ") ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
