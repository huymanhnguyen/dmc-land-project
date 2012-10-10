<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrQuanLyGiaoViec
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cboTuDienLuanChuyenHoSo = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdSoNgayQUanLy = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.NumNgayCanhBao = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdTongHop = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCanBo = New System.Windows.Forms.TextBox
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdCongViecDaLapLich = New System.Windows.Forms.Button
        Me.grdDanhSachHoSo = New DMC.[Interface].GridView.ctrlGridView
        Me.grdDanhSachCongViec = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumNgayCanhBao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDanhSachHoSo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(894, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LỊCH TRÌNH CÔNG VIỆC CẤP GIẤY CHỨNG NHẬN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCongViecDaLapLich)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.cboTuDienLuanChuyenHoSo)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(894, 563)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Loại hồ sơ quản lý"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.grdDanhSachHoSo)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 37)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(879, 287)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Danh sách hồ sơ "
        '
        'cboTuDienLuanChuyenHoSo
        '
        Me.cboTuDienLuanChuyenHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTuDienLuanChuyenHoSo.FormattingEnabled = True
        Me.cboTuDienLuanChuyenHoSo.Location = New System.Drawing.Point(104, 12)
        Me.cboTuDienLuanChuyenHoSo.Name = "cboTuDienLuanChuyenHoSo"
        Me.cboTuDienLuanChuyenHoSo.Size = New System.Drawing.Size(249, 21)
        Me.cboTuDienLuanChuyenHoSo.TabIndex = 83
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdSoNgayQUanLy)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.NumNgayCanhBao)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmdTongHop)
        Me.GroupBox2.Controls.Add(Me.btnThem)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnCapNhat)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtCanBo)
        Me.GroupBox2.Controls.Add(Me.dtpTuNgay)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 320)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 237)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'cmdSoNgayQUanLy
        '
        Me.cmdSoNgayQUanLy.Location = New System.Drawing.Point(95, 19)
        Me.cmdSoNgayQUanLy.Name = "cmdSoNgayQUanLy"
        Me.cmdSoNgayQUanLy.Size = New System.Drawing.Size(125, 23)
        Me.cmdSoNgayQUanLy.TabIndex = 32
        Me.cmdSoNgayQUanLy.Text = "<< Ngày quản lý >>"
        Me.cmdSoNgayQUanLy.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(195, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "ngày"
        '
        'NumNgayCanhBao
        '
        Me.NumNgayCanhBao.Location = New System.Drawing.Point(95, 100)
        Me.NumNgayCanhBao.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumNgayCanhBao.Name = "NumNgayCanhBao"
        Me.NumNgayCanhBao.Size = New System.Drawing.Size(79, 20)
        Me.NumNgayCanhBao.TabIndex = 30
        Me.NumNgayCanhBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumNgayCanhBao.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Cảnh báo trước"
        '
        'cmdTongHop
        '
        Me.cmdTongHop.Location = New System.Drawing.Point(95, 126)
        Me.cmdTongHop.Name = "cmdTongHop"
        Me.cmdTongHop.Size = New System.Drawing.Size(103, 21)
        Me.cmdTongHop.TabIndex = 28
        Me.cmdTongHop.Text = "Tổng hợp"
        Me.cmdTongHop.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(12, 208)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 21
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(138, 208)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 25
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(74, 208)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 24
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Từ ngày"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cán bộ"
        '
        'txtCanBo
        '
        Me.txtCanBo.Location = New System.Drawing.Point(95, 74)
        Me.txtCanBo.Name = "txtCanBo"
        Me.txtCanBo.Size = New System.Drawing.Size(108, 20)
        Me.txtCanBo.TabIndex = 8
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTuNgay.Location = New System.Drawing.Point(95, 48)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(108, 20)
        Me.dtpTuNgay.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(359, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 21)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Tìm kiếm hồ sơ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grdDanhSachCongViec)
        Me.GroupBox3.Location = New System.Drawing.Point(248, 320)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(640, 237)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdCongViecDaLapLich
        '
        Me.cmdCongViecDaLapLich.Location = New System.Drawing.Point(479, 14)
        Me.cmdCongViecDaLapLich.Name = "cmdCongViecDaLapLich"
        Me.cmdCongViecDaLapLich.Size = New System.Drawing.Size(138, 21)
        Me.cmdCongViecDaLapLich.TabIndex = 85
        Me.cmdCongViecDaLapLich.Text = "Công việc đã giao"
        Me.cmdCongViecDaLapLich.UseVisualStyleBackColor = True
        '
        'grdDanhSachHoSo
        '
        Me.grdDanhSachHoSo.AllowUserToAddRows = False
        Me.grdDanhSachHoSo.AllowUserToDeleteRows = False
        Me.grdDanhSachHoSo.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachHoSo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhSachHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachHoSo.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhSachHoSo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSachHoSo.Location = New System.Drawing.Point(3, 16)
        Me.grdDanhSachHoSo.Name = "grdDanhSachHoSo"
        Me.grdDanhSachHoSo.ReadOnly = True
        Me.grdDanhSachHoSo.RowHeadersWidth = 25
        Me.grdDanhSachHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDanhSachHoSo.Size = New System.Drawing.Size(873, 268)
        Me.grdDanhSachHoSo.TabIndex = 0
        '
        'grdDanhSachCongViec
        '
        Me.grdDanhSachCongViec.AllowUserToAddRows = False
        Me.grdDanhSachCongViec.AllowUserToDeleteRows = False
        Me.grdDanhSachCongViec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhSachCongViec.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachCongViec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdDanhSachCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachCongViec.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdDanhSachCongViec.Location = New System.Drawing.Point(3, 10)
        Me.grdDanhSachCongViec.Name = "grdDanhSachCongViec"
        Me.grdDanhSachCongViec.ReadOnly = True
        Me.grdDanhSachCongViec.RowHeadersWidth = 25
        Me.grdDanhSachCongViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDanhSachCongViec.Size = New System.Drawing.Size(634, 220)
        Me.grdDanhSachCongViec.TabIndex = 1
        '
        'ctrQuanLyGiaoViec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ctrQuanLyGiaoViec"
        Me.Size = New System.Drawing.Size(894, 585)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumNgayCanhBao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdDanhSachHoSo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhSachHoSo As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhSachCongViec As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCanBo As System.Windows.Forms.TextBox
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents cmdTongHop As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NumNgayCanhBao As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSoNgayQUanLy As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTuDienLuanChuyenHoSo As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCongViecDaLapLich As System.Windows.Forms.Button

End Class
