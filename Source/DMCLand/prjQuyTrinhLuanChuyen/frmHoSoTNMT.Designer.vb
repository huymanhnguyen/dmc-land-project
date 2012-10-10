<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoTNMT
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
        Me.dtpTNMT = New System.Windows.Forms.DateTimePicker
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.cmdBCTNNhan = New System.Windows.Forms.Button
        Me.chkDataGridTNMTNhanChuyenVe = New System.Windows.Forms.CheckBox
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.Button25 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkDuDieuKienTNMT = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtLyDoKhongDuDKTNMT = New System.Windows.Forms.TextBox
        Me.cmdCapNhatTNMT = New System.Windows.Forms.Button
        Me.cmdBCTNChuyen = New System.Windows.Forms.Button
        Me.chkdatagridTNMTChuyen = New System.Windows.Forms.CheckBox
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGridPhongTNTra = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTNMTNhanChuyenVe = New System.Windows.Forms.DataGridView
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGridPhongTNNHan = New prjFilterGrid.ctrFilterGrid
        Me.datagridTNMTChuyen = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdHoSoDaChuyen = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid3 = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTheoDoi = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        CType(Me.DataGridTNMTNhanChuyenVe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        CType(Me.datagridTNMTChuyen, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(1015, 557)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtCanBoThuLy)
        Me.TabPage1.Controls.Add(Me.dtpTNMT)
        Me.TabPage1.Controls.Add(Me.GroupBox9)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.GroupBox13)
        Me.TabPage1.Controls.Add(Me.GroupBox12)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1007, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XỬ LÝ HỒ SƠ TẠI PHÒNG TÀI NGUYÊN MÔI TRƯỜNG"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(800, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Cán bộ thụ lý"
        '
        'txtCanBoThuLy
        '
        Me.txtCanBoThuLy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCanBoThuLy.Location = New System.Drawing.Point(801, 59)
        Me.txtCanBoThuLy.Name = "txtCanBoThuLy"
        Me.txtCanBoThuLy.Size = New System.Drawing.Size(204, 20)
        Me.txtCanBoThuLy.TabIndex = 68
        '
        'dtpTNMT
        '
        Me.dtpTNMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTNMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTNMT.Location = New System.Drawing.Point(804, 20)
        Me.dtpTNMT.Name = "dtpTNMT"
        Me.dtpTNMT.Size = New System.Drawing.Size(147, 20)
        Me.dtpTNMT.TabIndex = 67
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.Controls.Add(Me.cmdBCTNNhan)
        Me.GroupBox9.Controls.Add(Me.chkDataGridTNMTNhanChuyenVe)
        Me.GroupBox9.Controls.Add(Me.Button26)
        Me.GroupBox9.Controls.Add(Me.Button24)
        Me.GroupBox9.Controls.Add(Me.Button25)
        Me.GroupBox9.Location = New System.Drawing.Point(797, 308)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(207, 162)
        Me.GroupBox9.TabIndex = 66
        Me.GroupBox9.TabStop = False
        '
        'cmdBCTNNhan
        '
        Me.cmdBCTNNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCTNNhan.ForeColor = System.Drawing.Color.Black
        Me.cmdBCTNNhan.Location = New System.Drawing.Point(7, 105)
        Me.cmdBCTNNhan.Name = "cmdBCTNNhan"
        Me.cmdBCTNNhan.Size = New System.Drawing.Size(189, 23)
        Me.cmdBCTNNhan.TabIndex = 35
        Me.cmdBCTNNhan.Text = "In báo cáo"
        Me.cmdBCTNNhan.UseVisualStyleBackColor = True
        Me.cmdBCTNNhan.Visible = False
        '
        'chkDataGridTNMTNhanChuyenVe
        '
        Me.chkDataGridTNMTNhanChuyenVe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDataGridTNMTNhanChuyenVe.AutoSize = True
        Me.chkDataGridTNMTNhanChuyenVe.BackColor = System.Drawing.Color.Transparent
        Me.chkDataGridTNMTNhanChuyenVe.Location = New System.Drawing.Point(7, 134)
        Me.chkDataGridTNMTNhanChuyenVe.Name = "chkDataGridTNMTNhanChuyenVe"
        Me.chkDataGridTNMTNhanChuyenVe.Size = New System.Drawing.Size(96, 17)
        Me.chkDataGridTNMTNhanChuyenVe.TabIndex = 32
        Me.chkDataGridTNMTNhanChuyenVe.Text = "Chọn/Bỏ chọn"
        Me.chkDataGridTNMTNhanChuyenVe.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button26.BackColor = System.Drawing.Color.Lavender
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button26.ForeColor = System.Drawing.Color.Black
        Me.Button26.Location = New System.Drawing.Point(7, 76)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(189, 23)
        Me.Button26.TabIndex = 18
        Me.Button26.Text = "Chuyển về VP nhà đất"
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button24.ForeColor = System.Drawing.Color.Black
        Me.Button24.Location = New System.Drawing.Point(7, 47)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(189, 23)
        Me.Button24.TabIndex = 20
        Me.Button24.Text = "Hồ sơ đã trả về"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'Button25
        '
        Me.Button25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button25.ForeColor = System.Drawing.Color.Black
        Me.Button25.Location = New System.Drawing.Point(7, 18)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(189, 23)
        Me.Button25.TabIndex = 19
        Me.Button25.Text = "Tìm và lấy hồ sơ trả về"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkDuDieuKienTNMT)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtLyDoKhongDuDKTNMT)
        Me.GroupBox3.Controls.Add(Me.cmdCapNhatTNMT)
        Me.GroupBox3.Controls.Add(Me.cmdBCTNChuyen)
        Me.GroupBox3.Controls.Add(Me.chkdatagridTNMTChuyen)
        Me.GroupBox3.Controls.Add(Me.Button22)
        Me.GroupBox3.Controls.Add(Me.Button23)
        Me.GroupBox3.Location = New System.Drawing.Point(797, 103)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(207, 191)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        '
        'chkDuDieuKienTNMT
        '
        Me.chkDuDieuKienTNMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDuDieuKienTNMT.AutoSize = True
        Me.chkDuDieuKienTNMT.BackColor = System.Drawing.Color.Transparent
        Me.chkDuDieuKienTNMT.Location = New System.Drawing.Point(7, 10)
        Me.chkDuDieuKienTNMT.Name = "chkDuDieuKienTNMT"
        Me.chkDuDieuKienTNMT.Size = New System.Drawing.Size(128, 17)
        Me.chkDuDieuKienTNMT.TabIndex = 49
        Me.chkDuDieuKienTNMT.Text = "Đủ ĐK/Không đủ ĐK"
        Me.chkDuDieuKienTNMT.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(6, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Lý do không đủ điều kiện"
        '
        'txtLyDoKhongDuDKTNMT
        '
        Me.txtLyDoKhongDuDKTNMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongDuDKTNMT.Location = New System.Drawing.Point(7, 52)
        Me.txtLyDoKhongDuDKTNMT.Name = "txtLyDoKhongDuDKTNMT"
        Me.txtLyDoKhongDuDKTNMT.Size = New System.Drawing.Size(188, 20)
        Me.txtLyDoKhongDuDKTNMT.TabIndex = 47
        '
        'cmdCapNhatTNMT
        '
        Me.cmdCapNhatTNMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhatTNMT.ForeColor = System.Drawing.Color.Black
        Me.cmdCapNhatTNMT.Location = New System.Drawing.Point(6, 79)
        Me.cmdCapNhatTNMT.Name = "cmdCapNhatTNMT"
        Me.cmdCapNhatTNMT.Size = New System.Drawing.Size(188, 23)
        Me.cmdCapNhatTNMT.TabIndex = 46
        Me.cmdCapNhatTNMT.Text = "Cập nhật"
        Me.cmdCapNhatTNMT.UseVisualStyleBackColor = True
        '
        'cmdBCTNChuyen
        '
        Me.cmdBCTNChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCTNChuyen.ForeColor = System.Drawing.Color.Black
        Me.cmdBCTNChuyen.Location = New System.Drawing.Point(7, 166)
        Me.cmdBCTNChuyen.Name = "cmdBCTNChuyen"
        Me.cmdBCTNChuyen.Size = New System.Drawing.Size(188, 23)
        Me.cmdBCTNChuyen.TabIndex = 34
        Me.cmdBCTNChuyen.Text = "In báo cáo"
        Me.cmdBCTNChuyen.UseVisualStyleBackColor = True
        '
        'chkdatagridTNMTChuyen
        '
        Me.chkdatagridTNMTChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkdatagridTNMTChuyen.AutoSize = True
        Me.chkdatagridTNMTChuyen.BackColor = System.Drawing.Color.Transparent
        Me.chkdatagridTNMTChuyen.Location = New System.Drawing.Point(7, 195)
        Me.chkdatagridTNMTChuyen.Name = "chkdatagridTNMTChuyen"
        Me.chkdatagridTNMTChuyen.Size = New System.Drawing.Size(96, 17)
        Me.chkdatagridTNMTChuyen.TabIndex = 31
        Me.chkdatagridTNMTChuyen.Text = "Chọn/Bỏ chọn"
        Me.chkdatagridTNMTChuyen.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button22.BackColor = System.Drawing.Color.Lavender
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button22.ForeColor = System.Drawing.Color.Black
        Me.Button22.Location = New System.Drawing.Point(7, 137)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(188, 23)
        Me.Button22.TabIndex = 15
        Me.Button22.Text = "Chuyển lên UB thẩm định"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button23.ForeColor = System.Drawing.Color.Black
        Me.Button23.Location = New System.Drawing.Point(7, 108)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(188, 23)
        Me.Button23.TabIndex = 14
        Me.Button23.Text = "Tìm và lấy hồ sơ chuyển lên"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(797, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Ngày báo cáo"
        '
        'GroupBox13
        '
        Me.GroupBox13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox13.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox13.Controls.Add(Me.CtrFilterGridPhongTNTra)
        Me.GroupBox13.Controls.Add(Me.DataGridTNMTNhanChuyenVe)
        Me.GroupBox13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox13.Location = New System.Drawing.Point(9, 308)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(780, 220)
        Me.GroupBox13.TabIndex = 63
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Danh sách hồ sơ nhận chuyển về"
        '
        'CtrFilterGridPhongTNTra
        '
        Me.CtrFilterGridPhongTNTra.AutoScroll = True
        Me.CtrFilterGridPhongTNTra.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridPhongTNTra.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridPhongTNTra.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridPhongTNTra.MydataTable = Nothing
        Me.CtrFilterGridPhongTNTra.MyGrid = Nothing
        Me.CtrFilterGridPhongTNTra.Name = "CtrFilterGridPhongTNTra"
        Me.CtrFilterGridPhongTNTra.Size = New System.Drawing.Size(774, 57)
        Me.CtrFilterGridPhongTNTra.TabIndex = 30
        '
        'DataGridTNMTNhanChuyenVe
        '
        Me.DataGridTNMTNhanChuyenVe.AllowUserToAddRows = False
        Me.DataGridTNMTNhanChuyenVe.AllowUserToDeleteRows = False
        Me.DataGridTNMTNhanChuyenVe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridTNMTNhanChuyenVe.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGridTNMTNhanChuyenVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTNMTNhanChuyenVe.Location = New System.Drawing.Point(6, 79)
        Me.DataGridTNMTNhanChuyenVe.Name = "DataGridTNMTNhanChuyenVe"
        Me.DataGridTNMTNhanChuyenVe.ReadOnly = True
        Me.DataGridTNMTNhanChuyenVe.Size = New System.Drawing.Size(768, 135)
        Me.DataGridTNMTNhanChuyenVe.TabIndex = 17
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox12.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox12.Controls.Add(Me.CtrFilterGridPhongTNNHan)
        Me.GroupBox12.Controls.Add(Me.datagridTNMTChuyen)
        Me.GroupBox12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox12.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(781, 286)
        Me.GroupBox12.TabIndex = 62
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Danh sách hồ sơ VP thẩm định chuyển lên"
        '
        'CtrFilterGridPhongTNNHan
        '
        Me.CtrFilterGridPhongTNNHan.AutoScroll = True
        Me.CtrFilterGridPhongTNNHan.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridPhongTNNHan.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridPhongTNNHan.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridPhongTNNHan.MydataTable = Nothing
        Me.CtrFilterGridPhongTNNHan.MyGrid = Nothing
        Me.CtrFilterGridPhongTNNHan.Name = "CtrFilterGridPhongTNNHan"
        Me.CtrFilterGridPhongTNNHan.Size = New System.Drawing.Size(775, 61)
        Me.CtrFilterGridPhongTNNHan.TabIndex = 30
        '
        'datagridTNMTChuyen
        '
        Me.datagridTNMTChuyen.AllowUserToAddRows = False
        Me.datagridTNMTChuyen.AllowUserToDeleteRows = False
        Me.datagridTNMTChuyen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridTNMTChuyen.BackgroundColor = System.Drawing.Color.Lavender
        Me.datagridTNMTChuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridTNMTChuyen.Location = New System.Drawing.Point(6, 83)
        Me.datagridTNMTChuyen.Name = "datagridTNMTChuyen"
        Me.datagridTNMTChuyen.ReadOnly = True
        Me.datagridTNMTChuyen.Size = New System.Drawing.Size(774, 197)
        Me.datagridTNMTChuyen.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdHoSoDaChuyen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1007, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "HỒ SƠ ĐÃ CHUYỂN LÊN ỦY BAN QUẬN"
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
        Me.grdHoSoDaChuyen.Size = New System.Drawing.Size(1001, 525)
        Me.grdHoSoDaChuyen.TabIndex = 18
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button12)
        Me.TabPage3.Controls.Add(Me.GroupBox15)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1007, 531)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "THEO DÕI HỒ SƠ"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(849, 6)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(155, 23)
        Me.Button12.TabIndex = 32
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
        Me.GroupBox15.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(837, 516)
        Me.GroupBox15.TabIndex = 31
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
        Me.CtrFilterGrid3.Size = New System.Drawing.Size(831, 67)
        Me.CtrFilterGrid3.TabIndex = 26
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
        Me.DataGridTheoDoi.Size = New System.Drawing.Size(831, 421)
        Me.DataGridTheoDoi.TabIndex = 0
        '
        'frmHoSoTNMT
        '
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1015, 557)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmHoSoTNMT"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.DataGridTNMTNhanChuyenVe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.datagridTNMTChuyen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdHoSoDaChuyen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        CType(Me.DataGridTheoDoi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCanBoThuLy As System.Windows.Forms.TextBox
    Friend WithEvents dtpTNMT As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBCTNNhan As System.Windows.Forms.Button
    Friend WithEvents chkDataGridTNMTNhanChuyenVe As System.Windows.Forms.CheckBox
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuDieuKienTNMT As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKhongDuDKTNMT As System.Windows.Forms.TextBox
    Friend WithEvents cmdCapNhatTNMT As System.Windows.Forms.Button
    Friend WithEvents cmdBCTNChuyen As System.Windows.Forms.Button
    Friend WithEvents chkdatagridTNMTChuyen As System.Windows.Forms.CheckBox
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridPhongTNTra As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTNMTNhanChuyenVe As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridPhongTNNHan As prjFilterGrid.ctrFilterGrid
    Friend WithEvents datagridTNMTChuyen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdHoSoDaChuyen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid3 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTheoDoi As System.Windows.Forms.DataGridView

End Class
