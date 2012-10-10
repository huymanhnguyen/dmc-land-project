Imports DMC.Interface.GridView
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlHoiDongXetDuyet
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
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.cmbGioiTinh = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.btnQuyetDinhThanhLapHoiDong = New System.Windows.Forms.Button
        Me.txtChucDanh = New System.Windows.Forms.TextBox
        Me.txtChucVu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdLayLai = New System.Windows.Forms.Button
        Me.cmdXuong = New System.Windows.Forms.Button
        Me.cmdLen = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        Me.grdvwHoiDongXetDuyet = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdvwHoiDongXetDuyet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Chức danh"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(141, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "Họ và tên"
        '
        'txtHoTen
        '
        Me.txtHoTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHoTen.Location = New System.Drawing.Point(205, 15)
        Me.txtHoTen.Multiline = True
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(530, 20)
        Me.txtHoTen.TabIndex = 2
        '
        'cmbGioiTinh
        '
        Me.cmbGioiTinh.FormattingEnabled = True
        Me.cmbGioiTinh.Items.AddRange(New Object() {"Ông", "Bà"})
        Me.cmbGioiTinh.Location = New System.Drawing.Point(70, 15)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(58, 21)
        Me.cmbGioiTinh.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Ông (Bà)"
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(183, 11)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 29)
        Me.btnHuyLenh.TabIndex = 9
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(65, 11)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 29)
        Me.btnXoa.TabIndex = 7
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(124, 11)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 29)
        Me.btnCapNhat.TabIndex = 8
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(6, 11)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(58, 29)
        Me.btnTraCuu.TabIndex = 6
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'btnQuyetDinhThanhLapHoiDong
        '
        Me.btnQuyetDinhThanhLapHoiDong.Location = New System.Drawing.Point(244, 11)
        Me.btnQuyetDinhThanhLapHoiDong.Name = "btnQuyetDinhThanhLapHoiDong"
        Me.btnQuyetDinhThanhLapHoiDong.Size = New System.Drawing.Size(138, 29)
        Me.btnQuyetDinhThanhLapHoiDong.TabIndex = 10
        Me.btnQuyetDinhThanhLapHoiDong.Text = "Quyết định thành lập HĐ"
        Me.btnQuyetDinhThanhLapHoiDong.UseVisualStyleBackColor = True
        '
        'txtChucDanh
        '
        Me.txtChucDanh.Location = New System.Drawing.Point(70, 46)
        Me.txtChucDanh.Name = "txtChucDanh"
        Me.txtChucDanh.Size = New System.Drawing.Size(256, 20)
        Me.txtChucDanh.TabIndex = 3
        '
        'txtChucVu
        '
        Me.txtChucVu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChucVu.Location = New System.Drawing.Point(401, 46)
        Me.txtChucVu.Name = "txtChucVu"
        Me.txtChucVu.Size = New System.Drawing.Size(334, 20)
        Me.txtChucVu.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(348, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Chức vụ"
        '
        'cmdLayLai
        '
        Me.cmdLayLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLayLai.Location = New System.Drawing.Point(635, 11)
        Me.cmdLayLai.Name = "cmdLayLai"
        Me.cmdLayLai.Size = New System.Drawing.Size(95, 30)
        Me.cmdLayLai.TabIndex = 76
        Me.cmdLayLai.Text = "Tạo từ điển"
        Me.cmdLayLai.UseVisualStyleBackColor = True
        '
        'cmdXuong
        '
        Me.cmdXuong.BackgroundImage = Global.DMC.Land.HoiDongXetDuyet.My.Resources.Resources.Down
        Me.cmdXuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdXuong.Location = New System.Drawing.Point(415, 11)
        Me.cmdXuong.Name = "cmdXuong"
        Me.cmdXuong.Size = New System.Drawing.Size(28, 30)
        Me.cmdXuong.TabIndex = 75
        Me.cmdXuong.UseVisualStyleBackColor = True
        '
        'cmdLen
        '
        Me.cmdLen.BackgroundImage = Global.DMC.Land.HoiDongXetDuyet.My.Resources.Resources.up
        Me.cmdLen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdLen.Location = New System.Drawing.Point(387, 11)
        Me.cmdLen.Name = "cmdLen"
        Me.cmdLen.Size = New System.Drawing.Size(28, 30)
        Me.cmdLen.TabIndex = 74
        Me.cmdLen.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdXuong)
        Me.GroupBox1.Controls.Add(Me.cmdLayLai)
        Me.GroupBox1.Controls.Add(Me.cmdLen)
        Me.GroupBox1.Controls.Add(Me.btnQuyetDinhThanhLapHoiDong)
        Me.GroupBox1.Controls.Add(Me.btnTraCuu)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnCapNhat)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 405)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 47)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrFilterGrid1)
        Me.GroupBox2.Controls.Add(Me.txtChucVu)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtChucDanh)
        Me.GroupBox2.Controls.Add(Me.grdvwHoiDongXetDuyet)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtHoTen)
        Me.GroupBox2.Controls.Add(Me.cmbGioiTinh)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(741, 399)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        '
        'CtrFilterGrid1
        '
        Me.CtrFilterGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrFilterGrid1.AutoScroll = True
        Me.CtrFilterGrid1.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid1.Location = New System.Drawing.Point(8, 77)
        Me.CtrFilterGrid1.MydataTable = Nothing
        Me.CtrFilterGrid1.MyGrid = Nothing
        Me.CtrFilterGrid1.Name = "CtrFilterGrid1"
        Me.CtrFilterGrid1.Size = New System.Drawing.Size(724, 57)
        Me.CtrFilterGrid1.TabIndex = 74
        '
        'grdvwHoiDongXetDuyet
        '
        Me.grdvwHoiDongXetDuyet.AllowUserToAddRows = False
        Me.grdvwHoiDongXetDuyet.AllowUserToDeleteRows = False
        Me.grdvwHoiDongXetDuyet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwHoiDongXetDuyet.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwHoiDongXetDuyet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwHoiDongXetDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwHoiDongXetDuyet.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwHoiDongXetDuyet.Location = New System.Drawing.Point(6, 144)
        Me.grdvwHoiDongXetDuyet.Name = "grdvwHoiDongXetDuyet"
        Me.grdvwHoiDongXetDuyet.ReadOnly = True
        Me.grdvwHoiDongXetDuyet.RowHeadersWidth = 25
        Me.grdvwHoiDongXetDuyet.Size = New System.Drawing.Size(726, 249)
        Me.grdvwHoiDongXetDuyet.TabIndex = 5
        '
        'ctrlHoiDongXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlHoiDongXetDuyet"
        Me.Size = New System.Drawing.Size(746, 469)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdvwHoiDongXetDuyet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents cmbGioiTinh As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents btnQuyetDinhThanhLapHoiDong As System.Windows.Forms.Button
    Friend WithEvents grdvwHoiDongXetDuyet As ctrlGridView
    Public WithEvents txtChucDanh As System.Windows.Forms.TextBox
    Public WithEvents txtChucVu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1 As prjFilterGrid.ctrFilterGrid
    Public WithEvents cmdLen As System.Windows.Forms.Button
    Public WithEvents cmdXuong As System.Windows.Forms.Button
    Public WithEvents cmdLayLai As System.Windows.Forms.Button

End Class
