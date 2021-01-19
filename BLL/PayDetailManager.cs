using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class PayDetailManager
    {
        #region 自定义函数...

        /// <summary>检查消费明细中是否存在相同商品。</summary>
        /// <param name="detailid">消费明细流水号</param>
        /// <returns></returns>
        public int ExistsPostSPItems(string payid, int itemid)
        {
            return new Table_PayDetail().ExistsPostSPItems(payid, itemid);
        }

        /// <summary>查询消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public PayDetail SelectList(decimal payid)
        {
            return new Table_PayDetail().SelectList(payid);
        }

        /// <summary>查询消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <returns></returns>
        public List<PayDetail> SelectList(string payid)
        {
            return new Table_PayDetail().SelectList(payid);
        }

        /// <summary>新增消费明细。</summary>
        /// <returns></returns>
        public int InsertDetail(PayDetail objPayDetail)
        {
            return new Table_PayDetail().InsertDetail(objPayDetail);
        }

        /// <summary>删除消费明细。</summary>
        /// <param name="detailid">消费明细流水号</param>
        /// <returns></returns>
        public int DeleteDetail(decimal detailid)
        {
            return new Table_PayDetail().DeleteDetail(detailid);
        }

        /// <summary>更新消费 。</summary>
        /// <returns></returns>
        public int UpdateDetailBonus(decimal Money, decimal DetailID)
        {
            return new Table_PayDetail().UpdateDetailBonus(Money, DetailID);
        }

        /// <summary>更新消费明细</summary>
        /// <param name="payid">消费单号</param>
        /// <param name="itemid">商品单号</param>
        /// <returns></returns>
        public int UpdateDetail(string PayID, int ItemID, int Number, decimal Money)
        {
            return new Table_PayDetail().UpdateDetail(PayID, ItemID, Number, Money);
        }

        #endregion
    }
}
