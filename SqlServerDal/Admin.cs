using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;

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
            sql.Append("select * from BBSUsers where uname=" + model1.UName + " and upassword=" + model1.UPassword);
            object obj = DbHelperSQL.GetSingle(sql.ToString());
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int add_section(Model.BBSSection model1)//新增板块
        {
            string sql = string.Format(@"insert into [BBSSection](
            [sname],
            [smasterid],
            [sstatement],
            [sclickcount],
            [stopiccount])
            values('{0}','{1}','{2}','{3}',{4});select @@identity",
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

        public int posting(Model.BBSTopic model)
        {
            string sql = string.Format(@"insert into [BBSTopic](
            [ttopic],
            [tcontents],
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
    }
}
