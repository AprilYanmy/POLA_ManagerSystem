using Model;
using System.Data;
using MySqlLibrary;
using System.Configuration;

namespace DAL
{
    public class Table_User
    {
        SQLHelper SqlHelper = new SQLHelper(MySQLConnStrDecrypt.EncryptMySQLConntStr());

        public UserInfo SelectUser(UserInfo userInfo)
        {
            DataTable dt = new DataTable();
            string sql = "select * from UserInfo where UserName = '" + userInfo.UserName + "';";
            SqlHelper.ExecuteSql(sql, out dt);
            UserInfo info = new UserInfo();
            if (dt.Rows.Count > 0)
            {
                info.UserName = dt.Rows[0]["UserName"].ToString();
                info.UserPassword = dt.Rows[0]["UserPassword"].ToString();
                info.UserType = dt.Rows[0]["UserType"].ToString();
            }
            return info;
        }

        public bool ChangePassword(UserInfo userInfo)
        {
            string strSql = "update UserInfo set UserPassword = '" + userInfo.UserPassword + "' where UserName='" + userInfo.UserName + "';";
            bool res = false;
            if (SqlHelper.ExecuteSql(strSql) > 0)
                res = true;
            return res;
        }
    }
}
