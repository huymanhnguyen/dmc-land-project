namespace TachThua
{
    partial class frmLayerVisibility
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
            this.btnOk = new System.Windows.Forms.Button();
            this.chkShowNodes = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowLineDirection = new System.Windows.Forms.CheckBox();
            this.chkShowCentroid = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(21, 105);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkShowNodes
            // 
            this.chkShowNodes.AutoSize = true;
            this.chkShowNodes.Location = new System.Drawing.Point(18, 19);
            this.chkShowNodes.Name = "chkShowNodes";
            this.chkShowNodes.Size = new System.Drawing.Size(135, 22);
            this.chkShowNodes.TabIndex = 1;
            this.chkShowNodes.Text = "Hiển thị các đỉnh";
            this.chkShowNodes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkShowLineDirection);
            this.groupBox1.Controls.Add(this.chkShowCentroid);
            this.groupBox1.Controls.Add(this.chkShowNodes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thiết lập chế độ hiển thị";
            // 
            // chkShowLineDirection
            // 
            this.chkShowLineDirection.AutoSize = true;
            this.chkShowLineDirection.Location = new System.Drawing.Point(18, 65);
            this.chkShowLineDirection.Name = "chkShowLineDirection";
            this.chkShowLineDirection.Size = new System.Drawing.Size(189, 22);
            this.chkShowLineDirection.TabIndex = 3;
            this.chkShowLineDirection.Text = "Hiển thị hướng cạnh thửa";
            this.chkShowLineDirection.UseVisualStyleBackColor = true;
            // 
            // chkShowCentroid
            // 
            this.chkShowCentroid.AutoSize = true;
            this.chkShowCentroid.Location = new System.Drawing.Point(18, 42);
            this.chkShowCentroid.Name = "chkShowCentroid";
            this.chkShowCentroid.Size = new System.Drawing.Size(137, 22);
            this.chkShowCentroid.TabIndex = 2;
            this.chkShowCentroid.Text = "Hiển thị tâm thửa";
            this.chkShowCentroid.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(138, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLayerVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 133);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLayerVisibility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Che do hien thi lop ban do";
            this.Load += new System.EventHandler(this.frmLayerVisibility_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkShowNodes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkShowLineDirection;
        private System.Windows.Forms.CheckBox chkShowCentroid;
        private System.Windows.Forms.Button btnCancel;
    }
}