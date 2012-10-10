namespace DMC.Land.SoanHoSo
{
    partial class frmBuffer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuff = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radKhung = new System.Windows.Forms.RadioButton();
            this.radDuongBao = new System.Windows.Forms.RadioButton();
            this.cmdChapNhan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Độ rộng vùng đệm (m)";
            // 
            // txtBuff
            // 
            this.txtBuff.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtBuff.Location = new System.Drawing.Point(154, 19);
            this.txtBuff.MaxLength = 2;
            this.txtBuff.Name = "txtBuff";
            this.txtBuff.Size = new System.Drawing.Size(121, 20);
            this.txtBuff.TabIndex = 1;
            this.txtBuff.Text = "0";
            this.txtBuff.TextChanged += new System.EventHandler(this.txtBuff_TextChanged);
            this.txtBuff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuff_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radKhung);
            this.groupBox1.Controls.Add(this.radDuongBao);
            this.groupBox1.Location = new System.Drawing.Point(33, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // radKhung
            // 
            this.radKhung.AutoSize = true;
            this.radKhung.Location = new System.Drawing.Point(7, 42);
            this.radKhung.Name = "radKhung";
            this.radKhung.Size = new System.Drawing.Size(166, 17);
            this.radKhung.TabIndex = 1;
            this.radKhung.Text = "Lấy buffer theo khung bản đồ";
            this.radKhung.UseVisualStyleBackColor = true;
            this.radKhung.CheckedChanged += new System.EventHandler(this.radKhung_CheckedChanged);
            // 
            // radDuongBao
            // 
            this.radDuongBao.AutoSize = true;
            this.radDuongBao.Checked = true;
            this.radDuongBao.Location = new System.Drawing.Point(7, 19);
            this.radDuongBao.Name = "radDuongBao";
            this.radDuongBao.Size = new System.Drawing.Size(151, 17);
            this.radDuongBao.TabIndex = 0;
            this.radDuongBao.TabStop = true;
            this.radDuongBao.Text = "Lấy buffer theo đường bao";
            this.radDuongBao.UseVisualStyleBackColor = true;
            this.radDuongBao.CheckedChanged += new System.EventHandler(this.radDuongBao_CheckedChanged);
            // 
            // cmdChapNhan
            // 
            this.cmdChapNhan.Location = new System.Drawing.Point(214, 129);
            this.cmdChapNhan.Name = "cmdChapNhan";
            this.cmdChapNhan.Size = new System.Drawing.Size(100, 24);
            this.cmdChapNhan.TabIndex = 3;
            this.cmdChapNhan.Text = "Chấp nhận";
            this.cmdChapNhan.UseVisualStyleBackColor = true;
            this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
            // 
            // frmBuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 160);
            this.Controls.Add(this.cmdChapNhan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBuff);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuffer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lay buffer";
            this.Load += new System.EventHandler(this.frmBuffer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.RadioButton radKhung;
        private System.Windows.Forms.RadioButton radDuongBao;
    }
}