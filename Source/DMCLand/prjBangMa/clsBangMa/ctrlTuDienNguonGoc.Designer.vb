<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTuDienNguonGoc
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
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.grdvwBangMa = New DMC.[Interface].GridView.ctrlGridView
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBangMaMoTa = New System.Windows.Forms.TextBox
        Me.txtBangMaKyHieu = New System.Windows.Forms.TextBox
        CType(Me.grdvwBangMa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(243, 294)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(62, 21)
        Me.btnHuyLenh.TabIndex = 53
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(63, 292)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 52
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'grdvwBangMa
        '
        Me.grdvwBangMa.AllowUserToAddRows = False
        Me.grdvwBangMa.AllowUserToDeleteRows = False
        Me.grdvwBangMa.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwBangMa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwBangMa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwBangMa.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwBangMa.Location = New System.Drawing.Point(3, 3)
        Me.grdvwBangMa.MultiSelect = False
        Me.grdvwBangMa.Name = "grdvwBangMa"
        Me.grdvwBangMa.ReadOnly = True
        Me.grdvwBangMa.RowHeadersVisible = False
        Me.grdvwBangMa.RowHeadersWidth = 25
        Me.grdvwBangMa.Size = New System.Drawing.Size(563, 165)
        Me.grdvwBangMa.TabIndex = 51
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(181, 292)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 47
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(123, 292)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 48
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(3, 292)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 46
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Mô tả"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Tên:"
        '
        'txtBangMaMoTa
        '
        Me.txtBangMaMoTa.Location = New System.Drawing.Point(4, 244)
        Me.txtBangMaMoTa.Multiline = True
        Me.txtBangMaMoTa.Name = "txtBangMaMoTa"
        Me.txtBangMaMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBangMaMoTa.Size = New System.Drawing.Size(564, 45)
        Me.txtBangMaMoTa.TabIndex = 45
        '
        'txtBangMaKyHieu
        '
        Me.txtBangMaKyHieu.Location = New System.Drawing.Point(5, 186)
        Me.txtBangMaKyHieu.Multiline = True
        Me.txtBangMaKyHieu.Name = "txtBangMaKyHieu"
        Me.txtBangMaKyHieu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBangMaKyHieu.Size = New System.Drawing.Size(564, 39)
        Me.txtBangMaKyHieu.TabIndex = 44
        '
        'ctrlTuDienNguonGoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.grdvwBangMa)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBangMaMoTa)
        Me.Controls.Add(Me.txtBangMaKyHieu)
        Me.Name = "ctrlTuDienNguonGoc"
        Me.Size = New System.Drawing.Size(574, 316)
        CType(Me.grdvwBangMa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents grdvwBangMa As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBangMaMoTa As System.Windows.Forms.TextBox
    Friend WithEvents txtBangMaKyHieu As System.Windows.Forms.TextBox

End Class
