﻿namespace DMC.Land.TachThua
{
    partial class frmLichSuBienDong
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
            this.ctrLichSuBienDong1 = new prjXemLichSuThuaDat.ctrLichSuBienDong();
            this.SuspendLayout();
            // 
            // ctrLichSuBienDong1
            // 
            this.ctrLichSuBienDong1.Connection = "";
            this.ctrLichSuBienDong1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrLichSuBienDong1.Location = new System.Drawing.Point(0, 0);
            this.ctrLichSuBienDong1.MaThuaDat = "";
            this.ctrLichSuBienDong1.Name = "ctrLichSuBienDong1";
            this.ctrLichSuBienDong1.Size = new System.Drawing.Size(711, 502);
            this.ctrLichSuBienDong1.TabIndex = 0;
            // 
            // frmLichSuBienDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 502);
            this.Controls.Add(this.ctrLichSuBienDong1);
            this.Name = "frmLichSuBienDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LICH SU BIEN DONG THUA DAT";
            this.Load += new System.EventHandler(this.frmLichSuBienDong_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public  prjXemLichSuThuaDat.ctrLichSuBienDong ctrLichSuBienDong1;
    }
}