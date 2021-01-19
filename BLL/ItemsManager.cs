using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ItemsManager
    {
        #region 自定义函数...

        /// <summary>检查商品名称是否存在。</summary>
        /// <param name="name">商品名称</param>
        /// <returns></returns>
        public int ExistsPostName(string name)
        {
            return new Table_Items().ExistsPostName(name);
        }

        /// <summary>商品信息。</summary>
        /// <param name="itemid">商品编号</param>
        public SPItems SelectList(int itemid)
        {
            return new Table_Items().SelectList(itemid);
        }

        /// <summary>查询商品信息</summary>
        /// <param name="type">商品类型(0为所有类型)</param>
        /// <param name="text"></param>
        /// <param name="status">商品状态(0为所有状态)</param>
        /// <returns></returns>
        public List<SPItems> SelectList(int type, string text, int status)
        {
            return new Table_Items().SelectList(type, text, status);
        }

        /// <summary>新增商品信息。</summary>
        /// <returns></returns>
        public int InsertSPItems(SPItems objSPItems)
        {
            return new Table_Items().InsertSPItems(objSPItems);
        }

        /// <summary>修改商品信息。</summary>
        /// <returns></returns>
        public int UpdateSPItems(SPItems objSPItems)
        {
            return new Table_Items().UpdateSPItems(objSPItems);
        }

        /// <summary>商品下(上)架</summary>
        /// <returns></returns>
        public int DownSPItems(int Status, int ID)
        {
            return new Table_Items().DownSPItems(Status, ID);
        }

        #endregion
    }
}
