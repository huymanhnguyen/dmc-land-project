namespace DMC.Land.TinhToanDenBu
{
    partial class frmTinhToanDenBu
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
            this.ctrlTinhToanDenBu = new DMC.Land.TinhToanDenBu.ctrlTinhToanDenBu();
            this.SuspendLayout();
            // 
            // ctrlTinhToanDenBu
            // 
            this.ctrlTinhToanDenBu.BackColor = System.Drawing.Color.Lavender;
            this.ctrlTinhToanDenBu.Connection = "";
            this.ctrlTinhToanDenBu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTinhToanDenBu.Location = new System.Drawing.Point(0, 0);
            this.ctrlTinhToanDenBu.Name = "ctrlTinhToanDenBu";
            this.ctrlTinhToanDenBu.Size = new System.Drawing.Size(709, 456);
            this.ctrlTinhToanDenBu.TabIndex = 0;
            // 
            // frmTinhToanDenBu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(709, 456);
            this.Controls.Add(this.ctrlTinhToanDenBu);
            this.Name = "frmTinhToanDenBu";
            this.Text = "Tinh toan den bu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public ctrlTinhToanDenBu ctrlTinhToanDenBu;

    }
}