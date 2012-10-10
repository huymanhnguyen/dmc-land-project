namespace DMC.Land.SoanHoSo
{
    partial class frmSetTextStyle
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
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownTextAngle = new System.Windows.Forms.NumericUpDown();
            this.radioButtonTextOpaque = new System.Windows.Forms.RadioButton();
            this.radioButtonTextHalo = new System.Windows.Forms.RadioButton();
            this.radioButtonTextNoBackground = new System.Windows.Forms.RadioButton();
            this.textBoxTextText = new System.Windows.Forms.TextBox();
            this.comboBoxTextFontFamily = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownTextSize = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxTextBold = new System.Windows.Forms.CheckBox();
            this.checkBoxTextItalic = new System.Windows.Forms.CheckBox();
            this.checkBoxTextUnderline = new System.Windows.Forms.CheckBox();
            this.checkBoxTextStrikeout = new System.Windows.Forms.CheckBox();
            this.checkBoxTextAllCaps = new System.Windows.Forms.CheckBox();
            this.checkBoxTextShadow = new System.Windows.Forms.CheckBox();
            this.checkBoxTextDoubleSpace = new System.Windows.Forms.CheckBox();
            this.buttonTextForeColor = new System.Windows.Forms.Button();
            this.buttonTextBackColor = new System.Windows.Forms.Button();
            this.groupBoxTextProperties = new System.Windows.Forms.GroupBox();
            this.groupBoxTextFontProperties = new System.Windows.Forms.GroupBox();
            this.cmdChapNhan = new System.Windows.Forms.Button();
            this.cmdHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextSize)).BeginInit();
            this.groupBoxTextProperties.SuspendLayout();
            this.groupBoxTextFontProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Góc quay";
            // 
            // numericUpDownTextAngle
            // 
            this.numericUpDownTextAngle.DecimalPlaces = 2;
            this.numericUpDownTextAngle.Location = new System.Drawing.Point(82, 136);
            this.numericUpDownTextAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownTextAngle.Name = "numericUpDownTextAngle";
            this.numericUpDownTextAngle.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownTextAngle.TabIndex = 71;
            this.numericUpDownTextAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTextAngle.ValueChanged += new System.EventHandler(this.numericUpDownTextAngle_ValueChanged);
            // 
            // radioButtonTextOpaque
            // 
            this.radioButtonTextOpaque.AutoSize = true;
            this.radioButtonTextOpaque.Location = new System.Drawing.Point(243, 103);
            this.radioButtonTextOpaque.Name = "radioButtonTextOpaque";
            this.radioButtonTextOpaque.Size = new System.Drawing.Size(72, 17);
            this.radioButtonTextOpaque.TabIndex = 70;
            this.radioButtonTextOpaque.Text = "Hộp chứa";
            this.radioButtonTextOpaque.CheckedChanged += new System.EventHandler(this.radioButtonTextOpaque_CheckedChanged);
            // 
            // radioButtonTextHalo
            // 
            this.radioButtonTextHalo.AutoSize = true;
            this.radioButtonTextHalo.Location = new System.Drawing.Point(243, 79);
            this.radioButtonTextHalo.Name = "radioButtonTextHalo";
            this.radioButtonTextHalo.Size = new System.Drawing.Size(72, 17);
            this.radioButtonTextHalo.TabIndex = 69;
            this.radioButtonTextHalo.Text = "Viền sáng";
            this.radioButtonTextHalo.CheckedChanged += new System.EventHandler(this.radioButtonTextHalo_CheckedChanged);
            // 
            // radioButtonTextNoBackground
            // 
            this.radioButtonTextNoBackground.AutoSize = true;
            this.radioButtonTextNoBackground.Checked = true;
            this.radioButtonTextNoBackground.Location = new System.Drawing.Point(243, 55);
            this.radioButtonTextNoBackground.Name = "radioButtonTextNoBackground";
            this.radioButtonTextNoBackground.Size = new System.Drawing.Size(100, 17);
            this.radioButtonTextNoBackground.TabIndex = 68;
            this.radioButtonTextNoBackground.TabStop = true;
            this.radioButtonTextNoBackground.Text = "Không màu nền";
            this.radioButtonTextNoBackground.CheckedChanged += new System.EventHandler(this.radioButtonTextNoBackground_CheckedChanged);
            // 
            // textBoxTextText
            // 
            this.textBoxTextText.AcceptsReturn = true;
            this.textBoxTextText.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTextText.Location = new System.Drawing.Point(6, 30);
            this.textBoxTextText.Multiline = true;
            this.textBoxTextText.Name = "textBoxTextText";
            this.textBoxTextText.Size = new System.Drawing.Size(172, 100);
            this.textBoxTextText.TabIndex = 67;
            this.textBoxTextText.WordWrap = false;
            // 
            // comboBoxTextFontFamily
            // 
            this.comboBoxTextFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTextFontFamily.Location = new System.Drawing.Point(54, 30);
            this.comboBoxTextFontFamily.Name = "comboBoxTextFontFamily";
            this.comboBoxTextFontFamily.Size = new System.Drawing.Size(167, 21);
            this.comboBoxTextFontFamily.TabIndex = 59;
            this.comboBoxTextFontFamily.SelectedIndexChanged += new System.EventHandler(this.comboBoxTextFontFamily_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Tên font";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "Chữ:";
            // 
            // numericUpDownTextSize
            // 
            this.numericUpDownTextSize.Location = new System.Drawing.Point(291, 30);
            this.numericUpDownTextSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTextSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTextSize.Name = "numericUpDownTextSize";
            this.numericUpDownTextSize.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownTextSize.TabIndex = 55;
            this.numericUpDownTextSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTextSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTextSize.ValueChanged += new System.EventHandler(this.numericUpDownTextSize_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Kích thước:";
            // 
            // checkBoxTextBold
            // 
            this.checkBoxTextBold.Location = new System.Drawing.Point(204, 63);
            this.checkBoxTextBold.Name = "checkBoxTextBold";
            this.checkBoxTextBold.Size = new System.Drawing.Size(72, 24);
            this.checkBoxTextBold.TabIndex = 65;
            this.checkBoxTextBold.Text = "Đậm";
            this.checkBoxTextBold.CheckedChanged += new System.EventHandler(this.checkBoxTextBold_CheckedChanged);
            // 
            // checkBoxTextItalic
            // 
            this.checkBoxTextItalic.Location = new System.Drawing.Point(204, 87);
            this.checkBoxTextItalic.Name = "checkBoxTextItalic";
            this.checkBoxTextItalic.Size = new System.Drawing.Size(72, 24);
            this.checkBoxTextItalic.TabIndex = 64;
            this.checkBoxTextItalic.Text = "Nghiêng";
            this.checkBoxTextItalic.CheckedChanged += new System.EventHandler(this.checkBoxTextItalic_CheckedChanged);
            // 
            // checkBoxTextUnderline
            // 
            this.checkBoxTextUnderline.Location = new System.Drawing.Point(204, 111);
            this.checkBoxTextUnderline.Name = "checkBoxTextUnderline";
            this.checkBoxTextUnderline.Size = new System.Drawing.Size(86, 24);
            this.checkBoxTextUnderline.TabIndex = 63;
            this.checkBoxTextUnderline.Text = "Gạch chân";
            this.checkBoxTextUnderline.CheckedChanged += new System.EventHandler(this.checkBoxTextUnderline_CheckedChanged);
            // 
            // checkBoxTextStrikeout
            // 
            this.checkBoxTextStrikeout.AutoSize = true;
            this.checkBoxTextStrikeout.Location = new System.Drawing.Point(204, 135);
            this.checkBoxTextStrikeout.Name = "checkBoxTextStrikeout";
            this.checkBoxTextStrikeout.Size = new System.Drawing.Size(85, 17);
            this.checkBoxTextStrikeout.TabIndex = 66;
            this.checkBoxTextStrikeout.Text = "Gạch ngang";
            this.checkBoxTextStrikeout.CheckedChanged += new System.EventHandler(this.checkBoxTextStrikeout_CheckedChanged);
            // 
            // checkBoxTextAllCaps
            // 
            this.checkBoxTextAllCaps.Location = new System.Drawing.Point(97, 55);
            this.checkBoxTextAllCaps.Name = "checkBoxTextAllCaps";
            this.checkBoxTextAllCaps.Size = new System.Drawing.Size(93, 24);
            this.checkBoxTextAllCaps.TabIndex = 61;
            this.checkBoxTextAllCaps.Text = "Chữ hoa";
            this.checkBoxTextAllCaps.CheckedChanged += new System.EventHandler(this.checkBoxTextAllCaps_CheckedChanged);
            // 
            // checkBoxTextShadow
            // 
            this.checkBoxTextShadow.Location = new System.Drawing.Point(97, 103);
            this.checkBoxTextShadow.Name = "checkBoxTextShadow";
            this.checkBoxTextShadow.Size = new System.Drawing.Size(93, 24);
            this.checkBoxTextShadow.TabIndex = 60;
            this.checkBoxTextShadow.Text = "Đổ bóng";
            this.checkBoxTextShadow.CheckedChanged += new System.EventHandler(this.checkBoxTextShadow_CheckedChanged);
            // 
            // checkBoxTextDoubleSpace
            // 
            this.checkBoxTextDoubleSpace.Location = new System.Drawing.Point(97, 79);
            this.checkBoxTextDoubleSpace.Name = "checkBoxTextDoubleSpace";
            this.checkBoxTextDoubleSpace.Size = new System.Drawing.Size(149, 24);
            this.checkBoxTextDoubleSpace.TabIndex = 62;
            this.checkBoxTextDoubleSpace.Text = "Nhân đôi khoảng trống";
            this.checkBoxTextDoubleSpace.CheckedChanged += new System.EventHandler(this.checkBoxTextDoubleSpace_CheckedChanged);
            // 
            // buttonTextForeColor
            // 
            this.buttonTextForeColor.Location = new System.Drawing.Point(202, 125);
            this.buttonTextForeColor.Name = "buttonTextForeColor";
            this.buttonTextForeColor.Size = new System.Drawing.Size(64, 24);
            this.buttonTextForeColor.TabIndex = 54;
            this.buttonTextForeColor.Text = "Màu chữ";
            this.buttonTextForeColor.Click += new System.EventHandler(this.buttonTextForeColor_Click);
            // 
            // buttonTextBackColor
            // 
            this.buttonTextBackColor.Location = new System.Drawing.Point(282, 125);
            this.buttonTextBackColor.Name = "buttonTextBackColor";
            this.buttonTextBackColor.Size = new System.Drawing.Size(64, 24);
            this.buttonTextBackColor.TabIndex = 53;
            this.buttonTextBackColor.Text = "Màu nền";
            this.buttonTextBackColor.Click += new System.EventHandler(this.buttonTextBackColor_Click);
            // 
            // groupBoxTextProperties
            // 
            this.groupBoxTextProperties.Controls.Add(this.label4);
            this.groupBoxTextProperties.Controls.Add(this.label12);
            this.groupBoxTextProperties.Controls.Add(this.numericUpDownTextAngle);
            this.groupBoxTextProperties.Controls.Add(this.textBoxTextText);
            this.groupBoxTextProperties.Location = new System.Drawing.Point(4, 8);
            this.groupBoxTextProperties.Name = "groupBoxTextProperties";
            this.groupBoxTextProperties.Size = new System.Drawing.Size(184, 161);
            this.groupBoxTextProperties.TabIndex = 77;
            this.groupBoxTextProperties.TabStop = false;
            this.groupBoxTextProperties.Text = "Thuộc tính text";
            // 
            // groupBoxTextFontProperties
            // 
            this.groupBoxTextFontProperties.Controls.Add(this.label11);
            this.groupBoxTextFontProperties.Controls.Add(this.label13);
            this.groupBoxTextFontProperties.Controls.Add(this.radioButtonTextOpaque);
            this.groupBoxTextFontProperties.Controls.Add(this.numericUpDownTextSize);
            this.groupBoxTextFontProperties.Controls.Add(this.radioButtonTextHalo);
            this.groupBoxTextFontProperties.Controls.Add(this.radioButtonTextNoBackground);
            this.groupBoxTextFontProperties.Controls.Add(this.comboBoxTextFontFamily);
            this.groupBoxTextFontProperties.Controls.Add(this.buttonTextBackColor);
            this.groupBoxTextFontProperties.Controls.Add(this.buttonTextForeColor);
            this.groupBoxTextFontProperties.Controls.Add(this.checkBoxTextDoubleSpace);
            this.groupBoxTextFontProperties.Controls.Add(this.checkBoxTextShadow);
            this.groupBoxTextFontProperties.Controls.Add(this.checkBoxTextAllCaps);
            this.groupBoxTextFontProperties.Location = new System.Drawing.Point(196, 8);
            this.groupBoxTextFontProperties.Name = "groupBoxTextFontProperties";
            this.groupBoxTextFontProperties.Size = new System.Drawing.Size(352, 161);
            this.groupBoxTextFontProperties.TabIndex = 78;
            this.groupBoxTextFontProperties.TabStop = false;
            this.groupBoxTextFontProperties.Text = "Thuộc tính Font";
            // 
            // cmdChapNhan
            // 
            this.cmdChapNhan.Location = new System.Drawing.Point(376, 175);
            this.cmdChapNhan.Name = "cmdChapNhan";
            this.cmdChapNhan.Size = new System.Drawing.Size(86, 25);
            this.cmdChapNhan.TabIndex = 79;
            this.cmdChapNhan.Text = "Chấp nhận";
            this.cmdChapNhan.UseVisualStyleBackColor = true;
            this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
            // 
            // cmdHuy
            // 
            this.cmdHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdHuy.Location = new System.Drawing.Point(469, 175);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(81, 24);
            this.cmdHuy.TabIndex = 80;
            this.cmdHuy.Text = "Huỷ lệnh";
            this.cmdHuy.UseVisualStyleBackColor = true;
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // frmSetTextStyle
            // 
            this.AcceptButton = this.cmdChapNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdHuy;
            this.ClientSize = new System.Drawing.Size(554, 225);
            this.Controls.Add(this.cmdHuy);
            this.Controls.Add(this.cmdChapNhan);
            this.Controls.Add(this.checkBoxTextBold);
            this.Controls.Add(this.checkBoxTextItalic);
            this.Controls.Add(this.checkBoxTextUnderline);
            this.Controls.Add(this.checkBoxTextStrikeout);
            this.Controls.Add(this.groupBoxTextProperties);
            this.Controls.Add(this.groupBoxTextFontProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetTextStyle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dinh dang chu";
            this.Load += new System.EventHandler(this.frmSetTextStyle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTextSize)).EndInit();
            this.groupBoxTextProperties.ResumeLayout(false);
            this.groupBoxTextProperties.PerformLayout();
            this.groupBoxTextFontProperties.ResumeLayout(false);
            this.groupBoxTextFontProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownTextAngle;
        private System.Windows.Forms.RadioButton radioButtonTextOpaque;
        private System.Windows.Forms.RadioButton radioButtonTextHalo;
        private System.Windows.Forms.RadioButton radioButtonTextNoBackground;
        private System.Windows.Forms.TextBox textBoxTextText;
        private System.Windows.Forms.ComboBox comboBoxTextFontFamily;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownTextSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxTextBold;
        private System.Windows.Forms.CheckBox checkBoxTextItalic;
        private System.Windows.Forms.CheckBox checkBoxTextUnderline;
        private System.Windows.Forms.CheckBox checkBoxTextStrikeout;
        private System.Windows.Forms.CheckBox checkBoxTextAllCaps;
        private System.Windows.Forms.CheckBox checkBoxTextShadow;
        private System.Windows.Forms.CheckBox checkBoxTextDoubleSpace;
        private System.Windows.Forms.Button buttonTextForeColor;
        private System.Windows.Forms.Button buttonTextBackColor;
        private System.Windows.Forms.GroupBox groupBoxTextProperties;
        private System.Windows.Forms.GroupBox groupBoxTextFontProperties;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.Button cmdHuy;

    }
}