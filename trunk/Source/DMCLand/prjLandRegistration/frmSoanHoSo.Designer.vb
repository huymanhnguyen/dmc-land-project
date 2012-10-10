<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSoanHoSo
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
        Me.CtrSoanHS1 = New DMC.Land.SoanHoSo.ctrSoanHS
        Me.SuspendLayout()
        '
        'CtrSoanHS1
        '
        Me.CtrSoanHS1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrSoanHS1.Location = New System.Drawing.Point(0, 0)
        Me.CtrSoanHS1.Name = "CtrSoanHS1"
        Me.CtrSoanHS1.Size = New System.Drawing.Size(892, 655)
        Me.CtrSoanHS1.TabIndex = 0
        '
        'frmSoanHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 655)
        Me.Controls.Add(Me.CtrSoanHS1)
        Me.Name = "frmSoanHoSo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOAN HO SO THUA DAT"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrSoanHS1 As DMC.Land.SoanHoSo.ctrSoanHS
End Class
