using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace DAL
{
    public class MySQL_ConnectionTest
    {
        string msg = "";
        string sqlconn = MySQLConnStrDecrypt.EncryptMySQLConntStr();

        public string ConntectionTest()
        {
            MySqlConnection sqlConnection = new MySqlConnection(sqlconn);

            try
            {
                sqlConnection.Open();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    msg = "数据库连接成功";
                else
                    msg = "数据库连接失败";
            }
            catch (Exception ex)
            {             
                if (ex.InnerException != null)
                    msg = ex.Message + "\n" + ex.InnerException.Message + "\n" + "数据库连接失败,请检查网络";
                else
                    msg = ex.Message + "\n" + "数据库连接失败,请检查网络";
            }
            finally
            {
                sqlConnection.Close();
            }
            return msg;
        }
    }
}
