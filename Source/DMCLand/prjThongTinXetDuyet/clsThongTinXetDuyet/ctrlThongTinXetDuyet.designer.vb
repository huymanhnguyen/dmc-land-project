<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinXetDuyet
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
        Me.btnBienBanXetDuyet = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbKetQuaXetDuyet = New System.Windows.Forms.ComboBox
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.txtToTrinh = New System.Windows.Forms.TextBox
        Me.dtpNgayXetDuyet = New System.Windows.Forms.DateTimePicker
        Me.dtpNgayTrinh = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnThem = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtYKienCanBoXetDuyet = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLyDoKhongCap = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNoiDungTranhChapKhieuKien = New System.Windows.Forms.TextBox
        Me.chkCanhBaoTranhChap = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPhamViBaoVeHaTang = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.numDienTichRieng = New System.Windows.Forms.NumericUpDown
        Me.numDienTichChung = New System.Windows.Forms.NumericUpDown
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.NumDatKhongCap = New System.Windows.Forms.NumericUpDown
        Me.NumCapDatVuon = New System.Windows.Forms.NumericUpDown
        Me.NumCapDatO = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numDienTichRieng, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDienTichChung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDatKhongCap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCapDatVuon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCapDatO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBienBanXetDuyet
        '
        Me.btnBienBanXetDuyet.Location = New System.Drawing.Point(303, 325)
        Me.btnBienBanXetDuyet.Name = "btnBienBanXetDuyet"
        Me.btnBienBanXetDuyet.Size = New System.Drawing.Size(103, 21)
        Me.btnBienBanXetDuyet.TabIndex = 12
        Me.btnBienBanXetDuyet.Text = "Biên bản xét duyệt"
        Me.btnBienBanXetDuyet.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Kết quả xét duyệt"
        '
        'cmbKetQuaXetDuyet
        '
        Me.cmbKetQuaXetDuyet.FormattingEnabled = True
        Me.cmbKetQuaXetDuyet.Location = New System.Drawing.Point(109, 10)
        Me.cmbKetQuaXetDuyet.Name = "cmbKetQuaXetDuyet"
        Me.cmbKetQuaXetDuyet.Size = New System.Drawing.Size(99, 21)
        Me.cmbKetQuaXetDuyet.TabIndex = 2
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(72, 325)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(246, 325)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 11
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(130, 325)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(188, 325)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 10
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'txtToTrinh
        '
        Me.txtToTrinh.Location = New System.Drawing.Point(109, 13)
        Me.txtToTrinh.Name = "txtToTrinh"
        Me.txtToTrinh.Size = New System.Drawing.Size(99, 20)
        Me.txtToTrinh.TabIndex = 0
        '
        'dtpNgayXetDuyet
        '
        Me.dtpNgayXetDuyet.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayXetDuyet.Location = New System.Drawing.Point(341, 11)
        Me.dtpNgayXetDuyet.Name = "dtpNgayXetDuyet"
        Me.dtpNgayXetDuyet.Size = New System.Drawing.Size(111, 20)
        Me.dtpNgayXetDuyet.TabIndex = 3
        '
        'dtpNgayTrinh
        '
        Me.dtpNgayTrinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayTrinh.Location = New System.Drawing.Point(341, 13)
        Me.dtpNgayTrinh.Name = "dtpNgayTrinh"
        Me.dtpNgayTrinh.Size = New System.Drawing.Size(111, 20)
        Me.dtpNgayTrinh.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Ngày xét duyệt"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Ngày trình"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Tờ trình"
        '
        'btnThem
        '
        Me.btnThem.Enabled = False
        Me.btnThem.Location = New System.Drawing.Point(14, 325)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtYKienCanBoXetDuyet)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtLyDoKhongCap)
        Me.GroupBox1.Controls.Add(Me.numDienTichRieng)
        Me.GroupBox1.Controls.Add(Me.numDienTichChung)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.NumDatKhongCap)
        Me.GroupBox1.Controls.Add(Me.NumCapDatVuon)
        Me.GroupBox1.Controls.Add(Me.NumCapDatO)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmbKetQuaXetDuyet)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpNgayXetDuyet)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 173)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Kết quả xét duyệt"
        '
        'txtYKienCanBoXetDuyet
        '
        Me.txtYKienCanBoXetDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYKienCanBoXetDuyet.Location = New System.Drawing.Point(112, 144)
        Me.txtYKienCanBoXetDuyet.Multiline = True
        Me.txtYKienCanBoXetDuyet.Name = "txtYKienCanBoXetDuyet"
        Me.txtYKienCanBoXetDuyet.Size = New System.Drawing.Size(572, 22)
        Me.txtYKienCanBoXetDuyet.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Lý do không cấp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Ý kiến xét duyệt"
        '
        'txtLyDoKhongCap
        '
        Me.txtLyDoKhongCap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongCap.Location = New System.Drawing.Point(112, 116)
        Me.txtLyDoKhongCap.Multiline = True
        Me.txtLyDoKhongCap.Name = "txtLyDoKhongCap"
        Me.txtLyDoKhongCap.Size = New System.Drawing.Size(572, 22)
        Me.txtLyDoKhongCap.TabIndex = 6
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.dtpNgayTrinh)
        Me.GroupBox5.Controls.Add(Me.txtToTrinh)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(688, 37)
        Me.GroupBox5.TabIndex = 78
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Thông tin tờ trình cấp cơ sở (Phường)"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.txtNoiDungTranhChapKhieuKien)
        Me.GroupBox6.Controls.Add(Me.chkCanhBaoTranhChap)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Red
        Me.GroupBox6.Location = New System.Drawing.Point(0, 221)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(688, 38)
        Me.GroupBox6.TabIndex = 79
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Tình trạng tranh chấp khiếu kiện"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(204, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Nội dung:"
        '
        'txtNoiDungTranhChapKhieuKien
        '
        Me.txtNoiDungTranhChapKhieuKien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiDungTranhChapKhieuKien.Location = New System.Drawing.Point(258, 12)
        Me.txtNoiDungTranhChapKhieuKien.Multiline = True
        Me.txtNoiDungTranhChapKhieuKien.Name = "txtNoiDungTranhChapKhieuKien"
        Me.txtNoiDungTranhChapKhieuKien.Size = New System.Drawing.Size(426, 22)
        Me.txtNoiDungTranhChapKhieuKien.TabIndex = 5
        '
        'chkCanhBaoTranhChap
        '
        Me.chkCanhBaoTranhChap.AutoSize = True
        Me.chkCanhBaoTranhChap.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCanhBaoTranhChap.Location = New System.Drawing.Point(8, 16)
        Me.chkCanhBaoTranhChap.Name = "chkCanhBaoTranhChap"
        Me.chkCanhBaoTranhChap.Size = New System.Drawing.Size(184, 17)
        Me.chkCanhBaoTranhChap.TabIndex = 4
        Me.chkCanhBaoTranhChap.Text = "Cảnh báo tranh chấp, khiếu kiện."
        Me.chkCanhBaoTranhChap.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPhamViBaoVeHaTang)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(3, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(688, 54)
        Me.GroupBox2.TabIndex = 81
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Phạm vi bảo vệ công trình hạ tầng"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(5, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Nội dung"
        '
        'txtPhamViBaoVeHaTang
        '
        Me.txtPhamViBaoVeHaTang.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhamViBaoVeHaTang.Location = New System.Drawing.Point(108, 19)
        Me.txtPhamViBaoVeHaTang.Multiline = True
        Me.txtPhamViBaoVeHaTang.Name = "txtPhamViBaoVeHaTang"
        Me.txtPhamViBaoVeHaTang.Size = New System.Drawing.Size(576, 22)
        Me.txtPhamViBaoVeHaTang.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(613, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "(m2)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(613, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "(m2)"
        '
        'numDienTichRieng
        '
        Me.numDienTichRieng.Cursor = System.Windows.Forms.Cursors.Default
        Me.numDienTichRieng.DecimalPlaces = 2
        Me.numDienTichRieng.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDienTichRieng.Location = New System.Drawing.Point(487, 58)
        Me.numDienTichRieng.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numDienTichRieng.Name = "numDienTichRieng"
        Me.numDienTichRieng.Size = New System.Drawing.Size(120, 20)
        Me.numDienTichRieng.TabIndex = 88
        Me.numDienTichRieng.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDienTichChung
        '
        Me.numDienTichChung.Cursor = System.Windows.Forms.Cursors.Default
        Me.numDienTichChung.DecimalPlaces = 2
        Me.numDienTichChung.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDienTichChung.Location = New System.Drawing.Point(487, 33)
        Me.numDienTichChung.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numDienTichChung.Name = "numDienTichChung"
        Me.numDienTichChung.Size = New System.Drawing.Size(120, 20)
        Me.numDienTichChung.TabIndex = 87
        Me.numDienTichChung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(362, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 86
        Me.Label17.Text = "Diện tích riêng"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(362, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "Diện tích chung"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(295, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "(m2)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(295, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "(m2)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(295, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "(m2)"
        '
        'NumDatKhongCap
        '
        Me.NumDatKhongCap.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumDatKhongCap.DecimalPlaces = 2
        Me.NumDatKhongCap.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumDatKhongCap.Location = New System.Drawing.Point(166, 86)
        Me.NumDatKhongCap.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumDatKhongCap.Name = "NumDatKhongCap"
        Me.NumDatKhongCap.Size = New System.Drawing.Size(120, 20)
        Me.NumDatKhongCap.TabIndex = 81
        Me.NumDatKhongCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumCapDatVuon
        '
        Me.NumCapDatVuon.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumCapDatVuon.DecimalPlaces = 2
        Me.NumCapDatVuon.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumCapDatVuon.Location = New System.Drawing.Point(166, 61)
        Me.NumCapDatVuon.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumCapDatVuon.Name = "NumCapDatVuon"
        Me.NumCapDatVuon.Size = New System.Drawing.Size(120, 20)
        Me.NumCapDatVuon.TabIndex = 80
        Me.NumCapDatVuon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NumCapDatO
        '
        Me.NumCapDatO.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumCapDatO.DecimalPlaces = 2
        Me.NumCapDatO.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumCapDatO.Location = New System.Drawing.Point(166, 36)
        Me.NumCapDatO.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumCapDatO.Name = "NumCapDatO"
        Me.NumCapDatO.Size = New System.Drawing.Size(120, 20)
        Me.NumCapDatO.TabIndex = 79
        Me.NumCapDatO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Diện tích không cấp"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Diện tích cấp đất vườn"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Diện tích cấp đất ở"
        '
        'ctrlThongTinXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.btnBienBanXetDuyet)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Name = "ctrlThongTinXetDuyet"
        Me.Size = New System.Drawing.Size(696, 353)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numDienTichRieng, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDienTichChung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDatKhongCap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCapDatVuon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCapDatO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBienBanXetDuyet As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbKetQuaXetDuyet As System.Windows.Forms.ComboBox
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents txtToTrinh As System.Windows.Forms.TextBox
    Friend WithEvents dtpNgayXetDuyet As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgayTrinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtYKienCanBoXetDuyet As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCanhBaoTranhChap As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNoiDungTranhChapKhieuKien As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKhongCap As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPhamViBaoVeHaTang As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents numDienTichRieng As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDienTichChung As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumDatKhongCap As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCapDatVuon As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCapDatO As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
