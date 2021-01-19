using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Subject
    {
        #region 属性...

        private int _ID;

        /// <summary>获取或设置科目标识(ID)。</summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;

        /// <summary>获取或设置科目名称。</summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Type;

        /// <summary>获取或设置科目收支类型(1为收入，0为支出)。</summary>
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _TypeText;

        /// <summary>获取科目收支类型。</summary>
        public string TypeText
        {
            get
            {
                if (this.Type == 0)
                {
                    _TypeText = "支出";
                }
                else
                {
                    _TypeText = "收入";
                }
                return _TypeText;
            }
        }

        private string _Readme;

        /// <summary>获取或设置科目说明。</summary>
        public string Readme
        {
            get { return _Readme; }
            set { _Readme = value; }
        }

        private int _IsEnabled;

        /// <summary>获取或设置收支科目禁用状态(0启用，1禁用)。</summary>
        public int IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

        private string _EnabledText;

        /// <summary>获取或设置收支科目禁用状态(0启用，1禁用)。</summary>
        public string EnabledText
        {
            get
            {
                if (this.IsEnabled == 0)
                {
                    _EnabledText = "启用";
                }
                else
                {
                    _EnabledText = "禁用";
                }
                return _EnabledText;
            }
        }

        #endregion
    }
}
