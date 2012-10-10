<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrUpdateHeThong
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstFile = New System.Windows.Forms.ListBox
        Me.txtThuMucConVert = New System.Windows.Forms.TextBox
        Me.cmdChonThuMuc = New System.Windows.Forms.Button
        Me.cmdThucThi = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMatKhau = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lstFile)
        Me.GroupBox1.Controls.Add(Me.txtThuMucConVert)
        Me.GroupBox1.Controls.Add(Me.cmdChonThuMuc)
        Me.GroupBox1.Controls.Add(Me.cmdThucThi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMatKhau)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 291)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin"
        '
        'lstFile
        '
        Me.lstFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFile.FormattingEnabled = True
        Me.lstFile.Location = New System.Drawing.Point(6, 71)
        Me.lstFile.Name = "lstFile"
        Me.lstFile.Size = New System.Drawing.Size(469, 173)
        Me.lstFile.TabIndex = 8
        '
        'txtThuMucConVert
        '
        Me.txtThuMucConVert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtThuMucConVert.Location = New System.Drawing.Point(6, 45)
        Me.txtThuMucConVert.Name = "txtThuMucConVert"
        Me.txtThuMucConVert.ReadOnly = True
        Me.txtThuMucConVert.Size = New System.Drawing.Size(404, 20)
        Me.txtThuMucConVert.TabIndex = 7
        '
        'cmdChonThuMuc
        '
        Me.cmdChonThuMuc.Location = New System.Drawing.Point(416, 43)
        Me.cmdChonThuMuc.Name = "cmdChonThuMuc"
        Me.cmdChonThuMuc.Size = New System.Drawing.Size(65, 23)
        Me.cmdChonThuMuc.TabIndex = 6
        Me.cmdChonThuMuc.Text = "<<..>>"
        Me.cmdChonThuMuc.UseVisualStyleBackColor = True
        '
        'cmdThucThi
        '
        Me.cmdThucThi.Location = New System.Drawing.Point(6, 260)
        Me.cmdThucThi.Name = "cmdThucThi"
        Me.cmdThucThi.Size = New System.Drawing.Size(123, 25)
        Me.cmdThucThi.TabIndex = 1
        Me.cmdThucThi.Text = "Thực thi"
        Me.cmdThucThi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mật khẩu"
        '
        'txtMatKhau
        '
        Me.txtMatKhau.Location = New System.Drawing.Point(71, 19)
        Me.txtMatKhau.Name = "txtMatKhau"
        Me.txtMatKhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatKhau.Size = New System.Drawing.Size(160, 20)
        Me.txtMatKhau.TabIndex = 0
        '
        'ctrUpdateHeThong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrUpdateHeThong"
        Me.Size = New System.Drawing.Size(541, 348)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstFile As System.Windows.Forms.ListBox
    Friend WithEvents txtThuMucConVert As System.Windows.Forms.TextBox
    Friend WithEvents cmdChonThuMuc As System.Windows.Forms.Button
    Friend WithEvents cmdThucThi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMatKhau As System.Windows.Forms.TextBox

End Class
