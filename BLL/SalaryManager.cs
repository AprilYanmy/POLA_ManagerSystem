using Model;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class SalaryManager
    {
        public List<Salary> SelectList(int year, int month)
        {
            List<Salary> lstSalaryTable = new List<Salary>();
            List<Employee> lstEmployee = new Table_Employee().SelectList(0, 0);//获取员工信息列表
            foreach (Employee objEmp in lstEmployee)
            {
                Salary objSalaryTable = new Salary();
                objSalaryTable.WorkNumber = objEmp.Code.ToString();
                objSalaryTable.Name = objEmp.Name;
                objSalaryTable.PostName = objEmp.Post.Name;
                objSalaryTable.Basic_Salary = objEmp.Salary;
                objSalaryTable.Deduct = new Table_EmpMoney().GetMoney(objEmp.ID, year, month, 0);//扣
                objSalaryTable.Award = new Table_EmpMoney().GetMoney(objEmp.ID, year, month, 1);//奖
                if (new Table_Pays().GetCountForEmployee(objEmp.ID, year, month) > 0 || (objEmp.Status == 0 || objEmp.Status == 1 || objEmp.Status == 2))
                {
                    objSalaryTable.MonthTotal = new Table_Pays().GetMoneyForEmployee(objEmp.ID, year, month);//业绩
                    //List<Pays> lstPay = new Pays().SelectListForEmployee(objEmp.ID, year, month);
                    //提成计算
                    //if (objEmp.Post.Mode == 1)
                    //{
                    //    objSalaryTable.Bonus = objSalaryTable.MonthTotal * decimal.Parse(objEmp.Bonus.ToString());
                    //}
                    objSalaryTable.Bonus = new Table_Pays().GetBonusForEmployee(objEmp.ID, year, month); //提成
                    lstSalaryTable.Add(objSalaryTable);
                }
            }
            return lstSalaryTable;
        }
    }
}
