using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlLibrary;
using System.Configuration;

namespace DAL
{
    public class Table_Post
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        #region 自定义函数...

        /// <summary>检查职位名称是否存在。</summary>
        /// <param name="name">职位名称</param>
        /// <returns></returns>
        public int ExistsPostName(string name)
        {
            string strSql = "select * from Post where pname='" + name + "'";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            if (objDataTable.Rows.Count > 0)
            {
                return int.Parse(objDataTable.Rows[0]["pid"].ToString());
            }
            return 0;
        }

        /// <summary>查询所有职位信息。</summary>
        /// <returns></returns>
        public Post SelectList(int pid)
        {
            string strSql = "select * from Post where pid=" + pid;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            DataRow objRow = objDataTable.Rows[0];

            Post objPost = new Post();
            objPost.ID = int.Parse(objRow["pid"].ToString());
            objPost.Name = objRow["pname"].ToString();
            objPost.Readme = objRow["preadme"].ToString();
            objPost.Mode = int.Parse(objRow["pmode"].ToString());
            objPost.Sort = int.Parse(objRow["psort"].ToString());
            objPost.Salary = decimal.Parse(objRow["psalary"].ToString());
            objPost.Bonus = double.Parse(objRow["pbonus"].ToString());

            return objPost;
        }

        /// <summary>查询所有职位信息。</summary>
        /// <returns></returns>
        public List<Post> SelectList()
        {
            string strSql = "select * from Post order by psort";
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            List<Post> lstPost = new List<Post>();
            foreach (DataRow objRow in objDataTable.Rows)
            {
                Post objPost = new Post();
                objPost.ID = int.Parse(objRow["pid"].ToString());
                objPost.Name = objRow["pname"].ToString();
                objPost.Readme = objRow["preadme"].ToString();
                objPost.Mode = int.Parse(objRow["pmode"].ToString());
                objPost.Sort = int.Parse(objRow["psort"].ToString());
                objPost.Salary = decimal.Parse(objRow["psalary"].ToString());
                objPost.Bonus = double.Parse(objRow["pbonus"].ToString());
                lstPost.Add(objPost);
            }
            return lstPost;
        }

        /// <summary>新增职位信息。</summary>
        /// <returns></returns>
        public int InsertPost(Post objPost)
        {
            string strSql = "insert into Post(pname,pbonus,preadme,psort,psalary,pmode) values('" + objPost.Name + "'," + objPost.Bonus + ",'" + objPost.Readme + "'," +
                objPost.Sort + "," + objPost.Salary + "," + objPost.Mode + ")";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>修改职位信息。</summary>
        /// <returns></returns>
        public int UpdatePost(Post objPost)
        {
            string strSql = "update Post set pname='" + objPost.Name + "',pbonus=" + objPost.Bonus + ",preadme='" + objPost.Readme + "',psort=" +
                objPost.Sort + ",psalary=" + objPost.Salary + ",pmode=" + objPost.Mode + " where pid=" + objPost.ID + "";
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>删除职位信息。</summary>
        /// <param name="postid">职位编号</param>
        /// <returns></returns>
        public int DeletePost(int postid)
        {
            string strSql = "delete from Post where pid=" + postid;
            return SqlHelper.ExecuteSql(strSql);
        }

        /// <summary>获取员工数量</summary>
        /// <param name="postid">职位编号</param>
        /// <returns></returns>
        public int GetEmployeeNumber(int postid)
        {
            string strSql = "select count(*) from Employee where epid=" + postid;
            DataTable objDataTable = new DataTable();
            SqlHelper.ExecuteSql(strSql, out objDataTable);
            int iCount = int.Parse(objDataTable.Rows[0][0].ToString());
            return iCount;
        }

        #endregion
    }
}
