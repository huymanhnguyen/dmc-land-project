<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinBoSung
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
        Me.chkHoanTatBoSung = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpNgayBoXung = New System.Windows.Forms.DateTimePicker
        Me.dtpNgayCongVanBoXung = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSoCongVanBoXung = New System.Windows.Forms.TextBox
        Me.txtNoiDungBoXung = New System.Windows.Forms.TextBox
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.grdrwYeuCauBoXung = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdrwYeuCauBoXung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkHoanTatBoSung
        '
        Me.chkHoanTatBoSung.AutoSize = True
        Me.chkHoanTatBoSung.ForeColor = System.Drawing.Color.Red
        Me.chkHoanTatBoSung.Location = New System.Drawing.Point(302, 79)
        Me.chkHoanTatBoSung.Name = "chkHoanTatBoSung"
        Me.chkHoanTatBoSung.Size = New System.Drawing.Size(123, 17)
        Me.chkHoanTatBoSung.TabIndex = 5
        Me.chkHoanTatBoSung.Text = "Đã hoàn tất bổ sung"
        Me.chkHoanTatBoSung.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkHoanTatBoSung)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.dtpNgayBoXung)
        Me.GroupBox2.Controls.Add(Me.dtpNgayCongVanBoXung)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSoCongVanBoXung)
        Me.GroupBox2.Controls.Add(Me.txtNoiDungBoXung)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(746, 100)
        Me.GroupBox2.TabIndex = 125
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin bổ sung của cán bộ CẤP CƠ SỞ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Công văn bổ sung số:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Nội dung bổ sung:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Ngày công văn bổ sung:"
        '
        'dtpNgayBoXung
        '
        Me.dtpNgayBoXung.Location = New System.Drawing.Point(137, 77)
        Me.dtpNgayBoXung.Name = "dtpNgayBoXung"
        Me.dtpNgayBoXung.Size = New System.Drawing.Size(103, 20)
        Me.dtpNgayBoXung.TabIndex = 4
        '
        'dtpNgayCongVanBoXung
        '
        Me.dtpNgayCongVanBoXung.Location = New System.Drawing.Point(484, 49)
        Me.dtpNgayCongVanBoXung.Name = "dtpNgayCongVanBoXung"
        Me.dtpNgayCongVanBoXung.Size = New System.Drawing.Size(102, 20)
        Me.dtpNgayCongVanBoXung.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Ngày bổ sung:"
        '
        'txtSoCongVanBoXung
        '
        Me.txtSoCongVanBoXung.Location = New System.Drawing.Point(137, 49)
        Me.txtSoCongVanBoXung.Name = "txtSoCongVanBoXung"
        Me.txtSoCongVanBoXung.Size = New System.Drawing.Size(149, 20)
        Me.txtSoCongVanBoXung.TabIndex = 2
        '
        'txtNoiDungBoXung
        '
        Me.txtNoiDungBoXung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiDungBoXung.Location = New System.Drawing.Point(137, 18)
        Me.txtNoiDungBoXung.Multiline = True
        Me.txtNoiDungBoXung.Name = "txtNoiDungBoXung"
        Me.txtNoiDungBoXung.Size = New System.Drawing.Size(600, 26)
        Me.txtNoiDungBoXung.TabIndex = 1
        '
        'btnTroGiup
        '
        Me.btnTroGiup.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTroGiup.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTroGiup.Location = New System.Drawing.Point(596, 19)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(62, 23)
        Me.btnTroGiup.TabIndex = 12
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = False
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnHuyLenh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHuyLenh.Location = New System.Drawing.Point(266, 19)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(64, 23)
        Me.btnHuyLenh.TabIndex = 11
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = False
        '
        'btnCapNhat
        '
        Me.btnCapNhat.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCapNhat.Location = New System.Drawing.Point(202, 19)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(64, 23)
        Me.btnCapNhat.TabIndex = 10
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = False
        '
        'btnXoa
        '
        Me.btnXoa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnXoa.Location = New System.Drawing.Point(138, 19)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(64, 23)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = False
        '
        'btnSua
        '
        Me.btnSua.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSua.Location = New System.Drawing.Point(74, 19)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(64, 23)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = False
        '
        'btnThem
        '
        Me.btnThem.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnThem.Location = New System.Drawing.Point(10, 19)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(64, 23)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = False
        '
        'grdrwYeuCauBoXung
        '
        Me.grdrwYeuCauBoXung.AllowUserToAddRows = False
        Me.grdrwYeuCauBoXung.AllowUserToDeleteRows = False
        Me.grdrwYeuCauBoXung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdrwYeuCauBoXung.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdrwYeuCauBoXung.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdrwYeuCauBoXung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdrwYeuCauBoXung.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdrwYeuCauBoXung.Location = New System.Drawing.Point(3, 107)
        Me.grdrwYeuCauBoXung.Name = "grdrwYeuCauBoXung"
        Me.grdrwYeuCauBoXung.ReadOnly = True
        Me.grdrwYeuCauBoXung.RowHeadersWidth = 25
        Me.grdrwYeuCauBoXung.Size = New System.Drawing.Size(745, 109)
        Me.grdrwYeuCauBoXung.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Controls.Add(Me.btnCapNhat)
        Me.GroupBox1.Controls.Add(Me.btnTroGiup)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 46)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.grdrwYeuCauBoXung)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(752, 225)
        Me.GroupBox3.TabIndex = 127
        Me.GroupBox3.TabStop = False
        '
        'ctrlThongTinBoSung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinBoSung"
        Me.Size = New System.Drawing.Size(755, 287)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdrwYeuCauBoXung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkHoanTatBoSung As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayBoXung As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgayCongVanBoXung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSoCongVanBoXung As System.Windows.Forms.TextBox
    Friend WithEvents txtNoiDungBoXung As System.Windows.Forms.TextBox
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents grdrwYeuCauBoXung As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
