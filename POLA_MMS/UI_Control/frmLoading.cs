using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POLA_MMS.UI_Control
{
    public partial class frmLoading : WinFormsUI.Docking.DockContent
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            loading_gif.Load("Resources/loading_240.gif");
            loading_gif.Location = new Point(this.Width / 2 - loading_gif.Width / 2, this.Height / 2 - loading_gif.Height / 2);
        }
    }
}
