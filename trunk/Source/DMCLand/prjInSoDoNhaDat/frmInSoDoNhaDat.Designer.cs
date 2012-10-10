namespace DMC.Land.InSoDoNhaDat
{
    partial class frmInSoDoNhaDat
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
            this.ctrlSoDoNhaDat = new DMC.Land.InSoDoNhaDat.ctrlSoDoNhaDat();
            this.SuspendLayout();
            // 
            // ctrlSoDoNhaDat
            // 
            this.ctrlSoDoNhaDat.BackColor = System.Drawing.Color.Lavender;
            this.ctrlSoDoNhaDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSoDoNhaDat.Location = new System.Drawing.Point(0, 0);
            this.ctrlSoDoNhaDat.Name = "ctrlSoDoNhaDat";
            this.ctrlSoDoNhaDat.Size = new System.Drawing.Size(447, 303);
            this.ctrlSoDoNhaDat.SoDoNhaDat = null;
            this.ctrlSoDoNhaDat.TabIndex = 0;
            // 
            // frmInSoDoNhaDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 303);
            this.Controls.Add(this.ctrlSoDoNhaDat);
            this.Name = "frmInSoDoNhaDat";
            this.Text = "In so do nha dat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public ctrlSoDoNhaDat ctrlSoDoNhaDat;

    }
}