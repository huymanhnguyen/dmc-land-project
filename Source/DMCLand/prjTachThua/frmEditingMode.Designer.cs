namespace TachThua
{
    partial class frmEditingMode
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
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.groupEditingMode = new System.Windows.Forms.GroupBox();
            this.radioAddNode = new System.Windows.Forms.RadioButton();
            this.radioNodes = new System.Windows.Forms.RadioButton();
            this.radioObjects = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupEditingMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Location = new System.Drawing.Point(6, 23);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(318, 22);
            this.radioNone.TabIndex = 0;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "Không cho phép hiệu chỉnh đối tượng bản đồ";
            this.radioNone.UseVisualStyleBackColor = true;
            // 
            // groupEditingMode
            // 
            this.groupEditingMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupEditingMode.Controls.Add(this.radioAddNode);
            this.groupEditingMode.Controls.Add(this.radioNodes);
            this.groupEditingMode.Controls.Add(this.radioObjects);
            this.groupEditingMode.Controls.Add(this.radioNone);
            this.groupEditingMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupEditingMode.Location = new System.Drawing.Point(3, 2);
            this.groupEditingMode.Name = "groupEditingMode";
            this.groupEditingMode.Size = new System.Drawing.Size(332, 129);
            this.groupEditingMode.TabIndex = 1;
            this.groupEditingMode.TabStop = false;
            this.groupEditingMode.Text = "Chế độ hiệu chỉnh bản đồ";
            // 
            // radioAddNode
            // 
            this.radioAddNode.AutoSize = true;
            this.radioAddNode.Location = new System.Drawing.Point(6, 101);
            this.radioAddNode.Name = "radioAddNode";
            this.radioAddNode.Size = new System.Drawing.Size(158, 22);
            this.radioAddNode.TabIndex = 3;
            this.radioAddNode.TabStop = true;
            this.radioAddNode.Text = "Cho phép thêm đỉnh";
            this.radioAddNode.UseVisualStyleBackColor = true;
            // 
            // radioNodes
            // 
            this.radioNodes.AutoSize = true;
            this.radioNodes.Location = new System.Drawing.Point(6, 81);
            this.radioNodes.Name = "radioNodes";
            this.radioNodes.Size = new System.Drawing.Size(196, 22);
            this.radioNodes.TabIndex = 2;
            this.radioNodes.TabStop = true;
            this.radioNodes.Text = "Cho phép sửa và xóa đỉnh";
            this.radioNodes.UseVisualStyleBackColor = true;
            // 
            // radioObjects
            // 
            this.radioObjects.Location = new System.Drawing.Point(6, 43);
            this.radioObjects.Name = "radioObjects";
            this.radioObjects.Size = new System.Drawing.Size(318, 40);
            this.radioObjects.TabIndex = 1;
            this.radioObjects.TabStop = true;
            this.radioObjects.Text = "Cho phép di chuyển và thay đổi kích thước đối tượng bản đồ";
            this.radioObjects.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(51, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(173, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmEditingMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 169);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupEditingMode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditingMode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Che do hieu chinh ban do";
            this.Load += new System.EventHandler(this.frmEditingMode_Load);
            this.groupEditingMode.ResumeLayout(false);
            this.groupEditingMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.GroupBox groupEditingMode;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioAddNode;
        private System.Windows.Forms.RadioButton radioNodes;
        private System.Windows.Forms.RadioButton radioObjects;
    }
}