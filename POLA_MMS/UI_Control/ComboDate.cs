using BLL;
using System;
using System.Windows.Forms;

namespace POLA_MMS.UI_Control
{
    public enum ShowMode
    {
        All, YearAndMonth
    }

    public partial class ComboDate : UserControl
    {
        private bool bRun = false;

        public ComboDate()
        {
            InitializeComponent();
        }

        #region 自定义属性...

        /// <summary>年</summary>
        public int Year
        {
            get
            {
                return int.Parse(this.cboYear.Text);
            }
        }

        /// <summary>月</summary>
        public int Month
        {
            get
            {
                return int.Parse(this.cboMonth.Text);
            }
        }

        /// <summary>日</summary>
        public int Day
        {
            get
            {
                if (this.cboDay.SelectedIndex > 0)
                {
                    return int.Parse(this.cboDay.Text);
                }
                return 0;
            }
        }

        private ShowMode _ShowMode = ShowMode.All;

        public ShowMode ShowMode
        {
            get { return _ShowMode; }
            set { _ShowMode = value; }
        }

        #endregion

        private void LoadDate()
        {
            for (int y = 2019; y <= DateTime.Now.Year; y++)
            {
                this.cboYear.Items.Add(y.ToString());
            }
            for (int m = 1; m <= 12; m++)
            {
                this.cboMonth.Items.Add(m.ToString());
            }
            this.cboYear.Text = DateTime.Now.Year.ToString();
            this.cboMonth.Text = DateTime.Now.Month.ToString();
            this.LoadMaxDay();
        }

        private void LoadMaxDay()
        {
            this.cboDay.Items.Clear();
            int year = int.Parse(this.cboYear.Text);
            int month = int.Parse(this.cboMonth.Text);
            int max = Common.GetMonthMaxDay(year, month);
            this.cboDay.Items.Add("全部");
            for (int d = 1; d <= max; d++)
            {
                this.cboDay.Items.Add(d.ToString());
            }
            this.cboDay.SelectedIndex = 0;
        }

        /// <summary>年</summary>
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bRun)
            {
                this.LoadMaxDay();
            }
        }

        /// <summary>月</summary>
        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bRun)
            {
                this.LoadMaxDay();
            }
        }

        public event EventHandler SelectedIndexChanged;

        /// <summary>日</summary>
        private void cboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }

        private void ComboDate_Load(object sender, EventArgs e)
        {
            this.LoadDate();
            this.bRun = true;
        }
    }
}
