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
        Me.cboDinhDanh = New System.Windows.Forms.ComboBox
        Me.RadGiaDinh = New System.Windows.Forms.RadioButton
        Me.RadCaNhan = New System.Windows.Forms.RadioButton
        Me.chkDongSoHuu = New System.Windows.Forms.CheckBox
        Me.cmbQuocTich2 = New System.Windows.Forms.ComboBox
        Me.DTPNgayCapCMT2 = New System.Windows.Forms.DateTimePicker
        Me.txtNoiCapCMT2 = New System.Windows.Forms.TextBox
        Me.txtSoCMT2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
        Me.chkChuRungCay = New System.Windows.Forms.CheckBox
        Me.chkChuCongTrinhXayDung = New System.Windows.Forms.CheckBox
        Me.chkChuNhaO = New System.Windows.Forms.CheckBox
        Me.chkChuDat = New System.Windows.Forms.CheckBox
        Me.chkChuCayLauNam = New System.Windows.Forms.CheckBox
        Me.chkDaChet = New System.Windows.Forms.CheckBox
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdNoiCapCMT1 = New System.Windows.Forms.Button
        Me.cmdNoiCapCMT2 = New System.Windows.Forms.Button
        Me.cmdNoiDangKyHK = New System.Windows.Forms.Button
        Me.GroupThaoTac.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(247, 12)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 29
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(188, 12)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 28
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(129, 12)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(57, 21)
        Me.btnSua.TabIndex = 27
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(70, 12)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(57, 21)
        Me.btnThem.TabIndex = 26
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(10, 12)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(57, 21)
        Me.btnTraCuu.TabIndex = 25
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(306, 12)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 30
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThaoTac.BackColor = System.Drawing.Color.Lavender
        Me.GroupThaoTac.Controls.Add(Me.cmdNoiDangKyHK)
        Me.GroupThaoTac.Controls.Add(Me.cmdNoiCapCMT2)
        Me.GroupThaoTac.Controls.Add(Me.cmdNoiCapCMT1)
        Me.GroupThaoTac.Controls.Add(Me.cboDinhDanh)
        Me.GroupThaoTac.Controls.Add(Me.RadGiaDinh)
        Me.GroupThaoTac.Controls.Add(Me.RadCaNhan)
        Me.GroupThaoTac.Controls.Add(Me.chkDongSoHuu)
        Me.GroupThaoTac.Controls.Add(Me.cmbQuocTich2)
        Me.GroupThaoTac.Controls.Add(Me.DTPNgayCapCMT2)
        Me.GroupThaoTac.Controls.Add(Me.txtNoiCapCMT2)
        Me.GroupThaoTac.Controls.Add(Me.txtSoCMT2)
        Me.GroupThaoTac.Controls.Add(Me.Label1)
        Me.GroupThaoTac.Controls.Add(Me.Label2)
        Me.GroupThaoTac.Controls.Add(Me.Label3)
        Me.GroupThaoTac.Controls.Add(Me.Label4)
        Me.GroupThaoTac.Controls.Add(Me.grdvwChu)
        Me.GroupThaoTac.Controls.Add(Me.chkChuRungCay)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCongTrinhXayDung)
        Me.GroupThaoTac.Controls.Add(Me.chkChuNhaO)
        Me.GroupThaoTac.Controls.Add(Me.chkChuDat)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCayLauNam)
        Me.GroupThaoTac.Controls.Add(Me.chkDaChet)
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
        Me.GroupThaoTac.Size = New System.Drawing.Size(697, 413)
        Me.GroupThaoTac.TabIndex = 120
        Me.GroupThaoTac.TabStop = False
        '
        'cboDinhDanh
        '
        Me.cboDinhDanh.FormattingEnabled = True
        Me.cboDinhDanh.Items.AddRange(New Object() {"CMND", "CMSQ", "CMQĐ", "Hộ chiếu"})
        Me.cboDinhDanh.Location = New System.Drawing.Point(363, 93)
        Me.cboDinhDanh.Name = "cboDinhDanh"
        Me.cboDinhDanh.Size = New System.Drawing.Size(136, 21)
        Me.cboDinhDanh.TabIndex = 143
        '
        'RadGiaDinh
        '
        Me.RadGiaDinh.AutoSize = True
        Me.RadGiaDinh.Location = New System.Drawing.Point(313, 16)
        Me.RadGiaDinh.Name = "RadGiaDinh"
        Me.RadGiaDinh.Size = New System.Drawing.Size(65, 17)
        Me.RadGiaDinh.TabIndex = 142
        Me.RadGiaDinh.Text = "Gia đình"
        Me.RadGiaDinh.UseVisualStyleBackColor = True
        '
        'RadCaNhan
        '
        Me.RadCaNhan.AutoSize = True
        Me.RadCaNhan.Checked = True
        Me.RadCaNhan.Location = New System.Drawing.Point(217, 16)
        Me.RadCaNhan.Name = "RadCaNhan"
        Me.RadCaNhan.Size = New System.Drawing.Size(65, 17)
        Me.RadCaNhan.TabIndex = 141
        Me.RadCaNhan.TabStop = True
        Me.RadCaNhan.Text = "Cá nhân"
        Me.RadCaNhan.UseVisualStyleBackColor = True
        '
        'chkDongSoHuu
        '
        Me.chkDongSoHuu.AutoSize = True
        Me.chkDongSoHuu.Location = New System.Drawing.Point(253, 42)
        Me.chkDongSoHuu.Name = "chkDongSoHuu"
        Me.chkDongSoHuu.Size = New System.Drawing.Size(87, 17)
        Me.chkDongSoHuu.TabIndex = 139
        Me.chkDongSoHuu.Text = "Đồng sở hữu"
        Me.chkDongSoHuu.UseVisualStyleBackColor = True
        '
        'cmbQuocTich2
        '
        Me.cmbQuocTich2.FormattingEnabled = True
        Me.cmbQuocTich2.ItemHeight = 13
        Me.cmbQuocTich2.Items.AddRange(New Object() {"", "Việt Nam", "Trung Quốc", "Hàn Quốc", "Nhật Bản", "Nga", "Hoa Kỳ", "Canada"})
        Me.cmbQuocTich2.Location = New System.Drawing.Point(116, 144)
        Me.cmbQuocTich2.Name = "cmbQuocTich2"
        Me.cmbQuocTich2.Size = New System.Drawing.Size(119, 21)
        Me.cmbQuocTich2.TabIndex = 11
        '
        'DTPNgayCapCMT2
        '
        Me.DTPNgayCapCMT2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT2.Location = New System.Drawing.Point(116, 172)
        Me.DTPNgayCapCMT2.Name = "DTPNgayCapCMT2"
        Me.DTPNgayCapCMT2.Size = New System.Drawing.Size(119, 20)
        Me.DTPNgayCapCMT2.TabIndex = 13
        '
        'txtNoiCapCMT2
        '
        Me.txtNoiCapCMT2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapCMT2.Location = New System.Drawing.Point(362, 173)
        Me.txtNoiCapCMT2.Name = "txtNoiCapCMT2"
        Me.txtNoiCapCMT2.Size = New System.Drawing.Size(287, 20)
        Me.txtNoiCapCMT2.TabIndex = 14
        '
        'txtSoCMT2
        '
        Me.txtSoCMT2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoCMT2.Location = New System.Drawing.Point(362, 146)
        Me.txtSoCMT2.Name = "txtSoCMT2"
        Me.txtSoCMT2.Size = New System.Drawing.Size(327, 20)
        Me.txtSoCMT2.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(277, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Số CMT(HC) 2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Nơi cấp CMT (HC) 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Quốc tịch 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Ngày cấp CMT (HC) 2"
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
        Me.grdvwChu.Location = New System.Drawing.Point(7, 292)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(685, 115)
        Me.grdvwChu.TabIndex = 24
        '
        'chkChuRungCay
        '
        Me.chkChuRungCay.AutoSize = True
        Me.chkChuRungCay.Location = New System.Drawing.Point(476, 262)
        Me.chkChuRungCay.Name = "chkChuRungCay"
        Me.chkChuRungCay.Size = New System.Drawing.Size(88, 17)
        Me.chkChuRungCay.TabIndex = 22
        Me.chkChuRungCay.Text = "Là chủ Rừng"
        Me.chkChuRungCay.UseVisualStyleBackColor = True
        '
        'chkChuCongTrinhXayDung
        '
        Me.chkChuCongTrinhXayDung.AutoSize = True
        Me.chkChuCongTrinhXayDung.Location = New System.Drawing.Point(318, 262)
        Me.chkChuCongTrinhXayDung.Name = "chkChuCongTrinhXayDung"
        Me.chkChuCongTrinhXayDung.Size = New System.Drawing.Size(156, 17)
        Me.chkChuCongTrinhXayDung.TabIndex = 21
        Me.chkChuCongTrinhXayDung.Text = "Là chủ Công trình xây dựng"
        Me.chkChuCongTrinhXayDung.UseVisualStyleBackColor = True
        '
        'chkChuNhaO
        '
        Me.chkChuNhaO.AutoSize = True
        Me.chkChuNhaO.Location = New System.Drawing.Point(198, 262)
        Me.chkChuNhaO.Name = "chkChuNhaO"
        Me.chkChuNhaO.Size = New System.Drawing.Size(112, 17)
        Me.chkChuNhaO.TabIndex = 20
        Me.chkChuNhaO.Text = "Là chủ Nhà (CHộ)"
        Me.chkChuNhaO.UseVisualStyleBackColor = True
        '
        'chkChuDat
        '
        Me.chkChuDat.AutoSize = True
        Me.chkChuDat.Location = New System.Drawing.Point(116, 262)
        Me.chkChuDat.Name = "chkChuDat"
        Me.chkChuDat.Size = New System.Drawing.Size(79, 17)
        Me.chkChuDat.TabIndex = 19
        Me.chkChuDat.Text = "Là chủ Đất"
        Me.chkChuDat.UseVisualStyleBackColor = True
        '
        'chkChuCayLauNam
        '
        Me.chkChuCayLauNam.AutoSize = True
        Me.chkChuCayLauNam.Location = New System.Drawing.Point(575, 263)
        Me.chkChuCayLauNam.Name = "chkChuCayLauNam"
        Me.chkChuCayLauNam.Size = New System.Drawing.Size(120, 17)
        Me.chkChuCayLauNam.TabIndex = 23
        Me.chkChuCayLauNam.Text = "Là chủ Cây lâu năm"
        Me.chkChuCayLauNam.UseVisualStyleBackColor = True
        '
        'chkDaChet
        '
        Me.chkDaChet.AutoSize = True
        Me.chkDaChet.Location = New System.Drawing.Point(363, 67)
        Me.chkDaChet.Name = "chkDaChet"
        Me.chkDaChet.Size = New System.Drawing.Size(64, 17)
        Me.chkDaChet.TabIndex = 4
        Me.chkDaChet.Text = "Đã chết"
        Me.chkDaChet.UseVisualStyleBackColor = True
        '
        'numNamSinh
        '
        Me.numNamSinh.Location = New System.Drawing.Point(525, 66)
        Me.numNamSinh.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
        Me.numNamSinh.Minimum = New Decimal(New Integer() {1700, 0, 0, 0})
        Me.numNamSinh.Name = "numNamSinh"
        Me.numNamSinh.Size = New System.Drawing.Size(47, 20)
        Me.numNamSinh.TabIndex = 5
        Me.numNamSinh.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'cmbQuanHe
        '
        Me.cmbQuanHe.FormattingEnabled = True
        Me.cmbQuanHe.Items.AddRange(New Object() {"Chồng", "Và Chồng", "Vợ", "Và Vợ", "Ông", "Và Ông", "Hộ Ông", "Bà", "Và Bà", "Hộ Bà", "Con", "Và Con", "Cháu", "Và Cháu"})
        Me.cmbQuanHe.Location = New System.Drawing.Point(117, 39)
        Me.cmbQuanHe.Name = "cmbQuanHe"
        Me.cmbQuanHe.Size = New System.Drawing.Size(130, 21)
        Me.cmbQuanHe.TabIndex = 2
        '
        'cmbQuocTich
        '
        Me.cmbQuocTich.FormattingEnabled = True
        Me.cmbQuocTich.ItemHeight = 13
        Me.cmbQuocTich.Items.AddRange(New Object() {"", "Việt Nam", "Trung Quốc", "Hàn Quốc", "Nhật Bản", "Nga", "Hoa Kỳ"})
        Me.cmbQuocTich.Location = New System.Drawing.Point(116, 91)
        Me.cmbQuocTich.Name = "cmbQuocTich"
        Me.cmbQuocTich.Size = New System.Drawing.Size(119, 21)
        Me.cmbQuocTich.TabIndex = 7
        Me.cmbQuocTich.Text = "Việt Nam"
        '
        'cmbGioiTinh
        '
        Me.cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGioiTinh.FormattingEnabled = True
        Me.cmbGioiTinh.ItemHeight = 13
        Me.cmbGioiTinh.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cmbGioiTinh.Location = New System.Drawing.Point(638, 65)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(49, 21)
        Me.cmbGioiTinh.TabIndex = 6
        '
        'DTPNgayCapHK
        '
        Me.DTPNgayCapHK.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapHK.Location = New System.Drawing.Point(313, 202)
        Me.DTPNgayCapHK.Name = "DTPNgayCapHK"
        Me.DTPNgayCapHK.Size = New System.Drawing.Size(100, 20)
        Me.DTPNgayCapHK.TabIndex = 16
        '
        'DTPNgayCapCMT
        '
        Me.DTPNgayCapCMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT.Location = New System.Drawing.Point(116, 119)
        Me.DTPNgayCapCMT.Name = "DTPNgayCapCMT"
        Me.DTPNgayCapCMT.Size = New System.Drawing.Size(119, 20)
        Me.DTPNgayCapCMT.TabIndex = 9
        '
        'txtDiaChiThuongTru
        '
        Me.txtDiaChiThuongTru.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChiThuongTru.Location = New System.Drawing.Point(116, 232)
        Me.txtDiaChiThuongTru.Name = "txtDiaChiThuongTru"
        Me.txtDiaChiThuongTru.Size = New System.Drawing.Size(570, 20)
        Me.txtDiaChiThuongTru.TabIndex = 18
        Me.txtDiaChiThuongTru.Text = "Phường Long Biên, Quận Long Biên, Tp Hà Nội"
        '
        'txtNoiCapHK
        '
        Me.txtNoiCapHK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapHK.Location = New System.Drawing.Point(476, 203)
        Me.txtNoiCapHK.Name = "txtNoiCapHK"
        Me.txtNoiCapHK.Size = New System.Drawing.Size(173, 20)
        Me.txtNoiCapHK.TabIndex = 17
        '
        'txtSoHoKhau
        '
        Me.txtSoHoKhau.Location = New System.Drawing.Point(116, 201)
        Me.txtSoHoKhau.Name = "txtSoHoKhau"
        Me.txtSoHoKhau.Size = New System.Drawing.Size(119, 20)
        Me.txtSoHoKhau.TabIndex = 15
        '
        'txtNoiCapCMT
        '
        Me.txtNoiCapCMT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapCMT.Location = New System.Drawing.Point(363, 120)
        Me.txtNoiCapCMT.Name = "txtNoiCapCMT"
        Me.txtNoiCapCMT.Size = New System.Drawing.Size(286, 20)
        Me.txtNoiCapCMT.TabIndex = 10
        '
        'txtSoCMT
        '
        Me.txtSoCMT.Location = New System.Drawing.Point(499, 93)
        Me.txtSoCMT.Name = "txtSoCMT"
        Me.txtSoCMT.Size = New System.Drawing.Size(188, 20)
        Me.txtSoCMT.TabIndex = 8
        '
        'txtHoTen
        '
        Me.txtHoTen.Location = New System.Drawing.Point(116, 65)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(237, 20)
        Me.txtHoTen.TabIndex = 3
        '
        'txtMaDoiTuong
        '
        Me.txtMaDoiTuong.Location = New System.Drawing.Point(116, 15)
        Me.txtMaDoiTuong.Name = "txtMaDoiTuong"
        Me.txtMaDoiTuong.Size = New System.Drawing.Size(83, 20)
        Me.txtMaDoiTuong.TabIndex = 1
        Me.txtMaDoiTuong.Text = "GDC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Số CMT(HC)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(586, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Giới tính"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(259, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "Nơi cấp CMT (HC)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(241, 206)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Ngày cấp HK"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(421, 206)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "Nơi ĐKHK"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(57, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "Quốc tịch"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(46, 204)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 115
        Me.Label19.Text = "Số hộ khẩu"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 234)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Địa chỉ thường trú"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(-1, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "Quan hệ ghi trên GCN"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 123)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Ngày cấp CMT (HC)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(465, 70)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Năm sinh"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(71, 68)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 110
        Me.Label24.Text = "Họ tên"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(40, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Mã đối tượng"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnGhi)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnTraCuu)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 410)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(698, 45)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'cmdNoiCapCMT1
        '
        Me.cmdNoiCapCMT1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNoiCapCMT1.Location = New System.Drawing.Point(655, 119)
        Me.cmdNoiCapCMT1.Name = "cmdNoiCapCMT1"
        Me.cmdNoiCapCMT1.Size = New System.Drawing.Size(34, 21)
        Me.cmdNoiCapCMT1.TabIndex = 144
        Me.cmdNoiCapCMT1.Text = "..."
        Me.cmdNoiCapCMT1.UseVisualStyleBackColor = True
        '
        'cmdNoiCapCMT2
        '
        Me.cmdNoiCapCMT2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNoiCapCMT2.Location = New System.Drawing.Point(655, 172)
        Me.cmdNoiCapCMT2.Name = "cmdNoiCapCMT2"
        Me.cmdNoiCapCMT2.Size = New System.Drawing.Size(34, 21)
        Me.cmdNoiCapCMT2.TabIndex = 145
        Me.cmdNoiCapCMT2.Text = "..."
        Me.cmdNoiCapCMT2.UseVisualStyleBackColor = True
        '
        'cmdNoiDangKyHK
        '
        Me.cmdNoiDangKyHK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNoiDangKyHK.Location = New System.Drawing.Point(653, 202)
        Me.cmdNoiDangKyHK.Name = "cmdNoiDangKyHK"
        Me.cmdNoiDangKyHK.Size = New System.Drawing.Size(34, 21)
        Me.cmdNoiDangKyHK.TabIndex = 146
        Me.cmdNoiDangKyHK.Text = "..."
        Me.cmdNoiDangKyHK.UseVisualStyleBackColor = True
        '
        'ctrlChuGDCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Name = "ctrlChuGDCN"
        Me.Size = New System.Drawing.Size(701, 452)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupThaoTac As System.Windows.Forms.GroupBox
    Friend WithEvents chkDaChet As System.Windows.Forms.CheckBox
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
    Friend WithEvents cmbQuocTich2 As System.Windows.Forms.ComboBox
    Friend WithEvents DTPNgayCapCMT2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNoiCapCMT2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSoCMT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents chkDongSoHuu As System.Windows.Forms.CheckBox
    Friend WithEvents RadGiaDinh As System.Windows.Forms.RadioButton
    Friend WithEvents RadCaNhan As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDinhDanh As System.Windows.Forms.ComboBox
    Friend WithEvents cmdNoiCapCMT1 As System.Windows.Forms.Button
    Friend WithEvents cmdNoiDangKyHK As System.Windows.Forms.Button
    Friend WithEvents cmdNoiCapCMT2 As System.Windows.Forms.Button

End Class
