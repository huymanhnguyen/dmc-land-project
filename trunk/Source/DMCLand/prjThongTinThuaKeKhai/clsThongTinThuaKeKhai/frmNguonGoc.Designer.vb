<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNguonGoc
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
        Me.CtrlNguonGoc = New DMC.Land.NguonGoc.ctrlNguonGoc
        Me.SuspendLayout()
        '
        'CtrlNguonGoc
        '
        Me.CtrlNguonGoc.BackColor = System.Drawing.Color.Lavender
        Me.CtrlNguonGoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlNguonGoc.Location = New System.Drawing.Point(0, 0)
        Me.CtrlNguonGoc.Name = "CtrlNguonGoc"
        Me.CtrlNguonGoc.Size = New System.Drawing.Size(607, 302)
        Me.CtrlNguonGoc.TabIndex = 0
        '
        'frmNguonGoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(607, 302)
        Me.Controls.Add(Me.CtrlNguonGoc)
        Me.Name = "frmNguonGoc"
        Me.Text = "Chi tiet Nguon goc su dung"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlNguonGoc As DMC.Land.NguonGoc.ctrlNguonGoc
End Class
