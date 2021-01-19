using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PayDetail
    {
        #region 属性...

        private decimal _DetailID;

        /// <summary>获取或设置消费明细流水号。</summary>
        public decimal DetailID
        {
            get { return _DetailID; }
            set { _DetailID = value; }
        }

        private string _PayID;

        /// <summary>获取或设置消费单号。</summary>
        public string PayID
        {
            get { return _PayID; }
            set { _PayID = value; }
        }

        private int _ItemID;

        /// <summary>获取或设置消费项目(商品编号/商品ID)。</summary>
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        private int _Number;

        /// <summary>获取或设置消费数量。</summary>
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        private SPItems _SPItem = new SPItems();

        /// <summary>获取或消费项目(商品信息)。</summary>
        public SPItems SPItem
        {
            get { return _SPItem; }
            set { _SPItem = value; }
        }

        private decimal _Money;

        /// <summary>获取或设置折后单价。</summary>
        public decimal Money
        {
            get
            {
                if (_Money == 0)
                {
                    return _Money = this.SPItem.UnitPrice;
                }
                return _Money;
            }
            set { _Money = value; }
        }

        /// <summary>获取消费合计金额。</summary>
        public decimal Sum
        {
            get { return this.Number * this.Money; }
        }

        private decimal _FatPrice;

        /// <summary>获取消费成本价。</summary>
        public decimal FatPrice
        {
            get
            {
                if (this.ItemID > 0)
                {
                    _FatPrice = this.Number * this.SPItem.FatPrice;
                }
                return _FatPrice;
            }
        }

        #endregion
    }
}
