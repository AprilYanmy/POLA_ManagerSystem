using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POLA_MMS.UI_Card
{
    public partial class frmCard_List : WinFormsUI.Docking.DockContent
    {
        public frmCard_List()
        {
            InitializeComponent();
        }

        private void frmCard_List_Load(object sender, EventArgs e)
        {
            this.LoadCard();
        }

        /// <summary>加载会员卡类型列表。</summary>
        private void LoadCard()
        {
            List<Card> lstCard = new CardManager().SelectList(0);
            this.dgvCard.AutoGenerateColumns = false;
            this.dgvCard.Rows.Clear();
            foreach (Card objCard in lstCard)
            {
                this.dgvCard.Rows.Add(new object[] { objCard.CardId, objCard.CardName, objCard.Discount, "￥" + objCard.Money.ToString("f2"), objCard.MemberSum });
            }
        }

        /// <summary>新增</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCard objfrmCard = new frmCard();
            if (objfrmCard.ShowDialog() == DialogResult.OK)
            {
                this.LoadCard();
            }
        }

        /// <summary>修改</summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.dgvCard.CurrentRow != null)
            {
                int cardId = int.Parse(this.dgvCard.CurrentRow.Cells[0].Value.ToString());
                frmCard objfrmCard = new frmCard(cardId);
                if (objfrmCard.ShowDialog() == DialogResult.OK)
                {
                    this.LoadCard();
                }
            }
        }

        /// <summary>双击修改</summary>
        private void dgvCard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvCard.CurrentRow != null)
            {
                int cardId = int.Parse(this.dgvCard.CurrentRow.Cells[0].Value.ToString());
                frmCard objfrmCard = new frmCard(cardId);
                if (objfrmCard.ShowDialog() == DialogResult.OK)
                {
                    this.LoadCard();
                }
            }
        }

        /// <summary>删除</summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Card objCard = new Card();
            if (this.dgvCard.CurrentRow != null)
            {
                if (MessageBox.Show("确实要删除当前记录吗，删除后将不能恢复。", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int cardId = int.Parse(this.dgvCard.CurrentRow.Cells[0].Value.ToString());
                    if (new MemberManager().GetMemberTotal(2, cardId) > 0)
                    {
                        MessageBox.Show("不能删除，该会员卡类型下已有会员！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    objCard.CardId = cardId;
                    new CardManager().DeleteCard(cardId);
                    this.LoadCard();
                }
            }
        }

        private void dgvCard_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.ShowRows_DataGridView_RowPostPaint(this.dgvCard, sender, e);
        }
    }
}
