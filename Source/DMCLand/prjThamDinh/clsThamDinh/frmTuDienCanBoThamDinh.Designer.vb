<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienCanBoThamDinh
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
        Me.CtrlTuDienNguoiThamDinh = New DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiThamDinh
        Me.SuspendLayout()
        '
        'CtrlTuDienNguoiThamDinh
        '
        Me.CtrlTuDienNguoiThamDinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTuDienNguoiThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNguoiThamDinh.Location = New System.Drawing.Point(-2, 0)
        Me.CtrlTuDienNguoiThamDinh.Ma = ""
        Me.CtrlTuDienNguoiThamDinh.Name = "CtrlTuDienNguoiThamDinh"
        Me.CtrlTuDienNguoiThamDinh.Size = New System.Drawing.Size(656, 423)
        Me.CtrlTuDienNguoiThamDinh.TabIndex = 0
        '
        'frmTuDienCanBoThamDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 424)
        Me.Controls.Add(Me.CtrlTuDienNguoiThamDinh)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTuDienCanBoThamDinh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tu dien can bo tham dinh"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNguoiThamDinh As DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiThamDinh
End Class
