<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRptPhieuThamDinh
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.toolCongCu = New System.Windows.Forms.ToolStrip
        Me.toolCongCuNhan = New System.Windows.Forms.ToolStripLabel
        Me.toolLoaiBaoCao = New System.Windows.Forms.ToolStripComboBox
        Me.toolCongCuXem = New System.Windows.Forms.ToolStripButton
        Me.toolCongCuIn = New System.Windows.Forms.ToolStripButton
        Me.toolCongCuSuaBaoCao = New System.Windows.Forms.ToolStripButton
        Me.crptThamDinh = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.toolCongCu.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolCongCu
        '
        Me.toolCongCu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.toolCongCu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCongCuNhan, Me.toolLoaiBaoCao, Me.toolCongCuXem, Me.toolCongCuIn, Me.toolCongCuSuaBaoCao})
        Me.toolCongCu.Location = New System.Drawing.Point(0, 0)
        Me.toolCongCu.Name = "toolCongCu"
        Me.toolCongCu.Size = New System.Drawing.Size(717, 25)
        Me.toolCongCu.TabIndex = 7
        Me.toolCongCu.Text = "Thanh cong cu"
        '
        'toolCongCuNhan
        '
        Me.toolCongCuNhan.Name = "toolCongCuNhan"
        Me.toolCongCuNhan.Size = New System.Drawing.Size(111, 22)
        Me.toolCongCuNhan.Text = "Lựa chọn loại báo cáo"
        '
        'toolLoaiBaoCao
        '
        Me.toolLoaiBaoCao.Items.AddRange(New Object() {"Phiếu thẩm định", "Hồ sơ kỹ thuật"})
        Me.toolLoaiBaoCao.Name = "toolLoaiBaoCao"
        Me.toolLoaiBaoCao.Size = New System.Drawing.Size(121, 25)
        '
        'toolCongCuXem
        '
        Me.toolCongCuXem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCongCuXem.Name = "toolCongCuXem"
        Me.toolCongCuXem.Size = New System.Drawing.Size(61, 22)
        Me.toolCongCuXem.Text = "     Xem     "
        Me.toolCongCuXem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'toolCongCuIn
        '
        Me.toolCongCuIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCongCuIn.Name = "toolCongCuIn"
        Me.toolCongCuIn.Size = New System.Drawing.Size(51, 22)
        Me.toolCongCuIn.Text = "     In     "
        Me.toolCongCuIn.ToolTipText = "     In     "
        '
        'toolCongCuSuaBaoCao
        '
        Me.toolCongCuSuaBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCongCuSuaBaoCao.Name = "toolCongCuSuaBaoCao"
        Me.toolCongCuSuaBaoCao.Size = New System.Drawing.Size(71, 22)
        Me.toolCongCuSuaBaoCao.Text = "Sửa báo cáo"
        '
        'crptThamDinh
        '
        Me.crptThamDinh.ActiveViewIndex = -1
        Me.crptThamDinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crptThamDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptThamDinh.DisplayGroupTree = False
        Me.crptThamDinh.Location = New System.Drawing.Point(3, 28)
        Me.crptThamDinh.Name = "crptThamDinh"
        Me.crptThamDinh.Size = New System.Drawing.Size(712, 336)
        Me.crptThamDinh.TabIndex = 1
        '
        'ctrlRptPhieuThamDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.toolCongCu)
        Me.Controls.Add(Me.crptThamDinh)
        Me.Name = "ctrlRptPhieuThamDinh"
        Me.Size = New System.Drawing.Size(717, 364)
        Me.toolCongCu.ResumeLayout(False)
        Me.toolCongCu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolCongCuNhan As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolLoaiBaoCao As System.Windows.Forms.ToolStripComboBox
    Public WithEvents toolCongCu As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCongCuSuaBaoCao As System.Windows.Forms.ToolStripButton
    Public WithEvents toolCongCuXem As System.Windows.Forms.ToolStripButton
    Public WithEvents toolCongCuIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents crptThamDinh As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
