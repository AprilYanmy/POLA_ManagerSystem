using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class SystemConfigManager
    {
        private List<SystemConfig> DefaultConfig;

        #region 自定义函数...

        /// <summary>初始化默认数据。</summary>
        private void Initialize()
        {
            DefaultConfig = new List<SystemConfig>() {
                new SystemConfig(){
                    VarName = "cfg_deposit_money",
                    VarType = "money",
                    VarValue = "100",
                    VarInfo = "充值基数金额，最小100元"
                },
                new SystemConfig(){
                    VarName = "cfg_deposit_send",
                    VarType = "money",
                    VarValue = "0",
                    VarInfo = "充值增送金额，权限大于有效时间"
                },
                new SystemConfig(){
                    VarName = "cfg_deposit_start",
                    VarType = "datetime",
                    VarValue = DateTime.Now.ToShortDateString() + " 00:00:00",
                    VarInfo = "充值增送开始时间"
                },
                new SystemConfig(){
                    VarName = "cfg_deposit_finish",
                    VarType = "datetime",
                    VarValue = DateTime.Now.ToShortDateString() + " 23:59:59",
                    VarInfo = "充值增送结束时间"
                },
            };
        }

        /// <summary>系统参数设置。</summary>
        public SystemConfig Select(int objIndex)
        {
            this.Initialize();
            return new SystemConfig()
            {
                VarIndex = objIndex,
                VarName = this.DefaultConfig[objIndex].VarName,
                VarType = this.DefaultConfig[objIndex].VarType,
                VarValue = this.DefaultConfig[objIndex].VarValue,
                VarInfo = this.DefaultConfig[objIndex].VarInfo,
            };
        }

        /// <summary>系统参数设置。</summary>
        /// <param name="varname">参数名</param>
        public SystemConfig Select(int objIndex, string VarName)
        {
            if (!this.IsExist(VarName))
            {
                this.Initialize();
                this.Insert(objIndex);
            }
            return new Table_SystemConfig().Select(VarName);
        }

        /// <summary>参数不存在时执行新增</summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        private int Insert(int objIndex)
        {
            SystemConfig objConfig = this.Select(objIndex);
            return new Table_SystemConfig().Insert(objConfig);
        }

        /// <summary>检查参数是否存在</summary>
        /// <param name="varname">参数名</param>
        /// <returns></returns>
        private bool IsExist(string VarName)
        {
            return new Table_SystemConfig().IsExist(VarName);
        }

        /// <summary>更新参数值</summary>
        /// <returns></returns>
        public int UpdateValue(string VarValue, string VarName)
        {
            return new Table_SystemConfig().UpdateValue(VarValue, VarName);
        }

        /// <summary>获取一个布尔值，判断是否执行充值送金额。</summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public bool GetIsDeposit()
        {
            DateTime dtNow = DateTime.Now;

            decimal iSendMoney = decimal.Parse(Select(1, "cfg_deposit_send").VarValue);
            DateTime dtStart = DateTime.Parse(Select(2, "cfg_deposit_start").VarValue);
            DateTime dtFinish = DateTime.Parse(Select(3, "cfg_deposit_finish").VarValue);

            if (dtNow > dtStart && dtNow < dtFinish && iSendMoney > 0)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
