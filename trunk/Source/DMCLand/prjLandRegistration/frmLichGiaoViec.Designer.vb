<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLichGiaoViec
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
        Me.CtrQuanLyGiaoViec1 = New prjQuanLyGiaoViec.ctrQuanLyGiaoViec
        Me.SuspendLayout()
        '
        'CtrQuanLyGiaoViec1
        '
        Me.CtrQuanLyGiaoViec1.BackColor = System.Drawing.Color.Lavender
        Me.CtrQuanLyGiaoViec1.Conection = ""
        Me.CtrQuanLyGiaoViec1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrQuanLyGiaoViec1.Location = New System.Drawing.Point(0, 0)
        Me.CtrQuanLyGiaoViec1.MaDonViHanhChinh = "0"
        Me.CtrQuanLyGiaoViec1.Name = "CtrQuanLyGiaoViec1"
        Me.CtrQuanLyGiaoViec1.Size = New System.Drawing.Size(731, 496)
        Me.CtrQuanLyGiaoViec1.TabIndex = 0
        Me.CtrQuanLyGiaoViec1.UserName = ""
        '
        'frmLichGiaoViec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 496)
        Me.Controls.Add(Me.CtrQuanLyGiaoViec1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLichGiaoViec"
        Me.Text = "frmLichGiaoViec"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrQuanLyGiaoViec1 As prjQuanLyGiaoViec.ctrQuanLyGiaoViec
End Class
