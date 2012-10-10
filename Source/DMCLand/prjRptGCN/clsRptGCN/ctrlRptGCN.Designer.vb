<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRptGCN
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
        Me.crptGCN = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.PrintDialog = New System.Windows.Forms.PrintDialog
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.toolCongCu = New System.Windows.Forms.ToolStrip
        Me.toolCongCuNhanLoaiMauGCN = New System.Windows.Forms.ToolStripLabel
        Me.toolCongCuLoaiMauGCN = New System.Windows.Forms.ToolStripComboBox
        Me.toolCongCuXem = New System.Windows.Forms.ToolStripButton
        Me.toolCongCuIn = New System.Windows.Forms.ToolStripButton
        Me.toolCongCu.SuspendLayout()
        Me.SuspendLayout()
        '
        'crptGCN
        '
        Me.crptGCN.ActiveViewIndex = -1
        Me.crptGCN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crptGCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptGCN.DisplayGroupTree = False
        Me.crptGCN.Location = New System.Drawing.Point(0, 27)
        Me.crptGCN.Name = "crptGCN"
        Me.crptGCN.SelectionFormula = ""
        Me.crptGCN.Size = New System.Drawing.Size(619, 383)
        Me.crptGCN.TabIndex = 2
        Me.crptGCN.ViewTimeSelectionFormula = ""
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'toolCongCu
        '
        Me.toolCongCu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCongCuNhanLoaiMauGCN, Me.toolCongCuLoaiMauGCN, Me.toolCongCuXem, Me.toolCongCuIn})
        Me.toolCongCu.Location = New System.Drawing.Point(0, 0)
        Me.toolCongCu.Name = "toolCongCu"
        Me.toolCongCu.Size = New System.Drawing.Size(619, 25)
        Me.toolCongCu.TabIndex = 6
        Me.toolCongCu.Text = "ToolStrip1"
        '
        'toolCongCuNhanLoaiMauGCN
        '
        Me.toolCongCuNhanLoaiMauGCN.Name = "toolCongCuNhanLoaiMauGCN"
        Me.toolCongCuNhanLoaiMauGCN.Size = New System.Drawing.Size(77, 22)
        Me.toolCongCuNhanLoaiMauGCN.Text = "Loại mẫu GCN:"
        '
        'toolCongCuLoaiMauGCN
        '
        Me.toolCongCuLoaiMauGCN.Items.AddRange(New Object() {"Bản thảo GCN", "Mẫu GCN mặt 1-4", "Mẫu GCN mặt 2-3", "Mẫu GCN mặt 1-4 Hoàn kiếm"})
        Me.toolCongCuLoaiMauGCN.Name = "toolCongCuLoaiMauGCN"
        Me.toolCongCuLoaiMauGCN.Size = New System.Drawing.Size(121, 25)
        '
        'toolCongCuXem
        '
        Me.toolCongCuXem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCongCuXem.Name = "toolCongCuXem"
        Me.toolCongCuXem.Size = New System.Drawing.Size(61, 22)
        Me.toolCongCuXem.Text = "     Xem     "
        '
        'toolCongCuIn
        '
        Me.toolCongCuIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCongCuIn.Name = "toolCongCuIn"
        Me.toolCongCuIn.Size = New System.Drawing.Size(51, 22)
        Me.toolCongCuIn.Text = "     In     "
        '
        'ctrlRptGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.toolCongCu)
        Me.Controls.Add(Me.crptGCN)
        Me.Name = "ctrlRptGCN"
        Me.Size = New System.Drawing.Size(619, 412)
        Me.toolCongCu.ResumeLayout(False)
        Me.toolCongCu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Public WithEvents crptGCN As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public WithEvents toolCongCu As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCongCuNhanLoaiMauGCN As System.Windows.Forms.ToolStripLabel
    Public WithEvents toolCongCuLoaiMauGCN As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolCongCuXem As System.Windows.Forms.ToolStripButton
    Public WithEvents toolCongCuIn As System.Windows.Forms.ToolStripButton

End Class
