using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace POLA_MMS.Pays_UI
{
    public partial class frmPayDetail_Bonus : Form
    {
        private int _iIndex = -1;
        private decimal _iDetailId = 0;

        public frmPayDetail_Bonus(int index)
        {
            InitializeComponent();
            this._iIndex = index;
        }

        public frmPayDetail_Bonus(decimal detailid)
        {
            InitializeComponent();
            this._iDetailId = detailid;
        }

        private void frmPayDetail_Bonus_Load(object sender, EventArgs e)
        {
            PayDetail objDetail = new PayDetail();
            if (this._iIndex > -1)
            {
                objDetail = StaticValue.g_lstTempPayDetails[this._iIndex];
            }
            else if (this._iDetailId > 0)
            {
                objDetail = new PayDetailManager().SelectList(this._iDetailId);
            }
            this.lblName.Text = objDetail.SPItem.Name;
            this.lblPrice.Text = "￥" + objDetail.SPItem.UnitPrice.ToString("f2");
            this.numBonused.Value = objDetail.Money;
        }

        /// <summary>确定按钮</summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this._iDetailId == 0)
            {
                StaticValue.g_lstTempPayDetails[this._iIndex].Money = this.numBonused.Value;
            }
            else
            {
                new PayDetailManager().UpdateDetailBonus(this.numBonused.Value, this._iDetailId);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>取消按钮</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
