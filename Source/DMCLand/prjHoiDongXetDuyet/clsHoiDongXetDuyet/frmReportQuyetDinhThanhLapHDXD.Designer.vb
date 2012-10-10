<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportQuyetDinhThanhLapHDXD
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
        Me.CtrQuyetDinhThanhLapHoiDong1 = New DMC.Land.RptHoiDongXetDuyet.ctrQuyetDinhThanhLapHoiDong
        Me.SuspendLayout()
        '
        'CtrQuyetDinhThanhLapHoiDong1
        '
        Me.CtrQuyetDinhThanhLapHoiDong1.Conection = ""
        Me.CtrQuyetDinhThanhLapHoiDong1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrQuyetDinhThanhLapHoiDong1.Location = New System.Drawing.Point(0, 0)
        Me.CtrQuyetDinhThanhLapHoiDong1.MaDVHC = ""
        Me.CtrQuyetDinhThanhLapHoiDong1.MaHoSoCapGCN = ""
        Me.CtrQuyetDinhThanhLapHoiDong1.Name = "CtrQuyetDinhThanhLapHoiDong1"
        Me.CtrQuyetDinhThanhLapHoiDong1.Size = New System.Drawing.Size(971, 670)
        Me.CtrQuyetDinhThanhLapHoiDong1.TabIndex = 0
        '
        'frmReportQuyetDinhThanhLapHDXD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 670)
        Me.Controls.Add(Me.CtrQuyetDinhThanhLapHoiDong1)
        Me.Name = "frmReportQuyetDinhThanhLapHDXD"
        Me.Text = "QUYET DINH THANH LAP HOI DONG XET DUYET"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrQuyetDinhThanhLapHoiDong1 As DMC.Land.RptHoiDongXetDuyet.ctrQuyetDinhThanhLapHoiDong
End Class
