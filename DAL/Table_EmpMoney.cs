using Model;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DAL
{
    public class Table_EmpMoney
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>员工奖扣款记录。</summary>
        public EmpMoney Select(decimal id)
        {
            string strSql = "select* from Emp_Money where emid=" + id;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            EmpMoney objEmpMoney = new EmpMoney();

            objEmpMoney.ID = decimal.Parse(objRow["emid"].ToString());
            objEmpMoney.Money = decimal.Parse(objRow["emmoney"].ToString());
            objEmpMoney.Type = int.Parse(objRow["emtype"].ToString());
            objEmpMoney.Remark = objRow["emremark"].ToString();
            objEmpMoney.Date = DateTime.Parse(objRow["emtime"].ToString());
            objEmpMoney.EmpId = int.Parse(objRow["empid"].ToString());

            return objEmpMoney;
        }

        public int Insert(EmpMoney objEmpMoney)
        {
            string strSql = "insert into Emp_Money(emmoney,emtype,emremark,emtime,empid) "
            + "values('" + objEmpMoney.Money + "'," + objEmpMoney.Type + ",'" + objEmpMoney.Remark 
            + "','" + objEmpMoney.Date + "'," + objEmpMoney.EmpId + ");";
            return this.SqlHelper.ExecuteSql(strSql);
        }

        public List<EmpMoney> SelectList(int empid, int year, int month)
        {
            string strSql = "select * from Emp_Money where empid=" + empid
                + " and DATE_FORMAT(emtime, '%Y')=" + year
                + " and DATE_FORMAT(emtime, '%c')=" + month;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<EmpMoney> lstEmpMoney = new List<EmpMoney>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                EmpMoney objEmpMoney = new EmpMoney();
                objEmpMoney.ID = decimal.Parse(objRow["emid"].ToString());
                objEmpMoney.Money = decimal.Parse(objRow["emmoney"].ToString());
                objEmpMoney.Type = int.Parse(objRow["emtype"].ToString());
                objEmpMoney.Remark = objRow["emremark"].ToString();
                objEmpMoney.Date = DateTime.Parse(objRow["emtime"].ToString());
                objEmpMoney.EmpId = int.Parse(objRow["empid"].ToString());
                lstEmpMoney.Add(objEmpMoney);
            }
            return lstEmpMoney;
        }

        /// <summary>获取员工奖/扣金额</summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="type">类型（0扣，1奖）</param>
        /// <returns></returns>
        public decimal GetMoney(int empid, int year, int month, int type)
        {
            string strSql = "select sum(emmoney) from Emp_Money where empid=" + empid
                + " and emtype=" + type
                + " and DATE_FORMAT(emtime, '%Y')=" + year
                + " and DATE_FORMAT(emtime, '%c')=" + month;
            try
            {
                DataTable objDataTable = new DataTable();
                SqlHelper.ExecuteSql(strSql, out objDataTable);
                return decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch { }
            return 0;
        }

        public int Update(EmpMoney objEmpMoney)
        {
            string strSql = "update Emp_Money set emmoney='" + objEmpMoney.Money + "',emtype=" + objEmpMoney.Type 
                + ",emremark='" + objEmpMoney.Remark + "',emtime='" + objEmpMoney.Date + "',empid=" 
                + objEmpMoney.EmpId + " where emid='" + objEmpMoney.ID + "';";
            return this.SqlHelper.ExecuteSql(strSql);
        }

        public int Delete(decimal id)
        {
            string strSql = "delete from Emp_Money where emid=" + id;
            return this.SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>获取员工信息</summary>
        /// <param name="empid">员工编号ID</param>
        /// <returns></returns>
        public Employee GetEmployeeInfo(int EmpId)
        {
            Employee objEmp = new Employee();
            if (EmpId > 0)
            {
                objEmp = new Table_Employee().SelectList(EmpId);
            }
            return objEmp;
        }
        #endregion
    }
}
