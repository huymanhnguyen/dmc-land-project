<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInDanhSachToTrinh
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
        Me.CtrInToTrinh1 = New DMC.Land.InToTrinh.ctrInToTrinh
        Me.SuspendLayout()
        '
        'CtrInToTrinh1
        '
        Me.CtrInToTrinh1.BackColor = System.Drawing.Color.Lavender
        Me.CtrInToTrinh1.Conection = "Server=DMC-SVR\MAP;Database=georgetown;User ID=sa;Password=1"
        Me.CtrInToTrinh1.Location = New System.Drawing.Point(-1, -1)
        Me.CtrInToTrinh1.MaDVHC = "100241"
        Me.CtrInToTrinh1.MaHoSoCapGCN = ""
        Me.CtrInToTrinh1.Name = "CtrInToTrinh1"
        Me.CtrInToTrinh1.NgayTrinhPhuong = ""
        Me.CtrInToTrinh1.Size = New System.Drawing.Size(800, 299)
        Me.CtrInToTrinh1.SoToTrinh = ""
        Me.CtrInToTrinh1.TabIndex = 0
        '
        'frmInDanhSachToTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 297)
        Me.Controls.Add(Me.CtrInToTrinh1)
        Me.Name = "frmInDanhSachToTrinh"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IN DANH SACH TO TRINH"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrInToTrinh1 As DMC.Land.InToTrinh.ctrInToTrinh
End Class
