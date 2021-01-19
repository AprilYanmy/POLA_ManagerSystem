using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class DepositManager
    {
        #region 自定义函数...

        /// <summary>会员续费</summary>
        /// <param name="did">续费记录流水号</param>
        public Deposit GetDeposit(decimal id)
        {
            return new Table_Deposit().GetDeposit(id);
        }

        /// <summary>新增充值记录</summary>
        /// <returns></returns>
        public string InsertDeposit(Deposit objDeposit)
        {
            return new Table_Deposit().InsertDeposit(objDeposit);
        }

        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="oldobjDeposit">本帐户</param>
        /// <param name="newobjDeposit">目标账户</param>
        /// <returns></returns>
        public bool Transfer(Deposit oldobjDeposit, Deposit newobjDeposit)
        {
            return new Table_Deposit().Transfer(oldobjDeposit, newobjDeposit);
        }

        /// <summary>退卡</summary>
        /// <returns></returns>
        public int BackDeposit(Deposit objDeposit)
        {
            return new Table_Deposit().BackDeposit(objDeposit);
        }

        /// <summary>删除充值记录</summary>
        /// <returns></returns>
        public bool DeleteDeposit(int ID)
        {
            return new Table_Deposit().DeleteDeposit(ID);
        }

        /// <summary>查询会员充值记录。</summary>
        /// <param name="memberid">会员编号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public List<Deposit> SelectList(string memberid, int year, int month, int day)
        {
            return new Table_Deposit().SelectList(memberid, year, month, day);
        }


        /// <summary>获取会员充值总金额。</summary>
        /// <param name="memberid">会员卡号</param>
        /// <returns></returns>
        public decimal GetTotalMoneyForMember(string memberid)
        {
            return new Table_Deposit().GetTotalMoneyForMember(memberid);
        }

        /// <summary>统计会员充值金额(只计算正常充值金额)。</summary>
        /// <returns></returns>
        public decimal GetMembersMoney(int year, int month, int day)
        {
            return new Table_Deposit().GetMembersMoney(year, month, day);
        }


        #endregion
    }
}
