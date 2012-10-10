<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHinhDangThua
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
        Me.CtrHinhDangThua1 = New prjHinhDangThua.ctrHinhDangThua
        Me.SuspendLayout()
        '
        'CtrHinhDangThua1
        '
        Me.CtrHinhDangThua1.Connection = ""
        Me.CtrHinhDangThua1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrHinhDangThua1.Location = New System.Drawing.Point(0, 0)
        Me.CtrHinhDangThua1.MaDonViHanhChinh = ""
        Me.CtrHinhDangThua1.MaThuaDat = ""
        Me.CtrHinhDangThua1.Name = "CtrHinhDangThua1"
        Me.CtrHinhDangThua1.Size = New System.Drawing.Size(275, 195)
        Me.CtrHinhDangThua1.TabIndex = 0
        '
        'frmHinhDangThua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 195)
        Me.Controls.Add(Me.CtrHinhDangThua1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmHinhDangThua"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrHinhDangThua1 As prjHinhDangThua.ctrHinhDangThua
End Class
