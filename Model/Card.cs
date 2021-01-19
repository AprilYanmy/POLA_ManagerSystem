using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Card
    {
        #region 属性...

        private int _CardId;

        /// <summary>获取或设置会员卡类型标识(ID)。</summary>
        public int CardId
        {
            get { return _CardId; }
            set { _CardId = value; }
        }

        private string _CardName;

        /// <summary>获取或设置会员卡类型名称。</summary>
        public string CardName
        {
            get { return _CardName; }
            set { _CardName = value; }
        }

        private double _Discount;

        /// <summary>获取或设置该类型会员卡消费折扣。</summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        private decimal _Money;

        /// <summary>获取或设置该类型会员卡初始金额。</summary>
        public decimal Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        private int _MemberSum;

        /// <summary>获取会员数量。</summary>
        public int MemberSum
        {
            get
            {
                //_MemberSum = Member.GetMemberTotal(0, this.CardId);
                return _MemberSum;
            }
            set { _MemberSum = value; }
        }

        #endregion
    }
}
