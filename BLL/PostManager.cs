using Model;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class PostManager
    {
        #region 自定义函数...

        /// <summary>检查职位名称是否存在。</summary>
        /// <param name="name">职位名称</param>
        /// <returns></returns>
        public int ExistsPostName(string name)
        {
            return new Table_Post().ExistsPostName(name);
        }

        /// <summary>查询所有职位信息。</summary>
        /// <returns></returns>
        public Post SelectList(int pid)
        {
            return new Table_Post().SelectList(pid);
        }

        /// <summary>查询所有职位信息。</summary>
        /// <returns></returns>
        public List<Post> SelectList()
        {
            return new Table_Post().SelectList();
        }

        /// <summary>新增职位信息。</summary>
        /// <returns></returns>
        public int InsertPost(Post objPost)
        {
            return new Table_Post().InsertPost(objPost);
        }

        /// <summary>修改职位信息。</summary>
        /// <returns></returns>
        public int UpdatePost(Post objPost)
        {
            return new Table_Post().UpdatePost(objPost);
        }

        /// <summary>删除职位信息。</summary>
        /// <param name="postid">职位编号</param>
        /// <returns></returns>
        public int DeletePost(int postid)
        {
            return new Table_Post().DeletePost(postid);
        }

        /// <summary>获取员工数量</summary>
        /// <param name="postid">职位编号</param>
        /// <returns></returns>
        public int GetEmployeeNumber(int postid)
        {
            return new Table_Post().GetEmployeeNumber(postid);
        }

        #endregion
    }
}
