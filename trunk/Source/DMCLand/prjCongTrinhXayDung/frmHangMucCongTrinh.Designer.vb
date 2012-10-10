<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHangMucCongTrinh
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
        Me.CtrlHangMucCongTrinh = New DMC.Land.CongTrinhXayDung.ctrlHangMucCongTrinh
        Me.SuspendLayout()
        '
        'CtrlHangMucCongTrinh
        '
        Me.CtrlHangMucCongTrinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlHangMucCongTrinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlHangMucCongTrinh.Location = New System.Drawing.Point(0, 0)
        Me.CtrlHangMucCongTrinh.MaHangMucCongTrinh = ""
        Me.CtrlHangMucCongTrinh.Name = "CtrlHangMucCongTrinh"
        Me.CtrlHangMucCongTrinh.Size = New System.Drawing.Size(638, 295)
        Me.CtrlHangMucCongTrinh.TabIndex = 0
        '
        'frmHangMucCongTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(638, 295)
        Me.Controls.Add(Me.CtrlHangMucCongTrinh)
        Me.Name = "frmHangMucCongTrinh"
        Me.Text = "Hang muc cong trinh"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlHangMucCongTrinh As DMC.Land.CongTrinhXayDung.ctrlHangMucCongTrinh
End Class
