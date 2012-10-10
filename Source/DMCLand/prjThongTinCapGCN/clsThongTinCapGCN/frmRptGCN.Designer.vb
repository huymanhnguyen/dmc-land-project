<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGCN
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
        Me.CtrlRptGCN = New DMC.Land.RptGCN.ctrlRptGCN
        Me.SuspendLayout()
        '
        'CtrlRptGCN
        '
        Me.CtrlRptGCN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlRptGCN.BackColor = System.Drawing.SystemColors.Control
        Me.CtrlRptGCN.Location = New System.Drawing.Point(-1, -1)
        Me.CtrlRptGCN.MaHoSoCapGCN = ""
        Me.CtrlRptGCN.Name = "CtrlRptGCN"
        Me.CtrlRptGCN.Size = New System.Drawing.Size(776, 499)
        Me.CtrlRptGCN.TabIndex = 0
        '
        'frmRptGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 498)
        Me.Controls.Add(Me.CtrlRptGCN)
        Me.Name = "frmRptGCN"
        Me.Text = "Giay chung nhan quyen su dung dat va so huu tai san tren dat"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlRptGCN As DMC.Land.RptGCN.ctrlRptGCN
End Class
