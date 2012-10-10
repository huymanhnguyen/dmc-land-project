<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuTCDN
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
        Me.CtrlChuTCDN = New DMC.Land.Chu.ctrlChuTCDN
        Me.SuspendLayout()
        '
        'CtrlChuTCDN
        '
        Me.CtrlChuTCDN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlChuTCDN.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CtrlChuTCDN.Location = New System.Drawing.Point(1, 1)
        Me.CtrlChuTCDN.MaChu = ""
        Me.CtrlChuTCDN.Name = "CtrlChuTCDN"
        Me.CtrlChuTCDN.Size = New System.Drawing.Size(678, 352)
        Me.CtrlChuTCDN.TabIndex = 0
        '
        'frmChuTCDN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 352)
        Me.Controls.Add(Me.CtrlChuTCDN)
        Me.Name = "frmChuTCDN"
        Me.Text = "Tu dien doi tuong To chuc, doanh nghiep"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlChuTCDN As DMC.Land.Chu.ctrlChuTCDN
End Class
