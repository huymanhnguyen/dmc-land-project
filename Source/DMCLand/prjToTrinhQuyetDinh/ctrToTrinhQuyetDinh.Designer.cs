namespace prjToTrinhQuyetDinh
{
    partial class ctrToTrinhQuyetDinh
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoToTrinh = new System.Windows.Forms.TextBox();
            this.txtNguoiTrinhKy = new System.Windows.Forms.TextBox();
            this.txtNguoiQuyetDinhKy = new System.Windows.Forms.TextBox();
            this.cmdToTrinh = new System.Windows.Forms.Button();
            this.cmdQuyetDinh = new System.Windows.Forms.Button();
            this.dtpNgayTrinh = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayQuyetDinh = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tờ trình số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày ký tờ trình";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Người ký tờ trình";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Người ký quyết định";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày ký quyết định";
            // 
            // txtSoToTrinh
            // 
            this.txtSoToTrinh.Location = new System.Drawing.Point(128, 9);
            this.txtSoToTrinh.Name = "txtSoToTrinh";
            this.txtSoToTrinh.Size = new System.Drawing.Size(100, 20);
            this.txtSoToTrinh.TabIndex = 1;
            // 
            // txtNguoiTrinhKy
            // 
            this.txtNguoiTrinhKy.Location = new System.Drawing.Point(128, 35);
            this.txtNguoiTrinhKy.Name = "txtNguoiTrinhKy";
            this.txtNguoiTrinhKy.Size = new System.Drawing.Size(189, 20);
            this.txtNguoiTrinhKy.TabIndex = 3;
            this.txtNguoiTrinhKy.Text = "Đỗ Đình Ân";
            // 
            // txtNguoiQuyetDinhKy
            // 
            this.txtNguoiQuyetDinhKy.Location = new System.Drawing.Point(128, 61);
            this.txtNguoiQuyetDinhKy.Name = "txtNguoiQuyetDinhKy";
            this.txtNguoiQuyetDinhKy.Size = new System.Drawing.Size(189, 20);
            this.txtNguoiQuyetDinhKy.TabIndex = 4;
            this.txtNguoiQuyetDinhKy.Text = "Nguyễn Quốc Hoa";
            // 
            // cmdToTrinh
            // 
            this.cmdToTrinh.Location = new System.Drawing.Point(127, 87);
            this.cmdToTrinh.Name = "cmdToTrinh";
            this.cmdToTrinh.Size = new System.Drawing.Size(75, 23);
            this.cmdToTrinh.TabIndex = 6;
            this.cmdToTrinh.Text = "Tờ trình";
            this.cmdToTrinh.UseVisualStyleBackColor = true;
            this.cmdToTrinh.Click += new System.EventHandler(this.cmdToTrinh_Click);
            // 
            // cmdQuyetDinh
            // 
            this.cmdQuyetDinh.Location = new System.Drawing.Point(208, 87);
            this.cmdQuyetDinh.Name = "cmdQuyetDinh";
            this.cmdQuyetDinh.Size = new System.Drawing.Size(75, 23);
            this.cmdQuyetDinh.TabIndex = 7;
            this.cmdQuyetDinh.Text = "Quyết định";
            this.cmdQuyetDinh.UseVisualStyleBackColor = true;
            this.cmdQuyetDinh.Click += new System.EventHandler(this.cmdQuyetDinh_Click);
            // 
            // dtpNgayTrinh
            // 
            this.dtpNgayTrinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTrinh.Location = new System.Drawing.Point(432, 9);
            this.dtpNgayTrinh.Name = "dtpNgayTrinh";
            this.dtpNgayTrinh.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayTrinh.TabIndex = 2;
            // 
            // dtpNgayQuyetDinh
            // 
            this.dtpNgayQuyetDinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayQuyetDinh.Location = new System.Drawing.Point(432, 57);
            this.dtpNgayQuyetDinh.Name = "dtpNgayQuyetDinh";
            this.dtpNgayQuyetDinh.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayQuyetDinh.TabIndex = 5;
            this.dtpNgayQuyetDinh.ValueChanged += new System.EventHandler(this.dtpNgayQuyetDinh_ValueChanged);
            // 
            // ctrToTrinhQuyetDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.dtpNgayQuyetDinh);
            this.Controls.Add(this.dtpNgayTrinh);
            this.Controls.Add(this.cmdQuyetDinh);
            this.Controls.Add(this.cmdToTrinh);
            this.Controls.Add(this.txtNguoiQuyetDinhKy);
            this.Controls.Add(this.txtNguoiTrinhKy);
            this.Controls.Add(this.txtSoToTrinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrToTrinhQuyetDinh";
            this.Size = new System.Drawing.Size(545, 126);
            this.Load += new System.EventHandler(this.ctrToTrinhQuyetDinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoToTrinh;
        private System.Windows.Forms.TextBox txtNguoiTrinhKy;
        private System.Windows.Forms.TextBox txtNguoiQuyetDinhKy;
        private System.Windows.Forms.Button cmdToTrinh;
        private System.Windows.Forms.Button cmdQuyetDinh;
        public System.Windows.Forms.DateTimePicker dtpNgayTrinh;
        public System.Windows.Forms.DateTimePicker dtpNgayQuyetDinh;
    }
}
