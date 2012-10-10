<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtTimKiemHoSoThuaDat
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.cmdTimChuSuDung = New System.Windows.Forms.Button
        Me.cmdTimMoiChuSuDung = New System.Windows.Forms.Button
        Me.txtDinhDanh = New System.Windows.Forms.TextBox
        Me.txtTenChu = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmdTimThua = New System.Windows.Forms.Button
        Me.cmdTimMoiThua = New System.Windows.Forms.Button
        Me.txtDiaChiDat = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtToBanDo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSoThua = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.cmdTimHoSo = New System.Windows.Forms.Button
        Me.cmdTimMoiHoSo = New System.Windows.Forms.Button
        Me.txtHoSoTiepNhanSo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTrangThaiHoSo = New System.Windows.Forms.ComboBox
        Me.txtSoThuTuTiepNhan = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cmdTimGCN = New System.Windows.Forms.Button
        Me.cmdTimMoiGCN = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtToTrinh = New System.Windows.Forms.TextBox
        Me.txtNamCapGCN = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtNamTrinh = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSoPhatHanhGCN = New System.Windows.Forms.TextBox
        Me.txtSoQuyetDinhCapGCN = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSoVaoSoGCN = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkChonBanDo = New System.Windows.Forms.CheckBox
        Me.cmdChonHoSo = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.grdvwTacNghiep = New DMC.[Interface].GridView.ctrlGridView
        Me.grdvwTimKiem = New DMC.[Interface].GridView.ctrlGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdvwTacNghiep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvwTimKiem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(786, 120)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Lavender
        Me.TabPage4.Controls.Add(Me.cmdTimChuSuDung)
        Me.TabPage4.Controls.Add(Me.cmdTimMoiChuSuDung)
        Me.TabPage4.Controls.Add(Me.txtDinhDanh)
        Me.TabPage4.Controls.Add(Me.txtTenChu)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(778, 94)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Tag = "1"
        Me.TabPage4.Text = "Thông tin chủ sử dụng"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'cmdTimChuSuDung
        '
        Me.cmdTimChuSuDung.Location = New System.Drawing.Point(69, 63)
        Me.cmdTimChuSuDung.Name = "cmdTimChuSuDung"
        Me.cmdTimChuSuDung.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimChuSuDung.TabIndex = 4
        Me.cmdTimChuSuDung.Text = "Tìm"
        Me.cmdTimChuSuDung.UseVisualStyleBackColor = True
        '
        'cmdTimMoiChuSuDung
        '
        Me.cmdTimMoiChuSuDung.Location = New System.Drawing.Point(6, 63)
        Me.cmdTimMoiChuSuDung.Name = "cmdTimMoiChuSuDung"
        Me.cmdTimMoiChuSuDung.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimMoiChuSuDung.TabIndex = 3
        Me.cmdTimMoiChuSuDung.Text = "Tìm mới"
        Me.cmdTimMoiChuSuDung.UseVisualStyleBackColor = True
        '
        'txtDinhDanh
        '
        Me.txtDinhDanh.Location = New System.Drawing.Point(119, 34)
        Me.txtDinhDanh.Name = "txtDinhDanh"
        Me.txtDinhDanh.Size = New System.Drawing.Size(144, 20)
        Me.txtDinhDanh.TabIndex = 2
        '
        'txtTenChu
        '
        Me.txtTenChu.Location = New System.Drawing.Point(119, 9)
        Me.txtTenChu.Name = "txtTenChu"
        Me.txtTenChu.Size = New System.Drawing.Size(302, 20)
        Me.txtTenChu.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(6, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Tên chủ sử dụng đất"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 12)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "CMT (HC, GPKD)"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Lavender
        Me.TabPage2.Controls.Add(Me.cmdTimThua)
        Me.TabPage2.Controls.Add(Me.cmdTimMoiThua)
        Me.TabPage2.Controls.Add(Me.txtDiaChiDat)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtToBanDo)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtSoThua)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(920, 94)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "2"
        Me.TabPage2.Text = "Thông tin thửa đất"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdTimThua
        '
        Me.cmdTimThua.Location = New System.Drawing.Point(69, 63)
        Me.cmdTimThua.Name = "cmdTimThua"
        Me.cmdTimThua.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimThua.TabIndex = 9
        Me.cmdTimThua.Text = "Tìm"
        Me.cmdTimThua.UseVisualStyleBackColor = True
        '
        'cmdTimMoiThua
        '
        Me.cmdTimMoiThua.Location = New System.Drawing.Point(6, 63)
        Me.cmdTimMoiThua.Name = "cmdTimMoiThua"
        Me.cmdTimMoiThua.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimMoiThua.TabIndex = 8
        Me.cmdTimMoiThua.Text = "Tìm mới"
        Me.cmdTimMoiThua.UseVisualStyleBackColor = True
        '
        'txtDiaChiDat
        '
        Me.txtDiaChiDat.Location = New System.Drawing.Point(74, 35)
        Me.txtDiaChiDat.Name = "txtDiaChiDat"
        Me.txtDiaChiDat.Size = New System.Drawing.Size(466, 20)
        Me.txtDiaChiDat.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Địa chỉ đất"
        '
        'txtToBanDo
        '
        Me.txtToBanDo.Location = New System.Drawing.Point(74, 9)
        Me.txtToBanDo.Name = "txtToBanDo"
        Me.txtToBanDo.Size = New System.Drawing.Size(90, 20)
        Me.txtToBanDo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Tờ bản đồ"
        '
        'txtSoThua
        '
        Me.txtSoThua.Location = New System.Drawing.Point(230, 9)
        Me.txtSoThua.Name = "txtSoThua"
        Me.txtSoThua.Size = New System.Drawing.Size(85, 20)
        Me.txtSoThua.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(180, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Số thửa"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Lavender
        Me.TabPage3.Controls.Add(Me.cmdTimHoSo)
        Me.TabPage3.Controls.Add(Me.cmdTimMoiHoSo)
        Me.TabPage3.Controls.Add(Me.txtHoSoTiepNhanSo)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.cmbTrangThaiHoSo)
        Me.TabPage3.Controls.Add(Me.txtSoThuTuTiepNhan)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(920, 94)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Tag = "3"
        Me.TabPage3.Text = "Thông tin hồ sơ"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdTimHoSo
        '
        Me.cmdTimHoSo.Location = New System.Drawing.Point(69, 63)
        Me.cmdTimHoSo.Name = "cmdTimHoSo"
        Me.cmdTimHoSo.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimHoSo.TabIndex = 14
        Me.cmdTimHoSo.Text = "Tìm"
        Me.cmdTimHoSo.UseVisualStyleBackColor = True
        '
        'cmdTimMoiHoSo
        '
        Me.cmdTimMoiHoSo.Location = New System.Drawing.Point(6, 63)
        Me.cmdTimMoiHoSo.Name = "cmdTimMoiHoSo"
        Me.cmdTimMoiHoSo.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimMoiHoSo.TabIndex = 13
        Me.cmdTimMoiHoSo.Text = "Tìm mới"
        Me.cmdTimMoiHoSo.UseVisualStyleBackColor = True
        '
        'txtHoSoTiepNhanSo
        '
        Me.txtHoSoTiepNhanSo.Location = New System.Drawing.Point(108, 35)
        Me.txtHoSoTiepNhanSo.Name = "txtHoSoTiepNhanSo"
        Me.txtHoSoTiepNhanSo.Size = New System.Drawing.Size(123, 20)
        Me.txtHoSoTiepNhanSo.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(256, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Số thứ tự tiếp nhận"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Hồ sơ tiếp nhận số"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Trạng thái hồ sơ"
        '
        'cmbTrangThaiHoSo
        '
        Me.cmbTrangThaiHoSo.FormattingEnabled = True
        Me.cmbTrangThaiHoSo.Items.AddRange(New Object() {"Tất cả", "Các thửa mới tạo", "Hồ sơ kê khai", "Xét duyệt cấp phường", "Thẩm định", "Phê duyệt", "Thửa đã cấp GCN", "Thửa không đủ điều kiện", "Thửa chưa đủ điều kiện", "Thửa đã biến động"})
        Me.cmbTrangThaiHoSo.Location = New System.Drawing.Point(108, 9)
        Me.cmbTrangThaiHoSo.Name = "cmbTrangThaiHoSo"
        Me.cmbTrangThaiHoSo.Size = New System.Drawing.Size(123, 21)
        Me.cmbTrangThaiHoSo.TabIndex = 10
        '
        'txtSoThuTuTiepNhan
        '
        Me.txtSoThuTuTiepNhan.Location = New System.Drawing.Point(359, 35)
        Me.txtSoThuTuTiepNhan.Name = "txtSoThuTuTiepNhan"
        Me.txtSoThuTuTiepNhan.Size = New System.Drawing.Size(96, 20)
        Me.txtSoThuTuTiepNhan.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Lavender
        Me.TabPage1.Controls.Add(Me.cmdTimGCN)
        Me.TabPage1.Controls.Add(Me.cmdTimMoiGCN)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtToTrinh)
        Me.TabPage1.Controls.Add(Me.txtNamCapGCN)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtNamTrinh)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtSoPhatHanhGCN)
        Me.TabPage1.Controls.Add(Me.txtSoQuyetDinhCapGCN)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtSoVaoSoGCN)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(920, 94)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "4"
        Me.TabPage1.Text = "Thông tin cấp GCN"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdTimGCN
        '
        Me.cmdTimGCN.Location = New System.Drawing.Point(69, 63)
        Me.cmdTimGCN.Name = "cmdTimGCN"
        Me.cmdTimGCN.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimGCN.TabIndex = 22
        Me.cmdTimGCN.Text = "Tìm"
        Me.cmdTimGCN.UseVisualStyleBackColor = True
        '
        'cmdTimMoiGCN
        '
        Me.cmdTimMoiGCN.Location = New System.Drawing.Point(6, 63)
        Me.cmdTimMoiGCN.Name = "cmdTimMoiGCN"
        Me.cmdTimMoiGCN.Size = New System.Drawing.Size(57, 23)
        Me.cmdTimMoiGCN.TabIndex = 21
        Me.cmdTimMoiGCN.Text = "Tìm mới"
        Me.cmdTimMoiGCN.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(423, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Năm cấp GCN"
        '
        'txtToTrinh
        '
        Me.txtToTrinh.Location = New System.Drawing.Point(109, 35)
        Me.txtToTrinh.Name = "txtToTrinh"
        Me.txtToTrinh.Size = New System.Drawing.Size(107, 20)
        Me.txtToTrinh.TabIndex = 18
        '
        'txtNamCapGCN
        '
        Me.txtNamCapGCN.Location = New System.Drawing.Point(523, 35)
        Me.txtNamCapGCN.Name = "txtNamCapGCN"
        Me.txtNamCapGCN.Size = New System.Drawing.Size(99, 20)
        Me.txtNamCapGCN.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(6, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Tờ trình"
        '
        'txtNamTrinh
        '
        Me.txtNamTrinh.Location = New System.Drawing.Point(313, 35)
        Me.txtNamTrinh.Name = "txtNamTrinh"
        Me.txtNamTrinh.Size = New System.Drawing.Size(105, 20)
        Me.txtNamTrinh.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(229, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Năm trình"
        '
        'txtSoPhatHanhGCN
        '
        Me.txtSoPhatHanhGCN.Location = New System.Drawing.Point(109, 9)
        Me.txtSoPhatHanhGCN.Name = "txtSoPhatHanhGCN"
        Me.txtSoPhatHanhGCN.Size = New System.Drawing.Size(107, 20)
        Me.txtSoPhatHanhGCN.TabIndex = 15
        '
        'txtSoQuyetDinhCapGCN
        '
        Me.txtSoQuyetDinhCapGCN.Location = New System.Drawing.Point(523, 9)
        Me.txtSoQuyetDinhCapGCN.Name = "txtSoQuyetDinhCapGCN"
        Me.txtSoQuyetDinhCapGCN.Size = New System.Drawing.Size(99, 20)
        Me.txtSoQuyetDinhCapGCN.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(6, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Số phát hành GCN"
        '
        'txtSoVaoSoGCN
        '
        Me.txtSoVaoSoGCN.Location = New System.Drawing.Point(313, 9)
        Me.txtSoVaoSoGCN.Name = "txtSoVaoSoGCN"
        Me.txtSoVaoSoGCN.Size = New System.Drawing.Size(105, 20)
        Me.txtSoVaoSoGCN.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(229, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Số vào sổ GCN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(424, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Số quyết định cấp"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdvwTimKiem)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(779, 199)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách thửa tìm được"
        '
        'chkChonBanDo
        '
        Me.chkChonBanDo.AutoSize = True
        Me.chkChonBanDo.Checked = True
        Me.chkChonBanDo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChonBanDo.Location = New System.Drawing.Point(7, 130)
        Me.chkChonBanDo.Name = "chkChonBanDo"
        Me.chkChonBanDo.Size = New System.Drawing.Size(150, 17)
        Me.chkChonBanDo.TabIndex = 0
        Me.chkChonBanDo.Text = "Đã có bản đồ hành chính"
        Me.chkChonBanDo.UseVisualStyleBackColor = True
        '
        'cmdChonHoSo
        '
        Me.cmdChonHoSo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChonHoSo.Location = New System.Drawing.Point(700, 358)
        Me.cmdChonHoSo.Name = "cmdChonHoSo"
        Me.cmdChonHoSo.Size = New System.Drawing.Size(79, 22)
        Me.cmdChonHoSo.TabIndex = 36
        Me.cmdChonHoSo.Text = "Chọn hồ sơ"
        Me.cmdChonHoSo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grdvwTacNghiep)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 387)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(778, 183)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Thửa chọn để giao việc"
        '
        'cmdAdd
        '
        Me.cmdAdd.Image = Global.prjQuanLyGiaoViec.My.Resources.Resources.bullet_arrow_bottom
        Me.cmdAdd.Location = New System.Drawing.Point(4, 358)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(38, 23)
        Me.cmdAdd.TabIndex = 38
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Image = Global.prjQuanLyGiaoViec.My.Resources.Resources.bullet_arrow_top
        Me.cmdRemove.Location = New System.Drawing.Point(45, 358)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(41, 23)
        Me.cmdRemove.TabIndex = 39
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'grdvwTacNghiep
        '
        Me.grdvwTacNghiep.AllowUserToAddRows = False
        Me.grdvwTacNghiep.AllowUserToDeleteRows = False
        Me.grdvwTacNghiep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwTacNghiep.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwTacNghiep.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdvwTacNghiep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwTacNghiep.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdvwTacNghiep.Location = New System.Drawing.Point(6, 19)
        Me.grdvwTacNghiep.Name = "grdvwTacNghiep"
        Me.grdvwTacNghiep.ReadOnly = True
        Me.grdvwTacNghiep.RowHeadersVisible = False
        Me.grdvwTacNghiep.RowHeadersWidth = 25
        Me.grdvwTacNghiep.Size = New System.Drawing.Size(772, 158)
        Me.grdvwTacNghiep.TabIndex = 24
        '
        'grdvwTimKiem
        '
        Me.grdvwTimKiem.AllowUserToAddRows = False
        Me.grdvwTimKiem.AllowUserToDeleteRows = False
        Me.grdvwTimKiem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwTimKiem.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwTimKiem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwTimKiem.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwTimKiem.Location = New System.Drawing.Point(2, 19)
        Me.grdvwTimKiem.Name = "grdvwTimKiem"
        Me.grdvwTimKiem.ReadOnly = True
        Me.grdvwTimKiem.RowHeadersVisible = False
        Me.grdvwTimKiem.RowHeadersWidth = 25
        Me.grdvwTimKiem.Size = New System.Drawing.Size(774, 174)
        Me.grdvwTimKiem.TabIndex = 23
        '
        'crtTimKiemHoSoThuaDat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdChonHoSo)
        Me.Controls.Add(Me.chkChonBanDo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "crtTimKiemHoSoThuaDat"
        Me.Size = New System.Drawing.Size(786, 573)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdvwTacNghiep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvwTimKiem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtToTrinh As System.Windows.Forms.TextBox
    Friend WithEvents txtNamCapGCN As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNamTrinh As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSoPhatHanhGCN As System.Windows.Forms.TextBox
    Friend WithEvents txtSoQuyetDinhCapGCN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSoVaoSoGCN As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDiaChiDat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtToBanDo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSoThua As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHoSoTiepNhanSo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTrangThaiHoSo As System.Windows.Forms.ComboBox
    Friend WithEvents txtSoThuTuTiepNhan As System.Windows.Forms.TextBox
    Friend WithEvents txtDinhDanh As System.Windows.Forms.TextBox
    Friend WithEvents txtTenChu As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdTimGCN As System.Windows.Forms.Button
    Friend WithEvents cmdTimMoiGCN As System.Windows.Forms.Button
    Friend WithEvents cmdTimThua As System.Windows.Forms.Button
    Friend WithEvents cmdTimMoiThua As System.Windows.Forms.Button
    Friend WithEvents cmdTimHoSo As System.Windows.Forms.Button
    Friend WithEvents cmdTimMoiHoSo As System.Windows.Forms.Button
    Friend WithEvents cmdTimChuSuDung As System.Windows.Forms.Button
    Friend WithEvents cmdTimMoiChuSuDung As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwTimKiem As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents chkChonBanDo As System.Windows.Forms.CheckBox
    Friend WithEvents cmdChonHoSo As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwTacNghiep As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button

End Class
