namespace DMC.Land.TachThua
{
    partial class frmHoSoCapGCN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdHoSoCapGCN = new DMC.Interface.GridView.ctrlGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMaHoSoCapGCN = new System.Windows.Forms.RadioButton();
            this.radToBanDoSoThua = new System.Windows.Forms.RadioButton();
            this.radMaThuaDat = new System.Windows.Forms.RadioButton();
            this.cmdChapNhan = new System.Windows.Forms.Button();
            this.cmdHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoSoCapGCN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdHoSoCapGCN
            // 
            this.grdHoSoCapGCN.AllowUserToAddRows = false;
            this.grdHoSoCapGCN.AllowUserToDeleteRows = false;
            this.grdHoSoCapGCN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHoSoCapGCN.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdHoSoCapGCN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdHoSoCapGCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdHoSoCapGCN.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdHoSoCapGCN.Location = new System.Drawing.Point(0, 62);
            this.grdHoSoCapGCN.Name = "grdHoSoCapGCN";
            this.grdHoSoCapGCN.ReadOnly = true;
            this.grdHoSoCapGCN.RowHeadersWidth = 25;
            this.grdHoSoCapGCN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHoSoCapGCN.Size = new System.Drawing.Size(665, 295);
            this.grdHoSoCapGCN.TabIndex = 0;
            this.grdHoSoCapGCN.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdHoSoCapGCN_CellMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radMaHoSoCapGCN);
            this.groupBox1.Controls.Add(this.radToBanDoSoThua);
            this.groupBox1.Controls.Add(this.radMaThuaDat);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn thông tin cần tìm hồ sơ";
            // 
            // radMaHoSoCapGCN
            // 
            this.radMaHoSoCapGCN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radMaHoSoCapGCN.AutoSize = true;
            this.radMaHoSoCapGCN.Location = new System.Drawing.Point(426, 19);
            this.radMaHoSoCapGCN.Name = "radMaHoSoCapGCN";
            this.radMaHoSoCapGCN.Size = new System.Drawing.Size(100, 17);
            this.radMaHoSoCapGCN.TabIndex = 2;
            this.radMaHoSoCapGCN.Text = "Hồ sơ cấp GCN";
            this.radMaHoSoCapGCN.UseVisualStyleBackColor = true;
            this.radMaHoSoCapGCN.CheckedChanged += new System.EventHandler(this.radMaHoSoCapGCN_CheckedChanged);
            // 
            // radToBanDoSoThua
            // 
            this.radToBanDoSoThua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radToBanDoSoThua.AutoSize = true;
            this.radToBanDoSoThua.Location = new System.Drawing.Point(249, 19);
            this.radToBanDoSoThua.Name = "radToBanDoSoThua";
            this.radToBanDoSoThua.Size = new System.Drawing.Size(116, 17);
            this.radToBanDoSoThua.TabIndex = 1;
            this.radToBanDoSoThua.Text = "Tờ bản đồ, số thửa";
            this.radToBanDoSoThua.UseVisualStyleBackColor = true;
            this.radToBanDoSoThua.CheckedChanged += new System.EventHandler(this.radToBanDoSoThua_CheckedChanged);
            // 
            // radMaThuaDat
            // 
            this.radMaThuaDat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radMaThuaDat.AutoSize = true;
            this.radMaThuaDat.Checked = true;
            this.radMaThuaDat.Location = new System.Drawing.Point(101, 19);
            this.radMaThuaDat.Name = "radMaThuaDat";
            this.radMaThuaDat.Size = new System.Drawing.Size(69, 17);
            this.radMaThuaDat.TabIndex = 0;
            this.radMaThuaDat.TabStop = true;
            this.radMaThuaDat.Text = "Thửa đất";
            this.radMaThuaDat.UseVisualStyleBackColor = true;
            this.radMaThuaDat.CheckedChanged += new System.EventHandler(this.radMaThuaDat_CheckedChanged);
            // 
            // cmdChapNhan
            // 
            this.cmdChapNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdChapNhan.Location = new System.Drawing.Point(491, 363);
            this.cmdChapNhan.Name = "cmdChapNhan";
            this.cmdChapNhan.Size = new System.Drawing.Size(78, 23);
            this.cmdChapNhan.TabIndex = 2;
            this.cmdChapNhan.Text = "Chấp nhận";
            this.cmdChapNhan.UseVisualStyleBackColor = true;
            this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
            // 
            // cmdHuy
            // 
            this.cmdHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdHuy.Location = new System.Drawing.Point(575, 363);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(78, 23);
            this.cmdHuy.TabIndex = 3;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.UseVisualStyleBackColor = true;
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // frmHoSoCapGCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(665, 393);
            this.Controls.Add(this.cmdHuy);
            this.Controls.Add(this.cmdChapNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdHoSoCapGCN);
            this.Name = "frmHoSoCapGCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HO SO CAP GCN";
            this.Load += new System.EventHandler(this.frmHoSoCapGCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHoSoCapGCN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DMC.Interface.GridView.ctrlGridView grdHoSoCapGCN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radMaHoSoCapGCN;
        private System.Windows.Forms.RadioButton radToBanDoSoThua;
        private System.Windows.Forms.RadioButton radMaThuaDat;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.Button cmdHuy;
    }
}