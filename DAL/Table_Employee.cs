using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using MySqlLibrary;
using Model;

namespace DAL
{
    public class Table_Employee
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>检查员工工号是否存在(除离职外)。</summary>
        /// <param name="code">工号</param>
        /// <returns>员工ID</returns>
        public int ExistsEmployeeCode(int code)
        {
            string strSql = "select * from Employee where estatus!=3 and ecode=" + code;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            if (objDataTable.Rows.Count > 0)
            {
                return int.Parse(objDataTable.Rows[0]["eid"].ToString());
            }
            return 0;
        }

        /// <summary>查询员工信息。</summary>
        /// <param name="postId">职位编号</param>
        /// <param name="i">状态(1为在职，0为所有)</param>
        /// <returns></returns>
        public Employee SelectList(int empid)
        {
            Employee objEmployee = new Employee();
            string strSql = "select * from Employee where eid=" + empid;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];

            objEmployee.ID = int.Parse(objRow["eid"].ToString());
            objEmployee.Code = int.Parse(objRow["ecode"].ToString());
            objEmployee.Name = objRow["ename"].ToString();
            objEmployee.Sex = int.Parse(objRow["esex"].ToString());
            objEmployee.Phone = objRow["ephone"].ToString();
            objEmployee.PostId = int.Parse(objRow["epid"].ToString());
            objEmployee.Salary = decimal.Parse(objRow["esalary"].ToString());
            objEmployee.Bonus = double.Parse(objRow["ebonus"].ToString());
            objEmployee.Input = objRow["einput"].ToString();
            objEmployee.Output = objRow["eoutput"].ToString();
            objEmployee.Status = int.Parse(objRow["estatus"].ToString());
            objEmployee.Password = objRow["epassword"].ToString();
            objEmployee.Remark = objRow["eremark"].ToString();
            objEmployee.Address = objRow["eaddress"].ToString();
            objEmployee.CardNumber = objRow["ecard"].ToString();
            objEmployee.Mobile = objRow["emobile"].ToString();

            Post objPost = new Post();
            if (objEmployee.PostId > 0)
            {
                objPost = new Table_Post().SelectList(objEmployee.PostId);
            }
            objEmployee.Post = objPost;

            return objEmployee;
        }

        /// <summary>查询员工信息。</summary>
        /// <param name="postId">职位编号</param>
        /// <param name="i">状态(1为在职，0为所有)</param>
        /// <returns></returns>
        public List<Employee> SelectList(int postId, int i)
        {
            string strSql = "select * from Employee where 1=1 ";
            if (postId > 0)
            {
                strSql += "and epid=" + postId;
            }
            if (i == 1)
            {
                strSql += " and estatus!=3";
            }
            strSql += " order by epid desc";

            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);

            List<Employee> lstEmp = new List<Employee>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                Employee objEmp = new Employee();
                objEmp.ID = int.Parse(objRow["eid"].ToString());
                objEmp.Code = int.Parse(objRow["ecode"].ToString());
                objEmp.Name = objRow["ename"].ToString();
                objEmp.Sex = int.Parse(objRow["esex"].ToString());
                objEmp.Phone = objRow["ephone"].ToString();
                objEmp.PostId = int.Parse(objRow["epid"].ToString());
                objEmp.Salary = decimal.Parse(objRow["esalary"].ToString());
                objEmp.Bonus = double.Parse(objRow["ebonus"].ToString());
                objEmp.Input = objRow["einput"].ToString();
                objEmp.Output = objRow["eoutput"].ToString();
                objEmp.Status = int.Parse(objRow["estatus"].ToString());
                objEmp.Password = objRow["epassword"].ToString();
                objEmp.Remark = objRow["eremark"].ToString();
                objEmp.Address = objRow["eaddress"].ToString();
                objEmp.CardNumber = objRow["ecard"].ToString();
                objEmp.Mobile = objRow["emobile"].ToString();
                Post objPost = new Post();
                if (objEmp.PostId > 0)
                {
                    objPost = new Table_Post().SelectList(objEmp.PostId);
                }
                objEmp.Post = objPost;
                lstEmp.Add(objEmp);
            }
            return lstEmp;
        }

        /// <summary>新增员工信息。</summary>
        /// <returns></returns>
        public int InsertEmployee(Employee objEmployee)
        {
            string strSql = "insert into Employee(ecode,ename,esex,ephone,epid,esalary,ebonus,einput,estatus,eremark,eaddress,ecard,emobile) " +
                "values(" + objEmployee.Code + ",'" + objEmployee.Name + "'," + objEmployee.Sex + ",'" + objEmployee.Phone + "'," + objEmployee.PostId + ",'" + objEmployee.Salary + "'," + objEmployee.Bonus + ",'"
                + objEmployee.Input + "'," + objEmployee.Status + ",'" + objEmployee.Remark + "','" + objEmployee.Address + "','" + objEmployee.CardNumber + "','" + objEmployee.Mobile + "')";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新员工信息。</summary>
        /// <returns></returns>
        public int UpdateEmployee(Employee objEmployee)
        {
            string strSql = "update Employee set ecode=" + objEmployee.Code + ",ename='" + objEmployee.Name + "',esex=" + objEmployee.Sex + ",ephone='" + objEmployee.Phone + "',epid=" + objEmployee.PostId + ",esalary='" + objEmployee.Salary + "'" +
                ",ebonus=" + objEmployee.Bonus + ",einput='" + objEmployee.Input + "',eoutput='" + objEmployee.Output + "',estatus=" + objEmployee.Status + ",eremark='" + objEmployee.Remark + "',eaddress='" + objEmployee.Address + "',ecard='" + objEmployee.CardNumber + "'" +
                ",emobile='" + objEmployee.Mobile + "' where eid=" + objEmployee.ID;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public int DeleteEmployee(int empid)
        {
            string strsql = "delete from Employee where eid =" + empid;
            return SqlHelper.ExecuteSql(strsql);
        }

        #endregion
    }
}
