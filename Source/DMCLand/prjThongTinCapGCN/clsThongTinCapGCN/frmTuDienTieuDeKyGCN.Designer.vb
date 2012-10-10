<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTuDienTieuDeKyGCN
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
        Me.CtrlTuDienTieuDeKyGCN = New prjThietLapThongTinGCN.ctrlTuDienTieuDeKyGCN
        Me.SuspendLayout()
        '
        'CtrlTuDienTieuDeKyGCN
        '
        Me.CtrlTuDienTieuDeKyGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTuDienTieuDeKyGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlTuDienTieuDeKyGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTuDienTieuDeKyGCN.Ma = ""
        Me.CtrlTuDienTieuDeKyGCN.Name = "CtrlTuDienTieuDeKyGCN"
        Me.CtrlTuDienTieuDeKyGCN.Size = New System.Drawing.Size(618, 264)
        Me.CtrlTuDienTieuDeKyGCN.TabIndex = 0
        '
        'frmTuDienTieuDeKyGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(618, 264)
        Me.Controls.Add(Me.CtrlTuDienTieuDeKyGCN)
        Me.Name = "frmTuDienTieuDeKyGCN"
        Me.Text = "Tu dien tieu de ky GCN"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTuDienTieuDeKyGCN As prjThietLapThongTinGCN.ctrlTuDienTieuDeKyGCN
End Class
