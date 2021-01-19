using System;
using System.Collections.Generic;
using System.Text;
using MySqlLibrary;
using System.Data;
using System.Configuration;
using Model;

namespace DAL
{
    public class Table_Card
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>检查会员卡类型是否存在。</summary>
        /// <param name="name">会员卡类型名称</param>
        /// <returns></returns>
        public int ExistsCardName(string name)
        {
            string strSql = "select cid from Card where cname='" + name + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            if (objDataTable.Rows.Count > 0)
            {
                return int.Parse(objDataTable.Rows[0]["cid"].ToString());
            }
            return 0;
        }

        /// <summary>会员卡类型管理。</summary>
        /// <param name="cid">会员类型标识</param>
        public Card Select(int cid)
        {
            string strSql = "select * from Card where cid=" + cid;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            Card objCard = new Card();
            objCard.CardId = int.Parse(objRow["cid"].ToString());
            objCard.CardName = objRow["cname"].ToString();
            objCard.Discount = double.Parse(objRow["cdiscount"].ToString());
            objCard.Money = decimal.Parse(objRow["cmoney"].ToString());

            objCard.MemberSum = new Table_Member().GetMembersCount(0, objCard.CardId);

            return objCard;
        }

        /// <summary>查询会员卡类型数据。</summary>
        /// <param name="cid">会员卡标识，为0时查询所有数据</param>
        /// <returns></returns>
        public List<Card> SelectList(int cid)
        {
            string strSql = "select * from Card";
            if (cid > 0)
            {
                strSql += " where cid=" + cid;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<Card> lstCard = new List<Card>();
            foreach (DataRow row in objDataTable.Rows)
            {
                Card objCard = new Card();
                objCard.CardId = int.Parse(row["cid"].ToString());
                objCard.CardName = row["cname"].ToString();
                objCard.Discount = double.Parse(row["cdiscount"].ToString());
                objCard.Money = decimal.Parse(row["cmoney"].ToString());
                lstCard.Add(objCard);
            }
            return lstCard;
        }

        /// <summary>新增会员卡类型。</summary>
        /// <returns></returns>
        public int InsertCard(Card objCard)
        {
            string strSql = "insert into Card(cname,cdiscount,cmoney) values('" + objCard.CardName + "'," + objCard.Discount + ",'" + objCard.Money + "')";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>修改会员卡类型。</summary>
        /// <returns></returns>
        public int UpdateCard(Card objCard)
        {
            string strSql = "update Card set cname='" + objCard.CardName + "',cdiscount=" + objCard.Discount + ",cmoney='" + objCard.Money + "' where cid=" + objCard.CardId;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>删除会员卡类型。</summary>
        /// <returns></returns>
        public int DeleteCard(int CardId)
        {
            string strSql = "delete from Card where cid=" + CardId;
            return SqlHelper.ExecuteSql(strSql);
        }
        #endregion
    }
}
