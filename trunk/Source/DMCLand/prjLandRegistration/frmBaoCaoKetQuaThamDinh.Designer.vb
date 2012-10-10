<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaoCaoKetQuaThamDinh
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
        Me.CtrInBaoCaoKetQuaThamDinh1 = New prjInBaoCaKetQuaThamDinh.ctrInBaoCaoKetQuaThamDinh
        Me.SuspendLayout()
        '
        'CtrInBaoCaoKetQuaThamDinh1
        '
        Me.CtrInBaoCaoKetQuaThamDinh1.Connection = ""
        Me.CtrInBaoCaoKetQuaThamDinh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrInBaoCaoKetQuaThamDinh1.Location = New System.Drawing.Point(0, 0)
        Me.CtrInBaoCaoKetQuaThamDinh1.MaDVHC = ""
        Me.CtrInBaoCaoKetQuaThamDinh1.MaHoSoCapGCN = ""
        Me.CtrInBaoCaoKetQuaThamDinh1.Name = "CtrInBaoCaoKetQuaThamDinh1"
        Me.CtrInBaoCaoKetQuaThamDinh1.Size = New System.Drawing.Size(702, 502)
        Me.CtrInBaoCaoKetQuaThamDinh1.TabIndex = 0
        Me.CtrInBaoCaoKetQuaThamDinh1.TenMaDVHC = Nothing
        '
        'frmBaoCaoKetQuaThamDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 502)
        Me.Controls.Add(Me.CtrInBaoCaoKetQuaThamDinh1)
        Me.Name = "frmBaoCaoKetQuaThamDinh"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BAO CAO KET QUA THAM DINH"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrInBaoCaoKetQuaThamDinh1 As prjInBaoCaKetQuaThamDinh.ctrInBaoCaoKetQuaThamDinh
End Class
