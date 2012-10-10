<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaoCaoTongHop
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
        Me.CtrTongHop1 = New PrjBaoCaoTongHop.CtrTongHop
        Me.SuspendLayout()
        '
        'CtrTongHop1
        '
        Me.CtrTongHop1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTongHop1.Connection = ""
        Me.CtrTongHop1.DenNgay = ""
        Me.CtrTongHop1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrTongHop1.DVHC = Nothing
        Me.CtrTongHop1.Get_MaChu = ""
        Me.CtrTongHop1.Location = New System.Drawing.Point(0, 0)
        Me.CtrTongHop1.MaQuyen = ""
        Me.CtrTongHop1.Name = "CtrTongHop1"
        Me.CtrTongHop1.Size = New System.Drawing.Size(932, 275)
        Me.CtrTongHop1.TabIndex = 0
        Me.CtrTongHop1.TuNgay = ""
        Me.CtrTongHop1.UserName = ""
        '
        'frmBaoCaoTongHop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 275)
        Me.Controls.Add(Me.CtrTongHop1)
        Me.Name = "frmBaoCaoTongHop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BAO CAO TONG HOP"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrTongHop1 As PrjBaoCaoTongHop.CtrTongHop
End Class
