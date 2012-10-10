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
        Me.CtrlTuDienNghiaVuTaiChinh = New DMC.Land.BangMa.ctrlTuDienNghiaVuTaiChinh
        Me.SuspendLayout()
        '
        'CtrlTuDienNghiaVuTaiChinh
        '
        Me.CtrlTuDienNghiaVuTaiChinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTuDienNghiaVuTaiChinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNghiaVuTaiChinh.KyHieu = ""
        Me.CtrlTuDienNghiaVuTaiChinh.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTuDienNghiaVuTaiChinh.MoTa = ""
        Me.CtrlTuDienNghiaVuTaiChinh.Name = "CtrlTuDienNghiaVuTaiChinh"
        Me.CtrlTuDienNghiaVuTaiChinh.Size = New System.Drawing.Size(571, 315)
        Me.CtrlTuDienNghiaVuTaiChinh.TabIndex = 0
        '
        'frmBangMa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 315)
        Me.Controls.Add(Me.CtrlTuDienNghiaVuTaiChinh)
        Me.Name = "frmBangMa"
        Me.Text = "Bang tu dien"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNghiaVuTaiChinh As DMC.Land.BangMa.ctrlTuDienNghiaVuTaiChinh
End Class
