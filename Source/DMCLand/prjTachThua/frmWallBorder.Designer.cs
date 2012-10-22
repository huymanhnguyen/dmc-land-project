namespace DMC.Land.TachThua
{
    partial class frmWallBorder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKieuBao = new System.Windows.Forms.CheckBox();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.rdbtnAccurate = new System.Windows.Forms.RadioButton();
            this.rdbtnRelatively = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkKieuBao);
            this.groupBox1.Controls.Add(this.numDistance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khoảng cách với thửa đất đồng dạng";
            // 
            // chkKieuBao
            // 
            this.chkKieuBao.AutoSize = true;
            this.chkKieuBao.Checked = true;
            this.chkKieuBao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKieuBao.Location = new System.Drawing.Point(107, 53);
            this.chkKieuBao.Name = "chkKieuBao";
            this.chkKieuBao.Size = new System.Drawing.Size(170, 22);
            this.chkKieuBao.TabIndex = 3;
            this.chkKieuBao.Text = "Đường bao trong thửa";
            this.chkKieuBao.UseVisualStyleBackColor = true;
            this.chkKieuBao.CheckedChanged += new System.EventHandler(this.chkKieuBao_CheckedChanged);
            // 
            // numDistance
            // 
            this.numDistance.DecimalPlaces = 2;
            this.numDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDistance.Location = new System.Drawing.Point(106, 24);
            this.numDistance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(154, 24);
            this.numDistance.TabIndex = 2;
            this.numDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDistance.ValueChanged += new System.EventHandler(this.numDistance_ValueChanged);
            this.numDistance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numDistance_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoảng cách";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(12, 141);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(87, 27);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(185, 139);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 27);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rdbtnAccurate
            // 
            this.rdbtnAccurate.AutoSize = true;
            this.rdbtnAccurate.Location = new System.Drawing.Point(13, 19);
            this.rdbtnAccurate.Name = "rdbtnAccurate";
            this.rdbtnAccurate.Size = new System.Drawing.Size(74, 17);
            this.rdbtnAccurate.TabIndex = 0;
            this.rdbtnAccurate.TabStop = true;
            this.rdbtnAccurate.Text = "Chính xác";
            this.rdbtnAccurate.UseVisualStyleBackColor = true;
            this.rdbtnAccurate.Click += new System.EventHandler(this.rdbtnAccurate_Click);
            // 
            // rdbtnRelatively
            // 
            this.rdbtnRelatively.AutoSize = true;
            this.rdbtnRelatively.Location = new System.Drawing.Point(185, 19);
            this.rdbtnRelatively.Name = "rdbtnRelatively";
            this.rdbtnRelatively.Size = new System.Drawing.Size(74, 17);
            this.rdbtnRelatively.TabIndex = 1;
            this.rdbtnRelatively.TabStop = true;
            this.rdbtnRelatively.Text = "Tương đối";
            this.rdbtnRelatively.UseVisualStyleBackColor = true;
            this.rdbtnRelatively.Click += new System.EventHandler(this.rdbtnRelatively_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbtnRelatively);
            this.groupBox2.Controls.Add(this.rdbtnAccurate);
            this.groupBox2.Location = new System.Drawing.Point(4, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn chế độ lấy đa giác đồng dạng";
            // 
            // frmWallBorder
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(298, 178);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXacNhan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWallBorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Da giac dong dang";
            this.Load += new System.EventHandler(this.frmWallBorder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rdbtnAccurate;
        private System.Windows.Forms.RadioButton rdbtnRelatively;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkKieuBao;
    }
}