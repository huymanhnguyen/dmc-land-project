namespace DMC.Land.SoanHoSo
{
    partial class frmSnapPoints
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
            this.groupSnapEnable = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.numKhoangCachBatDinh = new System.Windows.Forms.NumericUpDown();
            this.chkSnapEnable = new System.Windows.Forms.CheckBox();
            this.groupSnapEnable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKhoangCachBatDinh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSnapEnable
            // 
            this.groupSnapEnable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSnapEnable.Controls.Add(this.label2);
            this.groupSnapEnable.Controls.Add(this.label1);
            this.groupSnapEnable.Controls.Add(this.btnCancel);
            this.groupSnapEnable.Controls.Add(this.btnOk);
            this.groupSnapEnable.Controls.Add(this.numKhoangCachBatDinh);
            this.groupSnapEnable.Controls.Add(this.chkSnapEnable);
            this.groupSnapEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSnapEnable.Location = new System.Drawing.Point(3, 2);
            this.groupSnapEnable.Name = "groupSnapEnable";
            this.groupSnapEnable.Size = new System.Drawing.Size(260, 108);
            this.groupSnapEnable.TabIndex = 6;
            this.groupSnapEnable.TabStop = false;
            this.groupSnapEnable.Text = "Chế độ bắt dính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "(điểm ảnh)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Khoảng cách:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(155, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(9, 77);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 26);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // numKhoangCachBatDinh
            // 
            this.numKhoangCachBatDinh.Location = new System.Drawing.Point(116, 42);
            this.numKhoangCachBatDinh.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numKhoangCachBatDinh.Name = "numKhoangCachBatDinh";
            this.numKhoangCachBatDinh.Size = new System.Drawing.Size(45, 24);
            this.numKhoangCachBatDinh.TabIndex = 7;
            this.numKhoangCachBatDinh.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkSnapEnable
            // 
            this.chkSnapEnable.AutoSize = true;
            this.chkSnapEnable.Location = new System.Drawing.Point(9, 19);
            this.chkSnapEnable.Name = "chkSnapEnable";
            this.chkSnapEnable.Size = new System.Drawing.Size(178, 22);
            this.chkSnapEnable.TabIndex = 6;
            this.chkSnapEnable.Text = "Bật/Tắt chế độ bắt dính";
            this.chkSnapEnable.UseVisualStyleBackColor = true;
            this.chkSnapEnable.CheckedChanged += new System.EventHandler(this.chkSnapEnable_CheckedChanged);
            // 
            // frmSnapPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 113);
            this.Controls.Add(this.groupSnapEnable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSnapPoints";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bat diem";
            this.Load += new System.EventHandler(this.frmSnapPoints_Load);
            this.groupSnapEnable.ResumeLayout(false);
            this.groupSnapEnable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKhoangCachBatDinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSnapEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numKhoangCachBatDinh;
        private System.Windows.Forms.CheckBox chkSnapEnable;

    }
}