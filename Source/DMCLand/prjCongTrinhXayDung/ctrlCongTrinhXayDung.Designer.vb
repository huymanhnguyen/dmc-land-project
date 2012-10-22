<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlCongTrinhXayDung
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdvw = New DMC.[Interface].GridView.ctrlGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkHinhThanhTrongTuongLai = New System.Windows.Forms.CheckBox
        Me.numDienTichXayDung = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNguonGoc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMoTa = New System.Windows.Forms.TextBox
        Me.DTPThoiDiemHinhThanh = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTen = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtGiayPhep = New System.Windows.Forms.TextBox
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnHangMucCongTrinh = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDienTichXayDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox1.Controls.Add(Me.grdvw)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkHinhThanhTrongTuongLai)
        Me.GroupBox1.Controls.Add(Me.numDienTichXayDung)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNguonGoc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMoTa)
        Me.GroupBox1.Controls.Add(Me.DTPThoiDiemHinhThanh)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtGiayPhep)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 254)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Công trình xây dựng"
        '
        'grdvw
        '
        Me.grdvw.AllowUserToAddRows = False
        Me.grdvw.AllowUserToDeleteRows = False
        Me.grdvw.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvw.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvw.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvw.Location = New System.Drawing.Point(7, 155)
        Me.grdvw.Name = "grdvw"
        Me.grdvw.ReadOnly = True
        Me.grdvw.RowHeadersWidth = 25
        Me.grdvw.Size = New System.Drawing.Size(675, 96)
        Me.grdvw.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(45, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Diện tích (m2)"
        '
        'chkHinhThanhTrongTuongLai
        '
        Me.chkHinhThanhTrongTuongLai.AutoSize = True
        Me.chkHinhThanhTrongTuongLai.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHinhThanhTrongTuongLai.Location = New System.Drawing.Point(279, 129)
        Me.chkHinhThanhTrongTuongLai.Name = "chkHinhThanhTrongTuongLai"
        Me.chkHinhThanhTrongTuongLai.Size = New System.Drawing.Size(152, 17)
        Me.chkHinhThanhTrongTuongLai.TabIndex = 10
        Me.chkHinhThanhTrongTuongLai.Text = "Hoàn thành trong tương lai"
        Me.chkHinhThanhTrongTuongLai.UseVisualStyleBackColor = True
        '
        'numDienTichXayDung
        '
        Me.numDienTichXayDung.DecimalPlaces = 2
        Me.numDienTichXayDung.Location = New System.Drawing.Point(125, 126)
        Me.numDienTichXayDung.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numDienTichXayDung.Name = "numDienTichXayDung"
        Me.numDienTichXayDung.Size = New System.Drawing.Size(100, 20)
        Me.numDienTichXayDung.TabIndex = 9
        Me.numDienTichXayDung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(59, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nguồn gốc"
        '
        'txtNguonGoc
        '
        Me.txtNguonGoc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNguonGoc.Location = New System.Drawing.Point(125, 97)
        Me.txtNguonGoc.Name = "txtNguonGoc"
        Me.txtNguonGoc.Size = New System.Drawing.Size(557, 20)
        Me.txtNguonGoc.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(85, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Mô tả"
        '
        'txtMoTa
        '
        Me.txtMoTa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMoTa.Location = New System.Drawing.Point(125, 71)
        Me.txtMoTa.Name = "txtMoTa"
        Me.txtMoTa.Size = New System.Drawing.Size(557, 20)
        Me.txtMoTa.TabIndex = 5
        '
        'DTPThoiDiemHinhThanh
        '
        Me.DTPThoiDiemHinhThanh.Location = New System.Drawing.Point(569, 126)
        Me.DTPThoiDiemHinhThanh.Name = "DTPThoiDiemHinhThanh"
        Me.DTPThoiDiemHinhThanh.Size = New System.Drawing.Size(113, 20)
        Me.DTPThoiDiemHinhThanh.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(43, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tên công trình"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(456, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Thời điểm hình thành"
        '
        'txtTen
        '
        Me.txtTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen.Location = New System.Drawing.Point(125, 45)
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(557, 20)
        Me.txtTen.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Giấy phép đầu tư (XD)"
        '
        'txtGiayPhep
        '
        Me.txtGiayPhep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGiayPhep.Location = New System.Drawing.Point(125, 19)
        Me.txtGiayPhep.Name = "txtGiayPhep"
        Me.txtGiayPhep.Size = New System.Drawing.Size(557, 20)
        Me.txtGiayPhep.TabIndex = 1
        '
        'btnThem
        '
        Me.btnThem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnThem.Location = New System.Drawing.Point(6, 15)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 13
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTroGiup.Location = New System.Drawing.Point(624, 15)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 19
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHuyLenh.Location = New System.Drawing.Point(247, 15)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 17
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSua.Location = New System.Drawing.Point(67, 15)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 14
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnXoa.Location = New System.Drawing.Point(127, 15)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 15
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCapNhat.Location = New System.Drawing.Point(187, 15)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 16
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnHangMucCongTrinh
        '
        Me.btnHangMucCongTrinh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnHangMucCongTrinh.Location = New System.Drawing.Point(308, 15)
        Me.btnHangMucCongTrinh.Name = "btnHangMucCongTrinh"
        Me.btnHangMucCongTrinh.Size = New System.Drawing.Size(136, 21)
        Me.btnHangMucCongTrinh.TabIndex = 18
        Me.btnHangMucCongTrinh.Text = "Hạng mục công trình"
        Me.btnHangMucCongTrinh.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHangMucCongTrinh)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnThem)
        Me.GroupBox2.Controls.Add(Me.btnCapNhat)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnTroGiup)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 42)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'ctrlCongTrinhXayDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlCongTrinhXayDung"
        Me.Size = New System.Drawing.Size(694, 305)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDienTichXayDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPThoiDiemHinhThanh As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtGiayPhep As System.Windows.Forms.TextBox
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMoTa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNguonGoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkHinhThanhTrongTuongLai As System.Windows.Forms.CheckBox
    Friend WithEvents numDienTichXayDung As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnHangMucCongTrinh As System.Windows.Forms.Button
    Friend WithEvents grdvw As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
