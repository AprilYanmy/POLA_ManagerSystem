using Model;
using System;
using System.Collections.Generic;
using System.Text;
using MySqlLibrary;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class Table_SystemConfig
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>系统参数设置。</summary>
        /// <param name="varname">参数名</param>
        public SystemConfig Select(string VarName)
        {
            string strSql = "select * from SysConfig where varname='" + VarName + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];

            SystemConfig objSystemConfig = new SystemConfig();
            objSystemConfig.VarIndex = int.Parse(objRow["varindex"].ToString());
            objSystemConfig.VarName = objRow["varname"].ToString();
            objSystemConfig.VarType = objRow["vartype"].ToString();
            objSystemConfig.VarValue = objRow["varvalue"].ToString();
            objSystemConfig.VarInfo = objRow["varinfo"].ToString();

            return objSystemConfig;
        }

        /// <summary>参数不存在时执行新增</summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public int Insert(SystemConfig objConfig)
        {
            string strSql = "insert SysConfig values(" + objConfig.VarIndex + ",'" + objConfig.VarName + "','" 
                + objConfig.VarType + "','" + objConfig.VarValue + "','" + objConfig.VarInfo + "')";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>检查参数是否存在</summary>
        /// <param name="varname">参数名</param>
        /// <returns></returns>
        public bool IsExist(string varname)
        {
            string strSql = "select * from SysConfig where varname='" + varname + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            int iCount = objDataTable.Rows.Count;
            if (iCount == 0)
            {
                return false;//不存在
            }
            return true;//存在
        }

        /// <summary>更新参数值</summary>
        /// <returns></returns>
        public int UpdateValue(string VarValue,string VarName)
        {
            string strSql = "update SysConfig set varvalue='" + VarValue + "' where varname='" + VarName + "'";
            return SqlHelper.ExecuteSql(strSql);
        }

        #endregion
    }
}
