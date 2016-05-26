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
            string sql = string.Format(@"insert into [BBSReply](
            [RID],
            [RTID],
            [RSID],
            [RUID],
            [RTopi],
            [RContents],
            [RTime],
            [RClickCount])
            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');select @@identity",
              model.RID, model.RTID, model.RSID, model.RUID, model.RTopic, model.RContents, model.RTime, model.RClickCount);
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



        //section版块
        public DataSet SectionGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SID,SName,SMasterID,SClickCount,STopicCount,SStatement ");
            strSql.Append("from BBSSection ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool SectionDeleteList(string SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BBSSection ");
            strSql.Append("where SID=" + SID + "");
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
        public int Add(Model.BBSSection model)
        {
            string sql = string.Format(@"insert into [BBSSection](
            [sname],
            [smasterid],
            [sstatement],
            [sclickcount],
            [stopiccount])
            values('{0}',{1},'{2}',{3},{4});select @@identity",
            model.SName, model.SMasterID, model.SStatement, model.SClickCount, model.STopicCount);
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

        //Topic主题
        public DataSet TopicGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TID,TSID,TUID,TReplycount,TTopic,TContents,TTime,TClickCount,TLastClickT ");
            strSql.Append("from BBSTopic ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool TopicDeleteList(string TID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BBSTopic ");
            strSql.Append("where TID=" + TID + "");
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
        public int Add(Model.BBSTopic model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.TSID.ToString() != null)
            {
                strSql1.Append("tsid,");
                strSql2.Append("" + model.TSID + ",");
            }
            if (model.TUID.ToString() != null)
            {
                strSql1.Append("tuid,");
                strSql2.Append("" + model.TUID + ",");
            }
            if (model.TReplyCount.ToString() != null)
            {
                strSql1.Append("treplycount,");
                strSql2.Append("" + model.TReplyCount + ",");
            }
            if (model.TTopic != null)
            {
                strSql1.Append("TTopic,");
                strSql2.Append("'" + model.TTopic + "',");
            }
            if (model.TContents != null)
            {
                strSql1.Append("TContents,");
                strSql2.Append("'" + model.TContents + "',");
            }
            if (model.TTime != null)
            {
                strSql1.Append("TTime,");
                strSql2.Append("'" + model.TTime + "',");
            }
            if (model.TClickCount.ToString() != null)
            {
                strSql1.Append("TClickCount,");
                strSql2.Append("" + model.TClickCount + ",");
            }
            if (model.TLastClickT != null)
            {
                strSql1.Append("TLastClickT,");
                strSql2.Append("'" + model.TLastClickT + "',");
            }
            strSql.Append("insert into BBSTopic(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //Reply回复
        public DataSet ReplyGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RID,RTID,RSID,RUID,RTopic,RContents,RTime,RClickCount ");
            strSql.Append("from BBSReply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());

        }
        public bool ReplyDeleteList(string RID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BBSReply ");
            strSql.Append("where RID=" + RID + "");
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
        public int Add(Model.BBSReply model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.RTID.ToString() != null)
            {
                strSql1.Append("RTID,");
                strSql2.Append("" + model.RTID + ",");
            }
            if (model.RSID.ToString() != null)
            {
                strSql1.Append("RSID,");
                strSql2.Append("" + model.RSID + ",");
            }
            if (model.RUID.ToString() != null)
            {
                strSql1.Append("RUID,");
                strSql2.Append("" + model.RUID + ",");
            }
            if (model.RTopic != null)
            {
                strSql1.Append("RTopic,");
                strSql2.Append("'" + model.RTopic + "',");
            }
            if (model.RContents != null)
            {
                strSql1.Append("RContents,");
                strSql2.Append("'" + model.RContents + "',");
            }
            if (model.RTime != null)
            {
                strSql1.Append("RTime,");
                strSql2.Append("'" + model.RTime + "',");
            }
            if (model.RClickCount.ToString() != null)
            {
                strSql1.Append("RClickCount,");
                strSql2.Append("" + model.RClickCount + ",");
            }
            strSql.Append("insert into BBSReply(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //Users用户
        public DataSet UsersGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UID,UName,UPassword,UEmail,UBirthday,Usex,UClass,UStatement,URegDate,UState,UPoint ");
            strSql.Append("from BBSUsers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());

        }
        public bool UsersDeleteList(string UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BBSUsers ");
            strSql.Append("where UID=" + UID + "");
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
        public int Add(Model.BBSUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.UName != null)
            {
                strSql1.Append("UName,");
                strSql2.Append("'" + model.UName + "',");
            }
            if (model.UPassword != null)
            {
                strSql1.Append("UPassword,");
                strSql2.Append("'" + model.UPassword + "',");
            }
            if (model.UEmail != null)
            {
                strSql1.Append("UEmail,");
                strSql2.Append("'" + model.UEmail + "',");
            }
            if (model.UBirthday != null)
            {
                strSql1.Append("UBirthday,");
                strSql2.Append("'" + model.UBirthday + "',");
            }
            if (model.USex.ToString() != null)
            {
                strSql1.Append("Usex,");
                strSql2.Append("" + (model.USex ? 1 : 0) + ",");
            }
            if (model.UClass.ToString() != null)
            {
                strSql1.Append("UClass,");
                strSql2.Append("" + model.UClass + ",");
            }
            if (model.UStatement != null)
            {
                strSql1.Append("UStatement,");
                strSql2.Append("'" + model.UStatement + "',");
            }
            if (model.URegDate != null)
            {
                strSql1.Append("URegDate,");
                strSql2.Append("'" + model.URegDate + "',");
            }
            if (model.UState != null)
            {
                strSql1.Append("UState,");
                strSql2.Append("" + model.UState + ",");
            }
            if (model.UPoint.ToString() != null)
            {
                strSql1.Append("UPoint,");
                strSql2.Append("" + model.UPoint + ",");
            }
            strSql.Append("insert into BBSUsers(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BBSSection ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SID desc");
            }
            strSql.Append(")AS Row, T.*  from BBSSection T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        
    }
}
