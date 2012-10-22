<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimKiemHoSo
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
        Me.CrtTimKiemHoSoThuaDat1 = New prjQuanLyGiaoViec.crtTimKiemHoSoThuaDat
        Me.SuspendLayout()
        '
        'CrtTimKiemHoSoThuaDat1
        '
        Me.CrtTimKiemHoSoThuaDat1.BackColor = System.Drawing.Color.Lavender
        Me.CrtTimKiemHoSoThuaDat1.ChuSuDung = ""
        Me.CrtTimKiemHoSoThuaDat1.DanhSachHoSoChon = ""
        Me.CrtTimKiemHoSoThuaDat1.DiaChiThua = ""
        Me.CrtTimKiemHoSoThuaDat1.DienTich = ""
        Me.CrtTimKiemHoSoThuaDat1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtTimKiemHoSoThuaDat1.Location = New System.Drawing.Point(0, 0)
        Me.CrtTimKiemHoSoThuaDat1.MaDonViHanhChinh = ""
        Me.CrtTimKiemHoSoThuaDat1.MaLoaiHS = Nothing
        Me.CrtTimKiemHoSoThuaDat1.NamCapGCN = ""
        Me.CrtTimKiemHoSoThuaDat1.Name = "CrtTimKiemHoSoThuaDat1"
        Me.CrtTimKiemHoSoThuaDat1.NgayLapToTrinh = ""
        Me.CrtTimKiemHoSoThuaDat1.Size = New System.Drawing.Size(914, 572)
        Me.CrtTimKiemHoSoThuaDat1.SoDinhDanh = ""
        Me.CrtTimKiemHoSoThuaDat1.SoThua = ""
        Me.CrtTimKiemHoSoThuaDat1.TabIndex = 0
        Me.CrtTimKiemHoSoThuaDat1.ToBanDo = ""
        '
        'frmTimKiemHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 572)
        Me.Controls.Add(Me.CrtTimKiemHoSoThuaDat1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTimKiemHoSo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIM KIEM HO SO"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CrtTimKiemHoSoThuaDat1 As prjQuanLyGiaoViec.crtTimKiemHoSoThuaDat
End Class
