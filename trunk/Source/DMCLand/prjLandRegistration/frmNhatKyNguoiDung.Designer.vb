<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhatKyNguoiDung
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdDanhSachCongViec = New DMC.[Interface].GridView.ctrlGridView
        Me.cmdTim = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNguoiDung = New System.Windows.Forms.TextBox
        Me.txtSoHieuThua = New System.Windows.Forms.TextBox
        Me.txtToBanDo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lable2 = New System.Windows.Forms.Label
        Me.CtrFilterGrid1 = New prjFilterGrid.ctrFilterGrid
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(846, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "NHẬT KÝ NGƯỜI SỬ DỤNG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDanhSachCongViec
        '
        Me.grdDanhSachCongViec.AllowUserToAddRows = False
        Me.grdDanhSachCongViec.AllowUserToDeleteRows = False
        Me.grdDanhSachCongViec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhSachCongViec.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachCongViec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhSachCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachCongViec.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhSachCongViec.Location = New System.Drawing.Point(3, 90)
        Me.grdDanhSachCongViec.Name = "grdDanhSachCongViec"
        Me.grdDanhSachCongViec.ReadOnly = True
        Me.grdDanhSachCongViec.RowHeadersWidth = 25
        Me.grdDanhSachCongViec.Size = New System.Drawing.Size(843, 330)
        Me.grdDanhSachCongViec.TabIndex = 70
        '
        'cmdTim
        '
        Me.cmdTim.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdTim.Location = New System.Drawing.Point(684, 426)
        Me.cmdTim.Name = "cmdTim"
        Me.cmdTim.Size = New System.Drawing.Size(75, 21)
        Me.cmdTim.TabIndex = 72
        Me.cmdTim.Text = "Tìm"
        Me.cmdTim.UseVisualStyleBackColor = True
        '
        'cmdThoat
        '
        Me.cmdThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdThoat.Location = New System.Drawing.Point(765, 426)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(75, 21)
        Me.cmdThoat.TabIndex = 73
        Me.cmdThoat.Text = "Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(535, 426)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(143, 20)
        Me.dtpNgay.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(455, 430)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Ngày làm việc"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Người dùng"
        '
        'txtNguoiDung
        '
        Me.txtNguoiDung.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNguoiDung.Location = New System.Drawing.Point(77, 426)
        Me.txtNguoiDung.Name = "txtNguoiDung"
        Me.txtNguoiDung.Size = New System.Drawing.Size(95, 20)
        Me.txtNguoiDung.TabIndex = 77
        '
        'txtSoHieuThua
        '
        Me.txtSoHieuThua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSoHieuThua.Location = New System.Drawing.Point(358, 428)
        Me.txtSoHieuThua.Name = "txtSoHieuThua"
        Me.txtSoHieuThua.Size = New System.Drawing.Size(91, 20)
        Me.txtSoHieuThua.TabIndex = 81
        '
        'txtToBanDo
        '
        Me.txtToBanDo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtToBanDo.Location = New System.Drawing.Point(235, 428)
        Me.txtToBanDo.Name = "txtToBanDo"
        Me.txtToBanDo.Size = New System.Drawing.Size(75, 20)
        Me.txtToBanDo.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Số thửa:"
        '
        'lable2
        '
        Me.lable2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lable2.AutoSize = True
        Me.lable2.Location = New System.Drawing.Point(178, 431)
        Me.lable2.Name = "lable2"
        Me.lable2.Size = New System.Drawing.Size(60, 13)
        Me.lable2.TabIndex = 78
        Me.lable2.Text = "Tờ bản đồ:"
        '
        'CtrFilterGrid1
        '
        Me.CtrFilterGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrFilterGrid1.AutoScroll = True
        Me.CtrFilterGrid1.BackColor = System.Drawing.Color.Lavender
        Me.CtrFilterGrid1.Location = New System.Drawing.Point(0, 22)
        Me.CtrFilterGrid1.MydataTable = Nothing
        Me.CtrFilterGrid1.MyGrid = Nothing
        Me.CtrFilterGrid1.Name = "CtrFilterGrid1"
        Me.CtrFilterGrid1.Size = New System.Drawing.Size(846, 67)
        Me.CtrFilterGrid1.TabIndex = 71
        '
        'frmNhatKyNguoiDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(846, 464)
        Me.Controls.Add(Me.txtSoHieuThua)
        Me.Controls.Add(Me.txtToBanDo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lable2)
        Me.Controls.Add(Me.txtNguoiDung)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpNgay)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.cmdTim)
        Me.Controls.Add(Me.CtrFilterGrid1)
        Me.Controls.Add(Me.grdDanhSachCongViec)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNhatKyNguoiDung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NHAT KY NGUOI DUNG"
        CType(Me.grdDanhSachCongViec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDanhSachCongViec As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents cmdTim As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents CtrFilterGrid1 As prjFilterGrid.ctrFilterGrid
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNguoiDung As System.Windows.Forms.TextBox
    Private WithEvents txtSoHieuThua As System.Windows.Forms.TextBox
    Private WithEvents txtToBanDo As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents lable2 As System.Windows.Forms.Label
End Class
