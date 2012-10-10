<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraCuu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraCuu))
        Me.CtrlTraCuu = New DMC.Land.ChuHoSoCapGCN.ctrlTraCuu
        Me.SuspendLayout()
        '
        'CtrlTraCuu
        '
        Me.CtrlTraCuu.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTraCuu.Connection = ""
        Me.CtrlTraCuu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlTraCuu.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTraCuu.Name = "CtrlTraCuu"
        Me.CtrlTraCuu.Nhom = ""
        Me.CtrlTraCuu.Size = New System.Drawing.Size(665, 432)
        Me.CtrlTraCuu.TabIndex = 0
        '
        'frmTraCuu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(665, 432)
        Me.Controls.Add(Me.CtrlTraCuu)
        Me.Name = "frmTraCuu"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTraCuu As DMC.Land.ChuHoSoCapGCN.ctrlTraCuu
End Class
