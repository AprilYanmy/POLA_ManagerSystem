using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Deposit
    {
        #region 属性...

        private decimal _ID;

        /// <summary>获取或设置续费记录流水号。</summary>
        public decimal ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _MemberID;

        /// <summary>获取或设置续费记录会员卡号。</summary>
        public string MemberID
        {
            get { return _MemberID; }
            set { _MemberID = value; }
        }

        private decimal _Money;

        /// <summary>获取或设置续费金额。</summary>
        public decimal Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        private DateTime _Date = DateTime.Now;

        /// <summary>获取或设置交易时间。</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Remark;

        /// <summary>获取或设置续费备注。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Mode;

        /// <summary>获取或设置充值方式(0充值，1转出，2转入，3增送，4退卡)。</summary>
        public int Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private string _ModeText;

        /// <summary>获取充值方式。</summary>
        public string ModeText
        {
            get
            {
                switch (this.Mode)
                {
                    case 0:
                        _ModeText = "充值";
                        break;
                    case 1:
                        _ModeText = "转出";
                        break;
                    case 2:
                        _ModeText = "转入";
                        break;
                    case 3:
                        _ModeText = "增送";
                        break;
                    case 4:
                        _ModeText = "退卡";
                        break;
                }
                return _ModeText;
            }
        }

        private decimal _ParentID = 0;

        /// <summary>获取或设置所属充值记录（充值增送时使用，默认为0）。</summary>
        public decimal ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private Member _MemberInfo = new Member();

        /// <summary>获取会员信息。</summary>
        public Member MemberInfo
        {
            get { return _MemberInfo; }
            set { _MemberInfo = value; }
        }

        #endregion
    }
}
