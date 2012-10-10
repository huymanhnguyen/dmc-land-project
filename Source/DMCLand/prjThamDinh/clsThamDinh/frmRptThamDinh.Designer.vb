<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptThamDinh
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
        Me.CtrlRptPhieuThamDinh = New DMC.Land.RptThamDinh.ctrlRptPhieuThamDinh
        Me.SuspendLayout()
        '
        'CtrlRptPhieuThamDinh
        '
        Me.CtrlRptPhieuThamDinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlRptPhieuThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlRptPhieuThamDinh.Location = New System.Drawing.Point(-2, 0)
        Me.CtrlRptPhieuThamDinh.MaHoSoCapGCN = ""
        Me.CtrlRptPhieuThamDinh.Name = "CtrlRptPhieuThamDinh"
        Me.CtrlRptPhieuThamDinh.Size = New System.Drawing.Size(735, 668)
        Me.CtrlRptPhieuThamDinh.TabIndex = 0
        '
        'frmRptThamDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 666)
        Me.Controls.Add(Me.CtrlRptPhieuThamDinh)
        Me.Name = "frmRptThamDinh"
        Me.Text = "Phieu Tham dinh"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlRptPhieuThamDinh As DMC.Land.RptThamDinh.ctrlRptPhieuThamDinh
End Class
