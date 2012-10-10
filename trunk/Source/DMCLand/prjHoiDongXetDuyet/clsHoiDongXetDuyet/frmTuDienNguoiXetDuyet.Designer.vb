<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienNguoiXetDuyet
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
        Me.CtrlTuDienNguoiXetDuyet = New DMC.Land.TuDienCanBoNhiepVu.ctrlTuDienNguoiXetDuyet
        Me.SuspendLayout()
        '
        'CtrlTuDienNguoiXetDuyet
        '
        Me.CtrlTuDienNguoiXetDuyet.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNguoiXetDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlTuDienNguoiXetDuyet.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTuDienNguoiXetDuyet.Ma = ""
        Me.CtrlTuDienNguoiXetDuyet.Name = "CtrlTuDienNguoiXetDuyet"
        Me.CtrlTuDienNguoiXetDuyet.Size = New System.Drawing.Size(650, 428)
        Me.CtrlTuDienNguoiXetDuyet.TabIndex = 0
        '
        'frmTuDienNguoiXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(650, 428)
        Me.Controls.Add(Me.CtrlTuDienNguoiXetDuyet)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTuDienNguoiXetDuyet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tu dien nguoi xet duyet"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNguoiXetDuyet As DMC.Land.TuDienCanBoNhiepVu.ctrlTuDienNguoiXetDuyet
End Class
