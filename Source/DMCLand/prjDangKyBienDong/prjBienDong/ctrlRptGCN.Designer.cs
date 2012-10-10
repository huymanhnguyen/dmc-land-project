namespace DMC.Land.DangKyBienDong
{
    partial class ctrlRptGCN
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolCongCu = new System.Windows.Forms.ToolStrip();
            this.toolCongCuXem = new System.Windows.Forms.ToolStripButton();
            this.toolCongCuIn = new System.Windows.Forms.ToolStripButton();
            this.crptGCN = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.toolCongCu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolCongCu
            // 
            this.toolCongCu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCongCuXem,
            this.toolCongCuIn});
            this.toolCongCu.Location = new System.Drawing.Point(0, 0);
            this.toolCongCu.Name = "toolCongCu";
            this.toolCongCu.Size = new System.Drawing.Size(688, 25);
            this.toolCongCu.TabIndex = 7;
            this.toolCongCu.Text = "ToolStrip1";
            // 
            // toolCongCuXem
            // 
            this.toolCongCuXem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCongCuXem.Name = "toolCongCuXem";
            this.toolCongCuXem.Size = new System.Drawing.Size(61, 22);
            this.toolCongCuXem.Text = "     Xem     ";
            this.toolCongCuXem.Click += new System.EventHandler(this.toolCongCuXem_Click);
            // 
            // toolCongCuIn
            // 
            this.toolCongCuIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCongCuIn.Name = "toolCongCuIn";
            this.toolCongCuIn.Size = new System.Drawing.Size(51, 22);
            this.toolCongCuIn.Text = "     In     ";
            this.toolCongCuIn.Click += new System.EventHandler(this.toolCongCuIn_Click);
            // 
            // crptGCN
            // 
            this.crptGCN.ActiveViewIndex = -1;
            this.crptGCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptGCN.DisplayGroupTree = false;
            this.crptGCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptGCN.Location = new System.Drawing.Point(0, 25);
            this.crptGCN.Name = "crptGCN";
            this.crptGCN.SelectionFormula = "";
            this.crptGCN.Size = new System.Drawing.Size(688, 424);
            this.crptGCN.TabIndex = 8;
            this.crptGCN.ViewTimeSelectionFormula = "";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // ctrlRptGCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crptGCN);
            this.Controls.Add(this.toolCongCu);
            this.Name = "ctrlRptGCN";
            this.Size = new System.Drawing.Size(688, 449);
            this.toolCongCu.ResumeLayout(false);
            this.toolCongCu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolCongCu;
        internal System.Windows.Forms.ToolStripButton toolCongCuXem;
        public System.Windows.Forms.ToolStripButton toolCongCuIn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crptGCN;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}
