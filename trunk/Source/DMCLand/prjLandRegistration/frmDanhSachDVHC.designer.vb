Imports DMC.Land.QuanTriHeThong.DonViHanhChinh
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachDVHC
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
        Me.UcListDVHC1 = New DMC.Land.QuanTriHeThong.DonViHanhChinh.ucListDVHC
        Me.SuspendLayout()
        '
        'UcListDVHC1
        '
        Me.UcListDVHC1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcListDVHC1.BackColor = System.Drawing.Color.Lavender
        Me.UcListDVHC1.Get_ArrDVHC = Nothing
        Me.UcListDVHC1.Get_CurrDVHC = 0
        Me.UcListDVHC1.Get_MaQuyen = 0
        Me.UcListDVHC1.Get_SqlCon = Nothing
        Me.UcListDVHC1.Location = New System.Drawing.Point(-1, 1)
        Me.UcListDVHC1.Name = "UcListDVHC1"
        Me.UcListDVHC1.Size = New System.Drawing.Size(247, 232)
        Me.UcListDVHC1.TabIndex = 0
        Me.UcListDVHC1.TrangThai = "0"
        '
        'frmDanhSachDVHC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 233)
        Me.Controls.Add(Me.UcListDVHC1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDanhSachDVHC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Don vi hanh chinh"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcListDVHC1 As ucListDVHC
End Class
