using BLL;
using Model;
using POLA_MMS.UI_Control;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace POLA_MMS
{
    public partial class Login : Form
    {
        #region  窗体设计
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                int left,
                int top,
                int right,
                int bottom,
                int width,
                int height
            );

        public Login()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));

            ////淡入特效显示
            //Control_Animation.AnimateWindow(this.Handle, 500, Control_Animation.AW_BLEND | Control_Animation.AW_ACTIVATE);
            //上到下特效显示
            Control_Animation.AnimateWindow(this.Handle, 300, Control_Animation.AW_ACTIVATE | Control_Animation.AW_VER_POSITIVE | Control_Animation.AW_SLIDE);
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        private const int HTCAPTION = 2;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
        private void title_bar_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        #endregion

        private void title_btnClose_ButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool CheckUserInfo()
        {
            bool res = true;
            if (txtUserID.Text == "")
            {
                res = false;
                MessageBox.Show("用户名或密码不能为空，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserID.Focus();
                txtPass.Text = "";               
            }
            else if (txtPass.Text == "")
            {
                res = false;
                MessageBox.Show("用户名或密码不能为空，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
            }
            return res;
        }

        private void btnLogin_ButtonClick(object sender, EventArgs e)
        {
            if (CheckUserInfo())
            {
                UserInfo userInfo = new UserInfo()
                {
                    UserName = this.txtUserID.Text,
                    UserPassword = this.txtPass.Text
                };
                UserInfo resUserInfo = new UserInfo();
                string MessageStr = "";
                if (new LoginManager().LoginCheck(userInfo, out MessageStr, out resUserInfo))
                {
                    StaticValue.User_Type = resUserInfo.UserType;
                    //下到上特效隐藏
                    if (Control_Animation.AnimateWindow(this.Handle, 300, Control_Animation.AW_HIDE | Control_Animation.AW_VER_NEGATIVE | Control_Animation.AW_SLIDE))
                    {

                        frmMain frmMain = new frmMain();
                        frmMain.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show(MessageStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //#region  动画加载特效失败
        //UserInfo userInfo;
        //frmLoading frmLoading;
        //private async void btnLogin_ButtonClick(object sender, EventArgs e)
        //{
        //    Loading_Show();
        //    Task objTask = new Task(login_Click);
        //    objTask.Start();
        //    await objTask;
        //    Random objRandom = new Random();
        //    Thread.Sleep(objRandom.Next(500, 1500));
        //    Loading_Hide();
        //}

        //private void login_Click()
        //{
        //    userInfo = new UserInfo()
        //    {
        //        UserName = this.txtUserID.Text,
        //        UserPassword = this.txtPass.Text
        //    };
        //    UserInfo resUserInfo = new UserInfo();
        //    string MessageStr = "";
        //    if (new LoginManager().LoginCheck(userInfo, out MessageStr, out resUserInfo))
        //    {
        //        StaticValue.User_Type = resUserInfo.UserType;
        //    }
        //    else
        //        MessageBox.Show(MessageStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}


        ///// <summary>
        ///// 窗体加载动画开启
        ///// </summary>
        //private void Loading_Show()
        //{
        //    if (frmLoading == null)
        //    {
        //        frmLoading = new frmLoading();
        //        frmLoading.Width = this.Width;
        //        frmLoading.Height = this.Height;
        //        frmLoading.Location = new Point(this.Location.X, this.Location.Y);
        //        frmLoading.Show();
        //    }
        //}

        ///// <summary>
        ///// 窗体加载动画关闭
        ///// </summary>
        //private void Loading_Hide()
        //{
        //    if (frmLoading != null)
        //    {
        //        frmLoading.Close();
        //        if (!string.IsNullOrEmpty(StaticValue.User_Type))
        //        {
        //            //下到上特效隐藏
        //            if (Control_Animation.AnimateWindow(this.Handle, 300, Control_Animation.AW_HIDE | Control_Animation.AW_VER_NEGATIVE | Control_Animation.AW_SLIDE))
        //            {

        //                frmMain frmMain = new frmMain();
        //                frmMain.Show();
        //                this.Close();
        //            }
        //        }
        //        else
        //        {
        //            this.txtUserID.Focus();
        //        }
        //    }
        //}
        //#endregion
    }
}
