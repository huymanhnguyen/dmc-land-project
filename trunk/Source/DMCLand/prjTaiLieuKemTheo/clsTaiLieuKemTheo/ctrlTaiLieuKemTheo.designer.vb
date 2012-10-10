Imports DMC.Interface.GridView
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTaiLieuKemTheo
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnTaiVe = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTenTepDuLieuNguon = New System.Windows.Forms.TextBox
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.cmdTaiFile = New System.Windows.Forms.Button
        Me.grdvwTaiLieuKemTheo = New DMC.[Interface].GridView.ctrlGridView
        Me.txtMoTa = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSuaTTFile = New System.Windows.Forms.Button
        Me.cmdCapNhatMoTa = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtThuMucChuaFile = New System.Windows.Forms.TextBox
        Me.grdDanhSachFile = New DMC.[Interface].GridView.ctrlGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTenTaiLieu = New System.Windows.Forms.TextBox
        Me.chkCoFile = New System.Windows.Forms.CheckBox
        Me.cmdFile = New System.Windows.Forms.Button
        CType(Me.grdvwTaiLieuKemTheo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDanhSachFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTaiVe
        '
        Me.btnTaiVe.Location = New System.Drawing.Point(383, 16)
        Me.btnTaiVe.Name = "btnTaiVe"
        Me.btnTaiVe.Size = New System.Drawing.Size(69, 23)
        Me.btnTaiVe.TabIndex = 9
        Me.btnTaiVe.Text = "Tải về"
        Me.btnTaiVe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 170)
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
        Me.txtTenTepDuLieuNguon.Location = New System.Drawing.Point(121, 165)
        Me.txtTenTepDuLieuNguon.Name = "txtTenTepDuLieuNguon"
        Me.txtTenTepDuLieuNguon.ReadOnly = True
        Me.txtTenTepDuLieuNguon.Size = New System.Drawing.Size(541, 20)
        Me.txtTenTepDuLieuNguon.TabIndex = 1
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(237, 16)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(69, 23)
        Me.btnCapNhat.TabIndex = 7
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(18, 16)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(69, 23)
        Me.btnThem.TabIndex = 4
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Mô tả tài liệu:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Danh sách các tài liệu kèm theo:"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(164, 16)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(69, 23)
        Me.btnXoa.TabIndex = 6
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(91, 16)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(69, 23)
        Me.btnSua.TabIndex = 5
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(310, 16)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(69, 23)
        Me.btnHuyLenh.TabIndex = 8
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'cmdTaiFile
        '
        Me.cmdTaiFile.Location = New System.Drawing.Point(9, 14)
        Me.cmdTaiFile.Name = "cmdTaiFile"
        Me.cmdTaiFile.Size = New System.Drawing.Size(87, 23)
        Me.cmdTaiFile.TabIndex = 17
        Me.cmdTaiFile.Text = "Tải Files"
        Me.cmdTaiFile.UseVisualStyleBackColor = True
        '
        'grdvwTaiLieuKemTheo
        '
        Me.grdvwTaiLieuKemTheo.AllowUserToAddRows = False
        Me.grdvwTaiLieuKemTheo.AllowUserToDeleteRows = False
        Me.grdvwTaiLieuKemTheo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwTaiLieuKemTheo.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwTaiLieuKemTheo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdvwTaiLieuKemTheo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwTaiLieuKemTheo.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdvwTaiLieuKemTheo.Location = New System.Drawing.Point(6, 56)
        Me.grdvwTaiLieuKemTheo.Name = "grdvwTaiLieuKemTheo"
        Me.grdvwTaiLieuKemTheo.ReadOnly = True
        Me.grdvwTaiLieuKemTheo.RowHeadersWidth = 25
        Me.grdvwTaiLieuKemTheo.Size = New System.Drawing.Size(698, 103)
        Me.grdvwTaiLieuKemTheo.TabIndex = 3
        '
        'txtMoTa
        '
        Me.txtMoTa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMoTa.Location = New System.Drawing.Point(121, 246)
        Me.txtMoTa.Name = "txtMoTa"
        Me.txtMoTa.Size = New System.Drawing.Size(586, 26)
        Me.txtMoTa.TabIndex = 18
        Me.txtMoTa.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdFile)
        Me.GroupBox1.Controls.Add(Me.chkCoFile)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTenTaiLieu)
        Me.GroupBox1.Controls.Add(Me.cmdSuaTTFile)
        Me.GroupBox1.Controls.Add(Me.cmdCapNhatMoTa)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.grdDanhSachFile)
        Me.GroupBox1.Controls.Add(Me.txtMoTa)
        Me.GroupBox1.Controls.Add(Me.cmdTaiFile)
        Me.GroupBox1.Controls.Add(Me.grdvwTaiLieuKemTheo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTenTepDuLieuNguon)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(727, 500)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'cmdSuaTTFile
        '
        Me.cmdSuaTTFile.Location = New System.Drawing.Point(102, 14)
        Me.cmdSuaTTFile.Name = "cmdSuaTTFile"
        Me.cmdSuaTTFile.Size = New System.Drawing.Size(85, 23)
        Me.cmdSuaTTFile.TabIndex = 22
        Me.cmdSuaTTFile.Text = "Sửa"
        Me.cmdSuaTTFile.UseVisualStyleBackColor = True
        '
        'cmdCapNhatMoTa
        '
        Me.cmdCapNhatMoTa.Location = New System.Drawing.Point(193, 14)
        Me.cmdCapNhatMoTa.Name = "cmdCapNhatMoTa"
        Me.cmdCapNhatMoTa.Size = New System.Drawing.Size(91, 23)
        Me.cmdCapNhatMoTa.TabIndex = 21
        Me.cmdCapNhatMoTa.Text = "Cập nhật"
        Me.cmdCapNhatMoTa.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtThuMucChuaFile)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnTaiVe)
        Me.GroupBox2.Controls.Add(Me.btnCapNhat)
        Me.GroupBox2.Controls.Add(Me.btnThem)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 280)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 45)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'txtThuMucChuaFile
        '
        Me.txtThuMucChuaFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtThuMucChuaFile.Location = New System.Drawing.Point(458, 18)
        Me.txtThuMucChuaFile.Name = "txtThuMucChuaFile"
        Me.txtThuMucChuaFile.ReadOnly = True
        Me.txtThuMucChuaFile.Size = New System.Drawing.Size(236, 20)
        Me.txtThuMucChuaFile.TabIndex = 10
        '
        'grdDanhSachFile
        '
        Me.grdDanhSachFile.AllowUserToAddRows = False
        Me.grdDanhSachFile.AllowUserToDeleteRows = False
        Me.grdDanhSachFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhSachFile.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachFile.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grdDanhSachFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachFile.DefaultCellStyle = DataGridViewCellStyle12
        Me.grdDanhSachFile.Location = New System.Drawing.Point(3, 331)
        Me.grdDanhSachFile.Name = "grdDanhSachFile"
        Me.grdDanhSachFile.ReadOnly = True
        Me.grdDanhSachFile.RowHeadersWidth = 25
        Me.grdDanhSachFile.Size = New System.Drawing.Size(698, 162)
        Me.grdDanhSachFile.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Tên tài liệu"
        '
        'txtTenTaiLieu
        '
        Me.txtTenTaiLieu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenTaiLieu.BackColor = System.Drawing.SystemColors.Window
        Me.txtTenTaiLieu.Location = New System.Drawing.Point(121, 217)
        Me.txtTenTaiLieu.Multiline = True
        Me.txtTenTaiLieu.Name = "txtTenTaiLieu"
        Me.txtTenTaiLieu.Size = New System.Drawing.Size(583, 23)
        Me.txtTenTaiLieu.TabIndex = 23
        '
        'chkCoFile
        '
        Me.chkCoFile.AutoSize = True
        Me.chkCoFile.Location = New System.Drawing.Point(121, 194)
        Me.chkCoFile.Name = "chkCoFile"
        Me.chkCoFile.Size = New System.Drawing.Size(116, 17)
        Me.chkCoFile.TabIndex = 25
        Me.chkCoFile.Text = "Có File/Không File "
        Me.chkCoFile.UseVisualStyleBackColor = True
        '
        'cmdFile
        '
        Me.cmdFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFile.Location = New System.Drawing.Point(668, 163)
        Me.cmdFile.Name = "cmdFile"
        Me.cmdFile.Size = New System.Drawing.Size(36, 23)
        Me.cmdFile.TabIndex = 26
        Me.cmdFile.Text = "..."
        Me.cmdFile.UseVisualStyleBackColor = True
        '
        'ctrlTaiLieuKemTheo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlTaiLieuKemTheo"
        Me.Size = New System.Drawing.Size(730, 503)
        CType(Me.grdvwTaiLieuKemTheo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdDanhSachFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTaiVe As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTenTepDuLieuNguon As System.Windows.Forms.TextBox
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents grdvwTaiLieuKemTheo As ctrlGridView
    Friend WithEvents cmdTaiFile As System.Windows.Forms.Button
    Friend WithEvents txtMoTa As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDanhSachFile As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents cmdCapNhatMoTa As System.Windows.Forms.Button
    Friend WithEvents cmdSuaTTFile As System.Windows.Forms.Button
    Friend WithEvents txtThuMucChuaFile As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTenTaiLieu As System.Windows.Forms.TextBox
    Friend WithEvents chkCoFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFile As System.Windows.Forms.Button

End Class
