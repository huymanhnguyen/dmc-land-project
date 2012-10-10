Imports DMC.Interface.GridView
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTaiLieuKemTheoSQL
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
        Me.btnTaiVe = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTenTepDuLieuNguon = New System.Windows.Forms.TextBox
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMoTa = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.grdvwTaiLieuKemTheo = New DMC.[Interface].GridView.ctrlGridView
        CType(Me.grdvwTaiLieuKemTheo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTaiVe
        '
        Me.btnTaiVe.Location = New System.Drawing.Point(368, 256)
        Me.btnTaiVe.Name = "btnTaiVe"
        Me.btnTaiVe.Size = New System.Drawing.Size(69, 23)
        Me.btnTaiVe.TabIndex = 13
        Me.btnTaiVe.Text = "Tải về"
        Me.btnTaiVe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tên tệp dữ liệu nguồn"
        '
        'txtTenTepDuLieuNguon
        '
        Me.txtTenTepDuLieuNguon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenTepDuLieuNguon.BackColor = System.Drawing.Color.LightYellow
        Me.txtTenTepDuLieuNguon.Location = New System.Drawing.Point(6, 16)
        Me.txtTenTepDuLieuNguon.Multiline = True
        Me.txtTenTepDuLieuNguon.Name = "txtTenTepDuLieuNguon"
        Me.txtTenTepDuLieuNguon.ReadOnly = True
        Me.txtTenTepDuLieuNguon.Size = New System.Drawing.Size(708, 28)
        Me.txtTenTepDuLieuNguon.TabIndex = 9
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(222, 256)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(69, 23)
        Me.btnCapNhat.TabIndex = 8
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(3, 256)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(69, 23)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Mô tả tài liệu:"
        '
        'txtMoTa
        '
        Me.txtMoTa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMoTa.Location = New System.Drawing.Point(6, 63)
        Me.txtMoTa.Multiline = True
        Me.txtMoTa.Name = "txtMoTa"
        Me.txtMoTa.Size = New System.Drawing.Size(708, 40)
        Me.txtMoTa.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Danh sách các tài liệu kèm theo:"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(149, 256)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(69, 23)
        Me.btnXoa.TabIndex = 17
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(76, 256)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(69, 23)
        Me.btnSua.TabIndex = 18
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(295, 256)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(69, 23)
        Me.btnHuyLenh.TabIndex = 19
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'grdvwTaiLieuKemTheo
        '
        Me.grdvwTaiLieuKemTheo.AllowUserToAddRows = False
        Me.grdvwTaiLieuKemTheo.AllowUserToDeleteRows = False
        Me.grdvwTaiLieuKemTheo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwTaiLieuKemTheo.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwTaiLieuKemTheo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwTaiLieuKemTheo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwTaiLieuKemTheo.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwTaiLieuKemTheo.Location = New System.Drawing.Point(6, 130)
        Me.grdvwTaiLieuKemTheo.Name = "grdvwTaiLieuKemTheo"
        Me.grdvwTaiLieuKemTheo.ReadOnly = True
        Me.grdvwTaiLieuKemTheo.RowHeadersWidth = 25
        Me.grdvwTaiLieuKemTheo.Size = New System.Drawing.Size(708, 120)
        Me.grdvwTaiLieuKemTheo.TabIndex = 20
        '
        'ctrlTaiLieuKemTheoSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Controls.Add(Me.grdvwTaiLieuKemTheo)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMoTa)
        Me.Controls.Add(Me.btnTaiVe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTenTepDuLieuNguon)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.btnThem)
        Me.Name = "ctrlTaiLieuKemTheoSQL"
        Me.Size = New System.Drawing.Size(717, 282)
        CType(Me.grdvwTaiLieuKemTheo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTaiVe As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTenTepDuLieuNguon As System.Windows.Forms.TextBox
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMoTa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents grdvwTaiLieuKemTheo As ctrlGridView

End Class
