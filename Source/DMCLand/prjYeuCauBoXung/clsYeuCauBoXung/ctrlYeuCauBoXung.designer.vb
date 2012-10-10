Imports DMC.Interface.GridView
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlYeuCauBoXung
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.txtNoiDungYeuCauBoXung = New System.Windows.Forms.TextBox
        Me.txtSoCongVanYeuCauBoXung = New System.Windows.Forms.TextBox
        Me.DTPNgayCongVanYeuCauBoXung = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpYeuCauBoXungTuNgay = New System.Windows.Forms.DateTimePicker
        Me.numThoiHanYeuCauBoXung = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpNgayBoXung = New System.Windows.Forms.DateTimePicker
        Me.dtpNgayCongVanBoXung = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSoCongVanBoXung = New System.Windows.Forms.TextBox
        Me.txtNoiDungBoXung = New System.Windows.Forms.TextBox
        Me.grdrwYeuCauBoXung = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        CType(Me.numThoiHanYeuCauBoXung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdrwYeuCauBoXung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTroGiup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTroGiup.Location = New System.Drawing.Point(675, 11)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(62, 23)
        Me.btnTroGiup.TabIndex = 17
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = False
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnHuyLenh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHuyLenh.Location = New System.Drawing.Point(265, 11)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(64, 23)
        Me.btnHuyLenh.TabIndex = 16
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = False
        '
        'btnCapNhat
        '
        Me.btnCapNhat.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCapNhat.Location = New System.Drawing.Point(201, 11)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(64, 23)
        Me.btnCapNhat.TabIndex = 15
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = False
        '
        'btnXoa
        '
        Me.btnXoa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnXoa.Location = New System.Drawing.Point(137, 11)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(64, 23)
        Me.btnXoa.TabIndex = 14
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = False
        '
        'btnSua
        '
        Me.btnSua.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSua.Location = New System.Drawing.Point(73, 11)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(64, 23)
        Me.btnSua.TabIndex = 13
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = False
        '
        'btnThem
        '
        Me.btnThem.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnThem.Location = New System.Drawing.Point(9, 11)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(64, 23)
        Me.btnThem.TabIndex = 12
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = False
        '
        'txtNoiDungYeuCauBoXung
        '
        Me.txtNoiDungYeuCauBoXung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiDungYeuCauBoXung.Location = New System.Drawing.Point(137, 17)
        Me.txtNoiDungYeuCauBoXung.Multiline = True
        Me.txtNoiDungYeuCauBoXung.Name = "txtNoiDungYeuCauBoXung"
        Me.txtNoiDungYeuCauBoXung.Size = New System.Drawing.Size(601, 26)
        Me.txtNoiDungYeuCauBoXung.TabIndex = 1
        '
        'txtSoCongVanYeuCauBoXung
        '
        Me.txtSoCongVanYeuCauBoXung.Location = New System.Drawing.Point(137, 49)
        Me.txtSoCongVanYeuCauBoXung.Name = "txtSoCongVanYeuCauBoXung"
        Me.txtSoCongVanYeuCauBoXung.Size = New System.Drawing.Size(149, 20)
        Me.txtSoCongVanYeuCauBoXung.TabIndex = 2
        '
        'DTPNgayCongVanYeuCauBoXung
        '
        Me.DTPNgayCongVanYeuCauBoXung.Location = New System.Drawing.Point(483, 49)
        Me.DTPNgayCongVanYeuCauBoXung.Name = "DTPNgayCongVanYeuCauBoXung"
        Me.DTPNgayCongVanYeuCauBoXung.Size = New System.Drawing.Size(104, 20)
        Me.DTPNgayCongVanYeuCauBoXung.TabIndex = 3
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(302, 52)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(143, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Ngày công văn y/c bổ xung:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 13)
        Me.Label23.TabIndex = 104
        Me.Label23.Text = "Nội dung y/c bổ xung:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 52)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(130, 13)
        Me.Label22.TabIndex = 103
        Me.Label22.Text = "Công văn y/c bổ xung số:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Thời hạn y/c bổ xung:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(302, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Y/c bổ xung từ ngày:"
        '
        'dtpYeuCauBoXungTuNgay
        '
        Me.dtpYeuCauBoXungTuNgay.Location = New System.Drawing.Point(483, 77)
        Me.dtpYeuCauBoXungTuNgay.Name = "dtpYeuCauBoXungTuNgay"
        Me.dtpYeuCauBoXungTuNgay.Size = New System.Drawing.Size(104, 20)
        Me.dtpYeuCauBoXungTuNgay.TabIndex = 5
        '
        'numThoiHanYeuCauBoXung
        '
        Me.numThoiHanYeuCauBoXung.Location = New System.Drawing.Point(137, 77)
        Me.numThoiHanYeuCauBoXung.Name = "numThoiHanYeuCauBoXung"
        Me.numThoiHanYeuCauBoXung.Size = New System.Drawing.Size(64, 20)
        Me.numThoiHanYeuCauBoXung.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(206, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "(ngày)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.numThoiHanYeuCauBoXung)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.dtpYeuCauBoXungTuNgay)
        Me.GroupBox1.Controls.Add(Me.DTPNgayCongVanYeuCauBoXung)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSoCongVanYeuCauBoXung)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNoiDungYeuCauBoXung)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(746, 103)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin y/c bổ xung của cán bộ THẨM ĐỊNH"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(119, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "(*)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.dtpNgayBoXung)
        Me.GroupBox2.Controls.Add(Me.dtpNgayCongVanBoXung)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSoCongVanBoXung)
        Me.GroupBox2.Controls.Add(Me.txtNoiDungBoXung)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(746, 100)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin bổ xung tương ứng của cán bộ CẤP CƠ SỞ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Công văn bổ xung số:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Nội dung bổ xung:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Ngày công văn bổ xung:"
        '
        'dtpNgayBoXung
        '
        Me.dtpNgayBoXung.Location = New System.Drawing.Point(137, 77)
        Me.dtpNgayBoXung.Name = "dtpNgayBoXung"
        Me.dtpNgayBoXung.Size = New System.Drawing.Size(103, 20)
        Me.dtpNgayBoXung.TabIndex = 9
        '
        'dtpNgayCongVanBoXung
        '
        Me.dtpNgayCongVanBoXung.Location = New System.Drawing.Point(484, 49)
        Me.dtpNgayCongVanBoXung.Name = "dtpNgayCongVanBoXung"
        Me.dtpNgayCongVanBoXung.Size = New System.Drawing.Size(102, 20)
        Me.dtpNgayCongVanBoXung.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Ngày bổ xung:"
        '
        'txtSoCongVanBoXung
        '
        Me.txtSoCongVanBoXung.Location = New System.Drawing.Point(137, 49)
        Me.txtSoCongVanBoXung.Name = "txtSoCongVanBoXung"
        Me.txtSoCongVanBoXung.Size = New System.Drawing.Size(149, 20)
        Me.txtSoCongVanBoXung.TabIndex = 7
        '
        'txtNoiDungBoXung
        '
        Me.txtNoiDungBoXung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiDungBoXung.Location = New System.Drawing.Point(137, 18)
        Me.txtNoiDungBoXung.Multiline = True
        Me.txtNoiDungBoXung.Name = "txtNoiDungBoXung"
        Me.txtNoiDungBoXung.Size = New System.Drawing.Size(600, 26)
        Me.txtNoiDungBoXung.TabIndex = 6
        '
        'grdrwYeuCauBoXung
        '
        Me.grdrwYeuCauBoXung.AllowUserToAddRows = False
        Me.grdrwYeuCauBoXung.AllowUserToDeleteRows = False
        Me.grdrwYeuCauBoXung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdrwYeuCauBoXung.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdrwYeuCauBoXung.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.grdrwYeuCauBoXung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdrwYeuCauBoXung.DefaultCellStyle = DataGridViewCellStyle18
        Me.grdrwYeuCauBoXung.Location = New System.Drawing.Point(4, 218)
        Me.grdrwYeuCauBoXung.Name = "grdrwYeuCauBoXung"
        Me.grdrwYeuCauBoXung.ReadOnly = True
        Me.grdrwYeuCauBoXung.RowHeadersWidth = 25
        Me.grdrwYeuCauBoXung.Size = New System.Drawing.Size(745, 109)
        Me.grdrwYeuCauBoXung.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnTroGiup)
        Me.GroupBox3.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox3.Controls.Add(Me.btnCapNhat)
        Me.GroupBox3.Controls.Add(Me.btnXoa)
        Me.GroupBox3.Controls.Add(Me.btnSua)
        Me.GroupBox3.Controls.Add(Me.btnThem)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 333)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(746, 40)
        Me.GroupBox3.TabIndex = 117
        Me.GroupBox3.TabStop = False
        '
        'ctrlYeuCauBoXung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grdrwYeuCauBoXung)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlYeuCauBoXung"
        Me.Size = New System.Drawing.Size(756, 380)
        CType(Me.numThoiHanYeuCauBoXung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdrwYeuCauBoXung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents txtNoiDungYeuCauBoXung As System.Windows.Forms.TextBox
    Friend WithEvents txtSoCongVanYeuCauBoXung As System.Windows.Forms.TextBox
    Friend WithEvents DTPNgayCongVanYeuCauBoXung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpYeuCauBoXungTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents numThoiHanYeuCauBoXung As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayBoXung As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgayCongVanBoXung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSoCongVanBoXung As System.Windows.Forms.TextBox
    Friend WithEvents txtNoiDungBoXung As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdrwYeuCauBoXung As ctrlGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
