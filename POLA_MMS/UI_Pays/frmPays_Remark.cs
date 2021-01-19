using System;
using System.Windows.Forms;
using BLL;

namespace POLA_MMS.Pays_UI
{
    public partial class frmPays_Remark : Form
    {
        private string _strPayId = "";

        public frmPays_Remark(string payid)
        {
            InitializeComponent();
            this._strPayId = payid;
        }

        private void frmPays_Remark_Load(object sender, EventArgs e)
        {
            Model.Pays objPay = new PayManager().GetPays(this._strPayId);
            this.lblPayID.Text = this._strPayId;
            this.txtRemark.Text = objPay.Remark;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Model.Pays objPay = new Model.Pays();
            objPay.PayID = this._strPayId;
            objPay.Remark = this.txtRemark.Text.Trim();
            if (new PayManager().UpdatePayRemark(objPay) > 0)
            {
                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
