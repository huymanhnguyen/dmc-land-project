namespace DMC.Land.ThongTinTiepNhanHoSo
{
    partial class frmTraCuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuu));
            this.ctrlTraCuu1 = new DMC.Land.ChuHoSoCapGCN.ctrlTraCuu();
            this.SuspendLayout();
            // 
            // ctrlTraCuu1
            // 
            this.ctrlTraCuu1.BackColor = System.Drawing.Color.Lavender;
            this.ctrlTraCuu1.Connection = "";
            this.ctrlTraCuu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTraCuu1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTraCuu1.Name = "ctrlTraCuu1";
            this.ctrlTraCuu1.Nhom = "";
            this.ctrlTraCuu1.Size = new System.Drawing.Size(712, 422);
            this.ctrlTraCuu1.TabIndex = 0;
            // 
            // frmTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 422);
            this.Controls.Add(this.ctrlTraCuu1);
            this.Name = "frmTraCuu";
            this.Text = "TRA CUU CHU SU DUNG";
            this.ResumeLayout(false);

        }

        #endregion

        public DMC.Land.ChuHoSoCapGCN.ctrlTraCuu ctrlTraCuu1;

    }
}