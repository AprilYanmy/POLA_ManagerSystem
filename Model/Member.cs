using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Member
    {
        #region 属性...

        #region 读写属性...

        private string _ID;

        /// <summary>获取或设置会员卡号，会员唯一标识。</summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;

        /// <summary>获取或设置会员姓名。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Status;

        /// <summary>获取或设置会员状态。（0正常；1停用）</summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private int _CardID;

        /// <summary>获取或设置会员卡类型ID。</summary>
        public int CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }

        private string _Password;

        /// <summary>获取或设置会员密码。</summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Remark;

        /// <summary>获取或设置会员备注。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Sex;

        /// <summary>获取或设置会员性别。</summary>
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private int _Month;

        /// <summary>获取或设置会员出生日期(月)。</summary>
        public int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }

        private int _Day;

        /// <summary>获取或设置会员出生日期(日)。</summary>
        public int Day
        {
            get { return _Day; }
            set { _Day = value; }
        }

        private string _Phone;

        /// <summary>获取或设置会员联系电话。</summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Address;

        /// <summary>获取或设置会员联系地址。</summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Other;

        /// <summary>获取或设置会员其它信息。</summary>
        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }

        private DateTime _JoinDate;

        /// <summary>获取或设置会员加入日期。</summary>
        public DateTime JoinDate
        {
            get { return _JoinDate; }
            set { _JoinDate = value; }
        }

        private string _IDCard;

        /// <summary>获取或设置会员身份证号码。</summary>
        public string IDCard
        {
            get { return _IDCard; }
            set { _IDCard = value; }
        }

        private decimal _Balance;

        /// <summary>获取或设置会员当前可用余额。</summary>
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        private int _Point = 0;

        /// <summary>获取或设置会员当前可用积分。</summary>
        public int Point
        {
            get { return _Point; }
            set { _Point = value; }
        }

        private DateTime? _LastTime;

        /// <summary>获取或设置会员最近光顾日期。</summary>
        public DateTime? LastTime
        {
            get { return _LastTime; }
            set { _LastTime = value; }
        }

        #endregion

        #region 只读属性...

        private string _SexText;

        /// <summary>获取会员性别(文本值)。</summary>
        public string SexText
        {
            get
            {
                _SexText = "男";
                if (this.Sex == 0)
                {
                    _SexText = "女";
                }
                return _SexText;
            }
        }

        private string _Birthday;

        /// <summary>获取会员出生日期。</summary>
        public string Birthday
        {
            get
            {
                _Birthday = "";
                if (this.Month > 0)
                {
                    _Birthday = this.Month + "月";
                    if (this.Day > 0)
                    {
                        _Birthday += this.Day + "日";
                    }
                }
                return _Birthday;
            }
        }

        private Card _Card;

        /// <summary>获取会员类型。</summary>
        public Card Card
        {
            get { return _Card; }
            set { _Card = value; }
        }

        private string _StatusText;

        /// <summary>获取会员当前状态(文本值)。</summary>
        public string StatusText
        {
            get
            {
                if (this.Status == 0)
                {
                    _StatusText = "正常";
                }
                else
                {
                    _StatusText = "停用";
                }
                return _StatusText;
            }
        }

        private string _LastDeposit;

        /// <summary>获取最近一次充值。</summary>
        /// 由只读变成读写，要改动
        public string LastDeposit
        {
            get
            {
                return _LastDeposit;
            }
            set { _LastDeposit = value; }
        }

        #endregion

        #endregion
    }
}
