using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Post
    {
        #region 属性...

        private int _ID;

        /// <summary>获取或设置职位标识(ID)。</summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;

        /// <summary>获取或设置职位名称。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Readme;

        /// <summary>获取或设置职位描述。</summary>
        public string Readme
        {
            get { return _Readme; }
            set { _Readme = value; }
        }

        private int _Sort;

        /// <summary>获取或设置职位排序(数字越小越靠前)。</summary>
        public int Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        private decimal _Salary;

        /// <summary>获取或设置职位底薪。</summary>
        public decimal Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        private double _Bonus;

        /// <summary>获取或设置职位提成比例。</summary>
        public double Bonus
        {
            get { return _Bonus; }
            set { _Bonus = value; }
        }

        private int _Mode;

        /// <summary>获取或设置职位薪资结算方式(0底薪,1提成,2底薪+提成)。</summary>
        public int Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private string _ModeText;

        /// <summary>获取职位薪资结算方式。</summary>
        public string ModeText
        {
            get
            {
                switch (this.Mode)
                {
                    case 0:
                        _ModeText = "底薪";
                        break;
                    case 1:
                        _ModeText = "提成";
                        break;
                    case 2:
                        _ModeText = "底薪+提成";
                        break;
                }
                return _ModeText;
            }
        }

        #endregion
    }
}
