using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IAdmin
    {
        int register(Model.BBSUsers model);

        int login(Model.BBSUsers model);

        int addsection(Model.BBSSection model);

        int posting(Model.BBSTopic model);

        int reply(Model.BBSReply model);

        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);

        bool DeleteList(string adminIDlist);
    }
}
