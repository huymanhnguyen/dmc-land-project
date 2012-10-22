<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrCanhBaoQuyTrinhGiaoViec
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
        Me.cmdDieuChinh = New System.Windows.Forms.Button
        Me.GrGhiChu = New System.Windows.Forms.GroupBox
        Me.cmdChiTietHoSo = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboTuDienLuanChuyenHoSo = New System.Windows.Forms.ComboBox
        Me.grdDanhMucHoSo = New System.Windows.Forms.DataGridView
        CType(Me.grdDanhMucHoSo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDieuChinh
        '
        Me.cmdDieuChinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDieuChinh.Location = New System.Drawing.Point(3, 424)
        Me.cmdDieuChinh.Name = "cmdDieuChinh"
        Me.cmdDieuChinh.Size = New System.Drawing.Size(102, 29)
        Me.cmdDieuChinh.TabIndex = 3
        Me.cmdDieuChinh.Text = "Điều chỉnh"
        Me.cmdDieuChinh.UseVisualStyleBackColor = True
        '
        'GrGhiChu
        '
        Me.GrGhiChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrGhiChu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrGhiChu.Location = New System.Drawing.Point(517, 39)
        Me.GrGhiChu.Name = "GrGhiChu"
        Me.GrGhiChu.Size = New System.Drawing.Size(203, 382)
        Me.GrGhiChu.TabIndex = 10
        Me.GrGhiChu.TabStop = False
        '
        'cmdChiTietHoSo
        '
        Me.cmdChiTietHoSo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChiTietHoSo.Location = New System.Drawing.Point(111, 424)
        Me.cmdChiTietHoSo.Name = "cmdChiTietHoSo"
        Me.cmdChiTietHoSo.Size = New System.Drawing.Size(102, 29)
        Me.cmdChiTietHoSo.TabIndex = 4
        Me.cmdChiTietHoSo.Text = "Nghiệp vụ hồ sơ"
        Me.cmdChiTietHoSo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Loại hồ sơ quản lý"
        '
        'cboTuDienLuanChuyenHoSo
        '
        Me.cboTuDienLuanChuyenHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTuDienLuanChuyenHoSo.FormattingEnabled = True
        Me.cboTuDienLuanChuyenHoSo.Location = New System.Drawing.Point(111, 12)
        Me.cboTuDienLuanChuyenHoSo.Name = "cboTuDienLuanChuyenHoSo"
        Me.cboTuDienLuanChuyenHoSo.Size = New System.Drawing.Size(249, 21)
        Me.cboTuDienLuanChuyenHoSo.TabIndex = 1
        '
        'grdDanhMucHoSo
        '
        Me.grdDanhMucHoSo.AllowUserToAddRows = False
        Me.grdDanhMucHoSo.AllowUserToDeleteRows = False
        Me.grdDanhMucHoSo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhMucHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhMucHoSo.Location = New System.Drawing.Point(3, 51)
        Me.grdDanhMucHoSo.Name = "grdDanhMucHoSo"
        Me.grdDanhMucHoSo.ReadOnly = True
        Me.grdDanhMucHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDanhMucHoSo.Size = New System.Drawing.Size(510, 360)
        Me.grdDanhMucHoSo.TabIndex = 2
        '
        'ctrCanhBaoQuyTrinhGiaoViec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.grdDanhMucHoSo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboTuDienLuanChuyenHoSo)
        Me.Controls.Add(Me.cmdChiTietHoSo)
        Me.Controls.Add(Me.cmdDieuChinh)
        Me.Controls.Add(Me.GrGhiChu)
        Me.Name = "ctrCanhBaoQuyTrinhGiaoViec"
        Me.Size = New System.Drawing.Size(720, 456)
        CType(Me.grdDanhMucHoSo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDieuChinh As System.Windows.Forms.Button
    Friend WithEvents GrGhiChu As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChiTietHoSo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTuDienLuanChuyenHoSo As System.Windows.Forms.ComboBox
    Friend WithEvents grdDanhMucHoSo As System.Windows.Forms.DataGridView
End Class
