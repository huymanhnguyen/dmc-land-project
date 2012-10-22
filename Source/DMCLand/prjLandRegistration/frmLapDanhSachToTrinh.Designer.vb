<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapDanhSachToTrinh
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
        Me.CtrToTrinh1 = New DMC.Land.GroupToTrinhPhuong.ctrToTrinh
        Me.SuspendLayout()
        '
        'CtrToTrinh1
        '
        Me.CtrToTrinh1.BackColor = System.Drawing.Color.Lavender
        Me.CtrToTrinh1.Conection = ""
        Me.CtrToTrinh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrToTrinh1.Location = New System.Drawing.Point(0, 0)
        Me.CtrToTrinh1.MaDVHC = ""
        Me.CtrToTrinh1.MaHoSoCapGCN = ""
        Me.CtrToTrinh1.MaToTrinh = ""
        Me.CtrToTrinh1.Name = "CtrToTrinh1"
        Me.CtrToTrinh1.NgayTrinh = ""
        Me.CtrToTrinh1.Size = New System.Drawing.Size(800, 615)
        Me.CtrToTrinh1.SoToTrinh = ""
        Me.CtrToTrinh1.TabIndex = 0
        '
        'frmLapDanhSachToTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 615)
        Me.Controls.Add(Me.CtrToTrinh1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLapDanhSachToTrinh"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAP DANH SACH TO TRINH"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrToTrinh1 As DMC.Land.GroupToTrinhPhuong.ctrToTrinh
End Class
