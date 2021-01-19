using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class SubjectMonthManager
    {
        #region 自定义函数...

        public List<SubjectMonth> SelectList(int year, int month)
        {
            int iMaxDays = GetMaxDay(year, month);
            List<SubjectMonth> lstMonthTable = new List<SubjectMonth>();
            for (int d = 1; d <= iMaxDays; d++)
            {
                SubjectMonth objMonth = new SubjectMonth();
                objMonth.Date = DateTime.Parse(year + "-" + month + "-" + d);
                //计算收入//
                objMonth.DepositMoney += new DepositManager().GetMembersMoney(year, month, d);//会员充卡收入
                objMonth.CashMoney += new PayManager().GetTotalPayForMember("", 0, year, month, d);//现金消费收入
                objMonth.OtherMoney += new WasteBookManager().GetIncomeMoney(year, month, d);//其它收入
                //计算支出//
                objMonth.Expend += new WasteBookManager().GetExpendMoney(year, month, d);

                lstMonthTable.Add(objMonth);
            }
            return lstMonthTable;
        }

        /// <summary>获取每月最大天数。</summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        private int GetMaxDay(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        #endregion
    }
}
