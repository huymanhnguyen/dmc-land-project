<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoLanhDaoVPDK
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCanBoThuLy = New System.Windows.Forms.TextBox
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.chkDuDKVPTHamDinh = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLyDoKhongDuDKVPTHamDinh = New System.Windows.Forms.TextBox
        Me.cmdCapNhatVPThamDinh = New System.Windows.Forms.Button
        Me.cmdBCVPThamDInhChuyen = New System.Windows.Forms.Button
        Me.chkgridVPThamDinhChuyenLen = New System.Windows.Forms.CheckBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpVPThamDinh = New System.Windows.Forms.DateTimePicker
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.gridVPThamDinhChuyenLen = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdHoSoDaChuyen = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.DataGridTheoDoi = New System.Windows.Forms.DataGridView
        Me.CtrFilterGridVpNhaDatThamDinh = New prjFilterGrid.ctrFilterGrid
        Me.CtrFilterGrid3 = New prjFilterGrid.ctrFilterGrid
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.gridVPThamDinhChuyenLen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdHoSoDaChuyen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DataGridTheoDoi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(979, 548)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtCanBoThuLy)
        Me.TabPage1.Controls.Add(Me.GroupBox16)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.dtpVPThamDinh)
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(971, 522)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XỬ LÝ HỒ SƠ CỦA LÃNH ĐẠO VĂN PHÒNG"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(756, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Cán bộ thụ lý"
        '
        'txtCanBoThuLy
        '
        Me.txtCanBoThuLy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCanBoThuLy.Location = New System.Drawing.Point(757, 60)
        Me.txtCanBoThuLy.Name = "txtCanBoThuLy"
        Me.txtCanBoThuLy.Size = New System.Drawing.Size(204, 20)
        Me.txtCanBoThuLy.TabIndex = 54
        '
        'GroupBox16
        '
        Me.GroupBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox16.Controls.Add(Me.chkDuDKVPTHamDinh)
        Me.GroupBox16.Controls.Add(Me.Label4)
        Me.GroupBox16.Controls.Add(Me.txtLyDoKhongDuDKVPTHamDinh)
        Me.GroupBox16.Controls.Add(Me.cmdCapNhatVPThamDinh)
        Me.GroupBox16.Controls.Add(Me.cmdBCVPThamDInhChuyen)
        Me.GroupBox16.Controls.Add(Me.chkgridVPThamDinhChuyenLen)
        Me.GroupBox16.Controls.Add(Me.Button10)
        Me.GroupBox16.Controls.Add(Me.Button11)
        Me.GroupBox16.Location = New System.Drawing.Point(753, 86)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(217, 232)
        Me.GroupBox16.TabIndex = 52
        Me.GroupBox16.TabStop = False
        '
        'chkDuDKVPTHamDinh
        '
        Me.chkDuDKVPTHamDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDuDKVPTHamDinh.AutoSize = True
        Me.chkDuDKVPTHamDinh.BackColor = System.Drawing.Color.Transparent
        Me.chkDuDKVPTHamDinh.Location = New System.Drawing.Point(7, 19)
        Me.chkDuDKVPTHamDinh.Name = "chkDuDKVPTHamDinh"
        Me.chkDuDKVPTHamDinh.Size = New System.Drawing.Size(128, 17)
        Me.chkDuDKVPTHamDinh.TabIndex = 45
        Me.chkDuDKVPTHamDinh.Text = "Đủ ĐK/Không đủ ĐK"
        Me.chkDuDKVPTHamDinh.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Lý do không đủ điều kiện"
        '
        'txtLyDoKhongDuDKVPTHamDinh
        '
        Me.txtLyDoKhongDuDKVPTHamDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongDuDKVPTHamDinh.Location = New System.Drawing.Point(6, 55)
        Me.txtLyDoKhongDuDKVPTHamDinh.Name = "txtLyDoKhongDuDKVPTHamDinh"
        Me.txtLyDoKhongDuDKVPTHamDinh.Size = New System.Drawing.Size(202, 20)
        Me.txtLyDoKhongDuDKVPTHamDinh.TabIndex = 43
        '
        'cmdCapNhatVPThamDinh
        '
        Me.cmdCapNhatVPThamDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhatVPThamDinh.ForeColor = System.Drawing.Color.Black
        Me.cmdCapNhatVPThamDinh.Location = New System.Drawing.Point(5, 82)
        Me.cmdCapNhatVPThamDinh.Name = "cmdCapNhatVPThamDinh"
        Me.cmdCapNhatVPThamDinh.Size = New System.Drawing.Size(202, 23)
        Me.cmdCapNhatVPThamDinh.TabIndex = 42
        Me.cmdCapNhatVPThamDinh.Text = "Cập nhật"
        Me.cmdCapNhatVPThamDinh.UseVisualStyleBackColor = True
        '
        'cmdBCVPThamDInhChuyen
        '
        Me.cmdBCVPThamDInhChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCVPThamDInhChuyen.ForeColor = System.Drawing.Color.Black
        Me.cmdBCVPThamDInhChuyen.Location = New System.Drawing.Point(4, 169)
        Me.cmdBCVPThamDInhChuyen.Name = "cmdBCVPThamDInhChuyen"
        Me.cmdBCVPThamDInhChuyen.Size = New System.Drawing.Size(202, 23)
        Me.cmdBCVPThamDInhChuyen.TabIndex = 33
        Me.cmdBCVPThamDInhChuyen.Text = "In báo cáo"
        Me.cmdBCVPThamDInhChuyen.UseVisualStyleBackColor = True
        '
        'chkgridVPThamDinhChuyenLen
        '
        Me.chkgridVPThamDinhChuyenLen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkgridVPThamDinhChuyenLen.AutoSize = True
        Me.chkgridVPThamDinhChuyenLen.BackColor = System.Drawing.Color.Transparent
        Me.chkgridVPThamDinhChuyenLen.Location = New System.Drawing.Point(4, 198)
        Me.chkgridVPThamDinhChuyenLen.Name = "chkgridVPThamDinhChuyenLen"
        Me.chkgridVPThamDinhChuyenLen.Size = New System.Drawing.Size(96, 17)
        Me.chkgridVPThamDinhChuyenLen.TabIndex = 31
        Me.chkgridVPThamDinhChuyenLen.Text = "Chọn/Bỏ chọn"
        Me.chkgridVPThamDinhChuyenLen.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.BackColor = System.Drawing.Color.Lavender
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button10.ForeColor = System.Drawing.Color.Black
        Me.Button10.Location = New System.Drawing.Point(4, 140)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(202, 23)
        Me.Button10.TabIndex = 15
        Me.Button10.Text = "Chuyển lên phòng TNMT"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button11.ForeColor = System.Drawing.Color.Black
        Me.Button11.Location = New System.Drawing.Point(4, 111)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(202, 23)
        Me.Button11.TabIndex = 14
        Me.Button11.Text = "Tìm và lấy hồ sơ chuyển lên"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(759, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Ngày báo cáo"
        '
        'dtpVPThamDinh
        '
        Me.dtpVPThamDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVPThamDinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVPThamDinh.Location = New System.Drawing.Point(762, 22)
        Me.dtpVPThamDinh.Name = "dtpVPThamDinh"
        Me.dtpVPThamDinh.Size = New System.Drawing.Size(197, 20)
        Me.dtpVPThamDinh.TabIndex = 50
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox8.Controls.Add(Me.CtrFilterGridVpNhaDatThamDinh)
        Me.GroupBox8.Controls.Add(Me.gridVPThamDinhChuyenLen)
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox8.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(741, 513)
        Me.GroupBox8.TabIndex = 49
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Danh sách hồ sơ VP nhà đất chuyển lên"
        '
        'gridVPThamDinhChuyenLen
        '
        Me.gridVPThamDinhChuyenLen.AllowUserToAddRows = False
        Me.gridVPThamDinhChuyenLen.AllowUserToDeleteRows = False
        Me.gridVPThamDinhChuyenLen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridVPThamDinhChuyenLen.BackgroundColor = System.Drawing.Color.Lavender
        Me.gridVPThamDinhChuyenLen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVPThamDinhChuyenLen.Location = New System.Drawing.Point(6, 80)
        Me.gridVPThamDinhChuyenLen.Name = "gridVPThamDinhChuyenLen"
        Me.gridVPThamDinhChuyenLen.ReadOnly = True
        Me.gridVPThamDinhChuyenLen.Size = New System.Drawing.Size(729, 427)
        Me.gridVPThamDinhChuyenLen.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdHoSoDaChuyen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(971, 522)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "HỒ SƠ ĐÃ CHUYỂN LÊN PHÒNG TNMT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdHoSoDaChuyen
        '
        Me.grdHoSoDaChuyen.AllowUserToAddRows = False
        Me.grdHoSoDaChuyen.AllowUserToDeleteRows = False
        Me.grdHoSoDaChuyen.BackgroundColor = System.Drawing.Color.Lavender
        Me.grdHoSoDaChuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHoSoDaChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHoSoDaChuyen.Location = New System.Drawing.Point(3, 3)
        Me.grdHoSoDaChuyen.Name = "grdHoSoDaChuyen"
        Me.grdHoSoDaChuyen.ReadOnly = True
        Me.grdHoSoDaChuyen.Size = New System.Drawing.Size(965, 516)
        Me.grdHoSoDaChuyen.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button12)
        Me.TabPage3.Controls.Add(Me.GroupBox15)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(971, 522)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "HỒ SƠ THEO DÕI"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(813, 19)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(155, 23)
        Me.Button12.TabIndex = 30
        Me.Button12.Text = "Tìm và lấy hồ sơ"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox15.Controls.Add(Me.CtrFilterGrid3)
        Me.GroupBox15.Controls.Add(Me.DataGridTheoDoi)
        Me.GroupBox15.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(804, 516)
        Me.GroupBox15.TabIndex = 29
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Danh sách hồ sơ"
        '
        'DataGridTheoDoi
        '
        Me.DataGridTheoDoi.AllowUserToAddRows = False
        Me.DataGridTheoDoi.AllowUserToDeleteRows = False
        Me.DataGridTheoDoi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridTheoDoi.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGridTheoDoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTheoDoi.Location = New System.Drawing.Point(3, 89)
        Me.DataGridTheoDoi.Name = "DataGridTheoDoi"
        Me.DataGridTheoDoi.ReadOnly = True
        Me.DataGridTheoDoi.Size = New System.Drawing.Size(798, 421)
        Me.DataGridTheoDoi.TabIndex = 0
        '
        'CtrFilterGridVpNhaDatThamDinh
        '
        Me.CtrFilterGridVpNhaDatThamDinh.AutoScroll = True
        Me.CtrFilterGridVpNhaDatThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridVpNhaDatThamDinh.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridVpNhaDatThamDinh.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridVpNhaDatThamDinh.MydataTable = Nothing
        Me.CtrFilterGridVpNhaDatThamDinh.MyGrid = Nothing
        Me.CtrFilterGridVpNhaDatThamDinh.Name = "CtrFilterGridVpNhaDatThamDinh"
        Me.CtrFilterGridVpNhaDatThamDinh.Size = New System.Drawing.Size(735, 58)
        Me.CtrFilterGridVpNhaDatThamDinh.TabIndex = 29
        '
        'CtrFilterGrid3
        '
        Me.CtrFilterGrid3.AutoScroll = True
        Me.CtrFilterGrid3.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid3.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGrid3.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGrid3.MydataTable = Nothing
        Me.CtrFilterGrid3.MyGrid = Nothing
        Me.CtrFilterGrid3.Name = "CtrFilterGrid3"
        Me.CtrFilterGrid3.Size = New System.Drawing.Size(798, 67)
        Me.CtrFilterGrid3.TabIndex = 26
        '
        'frmHoSoLanhDaoVPDK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmHoSoLanhDaoVPDK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HO SO CHUYEN LEN VAN PHONG THAM DINH"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.gridVPThamDinhChuyenLen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdHoSoDaChuyen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        CType(Me.DataGridTheoDoi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuDKVPTHamDinh As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKhongDuDKVPTHamDinh As System.Windows.Forms.TextBox
    Friend WithEvents cmdCapNhatVPThamDinh As System.Windows.Forms.Button
    Friend WithEvents cmdBCVPThamDInhChuyen As System.Windows.Forms.Button
    Friend WithEvents chkgridVPThamDinhChuyenLen As System.Windows.Forms.CheckBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpVPThamDinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridVpNhaDatThamDinh As prjFilterGrid.ctrFilterGrid
    Friend WithEvents gridVPThamDinhChuyenLen As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCanBoThuLy As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid3 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTheoDoi As System.Windows.Forms.DataGridView
    Friend WithEvents grdHoSoDaChuyen As System.Windows.Forms.DataGridView
End Class
