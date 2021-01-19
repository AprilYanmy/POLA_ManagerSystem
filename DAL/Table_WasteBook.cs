using Model;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace DAL
{
    public class Table_WasteBook
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>收支流水账。</summary>
        /// <param name="id">ID流水号</param>
        public WasteBook Select(decimal id)
        {
            string strSql = "select * from WasteBook where wbid=" + id;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            WasteBook objWasteBook = new WasteBook()
            {
                ID = decimal.Parse(objRow["wbid"].ToString()),
                SubjectID = int.Parse(objRow["wbsid"].ToString()),
                Income = decimal.Parse(objRow["wbincome"].ToString()),
                Expend = decimal.Parse(objRow["wbexpend"].ToString()),
                Date = DateTime.Parse(objRow["wbdate"].ToString()),
                Remark = objRow["wbremark"].ToString(),
                Type = objRow["wbtype"].ToString()
            };
            if (objWasteBook.SubjectID > 0)
            {
                objWasteBook.Subject = new Table_Subject().Select(objWasteBook.SubjectID);
            }

            return objWasteBook;
        }

        /// <summary>查询收支流水账</summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public DataTable SelectDataTable(int year, int month, int day)
        {
            string strSql = "select * from WasteBook where 1=1";
            if (year > 0)
            {
                strSql += " and DATE_FORMAT(wbdate, '%Y')=" + year;
            }
            if (month > 0)
            {
                strSql += " and DATE_FORMAT(wbdate, '%c')=" + month;
            }
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(wbdate, '%e')=" + day;
            }
            strSql += " order by wbdate";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            return objDataTable;
        }

        /// <summary>查询收支流水账</summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="type">收支类型</param>
        /// <returns></returns>
        public List<WasteBook> SelectList(int year, int month, int day)
        {
            DataTable objDataTable = this.SelectDataTable(year, month, day);
            List<WasteBook> lstWasteBook = new List<WasteBook>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                WasteBook objWasteBook = new WasteBook()
                {
                    ID = decimal.Parse(objRow["wbid"].ToString()),
                    SubjectID = int.Parse(objRow["wbsid"].ToString()),
                    Income = decimal.Parse(objRow["wbincome"].ToString()),
                    Expend = decimal.Parse(objRow["wbexpend"].ToString()),
                    Date = DateTime.Parse(objRow["wbdate"].ToString()),
                    Remark = objRow["wbremark"].ToString(),
                    Type = objRow["wbtype"].ToString()
                };
                if (objWasteBook.SubjectID > 0)
                {
                    objWasteBook.Subject = new Table_Subject().Select(objWasteBook.SubjectID);
                }

                lstWasteBook.Add(objWasteBook);
            }
            return lstWasteBook;
        }

        /// <summary>新增收支帐目。</summary>
        /// <returns></returns>
        public int InsertWasteBook(WasteBook objWasteBook)
        {
            string strSql = "insert into WasteBook(wbsid,wbincome,wbexpend,wbdate,wbremark,wbtype) " +
            "values(" + objWasteBook.SubjectID + ",'" + objWasteBook.Income + "','" + objWasteBook.Expend + "','" + objWasteBook.Date + "','"
            + objWasteBook.Remark + "','" + objWasteBook.Type + "')";//收入
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>修改收支帐目。</summary>
        /// <returns></returns>
        public int UpdateExpend(WasteBook objWasteBook)
        {
            string strSql = "update WasteBook set " +
                "wbsid=" + objWasteBook.SubjectID + ",wbincome='" + objWasteBook.Income + "',wbexpend='" + objWasteBook.Expend + "',wbdate='"
                + objWasteBook.Date + "',wbremark='" + objWasteBook.Remark + "' where wbid='" + objWasteBook.ID + "'";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>删除记录</summary>
        /// <param name="id">记录编号</param>
        /// <returns></returns>
        public int Delete(decimal id)
        {
            string strSql = "delete from WasteBook where wbid=" + id;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>支出</summary>
        public decimal GetExpendMoney(int year, int month, int day)
        {
            string strSql = "select sum(wbexpend) from WasteBook where DATE_FORMAT(wbdate, '%Y')="
                + year + " and DATE_FORMAT(wbdate, '%c')="
                + month + " and wbtype='e'";
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(wbdate, '%e')=" + day;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            try
            {
                return decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch { }
            return 0;
        }

        /// <summary>收入</summary>
        public decimal GetIncomeMoney(int year, int month, int day)
        {
            string strSql = "select sum(wbincome) from WasteBook where DATE_FORMAT(wbdate, '%Y')="
                + year + " and DATE_FORMAT(wbdate, '%c')=" 
                + month + " and wbtype='i'";
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(wbdate, '%e')=" + day;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            try
            {
                return decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch { }
            return 0;
        }

        #endregion
    }
}
