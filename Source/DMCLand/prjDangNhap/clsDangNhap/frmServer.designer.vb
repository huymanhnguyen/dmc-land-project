Imports DMC.Land.QuanTriHeThong.Server
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
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
        Me.UcSerVer1 = New DMC.Land.QuanTriHeThong.Server.ucSerVer
        Me.SuspendLayout()
        '
        'UcSerVer1
        '
        Me.UcSerVer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcSerVer1.BackColor = System.Drawing.Color.Lavender
        Me.UcSerVer1.Get_CoSoDuLieu = Nothing
        Me.UcSerVer1.Get_CoSoDuLieuQuan = Nothing
        Me.UcSerVer1.Get_MayChu = Nothing
        Me.UcSerVer1.Get_sqlConnect = Nothing
        Me.UcSerVer1.Get_Ten = Nothing
        Me.UcSerVer1.Location = New System.Drawing.Point(2, 2)
        Me.UcSerVer1.Name = "UcSerVer1"
        Me.UcSerVer1.Pass = Nothing
        Me.UcSerVer1.Size = New System.Drawing.Size(375, 297)
        Me.UcSerVer1.TabIndex = 0
        Me.UcSerVer1.UserId = Nothing
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(381, 296)
        Me.Controls.Add(Me.UcSerVer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAU HINH KET NOI MAY CHU"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents UcSerVer1 As DMC.Land.QuanTriHeThong.Server.ucSerVer
End Class
