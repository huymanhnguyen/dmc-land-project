<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienCanBoPheDuyet
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
        Me.CtrlTuDienNguoiPheDuyet = New DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiPheDuyet
        Me.SuspendLayout()
        '
        'CtrlTuDienNguoiPheDuyet
        '
        Me.CtrlTuDienNguoiPheDuyet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTuDienNguoiPheDuyet.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNguoiPheDuyet.Location = New System.Drawing.Point(0, -1)
        Me.CtrlTuDienNguoiPheDuyet.Ma = ""
        Me.CtrlTuDienNguoiPheDuyet.Name = "CtrlTuDienNguoiPheDuyet"
        Me.CtrlTuDienNguoiPheDuyet.Size = New System.Drawing.Size(652, 426)
        Me.CtrlTuDienNguoiPheDuyet.TabIndex = 0
        '
        'frmTuDienCanBoPheDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 424)
        Me.Controls.Add(Me.CtrlTuDienNguoiPheDuyet)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTuDienCanBoPheDuyet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tu dien can bo Phe duyet"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNguoiPheDuyet As DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiPheDuyet
End Class
