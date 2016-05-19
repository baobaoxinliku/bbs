using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALbbs;
using Model;

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
        public int addsetion(BBSSection model)
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
    }
}
