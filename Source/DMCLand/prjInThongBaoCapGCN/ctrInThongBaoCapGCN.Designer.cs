namespace DMC.Land.InThongBaoCapGCN
{
    partial class ctrInThongBaoCapGCN
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.DD = new System.Windows.Forms.Label();
            this.txtDiaChiNoiNhan = new System.Windows.Forms.TextBox();
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.cmdHienThi = new System.Windows.Forms.Button();
            this.txtNguoiKy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(3, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 533);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 16);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(906, 514);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // DD
            // 
            this.DD.AutoSize = true;
            this.DD.Location = new System.Drawing.Point(13, 19);
            this.DD.Name = "DD";
            this.DD.Size = new System.Drawing.Size(84, 13);
            this.DD.TabIndex = 2;
            this.DD.Text = "Địa chỉ nơi nhận";
            // 
            // txtDiaChiNoiNhan
            // 
            this.txtDiaChiNoiNhan.Location = new System.Drawing.Point(103, 16);
            this.txtDiaChiNoiNhan.Name = "txtDiaChiNoiNhan";
            this.txtDiaChiNoiNhan.Size = new System.Drawing.Size(531, 20);
            this.txtDiaChiNoiNhan.TabIndex = 1;
            // 
            // cmdHienThi
            // 
            this.cmdHienThi.Location = new System.Drawing.Point(400, 39);
            this.cmdHienThi.Name = "cmdHienThi";
            this.cmdHienThi.Size = new System.Drawing.Size(105, 23);
            this.cmdHienThi.TabIndex = 3;
            this.cmdHienThi.Text = "Hiển thị thông báo";
            this.cmdHienThi.UseVisualStyleBackColor = true;
            this.cmdHienThi.Click += new System.EventHandler(this.cmdHienThi_Click);
            // 
            // txtNguoiKy
            // 
            this.txtNguoiKy.Location = new System.Drawing.Point(103, 41);
            this.txtNguoiKy.Name = "txtNguoiKy";
            this.txtNguoiKy.Size = new System.Drawing.Size(272, 20);
            this.txtNguoiKy.TabIndex = 2;
            this.txtNguoiKy.TextChanged += new System.EventHandler(this.txtNguoiKy_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Họ tên người ký";
            // 
            // ctrInThongBaoCapGCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNguoiKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdHienThi);
            this.Controls.Add(this.txtDiaChiNoiNhan);
            this.Controls.Add(this.DD);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrInThongBaoCapGCN";
            this.Size = new System.Drawing.Size(918, 607);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DD;
        private System.Windows.Forms.TextBox txtDiaChiNoiNhan;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private System.Windows.Forms.Button cmdHienThi;
        private System.Windows.Forms.TextBox txtNguoiKy;
        private System.Windows.Forms.Label label2;
    }
}
