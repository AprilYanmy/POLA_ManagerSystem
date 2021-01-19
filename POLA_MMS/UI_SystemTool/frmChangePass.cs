using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace POLA_MMS
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() == "")
            {
                MessageBox.Show("请重输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserID.Focus();
                return;
            }


            if (txtOldPass.Text.Trim() == "")
            {
                MessageBox.Show("请重输入原密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPass.Focus();
                return;
            }


            if (txtnewpass.Text.Trim() == "")
            {
                MessageBox.Show("请重输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnewpass.Focus();
                return;
            }

            UserInfo userInfo = new UserInfo()
            {
                UserName = txtUserID.Text,
                UserPassword = txtnewpass.Text
            };
            LoginManager loginManager = new LoginManager();
            string MessageStr = "";
            if (loginManager.ChangePassword(userInfo, txtOldPass.Text, out MessageStr))
            {
                MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(MessageStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
