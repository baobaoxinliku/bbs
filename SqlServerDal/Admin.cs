using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data;

namespace SqlServerDal
{
    public class Admin : IDal.IAdmin
    {
        public int register(Model.BBSUsers model1)//注册
        {
            int sex1 = 0;
            if (model1.USex)
            {
                sex1 = 1;
            }
            string sql = string.Format(@"insert into [BBSUsers](
            [Uname],
            [UPassword],
            [UEmail],
            [UBirthday],
            [USex],
            [UClass],
            [UStatement],
            [URegDate],
            [UState],
            [UPoint])
            values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}');select @@identity",
            model1.UName, model1.UPassword, model1.UEmail, model1.UBirthday, sex1,
            model1.UClass, model1.UStatement, model1.URegDate, model1.UState, model1.UPoint);
            //sql字符串类型的值要用''，数字、日期类型不需要''。
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int login(Model.BBSUsers model1)//登录
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from BBSUsers where uname='" + model1.UName + "' and upassword='" + model1.UPassword+"'");
            object obj = DbHelperSQL.GetSingle(sql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int addsection(Model.BBSSection model1)//新增板块
        {
            string sql = string.Format(@"insert into [BBSSection](
            [sname],
            [smasterid],
            [sstatement],
            [sclickcount],
            [stopiccount])
            values('{0}',{1},'{2}',{3},{4});select @@identity",
            model1.SName, model1.SMasterID, model1.SStatement, model1.SClickCount, model1.STopicCount);
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int posting(Model.BBSTopic model)//发帖
        {
            string sql = string.Format(@"insert into [BBSTopic](
            [ttopic],
            [TContents],
            [ttime],
            [tclickcount],
            [tlastclickt],
            [treplycount],
            [tsid],
            [tuid])
            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');select @@identity",
             model.TTopic,model.TContents,model.TTime,model.TClickCount,model.TLastClickT,model.TReplyCount,model.TSID,model.TUID) ;
            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);

            }
        }

        public int reply(Model.BBSReply model)//回复
        {
            return 0;
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)//获取数据列表
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ( ");
            strSql.Append("select row_number() over( ");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.adminID desc");
            }
            strSql.Append(")AS Row, T.*  from Admin T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool DeleteList(string adminIDlist)//批量删除数据
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from bbs ");
            strSql.Append("where UID in (" + adminIDlist + ")  ");
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
