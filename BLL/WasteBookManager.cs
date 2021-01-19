using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class WasteBookManager
    {
        #region 自定义函数...

        /// <summary>收支流水账。</summary>
        /// <param name="id">ID流水号</param>
        public WasteBook Select(decimal id)
        {
            return new Table_WasteBook().Select(id);
        }

        /// <summary>查询收支流水账</summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        public DataTable SelectDataTable(int year, int month, int day)
        {
            return new Table_WasteBook().SelectDataTable(year, month, day);
        }

        /// <summary>查询收支流水账</summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <param name="type">收支类型</param>
        /// <returns></returns>
        public List<WasteBook> SelectList(int year, int month, int day)
        {
            return new Table_WasteBook().SelectList(year, month, day);
        }

        /// <summary>新增收支帐目。</summary>
        /// <returns></returns>
        public int InsertWasteBook(WasteBook objWasteBook)
        {
            return new Table_WasteBook().InsertWasteBook(objWasteBook);
        }

        /// <summary>修改收支帐目。</summary>
        /// <returns></returns>
        public int UpdateExpend(WasteBook objWasteBook)
        {
            return new Table_WasteBook().UpdateExpend(objWasteBook);
        }

        /// <summary>删除记录</summary>
        /// <param name="id">记录编号</param>
        /// <returns></returns>
        public int Delete(decimal id)
        {
            return new Table_WasteBook().Delete(id);
        }

        /// <summary>支出</summary>
        public decimal GetExpendMoney(int year, int month, int day)
        {
            return new Table_WasteBook().GetExpendMoney(year, month, day);
        }

        /// <summary>收入</summary>
        public decimal GetIncomeMoney(int year, int month, int day)
        {
            return new Table_WasteBook().GetIncomeMoney(year, month, day);
        }

        #endregion
    }
}
