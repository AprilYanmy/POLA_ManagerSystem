using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SystemConfig
    {
        #region 属性...

        private int _VarIndex;

        /// <summary>获取或设置参数索引。</summary>
        public int VarIndex
        {
            get { return _VarIndex; }
            set { _VarIndex = value; }
        }

        private string _VarName;

        /// <summary>获取或设置参数名。</summary>
        public string VarName
        {
            get { return _VarName; }
            set { _VarName = value; }
        }

        private string _VarType;

        /// <summary>获取或设置参数值类型。</summary>
        public string VarType
        {
            get { return _VarType; }
            set { _VarType = value; }
        }

        private string _VarValue;

        /// <summary>获取或设置参数值。</summary>
        public string VarValue
        {
            get { return _VarValue; }
            set { _VarValue = value; }
        }

        private string _VarInfo;

        /// <summary>获取或设置参数描述</summary>
        public string VarInfo
        {
            get { return _VarInfo; }
            set { _VarInfo = value; }
        }

        #endregion
    }
}
