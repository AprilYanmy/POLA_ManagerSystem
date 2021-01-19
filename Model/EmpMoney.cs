using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class EmpMoney
    {
        #region 属性...

        private decimal _ID;

        /// <summary>获取或设置奖扣款编号ID(流水号)。</summary>
        public decimal ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private decimal _Money;

        /// <summary>获取或设置奖扣款金额。</summary>
        public decimal Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        private int _Type;

        /// <summary>获取或设置奖/扣类型(0扣，1奖)。</summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _TypeText;

        public string TypeText
        {
            get
            {
                if (this.Type == 1)
                {
                    _TypeText = "奖";
                }
                else
                {
                    _TypeText = "扣";
                }
                return _TypeText;
            }
        }

        private string _Remark;

        /// <summary>获取或设置奖扣款原由。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private DateTime _Date = DateTime.Now;

        /// <summary>获取或设置奖扣款日期。</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private int _EmpId;

        /// <summary>获取或设置员工编号ID。</summary>
        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        #endregion
    }
}
