<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinThuaTuNhien
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdChon = New System.Windows.Forms.Button
        Me.cboChonChu = New System.Windows.Forms.ComboBox
        Me.LabChonChu = New System.Windows.Forms.Label
        Me.LabThongTinChu = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdvwLichSuThuaDat = New DMC.[Interface].GridView.ctrlGridView
        Me.numDienTichTuNhien = New System.Windows.Forms.NumericUpDown
        Me.txtSoThua = New System.Windows.Forms.TextBox
        Me.txtToBanDo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.contextCapNhatThongTinLichSu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.contextChuSuDung = New System.Windows.Forms.ToolStripMenuItem
        Me.contextMucDich = New System.Windows.Forms.ToolStripMenuItem
        Me.contextNguonGoc = New System.Windows.Forms.ToolStripMenuItem
        Me.contextKiemKe = New System.Windows.Forms.ToolStripMenuItem
        Me.contextQuiHoach = New System.Windows.Forms.ToolStripMenuItem
        Me.contextTaiLieuKemTheo = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvwLichSuThuaDat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDienTichTuNhien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextCapNhatThongTinLichSu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdChon)
        Me.GroupBox1.Controls.Add(Me.cboChonChu)
        Me.GroupBox1.Controls.Add(Me.LabChonChu)
        Me.GroupBox1.Controls.Add(Me.LabThongTinChu)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.grdvwLichSuThuaDat)
        Me.GroupBox1.Controls.Add(Me.numDienTichTuNhien)
        Me.GroupBox1.Controls.Add(Me.txtSoThua)
        Me.GroupBox1.Controls.Add(Me.txtToBanDo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 251)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin thửa tự nhiên"
        '
        'cmdChon
        '
        Me.cmdChon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChon.Location = New System.Drawing.Point(171, 111)
        Me.cmdChon.Name = "cmdChon"
        Me.cmdChon.Size = New System.Drawing.Size(47, 24)
        Me.cmdChon.TabIndex = 4
        Me.cmdChon.Text = "Chọn"
        Me.cmdChon.UseVisualStyleBackColor = True
        Me.cmdChon.Visible = False
        '
        'cboChonChu
        '
        Me.cboChonChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChonChu.DropDownHeight = 200
        Me.cboChonChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChonChu.DropDownWidth = 500
        Me.cboChonChu.FormattingEnabled = True
        Me.cboChonChu.IntegralHeight = False
        Me.cboChonChu.Location = New System.Drawing.Point(75, 111)
        Me.cboChonChu.Name = "cboChonChu"
        Me.cboChonChu.Size = New System.Drawing.Size(90, 24)
        Me.cboChonChu.TabIndex = 3
        Me.cboChonChu.Visible = False
        '
        'LabChonChu
        '
        Me.LabChonChu.AutoSize = True
        Me.LabChonChu.Location = New System.Drawing.Point(6, 114)
        Me.LabChonChu.Name = "LabChonChu"
        Me.LabChonChu.Size = New System.Drawing.Size(63, 16)
        Me.LabChonChu.TabIndex = 37
        Me.LabChonChu.Text = "Chọn chủ"
        Me.LabChonChu.Visible = False
        '
        'LabThongTinChu
        '
        Me.LabThongTinChu.AutoSize = True
        Me.LabThongTinChu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabThongTinChu.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LabThongTinChu.Location = New System.Drawing.Point(93, 92)
        Me.LabThongTinChu.Name = "LabThongTinChu"
        Me.LabThongTinChu.Size = New System.Drawing.Size(20, 16)
        Me.LabThongTinChu.TabIndex = 36
        Me.LabThongTinChu.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Loại thửa đất:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Lịch sử tạo lập thửa đất"
        '
        'grdvwLichSuThuaDat
        '
        Me.grdvwLichSuThuaDat.AllowUserToAddRows = False
        Me.grdvwLichSuThuaDat.AllowUserToDeleteRows = False
        Me.grdvwLichSuThuaDat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwLichSuThuaDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdvwLichSuThuaDat.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwLichSuThuaDat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwLichSuThuaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwLichSuThuaDat.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwLichSuThuaDat.Location = New System.Drawing.Point(6, 157)
        Me.grdvwLichSuThuaDat.MultiSelect = False
        Me.grdvwLichSuThuaDat.Name = "grdvwLichSuThuaDat"
        Me.grdvwLichSuThuaDat.ReadOnly = True
        Me.grdvwLichSuThuaDat.RowHeadersWidth = 25
        Me.grdvwLichSuThuaDat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwLichSuThuaDat.Size = New System.Drawing.Size(212, 88)
        Me.grdvwLichSuThuaDat.TabIndex = 5
        '
        'numDienTichTuNhien
        '
        Me.numDienTichTuNhien.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numDienTichTuNhien.DecimalPlaces = 2
        Me.numDienTichTuNhien.Location = New System.Drawing.Point(114, 65)
        Me.numDienTichTuNhien.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDienTichTuNhien.Name = "numDienTichTuNhien"
        Me.numDienTichTuNhien.Size = New System.Drawing.Size(104, 22)
        Me.numDienTichTuNhien.TabIndex = 2
        '
        'txtSoThua
        '
        Me.txtSoThua.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoThua.Location = New System.Drawing.Point(114, 41)
        Me.txtSoThua.Name = "txtSoThua"
        Me.txtSoThua.Size = New System.Drawing.Size(105, 22)
        Me.txtSoThua.TabIndex = 1
        '
        'txtToBanDo
        '
        Me.txtToBanDo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToBanDo.Location = New System.Drawing.Point(114, 17)
        Me.txtToBanDo.Name = "txtToBanDo"
        Me.txtToBanDo.Size = New System.Drawing.Size(105, 22)
        Me.txtToBanDo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Diện tích tự nhiên"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Số thửa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Tờ bản đồ"
        '
        'contextCapNhatThongTinLichSu
        '
        Me.contextCapNhatThongTinLichSu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contextChuSuDung, Me.contextMucDich, Me.contextNguonGoc, Me.contextKiemKe, Me.contextQuiHoach, Me.contextTaiLieuKemTheo})
        Me.contextCapNhatThongTinLichSu.Name = "contextMenuTachThua"
        Me.contextCapNhatThongTinLichSu.ShowImageMargin = False
        Me.contextCapNhatThongTinLichSu.Size = New System.Drawing.Size(227, 136)
        '
        'contextChuSuDung
        '
        Me.contextChuSuDung.Name = "contextChuSuDung"
        Me.contextChuSuDung.Size = New System.Drawing.Size(226, 22)
        Me.contextChuSuDung.Text = "Lịch sử CHỦ sử dụng đất"
        '
        'contextMucDich
        '
        Me.contextMucDich.Name = "contextMucDich"
        Me.contextMucDich.Size = New System.Drawing.Size(226, 22)
        Me.contextMucDich.Text = "Lịch sử MỤC ĐÍCH sử dụng đất"
        '
        'contextNguonGoc
        '
        Me.contextNguonGoc.Name = "contextNguonGoc"
        Me.contextNguonGoc.Size = New System.Drawing.Size(226, 22)
        Me.contextNguonGoc.Text = "Lịch sử NGUỒN GỐC sử dụng đất"
        '
        'contextKiemKe
        '
        Me.contextKiemKe.Name = "contextKiemKe"
        Me.contextKiemKe.Size = New System.Drawing.Size(226, 22)
        Me.contextKiemKe.Text = "Lịch sử KIỂM KÊ đất đai"
        '
        'contextQuiHoach
        '
        Me.contextQuiHoach.Name = "contextQuiHoach"
        Me.contextQuiHoach.Size = New System.Drawing.Size(226, 22)
        Me.contextQuiHoach.Text = "Lịch sử QUI HOẠCH sử dụng đất"
        '
        'contextTaiLieuKemTheo
        '
        Me.contextTaiLieuKemTheo.Name = "contextTaiLieuKemTheo"
        Me.contextTaiLieuKemTheo.Size = New System.Drawing.Size(226, 22)
        Me.contextTaiLieuKemTheo.Text = "Lịch sử TÀI LIỆU kèm theo"
        '
        'ctrlThongTinThuaTuNhien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinThuaTuNhien"
        Me.Size = New System.Drawing.Size(230, 257)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdvwLichSuThuaDat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDienTichTuNhien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextCapNhatThongTinLichSu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents numDienTichTuNhien As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtSoThua As System.Windows.Forms.TextBox
    Friend WithEvents txtToBanDo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents contextCapNhatThongTinLichSu As System.Windows.Forms.ContextMenuStrip
    Private WithEvents contextChuSuDung As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextMucDich As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextNguonGoc As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextKiemKe As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextQuiHoach As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextTaiLieuKemTheo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdvwLichSuThuaDat As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents LabThongTinChu As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LabChonChu As System.Windows.Forms.Label
    Friend WithEvents cboChonChu As System.Windows.Forms.ComboBox
    Friend WithEvents cmdChon As System.Windows.Forms.Button

End Class
