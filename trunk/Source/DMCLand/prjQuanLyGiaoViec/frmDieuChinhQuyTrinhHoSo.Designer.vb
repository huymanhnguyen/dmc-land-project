<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDieuChinhQuyTrinhHoSo
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
        Me.CtrDieuChinh1 = New prjQuanLyGiaoViec.ctrDieuChinh
        Me.SuspendLayout()
        '
        'CtrDieuChinh1
        '
        Me.CtrDieuChinh1.BackColor = System.Drawing.Color.Lavender
        Me.CtrDieuChinh1.ChuSuDung = ""
        Me.CtrDieuChinh1.Conection = ""
        Me.CtrDieuChinh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrDieuChinh1.HoSoCapGCN = ""
        Me.CtrDieuChinh1.Location = New System.Drawing.Point(0, 0)
        Me.CtrDieuChinh1.MaDonViHanhChinh = "0"
        Me.CtrDieuChinh1.MaLoaiHS = Nothing
        Me.CtrDieuChinh1.Name = "CtrDieuChinh1"
        Me.CtrDieuChinh1.Size = New System.Drawing.Size(870, 544)
        Me.CtrDieuChinh1.SoThua = ""
        Me.CtrDieuChinh1.TabIndex = 0
        Me.CtrDieuChinh1.TenLoaiHS = Nothing
        Me.CtrDieuChinh1.ToBanDo = ""
        Me.CtrDieuChinh1.UserName = ""
        '
        'frmDieuChinhQuyTrinhHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 544)
        Me.Controls.Add(Me.CtrDieuChinh1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmDieuChinhQuyTrinhHoSo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DIEU CHINH QUY TRINH QUAN LY NGHIEP VU"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrDieuChinh1 As prjQuanLyGiaoViec.ctrDieuChinh
End Class
