using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {
        #region 属性...

        private int _ID;

        /// <summary>获取或设置员工编号(ID)。</summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _Code;

        /// <summary>获取或设置员工工作编号。</summary>
        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;

        /// <summary>获取或设置员工姓名。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Sex;

        /// <summary>获取或设置员工性别。</summary>
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private string _Phone;

        /// <summary>获取或设置员工联系电话。</summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private int _PostId;

        /// <summary>获取或设置员工职位编号。</summary>
        public int PostId
        {
            get { return _PostId; }
            set { _PostId = value; }
        }
        private decimal _Salary;

        /// <summary>获取或设置员工底薪。</summary>
        public decimal Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        private double _Bonus;

        /// <summary>获取或设置员工提成</summary>
        public double Bonus
        {
            get { return _Bonus; }
            set { _Bonus = value; }
        }

        private string _Input;

        /// <summary>获取或设置入职日期。</summary>
        public string Input
        {
            get { return _Input; }
            set { _Input = value; }
        }

        private string _Output;

        /// <summary>获取或设置离职日期。</summary>
        public string Output
        {
            get { return _Output; }
            set { _Output = value; }
        }

        private int _Status;

        /// <summary>获取或设置员工状态(0试用,1学员,2正式,3离职)。</summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Password;

        /// <summary>获取或设置员工登录密码。</summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Remark;

        /// <summary>获取或设置员工备注。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _Address;

        /// <summary>获取或设置员工联系地址。</summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _CardNumber;

        /// <summary>获取或设置员工身份证号码。</summary>
        public string CardNumber
        {
            get { return _CardNumber; }
            set { _CardNumber = value; }
        }

        private string _Mobile;

        /// <summary>获取或设置员工手机。</summary>
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        private string _SexText;

        /// <summary>获取员工性别。</summary>
        public string SexText
        {
            get
            {
                if (this.Sex == 1)
                {
                    _SexText = "女";
                }
                else
                {
                    _SexText = "男";
                }
                return _SexText;
            }
        }

        private string _StatusText;

        /// <summary>获取员工状态。</summary>
        public string StatusText
        {
            get
            {
                switch (this.Status)
                {
                    case 0:
                        _StatusText = "试用";
                        break;
                    case 1:
                        _StatusText = "学员";
                        break;
                    case 2:
                        _StatusText = "正式";
                        break;
                    case 3:
                        _StatusText = "离职";
                        break;
                }
                return _StatusText;
            }
        }

        private Post _Post;

        /// <summary>获取员工职位信息。</summary>
        public Post Post
        {
            get { return _Post; }
            set { _Post = value; }
        }

        #endregion
    }
}
