using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class EmployeeManager
    {
        #region 自定义函数...

        /// <summary>检查员工工号是否存在(除离职外)。</summary>
        /// <param name="code">工号</param>
        /// <returns>员工ID</returns>
        public int ExistsEmployeeCode(int code)
        {
            return new Table_Employee().ExistsEmployeeCode(code);
        }

        /// <summary>查询员工信息。</summary>
        /// <param name="postId">职位编号</param>
        /// <param name="i">状态(1为在职，0为所有)</param>
        /// <returns></returns>
        public Employee SelectList(int empid)
        {
            return new Table_Employee().SelectList(empid);
        }

        /// <summary>查询员工信息。</summary>
        /// <param name="postId">职位编号</param>
        /// <param name="i">状态(1为在职，0为所有)</param>
        /// <returns></returns>
        public List<Employee> SelectList(int postId, int i)
        {
            return new Table_Employee().SelectList(postId, i);
        }

        /// <summary>新增员工信息。</summary>
        /// <returns></returns>
        public int InsertEmployee(Employee objEmployee)
        {
            return new Table_Employee().InsertEmployee(objEmployee);
        }

        /// <summary>更新员工信息。</summary>
        /// <returns></returns>
        public int UpdateEmployee(Employee objEmployee)
        {
            return new Table_Employee().UpdateEmployee(objEmployee);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int DeleteEmployee(int empid)
        {
            return new Table_Employee().DeleteEmployee(empid);
        }

        #endregion
    }
}
