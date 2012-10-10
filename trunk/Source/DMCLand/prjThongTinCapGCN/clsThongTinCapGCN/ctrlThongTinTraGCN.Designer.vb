<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinTraGCN
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpNgayHoanTatGCN = New System.Windows.Forms.DateTimePicker
        Me.Label26 = New System.Windows.Forms.Label
        Me.dtpNgayTraGCN = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radChuaTraGCN = New System.Windows.Forms.RadioButton
        Me.radDaTraGCN = New System.Windows.Forms.RadioButton
        Me.radChuaXuLy = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtYKienTraGCN = New System.Windows.Forms.TextBox
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkKhoaSoGCN = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(234, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Ngày hoàn tất"
        '
        'dtpNgayHoanTatGCN
        '
        Me.dtpNgayHoanTatGCN.Location = New System.Drawing.Point(313, 19)
        Me.dtpNgayHoanTatGCN.Name = "dtpNgayHoanTatGCN"
        Me.dtpNgayHoanTatGCN.Size = New System.Drawing.Size(136, 20)
        Me.dtpNgayHoanTatGCN.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(73, 13)
        Me.Label26.TabIndex = 38
        Me.Label26.Text = "Ngày trả GCN"
        '
        'dtpNgayTraGCN
        '
        Me.dtpNgayTraGCN.Location = New System.Drawing.Point(90, 19)
        Me.dtpNgayTraGCN.Name = "dtpNgayTraGCN"
        Me.dtpNgayTraGCN.Size = New System.Drawing.Size(136, 20)
        Me.dtpNgayTraGCN.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkKhoaSoGCN)
        Me.GroupBox1.Controls.Add(Me.radChuaTraGCN)
        Me.GroupBox1.Controls.Add(Me.radDaTraGCN)
        Me.GroupBox1.Controls.Add(Me.radChuaXuLy)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtYKienTraGCN)
        Me.GroupBox1.Controls.Add(Me.dtpNgayHoanTatGCN)
        Me.GroupBox1.Controls.Add(Me.dtpNgayTraGCN)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(651, 179)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin Trả GCN"
        '
        'radChuaTraGCN
        '
        Me.radChuaTraGCN.AutoSize = True
        Me.radChuaTraGCN.Location = New System.Drawing.Point(412, 45)
        Me.radChuaTraGCN.Name = "radChuaTraGCN"
        Me.radChuaTraGCN.Size = New System.Drawing.Size(91, 17)
        Me.radChuaTraGCN.TabIndex = 46
        Me.radChuaTraGCN.Text = "Chưa trả GCN"
        Me.radChuaTraGCN.UseVisualStyleBackColor = True
        '
        'radDaTraGCN
        '
        Me.radDaTraGCN.AutoSize = True
        Me.radDaTraGCN.Location = New System.Drawing.Point(228, 45)
        Me.radDaTraGCN.Name = "radDaTraGCN"
        Me.radDaTraGCN.Size = New System.Drawing.Size(80, 17)
        Me.radDaTraGCN.TabIndex = 45
        Me.radDaTraGCN.Text = "Đã trả GCN"
        Me.radDaTraGCN.UseVisualStyleBackColor = True
        '
        'radChuaXuLy
        '
        Me.radChuaXuLy.AutoSize = True
        Me.radChuaXuLy.Checked = True
        Me.radChuaXuLy.Location = New System.Drawing.Point(90, 45)
        Me.radChuaXuLy.Name = "radChuaXuLy"
        Me.radChuaXuLy.Size = New System.Drawing.Size(74, 17)
        Me.radChuaXuLy.TabIndex = 44
        Me.radChuaXuLy.TabStop = True
        Me.radChuaXuLy.Text = "Chưa xử lý"
        Me.radChuaXuLy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Ý kiến trả GCN"
        '
        'txtYKienTraGCN
        '
        Me.txtYKienTraGCN.Location = New System.Drawing.Point(90, 68)
        Me.txtYKienTraGCN.Multiline = True
        Me.txtYKienTraGCN.Name = "txtYKienTraGCN"
        Me.txtYKienTraGCN.Size = New System.Drawing.Size(544, 70)
        Me.txtYKienTraGCN.TabIndex = 42
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(6, 14)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(70, 14)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 3
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(134, 14)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 4
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(651, 41)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        '
        'chkKhoaSoGCN
        '
        Me.chkKhoaSoGCN.AutoSize = True
        Me.chkKhoaSoGCN.Location = New System.Drawing.Point(91, 144)
        Me.chkKhoaSoGCN.Name = "chkKhoaSoGCN"
        Me.chkKhoaSoGCN.Size = New System.Drawing.Size(91, 17)
        Me.chkKhoaSoGCN.TabIndex = 47
        Me.chkKhoaSoGCN.Text = "Khóa sổ GCN"
        Me.chkKhoaSoGCN.UseVisualStyleBackColor = True
        '
        'ctrlThongTinTraGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinTraGCN"
        Me.Size = New System.Drawing.Size(657, 232)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayHoanTatGCN As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayTraGCN As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtYKienTraGCN As System.Windows.Forms.TextBox
    Friend WithEvents radChuaTraGCN As System.Windows.Forms.RadioButton
    Friend WithEvents radDaTraGCN As System.Windows.Forms.RadioButton
    Friend WithEvents radChuaXuLy As System.Windows.Forms.RadioButton
    Friend WithEvents chkKhoaSoGCN As System.Windows.Forms.CheckBox

End Class
