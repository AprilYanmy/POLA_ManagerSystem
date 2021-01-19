using Model;
using MySqlLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class Table_Pays
    {
        SQLHelper objSQLHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        /// <summary>消费单据。</summary>
        /// <param name="payid"></param>
        public Pays GetPays(string PayID)
        {
            string strSql = "select * from Pays where pid='" + PayID + "'";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];

            Pays objPays = new Pays();
            objPays.PayID = objRow["pid"].ToString();
            objPays.MemberId = objRow["pmid"].ToString();
            objPays.EmpID1 = int.Parse(objRow["peid1"].ToString());
            objPays.EmpID2 = int.Parse(objRow["peid2"].ToString());
            objPays.EmpID3 = int.Parse(objRow["peid3"].ToString());
            objPays.Money = decimal.Parse(objRow["pmoney"].ToString());
            objPays.EmpIDPerf1 = decimal.Parse(objRow["perf1"].ToString());
            objPays.EmpIDPerf2 = decimal.Parse(objRow["perf2"].ToString());
            objPays.EmpIDPerf3 = decimal.Parse(objRow["perf3"].ToString());
            objPays.Proj1 = decimal.Parse(objRow["proj1"].ToString());
            objPays.Proj2 = decimal.Parse(objRow["proj2"].ToString());
            objPays.Proj3 = decimal.Parse(objRow["proj3"].ToString());
            objPays.Cash = objRow["pcash"].ToString();
            objPays.Zero = objRow["pzero"].ToString();
            objPays.PayType = int.Parse(objRow["ptype"].ToString());
            objPays.PayDate = DateTime.Parse(objRow["pdate"].ToString());
            objPays.Remark = objRow["premark"].ToString();
            objPays.Status = int.Parse(objRow["pstatus"].ToString());

            Member objMember = new Member();
            if ((objPays.MemberId != null || objPays.MemberId != "" || objPays.MemberId != "0"))
            {
                objMember = new Table_Member().SelectMemberInfo(objPays.MemberId);
            }
            objPays.Member = objMember;

            List<PayDetail> objPayDetailList = new List<PayDetail>();
            if (PayID != null || PayID != "")
            {
                objPayDetailList = new Table_PayDetail().SelectList(PayID);
            }
            objPays.PayDetails = objPayDetailList;

            return objPays;
        }

        /// <summary>获取消费单据。</summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Pays GetPays(DataRow row)
        {
            Pays objPay = new Pays();
            objPay.PayID = row["pid"].ToString();
            objPay.MemberId = row["pmid"].ToString();
            objPay.EmpID1 = int.Parse(row["peid1"].ToString());
            objPay.EmpID2 = int.Parse(row["peid2"].ToString());
            objPay.EmpID3 = int.Parse(row["peid3"].ToString());
            objPay.Money = decimal.Parse(row["pmoney"].ToString());
            objPay.EmpIDPerf1 = decimal.Parse(row["perf1"].ToString());
            objPay.EmpIDPerf2 = decimal.Parse(row["perf2"].ToString());
            objPay.EmpIDPerf3 = decimal.Parse(row["perf3"].ToString());
            objPay.Proj1 = decimal.Parse(row["proj1"].ToString());
            objPay.Proj2 = decimal.Parse(row["proj2"].ToString());
            objPay.Proj3 = decimal.Parse(row["proj3"].ToString());
            objPay.Cash = row["pcash"].ToString();
            objPay.Zero = row["pzero"].ToString();
            objPay.PayType = int.Parse(row["ptype"].ToString());
            objPay.PayDate = DateTime.Parse(row["pdate"].ToString());
            objPay.Remark = row["premark"].ToString();
            objPay.Status = int.Parse(row["pstatus"].ToString());

            Member objMember = new Member();
            if (objPay.MemberId != "0")
            {
                objMember = new Table_Member().SelectMemberInfo(objPay.MemberId);
            }
            objPay.Member = objMember;

            List<PayDetail> objPayDetailList = new List<PayDetail>();
            if (objPay.PayID != null || objPay.PayID != "")
            {
                objPayDetailList = new Table_PayDetail().SelectList(objPay.PayID);
            }
            objPay.PayDetails = objPayDetailList;

            return objPay;
        }

        /// <summary>获取最后一条消费单号。</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public string ExistsPayCode()
        {
            string strSql = "select pid from Pays order by CONVERT(pid,SIGNED) desc limit 1;";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            if (objDataTable.Rows.Count > 0)
            {
                return objDataTable.Rows[0]["pid"].ToString();
            }
            return "";
        }

        /// <summary>获取会员消费总金额。</summary>
        /// <param name="memberid">会员卡号</param>
        /// <param name="type">支付方式(只能输入0现金或1余额)</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public decimal GetTotalPayForMember(string memberid, int type, int year, int month, int day)
        {
            string strSql = "select sum(pmoney) from Pays where ptype=" + type;
            if (memberid != "")
            {
                strSql += " and pmid='" + memberid + "'";
            }
            if (year > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%Y')=" + year;
            }
            if (month > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%c')=" + month;
            }
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%e')=" + day;
            }
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            try
            {
                return decimal.Parse(objDataTable.Rows[0][0].ToString());
            }
            catch
            { }
            return 0;
        }

        /// <summary>查询员工业绩</summary>
        /// <param name="empid">员工编号(ID)</param>
        /// <returns></returns>
        public List<Pays> SelectListForEmployee(int empid, int year, int month)
        {
            string strSql = "select * from Pays where (DATE_FORMAT(pdate, '%Y')=" + year + " and DATE_FORMAT(pdate, '%c')=" + month + ") and (peid1=" + empid + " or peid2=" + empid + " or peid3=" + empid + ") and pstatus=1";
            strSql += " order by pdate";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            List<Pays> lstPay = new List<Pays>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                lstPay.Add(this.GetPays(objRow));
            }
            return lstPay;
        }

        /// <summary>获取员工业绩数量。</summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int GetCountForEmployee(int empid, int year, int month)
        {
            string strSql = "select count(*) from Pays where (DATE_FORMAT(pdate, '%Y')=" + year + " and DATE_FORMAT(pdate, '%c')=" + month + ") and (peid1=" + empid + " or peid2=" + empid + " or peid3=" + empid + ")";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            return int.Parse(objDataTable.Rows[0][0].ToString());
        }

        /// <summary>获取员工业绩金额。</summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public decimal GetMoneyForEmployee(int empid, int year, int month)
        {
            string strSql = "select sum(pmoney) from Pays where (DATE_FORMAT(pdate, '%Y')=" + year + " and DATE_FORMAT(pdate, '%c')=" + month + ") and (peid1=" + empid + " or peid2=" + empid + " or peid3=" + empid + ")";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);

            List<Pays> lstPays = SelectListForEmployee(empid, year, month);
            decimal dSum = 0;

            foreach (Pays objPay in lstPays)
            {
                dSum += objPay.Money;
            }
            return dSum;
        }

        /// <summary>
        /// 获取员工提成金额
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public decimal GetBonusForEmployee(int empid, int year, int month)
        {
            string strSql = "select sum(pmoney) from Pays where (DATE_FORMAT(pdate, '%Y')=" + year + " and DATE_FORMAT(pdate, '%c')=" + month + ") and (peid1=" + empid + " or peid2=" + empid + " or peid3=" + empid + ")";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);

            List<Pays> lstPays = SelectListForEmployee(empid, year, month);
            decimal dSum = 0;

            foreach (Pays objPay in lstPays)
            {
                dSum += SumBonus(objPay, empid);
            }
            return dSum;

        }

        /// <summary>
        /// 计算每一笔消费的提成
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        private decimal SumBonus(Pays pays, int m_iEmpId)
        {
            decimal Bonus = 0;
            if (pays.EmpID1 == m_iEmpId)
                Bonus += (pays.EmpIDPerf1 * pays.Proj1);
            if (pays.EmpID2 == m_iEmpId)
                Bonus += (pays.EmpIDPerf2 * pays.Proj2);
            if (pays.EmpID3 == m_iEmpId)
                Bonus += (pays.EmpIDPerf3 * pays.Proj3);
            return Bonus;
        }

        /// <summary>查询会员消费单据</summary>
        /// <param name="payid">消费单号</param>
        /// <param name="memberid">会员卡号</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="type">支付方式</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Pays> SelectList(string payid, string memberid, int year, int month, int day, int? type, int? status)
        {
            string strSql = "select * from Pays where 1=1";
            if (payid != "")
            {
                strSql += " and pid like '" + payid + "%'";
            }
            if (memberid != "")
            {
                strSql += " and pmid='" + memberid + "'";
            }
            if (year > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%Y')=" + year;
            }
            if (month > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%c')=" + month;
            }
            if (day > 0)
            {
                strSql += " and DATE_FORMAT(pdate, '%e')=" + day;
            }
            if (type != null)
            {
                strSql += " and ptype=" + type;
            }
            if (status != null)
            {
                strSql += " and pstatus=" + status;
            }
            strSql += " order by pdate";
            DataTable objDataTable = new DataTable();
            objSQLHelper.ExecuteSql(strSql, out objDataTable);
            List<Pays> lstPay = new List<Pays>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                lstPay.Add(this.GetPays(objRow));
            }
            return lstPay;
        }

        /// <summary>新增消费单据。</summary>
        /// <returns></returns>
        public int InsertPay(Pays objPays)
        {
            int ret = -1;
            try
            {
                string strSql = "insert into Pays(pid,pmid,peid1,peid2,peid3,pmoney,premark,pdate,pstatus,ptype,proj1,proj2,proj3,perf1,perf2,perf3) " +
                "values('" + objPays.PayID + "','" + objPays.MemberId + "'," + objPays.EmpID1 + "," + objPays.EmpID2 + "," + objPays.EmpID3 + ",'" + objPays.Money + "','" + objPays.Remark + "','" + objPays.PayDate + "',0,0," + objPays.Proj1 + "," + objPays.Proj2 + "," + objPays.Proj3 + "," + objPays.EmpIDPerf1 + "," + objPays.EmpIDPerf2 + "," + objPays.EmpIDPerf3 + ")";
                ret = objSQLHelper.ExecuteSql(strSql);
            }
            catch
            {
                string strsql = "UPDATE Pays SET pmid = '" + objPays.MemberId + "', peid1 = " + objPays.EmpID1 + ", peid2 = " + objPays.EmpID2 + ", peid3 = " + objPays.EmpID3 + ", pmoney = " + objPays.Money + ", ptype = 0, pstatus = 0, proj1 = '" + objPays.Proj1 + "', proj2 = '" + objPays.Proj2 + "', proj3 = '" + objPays.Proj3 + "', perf1 = '" + objPays.EmpIDPerf1 + "', perf2 = '" + objPays.EmpIDPerf2 + "', perf3 = '" + objPays.EmpIDPerf3 + "' WHERE pid = '" + objPays.PayID + "'";
                ret = objSQLHelper.ExecuteSql(strsql);
            }
            return ret;
        }

        /// <summary>更新消费单据</summary>
        /// <returns></returns>
        public int UpdatePay(Pays objPays)
        {
            string strSql = "update Pays set pmid='" + objPays.MemberId + "',peid1=" + objPays.EmpID1 + ",peid2=" + objPays.EmpID2 + ",peid3=" + objPays.EmpID3 + ",pmoney='" + objPays.Money + "',premark='" + objPays.Remark + "',pdate='" + objPays.PayDate + "' where pid='" + objPays.PayID + "'";
            return objSQLHelper.ExecuteSql(strSql);
        }

        /// <summary>删除消费单据</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public bool DeletePay(string payid)
        {
            string[] strSql = new string[2];
            strSql[0] = "delete from Pays where pid='" + payid + "'";
            strSql[1] = "delete from PayDetails where pdpid='" + payid + "'";
            if (objSQLHelper.ExecuteSql(strSql[0]) > 0 || objSQLHelper.ExecuteSql(strSql[1]) > 0)
                return true;
            else
                return false;
        }

        /// <summary>更新消费备注信息。</summary>
        public int UpdatePayRemark(Pays objPays)
        {
            string strSql = "update Pays set premark = '" + objPays.Remark + "' where pid = '" + objPays.PayID + "'";
            return objSQLHelper.ExecuteSql(strSql);
        }

        /// <summary>确认收款</summary>
        /// <returns></returns>
        public int UpdatePaysOK(Pays objPays)
        {
            string strSql = "update Pays set pcash='" + objPays.Cash + "',pzero='" + objPays.Zero + "',ptype='" + objPays.PayType + "',premark='" + objPays.Remark + "',pstatus=1 where pid='" + objPays.PayID + "'";
            return objSQLHelper.ExecuteSql(strSql);
        }

        /// <summary>更新消费金额</summary>
        /// <param name="payid"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int UpdateMoney(string payid, decimal money)
        {
            string strSql = "update Pays set pmoney='" + money + "' where pid='" + payid + "'";
            return objSQLHelper.ExecuteSql(strSql);
        }
    }
}
