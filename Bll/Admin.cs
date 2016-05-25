using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALbbs;
using Model;
using System.Data;

namespace Bll
{
    public class Admin
    {
        private readonly IDal.IAdmin dal = DALbbs.DataAccess.CreateAdmin();
        public int register(BBSUsers model)
        {
            return dal.register(model);
        }
        public int login(BBSUsers model)
        {
            return dal.login(model);
        }
        public int posting(BBSTopic model)
        {
            return dal.posting(model);
        }
        public int reply(BBSReply model)
        {
            return dal.reply(model);
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        //Section版块
        public DataSet SectionGetList(string strWhere)
        {
            return dal.SectionGetList(strWhere);
        }
        public bool SectionDeleteList(string adminIDlist)
        {
            return dal.SectionDeleteList(adminIDlist);
        }
        public int Add(Model.BBSSection model)
        {
            return dal.Add(model);
        }


        //Topic主题
        public DataSet TopicGetList(string strWhere)
        {
            return dal.TopicGetList(strWhere);
        }
        public bool TopicDeleteList(string adminIDlist)
        {
            return dal.TopicDeleteList(adminIDlist);
        }
        public int Add(Model.BBSTopic model)
        {
            return dal.Add(model);
        }

        //Reply回复
        public DataSet ReplyGetList(string strWhere)
        {
            return dal.ReplyGetList(strWhere);
        }
        public bool ReplyDeleteList(string adminIDlist)
        {
            return dal.ReplyDeleteList(adminIDlist);
        }
        public int Add(Model.BBSReply model)
        {
            return dal.Add(model);
        }

        //Users用户
        public DataSet UsersGetList(string strWhere)
        {
            return dal.UsersGetList(strWhere);
        }
        public bool UsersDeleteList(string adminIDlist)
        {
            return dal.UsersDeleteList(adminIDlist);
        }
        public int Add(Model.BBSUsers model)
        {
            return dal.Add(model);
        }
    }
}
