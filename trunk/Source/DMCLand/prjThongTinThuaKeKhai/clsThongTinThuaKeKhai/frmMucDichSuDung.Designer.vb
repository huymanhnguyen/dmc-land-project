<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMucDichSuDung
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
        Me.CtrlMucDich = New DMC.Land.MucDich.ctrlMucDich
        Me.SuspendLayout()
        '
        'CtrlMucDich
        '
        Me.CtrlMucDich.BackColor = System.Drawing.Color.Lavender
        Me.CtrlMucDich.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlMucDich.Location = New System.Drawing.Point(0, 0)
        Me.CtrlMucDich.Name = "CtrlMucDich"
        Me.CtrlMucDich.Size = New System.Drawing.Size(686, 306)
        Me.CtrlMucDich.TabIndex = 0
        '
        'frmMucDichSuDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(686, 306)
        Me.Controls.Add(Me.CtrlMucDich)
        Me.Name = "frmMucDichSuDung"
        Me.Text = "Chi tiet Muc dich su dung"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlMucDich As DMC.Land.MucDich.ctrlMucDich
End Class
