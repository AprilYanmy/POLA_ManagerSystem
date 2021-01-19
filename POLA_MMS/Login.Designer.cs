using POLA_MMS.UI_Control;

namespace POLA_MMS
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_pic = new System.Windows.Forms.PictureBox();
            this.title_bar = new System.Windows.Forms.Panel();
            this.title_btnClose = new POLA_MMS.UI_Control.Control_Button();
            this.title_line = new System.Windows.Forms.Panel();
            this.title_icon = new System.Windows.Forms.PictureBox();
            this.title_txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.pnl_loginmsg = new System.Windows.Forms.Panel();
            this.btnLogin = new POLA_MMS.UI_Control.Control_Button();
            ((System.ComponentModel.ISupportInitialize)(this.login_pic)).BeginInit();
            this.title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.title_icon)).BeginInit();
            this.pnl_loginmsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_pic
            // 
            this.login_pic.BackColor = System.Drawing.Color.Transparent;
            this.login_pic.Image = ((System.Drawing.Image)(resources.GetObject("login_pic.Image")));
            this.login_pic.Location = new System.Drawing.Point(80, 62);
            this.login_pic.Name = "login_pic";
            this.login_pic.Size = new System.Drawing.Size(128, 128);
            this.login_pic.TabIndex = 0;
            this.login_pic.TabStop = false;
            // 
            // title_bar
            // 
            this.title_bar.BackColor = System.Drawing.Color.Transparent;
            this.title_bar.Controls.Add(this.title_btnClose);
            this.title_bar.Controls.Add(this.title_line);
            this.title_bar.Controls.Add(this.title_icon);
            this.title_bar.Controls.Add(this.title_txt);
            this.title_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_bar.Location = new System.Drawing.Point(0, 0);
            this.title_bar.Name = "title_bar";
            this.title_bar.Size = new System.Drawing.Size(288, 31);
            this.title_bar.TabIndex = 2;
            this.title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_bar_MouseDown);
            // 
            // title_btnClose
            // 
            this.title_btnClose.AutoSize = true;
            this.title_btnClose.BackColor = System.Drawing.Color.Transparent;
            this.title_btnClose.BackColorLeave = System.Drawing.Color.Transparent;
            this.title_btnClose.BackColorM = System.Drawing.Color.Transparent;
            this.title_btnClose.BackColorMove = System.Drawing.Color.Transparent;
            this.title_btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.title_btnClose.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title_btnClose.ImageLeave = ((System.Drawing.Image)(resources.GetObject("title_btnClose.ImageLeave")));
            this.title_btnClose.ImageM = ((System.Drawing.Image)(resources.GetObject("title_btnClose.ImageM")));
            this.title_btnClose.ImageMove = ((System.Drawing.Image)(resources.GetObject("title_btnClose.ImageMove")));
            this.title_btnClose.Location = new System.Drawing.Point(260, 3);
            this.title_btnClose.Name = "title_btnClose";
            this.title_btnClose.Size = new System.Drawing.Size(24, 24);
            this.title_btnClose.TabIndex = 3;
            this.title_btnClose.TextColor = System.Drawing.Color.Black;
            this.title_btnClose.TextM = "";
            this.title_btnClose.ButtonClick += new System.EventHandler(this.title_btnClose_ButtonClick);
            // 
            // title_line
            // 
            this.title_line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(219)))), ((int)(((byte)(80)))));
            this.title_line.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.title_line.Location = new System.Drawing.Point(0, 30);
            this.title_line.Name = "title_line";
            this.title_line.Size = new System.Drawing.Size(288, 1);
            this.title_line.TabIndex = 0;
            // 
            // title_icon
            // 
            this.title_icon.Enabled = false;
            this.title_icon.Image = ((System.Drawing.Image)(resources.GetObject("title_icon.Image")));
            this.title_icon.InitialImage = ((System.Drawing.Image)(resources.GetObject("title_icon.InitialImage")));
            this.title_icon.Location = new System.Drawing.Point(5, 3);
            this.title_icon.Name = "title_icon";
            this.title_icon.Size = new System.Drawing.Size(24, 24);
            this.title_icon.TabIndex = 1;
            this.title_icon.TabStop = false;
            // 
            // title_txt
            // 
            this.title_txt.AutoSize = true;
            this.title_txt.Enabled = false;
            this.title_txt.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_txt.ForeColor = System.Drawing.Color.White;
            this.title_txt.Location = new System.Drawing.Point(35, 5);
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(45, 20);
            this.title_txt.TabIndex = 2;
            this.title_txt.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PassWord";
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Location = new System.Drawing.Point(92, 24);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(179, 25);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "Spencer";
            this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPass.Location = new System.Drawing.Point(92, 72);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(179, 25);
            this.txtPass.TabIndex = 3;
            this.txtPass.Text = "62209";
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnl_loginmsg
            // 
            this.pnl_loginmsg.Controls.Add(this.txtPass);
            this.pnl_loginmsg.Controls.Add(this.txtUserID);
            this.pnl_loginmsg.Controls.Add(this.label2);
            this.pnl_loginmsg.Controls.Add(this.label1);
            this.pnl_loginmsg.Location = new System.Drawing.Point(5, 235);
            this.pnl_loginmsg.Name = "pnl_loginmsg";
            this.pnl_loginmsg.Size = new System.Drawing.Size(278, 116);
            this.pnl_loginmsg.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColorLeave = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.btnLogin.BackColorM = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.btnLogin.BackColorMove = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(219)))), ((int)(((byte)(80)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.FontM = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.ImageLeave = null;
            this.btnLogin.ImageM = null;
            this.btnLogin.ImageMove = null;
            this.btnLogin.Location = new System.Drawing.Point(80, 381);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(128, 33);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.TextColor = System.Drawing.Color.Black;
            this.btnLogin.TextM = "Sign In";
            this.btnLogin.ButtonClick += new System.EventHandler(this.btnLogin_ButtonClick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(288, 470);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.title_bar);
            this.Controls.Add(this.pnl_loginmsg);
            this.Controls.Add(this.login_pic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.login_pic)).EndInit();
            this.title_bar.ResumeLayout(false);
            this.title_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.title_icon)).EndInit();
            this.pnl_loginmsg.ResumeLayout(false);
            this.pnl_loginmsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox login_pic;
        private System.Windows.Forms.Panel title_bar;
        private System.Windows.Forms.Panel title_line;
        private System.Windows.Forms.PictureBox title_icon;
        private System.Windows.Forms.Label title_txt;
        private Control_Button btnLogin;
        private Control_Button title_btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Panel pnl_loginmsg;
    }
}