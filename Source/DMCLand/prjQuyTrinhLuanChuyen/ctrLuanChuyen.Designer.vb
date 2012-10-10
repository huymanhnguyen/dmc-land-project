<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrLuanChuyen
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
        Me.cmdTiepNhanHoSo = New System.Windows.Forms.Button
        Me.cmdVPDangKy = New System.Windows.Forms.Button
        Me.cmdLanhDaoVP = New System.Windows.Forms.Button
        Me.cmdPhongTNMT = New System.Windows.Forms.Button
        Me.cmdUB = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdTiepNhanHoSo
        '
        Me.cmdTiepNhanHoSo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdTiepNhanHoSo.FlatAppearance.BorderSize = 20
        Me.cmdTiepNhanHoSo.Location = New System.Drawing.Point(51, 77)
        Me.cmdTiepNhanHoSo.Name = "cmdTiepNhanHoSo"
        Me.cmdTiepNhanHoSo.Size = New System.Drawing.Size(132, 44)
        Me.cmdTiepNhanHoSo.TabIndex = 0
        Me.cmdTiepNhanHoSo.Text = "Tiếp nhận hồ sơ"
        Me.cmdTiepNhanHoSo.UseVisualStyleBackColor = True
        '
        'cmdVPDangKy
        '
        Me.cmdVPDangKy.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdVPDangKy.FlatAppearance.BorderSize = 20
        Me.cmdVPDangKy.Location = New System.Drawing.Point(232, 77)
        Me.cmdVPDangKy.Name = "cmdVPDangKy"
        Me.cmdVPDangKy.Size = New System.Drawing.Size(127, 44)
        Me.cmdVPDangKy.TabIndex = 1
        Me.cmdVPDangKy.Text = "Văn phòng đăng ký đất nhà"
        Me.cmdVPDangKy.UseVisualStyleBackColor = True
        '
        'cmdLanhDaoVP
        '
        Me.cmdLanhDaoVP.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdLanhDaoVP.FlatAppearance.BorderSize = 20
        Me.cmdLanhDaoVP.Location = New System.Drawing.Point(400, 77)
        Me.cmdLanhDaoVP.Name = "cmdLanhDaoVP"
        Me.cmdLanhDaoVP.Size = New System.Drawing.Size(127, 44)
        Me.cmdLanhDaoVP.TabIndex = 2
        Me.cmdLanhDaoVP.Text = "Lãnh đạo văn phòng đăng ký đất nhà"
        Me.cmdLanhDaoVP.UseVisualStyleBackColor = True
        '
        'cmdPhongTNMT
        '
        Me.cmdPhongTNMT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdPhongTNMT.FlatAppearance.BorderSize = 20
        Me.cmdPhongTNMT.Location = New System.Drawing.Point(330, 149)
        Me.cmdPhongTNMT.Name = "cmdPhongTNMT"
        Me.cmdPhongTNMT.Size = New System.Drawing.Size(127, 44)
        Me.cmdPhongTNMT.TabIndex = 3
        Me.cmdPhongTNMT.Text = "Phòng tài nguyên môi trường"
        Me.cmdPhongTNMT.UseVisualStyleBackColor = True
        '
        'cmdUB
        '
        Me.cmdUB.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdUB.FlatAppearance.BorderSize = 20
        Me.cmdUB.Location = New System.Drawing.Point(150, 149)
        Me.cmdUB.Name = "cmdUB"
        Me.cmdUB.Size = New System.Drawing.Size(127, 44)
        Me.cmdUB.TabIndex = 4
        Me.cmdUB.Text = "Ủy ban quận"
        Me.cmdUB.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(589, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "QUY TRÌNH LUÂN CHUYỂN HỒ SƠ CẤP GCN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctrLuanChuyen
        '
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdUB)
        Me.Controls.Add(Me.cmdPhongTNMT)
        Me.Controls.Add(Me.cmdLanhDaoVP)
        Me.Controls.Add(Me.cmdVPDangKy)
        Me.Controls.Add(Me.cmdTiepNhanHoSo)
        Me.Name = "ctrLuanChuyen"
        Me.Size = New System.Drawing.Size(589, 267)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdTiepNhanHoSo As System.Windows.Forms.Button
    Friend WithEvents cmdVPDangKy As System.Windows.Forms.Button
    Friend WithEvents cmdLanhDaoVP As System.Windows.Forms.Button
    Friend WithEvents cmdPhongTNMT As System.Windows.Forms.Button
    Friend WithEvents cmdUB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
