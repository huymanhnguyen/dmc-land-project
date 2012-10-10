<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBangMa
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
        Me.CtrlBangMa = New DMC.Land.BangMa.ctrlTuDienMucDich
        Me.SuspendLayout()
        '
        'CtrlBangMa
        '
        Me.CtrlBangMa.BackColor = System.Drawing.Color.Lavender
        Me.CtrlBangMa.KyHieu = ""
        Me.CtrlBangMa.Location = New System.Drawing.Point(1, 0)
        Me.CtrlBangMa.MoTa = ""
        Me.CtrlBangMa.Name = "CtrlBangMa"
        Me.CtrlBangMa.Size = New System.Drawing.Size(570, 314)
        Me.CtrlBangMa.TabIndex = 0
        '
        'frmBangMa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 315)
        Me.Controls.Add(Me.CtrlBangMa)
        Me.Name = "frmBangMa"
        Me.Text = "frmBangMa"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlBangMa As DMC.Land.BangMa.ctrlTuDienMucDich
End Class
