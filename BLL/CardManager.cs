using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class CardManager
    {
        #region 自定义函数...

        /// <summary>检查会员卡类型是否存在。</summary>
        /// <param name="name">会员卡类型名称</param>
        /// <returns></returns>
        public int ExistsCardName(string name)
        {
            return new Table_Card().ExistsCardName(name);
        }

        /// <summary>会员卡类型管理。</summary>
        /// <param name="cid">会员类型标识</param>
        public Card Select(int cid)
        {
            return new Table_Card().Select(cid);
        }

        /// <summary>查询会员卡类型数据。</summary>
        /// <param name="cid">会员卡标识，为0时查询所有数据</param>
        /// <returns></returns>
        public List<Card> SelectList(int cid)
        {
            return new Table_Card().SelectList(cid);
        }

        /// <summary>新增会员卡类型。</summary>
        /// <returns></returns>
        public int InsertCard(Card objCard)
        {
            return new Table_Card().InsertCard(objCard);
        }

        /// <summary>修改会员卡类型。</summary>
        /// <returns></returns>
        public int UpdateCard(Card objCard)
        {
            return new Table_Card().UpdateCard(objCard);
        }

        /// <summary>删除会员卡类型。</summary>
        /// <returns></returns>
        public int DeleteCard(int CardId)
        {
            return new Table_Card().DeleteCard(CardId);
        }
        #endregion
    }
}
