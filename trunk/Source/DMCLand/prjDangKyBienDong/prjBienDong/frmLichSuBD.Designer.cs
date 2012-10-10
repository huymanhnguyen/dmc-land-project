namespace DMC.Land.DangKyBienDong
{
    partial class frmLichSuBD
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
            this.ctrLichSuHSBienDong1 = new prjLichSuHoSoBienDong.ctrLichSuHSBienDong();
            this.SuspendLayout();
            // 
            // ctrLichSuHSBienDong1
            // 
            this.ctrLichSuHSBienDong1.Connection = "";
            this.ctrLichSuHSBienDong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrLichSuHSBienDong1.Location = new System.Drawing.Point(0, 0);
            this.ctrLichSuHSBienDong1.MaDangKyBienDong = "";
            this.ctrLichSuHSBienDong1.MaDonViHanhChinh = null;
            this.ctrLichSuHSBienDong1.MaHoSoCapGCN = "";
            this.ctrLichSuHSBienDong1.MaThuaDat = "";
            this.ctrLichSuHSBienDong1.MyError = "";
            this.ctrLichSuHSBienDong1.Name = "ctrLichSuHSBienDong1";
            this.ctrLichSuHSBienDong1.Size = new System.Drawing.Size(835, 469);
            this.ctrLichSuHSBienDong1.TabIndex = 0;
            // 
            // frmLichSuBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 469);
            this.Controls.Add(this.ctrLichSuHSBienDong1);
            this.Name = "frmLichSuBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XEM LICH SU BIEN DONG";
            this.ResumeLayout(false);

        }

        #endregion

        public prjLichSuHoSoBienDong.ctrLichSuHSBienDong ctrLichSuHSBienDong1;

    }
}