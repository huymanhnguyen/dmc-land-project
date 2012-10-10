Imports DMC.Land.BangMa
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
        Me.CtrlTuDienDoiTuongSuDungDat = New DMC.Land.BangMa.ctrlTuDienDoiTuongSuDungDat
        Me.SuspendLayout()
        '
        'CtrlTuDienDoiTuongSuDungDat
        '
        Me.CtrlTuDienDoiTuongSuDungDat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTuDienDoiTuongSuDungDat.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienDoiTuongSuDungDat.KyHieu = ""
        Me.CtrlTuDienDoiTuongSuDungDat.Location = New System.Drawing.Point(-3, 0)
        Me.CtrlTuDienDoiTuongSuDungDat.MoTa = ""
        Me.CtrlTuDienDoiTuongSuDungDat.Name = "CtrlTuDienDoiTuongSuDungDat"
        Me.CtrlTuDienDoiTuongSuDungDat.Nhom = ""
        Me.CtrlTuDienDoiTuongSuDungDat.Size = New System.Drawing.Size(574, 317)
        Me.CtrlTuDienDoiTuongSuDungDat.TabIndex = 0
        '
        'frmBangMa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 318)
        Me.Controls.Add(Me.CtrlTuDienDoiTuongSuDungDat)
        Me.Name = "frmBangMa"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bang Ma"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienDoiTuongSuDungDat As DMC.Land.BangMa.ctrlTuDienDoiTuongSuDungDat
End Class
