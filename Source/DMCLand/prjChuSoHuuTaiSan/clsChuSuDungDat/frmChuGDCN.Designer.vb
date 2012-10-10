<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuGDCN
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
        Me.CtrlChuGDCN = New DMC.Land.Chu.ctrlChuGDCN
        Me.SuspendLayout()
        '
        'CtrlChuGDCN
        '
        Me.CtrlChuGDCN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlChuGDCN.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CtrlChuGDCN.Location = New System.Drawing.Point(-1, -1)
        Me.CtrlChuGDCN.MaChu = ""
        Me.CtrlChuGDCN.Name = "CtrlChuGDCN"
        Me.CtrlChuGDCN.Size = New System.Drawing.Size(697, 398)
        Me.CtrlChuGDCN.TabIndex = 0
        '
        'frmChuGDCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 395)
        Me.Controls.Add(Me.CtrlChuGDCN)
        Me.Name = "frmChuGDCN"
        Me.Text = "Tu dien doi tuong Gia dinh, ca nhan"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlChuGDCN As DMC.Land.Chu.ctrlChuGDCN
End Class
