using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Model;
using MySqlLibrary;

namespace DAL
{
    public class Table_Items
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>检查商品名称是否存在。</summary>
        /// <param name="name">商品名称</param>
        /// <returns></returns>
        public int ExistsPostName(string name)
        {
            string strSql = "select * from Items where iname='" + name + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);

            if (objDataTable.Rows.Count > 0)
            {
                return int.Parse(objDataTable.Rows[0]["iid"].ToString());
            }
            return 0;
        }

        /// <summary>商品信息。</summary>
        /// <param name="itemid">商品编号</param>
        public SPItems SelectList(int itemid)
        {
            string strSql = "select * from Items where iid=" + itemid.ToString();
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            SPItems objSPItems = new SPItems();
            objSPItems.ID = int.Parse(objRow["iid"].ToString());
            objSPItems.Name = objRow["iname"].ToString();
            objSPItems.FatPrice = decimal.Parse(objRow["ifprice"].ToString());
            objSPItems.UnitPrice = decimal.Parse(objRow["iuprice"].ToString());
            objSPItems.NumPrice = decimal.Parse(objRow["inprice"].ToString());
            objSPItems.Amount = int.Parse(objRow["iamount"].ToString());
            objSPItems.Type = int.Parse(objRow["itype"].ToString());
            objSPItems.Convert = int.Parse(objRow["iconvert"].ToString());
            objSPItems.Readme = objRow["ireadme"].ToString();
            objSPItems.Status = int.Parse(objRow["istatus"].ToString());

            return objSPItems;
        }

        /// <summary>查询商品信息</summary>
        /// <param name="type">商品类型(0为所有类型)</param>
        /// <param name="text"></param>
        /// <param name="status">商品状态(0为所有状态)</param>
        /// <returns></returns>
        public List<SPItems> SelectList(int type, string text, int status)
        {
            string strSql = "select * from Items where 1=1";
            if (type > 0)
            {
                strSql += " and itype=" + (type - 1).ToString();
            }
            if (text != "")
            {
                strSql += "and (iid like '%" + text + "%' or iname like '%" + text + "%')";
            }
            if (status > 0)
            {
                strSql += " and istatus=" + (status - 1).ToString();
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);

            List<SPItems> lstItems = new List<SPItems>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                SPItems objItem = new SPItems();
                objItem.ID = int.Parse(objRow["iid"].ToString());
                objItem.Name = objRow["iname"].ToString();
                objItem.FatPrice = decimal.Parse(objRow["ifprice"].ToString());
                objItem.UnitPrice = decimal.Parse(objRow["iuprice"].ToString());
                objItem.NumPrice = decimal.Parse(objRow["inprice"].ToString());
                objItem.Amount = int.Parse(objRow["iamount"].ToString());
                objItem.Type = int.Parse(objRow["itype"].ToString());
                objItem.Convert = int.Parse(objRow["iconvert"].ToString());
                objItem.Readme = objRow["ireadme"].ToString();
                objItem.Status = int.Parse(objRow["istatus"].ToString());
                lstItems.Add(objItem);
            }
            return lstItems;
        }

        /// <summary>新增商品信息。</summary>
        /// <returns></returns>
        public int InsertSPItems(SPItems objSPItems)
        {
            string strSql = "insert into Items(iname,ifprice,iuprice,inprice,iamount,itype,iconvert,ireadme,istatus) " +
                "values('" + objSPItems.Name + "'," + objSPItems.FatPrice + ","
                + objSPItems.UnitPrice + "," + objSPItems.NumPrice + "," + objSPItems.Amount + ","
                + objSPItems.Type + "," + objSPItems.Convert + ",'" + objSPItems.Readme + "'," + objSPItems.Status + ")";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>修改商品信息。</summary>
        /// <returns></returns>
        public int UpdateSPItems(SPItems objSPItems)
        {
            string strSql = "update Items set " +
                "iname='" + objSPItems.Name
                + "',ifprice=" + objSPItems.FatPrice + ",iuprice=" + objSPItems.UnitPrice
                + ",inprice=" + objSPItems.NumPrice + ",iamount=" + objSPItems.Amount
                + ",itype=" + objSPItems.Type + ",iconvert=" + objSPItems.Convert + ",ireadme='" + objSPItems.Readme
                + "',istatus=" + objSPItems.Status + " where iid=" + objSPItems.ID;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>商品下(上)架</summary>
        /// <returns></returns>
        public int DownSPItems(int Status,int ID)
        {
            string strSql = "update Items set istatus=" + Status + " where iid=" + ID;
            return SqlHelper.ExecuteSql(strSql);
        }

        #endregion
    }
}
