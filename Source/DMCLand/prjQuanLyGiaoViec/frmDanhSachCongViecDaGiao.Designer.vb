<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachCongViecDaGiao
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboTuDienLuanChuyenHoSo = New System.Windows.Forms.ComboBox
        Me.cmdChiTietHoSo = New System.Windows.Forms.Button
        Me.cmdDieuChinh = New System.Windows.Forms.Button
        Me.GrGhiChu = New System.Windows.Forms.GroupBox
        Me.grdDanhMucHoSo = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdDanhMucHoSo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(965, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DANH SÁCH HỒ SƠ ĐÃ ĐƯỢC GIAO VIỆC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdDanhMucHoSo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboTuDienLuanChuyenHoSo)
        Me.GroupBox1.Controls.Add(Me.cmdChiTietHoSo)
        Me.GroupBox1.Controls.Add(Me.cmdDieuChinh)
        Me.GroupBox1.Controls.Add(Me.GrGhiChu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 488)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Loại hồ sơ quản lý"
        '
        'cboTuDienLuanChuyenHoSo
        '
        Me.cboTuDienLuanChuyenHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTuDienLuanChuyenHoSo.FormattingEnabled = True
        Me.cboTuDienLuanChuyenHoSo.Location = New System.Drawing.Point(102, 19)
        Me.cboTuDienLuanChuyenHoSo.Name = "cboTuDienLuanChuyenHoSo"
        Me.cboTuDienLuanChuyenHoSo.Size = New System.Drawing.Size(249, 21)
        Me.cboTuDienLuanChuyenHoSo.TabIndex = 85
        '
        'cmdChiTietHoSo
        '
        Me.cmdChiTietHoSo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChiTietHoSo.Location = New System.Drawing.Point(465, 18)
        Me.cmdChiTietHoSo.Name = "cmdChiTietHoSo"
        Me.cmdChiTietHoSo.Size = New System.Drawing.Size(102, 21)
        Me.cmdChiTietHoSo.TabIndex = 15
        Me.cmdChiTietHoSo.Text = "Nghiệp vụ hồ sơ"
        Me.cmdChiTietHoSo.UseVisualStyleBackColor = True
        '
        'cmdDieuChinh
        '
        Me.cmdDieuChinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDieuChinh.Location = New System.Drawing.Point(357, 18)
        Me.cmdDieuChinh.Name = "cmdDieuChinh"
        Me.cmdDieuChinh.Size = New System.Drawing.Size(102, 21)
        Me.cmdDieuChinh.TabIndex = 12
        Me.cmdDieuChinh.Text = "Điều chỉnh"
        Me.cmdDieuChinh.UseVisualStyleBackColor = True
        '
        'GrGhiChu
        '
        Me.GrGhiChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrGhiChu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrGhiChu.Location = New System.Drawing.Point(756, 38)
        Me.GrGhiChu.Name = "GrGhiChu"
        Me.GrGhiChu.Size = New System.Drawing.Size(203, 444)
        Me.GrGhiChu.TabIndex = 14
        Me.GrGhiChu.TabStop = False
        '
        'grdDanhMucHoSo
        '
        Me.grdDanhMucHoSo.AllowUserToAddRows = False
        Me.grdDanhMucHoSo.AllowUserToDeleteRows = False
        Me.grdDanhMucHoSo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhMucHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDanhMucHoSo.Location = New System.Drawing.Point(6, 46)
        Me.grdDanhMucHoSo.Name = "grdDanhMucHoSo"
        Me.grdDanhMucHoSo.ReadOnly = True
        Me.grdDanhMucHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDanhMucHoSo.Size = New System.Drawing.Size(744, 436)
        Me.grdDanhMucHoSo.TabIndex = 88
        '
        'frmDanhSachCongViecDaGiao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(965, 513)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmDanhSachCongViecDaGiao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DANH SACH HO SO DA DUOC GIAO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdDanhMucHoSo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChiTietHoSo As System.Windows.Forms.Button
    Friend WithEvents cmdDieuChinh As System.Windows.Forms.Button
    Friend WithEvents GrGhiChu As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTuDienLuanChuyenHoSo As System.Windows.Forms.ComboBox
    Friend WithEvents grdDanhMucHoSo As System.Windows.Forms.DataGridView
End Class
