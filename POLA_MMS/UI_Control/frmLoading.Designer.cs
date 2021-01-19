namespace POLA_MMS.UI_Control
{
    partial class frmLoading
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
            this.loading_gif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading_gif)).BeginInit();
            this.SuspendLayout();
            // 
            // loading_gif
            // 
            this.loading_gif.Location = new System.Drawing.Point(280, 98);
            this.loading_gif.Name = "loading_gif";
            this.loading_gif.Size = new System.Drawing.Size(240, 240);
            this.loading_gif.TabIndex = 0;
            this.loading_gif.TabStop = false;
            this.loading_gif.Tag = "";
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loading_gif);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoading";
            this.Opacity = 0.4D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TabText = "frmLoading";
            this.Text = "frmLoading";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loading_gif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox loading_gif;
    }
}