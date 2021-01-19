using Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySqlLibrary;
using System.Configuration;

namespace DAL
{
    public class Table_PayDetail
    {

        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>检查消费明细中是否存在相同商品。</summary>
        /// <param name="detailid">消费明细流水号</param>
        /// <returns></returns>
        public int ExistsPostSPItems(string payid, int itemid)
        {
            string strSql = "select * from PayDetails where pdpid='" + payid + "' and pdiid=" + itemid;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            return objDataTable.Rows.Count;
        }

        /// <summary>查询消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public PayDetail SelectList(decimal payid)
        {
            string strSql = "select * from PayDetails where pdpid='" + payid + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];

            PayDetail objDetail = new PayDetail();
            objDetail.DetailID = decimal.Parse(objRow["pdid"].ToString());
            objDetail.PayID = objRow["pdpid"].ToString();
            objDetail.ItemID = int.Parse(objRow["pdiid"].ToString());
            objDetail.Number = int.Parse(objRow["pdnum"].ToString());
            objDetail.Money = decimal.Parse(objRow["pmoney"].ToString());

            SPItems objSPItems = new SPItems();
            if (objDetail.ItemID > 0)
            {
                objSPItems = new Table_Items().SelectList(objDetail.ItemID);
            }
            objDetail.SPItem = objSPItems;

            return objDetail;
        }

        /// <summary>查询消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public List<PayDetail> SelectList(string payid)
        {
            string strSql = "select * from PayDetails where pdpid='" + payid + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<PayDetail> lstPayDetail = new List<PayDetail>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                PayDetail objDetail = new PayDetail();
                objDetail.DetailID = decimal.Parse(objRow["pdid"].ToString());
                objDetail.PayID = objRow["pdpid"].ToString();
                objDetail.ItemID = int.Parse(objRow["pdiid"].ToString());
                objDetail.Number = int.Parse(objRow["pdnum"].ToString());
                objDetail.Money = decimal.Parse(objRow["pmoney"].ToString());
                SPItems objSPItems = new SPItems();
                if (objDetail.ItemID > 0)
                {
                    objSPItems = new Table_Items().SelectList(objDetail.ItemID);
                }
                objDetail.SPItem = objSPItems;

                lstPayDetail.Add(objDetail);
            }
            return lstPayDetail;
        }

        /// <summary>新增消费明细。</summary>
        /// <returns></returns>
        public int InsertDetail(PayDetail objPayDetail)
        {
            string strSql = "insert into PayDetails(pdpid,pdiid,pdnum,pmoney) " +
                "values('" + objPayDetail.PayID + "','" + objPayDetail.ItemID + "'," + objPayDetail.Number + ",'" + objPayDetail.Money + "')";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>删除消费明细。</summary>
        /// <param name="detailid">消费明细流水号</param>
        /// <returns></returns>
        public int DeleteDetail(decimal detailid)
        {
            string strSql = "delete from PayDetails where pdid=" + detailid;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新消费 。</summary>
        /// <returns></returns>
        public int UpdateDetailBonus(decimal Money, decimal DetailID)
        {
            string strSql = "update PayDetails set pmoney=" + Money + " where pdid=" + DetailID;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <param name="itemid">商品单号</param>
        /// <returns></returns>
        public int UpdateDetail(string PayID, int ItemID, int Number, decimal Money)
        {
            string strSql = "update PayDetails set pdnum=" + Number + ",pmoney='" + Money + "' where pdpid='" + PayID + "' and pdiid='" + ItemID + "'";
            return SqlHelper.ExecuteSql(strSql);
        }

        #endregion
    }
}
