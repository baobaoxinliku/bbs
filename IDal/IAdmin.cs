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

        int GetRecordCount(string strWhere);

        //section版块
        DataSet SectionGetList(string strWhere);
        bool SectionDeleteList(string adminIDlist);
        int Add(Model.BBSSection model);

        //Topic主题
        DataSet TopicGetList(string strWhere);
        bool TopicDeleteList(string adminIDlist);
        int Add(Model.BBSTopic model);

        //Reply回复
        DataSet ReplyGetList(string strWhere);
        bool ReplyDeleteList(string adminIDlist);
        int Add(Model.BBSReply model);

        //Users用户
        DataSet UsersGetList(string strWhere);
        bool UsersDeleteList(string adminIDlist);
        int Add(Model.BBSUsers model);
    }
}
