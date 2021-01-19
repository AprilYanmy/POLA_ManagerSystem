using Model;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class EmpMoneyManager
    {
        #region 自定义函数...

        /// <summary>员工奖扣款记录。</summary>
        public EmpMoney Select(decimal id)
        {
            return new Table_EmpMoney().Select(id);
        }

        public int Insert(EmpMoney objEmpMoney)
        {
            return new Table_EmpMoney().Insert(objEmpMoney);
        }

        public List<EmpMoney> SelectList(int empid, int year, int month)
        {
            return new Table_EmpMoney().SelectList(empid, year, month);
        }

        /// <summary>获取员工奖/扣金额</summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="type">类型（0扣，1奖）</param>
        /// <returns></returns>
        public decimal GetMoney(int empid, int year, int month, int type)
        {
            return new Table_EmpMoney().GetMoney(empid, year, month, type);
        }

        public int Update(EmpMoney objEmpMoney)
        {
            return new Table_EmpMoney().Update(objEmpMoney);
        }

        public int Delete(decimal id)
        {
            return new Table_EmpMoney().Delete(id);
        }

        /// <summary>获取员工信息</summary>
        /// <param name="empid">员工编号ID</param>
        /// <returns></returns>
        public Employee GetEmployeeInfo(int EmpId)
        {
            return new Table_EmpMoney().GetEmployeeInfo(EmpId);
        }
        #endregion
    }
}
