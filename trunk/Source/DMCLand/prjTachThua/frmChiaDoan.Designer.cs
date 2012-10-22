namespace TachThua
{
    partial class frmChiaDoan
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
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numDoDaiDoanDau = new System.Windows.Forms.NumericUpDown();
            this.lblTongDoDai = new System.Windows.Forms.Label();
            this.txtDoDaiDoanCuoi = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoDaiDoanDau)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(33, 85);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 29);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numDoDaiDoanDau);
            this.groupBox1.Controls.Add(this.lblTongDoDai);
            this.groupBox1.Controls.Add(this.txtDoDaiDoanCuoi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chia đoạn thẳng";
            // 
            // numDoDaiDoanDau
            // 
            this.numDoDaiDoanDau.DecimalPlaces = 2;
            this.numDoDaiDoanDau.Location = new System.Drawing.Point(6, 49);
            this.numDoDaiDoanDau.Name = "numDoDaiDoanDau";
            this.numDoDaiDoanDau.Size = new System.Drawing.Size(114, 24);
            this.numDoDaiDoanDau.TabIndex = 0;
            this.numDoDaiDoanDau.ValueChanged += new System.EventHandler(this.numDoDaiDoanDau_ValueChanged);
            // 
            // lblTongDoDai
            // 
            this.lblTongDoDai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDoDai.Location = new System.Drawing.Point(6, 20);
            this.lblTongDoDai.Name = "lblTongDoDai";
            this.lblTongDoDai.Size = new System.Drawing.Size(276, 23);
            this.lblTongDoDai.TabIndex = 2;
            this.lblTongDoDai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDoDaiDoanCuoi
            // 
            this.txtDoDaiDoanCuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoDaiDoanCuoi.Location = new System.Drawing.Point(166, 49);
            this.txtDoDaiDoanCuoi.Name = "txtDoDaiDoanCuoi";
            this.txtDoDaiDoanCuoi.ReadOnly = true;
            this.txtDoDaiDoanCuoi.Size = new System.Drawing.Size(116, 24);
            this.txtDoDaiDoanCuoi.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(178, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmChiaDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 116);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiaDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chia doan thang";
            this.Load += new System.EventHandler(this.frmChiaDoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDoDaiDoanDau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTongDoDai;
        private System.Windows.Forms.TextBox txtDoDaiDoanCuoi;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numDoDaiDoanDau;
    }
}