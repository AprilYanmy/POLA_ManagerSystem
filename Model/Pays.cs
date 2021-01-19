using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Pays
    {
        #region 属性...

        #region 读写属性...

        private string _PayID;

        /// <summary>获取或设置消费单号。</summary>
        public string PayID
        {
            get { return _PayID; }
            set { _PayID = value; }
        }

        private string _MemberId;

        /// <summary>获取或设置会员卡号(0为非会员)。</summary>
        public string MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }

        private int _EmpID1;

        /// <summary>获取或设置美容助理。</summary>
        public int EmpID1
        {
            get { return _EmpID1; }
            set { _EmpID1 = value; }
        }

        private decimal _EmpIDPerf1;

        public decimal EmpIDPerf1
        {
            get { return _EmpIDPerf1; }
            set { _EmpIDPerf1 = value; }
        }

        private decimal _Proj1;

        public decimal Proj1
        {
            get { return _Proj1; }
            set { _Proj1 = value; }
        }

        private int _EmpID2;

        /// <summary>获取或设置美甲助理。</summary>
        public int EmpID2
        {
            get { return _EmpID2; }
            set { _EmpID2 = value; }
        }

        private decimal _EmpIDPerf2;

        public decimal EmpIDPerf2
        {
            get { return _EmpIDPerf2; }
            set { _EmpIDPerf2 = value; }
        }

        private decimal _Proj2;

        public decimal Proj2
        {
            get { return _Proj2; }
            set { _Proj2 = value; }
        }

        private int _EmpID3;

        /// <summary>获取或设置美睫师。</summary>
        public int EmpID3
        {
            get { return _EmpID3; }
            set { _EmpID3 = value; }
        }

        private decimal _EmpIDPerf3;

        public decimal EmpIDPerf3
        {
            get { return _EmpIDPerf3; }
            set { _EmpIDPerf3 = value; }
        }

        private decimal _Proj3;

        public decimal Proj3
        {
            get { return _Proj3; }
            set { _Proj3 = value; }
        }

        private decimal _Money;

        /// <summary>获取或设置消费金额。</summary>
        public decimal Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        private string _Cash;

        /// <summary>获取或设置实收金额。</summary>
        public string Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }

        private string _Zero;

        /// <summary>获取或设置找零金额。</summary>
        public string Zero
        {
            get { return _Zero; }
            set { _Zero = value; }
        }

        private int _PayType;

        /// <summary>获取或设置付款(支付)方式。(0现金，1余额，2积分)</summary>
        public int PayType
        {
            get { return _PayType; }
            set { _PayType = value; }
        }

        private DateTime _PayDate = DateTime.Now;

        /// <summary>获取或设置消费日期时间。</summary>
        public DateTime PayDate
        {
            get { return _PayDate; }
            set { _PayDate = value; }
        }

        private string _Remark;

        /// <summary>获取或设置消费单据备注。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private int _Status;

        /// <summary>获取或设置消费单据支付状态(0挂单，1已结算)。</summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private Member _Member = new Member();

        public Member Member
        {
            get { return _Member; }
            set { _Member = value; }
        }

        private List<PayDetail> _PayDetails = new List<PayDetail>();

        public List<PayDetail> PayDetails
        {
            get { return _PayDetails; }
            set { _PayDetails = value; }
        }

        #endregion

        #region 只读属性...



        private string _ClientName;

        /// <summary>获取顾客/会员信息。</summary>
        public string ClientName
        {
            get
            {
                if (this.MemberId == "0")
                {
                    _ClientName = "【非会员】普通顾客";
                }
                else
                {
                    _ClientName = "【" + this.Member.ID + "】" + this.Member.Name;
                }
                return _ClientName;
            }
        }



        private string _PayContent;

        /// <summary>获取简明消费内容。</summary>
        public string PayContent
        {
            get
            {
                if (this.EmpID1 > 0)
                    _PayContent += "美容项目,";
                if (this.EmpID2 > 0)
                    _PayContent += "美甲项目,";
                if (this.EmpID3 > 0)
                    _PayContent += "美睫项目,";
                if (this.PayDetails.Count > 0)
                {
                    foreach (PayDetail objDet in this.PayDetails)
                    {
                        _PayContent += objDet.SPItem.Name + ",";
                    }
                }
                _PayContent = _PayContent.Substring(0, _PayContent.Length - 1);
                return _PayContent;
            }
        }

        private string _PayTypeText;

        /// <summary>获取支付方式。</summary>
        public string PayTypeText
        {
            get
            {
                switch (this.PayType)
                {
                    case 0:
                        _PayTypeText = "现金";
                        break;
                    case 1:
                        _PayTypeText = "余额";
                        break;
                    case 2:
                        _PayTypeText = "积分";
                        break;
                }
                return _PayTypeText;
            }
        }

        private string _StatusText;

        /// <summary>获取消费单据状态。</summary>
        public string StatusText
        {
            get
            {
                if (this.Status == 0)
                {
                    _StatusText = "挂单";
                }
                else
                {
                    _StatusText = "已结算";
                }
                return _StatusText;
            }
        }


        #endregion

        #endregion
    }
}
