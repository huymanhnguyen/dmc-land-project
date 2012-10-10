<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongBaoKhongDuDKCapGCN
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
        Me.CtrKhongDuDKCapGCN1 = New DMC.Land.InThongBaoCapGCN.CtrKhongDuDKCapGCN
        Me.SuspendLayout()
        '
        'CtrKhongDuDKCapGCN1
        '
        Me.CtrKhongDuDKCapGCN1.Conection = ""
        Me.CtrKhongDuDKCapGCN1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrKhongDuDKCapGCN1.DVHC = ""
        Me.CtrKhongDuDKCapGCN1.Location = New System.Drawing.Point(0, 0)
        Me.CtrKhongDuDKCapGCN1.MaHoSoCapGCN = Nothing
        Me.CtrKhongDuDKCapGCN1.Name = "CtrKhongDuDKCapGCN1"
        Me.CtrKhongDuDKCapGCN1.NgayThongBao = ""
        Me.CtrKhongDuDKCapGCN1.Size = New System.Drawing.Size(880, 385)
        Me.CtrKhongDuDKCapGCN1.TabIndex = 0
        '
        'frmThongBaoKhongDuDKCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 385)
        Me.Controls.Add(Me.CtrKhongDuDKCapGCN1)
        Me.Name = "frmThongBaoKhongDuDKCapGCN"
        Me.Text = "frmThongBaoKhongDuDKCapGCN"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrKhongDuDKCapGCN1 As DMC.Land.InThongBaoCapGCN.CtrKhongDuDKCapGCN
End Class
