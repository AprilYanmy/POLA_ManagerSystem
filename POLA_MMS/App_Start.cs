using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using POLA_MMS.UI_Control;
using Timer = System.Windows.Forms.Timer;

namespace POLA_MMS
{
    public partial class App_Start : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                int left,
                int top,
                int right,
                int bottom,
                int width,
                int height
            );

        private string sqlmsg = "";

        public App_Start()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            Default();

            //淡入特效显示
            Control_Animation.AnimateWindow(this.Handle, 500, Control_Animation.AW_BLEND | Control_Animation.AW_ACTIVATE);
        }

        void Default()
        {
            lblLoading.Text = "Loading 0%";
            pnlLoading.Width = 0;
            lbl_msg.Text = "";
        }

        private async void App_Start_Load(object sender, EventArgs e)
        {
            timer1.Start();

            Task objtesk = new Task(DBTest);
            objtesk.Start();
            await objtesk;

            lbl_msg.Text = sqlmsg;
            timer2.Start();
        }

        private void DBTest()
        {
            sqlmsg = Common.MySQL_ConnectionTest();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lbl_msg.Text == "")
            {
                if (pnlLoading.Width < 500)
                {
                    pnlLoading.Width += 5;
                    if (pnlLoading.Width >= 500)
                        pnlLoading.Width = 500;
                    lblLoading.Text = "Loading " + ((pnlLoading.Width / 500.00) * 100).ToString() + "%";
                }
            }
            else
            {
                pnlLoading.Width = 500;
                lblLoading.Text = "Loading 100%";
            }

            if (lbl_msg.Text == "数据库连接成功" && pnlLoading.Width == 500)
            {
                timer1.Stop();
                //Thread.Sleep(600);
                //淡出特效
                if (Control_Animation.AnimateWindow(this.Handle, 500, Control_Animation.AW_BLEND | Control_Animation.AW_HIDE))
                {
                    Login login = new Login();
                    login.Show();
                }
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lbl_msg.Text != "数据库连接成功" && pnlLoading.Width == 500)
            {
                timer1.Stop();
                Thread.Sleep(2000);
                lbl_msg.Text = "即将退出程序。。。";
                Thread.Sleep(600);
                //淡出特效
                Control_Animation.AnimateWindow(this.Handle, 500, Control_Animation.AW_BLEND | Control_Animation.AW_HIDE);
                Application.Exit();
            }
        }
    }
}
