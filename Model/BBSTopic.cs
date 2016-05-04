using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BBSTopic//主贴信息表格
    {
        private int _TID;//主贴编号
        private int _TSID;//主贴板块编号
        private int _TUID;//主贴用户编号
        private int _TReplyCount;//主贴回复次数
        private string _TTopic;//主贴标题
        private string _TContents;//主贴内容
        private DateTime _TTime;//发帖时间
        private int _TClickCount;//主贴点击次数
        private DateTime _TLastClickT;//主贴最后点击时间

        public int TID
        {
            get
            {
                return _TID;
            }

            set
            {
                _TID = value;
            }
        }

        public int TSID
        {
            get
            {
                return _TSID;
            }

            set
            {
                _TSID = value;
            }
        }

        public int TUID
        {
            get
            {
                return _TUID;
            }

            set
            {
                _TUID = value;
            }
        }

        public int TReplyCount
        {
            get
            {
                return _TReplyCount;
            }

            set
            {
                _TReplyCount = value;
            }
        }

        public string TTopic
        {
            get
            {
                return _TTopic;
            }

            set
            {
                _TTopic = value;
            }
        }

        public string TContents
        {
            get
            {
                return _TContents;
            }

            set
            {
                _TContents = value;
            }
        }

        public DateTime TTime
        {
            get
            {
                return _TTime;
            }

            set
            {
                _TTime = value;
            }
        }

        public int TClickCount
        {
            get
            {
                return _TClickCount;
            }

            set
            {
                _TClickCount = value;
            }
        }

        public DateTime TLastClickT
        {
            get
            {
                return _TLastClickT;
            }

            set
            {
                _TLastClickT = value;
            }
        }
    }
}
