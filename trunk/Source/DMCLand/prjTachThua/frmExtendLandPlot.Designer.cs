namespace DMC.Land.TachThua
{
    partial class frmExtendLandPlot
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
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnCustomized = new System.Windows.Forms.RadioButton();
            this.rdbtnDefault = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(12, 78);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(73, 21);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(160, 78);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(73, 21);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtnCustomized);
            this.groupBox1.Controls.Add(this.rdbtnDefault);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numDistance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mở rộng thửa đất theo khoảng cách";
            // 
            // rdbtnCustomized
            // 
            this.rdbtnCustomized.AutoSize = true;
            this.rdbtnCustomized.Location = new System.Drawing.Point(138, 18);
            this.rdbtnCustomized.Name = "rdbtnCustomized";
            this.rdbtnCustomized.Size = new System.Drawing.Size(70, 17);
            this.rdbtnCustomized.TabIndex = 3;
            this.rdbtnCustomized.TabStop = true;
            this.rdbtnCustomized.Text = "Tùy chọn";
            this.rdbtnCustomized.UseVisualStyleBackColor = true;
            this.rdbtnCustomized.Click += new System.EventHandler(this.rdbtnCustomized_Click);
            // 
            // rdbtnDefault
            // 
            this.rdbtnDefault.AutoSize = true;
            this.rdbtnDefault.Location = new System.Drawing.Point(11, 18);
            this.rdbtnDefault.Name = "rdbtnDefault";
            this.rdbtnDefault.Size = new System.Drawing.Size(70, 17);
            this.rdbtnDefault.TabIndex = 2;
            this.rdbtnDefault.TabStop = true;
            this.rdbtnDefault.Text = "Mặc định";
            this.rdbtnDefault.UseVisualStyleBackColor = true;
            this.rdbtnDefault.Click += new System.EventHandler(this.rdbtnDefault_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(m2)";
            // 
            // numDistance
            // 
            this.numDistance.DecimalPlaces = 1;
            this.numDistance.Location = new System.Drawing.Point(88, 41);
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(111, 20);
            this.numDistance.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoảng cách";
            // 
            // frmExtendLandPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 103);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXacNhan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExtendLandPlot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mo rong thua dat";
            this.Load += new System.EventHandler(this.frmExtendLandPlot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbtnCustomized;
        private System.Windows.Forms.RadioButton rdbtnDefault;
    }
}