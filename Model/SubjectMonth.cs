using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SubjectMonth
    {
        #region 属性...

        private DateTime _Date;

        /// <summary>获取或设置报表日期。</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        /// <summary>获取日期(日)。</summary>
        public int Day
        {
            get { return this.Date.Day; }
        }

        /// <summary>获取星期几(CN)。</summary>
        public string Week
        {
            get { return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Date.DayOfWeek); }
        }

        private decimal _DepositMoney;

        /// <summary>获取或设置充值收入。</summary>
        public decimal DepositMoney
        {
            get { return _DepositMoney; }
            set { _DepositMoney = value; }
        }

        private decimal _CashMoney;

        /// <summary>现金消费收入。</summary>
        public decimal CashMoney
        {
            get { return _CashMoney; }
            set { _CashMoney = value; }
        }

        private decimal _OtherMoney;

        /// <summary>获取或设置其它收入。</summary>
        public decimal OtherMoney
        {
            get { return _OtherMoney; }
            set { _OtherMoney = value; }
        }

        /// <summary>收入合计</summary>
        public decimal IncomeSum
        {
            get { return this.DepositMoney + this.CashMoney + this.OtherMoney; }
        }

        private decimal _Expend;

        /// <summary>支出</summary>
        public decimal Expend
        {
            get { return _Expend; }
            set { _Expend = value; }
        }

        /// <summary>盈亏</summary>
        public decimal Profit
        {
            get { return this.IncomeSum - this.Expend; }
        }

        #endregion
    }
}
