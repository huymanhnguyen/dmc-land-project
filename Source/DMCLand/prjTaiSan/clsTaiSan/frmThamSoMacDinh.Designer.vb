<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThamSoMacDinh
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
        Me.CtrThamSoMacDinh1 = New prjTuDienThamSoMacDinh.ctrThamSoMacDinh
        Me.SuspendLayout()
        '
        'CtrThamSoMacDinh1
        '
        Me.CtrThamSoMacDinh1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrThamSoMacDinh1.Location = New System.Drawing.Point(0, 0)
        Me.CtrThamSoMacDinh1.MoTa = ""
        Me.CtrThamSoMacDinh1.Name = "CtrThamSoMacDinh1"
        Me.CtrThamSoMacDinh1.Size = New System.Drawing.Size(616, 408)
        Me.CtrThamSoMacDinh1.TabIndex = 0
        Me.CtrThamSoMacDinh1.Ten = ""
        '
        'frmThamSoMacDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 408)
        Me.Controls.Add(Me.CtrThamSoMacDinh1)
        Me.Name = "frmThamSoMacDinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "THAM SO MAC DINH"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrThamSoMacDinh1 As prjTuDienThamSoMacDinh.ctrThamSoMacDinh
End Class
