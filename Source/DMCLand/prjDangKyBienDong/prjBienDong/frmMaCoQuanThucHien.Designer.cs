namespace DMC.Land.DangKyBienDong
{
    partial class frmMaCoQuanThucHien
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
            this.ctrlMaCoQuanThucHien = new DMC.Land.BangMa.ctrlMaCoQuanThucHien();
            this.SuspendLayout();
            // 
            // ctrlMaCoQuanThucHien
            // 
            this.ctrlMaCoQuanThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlMaCoQuanThucHien.BackColor = System.Drawing.Color.Lavender;
            this.ctrlMaCoQuanThucHien.Location = new System.Drawing.Point(1, -3);
            this.ctrlMaCoQuanThucHien.KyHieu = "";
            this.ctrlMaCoQuanThucHien.MoTa = "";
            this.ctrlMaCoQuanThucHien.Name = "ctrlMaCoQuanThucHien";
            this.ctrlMaCoQuanThucHien.Size = new System.Drawing.Size(574, 317);
            this.ctrlMaCoQuanThucHien.TabIndex = 0;
            // 
            // frmMaCoQuanThucHien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 316);
            this.Controls.Add(this.ctrlMaCoQuanThucHien);
            this.Name = "frmMaCoQuanThucHien";
            this.Text = "frmMaCoQuanThucHien";
            this.ResumeLayout(false);

        }

        #endregion

        public DMC.Land.BangMa.ctrlMaCoQuanThucHien ctrlMaCoQuanThucHien;


    }
}