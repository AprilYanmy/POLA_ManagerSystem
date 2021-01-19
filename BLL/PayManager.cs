using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class PayManager
    {
        /// <summary>消费单据。</summary>
        /// <param name="payid"></param>
        public Pays GetPays(string payid)
        {
            return new Table_Pays().GetPays(payid);
        }

        /// <summary>获取最后一条消费单号。</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public string ExistsPayCode()
        {
            return new Table_Pays().ExistsPayCode();
        }

        /// <summary>获取消费单据。</summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Pays GetPays(DataRow row)
        {
            return new Table_Pays().GetPays(row);
        }

        /// <summary>获取会员消费总金额。</summary>
        /// <param name="memberid">会员卡号</param>
        /// <param name="type">支付方式(只能输入0现金或1余额)</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public decimal GetTotalPayForMember(string memberid, int type, int year, int month, int day)
        {
            return new Table_Pays().GetTotalPayForMember(memberid, type, year, month, day);
        }

        /// <summary>查询员工业绩</summary>
        /// <param name="empid">员工编号(ID)</param>
        /// <returns></returns>
        public List<Pays> SelectListForEmployee(int empid, int year, int month)
        {
            return new Table_Pays().SelectListForEmployee(empid, year, month);
        }

        /// <summary>获取员工业绩数量。</summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetCountForEmployee(int empid, int year, int month)
        {
            return new Table_Pays().GetCountForEmployee(empid, year, month);
        }

        /// <summary>获取员工业绩金额。</summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public decimal GetMoneyForEmployee(int empid, int year, int month)
        {
            return new Table_Pays().GetMoneyForEmployee(empid, year, month);
        }

        /// <summary>
        /// 获取员工提成金额
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public decimal GetBonusForEmployee(int empid, int year, int month)
        {
            return new Table_Pays().GetBonusForEmployee(empid, year, month);
        }

        /// <summary>查询会员消费单据</summary>
        /// <param name="payid">消费单号</param>
        /// <param name="memberid">会员卡号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="type">支付方式</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Pays> SelectList(string payid, string memberid, int year, int month, int day, int? type, int? status)
        {
            return new Table_Pays().SelectList(payid, memberid, year, month, day, type, status);
        }

        /// <summary>新增消费单据。</summary>
        /// <returns></returns>
        public int InsertPay(Pays objPays)
        {
            return new Table_Pays().InsertPay(objPays);
        }

        /// <summary>更新消费单据</summary>
        /// <returns></returns>
        public int UpdatePay(Pays objPays)
        {
            return new Table_Pays().UpdatePay(objPays);
        }

        /// <summary>删除消费单据</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public bool DeletePay(string payid)
        {
            return new Table_Pays().DeletePay(payid);
        }

        /// <summary>更新消费备注信息。</summary>
        public int UpdatePayRemark(Pays objPays)
        {
            return new Table_Pays().UpdatePayRemark(objPays);
        }

        /// <summary>确认收款</summary>
        /// <returns></returns>
        public int UpdatePaysOK(Pays objPays)
        {
            return new Table_Pays().UpdatePaysOK(objPays);
        }

        /// <summary>更新消费金额</summary>
        /// <param name="payid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int UpdateMoney(string payid, decimal money)
        {
            return new Table_Pays().UpdateMoney(payid, money);
        }
    }
}
