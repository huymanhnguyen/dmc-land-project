namespace DMC.Land.BienDong.DangKy
{
    partial class frmBangMa
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
            this.ctrlTuDienLoaiHinhBienDong = new DMC.Land.BangMa.ctrlTuDienLoaiHinhBienDong();
            this.SuspendLayout();
            // 
            // ctrlTuDienLoaiHinhBienDong
            // 
            this.ctrlTuDienLoaiHinhBienDong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTuDienLoaiHinhBienDong.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ctrlTuDienLoaiHinhBienDong.DonViDangKy = "";
            this.ctrlTuDienLoaiHinhBienDong.KyHieu = "";
            this.ctrlTuDienLoaiHinhBienDong.Location = new System.Drawing.Point(0, 0);
            this.ctrlTuDienLoaiHinhBienDong.MoTa = "";
            this.ctrlTuDienLoaiHinhBienDong.Name = "ctrlTuDienLoaiHinhBienDong";
            this.ctrlTuDienLoaiHinhBienDong.NoiDungGhiSo = "";
            this.ctrlTuDienLoaiHinhBienDong.Size = new System.Drawing.Size(572, 389);
            this.ctrlTuDienLoaiHinhBienDong.TabIndex = 0;
            // 
            // frmBangMa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(573, 389);
            this.Controls.Add(this.ctrlTuDienLoaiHinhBienDong);
            this.Name = "frmBangMa";
            this.Text = "Bang Ma";
            this.ResumeLayout(false);

        }

        #endregion

        public DMC.Land.BangMa.ctrlTuDienLoaiHinhBienDong ctrlTuDienLoaiHinhBienDong;



    }
}