<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlChuTCDN
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
        Me.GroupThaoTac = New System.Windows.Forms.GroupBox
        Me.chkDongSoHuu = New System.Windows.Forms.CheckBox
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
        Me.btnMaDoiTuong = New System.Windows.Forms.Button
        Me.chkChuRungCay = New System.Windows.Forms.CheckBox
        Me.chkChuCongTrinhXayDung = New System.Windows.Forms.CheckBox
        Me.chkChuNhaO = New System.Windows.Forms.CheckBox
        Me.chkChuDat = New System.Windows.Forms.CheckBox
        Me.chkChuCayLauNam = New System.Windows.Forms.CheckBox
        Me.DTPNgayCap = New System.Windows.Forms.DateTimePicker
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.txtNoiCap = New System.Windows.Forms.TextBox
        Me.txtSoDinhDanh = New System.Windows.Forms.TextBox
        Me.txtTen = New System.Windows.Forms.TextBox
        Me.txtMaDoiTuong = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupThaoTac.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(247, 12)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 24
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(189, 12)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 23
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(131, 12)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(57, 21)
        Me.btnSua.TabIndex = 22
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(73, 12)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(57, 21)
        Me.btnThem.TabIndex = 21
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThaoTac.Controls.Add(Me.chkDongSoHuu)
        Me.GroupThaoTac.Controls.Add(Me.grdvwChu)
        Me.GroupThaoTac.Controls.Add(Me.btnMaDoiTuong)
        Me.GroupThaoTac.Controls.Add(Me.chkChuRungCay)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCongTrinhXayDung)
        Me.GroupThaoTac.Controls.Add(Me.chkChuNhaO)
        Me.GroupThaoTac.Controls.Add(Me.chkChuDat)
        Me.GroupThaoTac.Controls.Add(Me.chkChuCayLauNam)
        Me.GroupThaoTac.Controls.Add(Me.DTPNgayCap)
        Me.GroupThaoTac.Controls.Add(Me.txtDiaChi)
        Me.GroupThaoTac.Controls.Add(Me.txtNoiCap)
        Me.GroupThaoTac.Controls.Add(Me.txtSoDinhDanh)
        Me.GroupThaoTac.Controls.Add(Me.txtTen)
        Me.GroupThaoTac.Controls.Add(Me.txtMaDoiTuong)
        Me.GroupThaoTac.Controls.Add(Me.Label1)
        Me.GroupThaoTac.Controls.Add(Me.Label2)
        Me.GroupThaoTac.Controls.Add(Me.Label3)
        Me.GroupThaoTac.Controls.Add(Me.Label4)
        Me.GroupThaoTac.Controls.Add(Me.Label5)
        Me.GroupThaoTac.Controls.Add(Me.Label6)
        Me.GroupThaoTac.Location = New System.Drawing.Point(2, 2)
        Me.GroupThaoTac.Name = "GroupThaoTac"
        Me.GroupThaoTac.Size = New System.Drawing.Size(678, 306)
        Me.GroupThaoTac.TabIndex = 125
        Me.GroupThaoTac.TabStop = False
        '
        'chkDongSoHuu
        '
        Me.chkDongSoHuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDongSoHuu.AutoSize = True
        Me.chkDongSoHuu.Location = New System.Drawing.Point(575, 17)
        Me.chkDongSoHuu.Name = "chkDongSoHuu"
        Me.chkDongSoHuu.Size = New System.Drawing.Size(87, 17)
        Me.chkDongSoHuu.TabIndex = 5
        Me.chkDongSoHuu.Text = "Đồng sở hữu"
        Me.chkDongSoHuu.UseVisualStyleBackColor = True
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
        Me.grdvwChu.Location = New System.Drawing.Point(9, 143)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(662, 157)
        Me.grdvwChu.TabIndex = 19
        '
        'btnMaDoiTuong
        '
        Me.btnMaDoiTuong.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMaDoiTuong.Location = New System.Drawing.Point(233, 13)
        Me.btnMaDoiTuong.Name = "btnMaDoiTuong"
        Me.btnMaDoiTuong.Size = New System.Drawing.Size(24, 21)
        Me.btnMaDoiTuong.TabIndex = 2
        Me.btnMaDoiTuong.Text = "..."
        Me.btnMaDoiTuong.UseVisualStyleBackColor = True
        '
        'chkChuRungCay
        '
        Me.chkChuRungCay.AutoSize = True
        Me.chkChuRungCay.Location = New System.Drawing.Point(466, 123)
        Me.chkChuRungCay.Name = "chkChuRungCay"
        Me.chkChuRungCay.Size = New System.Drawing.Size(94, 17)
        Me.chkChuRungCay.TabIndex = 17
        Me.chkChuRungCay.Text = "Chủ Rừng cây"
        Me.chkChuRungCay.UseVisualStyleBackColor = True
        '
        'chkChuCongTrinhXayDung
        '
        Me.chkChuCongTrinhXayDung.AutoSize = True
        Me.chkChuCongTrinhXayDung.Location = New System.Drawing.Point(322, 123)
        Me.chkChuCongTrinhXayDung.Name = "chkChuCongTrinhXayDung"
        Me.chkChuCongTrinhXayDung.Size = New System.Drawing.Size(142, 17)
        Me.chkChuCongTrinhXayDung.TabIndex = 16
        Me.chkChuCongTrinhXayDung.Text = "Chủ Công trình xây dựng"
        Me.chkChuCongTrinhXayDung.UseVisualStyleBackColor = True
        '
        'chkChuNhaO
        '
        Me.chkChuNhaO.AutoSize = True
        Me.chkChuNhaO.Location = New System.Drawing.Point(194, 123)
        Me.chkChuNhaO.Name = "chkChuNhaO"
        Me.chkChuNhaO.Size = New System.Drawing.Size(120, 17)
        Me.chkChuNhaO.TabIndex = 15
        Me.chkChuNhaO.Text = "Chủ Nhà ở (Căn hộ)"
        Me.chkChuNhaO.UseVisualStyleBackColor = True
        '
        'chkChuDat
        '
        Me.chkChuDat.AutoSize = True
        Me.chkChuDat.Location = New System.Drawing.Point(122, 123)
        Me.chkChuDat.Name = "chkChuDat"
        Me.chkChuDat.Size = New System.Drawing.Size(65, 17)
        Me.chkChuDat.TabIndex = 14
        Me.chkChuDat.Text = "Chủ Đất"
        Me.chkChuDat.UseVisualStyleBackColor = True
        '
        'chkChuCayLauNam
        '
        Me.chkChuCayLauNam.AutoSize = True
        Me.chkChuCayLauNam.Location = New System.Drawing.Point(563, 123)
        Me.chkChuCayLauNam.Name = "chkChuCayLauNam"
        Me.chkChuCayLauNam.Size = New System.Drawing.Size(106, 17)
        Me.chkChuCayLauNam.TabIndex = 18
        Me.chkChuCayLauNam.Text = "Chủ Cây lâu năm"
        Me.chkChuCayLauNam.UseVisualStyleBackColor = True
        '
        'DTPNgayCap
        '
        Me.DTPNgayCap.Location = New System.Drawing.Point(292, 43)
        Me.DTPNgayCap.Name = "DTPNgayCap"
        Me.DTPNgayCap.Size = New System.Drawing.Size(104, 20)
        Me.DTPNgayCap.TabIndex = 9
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChi.Location = New System.Drawing.Point(120, 97)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(549, 20)
        Me.txtDiaChi.TabIndex = 13
        Me.txtDiaChi.Text = "Phường Long Biên, Quận Long Biên, Tp Hà Nội"
        '
        'txtNoiCap
        '
        Me.txtNoiCap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCap.Location = New System.Drawing.Point(120, 70)
        Me.txtNoiCap.Name = "txtNoiCap"
        Me.txtNoiCap.Size = New System.Drawing.Size(549, 20)
        Me.txtNoiCap.TabIndex = 11
        '
        'txtSoDinhDanh
        '
        Me.txtSoDinhDanh.Location = New System.Drawing.Point(120, 44)
        Me.txtSoDinhDanh.Name = "txtSoDinhDanh"
        Me.txtSoDinhDanh.Size = New System.Drawing.Size(110, 20)
        Me.txtSoDinhDanh.TabIndex = 7
        '
        'txtTen
        '
        Me.txtTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen.Location = New System.Drawing.Point(292, 14)
        Me.txtTen.Multiline = True
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(268, 20)
        Me.txtTen.TabIndex = 4
        '
        'txtMaDoiTuong
        '
        Me.txtMaDoiTuong.Location = New System.Drawing.Point(120, 14)
        Me.txtMaDoiTuong.Name = "txtMaDoiTuong"
        Me.txtMaDoiTuong.Size = New System.Drawing.Size(110, 20)
        Me.txtMaDoiTuong.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Địa chỉ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Nơi cấp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ngày cấp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Giấy phép đăng ký số"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tên"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Mã đối tượng"
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(14, 12)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(57, 21)
        Me.btnTraCuu.TabIndex = 20
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(307, 12)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 25
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnGhi)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.btnTraCuu)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 40)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        '
        'ctrlChuTCDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Name = "ctrlChuTCDN"
        Me.Size = New System.Drawing.Size(684, 348)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents GroupThaoTac As System.Windows.Forms.GroupBox
    Friend WithEvents DTPNgayCap As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents txtNoiCap As System.Windows.Forms.TextBox
    Friend WithEvents txtSoDinhDanh As System.Windows.Forms.TextBox
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents txtMaDoiTuong As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents chkChuRungCay As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuCongTrinhXayDung As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuNhaO As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuDat As System.Windows.Forms.CheckBox
    Friend WithEvents chkChuCayLauNam As System.Windows.Forms.CheckBox
    Friend WithEvents btnMaDoiTuong As System.Windows.Forms.Button
    Friend WithEvents grdvwChu As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents chkDongSoHuu As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
