using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SPItems
    {
        #region 属性...

        private int _ID;

        /// <summary>获取或设置商品编号。</summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;

        /// <summary>获取或设置商品名称。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private decimal _FatPrice;

        /// <summary>获取或设置商品进货(成本)单价。</summary>
        public decimal FatPrice
        {
            get { return _FatPrice; }
            set { _FatPrice = value; }
        }

        private int _Amount;

        /// <summary>获取或设置商品库存数量。</summary>
        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private decimal _UnitPrice;

        /// <summary>获取或设置商品预售单价。</summary>
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        private decimal _NumPrice;

        /// <summary>获取或设置商品预充次数单价。</summary>
        public decimal NumPrice
        {
            get { return _NumPrice; }
            set { _NumPrice = value; }
        }

        private int _Convert;

        /// <summary>获取或设置商品可用积分。</summary>
        public int Convert
        {
            get { return _Convert; }
            set { _Convert = value; }
        }

        private string _Readme;

        /// <summary>获取或设置商品说明。</summary>
        public string Readme
        {
            get { return _Readme; }
            set { _Readme = value; }
        }

        private int _Status;

        /// <summary>获取或设置商品状态(0可用，1下架)。</summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _Type;

        /// <summary>获取或设置商品所属类别(0美容，1美甲，2手护，3脚护， 4睫毛， 5护肤品， 6其他)。</summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _StatusText;

        /// <summary>获取或设置商品状态。</summary>
        public string StatusText
        {
            get
            {
                if (this.Status == 0)
                {
                    _StatusText = "可用";
                }
                else
                {
                    _StatusText = "下架";
                }
                return _StatusText;
            }
        }

        private string _TypeText;

        /// <summary>获取或设置商品所属类别。</summary>
        public string TypeText
        {
            get
            {
                switch (this.Type)
                {
                    case 0:
                        _TypeText = "美容";
                        break;
                    case 1:
                        _TypeText = "美甲";
                        break;
                    case 2:
                        _TypeText = "手护";
                        break;
                    case 3:
                        _TypeText = "脚护";
                        break;
                    case 4:
                        _TypeText = "睫毛";
                        break;
                    case 5:
                        _TypeText = "护肤品";
                        break;
                    case 6:
                        _TypeText = "身体";
                        break;
                    case 7:
                        _TypeText = "其他";
                        break;
                }
                return _TypeText;
            }
        }


        #endregion
    }
}
