using Model;
using MySql.Data.MySqlClient;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class Table_Member
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        /// <summary>
        /// 检查会员号是否存在
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int CheckMemberID(string mid)
        {
            string strSql = "select * from Member where mid='" + mid + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            return objDataTable.Rows.Count;
        }

        /// <summary>
        /// 获取某个会员的所有信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public Member SelectMemberInfo(string mid)
        {
            Member objMember = new Member();
            if (mid == "0")
            {

            }
            else
            {
                string strSql = "select * from Member where mid='" + mid + "'";
                DataTable objDataTable = new DataTable();
                SqlHelper.ExecuteSql(strSql, out objDataTable);
                DataRow objRow = objDataTable.Rows[0];
                
                objMember.ID = objRow["mid"].ToString();
                objMember.Name = objRow["mname"].ToString();
                objMember.Status = int.Parse(objRow["mstatus"].ToString());
                objMember.CardID = int.Parse(objRow["mcid"].ToString());
                objMember.Password = objRow["mpass"].ToString();
                objMember.Remark = objRow["mremark"].ToString();
                objMember.Sex = int.Parse(objRow["msex"].ToString());
                objMember.Month = int.Parse(objRow["mmonth"].ToString());
                objMember.Day = int.Parse(objRow["mday"].ToString());
                objMember.Phone = objRow["mphone"].ToString();
                objMember.Address = objRow["maddress"].ToString();
                objMember.Other = objRow["mother"].ToString();
                objMember.JoinDate = DateTime.Parse(objRow["mjoin"].ToString());
                objMember.IDCard = objRow["midcard"].ToString();
                objMember.Balance = decimal.Parse(objRow["mbalance"].ToString());
                objMember.Point = int.Parse(objRow["mpoint"].ToString());
                try
                {
                    objMember.LastTime = DateTime.Parse(objRow["mlastime"].ToString());
                }
                catch { }

                Card objCard = new Card();
                if (objMember.CardID > 0)
                {
                    objCard = new Table_Card().Select(objMember.CardID);
                }
                objMember.Card = objCard;
            }

            return objMember;
        }

        /// <summary>
        /// 获取所有会员的信息
        /// </summary>
        /// <param name="membertext"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public List<Member> SelectAllMemberInfo(string membertext, bool enabled)
        {
            //优先显示生日会员
            string strSql1 = "select * from Member where (DATE_FORMAT(CURDATE(), '%c')<=mmonth and DATE_FORMAT(CURDATE(),'%e')<=mday)";
            string strSql2 = "select * from Member where 1=1";
            if (membertext != "")
            {
                strSql1 += " and (mid like '" + membertext + "%' or mname like '%" + membertext + "%')";
                strSql2 += " and (mid like '" + membertext + "%' or mname like '%" + membertext + "%')";
            }
            if (enabled)
            {
                strSql1 += " and mstatus=1";
                strSql2 += " and mstatus=1";
            }
            else
            {
                strSql1 += " and mstatus=0";
                strSql2 += " and mstatus=0";
            }
            strSql1 += " order by mid";
            strSql2 += " order by mid";
            DataTable objTable1 = new DataTable();
            SqlHelper.ExecuteSql(strSql1, out objTable1);
            DataTable objTable2 = new DataTable();
            SqlHelper.ExecuteSql(strSql2, out objTable2);

            //合并表
            objTable1.Merge(objTable2);
            DataTable objTable = GetDistinctTable(objTable1, "mid");

            List<Member> lstMember = new List<Member>();
            foreach (DataRow objRow in objTable.Rows)
            {
                lstMember.Add(this.GetMemberForRow(objRow));
            }

            return lstMember;
        }

        private Member GetMemberForRow(DataRow objRow)
        {
            Member objMember = new Member();
            objMember.ID = objRow["mid"].ToString();
            objMember.Name = objRow["mname"].ToString();
            objMember.Status = int.Parse(objRow["mstatus"].ToString());
            objMember.CardID = int.Parse(objRow["mcid"].ToString());
            objMember.Password = objRow["mpass"].ToString();
            objMember.Remark = objRow["mremark"].ToString();
            objMember.Sex = int.Parse(objRow["msex"].ToString());
            objMember.Month = int.Parse(objRow["mmonth"].ToString());
            objMember.Day = int.Parse(objRow["mday"].ToString());
            objMember.Phone = objRow["mphone"].ToString();
            objMember.Address = objRow["maddress"].ToString();
            objMember.Other = objRow["mother"].ToString();
            objMember.JoinDate = DateTime.Parse(objRow["mjoin"].ToString());
            objMember.IDCard = objRow["midcard"].ToString();
            objMember.Balance = decimal.Parse(objRow["mbalance"].ToString());
            objMember.Point = int.Parse(objRow["mpoint"].ToString());
            try
            {
                objMember.LastTime = DateTime.Parse(objRow["mlastime"].ToString());
            }
            catch
            {
            }
            Card objCard = new Card();
            if (objMember.CardID > 0)
            {
                objCard = new Table_Card().Select(objMember.CardID);
            }
            objMember.Card = objCard;

            return objMember;
        }

        /// <summary>处理DataTable中重复的数据。</summary>
        /// <param name="dt">需要处理的DataTable</param>
        /// <param name="colname">作为判断重复数据的字段(字段名)</param>
        /// <returns></returns>
        public DataTable GetDistinctTable(DataTable dt, string colname)
        {
            DataView dv = dt.DefaultView;
            DataTable dtCardNo = dv.ToTable(true, colname);
            DataTable dtPoint = new DataTable();
            dtPoint = dv.ToTable();
            dtPoint.Clear();
            for (int i = 0; i < dtCardNo.Rows.Count; i++)
            {
                DataRow dr = dt.Select(colname + "='" + dtCardNo.Rows[i][0].ToString() + "'")[0];
                dtPoint.Rows.Add(dr.ItemArray);
            }
            return dtPoint;
        }

        /// <summary>获取会员总数量</summary>
        /// <param name="mode">查询方式(0可用，1不可用，2全部)</param>
        /// <param name="cid">会员卡类型(0所有)</param>
        /// <returns></returns>
        public int GetMembersCount(int mode, int cid)
        {
            string strSql = "select count(*) from Member where 1=1";
            switch (mode)
            {
                case 0://查询可用会员数据
                    strSql += " and mstatus=0";
                    break;
                case 1://查询不可用会员数据
                    strSql += " and mstatus=1";
                    break;
                case 2://查询所有会员
                    break;
            }
            if (cid > 0)
            {
                strSql += " and mcid=" + cid;
            }
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);

            return int.Parse(objDataTable.Rows[0][0].ToString());
        }

        /// <summary>新增会员信息。</summary>
        /// <returns></returns>
        public int AddMember(Member member)
        {
            string strSql = "insert Member(mid,mname,mstatus,mcid,mpass,mremark,msex,mmonth,mday,mphone,maddress,mother,mjoin,midcard,mbalance,mpoint) " +
                "values(" + member.ID + ",'" + member.Name + "'," + member.Status
                + "," + member.CardID + ",'" + member.Password + "'," +
                "'" + member.Remark + "'," + member.Sex + "," + member.Month
                + "," + member.Day + "," + member.Phone
                + ",'" + member.Address + "','" + member.Other + "','" + member.JoinDate + "','" + member.IDCard + "','" + member.Balance + "',0)";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>
        /// 删除会员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DelMember(int mid)
        {
            string strsql = "DELETE FROM Member where mid =" + mid;
            return SqlHelper.ExecuteSql(strsql);
        }

        /// <summary>编辑会员信息。</summary>
        /// <returns></returns>
        public int UpdateMember(Member member)
        {
            string strSql = "update Member set " +
                "mname='" + member.Name + "',mstatus=" + member.Status
                + ",mcid=" + member.CardID + ",mpass='" + member.Password + "',mremark=" +
                "'" + member.Remark + "',msex=" + member.Sex + ",mmonth=" + member.Month
                + ",mday=" + member.Day + ",mphone=" + member.Phone
                + ",maddress='" + member.Address + "',mother='" + member.Other + "',midcard='" + member.IDCard + "'where mid=" + member.ID;
            return SqlHelper.ExecuteSql(strSql);
        }

        public int UpdateMemberID(Member member,string oldid)
        {
            string strSql = "update Member set mid =" + member.ID 
                + ",mname='" + member.Name + "',mstatus=" + member.Status
                + ",mcid=" + member.CardID + ",mpass='" + member.Password + "',mremark=" +
                "'" + member.Remark + "',msex=" + member.Sex + ",mmonth=" + member.Month
                + ",mday=" + member.Day + ",mphone=" + member.Phone
                + ",maddress='" + member.Address + "',mother='" + member.Other + "',midcard='" + member.IDCard + "'where mid=" + oldid;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新会员状态(退卡)。</summary>
        /// <returns></returns>
        public int UpdateStatus(string ID, string Remark)
        {
            string strSql = "update Member set mstatus=1,mremark='" + Remark + "' where mid='" + ID + "'";
            return SqlHelper.ExecuteSql(strSql);
        }


        //待修改
        /// <summary>会员换卡</summary>
        /// <param name="oldmember">旧会员卡信息</param>
        /// <param name="newid">新卡号</param>
        /// <returns></returns>
        public bool UpdateExchange(Member oldmember, string newid)
        {
            DateTime dtNow = DateTime.Now;
            //更新旧卡信息，停用旧卡
            oldmember.Remark = "换卡：新卡号" + newid;
            string strSql1 = "update Member set mstatus = 1,mremark = '" + oldmember.Remark + "',mbalance=0 where mid='" + oldmember.ID + "';";

            string strSql2 = "insert into Deposit(dmid,dmoney,ddate,dremark,dmode,dparentid) " +
                "values('" + oldmember.ID + "','" + (0 - oldmember.Balance) + "','" + dtNow + "','" + ("换卡：转出到新卡号" + newid) + "',1,0);";
            //输入新卡信息
            Member newMember = oldmember;
            string strSql3 = "insert Member(mid,mname,mstatus,mcid,mpass,mremark,msex,mmonth,mday,mphone,maddress,mother,mjoin,midcard,mbalance,mpoint) " +
                "values(" + newid + ",'" + newMember.Name + "'," + newMember.Status
                + "," + newMember.CardID + ",'" + newMember.Password + "'," +
                "'" + newMember.Remark + "'," + newMember.Sex + "," + newMember.Month
                + "," + newMember.Day + "," + newMember.Phone
                + ",'" + newMember.Address + "','" + newMember.Other + "','" + newMember.JoinDate + "','" + newMember.IDCard + "','" + newMember.Balance + "',0);";
            string strSql4 = "insert into Meposit(dmid,dmoney,ddate,dremark,dmode,dparentid) " +
                "values('" + newid + "','" + oldmember.Balance + "','" + dtNow + "','" + ("换卡：从旧卡号" + oldmember.ID + "转入") + "',2,0);";

            MySqlCommand objComm = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["Connection"]);
            objComm.Connection = conn;
            conn.Open();

            objComm.CommandText = strSql1 + strSql2 + strSql3 + strSql4;

            int i = objComm.ExecuteNonQuery();
            conn.Close();

            bool flag = false;
            if (i > 0)
                flag = true;
            return flag;
        }

        /// <summary>
        /// 会员转账
        /// </summary>
        /// <param name="from_mid"></param>
        /// <param name="to_mid"></param>
        /// <param name="balance"></param>
        /// <returns>0:更新成功;1:转账账户更新失败;2:接收账户更新失败</returns>
        public int TransferBalance(string from_mid, string to_mid, decimal balance)
        {
            int res = 3;
            decimal from_m = NowBalance(from_mid);
            string strSql = "update Member set mbalance = " + (from_m - balance) + "where mid = '" + from_mid + "'";
            decimal to_m = NowBalance(from_mid);
            string strSql1 = "update Member set mbalance = " + (to_m + balance) + "where mid = '" + to_mid + "'";

            int from_r = SqlHelper.ExecuteSql(strSql);
            int to_r = SqlHelper.ExecuteSql(strSql1);

            if (from_r > 0 && to_r > 0)
                res = 0;
            else
            {
                if (from_r < 1)
                    res = 1;
                if (to_r < 1)
                    res = 2;
            }
            return res;
        }

        private decimal NowBalance(string mid)
        {
            string strSql = "select mbalance from Member where mid = '" + mid + "';";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];
            return decimal.Parse(objRow[0].ToString());
        }

        /// <summary>更新会员余额。</summary>
        /// <param name="memberid">会员卡号</param>
        public void UpdateBalance(string memberid)
        {
            decimal dSumDeposit = new Table_Deposit().GetTotalMoneyForMember(memberid);
            decimal dSumPays = new Table_Pays().GetTotalPayForMember(memberid, 1, 0, 0, 0);
            decimal dResult = dSumDeposit - dSumPays;
            string strSql = "update Member set mbalance=" + dResult + " where mid='" + memberid + "'";
            SqlHelper.ExecuteSql(strSql);
        }

        public int UpdateLastTime(string memberid, DateTime lasttime)
        {
            string strSql = "update Member set mlastime='" + lasttime + "' where mid='" + memberid + "'";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>更新会员积分</summary>
        /// <param name="memberid">会员卡号</param>
        private void UpdatePoint(string memberid)
        {

        }

        /// <summary>
        /// 获取最近一次充值
        /// </summary>
        /// <returns></returns>
        public string LastDeposit(string ID)
        {
            string res = "";
            if (ID != null || ID != "")
            {
                string strSql = "select * from Deposit where dmid='" + ID + "' and dmode=0 order by ddate limit 1";
                DataTable objDataTable = new DataTable();
                SqlHelper.ExecuteSql(strSql, out objDataTable);
                if (objDataTable.Rows.Count > 0)
                {
                    res = DateTime.Parse(objDataTable.Rows[0]["ddate"].ToString()).ToShortDateString() + " ￥" + decimal.Parse(objDataTable.Rows[0]["dmoney"].ToString()).ToString("f2");
                }
            }
            return res;
        }
    }
}
