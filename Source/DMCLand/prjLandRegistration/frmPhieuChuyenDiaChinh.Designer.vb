<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhieuChuyenDiaChinh
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
        Me.CtrPhieuChuyenThongTinDiaChinh1 = New prjPhieuChuyenThongTinDiaChinh.ctrPhieuChuyenThongTinDiaChinh
        Me.SuspendLayout()
        '
        'CtrPhieuChuyenThongTinDiaChinh1
        '
        Me.CtrPhieuChuyenThongTinDiaChinh1.Connection = ""
        Me.CtrPhieuChuyenThongTinDiaChinh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrPhieuChuyenThongTinDiaChinh1.Location = New System.Drawing.Point(0, 0)
        Me.CtrPhieuChuyenThongTinDiaChinh1.MaDVHC = ""
        Me.CtrPhieuChuyenThongTinDiaChinh1.MaHoSoCapGCN = ""
        Me.CtrPhieuChuyenThongTinDiaChinh1.Name = "CtrPhieuChuyenThongTinDiaChinh1"
        Me.CtrPhieuChuyenThongTinDiaChinh1.Size = New System.Drawing.Size(779, 593)
        Me.CtrPhieuChuyenThongTinDiaChinh1.TabIndex = 0
        Me.CtrPhieuChuyenThongTinDiaChinh1.TenMaDVHC = Nothing
        '
        'frmPhieuChuyenDiaChinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 593)
        Me.Controls.Add(Me.CtrPhieuChuyenThongTinDiaChinh1)
        Me.Name = "frmPhieuChuyenDiaChinh"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PHIEU CHUYEN THONG TIN DIA CHINH"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrPhieuChuyenThongTinDiaChinh1 As prjPhieuChuyenThongTinDiaChinh.ctrPhieuChuyenThongTinDiaChinh
End Class
