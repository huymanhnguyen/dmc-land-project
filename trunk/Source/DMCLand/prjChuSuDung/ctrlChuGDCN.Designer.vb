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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupThaoTac = New System.Windows.Forms.GroupBox
        Me.cmdTImChu = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdChuDuocChon = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
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
        Me.cboDinhDanh = New System.Windows.Forms.ComboBox
        Me.GroupThaoTac.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdChuDuocChon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(295, 178)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 29
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(236, 178)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 28
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(177, 178)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(57, 21)
        Me.btnSua.TabIndex = 27
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(118, 178)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(57, 21)
        Me.btnThem.TabIndex = 26
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(354, 178)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 30
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThaoTac.BackColor = System.Drawing.Color.Lavender
        Me.GroupThaoTac.Controls.Add(Me.cboDinhDanh)
        Me.GroupThaoTac.Controls.Add(Me.cmdTImChu)
        Me.GroupThaoTac.Controls.Add(Me.cmdRemove)
        Me.GroupThaoTac.Controls.Add(Me.cmdAdd)
        Me.GroupThaoTac.Controls.Add(Me.GroupBox2)
        Me.GroupThaoTac.Controls.Add(Me.GroupBox1)
        Me.GroupThaoTac.Controls.Add(Me.btnGhi)
        Me.GroupThaoTac.Controls.Add(Me.chkDaChet)
        Me.GroupThaoTac.Controls.Add(Me.btnXoa)
        Me.GroupThaoTac.Controls.Add(Me.numNamSinh)
        Me.GroupThaoTac.Controls.Add(Me.btnSua)
        Me.GroupThaoTac.Controls.Add(Me.btnThem)
        Me.GroupThaoTac.Controls.Add(Me.cmbQuanHe)
        Me.GroupThaoTac.Controls.Add(Me.btnHuyLenh)
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
        Me.GroupThaoTac.Size = New System.Drawing.Size(843, 524)
        Me.GroupThaoTac.TabIndex = 120
        Me.GroupThaoTac.TabStop = False
        '
        'cmdTImChu
        '
        Me.cmdTImChu.Location = New System.Drawing.Point(417, 178)
        Me.cmdTImChu.Name = "cmdTImChu"
        Me.cmdTImChu.Size = New System.Drawing.Size(57, 21)
        Me.cmdTImChu.TabIndex = 127
        Me.cmdTImChu.Text = "Tìm"
        Me.cmdTImChu.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdRemove.BackgroundImage = Global.prjChuSuDung.My.Resources.Resources.bullet_arrow_top
        Me.cmdRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdRemove.Location = New System.Drawing.Point(396, 394)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(31, 22)
        Me.cmdRemove.TabIndex = 126
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdAdd.BackgroundImage = Global.prjChuSuDung.My.Resources.Resources.bullet_arrow_bottom
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdAdd.Location = New System.Drawing.Point(354, 394)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(31, 22)
        Me.cmdAdd.TabIndex = 125
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grdChuDuocChon)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 413)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(831, 105)
        Me.GroupBox2.TabIndex = 124
        Me.GroupBox2.TabStop = False
        '
        'grdChuDuocChon
        '
        Me.grdChuDuocChon.AllowUserToAddRows = False
        Me.grdChuDuocChon.AllowUserToDeleteRows = False
        Me.grdChuDuocChon.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChuDuocChon.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdChuDuocChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdChuDuocChon.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdChuDuocChon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChuDuocChon.Location = New System.Drawing.Point(3, 16)
        Me.grdChuDuocChon.Name = "grdChuDuocChon"
        Me.grdChuDuocChon.ReadOnly = True
        Me.grdChuDuocChon.RowHeadersWidth = 25
        Me.grdChuDuocChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdChuDuocChon.Size = New System.Drawing.Size(825, 86)
        Me.grdChuDuocChon.TabIndex = 123
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CtrFilterGrid1)
        Me.GroupBox1.Controls.Add(Me.grdvwChu)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 205)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(831, 183)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'CtrFilterGrid1
        '
        Me.CtrFilterGrid1.AutoScroll = True
        Me.CtrFilterGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGrid1.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGrid1.MydataTable = Nothing
        Me.CtrFilterGrid1.MyGrid = Nothing
        Me.CtrFilterGrid1.Name = "CtrFilterGrid1"
        Me.CtrFilterGrid1.Size = New System.Drawing.Size(825, 30)
        Me.CtrFilterGrid1.TabIndex = 25
        '
        'grdvwChu
        '
        Me.grdvwChu.AllowUserToAddRows = False
        Me.grdvwChu.AllowUserToDeleteRows = False
        Me.grdvwChu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChu.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdvwChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChu.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdvwChu.Location = New System.Drawing.Point(3, 52)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(825, 125)
        Me.grdvwChu.TabIndex = 24
        '
        'chkDaChet
        '
        Me.chkDaChet.AutoSize = True
        Me.chkDaChet.Location = New System.Drawing.Point(363, 43)
        Me.chkDaChet.Name = "chkDaChet"
        Me.chkDaChet.Size = New System.Drawing.Size(64, 17)
        Me.chkDaChet.TabIndex = 4
        Me.chkDaChet.Text = "Đã chết"
        Me.chkDaChet.UseVisualStyleBackColor = True
        '
        'numNamSinh
        '
        Me.numNamSinh.Location = New System.Drawing.Point(525, 42)
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
        Me.cmbQuanHe.Location = New System.Drawing.Point(363, 15)
        Me.cmbQuanHe.Name = "cmbQuanHe"
        Me.cmbQuanHe.Size = New System.Drawing.Size(130, 21)
        Me.cmbQuanHe.TabIndex = 2
        '
        'cmbQuocTich
        '
        Me.cmbQuocTich.FormattingEnabled = True
        Me.cmbQuocTich.ItemHeight = 13
        Me.cmbQuocTich.Items.AddRange(New Object() {"", "Việt Nam", "Trung Quốc", "Hàn Quốc", "Nhật Bản", "Nga", "Hoa Kỳ"})
        Me.cmbQuocTich.Location = New System.Drawing.Point(116, 67)
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
        Me.cmbGioiTinh.Location = New System.Drawing.Point(638, 41)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(49, 21)
        Me.cmbGioiTinh.TabIndex = 6
        '
        'DTPNgayCapHK
        '
        Me.DTPNgayCapHK.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapHK.Location = New System.Drawing.Point(312, 122)
        Me.DTPNgayCapHK.Name = "DTPNgayCapHK"
        Me.DTPNgayCapHK.Size = New System.Drawing.Size(100, 20)
        Me.DTPNgayCapHK.TabIndex = 16
        '
        'DTPNgayCapCMT
        '
        Me.DTPNgayCapCMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT.Location = New System.Drawing.Point(116, 95)
        Me.DTPNgayCapCMT.Name = "DTPNgayCapCMT"
        Me.DTPNgayCapCMT.Size = New System.Drawing.Size(119, 20)
        Me.DTPNgayCapCMT.TabIndex = 9
        '
        'txtDiaChiThuongTru
        '
        Me.txtDiaChiThuongTru.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChiThuongTru.Location = New System.Drawing.Point(115, 152)
        Me.txtDiaChiThuongTru.Name = "txtDiaChiThuongTru"
        Me.txtDiaChiThuongTru.Size = New System.Drawing.Size(716, 20)
        Me.txtDiaChiThuongTru.TabIndex = 18
        Me.txtDiaChiThuongTru.Text = "Phường Long Biên, Quận Long Biên, Tp Hà Nội"
        '
        'txtNoiCapHK
        '
        Me.txtNoiCapHK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapHK.Location = New System.Drawing.Point(475, 123)
        Me.txtNoiCapHK.Name = "txtNoiCapHK"
        Me.txtNoiCapHK.Size = New System.Drawing.Size(356, 20)
        Me.txtNoiCapHK.TabIndex = 17
        '
        'txtSoHoKhau
        '
        Me.txtSoHoKhau.Location = New System.Drawing.Point(115, 121)
        Me.txtSoHoKhau.Name = "txtSoHoKhau"
        Me.txtSoHoKhau.Size = New System.Drawing.Size(119, 20)
        Me.txtSoHoKhau.TabIndex = 15
        '
        'txtNoiCapCMT
        '
        Me.txtNoiCapCMT.Location = New System.Drawing.Point(363, 96)
        Me.txtNoiCapCMT.Name = "txtNoiCapCMT"
        Me.txtNoiCapCMT.Size = New System.Drawing.Size(326, 20)
        Me.txtNoiCapCMT.TabIndex = 10
        '
        'txtSoCMT
        '
        Me.txtSoCMT.Location = New System.Drawing.Point(499, 69)
        Me.txtSoCMT.Name = "txtSoCMT"
        Me.txtSoCMT.Size = New System.Drawing.Size(190, 20)
        Me.txtSoCMT.TabIndex = 8
        '
        'txtHoTen
        '
        Me.txtHoTen.Location = New System.Drawing.Point(116, 41)
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
        Me.Label5.Location = New System.Drawing.Point(287, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Số CMT(HC)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(586, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Giới tính"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(259, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "Nơi cấp CMT (HC)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(240, 126)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Ngày cấp HK"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(420, 126)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "Nơi ĐKHK"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(57, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "Quốc tịch"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(45, 124)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 115
        Me.Label19.Text = "Số hộ khẩu"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 154)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Địa chỉ thường trú"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(245, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "Quan hệ ghi trên GCN"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 99)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Ngày cấp CMT (HC)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(465, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Năm sinh"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(71, 44)
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
        'cboDinhDanh
        '
        Me.cboDinhDanh.FormattingEnabled = True
        Me.cboDinhDanh.Items.AddRange(New Object() {"CMND", "CMSQ", "CMQĐ", "Hộ chiếu"})
        Me.cboDinhDanh.Location = New System.Drawing.Point(363, 69)
        Me.cboDinhDanh.Name = "cboDinhDanh"
        Me.cboDinhDanh.Size = New System.Drawing.Size(136, 21)
        Me.cboDinhDanh.TabIndex = 144
        '
        'ctrlChuGDCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Name = "ctrlChuGDCN"
        Me.Size = New System.Drawing.Size(847, 530)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdChuDuocChon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNamSinh, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public WithEvents grdvwChu As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1 As prjFilterGrid.ctrFilterGrid
    Public WithEvents grdChuDuocChon As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdTImChu As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cboDinhDanh As System.Windows.Forms.ComboBox

End Class
