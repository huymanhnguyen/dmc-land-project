namespace DMC.Barcode
{
    partial class ctrlEncodeEAN13
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkGenerateLabel = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnSaveDisk = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtDaySoMaVach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkInMaVach = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBarcodeType = new System.Windows.Forms.ComboBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuyLenh = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 21);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "G&hi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(275, 74);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(98, 20);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.Text = "50";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(87, 74);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(98, 20);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.Text = "190";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Cao";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Rộng";
            // 
            // chkGenerateLabel
            // 
            this.chkGenerateLabel.AutoSize = true;
            this.chkGenerateLabel.Checked = true;
            this.chkGenerateLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateLabel.Location = new System.Drawing.Point(275, 12);
            this.chkGenerateLabel.Name = "chkGenerateLabel";
            this.chkGenerateLabel.Size = new System.Drawing.Size(117, 17);
            this.chkGenerateLabel.TabIndex = 2;
            this.chkGenerateLabel.Text = "Bao gồm cả dãy số";
            this.chkGenerateLabel.UseVisualStyleBackColor = true;
            this.chkGenerateLabel.CheckedChanged += new System.EventHandler(this.chkGenerateLabel_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Màu nền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Màu vạch";
            // 
            // btnBackColor
            // 
            this.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackColor.Location = new System.Drawing.Point(275, 42);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(98, 20);
            this.btnBackColor.TabIndex = 4;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForeColor.Location = new System.Drawing.Point(87, 42);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(98, 20);
            this.btnForeColor.TabIndex = 3;
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // btnSaveDisk
            // 
            this.btnSaveDisk.Location = new System.Drawing.Point(361, 18);
            this.btnSaveDisk.Name = "btnSaveDisk";
            this.btnSaveDisk.Size = new System.Drawing.Size(73, 21);
            this.btnSaveDisk.TabIndex = 14;
            this.btnSaveDisk.Text = "&Ghi ra đĩa";
            this.btnSaveDisk.UseVisualStyleBackColor = true;
            this.btnSaveDisk.Click += new System.EventHandler(this.btnSaveDisk_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(6, 18);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(68, 21);
            this.btnEncode.TabIndex = 9;
            this.btnEncode.Text = "&Tạo mã";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtDaySoMaVach
            // 
            this.txtDaySoMaVach.Location = new System.Drawing.Point(87, 11);
            this.txtDaySoMaVach.MaxLength = 13;
            this.txtDaySoMaVach.Name = "txtDaySoMaVach";
            this.txtDaySoMaVach.Size = new System.Drawing.Size(98, 20);
            this.txtDaySoMaVach.TabIndex = 1;
            this.txtDaySoMaVach.Click += new System.EventHandler(this.txtDaySoMaVach_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Mã vạch:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Lavender;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(188, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "(13)";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(409, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 126);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picBarcode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 126);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ảnh mã vạch";
            // 
            // picBarcode
            // 
            this.picBarcode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBarcode.Location = new System.Drawing.Point(6, 19);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(113, 65);
            this.picBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBarcode.TabIndex = 0;
            this.picBarcode.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInMaVach);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbBarcodeType);
            this.groupBox1.Controls.Add(this.txtDaySoMaVach);
            this.groupBox1.Controls.Add(this.btnForeColor);
            this.groupBox1.Controls.Add(this.btnBackColor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkGenerateLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 128);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            // 
            // chkInMaVach
            // 
            this.chkInMaVach.AutoSize = true;
            this.chkInMaVach.Location = new System.Drawing.Point(275, 102);
            this.chkInMaVach.Name = "chkInMaVach";
            this.chkInMaVach.Size = new System.Drawing.Size(79, 17);
            this.chkInMaVach.TabIndex = 8;
            this.chkInMaVach.Text = "In mã vạch";
            this.chkInMaVach.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Chọn kiểu mã:";
            // 
            // cmbBarcodeType
            // 
            this.cmbBarcodeType.FormattingEnabled = true;
            this.cmbBarcodeType.Items.AddRange(new object[] {
            "CODE128A",
            "EAN13"});
            this.cmbBarcodeType.Location = new System.Drawing.Point(87, 100);
            this.cmbBarcodeType.Name = "cmbBarcodeType";
            this.cmbBarcodeType.Size = new System.Drawing.Size(96, 21);
            this.cmbBarcodeType.TabIndex = 7;
            this.cmbBarcodeType.Text = "CODE128A";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(148, 18);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 21);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(77, 18);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(68, 21);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuyLenh
            // 
            this.btnHuyLenh.Location = new System.Drawing.Point(290, 18);
            this.btnHuyLenh.Name = "btnHuyLenh";
            this.btnHuyLenh.Size = new System.Drawing.Size(68, 21);
            this.btnHuyLenh.TabIndex = 13;
            this.btnHuyLenh.Text = "Hủy lệnh";
            this.btnHuyLenh.UseVisualStyleBackColor = true;
            this.btnHuyLenh.Click += new System.EventHandler(this.btnHuyLenh_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnHuyLenh);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnSaveDisk);
            this.groupBox3.Controls.Add(this.btnEncode);
            this.groupBox3.Location = new System.Drawing.Point(5, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 45);
            this.groupBox3.TabIndex = 87;
            this.groupBox3.TabStop = false;
            // 
            // ctrlEncodeEAN13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlEncodeEAN13";
            this.Size = new System.Drawing.Size(622, 182);
            this.Load += new System.EventHandler(this.ctrlEncodeEAN13_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkGenerateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Button btnSaveDisk;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.TextBox txtDaySoMaVach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBarcodeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.CheckBox chkInMaVach;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuyLenh;
        private System.Windows.Forms.GroupBox groupBox3;


    }
}
