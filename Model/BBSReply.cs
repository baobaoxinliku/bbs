using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BBSReply//回帖信息表
    {
        private int _RID;//回复编号
        private int _RTID;//回复帖子编号
        private int _RSID;//回复版块编号
        private int _RUID;//回复用户编号
        private string _RTopic;//回帖主题
        private string _RContents;//回帖内容
        private DateTime _RTime;//回帖时间
        private int _RClickCount;//回帖点击次数

        public int RID
        {
            get
            {
                return _RID;
            }

            set
            {
                _RID = value;
            }
        }

        public int RTID
        {
            get
            {
                return _RTID;
            }

            set
            {
                _RTID = value;
            }
        }

        public int RSID
        {
            get
            {
                return _RSID;
            }

            set
            {
                _RSID = value;
            }
        }

        public int RUID
        {
            get
            {
                return _RUID;
            }

            set
            {
                _RUID = value;
            }
        }

        public string RTopic
        {
            get
            {
                return _RTopic;
            }

            set
            {
                _RTopic = value;
            }
        }

        public string RContents
        {
            get
            {
                return _RContents;
            }

            set
            {
                _RContents = value;
            }
        }

        public DateTime RTime
        {
            get
            {
                return _RTime;
            }

            set
            {
                _RTime = value;
            }
        }

        public int RClickCount
        {
            get
            {
                return _RClickCount;
            }

            set
            {
                _RClickCount = value;
            }
        }
    }
}
