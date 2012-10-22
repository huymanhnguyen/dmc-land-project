<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoSoTiepNhan
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
        Me.dtpMotCua = New System.Windows.Forms.DateTimePicker
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.cmdBC1CuaNhan = New System.Windows.Forms.Button
        Me.chkDataGridHoSoNhanVe = New System.Windows.Forms.CheckBox
        Me.cmdHoanThanhQuyTrinh = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox19 = New System.Windows.Forms.GroupBox
        Me.chkDuDK1Cua = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLyDoKhongDuDK1Cua = New System.Windows.Forms.TextBox
        Me.cmdCapNhat1Cua = New System.Windows.Forms.Button
        Me.cmdBC1CuaChuyen = New System.Windows.Forms.Button
        Me.chkDataGridTiepNhan = New System.Windows.Forms.CheckBox
        Me.tbnChuyen = New System.Windows.Forms.Button
        Me.btnTim = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1CuaTra = New prjFilterGrid.ctrFilterGrid
        Me.DataGridHoSoNhanVe = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1CuaNhan = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTiepNhan = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdHoSoDaChuyen = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Button12 = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.CtrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        Me.DataGridTheoDoi = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridHoSoNhanVe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridTiepNhan, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtCanBoThuLy)
        Me.TabPage1.Controls.Add(Me.dtpMotCua)
        Me.TabPage1.Controls.Add(Me.GroupBox20)
        Me.TabPage1.Controls.Add(Me.GroupBox19)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(971, 522)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "XỬ LÝ THÔNG TIN TIẾP NHẬN HỒ SƠ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(762, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cán bộ thụ lý"
        '
        'txtCanBoThuLy
        '
        Me.txtCanBoThuLy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCanBoThuLy.Location = New System.Drawing.Point(763, 63)
        Me.txtCanBoThuLy.Name = "txtCanBoThuLy"
        Me.txtCanBoThuLy.Size = New System.Drawing.Size(193, 20)
        Me.txtCanBoThuLy.TabIndex = 5
        '
        'dtpMotCua
        '
        Me.dtpMotCua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpMotCua.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMotCua.Location = New System.Drawing.Point(763, 22)
        Me.dtpMotCua.Name = "dtpMotCua"
        Me.dtpMotCua.Size = New System.Drawing.Size(147, 20)
        Me.dtpMotCua.TabIndex = 3
        '
        'GroupBox20
        '
        Me.GroupBox20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox20.Controls.Add(Me.cmdBC1CuaNhan)
        Me.GroupBox20.Controls.Add(Me.chkDataGridHoSoNhanVe)
        Me.GroupBox20.Controls.Add(Me.cmdHoanThanhQuyTrinh)
        Me.GroupBox20.Controls.Add(Me.Button1)
        Me.GroupBox20.Location = New System.Drawing.Point(753, 311)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(215, 132)
        Me.GroupBox20.TabIndex = 46
        Me.GroupBox20.TabStop = False
        '
        'cmdBC1CuaNhan
        '
        Me.cmdBC1CuaNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBC1CuaNhan.ForeColor = System.Drawing.Color.Black
        Me.cmdBC1CuaNhan.Location = New System.Drawing.Point(6, 77)
        Me.cmdBC1CuaNhan.Name = "cmdBC1CuaNhan"
        Me.cmdBC1CuaNhan.Size = New System.Drawing.Size(207, 23)
        Me.cmdBC1CuaNhan.TabIndex = 18
        Me.cmdBC1CuaNhan.Text = "In báo cáo"
        Me.cmdBC1CuaNhan.UseVisualStyleBackColor = True
        Me.cmdBC1CuaNhan.Visible = False
        '
        'chkDataGridHoSoNhanVe
        '
        Me.chkDataGridHoSoNhanVe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDataGridHoSoNhanVe.AutoSize = True
        Me.chkDataGridHoSoNhanVe.BackColor = System.Drawing.Color.Transparent
        Me.chkDataGridHoSoNhanVe.Location = New System.Drawing.Point(10, 109)
        Me.chkDataGridHoSoNhanVe.Name = "chkDataGridHoSoNhanVe"
        Me.chkDataGridHoSoNhanVe.Size = New System.Drawing.Size(96, 17)
        Me.chkDataGridHoSoNhanVe.TabIndex = 19
        Me.chkDataGridHoSoNhanVe.Text = "Chọn/Bỏ chọn"
        Me.chkDataGridHoSoNhanVe.UseVisualStyleBackColor = False
        '
        'cmdHoanThanhQuyTrinh
        '
        Me.cmdHoanThanhQuyTrinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdHoanThanhQuyTrinh.ForeColor = System.Drawing.Color.Black
        Me.cmdHoanThanhQuyTrinh.Location = New System.Drawing.Point(6, 48)
        Me.cmdHoanThanhQuyTrinh.Name = "cmdHoanThanhQuyTrinh"
        Me.cmdHoanThanhQuyTrinh.Size = New System.Drawing.Size(207, 23)
        Me.cmdHoanThanhQuyTrinh.TabIndex = 17
        Me.cmdHoanThanhQuyTrinh.Text = "Hồ sơ hoàn thành quy trình"
        Me.cmdHoanThanhQuyTrinh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(6, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(207, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Tìm và lấy hồ sơ trả về"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox19.Controls.Add(Me.chkDuDK1Cua)
        Me.GroupBox19.Controls.Add(Me.Label2)
        Me.GroupBox19.Controls.Add(Me.txtLyDoKhongDuDK1Cua)
        Me.GroupBox19.Controls.Add(Me.cmdCapNhat1Cua)
        Me.GroupBox19.Controls.Add(Me.cmdBC1CuaChuyen)
        Me.GroupBox19.Controls.Add(Me.chkDataGridTiepNhan)
        Me.GroupBox19.Controls.Add(Me.tbnChuyen)
        Me.GroupBox19.Controls.Add(Me.btnTim)
        Me.GroupBox19.Location = New System.Drawing.Point(753, 80)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(215, 221)
        Me.GroupBox19.TabIndex = 45
        Me.GroupBox19.TabStop = False
        '
        'chkDuDK1Cua
        '
        Me.chkDuDK1Cua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDuDK1Cua.AutoSize = True
        Me.chkDuDK1Cua.BackColor = System.Drawing.Color.Transparent
        Me.chkDuDK1Cua.Location = New System.Drawing.Point(10, 19)
        Me.chkDuDK1Cua.Name = "chkDuDK1Cua"
        Me.chkDuDK1Cua.Size = New System.Drawing.Size(128, 17)
        Me.chkDuDK1Cua.TabIndex = 6
        Me.chkDuDK1Cua.Text = "Đủ ĐK/Không đủ ĐK"
        Me.chkDuDK1Cua.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lý do không đủ điều kiện"
        '
        'txtLyDoKhongDuDK1Cua
        '
        Me.txtLyDoKhongDuDK1Cua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongDuDK1Cua.Location = New System.Drawing.Point(10, 55)
        Me.txtLyDoKhongDuDK1Cua.Name = "txtLyDoKhongDuDK1Cua"
        Me.txtLyDoKhongDuDK1Cua.Size = New System.Drawing.Size(193, 20)
        Me.txtLyDoKhongDuDK1Cua.TabIndex = 8
        '
        'cmdCapNhat1Cua
        '
        Me.cmdCapNhat1Cua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhat1Cua.ForeColor = System.Drawing.Color.Black
        Me.cmdCapNhat1Cua.Location = New System.Drawing.Point(9, 81)
        Me.cmdCapNhat1Cua.Name = "cmdCapNhat1Cua"
        Me.cmdCapNhat1Cua.Size = New System.Drawing.Size(193, 23)
        Me.cmdCapNhat1Cua.TabIndex = 9
        Me.cmdCapNhat1Cua.Text = "Cập nhật"
        Me.cmdCapNhat1Cua.UseVisualStyleBackColor = True
        '
        'cmdBC1CuaChuyen
        '
        Me.cmdBC1CuaChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBC1CuaChuyen.ForeColor = System.Drawing.Color.Black
        Me.cmdBC1CuaChuyen.Location = New System.Drawing.Point(10, 167)
        Me.cmdBC1CuaChuyen.Name = "cmdBC1CuaChuyen"
        Me.cmdBC1CuaChuyen.Size = New System.Drawing.Size(193, 23)
        Me.cmdBC1CuaChuyen.TabIndex = 12
        Me.cmdBC1CuaChuyen.Text = "In báo cáo"
        Me.cmdBC1CuaChuyen.UseVisualStyleBackColor = True
        '
        'chkDataGridTiepNhan
        '
        Me.chkDataGridTiepNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDataGridTiepNhan.AutoSize = True
        Me.chkDataGridTiepNhan.BackColor = System.Drawing.Color.Transparent
        Me.chkDataGridTiepNhan.Location = New System.Drawing.Point(12, 196)
        Me.chkDataGridTiepNhan.Name = "chkDataGridTiepNhan"
        Me.chkDataGridTiepNhan.Size = New System.Drawing.Size(96, 17)
        Me.chkDataGridTiepNhan.TabIndex = 13
        Me.chkDataGridTiepNhan.Text = "Chọn/Bỏ chọn"
        Me.chkDataGridTiepNhan.UseVisualStyleBackColor = False
        '
        'tbnChuyen
        '
        Me.tbnChuyen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbnChuyen.ForeColor = System.Drawing.Color.Black
        Me.tbnChuyen.Location = New System.Drawing.Point(10, 138)
        Me.tbnChuyen.Name = "tbnChuyen"
        Me.tbnChuyen.Size = New System.Drawing.Size(193, 23)
        Me.tbnChuyen.TabIndex = 11
        Me.tbnChuyen.Text = "Chuyển lên VP nhà đất"
        Me.tbnChuyen.UseVisualStyleBackColor = True
        '
        'btnTim
        '
        Me.btnTim.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTim.ForeColor = System.Drawing.Color.Black
        Me.btnTim.Location = New System.Drawing.Point(10, 108)
        Me.btnTim.Name = "btnTim"
        Me.btnTim.Size = New System.Drawing.Size(193, 23)
        Me.btnTim.TabIndex = 10
        Me.btnTim.Text = "Tìm và Lấy hồ sơ tiếp nhận"
        Me.btnTim.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(760, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Ngày báo cáo"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.CtrFilterGrid1CuaTra)
        Me.GroupBox5.Controls.Add(Me.DataGridHoSoNhanVe)
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox5.Location = New System.Drawing.Point(6, 308)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(741, 208)
        Me.GroupBox5.TabIndex = 43
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Danh sách hồ sơ nhận trả "
        '
        'CtrFilterGrid1CuaTra
        '
        Me.CtrFilterGrid1CuaTra.AutoScroll = True
        Me.CtrFilterGrid1CuaTra.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid1CuaTra.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGrid1CuaTra.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGrid1CuaTra.MydataTable = Nothing
        Me.CtrFilterGrid1CuaTra.MyGrid = Nothing
        Me.CtrFilterGrid1CuaTra.Name = "CtrFilterGrid1CuaTra"
        Me.CtrFilterGrid1CuaTra.Size = New System.Drawing.Size(735, 65)
        Me.CtrFilterGrid1CuaTra.TabIndex = 14
        '
        'DataGridHoSoNhanVe
        '
        Me.DataGridHoSoNhanVe.AllowUserToAddRows = False
        Me.DataGridHoSoNhanVe.AllowUserToDeleteRows = False
        Me.DataGridHoSoNhanVe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridHoSoNhanVe.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGridHoSoNhanVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridHoSoNhanVe.Location = New System.Drawing.Point(6, 87)
        Me.DataGridHoSoNhanVe.Name = "DataGridHoSoNhanVe"
        Me.DataGridHoSoNhanVe.ReadOnly = True
        Me.DataGridHoSoNhanVe.Size = New System.Drawing.Size(732, 118)
        Me.DataGridHoSoNhanVe.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.CtrFilterGrid1CuaNhan)
        Me.GroupBox4.Controls.Add(Me.DataGridTiepNhan)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(741, 296)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Danh sách hồ sơ mới tiếp nhận"
        '
        'CtrFilterGrid1CuaNhan
        '
        Me.CtrFilterGrid1CuaNhan.AutoScroll = True
        Me.CtrFilterGrid1CuaNhan.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid1CuaNhan.Dock = System.Windows.Forms.DockStyle.Top
        Me.CtrFilterGrid1CuaNhan.Location = New System.Drawing.Point(3, 16)
        Me.CtrFilterGrid1CuaNhan.MydataTable = Nothing
        Me.CtrFilterGrid1CuaNhan.MyGrid = Nothing
        Me.CtrFilterGrid1CuaNhan.Name = "CtrFilterGrid1CuaNhan"
        Me.CtrFilterGrid1CuaNhan.Size = New System.Drawing.Size(735, 61)
        Me.CtrFilterGrid1CuaNhan.TabIndex = 0
        '
        'DataGridTiepNhan
        '
        Me.DataGridTiepNhan.AllowUserToAddRows = False
        Me.DataGridTiepNhan.AllowUserToDeleteRows = False
        Me.DataGridTiepNhan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridTiepNhan.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGridTiepNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTiepNhan.Location = New System.Drawing.Point(3, 83)
        Me.DataGridTiepNhan.Name = "DataGridTiepNhan"
        Me.DataGridTiepNhan.ReadOnly = True
        Me.DataGridTiepNhan.Size = New System.Drawing.Size(735, 209)
        Me.DataGridTiepNhan.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdHoSoDaChuyen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(971, 522)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN VĂN PHÒNG"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdHoSoDaChuyen
        '
        Me.grdHoSoDaChuyen.BackgroundColor = System.Drawing.Color.Lavender
        Me.grdHoSoDaChuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHoSoDaChuyen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHoSoDaChuyen.Location = New System.Drawing.Point(3, 3)
        Me.grdHoSoDaChuyen.Name = "grdHoSoDaChuyen"
        Me.grdHoSoDaChuyen.Size = New System.Drawing.Size(965, 516)
        Me.grdHoSoDaChuyen.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button12)
        Me.TabPage3.Controls.Add(Me.GroupBox15)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
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
        Me.GroupBox15.Controls.Add(Me.CtrFilterGrid1)
        Me.GroupBox15.Controls.Add(Me.DataGridTheoDoi)
        Me.GroupBox15.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(804, 516)
        Me.GroupBox15.TabIndex = 23
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
        Me.CtrFilterGrid1.TabIndex = 0
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
        'frmHoSoTiepNhan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(979, 548)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmHoSoTiepNhan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HO SO TIEP NHAN"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridHoSoNhanVe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridTiepNhan, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dtpMotCua As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBC1CuaNhan As System.Windows.Forms.Button
    Friend WithEvents chkDataGridHoSoNhanVe As System.Windows.Forms.CheckBox
    Friend WithEvents cmdHoanThanhQuyTrinh As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuDK1Cua As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLyDoKhongDuDK1Cua As System.Windows.Forms.TextBox
    Friend WithEvents cmdCapNhat1Cua As System.Windows.Forms.Button
    Friend WithEvents cmdBC1CuaChuyen As System.Windows.Forms.Button
    Friend WithEvents chkDataGridTiepNhan As System.Windows.Forms.CheckBox
    Friend WithEvents tbnChuyen As System.Windows.Forms.Button
    Friend WithEvents btnTim As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1CuaTra As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridHoSoNhanVe As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1CuaNhan As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTiepNhan As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdHoSoDaChuyen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents CtrFilterGrid1 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents DataGridTheoDoi As System.Windows.Forms.DataGridView
End Class
