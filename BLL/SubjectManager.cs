using Model;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class SubjectManager
    {
        #region 自定义函数...

        /// <summary>科目管理。</summary>
        /// <param name="subId">科目标识(ID)</param>
        public Subject Select(int subId)
        {
            return new Table_Subject().Select(subId);
        }

        /// <summary>检查科目名称是否存在。</summary>
        /// <param name="name">科目名称</param>
        /// <returns></returns>
        public int ExistsSubjectName(string name)
        {
            return new Table_Subject().ExistsSubjectName(name);
        }

        /// <summary>添加科目信息。</summary>
        /// <returns></returns>
        public int InsertSubject(Subject objSubject)
        {
            return new Table_Subject().InsertSubject(objSubject);
        }

        /// <summary>修改科目信息。</summary>
        /// <returns></returns>
        public int UpdateSubject(Subject objSubject)
        {
            return new Table_Subject().UpdateSubject(objSubject);
        }

        /// <summary>更新科目状态。</summary>
        /// <returns></returns>
        public int UpdateStatus(int IsEnabled, int ID)
        {
            return new Table_Subject().UpdateStatus(IsEnabled, ID);
        }

        /// <summary>查询科目信息。</summary>
        /// <param name="type">收支类型</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Subject> SelectList(int type, int status)
        {
            return new Table_Subject().SelectList(type, status);
        }

        #endregion
    }
}
