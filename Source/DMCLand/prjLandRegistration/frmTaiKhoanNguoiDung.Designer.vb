<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaiKhoanNguoiDung
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
        Me.UcTaiKhoanNguoiDung1 = New DMC.Land.QuanTriHeThong.TaiKhoanNguoiDung.ucTaiKhoanNguoiDung
        Me.SuspendLayout()
        '
        'UcTaiKhoanNguoiDung1
        '
        Me.UcTaiKhoanNguoiDung1.BackColor = System.Drawing.Color.Lavender
        Me.UcTaiKhoanNguoiDung1.Connection = Nothing
        Me.UcTaiKhoanNguoiDung1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcTaiKhoanNguoiDung1.getConnect = Nothing
        Me.UcTaiKhoanNguoiDung1.getstrTenTruyCap = Nothing
        Me.UcTaiKhoanNguoiDung1.Location = New System.Drawing.Point(0, 0)
        Me.UcTaiKhoanNguoiDung1.Name = "UcTaiKhoanNguoiDung1"
        Me.UcTaiKhoanNguoiDung1.Size = New System.Drawing.Size(630, 370)
        Me.UcTaiKhoanNguoiDung1.TabIndex = 2
        Me.UcTaiKhoanNguoiDung1.TrangThaiKetNoi = 0
        '
        'frmTaiKhoanNguoiDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 370)
        Me.Controls.Add(Me.UcTaiKhoanNguoiDung1)
        Me.Name = "frmTaiKhoanNguoiDung"
        Me.Text = "frmTaiKhoanNguoiDung"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcTaiKhoanNguoiDung1 As DMC.Land.QuanTriHeThong.TaiKhoanNguoiDung.ucTaiKhoanNguoiDung
End Class
