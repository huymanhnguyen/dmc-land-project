namespace DMC.Land.TinhToanDenBu
{
    partial class frmChiTietDenBu
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
            this.grdChiTietDenBu = new DMC.Interface.GridView.ctrlGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdChiTietDenBu)).BeginInit();
            this.SuspendLayout();
            // 
            // grdChiTietDenBu
            // 
            this.grdChiTietDenBu.AllowUserToAddRows = false;
            this.grdChiTietDenBu.AllowUserToDeleteRows = false;
            this.grdChiTietDenBu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdChiTietDenBu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdChiTietDenBu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdChiTietDenBu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdChiTietDenBu.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdChiTietDenBu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChiTietDenBu.Location = new System.Drawing.Point(0, 0);
            this.grdChiTietDenBu.Name = "grdChiTietDenBu";
            this.grdChiTietDenBu.ReadOnly = true;
            this.grdChiTietDenBu.RowHeadersWidth = 25;
            this.grdChiTietDenBu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChiTietDenBu.Size = new System.Drawing.Size(784, 450);
            this.grdChiTietDenBu.TabIndex = 0;
            // 
            // frmChiTietDenBu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.grdChiTietDenBu);
            this.Name = "frmChiTietDenBu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiet den bu";
            this.Load += new System.EventHandler(this.frmChiTietDenBu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdChiTietDenBu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DMC.Interface.GridView.ctrlGridView grdChiTietDenBu;
    }
}