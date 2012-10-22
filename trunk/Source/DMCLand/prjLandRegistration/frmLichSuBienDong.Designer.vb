<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLichSuBienDong
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
        Me.CtrLichSuHSBienDong1 = New prjLichSuHoSoBienDong.ctrLichSuHSBienDong
        Me.SuspendLayout()
        '
        'CtrLichSuHSBienDong1
        '
        Me.CtrLichSuHSBienDong1.Connection = ""
        Me.CtrLichSuHSBienDong1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrLichSuHSBienDong1.Location = New System.Drawing.Point(0, 0)
        Me.CtrLichSuHSBienDong1.MaDangKyBienDong = ""
        Me.CtrLichSuHSBienDong1.MaDonViHanhChinh = Nothing
        Me.CtrLichSuHSBienDong1.MaHoSoCapGCN = ""
        Me.CtrLichSuHSBienDong1.MaThuaDat = ""
        Me.CtrLichSuHSBienDong1.MyError = ""
        Me.CtrLichSuHSBienDong1.Name = "CtrLichSuHSBienDong1"
        Me.CtrLichSuHSBienDong1.Size = New System.Drawing.Size(790, 624)
        Me.CtrLichSuHSBienDong1.TabIndex = 0
        '
        'frmLichSuBienDong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 624)
        Me.Controls.Add(Me.CtrLichSuHSBienDong1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLichSuBienDong"
        Me.Text = "frmLichSuBienDong"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrLichSuHSBienDong1 As prjLichSuHoSoBienDong.ctrLichSuHSBienDong
End Class
