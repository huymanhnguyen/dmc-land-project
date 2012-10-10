<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuCQNN
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
        Me.CtrlChuCQNN = New DMC.Land.Chu.ctrlChuCQNN
        Me.SuspendLayout()
        '
        'CtrlChuCQNN
        '
        Me.CtrlChuCQNN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlChuCQNN.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CtrlChuCQNN.Location = New System.Drawing.Point(1, 1)
        Me.CtrlChuCQNN.MaChu = ""
        Me.CtrlChuCQNN.Name = "CtrlChuCQNN"
        Me.CtrlChuCQNN.Size = New System.Drawing.Size(730, 321)
        Me.CtrlChuCQNN.TabIndex = 0
        '
        'frmChuCQNN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 321)
        Me.Controls.Add(Me.CtrlChuCQNN)
        Me.Name = "frmChuCQNN"
        Me.Text = "Tu dien doi tuong co quan nha nuoc"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlChuCQNN As DMC.Land.Chu.ctrlChuCQNN
End Class
