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
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
        Me.btnMaDoiTuong = New System.Windows.Forms.Button
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
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupThaoTac.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(178, 313)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 18
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(120, 313)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(57, 21)
        Me.btnXoa.TabIndex = 17
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(62, 313)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(57, 21)
        Me.btnSua.TabIndex = 16
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(4, 313)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(57, 21)
        Me.btnThem.TabIndex = 15
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThaoTac.Controls.Add(Me.grdvwChu)
        Me.GroupThaoTac.Controls.Add(Me.btnMaDoiTuong)
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
        Me.grdvwChu.Location = New System.Drawing.Point(9, 123)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(662, 177)
        Me.grdvwChu.TabIndex = 13
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
        'DTPNgayCap
        '
        Me.DTPNgayCap.Location = New System.Drawing.Point(292, 43)
        Me.DTPNgayCap.Name = "DTPNgayCap"
        Me.DTPNgayCap.Size = New System.Drawing.Size(104, 20)
        Me.DTPNgayCap.TabIndex = 5
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChi.Location = New System.Drawing.Point(120, 97)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(549, 20)
        Me.txtDiaChi.TabIndex = 7
        Me.txtDiaChi.Text = "Phường Long Biên, Quận Long Biên, Tp Hà Nội"
        '
        'txtNoiCap
        '
        Me.txtNoiCap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCap.Location = New System.Drawing.Point(120, 70)
        Me.txtNoiCap.Name = "txtNoiCap"
        Me.txtNoiCap.Size = New System.Drawing.Size(549, 20)
        Me.txtNoiCap.TabIndex = 6
        '
        'txtSoDinhDanh
        '
        Me.txtSoDinhDanh.Location = New System.Drawing.Point(120, 44)
        Me.txtSoDinhDanh.Name = "txtSoDinhDanh"
        Me.txtSoDinhDanh.Size = New System.Drawing.Size(110, 20)
        Me.txtSoDinhDanh.TabIndex = 4
        '
        'txtTen
        '
        Me.txtTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen.Location = New System.Drawing.Point(292, 14)
        Me.txtTen.Multiline = True
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(268, 20)
        Me.txtTen.TabIndex = 3
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
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Địa chỉ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nơi cấp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ngày cấp"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Giấy phép đăng ký số"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Tên"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Mã đối tượng"
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(238, 313)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(57, 21)
        Me.btnHuyLenh.TabIndex = 19
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'ctrlChuTCDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Name = "ctrlChuTCDN"
        Me.Size = New System.Drawing.Size(684, 337)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnMaDoiTuong As System.Windows.Forms.Button
    Public WithEvents grdvwChu As DMC.Interface.GridView.ctrlGridView

End Class
