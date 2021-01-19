using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POLA_MMS.UI_Control
{
    public partial class Control_Loading : UserControl
    {
        public Control_Loading()
        {
            InitializeComponent();
        }

        private Image gif_Image = null;
        [Description("加载动画的图片")]
        public Image Gif_Image
        {
            get
            {
                return gif_Image;
            }
            set
            {
                gif_Image = value;
                lbl_gif_loading.Image = gif_Image;
            }
        }

        private Point gif_Location = Point.Empty;
        public Point Gif_Location
        {
            get {
                return gif_Location;
            }
            set {
                gif_Location = value;
                lbl_gif_loading.Location = gif_Location;
            }
        }

    }
}
