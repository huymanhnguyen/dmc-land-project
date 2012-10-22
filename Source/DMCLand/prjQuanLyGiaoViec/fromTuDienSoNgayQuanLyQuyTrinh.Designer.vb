<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fromTuDienSoNgayQuanLyQuyTrinh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumSoNgayThucThi = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.dtpNgayApDung = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumSoTT = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTenCongViec = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabTenLoaiHS = New System.Windows.Forms.Label
        Me.cmdMauCanhBao = New System.Windows.Forms.Button
        Me.PicMau = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMaMau = New System.Windows.Forms.TextBox
        Me.cboBoPhan = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdDanhSachCongViec = New DMC.[Interface].GridView.ctrlGridView
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        CType(Me.NumSoNgayThucThi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumSoTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicMau, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(832, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SỐ NGÀY QUẢN LÝ QUY TRÌNH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NumSoNgayThucThi
        '
        Me.NumSoNgayThucThi.Location = New System.Drawing.Point(106, 94)
        Me.NumSoNgayThucThi.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumSoNgayThucThi.Name = "NumSoNgayThucThi"
        Me.NumSoNgayThucThi.Size = New System.Drawing.Size(79, 20)
        Me.NumSoNgayThucThi.TabIndex = 7
        Me.NumSoNgayThucThi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumSoNgayThucThi.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Số ngày thực thi"
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(5, 167)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 13
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(64, 167)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 14
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(241, 167)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 17
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(123, 167)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 15
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(182, 167)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 16
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'dtpNgayApDung
        '
        Me.dtpNgayApDung.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayApDung.Location = New System.Drawing.Point(106, 40)
        Me.dtpNgayApDung.Name = "dtpNgayApDung"
        Me.dtpNgayApDung.Size = New System.Drawing.Size(117, 20)
        Me.dtpNgayApDung.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ngày áp dụng"
        '
        'NumSoTT
        '
        Me.NumSoTT.Location = New System.Drawing.Point(363, 42)
        Me.NumSoTT.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumSoTT.Name = "NumSoTT"
        Me.NumSoTT.Size = New System.Drawing.Size(79, 20)
        Me.NumSoTT.TabIndex = 3
        Me.NumSoTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumSoTT.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Thứ tự công việc"
        '
        'txtTenCongViec
        '
        Me.txtTenCongViec.Location = New System.Drawing.Point(106, 68)
        Me.txtTenCongViec.Name = "txtTenCongViec"
        Me.txtTenCongViec.Size = New System.Drawing.Size(351, 20)
        Me.txtTenCongViec.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tên công việc"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(191, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "(Ngày)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.LabTenLoaiHS)
        Me.GroupBox1.Controls.Add(Me.cmdMauCanhBao)
        Me.GroupBox1.Controls.Add(Me.PicMau)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMaMau)
        Me.GroupBox1.Controls.Add(Me.cboBoPhan)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.txtTenCongViec)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Controls.Add(Me.NumSoTT)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCapNhat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpNgayApDung)
        Me.GroupBox1.Controls.Add(Me.NumSoNgayThucThi)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 194)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'LabTenLoaiHS
        '
        Me.LabTenLoaiHS.AutoSize = True
        Me.LabTenLoaiHS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabTenLoaiHS.Location = New System.Drawing.Point(26, 16)
        Me.LabTenLoaiHS.Name = "LabTenLoaiHS"
        Me.LabTenLoaiHS.Size = New System.Drawing.Size(19, 13)
        Me.LabTenLoaiHS.TabIndex = 81
        Me.LabTenLoaiHS.Text = "..."
        '
        'cmdMauCanhBao
        '
        Me.cmdMauCanhBao.Location = New System.Drawing.Point(483, 120)
        Me.cmdMauCanhBao.Name = "cmdMauCanhBao"
        Me.cmdMauCanhBao.Size = New System.Drawing.Size(39, 21)
        Me.cmdMauCanhBao.TabIndex = 12
        Me.cmdMauCanhBao.Text = "<<>>"
        Me.cmdMauCanhBao.UseVisualStyleBackColor = True
        '
        'PicMau
        '
        Me.PicMau.Location = New System.Drawing.Point(448, 120)
        Me.PicMau.Name = "PicMau"
        Me.PicMau.Size = New System.Drawing.Size(30, 20)
        Me.PicMau.TabIndex = 79
        Me.PicMau.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(254, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Màu cảnh báo"
        '
        'txtMaMau
        '
        Me.txtMaMau.BackColor = System.Drawing.Color.Lavender
        Me.txtMaMau.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaMau.Location = New System.Drawing.Point(336, 120)
        Me.txtMaMau.Name = "txtMaMau"
        Me.txtMaMau.ReadOnly = True
        Me.txtMaMau.Size = New System.Drawing.Size(106, 20)
        Me.txtMaMau.TabIndex = 11
        '
        'cboBoPhan
        '
        Me.cboBoPhan.FormattingEnabled = True
        Me.cboBoPhan.Items.AddRange(New Object() {"Văn phòng", "Phòng TNMT", "UB Quận"})
        Me.cboBoPhan.Location = New System.Drawing.Point(106, 120)
        Me.cboBoPhan.Name = "cboBoPhan"
        Me.cboBoPhan.Size = New System.Drawing.Size(108, 21)
        Me.cboBoPhan.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Bộ phận"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grdDanhSachCongViec)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 221)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(827, 223)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'grdDanhSachCongViec
        '
        Me.grdDanhSachCongViec.AllowUserToAddRows = False
        Me.grdDanhSachCongViec.AllowUserToDeleteRows = False
        Me.grdDanhSachCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDanhSachCongViec.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachCongViec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhSachCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachCongViec.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhSachCongViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDanhSachCongViec.Location = New System.Drawing.Point(3, 16)
        Me.grdDanhSachCongViec.Name = "grdDanhSachCongViec"
        Me.grdDanhSachCongViec.ReadOnly = True
        Me.grdDanhSachCongViec.RowHeadersWidth = 25
        Me.grdDanhSachCongViec.Size = New System.Drawing.Size(821, 204)
        Me.grdDanhSachCongViec.TabIndex = 18
        '
        'fromTuDienSoNgayQuanLyQuyTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(832, 451)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fromTuDienSoNgayQuanLyQuyTrinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SO NGAY QUAN LY"
        CType(Me.NumSoNgayThucThi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumSoTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicMau, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumSoNgayThucThi As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents dtpNgayApDung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdDanhSachCongViec As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents NumSoTT As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTenCongViec As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBoPhan As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdMauCanhBao As System.Windows.Forms.Button
    Friend WithEvents PicMau As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMaMau As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents LabTenLoaiHS As System.Windows.Forms.Label
End Class
