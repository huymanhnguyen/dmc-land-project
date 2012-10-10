<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinToTrinhQuyetDinh
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
        Me.CtrToTrinhQuyetDinh1 = New prjToTrinhQuyetDinh.ctrToTrinhQuyetDinh
        Me.SuspendLayout()
        '
        'CtrToTrinhQuyetDinh1
        '
        Me.CtrToTrinhQuyetDinh1.BackColor = System.Drawing.Color.Lavender
        Me.CtrToTrinhQuyetDinh1.Connection = ""
        Me.CtrToTrinhQuyetDinh1.Location = New System.Drawing.Point(-1, 0)
        Me.CtrToTrinhQuyetDinh1.MaDVHC = ""
        Me.CtrToTrinhQuyetDinh1.MaHoSoCapGCN = ""
        Me.CtrToTrinhQuyetDinh1.Name = "CtrToTrinhQuyetDinh1"
        Me.CtrToTrinhQuyetDinh1.Size = New System.Drawing.Size(545, 126)
        Me.CtrToTrinhQuyetDinh1.TabIndex = 0
        Me.CtrToTrinhQuyetDinh1.TenMaDVHC = Nothing
        '
        'frmTinToTrinhQuyetDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 127)
        Me.Controls.Add(Me.CtrToTrinhQuyetDinh1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTinToTrinhQuyetDinh"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "IN TO TRINH VA QUYET DINH"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrToTrinhQuyetDinh1 As prjToTrinhQuyetDinh.ctrToTrinhQuyetDinh
End Class
