using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class WasteBook
    {
        #region 属性...

        private decimal _ID;

        /// <summary>获取或设置收支流水账ID；</summary>
        public decimal ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _SubjectID;

        /// <summary>获取或设置收支科目编号。</summary>
        public int SubjectID
        {
            get { return _SubjectID; }
            set { _SubjectID = value; }
        }

        private decimal _Income;

        /// <summary>获取或设置收支流水账收入金额。</summary>
        public decimal Income
        {
            get { return _Income; }
            set { _Income = value; }
        }

        private decimal _Expend;

        /// <summary>获取或设置收支流水账支出金额。</summary>
        public decimal Expend
        {
            get { return _Expend; }
            set { _Expend = value; }
        }

        private DateTime _Date;

        /// <summary>获取或设置收支流水账记录时间。</summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Remark;

        /// <summary>获取或设置收支流水账备注。</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _Type;

        /// <summary>获取或设置收支流水账收支类型。</summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private Subject _Subject;

        /// <summary>获取收支科目信息。</summary>
        public Subject Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        #endregion
    }
}
