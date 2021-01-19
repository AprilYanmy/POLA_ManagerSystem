using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POLA_MMS.Pays_UI
{
    public partial class frmPay_OK : Form
    {
        private Pays _objPay = new Pays();//消费单据信息
        private decimal _dZero = 0;
        private decimal _Mounts = 0;

        public frmPay_OK(string payid)
        {
            InitializeComponent();
            this._objPay = new PayManager().GetPays(payid);  //将之前保存的消费单据取出
            if (this._objPay.PayDetails.Count > 0)
                //_Mounts = this._objPay.Money + this._objPay.Proj1 + this._objPay.Proj2 + this._objPay.Proj3;
                _Mounts = this._objPay.Money;
            else
                _Mounts = this._objPay.Money;
        }

        private void frmPay_OK_Load(object sender, EventArgs e)
        {
            if (this._objPay.MemberId == "0")
            {
                this.lblName.Text += "非会员(散客)";
                this.lblBalance.Text += "￥0.00";
                this.rbtnBalance.Enabled = false;
                this.rbtnAnd.Enabled = false;
                this.LoadCashPay();//初始化现金支付数据
            }
            else //会员
            {
                this.lblName.Text += this._objPay.ClientName;
                this.lblBalance.Text += this._objPay.Member.Balance.ToString("f2");
                if (this._objPay.Member.Balance >= _Mounts)
                {
                    //余额大于等于消费金额
                    this.rbtnBalance.Checked = true;
                    this.rbtnAnd.Enabled = true;
                    this.LoadBalancePay();
                }
                else if (this._objPay.Member.Balance < _Mounts)
                {
                    //余额小于消费金额
                    this.rbtnBalance.Enabled = false;
                    this.LoadCashPay();
                }
            }
            this.lblPayID.Text += this._objPay.PayID;
            this.lblMoney.Text += "￥" + (_Mounts).ToString("f2");//消费金额

        }

        #region 支付方式...

        /// <summary>现金</summary>
        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnCash.Checked)
            {
                this.LoadCashPay();
            }
        }

        /// <summary>初始化现金支付数据</summary>
        private void LoadCashPay()
        {
            this.numPayBalance.Text = "0";
            this.numPayMoney.Text = _Mounts.ToString();
            this.txtCash.Text = (_Mounts).ToString("f2");

            this.numPayBalance.Enabled = false;
            this.numPayMoney.Enabled = false;
            this.txtCash.ReadOnly = false;
        }

        /// <summary>余额</summary>
        private void rbtnBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnBalance.Checked)
            {
                this.LoadBalancePay();
            }
        }

        /// <summary>初始化余额支付数据</summary>
        private void LoadBalancePay()
        {
            this.numPayBalance.Text = _Mounts.ToString();
            this.numPayMoney.Text  = "0";
            this.txtCash.Text = "0.00";

            this.numPayBalance.Enabled = false;
            this.numPayMoney.Enabled = false;
            
        }

        /// <summary>现金+余额</summary>
        private void rbtnAnd_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnAnd.Checked)
            {
                this.LoadCashPay();
                this.numPayBalance.Enabled = true;
                this.numPayMoney.Enabled = true;
                this.txtCash.ReadOnly = false;
            }
        }

        #endregion

        /// <summary>确定</summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Model.Pays objPay = new Model.Pays();
            objPay.PayID = this._objPay.PayID;
            objPay.Cash = this.txtCash.Text;//实收金额
            objPay.Zero = this._dZero.ToString();// (decimal.Parse(this.txtCash.Text.Trim()) - this.numPayMoney.Value).ToString("f2");
            objPay.Remark = "";
            if (this.rbtnCash.Checked)
            {
                objPay.PayType = 0;//现金
            }
            else if (this.rbtnBalance.Checked || this.rbtnAnd.Checked)
            {
                objPay.PayType = 1;//余额
            }
            //判断现金消费
            if (decimal.Parse(objPay.Cash) < decimal.Parse(this.numPayMoney.Text))
            {
                MessageBox.Show("【实收金额】必须大于等于【应收金额】", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCash.Focus();
                return;
            }
            if (this.rbtnAnd.Checked)
            {
                objPay.Remark = "\n[现金+余额]现金：" + this.numPayMoney.Text + "；刷卡：" + this.numPayBalance.Text + "；";
                Deposit objDeposit = new Deposit();
                objDeposit.Remark = "[现金+余额]现金：" + this.numPayMoney.Text + "；刷卡：" + this.numPayBalance.Text + "；消费单号：" + this._objPay.PayID;
                objDeposit.Mode = 0;
                objDeposit.MemberID = this._objPay.MemberId;
                objDeposit.Money = decimal.Parse(this.numPayMoney.Text);
                objDeposit.Date = this._objPay.PayDate;

                new DepositManager().InsertDeposit(objDeposit);
            }
            if (new PayManager().UpdatePaysOK(objPay) > 0)
            {
                new MemberManager().UpdateBalance(this._objPay.MemberId);
                new MemberManager().UpdateLastTime(this._objPay.MemberId, this._objPay.PayDate);
            }

            //更新库存(没有添加该功能)


            DialogResult = DialogResult.OK;
            this.Close();
        }

        #region 计算找零金额...

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            this.FindZeroCash();
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            //NumericClass.NumberAccpter(sender, e, true);
        }

        /// <summary>计算找零。</summary>
        private void FindZeroCash()
        {
            decimal dCash = 0;
            if (this.txtCash.Text.Trim() != "")
            {
                dCash = decimal.Parse(this.txtCash.Text.Trim());
            }
            else
            {
                this.txtCash.Text = "0";
                this.txtCash.SelectionStart = this.txtCash.Text.Length;
            }
            this._dZero = dCash - decimal.Parse(this.numPayMoney.Text);
            if (this.rbtnBalance.Checked)
            {
                this._dZero = 0;
            }
            this.lblZero.Text = "￥" + this._dZero.ToString("f2");
        }

        #endregion

        /// <summary>取消关闭窗体。</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numPayBalance_ValueChanged(object sender, EventArgs e)
        {
            this.numPayMoney.Text = (_Mounts - decimal.Parse(this.numPayBalance.Text)).ToString();
            this.txtCash.Text = this.numPayMoney.Text;
            this.FindZeroCash();
        }

        ///// <summary>变更刷卡金额</summary>
        //private void numPayBalance_KeyUp(object sender, KeyEventArgs e)
        //{
        //    this.numPayMoney.Value = this._objPay.Money - this.numPayBalance.Value;
        //    this.FindZeroCash();
        //}

        private void numPayMoney_ValueChanged(object sender, EventArgs e)
        {
            this.numPayBalance.Text = (_Mounts - decimal.Parse(this.numPayMoney.Text)).ToString();
            this.FindZeroCash();
        }

        private void numPayMoney_KeyUp(object sender, KeyEventArgs e)
        {
            this.numPayBalance.Text = (_Mounts - decimal.Parse(this.numPayMoney.Text)).ToString();
            this.FindZeroCash();
        }

        public string ToCal(double amount, double perf)
        {
            return "￥" + String.Format("{0:F}", amount * perf);
        }
    }
}
