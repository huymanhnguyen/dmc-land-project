<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienHDXD
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
        Me.txtChucVu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtChucDanh = New System.Windows.Forms.TextBox
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.cmbGioiTinh = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.cmdXuong = New System.Windows.Forms.Button
        Me.cmdLen = New System.Windows.Forms.Button
        Me.cmdChuyen = New System.Windows.Forms.Button
        Me.grdvwHoiDongXetDuyet = New DMC.[Interface].GridView.ctrlGridView
        Me.ctrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        CType(Me.grdvwHoiDongXetDuyet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtChucVu
        '
        Me.txtChucVu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChucVu.Location = New System.Drawing.Point(400, 37)
        Me.txtChucVu.Name = "txtChucVu"
        Me.txtChucVu.Size = New System.Drawing.Size(282, 20)
        Me.txtChucVu.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Chức vụ"
        '
        'txtChucDanh
        '
        Me.txtChucDanh.Location = New System.Drawing.Point(69, 37)
        Me.txtChucDanh.Name = "txtChucDanh"
        Me.txtChucDanh.Size = New System.Drawing.Size(256, 20)
        Me.txtChucDanh.TabIndex = 79
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(7, 326)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(58, 21)
        Me.btnTraCuu.TabIndex = 82
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 89
        Me.Label15.Text = "Chức danh"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(140, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Họ và tên"
        '
        'txtHoTen
        '
        Me.txtHoTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHoTen.Location = New System.Drawing.Point(204, 6)
        Me.txtHoTen.Multiline = True
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(478, 20)
        Me.txtHoTen.TabIndex = 78
        '
        'cmbGioiTinh
        '
        Me.cmbGioiTinh.FormattingEnabled = True
        Me.cmbGioiTinh.Items.AddRange(New Object() {"Ông", "Bà"})
        Me.cmbGioiTinh.Location = New System.Drawing.Point(69, 6)
        Me.cmbGioiTinh.Name = "cmbGioiTinh"
        Me.cmbGioiTinh.Size = New System.Drawing.Size(58, 21)
        Me.cmbGioiTinh.TabIndex = 77
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Ông (Bà)"
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHuyLenh.Location = New System.Drawing.Point(184, 326)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 85
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnXoa.Location = New System.Drawing.Point(66, 326)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 83
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCapNhat.Location = New System.Drawing.Point(125, 326)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 84
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'cmdXuong
        '
        Me.cmdXuong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdXuong.BackgroundImage = Global.DMC.Land.HoiDongXetDuyet.My.Resources.Resources.Down
        Me.cmdXuong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdXuong.Location = New System.Drawing.Point(276, 326)
        Me.cmdXuong.Name = "cmdXuong"
        Me.cmdXuong.Size = New System.Drawing.Size(28, 22)
        Me.cmdXuong.TabIndex = 92
        Me.cmdXuong.UseVisualStyleBackColor = True
        '
        'cmdLen
        '
        Me.cmdLen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLen.BackgroundImage = Global.DMC.Land.HoiDongXetDuyet.My.Resources.Resources.up
        Me.cmdLen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdLen.Location = New System.Drawing.Point(248, 326)
        Me.cmdLen.Name = "cmdLen"
        Me.cmdLen.Size = New System.Drawing.Size(28, 22)
        Me.cmdLen.TabIndex = 91
        Me.cmdLen.UseVisualStyleBackColor = True
        '
        'cmdChuyen
        '
        Me.cmdChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChuyen.Location = New System.Drawing.Point(585, 328)
        Me.cmdChuyen.Name = "cmdChuyen"
        Me.cmdChuyen.Size = New System.Drawing.Size(95, 21)
        Me.cmdChuyen.TabIndex = 93
        Me.cmdChuyen.Text = "Chuyển xuống"
        Me.cmdChuyen.UseVisualStyleBackColor = True
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
        Me.grdvwHoiDongXetDuyet.Location = New System.Drawing.Point(6, 138)
        Me.grdvwHoiDongXetDuyet.Name = "grdvwHoiDongXetDuyet"
        Me.grdvwHoiDongXetDuyet.ReadOnly = True
        Me.grdvwHoiDongXetDuyet.RowHeadersWidth = 25
        Me.grdvwHoiDongXetDuyet.Size = New System.Drawing.Size(674, 182)
        Me.grdvwHoiDongXetDuyet.TabIndex = 81
        '
        'ctrFilterGrid1
        '
        Me.ctrFilterGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctrFilterGrid1.AutoScroll = True
        Me.ctrFilterGrid1.BackColor = System.Drawing.Color.Lavender
        Me.ctrFilterGrid1.Location = New System.Drawing.Point(7, 63)
        Me.ctrFilterGrid1.MydataTable = Nothing
        Me.ctrFilterGrid1.MyGrid = Nothing
        Me.ctrFilterGrid1.Name = "ctrFilterGrid1"
        Me.ctrFilterGrid1.Size = New System.Drawing.Size(675, 69)
        Me.ctrFilterGrid1.TabIndex = 125
        '
        'frmTuDienHDXD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(692, 359)
        Me.Controls.Add(Me.ctrFilterGrid1)
        Me.Controls.Add(Me.cmdChuyen)
        Me.Controls.Add(Me.cmdXuong)
        Me.Controls.Add(Me.cmdLen)
        Me.Controls.Add(Me.txtChucVu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtChucDanh)
        Me.Controls.Add(Me.grdvwHoiDongXetDuyet)
        Me.Controls.Add(Me.btnTraCuu)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtHoTen)
        Me.Controls.Add(Me.cmbGioiTinh)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Name = "frmTuDienHDXD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Từ điển hội đồng xét duyệt"
        CType(Me.grdvwHoiDongXetDuyet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdXuong As System.Windows.Forms.Button
    Friend WithEvents cmdLen As System.Windows.Forms.Button
    Public WithEvents txtChucVu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtChucDanh As System.Windows.Forms.TextBox
    Friend WithEvents grdvwHoiDongXetDuyet As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents cmbGioiTinh As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents cmdChuyen As System.Windows.Forms.Button
    Private WithEvents ctrFilterGrid1 As prjFilterGrid.ctrFilterGrid
End Class
