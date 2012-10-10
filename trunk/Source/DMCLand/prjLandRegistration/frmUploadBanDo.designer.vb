<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadBanDo
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
        Me.CtrToolUploadMap1 = New prjToolUploadMap.ctrToolUploadMap
        Me.SuspendLayout()
        '
        'CtrToolUploadMap1
        '
        Me.CtrToolUploadMap1.BackColor = System.Drawing.Color.Lavender
        Me.CtrToolUploadMap1.Connection = ""
        Me.CtrToolUploadMap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrToolUploadMap1.Location = New System.Drawing.Point(0, 0)
        Me.CtrToolUploadMap1.Name = "CtrToolUploadMap1"
        Me.CtrToolUploadMap1.Size = New System.Drawing.Size(968, 542)
        Me.CtrToolUploadMap1.TabIndex = 0
        '
        'frmUploadBanDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 542)
        Me.Controls.Add(Me.CtrToolUploadMap1)
        Me.Name = "frmUploadBanDo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UPLOAD BAN DO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrToolUploadMap1 As prjToolUploadMap.ctrToolUploadMap
End Class
