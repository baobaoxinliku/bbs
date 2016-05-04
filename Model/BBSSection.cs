using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BBSSection//板块信息
    {
        private int _SID;//版块编号
        private string _SName;//版块名称
        private int _SMasterID;//版主编号
        private string _SStatement;//版块说明
        private int _SClickCount;//版块点击次数
        private int _STopicCount;//版块主题数

        public int SID
        {
            get
            {
                return _SID;
            }

            set
            {
                _SID = value;
            }
        }

        public string SName
        {
            get
            {
                return _SName;
            }

            set
            {
                _SName = value;
            }
        }

        public int SMasterID
        {
            get
            {
                return _SMasterID;
            }

            set
            {
                _SMasterID = value;
            }
        }

        public string SStatement
        {
            get
            {
                return _SStatement;
            }

            set
            {
                _SStatement = value;
            }
        }

        public int SClickCount
        {
            get
            {
                return _SClickCount;
            }

            set
            {
                _SClickCount = value;
            }
        }

        public int STopicCount
        {
            get
            {
                return _STopicCount;
            }

            set
            {
                _STopicCount = value;
            }
        }
    }
}
