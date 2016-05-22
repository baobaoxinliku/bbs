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
    public class BBSSection
    {
        private readonly IDal.IBBSSection dal = DataAccess.CreateAdminsection();

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        public bool DeleteList(string adminIDlist)
        {
            return dal.DeleteList(adminIDlist);

        }
    }
}
