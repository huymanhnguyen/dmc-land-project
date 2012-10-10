<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlChuSuDungGDCN
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdvwGDCN = New DMC.[Interface].GridView.ctrlGridView
        Me.numNamSinh = New System.Windows.Forms.NumericUpDown
        Me.cmbQuanHe = New System.Windows.Forms.ComboBox
        Me.cmbQuocTich = New System.Windows.Forms.ComboBox
        Me.cmbGioiTinh = New System.Windows.Forms.ComboBox
        Me.DTPNgayCapHK = New System.Windows.Forms.DateTimePicker
        Me.DTPNgayCapCMT = New System.Windows.Forms.DateTimePicker
        Me.txtDiaChiThuongTru = New System.Windows.Forms.TextBox
        Me.txtNoiCapHK = New System.Windows.Forms.TextBox
        Me.txtSoHoKhau = New System.Windows.Forms.TextBox
        Me.txtNoiCapCMT = New System.Windows.Forms.TextBox
        Me.txtSoCMT = New System.Windows.Forms.TextBox
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.txtMaDoiTuong = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdvwGDCN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(184, 268)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 93
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(624, 269)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(57, 21)
        Me.btnTroGiup.TabIndex = 95
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupBox2.Controls.Add(Me.grdvwGDCN)
        Me.GroupBox2.Controls.Add(Me.numNamSinh)
        Me.GroupBox2.Controls.Add(Me.cmbQuanHe)
        Me.GroupBox2.Controls.Add(Me.cmbQuocTich)
        Me.GroupBox2.Controls.Add(Me.cmbGioiTinh)
        Me.GroupBox2.Controls.Add(Me.DTPNgayCapHK)
        Me.GroupBox2.Controls.Add(Me.DTPNgayCapCMT)
        Me.GroupBox2.Controls.Add(Me.txtDiaChiThuongTru)
        Me.GroupBox2.Controls.Add(Me.txtNoiCapHK)
        Me.GroupBox2.Controls.Add(Me.txtSoHoKhau)
        Me.GroupBox2.Controls.Add(Me.txtNoiCapCMT)
        Me.GroupBox2.Controls.Add(Me.txtSoCMT)
        Me.GroupBox2.Controls.Add(Me.txtHoTen)
        Me.GroupBox2.Controls.Add(Me.txtMaDoiTuong)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 267)
        Me.GroupBox2.TabIndex = 94
        Me.GroupBox2.TabStop = False
        '
        'grdvwGDCN
        '
        Me.grdvwGDCN.AllowUserToAddRows = False
        Me.grdvwGDCN.AllowUserToDeleteRows = False
        Me.grdvwGDCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwGDCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwGDCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwGDCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwGDCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwGDCN.Location = New System.Drawing.Point(6, 156)
        Me.grdvwGDCN.Name = "grdvwGDCN"
        Me.grdvwGDCN.ReadOnly = True
        Me.grdvwGDCN.RowHeadersWidth = 25
        Me.grdvwGDCN.Size = New System.Drawing.Size(669, 107)
        Me.grdvwGDCN.TabIndex = 99
        '
        'numNamSinh
        '
        Me.numNamSinh.Location = New System.Drawing.Point(509, 16)
        Me.numNamSinh.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.numNamSinh.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.numNamSinh.Name = "numNamSinh"
        Me.numNamSinh.Size = New System.Drawing.Size(47, 20)
        Me.numNamSinh.TabIndex = 98
        Me.numNamSinh.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'cmbQuanHe
        '
        Me.cmbQuanHe.FormattingEnabled = True
        Me.cmbQuanHe.Items.AddRange(New Object() {"Chồng", "Vợ", "Ông", "Bà", "Con", "Cháu", "Độc thân"})
        Me.cmbQuanHe.Location = New System.Drawing.Point(591, 129)
        Me.cmbQuanHe.Name = "cmbQuanHe"
        Me.cmbQuanHe.Size = New System.Drawing.Size(85, 21)
        Me.cmbQuanHe.TabIndex = 14
        '
        'cmbQuocTich
        '
        Me.cmbQuocTich.FormattingEnabled = True
        Me.cmbQuocTich.ItemHeight = 13
        Me.cmbQuocTich.Items.AddRange(New Object() {"", "Việt Nam", "Trung Quốc", "Hàn Quốc", "Nhật Bản", "Nga", "Hoa Kỳ"})
        Me.cmbQuocTich.Location = New System.Drawing.Point(106, 43)
        Me.cmbQuocTich.Name = "cmbQuocTich"
        Me.cmbQuocTich.Size = New System.Drawing.Size(85, 21)
        Me.cmbQuocTich.TabIndex = 97
        Me.cmbQuocTich.Text = "Việt Nam"
        '
        'cmbGioiTinh
        '
        Me.cmbGioiTinh.FormattingEnabled = True
        Me.cmbGioiTinh.ItemHeight = 13
        Me.cmbGioiTinh.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cmbGioiTinh.Location = New System.Drawing.Point(627, 16)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(49, 21)
        Me.cmbGioiTinh.TabIndex = 96
        '
        'DTPNgayCapHK
        '
        Me.DTPNgayCapHK.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapHK.Location = New System.Drawing.Point(106, 101)
        Me.DTPNgayCapHK.Name = "DTPNgayCapHK"
        Me.DTPNgayCapHK.Size = New System.Drawing.Size(100, 20)
        Me.DTPNgayCapHK.TabIndex = 11
        '
        'DTPNgayCapCMT
        '
        Me.DTPNgayCapCMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT.Location = New System.Drawing.Point(548, 42)
        Me.DTPNgayCapCMT.Name = "DTPNgayCapCMT"
        Me.DTPNgayCapCMT.Size = New System.Drawing.Size(128, 20)
        Me.DTPNgayCapCMT.TabIndex = 8
        '
        'txtDiaChiThuongTru
        '
        Me.txtDiaChiThuongTru.Location = New System.Drawing.Point(106, 130)
        Me.txtDiaChiThuongTru.Name = "txtDiaChiThuongTru"
        Me.txtDiaChiThuongTru.Size = New System.Drawing.Size(415, 20)
        Me.txtDiaChiThuongTru.TabIndex = 13
        '
        'txtNoiCapHK
        '
        Me.txtNoiCapHK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapHK.Location = New System.Drawing.Point(328, 101)
        Me.txtNoiCapHK.Name = "txtNoiCapHK"
        Me.txtNoiCapHK.Size = New System.Drawing.Size(349, 20)
        Me.txtNoiCapHK.TabIndex = 12
        '
        'txtSoHoKhau
        '
        Me.txtSoHoKhau.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoHoKhau.Location = New System.Drawing.Point(548, 73)
        Me.txtSoHoKhau.Name = "txtSoHoKhau"
        Me.txtSoHoKhau.Size = New System.Drawing.Size(128, 20)
        Me.txtSoHoKhau.TabIndex = 10
        '
        'txtNoiCapCMT
        '
        Me.txtNoiCapCMT.Location = New System.Drawing.Point(106, 72)
        Me.txtNoiCapCMT.Name = "txtNoiCapCMT"
        Me.txtNoiCapCMT.Size = New System.Drawing.Size(340, 20)
        Me.txtNoiCapCMT.TabIndex = 9
        '
        'txtSoCMT
        '
        Me.txtSoCMT.Location = New System.Drawing.Point(273, 43)
        Me.txtSoCMT.Name = "txtSoCMT"
        Me.txtSoCMT.Size = New System.Drawing.Size(173, 20)
        Me.txtSoCMT.TabIndex = 7
        '
        'txtHoTen
        '
        Me.txtHoTen.Location = New System.Drawing.Point(273, 13)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(173, 20)
        Me.txtHoTen.TabIndex = 3
        '
        'txtMaDoiTuong
        '
        Me.txtMaDoiTuong.Location = New System.Drawing.Point(107, 13)
        Me.txtMaDoiTuong.Name = "txtMaDoiTuong"
        Me.txtMaDoiTuong.Size = New System.Drawing.Size(83, 20)
        Me.txtMaDoiTuong.TabIndex = 2
        Me.txtMaDoiTuong.Text = "GDC"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(197, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Số CMT(HC)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(574, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Giới tính"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Nơi cấp CMT (HC)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Ngày cấp hộ khẩu"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(215, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Nơi ĐKHK thường trú"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Quốc tịch"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(452, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Số hộ khẩu"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Địa chỉ thường trú"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(527, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Quan hệ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(452, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Ngày cấp CMT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(452, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Năm sinh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Họ tên"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Mã đối tượng"
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(125, 268)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 92
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(66, 268)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 91
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(5, 268)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(59, 21)
        Me.btnCapNhat.TabIndex = 90
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'ctrlChuSuDungGDCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnTroGiup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Name = "ctrlChuSuDungGDCN"
        Me.Size = New System.Drawing.Size(688, 292)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdvwGDCN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwGDCN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents numNamSinh As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbQuanHe As System.Windows.Forms.ComboBox
    Friend WithEvents cmbQuocTich As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGioiTinh As System.Windows.Forms.ComboBox
    Friend WithEvents DTPNgayCapHK As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPNgayCapCMT As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDiaChiThuongTru As System.Windows.Forms.TextBox
    Friend WithEvents txtNoiCapHK As System.Windows.Forms.TextBox
    Friend WithEvents txtSoHoKhau As System.Windows.Forms.TextBox
    Friend WithEvents txtNoiCapCMT As System.Windows.Forms.TextBox
    Friend WithEvents txtSoCMT As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents txtMaDoiTuong As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button

End Class
