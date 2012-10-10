<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlChuGDCN
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
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupThaoTac = New System.Windows.Forms.GroupBox
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
        Me.chkChuRungCay = New System.Windows.Forms.CheckBox
        Me.chkChuCongTrinhXayDung = New System.Windows.Forms.CheckBox
        Me.chkChuNhaO = New System.Windows.Forms.CheckBox
        Me.chkChuDat = New System.Windows.Forms.CheckBox
        Me.chkChuCayLauNam = New System.Windows.Forms.CheckBox
        Me.chbTonTai = New System.Windows.Forms.CheckBox
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupThaoTac.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(239, 373)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 118
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(180, 373)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 117
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(121, 373)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(57, 21)
        Me.btnSua.TabIndex = 116
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(62, 373)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(57, 21)
        Me.btnThem.TabIndex = 115
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(1, 373)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(57, 21)
        Me.btnTraCuu.TabIndex = 113
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(298, 373)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 112
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.GroupThaoTac.Controls.Add(Me.grdvwChu)
        Me.GroupThaoTac.Controls.Add(Me.chkChuRungCay)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCongTrinhXayDung)
        Me.GroupThaoTac.Controls.Add(Me.chkChuNhaO)
        Me.GroupThaoTac.Controls.Add(Me.chkChuDat)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCayLauNam)
        Me.GroupThaoTac.Controls.Add(Me.chbTonTai)
        Me.GroupThaoTac.Controls.Add(Me.numNamSinh)
        Me.GroupThaoTac.Controls.Add(Me.cmbQuanHe)
        Me.GroupThaoTac.Controls.Add(Me.cmbQuocTich)
        Me.GroupThaoTac.Controls.Add(Me.cmbGioiTinh)
        Me.GroupThaoTac.Controls.Add(Me.DTPNgayCapHK)
        Me.GroupThaoTac.Controls.Add(Me.DTPNgayCapCMT)
        Me.GroupThaoTac.Controls.Add(Me.txtDiaChiThuongTru)
        Me.GroupThaoTac.Controls.Add(Me.txtNoiCapHK)
        Me.GroupThaoTac.Controls.Add(Me.txtSoHoKhau)
        Me.GroupThaoTac.Controls.Add(Me.txtNoiCapCMT)
        Me.GroupThaoTac.Controls.Add(Me.txtSoCMT)
        Me.GroupThaoTac.Controls.Add(Me.txtHoTen)
        Me.GroupThaoTac.Controls.Add(Me.txtMaDoiTuong)
        Me.GroupThaoTac.Controls.Add(Me.Label5)
        Me.GroupThaoTac.Controls.Add(Me.Label14)
        Me.GroupThaoTac.Controls.Add(Me.Label15)
        Me.GroupThaoTac.Controls.Add(Me.Label16)
        Me.GroupThaoTac.Controls.Add(Me.Label17)
        Me.GroupThaoTac.Controls.Add(Me.Label18)
        Me.GroupThaoTac.Controls.Add(Me.Label19)
        Me.GroupThaoTac.Controls.Add(Me.Label20)
        Me.GroupThaoTac.Controls.Add(Me.Label21)
        Me.GroupThaoTac.Controls.Add(Me.Label22)
        Me.GroupThaoTac.Controls.Add(Me.Label23)
        Me.GroupThaoTac.Controls.Add(Me.Label24)
        Me.GroupThaoTac.Controls.Add(Me.Label25)
        Me.GroupThaoTac.Location = New System.Drawing.Point(1, 3)
        Me.GroupThaoTac.Name = "GroupThaoTac"
        Me.GroupThaoTac.Size = New System.Drawing.Size(700, 366)
        Me.GroupThaoTac.TabIndex = 120
        Me.GroupThaoTac.TabStop = False
        '
        'grdvwChu
        '
        Me.grdvwChu.AllowUserToAddRows = False
        Me.grdvwChu.AllowUserToDeleteRows = False
        Me.grdvwChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChu.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwChu.Location = New System.Drawing.Point(6, 193)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(688, 165)
        Me.grdvwChu.TabIndex = 131
        '
        'chkChuRungCay
        '
        Me.chkChuRungCay.AutoSize = True
        Me.chkChuRungCay.Location = New System.Drawing.Point(481, 162)
        Me.chkChuRungCay.Name = "chkChuRungCay"
        Me.chkChuRungCay.Size = New System.Drawing.Size(94, 17)
        Me.chkChuRungCay.TabIndex = 130
        Me.chkChuRungCay.Text = "Chủ Rừng cây"
        Me.chkChuRungCay.UseVisualStyleBackColor = True
        '
        'chkChuCongTrinhXayDung
        '
        Me.chkChuCongTrinhXayDung.AutoSize = True
        Me.chkChuCongTrinhXayDung.Location = New System.Drawing.Point(324, 162)
        Me.chkChuCongTrinhXayDung.Name = "chkChuCongTrinhXayDung"
        Me.chkChuCongTrinhXayDung.Size = New System.Drawing.Size(142, 17)
        Me.chkChuCongTrinhXayDung.TabIndex = 129
        Me.chkChuCongTrinhXayDung.Text = "Chủ Công trình xây dựng"
        Me.chkChuCongTrinhXayDung.UseVisualStyleBackColor = True
        '
        'chkChuNhaO
        '
        Me.chkChuNhaO.AutoSize = True
        Me.chkChuNhaO.Location = New System.Drawing.Point(194, 162)
        Me.chkChuNhaO.Name = "chkChuNhaO"
        Me.chkChuNhaO.Size = New System.Drawing.Size(120, 17)
        Me.chkChuNhaO.TabIndex = 128
        Me.chkChuNhaO.Text = "Chủ Nhà ở (Căn hộ)"
        Me.chkChuNhaO.UseVisualStyleBackColor = True
        '
        'chkChuDat
        '
        Me.chkChuDat.AutoSize = True
        Me.chkChuDat.Location = New System.Drawing.Point(114, 162)
        Me.chkChuDat.Name = "chkChuDat"
        Me.chkChuDat.Size = New System.Drawing.Size(65, 17)
        Me.chkChuDat.TabIndex = 127
        Me.chkChuDat.Text = "Chủ Đất"
        Me.chkChuDat.UseVisualStyleBackColor = True
        '
        'chkChuCayLauNam
        '
        Me.chkChuCayLauNam.AutoSize = True
        Me.chkChuCayLauNam.Location = New System.Drawing.Point(587, 162)
        Me.chkChuCayLauNam.Name = "chkChuCayLauNam"
        Me.chkChuCayLauNam.Size = New System.Drawing.Size(106, 17)
        Me.chkChuCayLauNam.TabIndex = 126
        Me.chkChuCayLauNam.Text = "Chủ Cây lâu năm"
        Me.chkChuCayLauNam.UseVisualStyleBackColor = True
        '
        'chbTonTai
        '
        Me.chbTonTai.AutoSize = True
        Me.chbTonTai.Checked = True
        Me.chbTonTai.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTonTai.Location = New System.Drawing.Point(616, 136)
        Me.chbTonTai.Name = "chbTonTai"
        Me.chbTonTai.Size = New System.Drawing.Size(71, 17)
        Me.chbTonTai.TabIndex = 125
        Me.chbTonTai.Text = "Còn sống"
        Me.chbTonTai.UseVisualStyleBackColor = True
        '
        'numNamSinh
        '
        Me.numNamSinh.Location = New System.Drawing.Point(518, 18)
        Me.numNamSinh.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.numNamSinh.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.numNamSinh.Name = "numNamSinh"
        Me.numNamSinh.Size = New System.Drawing.Size(47, 20)
        Me.numNamSinh.TabIndex = 124
        Me.numNamSinh.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'cmbQuanHe
        '
        Me.cmbQuanHe.FormattingEnabled = True
        Me.cmbQuanHe.Items.AddRange(New Object() {"Chồng", "Vợ", "Ông", "Bà", "Con", "Cháu", "Độc thân"})
        Me.cmbQuanHe.Location = New System.Drawing.Point(495, 132)
        Me.cmbQuanHe.Name = "cmbQuanHe"
        Me.cmbQuanHe.Size = New System.Drawing.Size(85, 21)
        Me.cmbQuanHe.TabIndex = 108
        '
        'cmbQuocTich
        '
        Me.cmbQuocTich.FormattingEnabled = True
        Me.cmbQuocTich.ItemHeight = 13
        Me.cmbQuocTich.Items.AddRange(New Object() {"", "Việt Nam", "Trung Quốc", "Hàn Quốc", "Nhật Bản", "Nga", "Hoa Kỳ"})
        Me.cmbQuocTich.Location = New System.Drawing.Point(115, 45)
        Me.cmbQuocTich.Name = "cmbQuocTich"
        Me.cmbQuocTich.Size = New System.Drawing.Size(85, 21)
        Me.cmbQuocTich.TabIndex = 123
        Me.cmbQuocTich.Text = "Việt Nam"
        '
        'cmbGioiTinh
        '
        Me.cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGioiTinh.FormattingEnabled = True
        Me.cmbGioiTinh.ItemHeight = 13
        Me.cmbGioiTinh.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cmbGioiTinh.Location = New System.Drawing.Point(636, 18)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(49, 21)
        Me.cmbGioiTinh.TabIndex = 122
        '
        'DTPNgayCapHK
        '
        Me.DTPNgayCapHK.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapHK.Location = New System.Drawing.Point(115, 103)
        Me.DTPNgayCapHK.Name = "DTPNgayCapHK"
        Me.DTPNgayCapHK.Size = New System.Drawing.Size(100, 20)
        Me.DTPNgayCapHK.TabIndex = 105
        '
        'DTPNgayCapCMT
        '
        Me.DTPNgayCapCMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT.Location = New System.Drawing.Point(557, 44)
        Me.DTPNgayCapCMT.Name = "DTPNgayCapCMT"
        Me.DTPNgayCapCMT.Size = New System.Drawing.Size(128, 20)
        Me.DTPNgayCapCMT.TabIndex = 102
        '
        'txtDiaChiThuongTru
        '
        Me.txtDiaChiThuongTru.Location = New System.Drawing.Point(115, 132)
        Me.txtDiaChiThuongTru.Name = "txtDiaChiThuongTru"
        Me.txtDiaChiThuongTru.Size = New System.Drawing.Size(315, 20)
        Me.txtDiaChiThuongTru.TabIndex = 107
        '
        'txtNoiCapHK
        '
        Me.txtNoiCapHK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapHK.Location = New System.Drawing.Point(337, 103)
        Me.txtNoiCapHK.Name = "txtNoiCapHK"
        Me.txtNoiCapHK.Size = New System.Drawing.Size(350, 20)
        Me.txtNoiCapHK.TabIndex = 106
        '
        'txtSoHoKhau
        '
        Me.txtSoHoKhau.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoHoKhau.Location = New System.Drawing.Point(557, 75)
        Me.txtSoHoKhau.Name = "txtSoHoKhau"
        Me.txtSoHoKhau.Size = New System.Drawing.Size(129, 20)
        Me.txtSoHoKhau.TabIndex = 104
        '
        'txtNoiCapCMT
        '
        Me.txtNoiCapCMT.Location = New System.Drawing.Point(115, 74)
        Me.txtNoiCapCMT.Name = "txtNoiCapCMT"
        Me.txtNoiCapCMT.Size = New System.Drawing.Size(340, 20)
        Me.txtNoiCapCMT.TabIndex = 103
        '
        'txtSoCMT
        '
        Me.txtSoCMT.Location = New System.Drawing.Point(282, 45)
        Me.txtSoCMT.Name = "txtSoCMT"
        Me.txtSoCMT.Size = New System.Drawing.Size(173, 20)
        Me.txtSoCMT.TabIndex = 101
        '
        'txtHoTen
        '
        Me.txtHoTen.Location = New System.Drawing.Point(282, 15)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(173, 20)
        Me.txtHoTen.TabIndex = 100
        '
        'txtMaDoiTuong
        '
        Me.txtMaDoiTuong.Location = New System.Drawing.Point(116, 15)
        Me.txtMaDoiTuong.Name = "txtMaDoiTuong"
        Me.txtMaDoiTuong.Size = New System.Drawing.Size(83, 20)
        Me.txtMaDoiTuong.TabIndex = 99
        Me.txtMaDoiTuong.Text = "GDC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(206, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Số CMT(HC)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(583, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Giới tính"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "Nơi cấp CMT (HC)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 106)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Ngày cấp hộ khẩu"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(224, 107)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "Nơi ĐKHK thường trú"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "Quốc tịch"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(461, 78)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 115
        Me.Label19.Text = "Số hộ khẩu"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 134)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Địa chỉ thường trú"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(441, 136)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "Quan hệ"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(461, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Ngày cấp CMT"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(461, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Năm sinh"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(219, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 110
        Me.Label24.Text = "Họ tên"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(11, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Mã đối tượng"
        '
        'ctrlChuGDCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.btnTraCuu)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Name = "ctrlChuGDCN"
        Me.Size = New System.Drawing.Size(704, 397)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupThaoTac As System.Windows.Forms.GroupBox
    Friend WithEvents chbTonTai As System.Windows.Forms.CheckBox
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkChuRungCay As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuCongTrinhXayDung As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuNhaO As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuDat As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuCayLauNam As System.Windows.Forms.CheckBox
    Friend WithEvents grdvwChu As DMC.Interface.GridView.ctrlGridView

End Class
