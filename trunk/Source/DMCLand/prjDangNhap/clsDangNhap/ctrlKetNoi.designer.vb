
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlKetNoi
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlKetNoi))
        Me.txtMaNSD = New System.Windows.Forms.TextBox
        Me.txtMatKhau = New System.Windows.Forms.TextBox
        Me.btDangNhap = New System.Windows.Forms.Button
        Me.btThoat = New System.Windows.Forms.Button
        Me.bntCauHinh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtMaNSD
        '
        Me.txtMaNSD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaNSD.Location = New System.Drawing.Point(242, 122)
        Me.txtMaNSD.Name = "txtMaNSD"
        Me.txtMaNSD.Size = New System.Drawing.Size(259, 20)
        Me.txtMaNSD.TabIndex = 1
        '
        'txtMatKhau
        '
        Me.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMatKhau.Location = New System.Drawing.Point(242, 155)
        Me.txtMatKhau.Name = "txtMatKhau"
        Me.txtMatKhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatKhau.Size = New System.Drawing.Size(259, 20)
        Me.txtMatKhau.TabIndex = 2
        '
        'btDangNhap
        '
        Me.btDangNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDangNhap.Location = New System.Drawing.Point(328, 182)
        Me.btDangNhap.Name = "btDangNhap"
        Me.btDangNhap.Size = New System.Drawing.Size(84, 29)
        Me.btDangNhap.TabIndex = 3
        Me.btDangNhap.Tag = "Đăng nhập vào hệ thống"
        Me.btDangNhap.Text = "Đăng nhập"
        Me.btDangNhap.UseVisualStyleBackColor = True
        '
        'btThoat
        '
        Me.btThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThoat.Location = New System.Drawing.Point(417, 182)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(84, 29)
        Me.btThoat.TabIndex = 4
        Me.btThoat.Tag = "Thoát khỏi hệ thống"
        Me.btThoat.Text = "Thoát"
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'bntCauHinh
        '
        Me.bntCauHinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntCauHinh.Location = New System.Drawing.Point(241, 182)
        Me.bntCauHinh.Name = "bntCauHinh"
        Me.bntCauHinh.Size = New System.Drawing.Size(84, 29)
        Me.bntCauHinh.TabIndex = 5
        Me.bntCauHinh.Tag = "Cấu hình kết nối máy chủ"
        Me.bntCauHinh.Text = "Cấu hình"
        Me.bntCauHinh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(509, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "QUẢN LÝ VÀ CẤP GIẤY CHỨNG NHẬN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label2.Location = New System.Drawing.Point(146, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tên đăng nhập"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label3.Location = New System.Drawing.Point(148, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mật khẩu"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(148, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Đăng nhập"
        '
        'ctrlKetNoi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Red
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bntCauHinh)
        Me.Controls.Add(Me.btThoat)
        Me.Controls.Add(Me.btDangNhap)
        Me.Controls.Add(Me.txtMatKhau)
        Me.Controls.Add(Me.txtMaNSD)
        Me.Name = "ctrlKetNoi"
        Me.Size = New System.Drawing.Size(515, 299)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMaNSD As System.Windows.Forms.TextBox
    Friend WithEvents txtMatKhau As System.Windows.Forms.TextBox
    Friend WithEvents btDangNhap As System.Windows.Forms.Button
    Friend WithEvents btThoat As System.Windows.Forms.Button
    Friend WithEvents bntCauHinh As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
