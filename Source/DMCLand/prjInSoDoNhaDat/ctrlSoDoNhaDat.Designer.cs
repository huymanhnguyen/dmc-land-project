namespace DMC.Land.InSoDoNhaDat
{
    partial class ctrlSoDoNhaDat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlSoDoNhaDat));
            this.mapPrintDocument1 = new MapInfo.Printing.MapPrintDocument();
            this.toolCongCu = new System.Windows.Forms.ToolStrip();
            this.toolCongCuXem = new System.Windows.Forms.ToolStripButton();
            this.toolCongCuIn = new System.Windows.Forms.ToolStripButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.crptMap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolCongCu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPrintDocument1
            // 
            this.mapPrintDocument1.Border = MapInfo.Printing.PrintBorder.On;
            this.mapPrintDocument1.DrawingAttributes = ((MapInfo.Mapping.DrawingAttributes)(resources.GetObject("mapPrintDocument1.DrawingAttributes")));
            this.mapPrintDocument1.Map = null;
            this.mapPrintDocument1.MapPrintSize = MapInfo.Printing.MapPrintSize.FitPage;
            this.mapPrintDocument1.PrintMethod = MapInfo.Printing.PrintMethod.Direct;
            // 
            // toolCongCu
            // 
            this.toolCongCu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCongCuXem,
            this.toolCongCuIn});
            this.toolCongCu.Location = new System.Drawing.Point(0, 0);
            this.toolCongCu.Name = "toolCongCu";
            this.toolCongCu.Size = new System.Drawing.Size(540, 25);
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
            // 
            // crptMap
            // 
            this.crptMap.ActiveViewIndex = -1;
            this.crptMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crptMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptMap.DisplayGroupTree = false;
            this.crptMap.Location = new System.Drawing.Point(3, 28);
            this.crptMap.Name = "crptMap";
            this.crptMap.SelectionFormula = "";
            this.crptMap.Size = new System.Drawing.Size(534, 432);
            this.crptMap.TabIndex = 8;
            this.crptMap.ViewTimeSelectionFormula = "";
            // 
            // ctrlSoDoNhaDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.crptMap);
            this.Controls.Add(this.toolCongCu);
            this.Name = "ctrlSoDoNhaDat";
            this.Size = new System.Drawing.Size(540, 461);
            this.toolCongCu.ResumeLayout(false);
            this.toolCongCu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MapInfo.Printing.MapPrintDocument mapPrintDocument1;
        public System.Windows.Forms.ToolStrip toolCongCu;
        internal System.Windows.Forms.ToolStripButton toolCongCuXem;
        public System.Windows.Forms.ToolStripButton toolCongCuIn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crptMap;
    }
}
