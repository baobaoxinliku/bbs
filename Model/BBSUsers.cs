using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BBSUsers//用户信息表
    {
        private int _UID;//用户编号
        private string _UName;//用户姓名
        private string _UPassword;//用户密码
        private string _UEmail;//用户邮箱
        private DateTime _UBirthday;//用户生日
        private bool _USex;//用户性别
        private int _UClass;//用户等级
        private string _UStatement;//用户个人说明
        private DateTime _URegDate;//用户注册时间
        private string _UState;//用户状态
        private int _UPoint;//用户积分

        public int UID
        {
            get
            {
                return _UID;
            }

            set
            {
                _UID = value;
            }
        }

        public string UName
        {
            get
            {
                return _UName;
            }

            set
            {
                _UName = value;
            }
        }

        public string UPassword
        {
            get
            {
                return _UPassword;
            }

            set
            {
                _UPassword = value;
            }
        }

        public string UEmail
        {
            get
            {
                return _UEmail;
            }

            set
            {
                _UEmail = value;
            }
        }

        public DateTime UBirthday
        {
            get
            {
                return _UBirthday;
            }

            set
            {
                _UBirthday = value;
            }
        }

        public bool USex
        {
            get
            {
                return _USex;
            }

            set
            {
                _USex = value;
            }
        }

        public int UClass
        {
            get
            {
                return _UClass;
            }

            set
            {
                _UClass = value;
            }
        }

        public string UStatement
        {
            get
            {
                return _UStatement;
            }

            set
            {
                _UStatement = value;
            }
        }

        public DateTime URegDate
        {
            get
            {
                return _URegDate;
            }

            set
            {
                _URegDate = value;
            }
        }

        public string UState
        {
            get
            {
                return _UState;
            }

            set
            {
                _UState = value;
            }
        }

        public int UPoint
        {
            get
            {
                return _UPoint;
            }

            set
            {
                _UPoint = value;
            }
        }
    }
}
