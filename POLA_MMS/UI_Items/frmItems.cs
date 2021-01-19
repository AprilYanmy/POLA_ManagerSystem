using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace POLA_MMS.Items_UI
{
    public partial class frmItems : Form
    {
        private int m_iItemId = 0;

        /// <summary>商品信息</summary>
        public frmItems()
        {
            InitializeComponent();
        }

        /// <summary>商品信息</summary>
        /// <param name="itemid">商品编号</param>
        public frmItems(int itemid)
        {
            InitializeComponent();
            this.m_iItemId = itemid;
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.cboType.SelectedIndex = 0;
            this.cboStatus.SelectedIndex = 0;

            if (this.m_iItemId > 0)
            {
                SPItems objItem = new ItemsManager().SelectList(this.m_iItemId);
                this.cboType.SelectedIndex = objItem.Type;
                this.txtName.Text = objItem.Name;
                this.numFPrice.Value = objItem.FatPrice;
                this.numAmount.Value = decimal.Parse(objItem.Amount.ToString());
                this.cboStatus.SelectedIndex = objItem.Status;
                this.numUPrice.Value = objItem.UnitPrice;
                this.numNPrice.Value = objItem.NumPrice;
                this.numConvert.Value = decimal.Parse(objItem.Convert.ToString());
                this.txtReadme.Text = objItem.Readme;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SPItems objItem = new SPItems();
            ItemsManager objItemsManager = new ItemsManager();
            objItem.Type = this.cboType.SelectedIndex;
            objItem.Name = this.txtName.Text.Trim();
            objItem.FatPrice = this.numFPrice.Value;
            objItem.Amount = int.Parse(this.numAmount.Value.ToString());
            objItem.Status = this.cboStatus.SelectedIndex;
            objItem.UnitPrice = this.numUPrice.Value;
            objItem.NumPrice = this.numNPrice.Value;
            objItem.Convert = int.Parse(this.numConvert.Value.ToString());
            objItem.Readme = this.txtReadme.Text.Trim();
            if (objItem.Name == "")
            {
                MessageBox.Show("商品名称不能为空，请为该商品指定一个唯一名称。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtName.Focus();
                return;
            }
            int iTempId = objItemsManager.ExistsPostName(objItem.Name);
            if (this.m_iItemId > 0)
            {
                objItem.ID = this.m_iItemId;
                if (iTempId > 0 && iTempId != this.m_iItemId)
                {
                    MessageBox.Show("商品列表中已经存在同名商品，请为该商品指定一个唯一名称。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.Focus();
                    return;
                }
                objItemsManager.UpdateSPItems(objItem);
            }
            else
            {
                if (iTempId > 0)
                {
                    MessageBox.Show("商品列表中已经存在同名商品，请为该商品指定一个唯一名称。", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtName.Focus();
                    return;
                }
                objItemsManager.InsertSPItems(objItem);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
