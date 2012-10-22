<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtrTongHop
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdIn = New System.Windows.Forms.Button
        Me.cboXem = New System.Windows.Forms.Button
        Me.cboLoaiHoSo = New System.Windows.Forms.ComboBox
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmdIn)
        Me.GroupBox2.Controls.Add(Me.cboXem)
        Me.GroupBox2.Controls.Add(Me.cboLoaiHoSo)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(414, 142)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Chọn hệ thống báo cáo"
        '
        'cmdIn
        '
        Me.cmdIn.Location = New System.Drawing.Point(220, 94)
        Me.cmdIn.Name = "cmdIn"
        Me.cmdIn.Size = New System.Drawing.Size(73, 22)
        Me.cmdIn.TabIndex = 5
        Me.cmdIn.Text = "In"
        Me.cmdIn.UseVisualStyleBackColor = True
        '
        'cboXem
        '
        Me.cboXem.Location = New System.Drawing.Point(141, 94)
        Me.cboXem.Name = "cboXem"
        Me.cboXem.Size = New System.Drawing.Size(73, 22)
        Me.cboXem.TabIndex = 4
        Me.cboXem.Text = "Xem"
        Me.cboXem.UseVisualStyleBackColor = True
        '
        'cboLoaiHoSo
        '
        Me.cboLoaiHoSo.FormattingEnabled = True
        Me.cboLoaiHoSo.Items.AddRange(New Object() {"Hồ sơ tiếp nhận", "Hồ sơ xét duyệt", "Hồ sơ thẩm định", "Hồ sơ phê duyệt", "Hồ sơ cấp GCN", "Hồ sơ biến động"})
        Me.cboLoaiHoSo.Location = New System.Drawing.Point(141, 67)
        Me.cboLoaiHoSo.Name = "cboLoaiHoSo"
        Me.cboLoaiHoSo.Size = New System.Drawing.Size(220, 21)
        Me.cboLoaiHoSo.TabIndex = 3
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(141, 41)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(118, 20)
        Me.DateTimePicker3.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(82, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Đến ngày"
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(141, 15)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(119, 20)
        Me.DateTimePicker4.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Từ ngày"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(417, 23)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "BÁO CÁO TỔNG HỢP TRẠNG THÁI HỒ SƠ CẤP GCN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtrTongHop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "CtrTongHop"
        Me.Size = New System.Drawing.Size(417, 171)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdIn As System.Windows.Forms.Button
    Friend WithEvents cboXem As System.Windows.Forms.Button
    Friend WithEvents cboLoaiHoSo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
