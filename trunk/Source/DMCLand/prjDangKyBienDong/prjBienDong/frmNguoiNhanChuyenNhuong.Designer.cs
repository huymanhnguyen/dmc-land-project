namespace DMC.Land.DangKyBienDong
{
    partial class frmNguoiNhanChuyenNhuong
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
            this.TabControl3 = new System.Windows.Forms.TabControl();
            this.tabGDCN = new System.Windows.Forms.TabPage();
            this.ctrlChuGDCN1 = new prjChuSuDung.ctrlChuGDCN();
            this.tabCQNN = new System.Windows.Forms.TabPage();
            this.ctrlChuCQNN1 = new prjChuSuDung.ctrlChuCQNN();
            this.tabTCDN = new System.Windows.Forms.TabPage();
            this.ctrlChuTCDN1 = new prjChuSuDung.ctrlChuTCDN();
            this.TabControl3.SuspendLayout();
            this.tabGDCN.SuspendLayout();
            this.tabCQNN.SuspendLayout();
            this.tabTCDN.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl3
            // 
            this.TabControl3.Controls.Add(this.tabGDCN);
            this.TabControl3.Controls.Add(this.tabCQNN);
            this.TabControl3.Controls.Add(this.tabTCDN);
            this.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl3.Location = new System.Drawing.Point(0, 0);
            this.TabControl3.Name = "TabControl3";
            this.TabControl3.SelectedIndex = 0;
            this.TabControl3.Size = new System.Drawing.Size(918, 579);
            this.TabControl3.TabIndex = 3;
            // 
            // tabGDCN
            // 
            this.tabGDCN.Controls.Add(this.ctrlChuGDCN1);
            this.tabGDCN.Location = new System.Drawing.Point(4, 22);
            this.tabGDCN.Name = "tabGDCN";
            this.tabGDCN.Padding = new System.Windows.Forms.Padding(3);
            this.tabGDCN.Size = new System.Drawing.Size(910, 553);
            this.tabGDCN.TabIndex = 0;
            this.tabGDCN.Text = "Hộ gia đình, cá nhân";
            this.tabGDCN.UseVisualStyleBackColor = true;
            // 
            // ctrlChuGDCN1
            // 
            this.ctrlChuGDCN1.BackColor = System.Drawing.Color.Lavender;
            this.ctrlChuGDCN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChuGDCN1.Location = new System.Drawing.Point(3, 3);
            this.ctrlChuGDCN1.MaChu = "";
            this.ctrlChuGDCN1.MaDonViHanhChinh = null;
            this.ctrlChuGDCN1.Name = "ctrlChuGDCN1";
            this.ctrlChuGDCN1.Size = new System.Drawing.Size(904, 547);
            this.ctrlChuGDCN1.TabIndex = 0;
            this.ctrlChuGDCN1.TenPhuong = "";
            // 
            // tabCQNN
            // 
            this.tabCQNN.Controls.Add(this.ctrlChuCQNN1);
            this.tabCQNN.Location = new System.Drawing.Point(4, 22);
            this.tabCQNN.Name = "tabCQNN";
            this.tabCQNN.Padding = new System.Windows.Forms.Padding(3);
            this.tabCQNN.Size = new System.Drawing.Size(910, 553);
            this.tabCQNN.TabIndex = 1;
            this.tabCQNN.Text = "Cơ quan nhà nước, Cộng đồng dân cư";
            this.tabCQNN.UseVisualStyleBackColor = true;
            // 
            // ctrlChuCQNN1
            // 
            this.ctrlChuCQNN1.BackColor = System.Drawing.Color.Lavender;
            this.ctrlChuCQNN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChuCQNN1.Location = new System.Drawing.Point(3, 3);
            this.ctrlChuCQNN1.MaChu = "";
            this.ctrlChuCQNN1.MaDonViHanhChinh = null;
            this.ctrlChuCQNN1.Name = "ctrlChuCQNN1";
            this.ctrlChuCQNN1.Size = new System.Drawing.Size(904, 547);
            this.ctrlChuCQNN1.TabIndex = 0;
            this.ctrlChuCQNN1.TenPhuong = "";
            // 
            // tabTCDN
            // 
            this.tabTCDN.Controls.Add(this.ctrlChuTCDN1);
            this.tabTCDN.Location = new System.Drawing.Point(4, 22);
            this.tabTCDN.Name = "tabTCDN";
            this.tabTCDN.Size = new System.Drawing.Size(910, 553);
            this.tabTCDN.TabIndex = 2;
            this.tabTCDN.Text = "Tổ chức, doanh nghiệp";
            this.tabTCDN.UseVisualStyleBackColor = true;
            // 
            // ctrlChuTCDN1
            // 
            this.ctrlChuTCDN1.BackColor = System.Drawing.Color.Lavender;
            this.ctrlChuTCDN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChuTCDN1.Location = new System.Drawing.Point(0, 0);
            this.ctrlChuTCDN1.MaChu = "";
            this.ctrlChuTCDN1.MaDonViHanhChinh = null;
            this.ctrlChuTCDN1.Name = "ctrlChuTCDN1";
            this.ctrlChuTCDN1.Size = new System.Drawing.Size(910, 553);
            this.ctrlChuTCDN1.TabIndex = 0;
            this.ctrlChuTCDN1.TenPhuong = "";
            // 
            // frmNguoiNhanChuyenNhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(918, 579);
            this.Controls.Add(this.TabControl3);
            this.Name = "frmNguoiNhanChuyenNhuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NGUOI NHAN CHUYEN NHUONG";
            this.TabControl3.ResumeLayout(false);
            this.tabGDCN.ResumeLayout(false);
            this.tabCQNN.ResumeLayout(false);
            this.tabTCDN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl3;
        internal System.Windows.Forms.TabPage tabGDCN;
        internal System.Windows.Forms.TabPage tabCQNN;
        internal System.Windows.Forms.TabPage tabTCDN;
        public prjChuSuDung.ctrlChuGDCN ctrlChuGDCN1;
        public prjChuSuDung.ctrlChuCQNN ctrlChuCQNN1;
        public prjChuSuDung.ctrlChuTCDN ctrlChuTCDN1;
    }
}