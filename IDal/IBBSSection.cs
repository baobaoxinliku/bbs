using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IBBSSection
    {
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);

        bool DeleteList(string adminIDlist);
    }
}
