<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoVPDK
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
        Me.datagridHoSoDaChuyenVeVPNhaDat = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCanBoThuLy = New System.Windows.Forms.TextBox
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.cmdBCVPNhan = New System.Windows.Forms.Button
        Me.chkDaTagridVpNhaDatNhanLai = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.GroupBox17 = New System.Windows.Forms.GroupBox
        Me.chkDuDieuKienVP = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLyDoKHongDuDKVP = New System.Windows.Forms.TextBox
        Me.cmdCapNhatVP = New System.Windows.Forms.Button
        Me.cmdBCVPChuyen = New System.Windows.Forms.Button
        Me.chkdatagridvpnhan = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpVanPhong = New System.Windows.Forms.DateTimePicker
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGridVpNhaDatTra = New prjFilterGrid.ctrFilterGrid
        Me.DaTagridVpNhaDatNhanLai = New System.Windows.Forms.DataGridView
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGridVpNhaDatNhan = New prjFilterGrid.ctrFilterGrid
        Me.datagridvpnhan = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTheoDoi = New System.Windows.Forms.DataGridView
        CType(Me.datagridHoSoDaChuyenVeVPNhaDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DaTagridVpNhaDatNhanLai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.datagridvpnhan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DataGridTheoDoi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datagridHoSoDaChuyenVeVPNhaDat
        '
        Me.datagridHoSoDaChuyenVeVPNhaDat.AllowUserToAddRows = False
        Me.datagridHoSoDaChuyenVeVPNhaDat.BackgroundColor = System.Drawing.Color.Lavender
        Me.datagridHoSoDaChuyenVeVPNhaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridHoSoDaChuyenVeVPNhaDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridHoSoDaChuyenVeVPNhaDat.Location = New System.Drawing.Point(3, 3)
        Me.datagridHoSoDaChuyenVeVPNhaDat.Name = "datagridHoSoDaChuyenVeVPNhaDat"
        Me.datagridHoSoDaChuyenVeVPNhaDat.Size = New System.Drawing.Size(965, 516)
        Me.datagridHoSoDaChuyenVeVPNhaDat.TabIndex = 0
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
        Me.TabPage1.Controls.Add(Me.GroupBox18)
        Me.TabPage1.Controls.Add(Me.GroupBox17)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.dtpVanPhong)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(971, 522)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XỬ LÝ HỒ SƠ TẠI VĂN PHÒNG"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(742, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Cán bộ thụ lý"
        '
        'txtCanBoThuLy
        '
        Me.txtCanBoThuLy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCanBoThuLy.Location = New System.Drawing.Point(743, 60)
        Me.txtCanBoThuLy.Name = "txtCanBoThuLy"
        Me.txtCanBoThuLy.Size = New System.Drawing.Size(211, 20)
        Me.txtCanBoThuLy.TabIndex = 52
        '
        'GroupBox18
        '
        Me.GroupBox18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox18.Controls.Add(Me.cmdBCVPNhan)
        Me.GroupBox18.Controls.Add(Me.chkDaTagridVpNhaDatNhanLai)
        Me.GroupBox18.Controls.Add(Me.Button4)
        Me.GroupBox18.Controls.Add(Me.Button5)
        Me.GroupBox18.Controls.Add(Me.Button8)
        Me.GroupBox18.Location = New System.Drawing.Point(734, 308)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(231, 161)
        Me.GroupBox18.TabIndex = 51
        Me.GroupBox18.TabStop = False
        '
        'cmdBCVPNhan
        '
        Me.cmdBCVPNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCVPNhan.ForeColor = System.Drawing.Color.Black
        Me.cmdBCVPNhan.Location = New System.Drawing.Point(8, 109)
        Me.cmdBCVPNhan.Name = "cmdBCVPNhan"
        Me.cmdBCVPNhan.Size = New System.Drawing.Size(216, 23)
        Me.cmdBCVPNhan.TabIndex = 34
        Me.cmdBCVPNhan.Text = "In báo cáo"
        Me.cmdBCVPNhan.UseVisualStyleBackColor = True
        Me.cmdBCVPNhan.Visible = False
        '
        'chkDaTagridVpNhaDatNhanLai
        '
        Me.chkDaTagridVpNhaDatNhanLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDaTagridVpNhaDatNhanLai.AutoSize = True
        Me.chkDaTagridVpNhaDatNhanLai.BackColor = System.Drawing.Color.Transparent
        Me.chkDaTagridVpNhaDatNhanLai.Location = New System.Drawing.Point(11, 138)
        Me.chkDaTagridVpNhaDatNhanLai.Name = "chkDaTagridVpNhaDatNhanLai"
        Me.chkDaTagridVpNhaDatNhanLai.Size = New System.Drawing.Size(96, 17)
        Me.chkDaTagridVpNhaDatNhanLai.TabIndex = 32
        Me.chkDaTagridVpNhaDatNhanLai.Text = "Chọn/Bỏ chọn"
        Me.chkDaTagridVpNhaDatNhanLai.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Lavender
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(8, 80)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(216, 23)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Chuyển về nơi tiếp nhận"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(8, 51)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(216, 23)
        Me.Button5.TabIndex = 20
        Me.Button5.Text = "Hồ sơ đã trả"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.ForeColor = System.Drawing.Color.Black
        Me.Button8.Location = New System.Drawing.Point(8, 22)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(216, 23)
        Me.Button8.TabIndex = 19
        Me.Button8.Text = "Tìm và lấy hồ sơ trả về"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox17
        '
        Me.GroupBox17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox17.Controls.Add(Me.chkDuDieuKienVP)
        Me.GroupBox17.Controls.Add(Me.Label3)
        Me.GroupBox17.Controls.Add(Me.txtLyDoKHongDuDKVP)
        Me.GroupBox17.Controls.Add(Me.cmdCapNhatVP)
        Me.GroupBox17.Controls.Add(Me.cmdBCVPChuyen)
        Me.GroupBox17.Controls.Add(Me.chkdatagridvpnhan)
        Me.GroupBox17.Controls.Add(Me.Button2)
        Me.GroupBox17.Controls.Add(Me.Button3)
        Me.GroupBox17.Location = New System.Drawing.Point(737, 79)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(234, 223)
        Me.GroupBox17.TabIndex = 50
        Me.GroupBox17.TabStop = False
        '
        'chkDuDieuKienVP
        '
        Me.chkDuDieuKienVP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDuDieuKienVP.AutoSize = True
        Me.chkDuDieuKienVP.BackColor = System.Drawing.Color.Transparent
        Me.chkDuDieuKienVP.Location = New System.Drawing.Point(6, 13)
        Me.chkDuDieuKienVP.Name = "chkDuDieuKienVP"
        Me.chkDuDieuKienVP.Size = New System.Drawing.Size(128, 17)
        Me.chkDuDieuKienVP.TabIndex = 41
        Me.chkDuDieuKienVP.Text = "Đủ ĐK/Không đủ ĐK"
        Me.chkDuDieuKienVP.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Lý do không đủ điều kiện"
        '
        'txtLyDoKHongDuDKVP
        '
        Me.txtLyDoKHongDuDKVP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKHongDuDKVP.Location = New System.Drawing.Point(6, 52)
        Me.txtLyDoKHongDuDKVP.Name = "txtLyDoKHongDuDKVP"
        Me.txtLyDoKHongDuDKVP.Size = New System.Drawing.Size(219, 20)
        Me.txtLyDoKHongDuDKVP.TabIndex = 39
        '
        'cmdCapNhatVP
        '
        Me.cmdCapNhatVP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhatVP.ForeColor = System.Drawing.Color.Black
        Me.cmdCapNhatVP.Location = New System.Drawing.Point(5, 79)
        Me.cmdCapNhatVP.Name = "cmdCapNhatVP"
        Me.cmdCapNhatVP.Size = New System.Drawing.Size(219, 23)
        Me.cmdCapNhatVP.TabIndex = 38
        Me.cmdCapNhatVP.Text = "Cập nhật"
        Me.cmdCapNhatVP.UseVisualStyleBackColor = True
        '
        'cmdBCVPChuyen
        '
        Me.cmdBCVPChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBCVPChuyen.ForeColor = System.Drawing.Color.Black
        Me.cmdBCVPChuyen.Location = New System.Drawing.Point(5, 166)
        Me.cmdBCVPChuyen.Name = "cmdBCVPChuyen"
        Me.cmdBCVPChuyen.Size = New System.Drawing.Size(219, 23)
        Me.cmdBCVPChuyen.TabIndex = 33
        Me.cmdBCVPChuyen.Text = "In báo cáo"
        Me.cmdBCVPChuyen.UseVisualStyleBackColor = True
        '
        'chkdatagridvpnhan
        '
        Me.chkdatagridvpnhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkdatagridvpnhan.AutoSize = True
        Me.chkdatagridvpnhan.BackColor = System.Drawing.Color.Transparent
        Me.chkdatagridvpnhan.Location = New System.Drawing.Point(6, 195)
        Me.chkdatagridvpnhan.Name = "chkdatagridvpnhan"
        Me.chkdatagridvpnhan.Size = New System.Drawing.Size(96, 17)
        Me.chkdatagridvpnhan.TabIndex = 31
        Me.chkdatagridvpnhan.Text = "Chọn/Bỏ chọn"
        Me.chkdatagridvpnhan.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Lavender
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(6, 137)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(219, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Chuyển lên VP thẩm định"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(5, 108)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(219, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Tìm và lấy hồ sơ chuyển lên"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(742, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Ngày báo cáo"
        '
        'dtpVanPhong
        '
        Me.dtpVanPhong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpVanPhong.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVanPhong.Location = New System.Drawing.Point(745, 21)
        Me.dtpVanPhong.Name = "dtpVanPhong"
        Me.dtpVanPhong.Size = New System.Drawing.Size(209, 20)
        Me.dtpVanPhong.TabIndex = 48
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.CtrFilterGridVpNhaDatTra)
        Me.GroupBox7.Controls.Add(Me.DaTagridVpNhaDatNhanLai)
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox7.Location = New System.Drawing.Point(7, 308)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(724, 214)
        Me.GroupBox7.TabIndex = 47
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Danh sách hồ sơ nhận chuyển về"
        '
        'CtrFilterGridVpNhaDatTra
        '
        Me.CtrFilterGridVpNhaDatTra.AutoScroll = True
        Me.CtrFilterGridVpNhaDatTra.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridVpNhaDatTra.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridVpNhaDatTra.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridVpNhaDatTra.MydataTable = Nothing
        Me.CtrFilterGridVpNhaDatTra.MyGrid = Nothing
        Me.CtrFilterGridVpNhaDatTra.Name = "CtrFilterGridVpNhaDatTra"
        Me.CtrFilterGridVpNhaDatTra.Size = New System.Drawing.Size(718, 57)
        Me.CtrFilterGridVpNhaDatTra.TabIndex = 29
        '
        'DaTagridVpNhaDatNhanLai
        '
        Me.DaTagridVpNhaDatNhanLai.AllowUserToAddRows = False
        Me.DaTagridVpNhaDatNhanLai.AllowUserToDeleteRows = False
        Me.DaTagridVpNhaDatNhanLai.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DaTagridVpNhaDatNhanLai.BackgroundColor = System.Drawing.Color.Lavender
        Me.DaTagridVpNhaDatNhanLai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DaTagridVpNhaDatNhanLai.Location = New System.Drawing.Point(6, 79)
        Me.DaTagridVpNhaDatNhanLai.Name = "DaTagridVpNhaDatNhanLai"
        Me.DaTagridVpNhaDatNhanLai.ReadOnly = True
        Me.DaTagridVpNhaDatNhanLai.Size = New System.Drawing.Size(712, 129)
        Me.DaTagridVpNhaDatNhanLai.TabIndex = 17
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox6.Controls.Add(Me.CtrFilterGridVpNhaDatNhan)
        Me.GroupBox6.Controls.Add(Me.datagridvpnhan)
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox6.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(725, 296)
        Me.GroupBox6.TabIndex = 46
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Danh sách hồ sơ một cửa chuyển lên"
        '
        'CtrFilterGridVpNhaDatNhan
        '
        Me.CtrFilterGridVpNhaDatNhan.AutoScroll = True
        Me.CtrFilterGridVpNhaDatNhan.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGridVpNhaDatNhan.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGridVpNhaDatNhan.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGridVpNhaDatNhan.MydataTable = Nothing
        Me.CtrFilterGridVpNhaDatNhan.MyGrid = Nothing
        Me.CtrFilterGridVpNhaDatNhan.Name = "CtrFilterGridVpNhaDatNhan"
        Me.CtrFilterGridVpNhaDatNhan.Size = New System.Drawing.Size(719, 41)
        Me.CtrFilterGridVpNhaDatNhan.TabIndex = 28
        '
        'datagridvpnhan
        '
        Me.datagridvpnhan.AllowUserToAddRows = False
        Me.datagridvpnhan.AllowUserToDeleteRows = False
        Me.datagridvpnhan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridvpnhan.BackgroundColor = System.Drawing.Color.Lavender
        Me.datagridvpnhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridvpnhan.Location = New System.Drawing.Point(6, 66)
        Me.datagridvpnhan.Name = "datagridvpnhan"
        Me.datagridvpnhan.ReadOnly = True
        Me.datagridvpnhan.Size = New System.Drawing.Size(713, 224)
        Me.datagridvpnhan.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.datagridHoSoDaChuyenVeVPNhaDat)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(971, 522)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN LÃNH ĐẠO VĂN PHÒNG"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.Button12.TabIndex = 26
        Me.Button12.Text = "Tìm và lấy hồ sơ"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox15.Controls.Add(Me.CtrFilterGrid1)
        Me.GroupBox15.Controls.Add(Me.DataGridTheoDoi)
        Me.GroupBox15.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(804, 516)
        Me.GroupBox15.TabIndex = 25
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Danh sách hồ sơ"
        '
        'CtrFilterGrid1
        '
        Me.CtrFilterGrid1.AutoScroll = True
        Me.CtrFilterGrid1.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGrid1.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGrid1.MydataTable = Nothing
        Me.CtrFilterGrid1.MyGrid = Nothing
        Me.CtrFilterGrid1.Name = "CtrFilterGrid1"
        Me.CtrFilterGrid1.Size = New System.Drawing.Size(798, 67)
        Me.CtrFilterGrid1.TabIndex = 26
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
        'frmHoSoVPDK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(979, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmHoSoVPDK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HO SO TAI VAN PHONG DANG KY DAT VA NHA"
        CType(Me.datagridHoSoDaChuyenVeVPNhaDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DaTagridVpNhaDatNhanLai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.datagridvpnhan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        CType(Me.DataGridTheoDoi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents datagridHoSoDaChuyenVeVPNhaDat As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBCVPNhan As System.Windows.Forms.Button
    Friend WithEvents chkDaTagridVpNhaDatNhanLai As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuDieuKienVP As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKHongDuDKVP As System.Windows.Forms.TextBox
    Friend WithEvents cmdCapNhatVP As System.Windows.Forms.Button
    Friend WithEvents cmdBCVPChuyen As System.Windows.Forms.Button
    Friend WithEvents chkdatagridvpnhan As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpVanPhong As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridVpNhaDatTra As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DaTagridVpNhaDatNhanLai As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGridVpNhaDatNhan As prjFilterGrid.ctrFilterGrid
    Friend WithEvents datagridvpnhan As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCanBoThuLy As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTheoDoi As System.Windows.Forms.DataGridView
End Class
