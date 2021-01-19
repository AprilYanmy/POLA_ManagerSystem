using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POLA_MMS.UI_Employee
{
    public partial class frmEmployee_Pays : Form
    {
        private int m_iEmpId = 0;
        private bool bRun = false;

        /// <summary>查看员工业绩。</summary>
        public frmEmployee_Pays(int empid)
        {
            InitializeComponent();
            this.m_iEmpId = empid;
        }

        private void LoadData()
        {
            for (int y = 2011; y <= DateTime.Now.Year; y++)
            {
                this.cboYear.Items.Add(y.ToString());
            }
            for (int m = 1; m <= 12; m++)
            {
                this.cboMonth.Items.Add(m.ToString());
            }
            this.cboYear.Text = DateTime.Now.Year.ToString();
            this.cboMonth.Text = DateTime.Now.Month.ToString();
        }

        /// <summary>加载员工业绩</summary>
        private void LoadPaysForEmployee()
        {
            int iYear = int.Parse(this.cboYear.Text);
            int iMonth = int.Parse(this.cboMonth.Text);
            List<Pays> lstPays = new PayManager().SelectListForEmployee(this.m_iEmpId, iYear, iMonth);
            this.dgvPays.AutoGenerateColumns = false;
            this.dgvPays.Rows.Clear();
            decimal dMoney = 0;
            decimal dBonus = 0;
            foreach (Pays objPay in lstPays)
            {
                dMoney += objPay.Money;
                decimal bonus = SumBonus(objPay);
                dBonus += bonus;
                this.dgvPays.Rows.Add(new object[] { objPay.PayID, ConsumptionItem(objPay) + objPay.PayContent, objPay.Money, bonus, objPay.PayDate, objPay.Remark });
            }
            this.lblSum.Text = "本月总业绩：￥" + dMoney.ToString("f2");
            this.lblBonus.Text = "本月业绩提成：￥" + dBonus.ToString("f2");
        }

        /// <summary>
        /// 计算每一笔消费的提成
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        private decimal SumBonus(Pays pays)
        {
            decimal Bonus = 0;
            if (pays.EmpID1 == this.m_iEmpId)
                Bonus += (pays.EmpIDPerf1 * pays.Proj1);
            if (pays.EmpID2 == this.m_iEmpId)
                Bonus += (pays.EmpIDPerf2 * pays.Proj2);
            if (pays.EmpID3 == this.m_iEmpId)
                Bonus += (pays.EmpIDPerf3 * pays.Proj3);
            return Bonus;
        }

        /// <summary>
        /// 业绩内容添加服务项目
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        private string ConsumptionItem(Pays pays)
        {
            string content = "";
            if (pays.EmpID1 == this.m_iEmpId)
                content += "项目一,";
            if (pays.EmpID2 == this.m_iEmpId)
                content += "项目二,";
            if (pays.EmpID3 == this.m_iEmpId)
                content += "项目三,";
            return content;
        }

        private void frmPays_Employee_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.LoadPaysForEmployee();
            this.bRun = true;
        }

        /// <summary>年</summary>
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bRun)
            {
                this.LoadPaysForEmployee();
            }
        }

        /// <summary>年</summary>
        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bRun)
            {
                this.LoadPaysForEmployee();
            }
        }

        private void dgvPays_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Common.ShowRows_DataGridView_RowPostPaint(this.dgvPays, sender, e);
        }
    }
}
