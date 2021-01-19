using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using MySqlLibrary;

namespace DAL
{
    public class Table_Deposit
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>会员续费</summary>
        /// <param name="did">续费记录流水号</param>
        public Deposit GetDeposit(decimal id)
        {
            string strSql = "select * from Deposit where did=" + id;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            Deposit objDeposit = new Deposit();

            objDeposit.ID = decimal.Parse(objRow["did"].ToString());
            objDeposit.MemberID = objRow["dmid"].ToString();
            objDeposit.Money = decimal.Parse(objRow["dmoney"].ToString());
            objDeposit.Date = DateTime.Parse(objRow["ddate"].ToString());
            objDeposit.Remark = objRow["dremark"].ToString();
            objDeposit.Mode = int.Parse(objRow["dmode"].ToString());
            objDeposit.ParentID = decimal.Parse(objRow["dparentid"].ToString());

            Member objMemeber = new Member();
            if (objDeposit.MemberID != null || objDeposit.MemberID != "")
            {
                objMemeber = new Table_Member().SelectMemberInfo(objDeposit.MemberID);
            }
            objDeposit.MemberInfo = objMemeber;

            return objDeposit;
        }

        /// <summary>新增充值记录</summary>
        /// <returns></returns>
        public string InsertDeposit(Deposit objDeposit)
        {
            string strSql = "insert into Deposit(dmid,dmoney,ddate,dremark,dmode,dparentid) values('" + objDeposit.MemberID + "','" + objDeposit.Money + "','" + objDeposit.Date + "','" + objDeposit.Remark + "'," + objDeposit.Mode + ",'" + objDeposit.ParentID + "'); select @@identity";
            DataTable objDataTable = new DataTable();
            try
            {
                SqlHelper.ExecuteSql(strSql, out objDataTable);
                new Table_Member().UpdateBalance(objDeposit.MemberID);
                return objDataTable.Rows[0][0].ToString();
            }
            catch
            { }
            return "";
        }

        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="oldobjDeposit">本帐户</param>
        /// <param name="newobjDeposit">目标账户</param>
        /// <returns></returns>
        public bool Transfer(Deposit oldobjDeposit, Deposit newobjDeposit)
        {
            bool obj;
            string[] strSql = new string[2];
            strSql[0] = "insert into Deposit(dmid,dmoney,ddate,dremark,dmode,dparentid) values('" + oldobjDeposit.MemberID + "'," + oldobjDeposit.Money + ",'" + oldobjDeposit.Date + "','" + oldobjDeposit.Remark + "',1,0)";//转出
            strSql[1] = "insert into Deposit(dmid,dmoney,ddate,dremark,dmode,dparentid) values('" + newobjDeposit.MemberID + "'," + newobjDeposit.Money + ",'" + newobjDeposit.Date + "','" + newobjDeposit.Remark + "',2,0)";//转入
            int res = SqlHelper.ExecuteSql(strSql[0]);
            int res1 = SqlHelper.ExecuteSql(strSql[1]);
            if (res > 0 && res1 > 0)
                obj = true;
            else
                obj = false;
            return obj;
            //return SqlHelper.ExecuteTransaction(strSql);
        }

        /// <summary>退卡</summary>
        /// <returns></returns>
        public int BackDeposit(Deposit objDeposit)
        {
            string strSql = "insert into Deposit(dmid,dmoney,ddate,dmode,dparentid) values('" + objDeposit.MemberID + "'," + objDeposit.Money + ",'" + objDeposit.Date + "',4,0)";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>删除充值记录</summary>
        /// <returns></returns>
        public bool DeleteDeposit(int ID)
        {
            string[] strSql = new string[2];
            strSql[0] = "delete from Deposit where did=" + ID;
            strSql[1] = "delete from Deposit where dparentid=" + ID;
            return SqlHelper.ExecuteTransaction(strSql);
        }

        /// <summary>查询会员充值记录。</summary>
        /// <param name="memberid">会员编号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public List<Deposit> SelectList(string memberid, int year, int month, int day)
        {
            string strSql = "select * from Deposit,Member where 1=1 and Deposit.dmid = Member.mid";
            if (memberid != "")
            {
                strSql += " and dmid='" + memberid + "'";
            }
            if (year > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%Y')=" + year;
            }
            if (month > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%c')=" + month;
            }
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%e')=" + day;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<Deposit> lstDeposit = new List<Deposit>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                Member objmember = new Member()
                {
                    ID = objRow["mid"].ToString(),
                    Name = objRow["mname"].ToString(),
                };
                lstDeposit.Add(this.GetDepositForDataRow(objRow,objmember));
            }
            return lstDeposit;
        }

        /// <summary>从数据行中获取续费记录。</summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Deposit GetDepositForDataRow(DataRow row,Member objMember)
        {
            Deposit objDeposit = new Deposit
            {
                ID = decimal.Parse(row["did"].ToString()),
                MemberID = row["dmid"].ToString(),
                Money = decimal.Parse(row["dmoney"].ToString()),
                Date = DateTime.Parse(row["ddate"].ToString()),
                Remark = row["dremark"].ToString(),
                Mode = int.Parse(row["dmode"].ToString()),
                MemberInfo = objMember,
            };
            return objDeposit;
        }

        /// <summary>获取会员充值总金额。</summary>
        /// <param name="memberid">会员卡号</param>
        /// <returns></returns>
        public decimal GetTotalMoneyForMember(string memberid)
        {
            string strSql = "select sum(dmoney) from Deposit where 1=1";
            if (memberid != "")
            {
                strSql += " and dmid='" + memberid + "'";
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            decimal dSum = 0;
            try
            {
                dSum = decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch
            { }
            return dSum;
        }

        /// <summary>统计会员充值金额(只计算正常充值金额)。</summary>
        /// <returns></returns>
        public decimal GetMembersMoney(int year, int month, int day)
        {
            string strSql = "select sum(dmoney) from Deposit where dmode=0";
            if (year > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%Y')=" + year;
            }
            if (month > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%c')=" + month;
            }
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(ddate, '%e')=" + day;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            try
            {
                return decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch
            { }
            return 0;
        }


        #endregion
    }
}
