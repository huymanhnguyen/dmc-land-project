namespace DMC.Land.DangKyBienDong
{
    partial class frmInMatBonGCN
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
            this.ctrlRptGCN = new DMC.Land.DangKyBienDong.ctrlRptGCN();
            this.SuspendLayout();
            // 
            // ctrlRptGCN
            // 
            this.ctrlRptGCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRptGCN.Location = new System.Drawing.Point(0, 0);
            this.ctrlRptGCN.Name = "ctrlRptGCN";
            this.ctrlRptGCN.Size = new System.Drawing.Size(651, 389);
            this.ctrlRptGCN.TabIndex = 0;
            // 
            // frmInMatBonGCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(651, 389);
            this.Controls.Add(this.ctrlRptGCN);
            this.Name = "frmInMatBonGCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In noi dung thay doi va co so phap ly";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public ctrlRptGCN ctrlRptGCN;

    }
}