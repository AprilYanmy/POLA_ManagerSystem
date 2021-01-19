using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Salary
    {
        #region 属性...

        private string _WorkNumber;

        /// <summary>获取或设置员工工号。</summary>
        public string WorkNumber
        {
            get { return _WorkNumber; }
            set { _WorkNumber = value; }
        }

        private string _Name;

        /// <summary>获取或设置员工姓名。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _PostName;

        /// <summary>获取或设置员工职位。</summary>
        public string PostName
        {
            get { return _PostName; }
            set { _PostName = value; }
        }

        private decimal _MonthTotal;

        /// <summary>获取或设置员工每月业绩。</summary>
        public decimal MonthTotal
        {
            get { return _MonthTotal; }
            set { _MonthTotal = value; }
        }

        private decimal _Salary;

        /// <summary>获取或设置员工底薪。</summary>
        public decimal Basic_Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        private decimal _Bonus;

        /// <summary>获取或设置员工提成金额</summary>
        public decimal Bonus
        {
            get { return _Bonus; }
            set { _Bonus = value; }
        }

        private decimal _Award;

        /// <summary>获取或设置员工奖金额</summary>
        public decimal Award
        {
            get { return _Award; }
            set { _Award = value; }
        }

        private decimal _Deduct;

        /// <summary>获取或设置员工扣款金额</summary>
        public decimal Deduct
        {
            get { return _Deduct; }
            set { _Deduct = value; }
        }

        /// <summary>获取或设置实发工资。</summary>
        public decimal LastTotal
        {
            get { return decimal.Parse((this.Basic_Salary + this.Bonus + this.Award - this.Deduct).ToString("f0")); }
        }

        #endregion
    }
}
