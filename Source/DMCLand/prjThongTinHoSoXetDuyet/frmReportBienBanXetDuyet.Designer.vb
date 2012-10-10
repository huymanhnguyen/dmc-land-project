Imports DMC.Land.BienBanXetDuyetCapGCN

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBienBanXetDuyet
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
        Me.CtrBienBanXetDuyetCapGCN1 = New prjInBienBanXetDuyetHoSoCapGCN.ctrBienBanXetDuyetHoSoCapGCN
        Me.SuspendLayout()
        '
        'CtrBienBanXetDuyetCapGCN1
        '
        Me.CtrBienBanXetDuyetCapGCN1.Conection = ""
        Me.CtrBienBanXetDuyetCapGCN1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrBienBanXetDuyetCapGCN1.Location = New System.Drawing.Point(0, 0)
        Me.CtrBienBanXetDuyetCapGCN1.MaDVHC = ""
        Me.CtrBienBanXetDuyetCapGCN1.MaHoSoCapGCN = ""
        Me.CtrBienBanXetDuyetCapGCN1.Name = "CtrBienBanXetDuyetCapGCN1"
        Me.CtrBienBanXetDuyetCapGCN1.Size = New System.Drawing.Size(829, 552)
        Me.CtrBienBanXetDuyetCapGCN1.TabIndex = 0
        '
        'frmReportBienBanXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 552)
        Me.Controls.Add(Me.CtrBienBanXetDuyetCapGCN1)
        Me.Name = "frmReportBienBanXetDuyet"
        Me.Text = "BIEN BAN XET DUYET"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrBienBanXetDuyetCapGCN1 As prjInBienBanXetDuyetHoSoCapGCN.ctrBienBanXetDuyetHoSoCapGCN
End Class
