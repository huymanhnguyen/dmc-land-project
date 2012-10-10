Imports DMC.Land.BangMa
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
        Me.CtrlTuDienNguonGoc = New DMC.Land.BangMa.ctrlTuDienNguonGoc
        Me.SuspendLayout()
        '
        'CtrlTuDienNguonGoc
        '
        Me.CtrlTuDienNguonGoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTuDienNguonGoc.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNguonGoc.KyHieu = ""
        Me.CtrlTuDienNguonGoc.Location = New System.Drawing.Point(-1, 1)
        Me.CtrlTuDienNguonGoc.MoTa = ""
        Me.CtrlTuDienNguonGoc.Name = "CtrlTuDienNguonGoc"
        Me.CtrlTuDienNguonGoc.Size = New System.Drawing.Size(571, 315)
        Me.CtrlTuDienNguonGoc.TabIndex = 0
        '
        'frmBangMa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 316)
        Me.Controls.Add(Me.CtrlTuDienNguonGoc)
        Me.Name = "frmBangMa"
        Me.Text = "Bang Ma"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNguonGoc As DMC.Land.BangMa.ctrlTuDienNguonGoc
End Class
