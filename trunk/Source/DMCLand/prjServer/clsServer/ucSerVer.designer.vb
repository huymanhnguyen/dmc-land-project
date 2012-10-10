<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSerVer
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
        Me.txtTenKetNoi = New System.Windows.Forms.TextBox
        Me.btnChapNhan = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnKiemTra = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtMayChu = New System.Windows.Forms.TextBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.radTaiKhoanSQL = New System.Windows.Forms.RadioButton
        Me.radTaiKhoanWin = New System.Windows.Forms.RadioButton
        Me.groupSQL = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.cmbDatabases = New System.Windows.Forms.ComboBox
        Me.cmbDatabasesQuan = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.groupSQL.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTenKetNoi
        '
        Me.txtTenKetNoi.Location = New System.Drawing.Point(83, 25)
        Me.txtTenKetNoi.Name = "txtTenKetNoi"
        Me.txtTenKetNoi.Size = New System.Drawing.Size(262, 20)
        Me.txtTenKetNoi.TabIndex = 0
        '
        'btnChapNhan
        '
        Me.btnChapNhan.Location = New System.Drawing.Point(179, 260)
        Me.btnChapNhan.Name = "btnChapNhan"
        Me.btnChapNhan.Size = New System.Drawing.Size(88, 23)
        Me.btnChapNhan.TabIndex = 9
        Me.btnChapNhan.Text = "Chấp nhận"
        Me.btnChapNhan.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(268, 260)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(88, 23)
        Me.btnXoa.TabIndex = 10
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tên kết nối"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Máy chủ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CSDL Phường"
        '
        'btnKiemTra
        '
        Me.btnKiemTra.Location = New System.Drawing.Point(85, 260)
        Me.btnKiemTra.Name = "btnKiemTra"
        Me.btnKiemTra.Size = New System.Drawing.Size(88, 23)
        Me.btnKiemTra.TabIndex = 8
        Me.btnKiemTra.Text = "Kiểm tra kết nối"
        Me.btnKiemTra.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbDatabasesQuan)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtMayChu)
        Me.GroupBox2.Controls.Add(Me.btnRefresh)
        Me.GroupBox2.Controls.Add(Me.radTaiKhoanSQL)
        Me.GroupBox2.Controls.Add(Me.radTaiKhoanWin)
        Me.GroupBox2.Controls.Add(Me.groupSQL)
        Me.GroupBox2.Controls.Add(Me.cmbDatabases)
        Me.GroupBox2.Controls.Add(Me.txtTenKetNoi)
        Me.GroupBox2.Controls.Add(Me.btnKiemTra)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnChapNhan)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 289)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cấu hình kết nối cơ sở dữ liệu"
        '
        'txtMayChu
        '
        Me.txtMayChu.Location = New System.Drawing.Point(84, 53)
        Me.txtMayChu.Name = "txtMayChu"
        Me.txtMayChu.Size = New System.Drawing.Size(260, 20)
        Me.txtMayChu.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(268, 203)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(88, 23)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Làm tươi"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'radTaiKhoanSQL
        '
        Me.radTaiKhoanSQL.AutoSize = True
        Me.radTaiKhoanSQL.Location = New System.Drawing.Point(18, 101)
        Me.radTaiKhoanSQL.Name = "radTaiKhoanSQL"
        Me.radTaiKhoanSQL.Size = New System.Drawing.Size(188, 17)
        Me.radTaiKhoanSQL.TabIndex = 3
        Me.radTaiKhoanSQL.Text = "Sử dụng mật khẩu của SQLServer"
        Me.radTaiKhoanSQL.UseVisualStyleBackColor = True
        '
        'radTaiKhoanWin
        '
        Me.radTaiKhoanWin.AutoSize = True
        Me.radTaiKhoanWin.Checked = True
        Me.radTaiKhoanWin.Location = New System.Drawing.Point(18, 78)
        Me.radTaiKhoanWin.Name = "radTaiKhoanWin"
        Me.radTaiKhoanWin.Size = New System.Drawing.Size(186, 17)
        Me.radTaiKhoanWin.TabIndex = 2
        Me.radTaiKhoanWin.TabStop = True
        Me.radTaiKhoanWin.Text = "Sử dụng mật khẩu của Windowns"
        Me.radTaiKhoanWin.UseVisualStyleBackColor = True
        '
        'groupSQL
        '
        Me.groupSQL.Controls.Add(Me.Label5)
        Me.groupSQL.Controls.Add(Me.Label6)
        Me.groupSQL.Controls.Add(Me.txtPass)
        Me.groupSQL.Controls.Add(Me.txtUser)
        Me.groupSQL.Enabled = False
        Me.groupSQL.Location = New System.Drawing.Point(18, 117)
        Me.groupSQL.Name = "groupSQL"
        Me.groupSQL.Size = New System.Drawing.Size(339, 77)
        Me.groupSQL.TabIndex = 19
        Me.groupSQL.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Mật khẩu"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Tài khoản"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(65, 45)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(262, 20)
        Me.txtPass.TabIndex = 5
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(65, 19)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(262, 20)
        Me.txtUser.TabIndex = 4
        '
        'cmbDatabases
        '
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(83, 205)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(179, 21)
        Me.cmbDatabases.TabIndex = 6
        '
        'cmbDatabasesQuan
        '
        Me.cmbDatabasesQuan.FormattingEnabled = True
        Me.cmbDatabasesQuan.Location = New System.Drawing.Point(84, 232)
        Me.cmbDatabasesQuan.Name = "cmbDatabasesQuan"
        Me.cmbDatabasesQuan.Size = New System.Drawing.Size(179, 21)
        Me.cmbDatabasesQuan.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "CSDL Quận"
        '
        'ucSerVer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ucSerVer"
        Me.Size = New System.Drawing.Size(379, 294)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.groupSQL.ResumeLayout(False)
        Me.groupSQL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnChapNhan As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtTenKetNoi As System.Windows.Forms.TextBox
    Friend WithEvents btnKiemTra As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDatabases As System.Windows.Forms.ComboBox
    Friend WithEvents radTaiKhoanSQL As System.Windows.Forms.RadioButton
    Friend WithEvents radTaiKhoanWin As System.Windows.Forms.RadioButton
    Friend WithEvents groupSQL As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtPass As System.Windows.Forms.TextBox
    Public WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents txtMayChu As System.Windows.Forms.TextBox
    Friend WithEvents cmbDatabasesQuan As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
