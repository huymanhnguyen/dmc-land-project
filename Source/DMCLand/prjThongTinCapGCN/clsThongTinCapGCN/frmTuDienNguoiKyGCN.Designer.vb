<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienNguoiKyGCN
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
        Me.CtrlTuDienNguoiKyGCN = New DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiKyGCN
        Me.SuspendLayout()
        '
        'CtrlTuDienNguoiKyGCN
        '
        Me.CtrlTuDienNguoiKyGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienNguoiKyGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlTuDienNguoiKyGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTuDienNguoiKyGCN.Ma = ""
        Me.CtrlTuDienNguoiKyGCN.Name = "CtrlTuDienNguoiKyGCN"
        Me.CtrlTuDienNguoiKyGCN.Size = New System.Drawing.Size(660, 401)
        Me.CtrlTuDienNguoiKyGCN.TabIndex = 0
        '
        'frmTuDienNguoiKyGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(660, 401)
        Me.Controls.Add(Me.CtrlTuDienNguoiKyGCN)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTuDienNguoiKyGCN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tu dien nguoi ky GCN"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienNguoiKyGCN As DMC.Land.TuDienCanBoNghiepVu.ctrlTuDienNguoiKyGCN
End Class
