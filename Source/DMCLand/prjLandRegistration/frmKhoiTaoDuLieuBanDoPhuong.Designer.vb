<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKhoiTaoDuLieuBanDoPhuong
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cmdKhoiTao = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txttenPhuong = New System.Windows.Forms.TextBox
        Me.txtTenTat = New System.Windows.Forms.TextBox
        Me.txtDonViHanhChinh = New System.Windows.Forms.TextBox
        Me.UcListDVHC1 = New DMC.Land.QuanTriHeThong.DonViHanhChinh.ucListDVHC
        Me.SuspendLayout()
        '
        'cmdKhoiTao
        '
        Me.cmdKhoiTao.Location = New System.Drawing.Point(478, 98)
        Me.cmdKhoiTao.Name = "cmdKhoiTao"
        Me.cmdKhoiTao.Size = New System.Drawing.Size(107, 26)
        Me.cmdKhoiTao.TabIndex = 1
        Me.cmdKhoiTao.Text = "Khởi tạo dữ liệu"
        Me.cmdKhoiTao.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(269, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tên phường"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tên tắt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(270, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Đơn vị hành chính"
        '
        'txttenPhuong
        '
        Me.txttenPhuong.Location = New System.Drawing.Point(372, 21)
        Me.txttenPhuong.Name = "txttenPhuong"
        Me.txttenPhuong.ReadOnly = True
        Me.txttenPhuong.Size = New System.Drawing.Size(216, 20)
        Me.txttenPhuong.TabIndex = 5
        '
        'txtTenTat
        '
        Me.txtTenTat.Location = New System.Drawing.Point(373, 45)
        Me.txtTenTat.Name = "txtTenTat"
        Me.txtTenTat.ReadOnly = True
        Me.txtTenTat.Size = New System.Drawing.Size(216, 20)
        Me.txtTenTat.TabIndex = 6
        '
        'txtDonViHanhChinh
        '
        Me.txtDonViHanhChinh.Location = New System.Drawing.Point(372, 72)
        Me.txtDonViHanhChinh.Name = "txtDonViHanhChinh"
        Me.txtDonViHanhChinh.ReadOnly = True
        Me.txtDonViHanhChinh.Size = New System.Drawing.Size(216, 20)
        Me.txtDonViHanhChinh.TabIndex = 7
        '
        'UcListDVHC1
        '
        Me.UcListDVHC1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UcListDVHC1.BackColor = System.Drawing.Color.Lavender
        Me.UcListDVHC1.Get_ArrDVHC = Nothing
        Me.UcListDVHC1.Get_CurrDVHC = 0
        Me.UcListDVHC1.Get_MaQuyen = 0
        Me.UcListDVHC1.Get_SqlCon = Nothing
        Me.UcListDVHC1.Location = New System.Drawing.Point(0, 0)
        Me.UcListDVHC1.Name = "UcListDVHC1"
        Me.UcListDVHC1.Size = New System.Drawing.Size(264, 330)
        Me.UcListDVHC1.TabIndex = 0
        '
        'frmKhoiTaoDuLieuBanDoPhuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(597, 304)
        Me.Controls.Add(Me.txtDonViHanhChinh)
        Me.Controls.Add(Me.txtTenTat)
        Me.Controls.Add(Me.txttenPhuong)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdKhoiTao)
        Me.Controls.Add(Me.UcListDVHC1)
        Me.Name = "frmKhoiTaoDuLieuBanDoPhuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KHOI TAO DU LIEU BAN DO PHUONG"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UcListDVHC1 As DMC.Land.QuanTriHeThong.DonViHanhChinh.ucListDVHC
    Friend WithEvents cmdKhoiTao As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttenPhuong As System.Windows.Forms.TextBox
    Friend WithEvents txtTenTat As System.Windows.Forms.TextBox
    Friend WithEvents txtDonViHanhChinh As System.Windows.Forms.TextBox
End Class
