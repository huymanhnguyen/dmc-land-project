namespace DMC.Land.SoanHoSo
{
    partial class frmSongSongVuongGoc
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
            this.groupTuyChonDuongVuongGoc = new System.Windows.Forms.GroupBox();
            this.radDiemCuoiVuongGoc = new System.Windows.Forms.RadioButton();
            this.radDiemDauVuongGoc = new System.Windows.Forms.RadioButton();
            this.txtKhoangCach = new System.Windows.Forms.NumericUpDown();
            this.radNghiemSognSong2 = new System.Windows.Forms.RadioButton();
            this.radNghiemSognSong1 = new System.Windows.Forms.RadioButton();
            this.cmdChapNhanKhoangCach = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupTuyChonDuongVuongGoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhoangCach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTuyChonDuongVuongGoc
            // 
            this.groupTuyChonDuongVuongGoc.Controls.Add(this.radDiemCuoiVuongGoc);
            this.groupTuyChonDuongVuongGoc.Controls.Add(this.radDiemDauVuongGoc);
            this.groupTuyChonDuongVuongGoc.Location = new System.Drawing.Point(3, 58);
            this.groupTuyChonDuongVuongGoc.Name = "groupTuyChonDuongVuongGoc";
            this.groupTuyChonDuongVuongGoc.Size = new System.Drawing.Size(297, 54);
            this.groupTuyChonDuongVuongGoc.TabIndex = 15;
            this.groupTuyChonDuongVuongGoc.TabStop = false;
            this.groupTuyChonDuongVuongGoc.Text = "Tuỳ chọn đường vuông góc";
            // 
            // radDiemCuoiVuongGoc
            // 
            this.radDiemCuoiVuongGoc.AutoSize = true;
            this.radDiemCuoiVuongGoc.Location = new System.Drawing.Point(174, 19);
            this.radDiemCuoiVuongGoc.Name = "radDiemCuoiVuongGoc";
            this.radDiemCuoiVuongGoc.Size = new System.Drawing.Size(72, 17);
            this.radDiemCuoiVuongGoc.TabIndex = 1;
            this.radDiemCuoiVuongGoc.Text = "Điểm cuối";
            this.radDiemCuoiVuongGoc.UseVisualStyleBackColor = true;
            // 
            // radDiemDauVuongGoc
            // 
            this.radDiemDauVuongGoc.AutoSize = true;
            this.radDiemDauVuongGoc.Checked = true;
            this.radDiemDauVuongGoc.Location = new System.Drawing.Point(6, 19);
            this.radDiemDauVuongGoc.Name = "radDiemDauVuongGoc";
            this.radDiemDauVuongGoc.Size = new System.Drawing.Size(71, 17);
            this.radDiemDauVuongGoc.TabIndex = 0;
            this.radDiemDauVuongGoc.TabStop = true;
            this.radDiemDauVuongGoc.Text = "Điểm đầu";
            this.radDiemDauVuongGoc.UseVisualStyleBackColor = true;
            // 
            // txtKhoangCach
            // 
            this.txtKhoangCach.DecimalPlaces = 2;
            this.txtKhoangCach.Location = new System.Drawing.Point(91, 9);
            this.txtKhoangCach.Name = "txtKhoangCach";
            this.txtKhoangCach.Size = new System.Drawing.Size(123, 20);
            this.txtKhoangCach.TabIndex = 0;
            this.txtKhoangCach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radNghiemSognSong2
            // 
            this.radNghiemSognSong2.AutoSize = true;
            this.radNghiemSognSong2.Location = new System.Drawing.Point(130, 35);
            this.radNghiemSognSong2.Name = "radNghiemSognSong2";
            this.radNghiemSognSong2.Size = new System.Drawing.Size(84, 17);
            this.radNghiemSognSong2.TabIndex = 2;
            this.radNghiemSognSong2.Text = "Đường thứ 2";
            this.radNghiemSognSong2.UseVisualStyleBackColor = true;
            // 
            // radNghiemSognSong1
            // 
            this.radNghiemSognSong1.AutoSize = true;
            this.radNghiemSognSong1.Checked = true;
            this.radNghiemSognSong1.Location = new System.Drawing.Point(17, 35);
            this.radNghiemSognSong1.Name = "radNghiemSognSong1";
            this.radNghiemSognSong1.Size = new System.Drawing.Size(84, 17);
            this.radNghiemSognSong1.TabIndex = 1;
            this.radNghiemSognSong1.TabStop = true;
            this.radNghiemSognSong1.Text = "Đường thứ 1";
            this.radNghiemSognSong1.UseVisualStyleBackColor = true;
            // 
            // cmdChapNhanKhoangCach
            // 
            this.cmdChapNhanKhoangCach.Location = new System.Drawing.Point(220, 9);
            this.cmdChapNhanKhoangCach.Name = "cmdChapNhanKhoangCach";
            this.cmdChapNhanKhoangCach.Size = new System.Drawing.Size(80, 25);
            this.cmdChapNhanKhoangCach.TabIndex = 3;
            this.cmdChapNhanKhoangCach.Text = "Chấp nhận";
            this.cmdChapNhanKhoangCach.UseVisualStyleBackColor = true;
            this.cmdChapNhanKhoangCach.Click += new System.EventHandler(this.cmdChapNhanKhoangCach_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Khoảng cách";
            // 
            // frmSongSongVuongGoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(303, 56);
            this.Controls.Add(this.groupTuyChonDuongVuongGoc);
            this.Controls.Add(this.txtKhoangCach);
            this.Controls.Add(this.radNghiemSognSong2);
            this.Controls.Add(this.radNghiemSognSong1);
            this.Controls.Add(this.cmdChapNhanKhoangCach);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSongSongVuongGoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tao duong";
            this.Load += new System.EventHandler(this.frmSongSongVuongGoc_Load);
            this.groupTuyChonDuongVuongGoc.ResumeLayout(false);
            this.groupTuyChonDuongVuongGoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhoangCach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTuyChonDuongVuongGoc;
        private System.Windows.Forms.RadioButton radDiemCuoiVuongGoc;
        private System.Windows.Forms.RadioButton radDiemDauVuongGoc;
        private System.Windows.Forms.NumericUpDown txtKhoangCach;
        private System.Windows.Forms.RadioButton radNghiemSognSong2;
        private System.Windows.Forms.RadioButton radNghiemSognSong1;
        private System.Windows.Forms.Button cmdChapNhanKhoangCach;
        private System.Windows.Forms.Label label11;
    }
}