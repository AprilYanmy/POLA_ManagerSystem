using DAL;
using Model;

namespace BLL
{
    public class LoginManager
    {
        private Table_User userDB = new Table_User();

        public bool LoginCheck(UserInfo userInfo, out string MessageStr,out UserInfo resUserInfo)
        {
            MessageStr = "";
            bool res = false;
            resUserInfo = userDB.SelectUser(userInfo);
            if (userInfo.UserName == resUserInfo.UserName)
            {
                if (userInfo.UserPassword == resUserInfo.UserPassword)
                    res = true;
                else
                    MessageStr = "输入的密码不正确，请重新输入";
            }
            else
                MessageStr = "不存在此用户";
            return res;
        }

        public bool ChangePassword(UserInfo userInfo, string OldPwd, out string MessageStr)
        {
            MessageStr = "";
            bool res = false;
            UserInfo resUserInfo = userDB.SelectUser(userInfo);
            if (userInfo.UserName == resUserInfo.UserName)
            {
                if (OldPwd == resUserInfo.UserPassword)
                    res = userDB.ChangePassword(userInfo);
                else
                    MessageStr = "原密码不正确";
            }
            else
                MessageStr = "不存在此用户";
            return res;
        }
    }
}
