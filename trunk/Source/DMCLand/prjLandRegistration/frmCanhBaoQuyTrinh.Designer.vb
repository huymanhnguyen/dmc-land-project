<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCanhBaoQuyTrinh
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
        Me.CtrCanhBaoQuyTrinhGiaoViec1 = New prjQuanLyGiaoViec.ctrCanhBaoQuyTrinhGiaoViec
        Me.SuspendLayout()
        '
        'CtrCanhBaoQuyTrinhGiaoViec1
        '
        Me.CtrCanhBaoQuyTrinhGiaoViec1.Conection = ""
        Me.CtrCanhBaoQuyTrinhGiaoViec1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrCanhBaoQuyTrinhGiaoViec1.Location = New System.Drawing.Point(0, 0)
        Me.CtrCanhBaoQuyTrinhGiaoViec1.MaDonViHanhChinh = "0"
        Me.CtrCanhBaoQuyTrinhGiaoViec1.Name = "CtrCanhBaoQuyTrinhGiaoViec1"
        Me.CtrCanhBaoQuyTrinhGiaoViec1.Size = New System.Drawing.Size(823, 487)
        Me.CtrCanhBaoQuyTrinhGiaoViec1.TabIndex = 0
        '
        'frmCanhBaoQuyTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 487)
        Me.Controls.Add(Me.CtrCanhBaoQuyTrinhGiaoViec1)
        Me.Name = "frmCanhBaoQuyTrinh"
        Me.Text = "CANH BAO QUY TRINH QUAN LY THOI GIAN CUA HO SO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrCanhBaoQuyTrinhGiaoViec1 As prjQuanLyGiaoViec.ctrCanhBaoQuyTrinhGiaoViec
End Class
