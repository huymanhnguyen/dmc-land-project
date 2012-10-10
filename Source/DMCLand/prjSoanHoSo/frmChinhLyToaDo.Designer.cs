namespace DMC.Land.SoanHoSo
{
    partial class frmChinhLyToaDo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdDanhSachToaDo = new DMC.Interface.GridView.ctrlGridView();
            this.cmdLuu = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSachToaDo)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDanhSachToaDo
            // 
            this.grdDanhSachToaDo.AllowUserToAddRows = false;
            this.grdDanhSachToaDo.AllowUserToDeleteRows = false;
            this.grdDanhSachToaDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDanhSachToaDo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDanhSachToaDo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDanhSachToaDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDanhSachToaDo.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdDanhSachToaDo.Location = new System.Drawing.Point(0, 1);
            this.grdDanhSachToaDo.Name = "grdDanhSachToaDo";
            this.grdDanhSachToaDo.RowHeadersWidth = 25;
            this.grdDanhSachToaDo.Size = new System.Drawing.Size(519, 328);
            this.grdDanhSachToaDo.TabIndex = 0;
            // 
            // cmdLuu
            // 
            this.cmdLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLuu.Location = new System.Drawing.Point(354, 337);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(75, 23);
            this.cmdLuu.TabIndex = 2;
            this.cmdLuu.Text = "Lưu lại";
            this.cmdLuu.UseVisualStyleBackColor = true;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdThoat.Location = new System.Drawing.Point(435, 337);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 23);
            this.cmdThoat.TabIndex = 3;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // frmChinhLyToaDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(519, 370);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdLuu);
            this.Controls.Add(this.grdDanhSachToaDo);
            this.Name = "frmChinhLyToaDo";
            this.Text = "CHINH LY TOA DO";
            this.Load += new System.EventHandler(this.frmChinhLyToaDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSachToaDo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DMC.Interface.GridView.ctrlGridView grdDanhSachToaDo;
        private System.Windows.Forms.Button cmdLuu;
        private System.Windows.Forms.Button cmdThoat;
    }
}