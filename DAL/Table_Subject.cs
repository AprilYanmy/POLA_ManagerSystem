using Model;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DAL
{
    public class Table_Subject
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>科目管理。</summary>
        /// <param name="subId">科目标识(ID)</param>
        public Subject Select(int subId)
        {
            string strSql = "select * from Subject where sid=" + subId;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            return new Subject()
            {
                ID = int.Parse(objRow["sid"].ToString()),
                Name = objRow["sname"].ToString(),
                Type = int.Parse(objRow["stype"].ToString()),
                Readme = objRow["sreadme"].ToString(),
                IsEnabled = int.Parse(objRow["senabled"].ToString())
            };

        }

        /// <summary>检查科目名称是否存在。</summary>
        /// <param name="name">科目名称</param>
        /// <returns></returns>
        public int ExistsSubjectName(string name)
        {
            string strSql = "select * from Subject where sname='" + name + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            if (objDataTable.Rows.Count > 0)
            {
                return int.Parse(objDataTable.Rows[0]["sid"].ToString());
            }
            return 0;
        }

        /// <summary>添加科目信息。</summary>
        /// <returns></returns>
        public int InsertSubject(Subject objSubject)
        {
            string strSql = "insert into Subject(sname,stype,sreadme,senabled) values('" + objSubject.Name + "'," + objSubject.Type + ",'" 
                + objSubject.Readme + "',0); select @@identity";
            DataTable objDataTable = new DataTable();
            try
            {
                SqlHelper.ExecuteSql(strSql, out objDataTable);
                return int.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch
            { }
            return 0;
        }

        /// <summary>修改科目信息。</summary>
        /// <returns></returns>
        public int UpdateSubject(Subject objSubject)
        {
            string strSql = "update Subject set sname='" + objSubject.Name + "',stype=" + objSubject.Type + ",sreadme='" 
                + objSubject.Readme + "' where sid=" + objSubject.ID;
           return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新科目状态。</summary>
        /// <returns></returns>
        public int UpdateStatus(int IsEnabled,int ID)
        {
            string strSql = "update Subject set senabled=" + IsEnabled + " where sid=" + ID;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>查询科目信息。</summary>
        /// <param name="type">收支类型</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Subject> SelectList(int type, int status)
        {
            string strSql = "select * from Subject where senabled=" + status;
            if (type > 0)
            {
                strSql += " and stype=" + (type - 1).ToString();
            }
            strSql += " order by stype";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<Subject> lstSubject = new List<Subject>();
            foreach (DataRow row in objDataTable.Rows)
            {
                Subject objSubject = new Subject();
                objSubject.ID = int.Parse(row["sid"].ToString());
                objSubject.Name = row["sname"].ToString();
                objSubject.Type = int.Parse(row["stype"].ToString());
                objSubject.Readme = row["sreadme"].ToString();
                objSubject.IsEnabled = int.Parse(row["senabled"].ToString());
                lstSubject.Add(objSubject);
            }
            return lstSubject;
        }

        #endregion
    }
}
