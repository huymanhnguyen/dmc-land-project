<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoUB
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCanBoThuLy = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDuDKUB = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLyDoKhongDuDieuKienUB = New System.Windows.Forms.TextBox
        Me.cmdCapNhatUB = New System.Windows.Forms.Button
        Me.cmdBCUBChuyen = New System.Windows.Forms.Button
        Me.chkdatagridUBThamDinh = New System.Windows.Forms.CheckBox
        Me.Button28 = New System.Windows.Forms.Button
        Me.Button29 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtpUB = New System.Windows.Forms.DateTimePicker
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGridUBNhan = New prjFilterGrid.ctrFilterGrid
        Me.datagridUBThamDinh = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdHoSoDaChuyen = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid3 = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTheoDoi = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.datagridUBThamDinh, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtCanBoThuLy)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.dtpUB)
        Me.TabPage1.Controls.Add(Me.GroupBox14)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(971, 522)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XỬ LÝ HỒ SƠ TẠI ỦY BAN"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(734, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Cán bộ thụ lý"
        '
        'txtCanBoThuLy
        '
        Me.txtCanBoThuLy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCanBoThuLy.Location = New System.Drawing.Point(735, 70)
        Me.txtCanBoThuLy.Name = "txtCanBoThuLy"
        Me.txtCanBoThuLy.Size = New System.Drawing.Size(219, 20)
        Me.txtCanBoThuLy.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkDuDKUB)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLyDoKhongDuDieuKienUB)
        Me.GroupBox1.Controls.Add(Me.cmdCapNhatUB)
        Me.GroupBox1.Controls.Add(Me.cmdBCUBChuyen)
        Me.GroupBox1.Controls.Add(Me.chkdatagridUBThamDinh)
        Me.GroupBox1.Controls.Add(Me.Button28)
        Me.GroupBox1.Controls.Add(Me.Button29)
        Me.GroupBox1.Location = New System.Drawing.Point(732, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 258)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'chkDuDKUB
        '
        Me.chkDuDKUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDuDKUB.AutoSize = True
        Me.chkDuDKUB.BackColor = System.Drawing.Color.Transparent
        Me.chkDuDKUB.Location = New System.Drawing.Point(6, 19)
        Me.chkDuDKUB.Name = "chkDuDKUB"
        Me.chkDuDKUB.Size = New System.Drawing.Size(128, 17)
        Me.chkDuDKUB.TabIndex = 6
        Me.chkDuDKUB.Text = "Đủ ĐK/Không đủ ĐK"
        Me.chkDuDKUB.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(5, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Lý do không đủ điều kiện"
        '
        'txtLyDoKhongDuDieuKienUB
        '
        Me.txtLyDoKhongDuDieuKienUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongDuDieuKienUB.Location = New System.Drawing.Point(6, 55)
        Me.txtLyDoKhongDuDieuKienUB.Name = "txtLyDoKhongDuDieuKienUB"
        Me.txtLyDoKhongDuDieuKienUB.Size = New System.Drawing.Size(218, 20)
        Me.txtLyDoKhongDuDieuKienUB.TabIndex = 8
        '
        'cmdCapNhatUB
        '
        Me.cmdCapNhatUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhatUB.ForeColor = System.Drawing.Color.Black
        Me.cmdCapNhatUB.Location = New System.Drawing.Point(5, 82)
        Me.cmdCapNhatUB.Name = "cmdCapNhatUB"
        Me.cmdCapNhatUB.Size = New System.Drawing.Size(218, 23)
        Me.cmdCapNhatUB.TabIndex = 9
        Me.cmdCapNhatUB.Text = "Cập nhật"
        Me.cmdCapNhatUB.UseVisualStyleBackColor = True
        '
        'cmdBCUBChuyen
        '
        Me.cmdBCUBChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCUBChuyen.ForeColor = System.Drawing.Color.Black
        Me.cmdBCUBChuyen.Location = New System.Drawing.Point(5, 170)
        Me.cmdBCUBChuyen.Name = "cmdBCUBChuyen"
        Me.cmdBCUBChuyen.Size = New System.Drawing.Size(218, 23)
        Me.cmdBCUBChuyen.TabIndex = 12
        Me.cmdBCUBChuyen.Text = "In báo cáo"
        Me.cmdBCUBChuyen.UseVisualStyleBackColor = True
        '
        'chkdatagridUBThamDinh
        '
        Me.chkdatagridUBThamDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkdatagridUBThamDinh.AutoSize = True
        Me.chkdatagridUBThamDinh.BackColor = System.Drawing.Color.Transparent
        Me.chkdatagridUBThamDinh.Location = New System.Drawing.Point(6, 199)
        Me.chkdatagridUBThamDinh.Name = "chkdatagridUBThamDinh"
        Me.chkdatagridUBThamDinh.Size = New System.Drawing.Size(96, 17)
        Me.chkdatagridUBThamDinh.TabIndex = 13
        Me.chkdatagridUBThamDinh.Text = "Chọn/Bỏ chọn"
        Me.chkdatagridUBThamDinh.UseVisualStyleBackColor = False
        '
        'Button28
        '
        Me.Button28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button28.BackColor = System.Drawing.Color.Lavender
        Me.Button28.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button28.ForeColor = System.Drawing.Color.Black
        Me.Button28.Location = New System.Drawing.Point(5, 140)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(218, 24)
        Me.Button28.TabIndex = 11
        Me.Button28.Text = "Trả hồ sơ về phòng TNMT"
        Me.Button28.UseVisualStyleBackColor = False
        '
        'Button29
        '
        Me.Button29.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button29.ForeColor = System.Drawing.Color.Black
        Me.Button29.Location = New System.Drawing.Point(6, 111)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(218, 23)
        Me.Button29.TabIndex = 10
        Me.Button29.Text = "Tìm và lấy hồ sơ chuyển lên"
        Me.Button29.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(738, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Ngày báo cáo"
        '
        'dtpUB
        '
        Me.dtpUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpUB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUB.Location = New System.Drawing.Point(737, 21)
        Me.dtpUB.Name = "dtpUB"
        Me.dtpUB.Size = New System.Drawing.Size(217, 20)
        Me.dtpUB.TabIndex = 3
        '
        'GroupBox14
        '
        Me.GroupBox14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox14.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox14.Controls.Add(Me.CtrFilterGridUBNhan)
        Me.GroupBox14.Controls.Add(Me.datagridUBThamDinh)
        Me.GroupBox14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox14.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(723, 509)
        Me.GroupBox14.TabIndex = 57
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Danh sách hồ sơ VP thẩm định chuyển lên"
        '
        'CtrFilterGridUBNhan
        '
        Me.CtrFilterGridUBNhan.AutoScroll = True
        Me.CtrFilterGridUBNhan.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridUBNhan.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridUBNhan.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridUBNhan.MydataTable = Nothing
        Me.CtrFilterGridUBNhan.MyGrid = Nothing
        Me.CtrFilterGridUBNhan.Name = "CtrFilterGridUBNhan"
        Me.CtrFilterGridUBNhan.Size = New System.Drawing.Size(717, 60)
        Me.CtrFilterGridUBNhan.TabIndex = 0
        '
        'datagridUBThamDinh
        '
        Me.datagridUBThamDinh.AllowUserToAddRows = False
        Me.datagridUBThamDinh.AllowUserToDeleteRows = False
        Me.datagridUBThamDinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridUBThamDinh.BackgroundColor = System.Drawing.Color.Lavender
        Me.datagridUBThamDinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridUBThamDinh.Location = New System.Drawing.Point(6, 76)
        Me.datagridUBThamDinh.Name = "datagridUBThamDinh"
        Me.datagridUBThamDinh.ReadOnly = True
        Me.datagridUBThamDinh.Size = New System.Drawing.Size(716, 427)
        Me.datagridUBThamDinh.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdHoSoDaChuyen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(971, 522)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DANH SÁCH HỒ SƠ CHUYỂN VỀ PHÒNG TNMT"
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
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(971, 522)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "THEO DÕI HỒ SƠ"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(813, 19)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(155, 23)
        Me.Button12.TabIndex = 2
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
        Me.GroupBox15.TabIndex = 27
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Danh sách hồ sơ"
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
        Me.CtrFilterGrid3.TabIndex = 0
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
        Me.DataGridTheoDoi.TabIndex = 1
        '
        'frmHoSoUB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(979, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmHoSoUB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HO SO CHUYEN LEN UY BAN THAM DINH"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        CType(Me.datagridUBThamDinh, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuDKUB As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKhongDuDieuKienUB As System.Windows.Forms.TextBox
    Friend WithEvents cmdCapNhatUB As System.Windows.Forms.Button
    Friend WithEvents cmdBCUBChuyen As System.Windows.Forms.Button
    Friend WithEvents chkdatagridUBThamDinh As System.Windows.Forms.CheckBox
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpUB As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridUBNhan As prjFilterGrid.ctrFilterGrid
    Friend WithEvents datagridUBThamDinh As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCanBoThuLy As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid3 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTheoDoi As System.Windows.Forms.DataGridView
    Friend WithEvents grdHoSoDaChuyen As System.Windows.Forms.DataGridView
End Class
