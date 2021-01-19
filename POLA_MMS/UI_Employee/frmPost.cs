using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace POLA_MMS.UI_Employee
{
    public partial class frmPost : Form
    {
        private int m_iPostId = 0;

        /// <summary>职位信息</summary>
        public frmPost()
        {
            InitializeComponent();
        }

        /// <summary>职位信息</summary>
        /// <param name="postid">职位编号</param>
        public frmPost(int postid)
        {
            InitializeComponent();
            this.m_iPostId = postid;
            this.Text = "修改职位";
        }

        private void frmPost_Load(object sender, EventArgs e)
        {
            if (this.m_iPostId > 0)
            {
                Post objPost = new PostManager().SelectList(this.m_iPostId);
                this.txtName.Text = objPost.Name;
                this.numSalary.Value = objPost.Salary;
                this.numBonus.Value = decimal.Parse(objPost.Bonus.ToString());
                this.cboMode.SelectedIndex = objPost.Mode;
                this.txtReadme.Text = objPost.Readme;
                this.txtSort.Text = objPost.Sort.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("职位名称不能为办，请输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtName.Focus();
                return;
            }
            Post objPost = new Post();
            PostManager objPostM = new PostManager();
            objPost.Name = this.txtName.Text.Trim();
            objPost.Salary = this.numSalary.Value;
            objPost.Bonus = double.Parse(this.numBonus.Value.ToString());
            objPost.Mode = this.cboMode.SelectedIndex;
            objPost.Readme = this.txtReadme.Text.Trim();
            objPost.Sort = int.Parse(this.txtSort.Text.Trim());
            int iTempId = objPostM.ExistsPostName(objPost.Name);
            if (this.m_iPostId > 0)
            {
                objPost.ID = this.m_iPostId;
                if (iTempId > 0 && iTempId != this.m_iPostId)
                {
                    MessageBox.Show("已经存在同名职位名称，请重新输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtName.Focus();
                    return;
                }
                objPostM.UpdatePost(objPost);
            }
            else
            {
                if (iTempId > 0)
                {
                    MessageBox.Show("已经存在同名职位名称，请重新输入！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtName.Focus();
                    return;
                }
                objPostM.InsertPost(objPost);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>取消</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSort_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.NumberAccpter(sender, e, false);
        }
    }
}
