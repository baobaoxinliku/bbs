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
        public int addsetion(Model.BBSSection model)
        {
            return dal.addsection(model);
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
        public bool DeleteList(string adminIDlist)
        {
            return dal.DeleteList(adminIDlist);

        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
