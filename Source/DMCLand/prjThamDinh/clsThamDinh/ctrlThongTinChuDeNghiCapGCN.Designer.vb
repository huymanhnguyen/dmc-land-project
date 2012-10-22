<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinChuDeNghiCapGCN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlThongTinChuDeNghiCapGCN))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.txtGhiChuNoiDungChuDeNghiCapGCN = New System.Windows.Forms.RichTextBox
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdvwChuDeNghiCapGCN = New DMC.[Interface].GridView.ctrlGridView
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabGDCN = New System.Windows.Forms.TabPage
        Me.btnUpChu = New System.Windows.Forms.Button
        Me.btnDownChuGDCN = New System.Windows.Forms.Button
        Me.grdvwChuHoSoDangKyCapGCNGDCN = New DMC.[Interface].GridView.ctrlGridView
        Me.tabCQNN = New System.Windows.Forms.TabPage
        Me.btnUpChu2 = New System.Windows.Forms.Button
        Me.btnDownChuCQNN = New System.Windows.Forms.Button
        Me.grdvwChuHoSoDangKyCapGCNCQNN = New DMC.[Interface].GridView.ctrlGridView
        Me.tabTCDN = New System.Windows.Forms.TabPage
        Me.btnUpChu3 = New System.Windows.Forms.Button
        Me.btnDownChuTCDN = New System.Windows.Forms.Button
        Me.grdvwChuHoSoDangKyCapGCNTCDN = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvwChuDeNghiCapGCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabGDCN.SuspendLayout()
        CType(Me.grdvwChuHoSoDangKyCapGCNGDCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCQNN.SuspendLayout()
        CType(Me.grdvwChuHoSoDangKyCapGCNCQNN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTCDN.SuspendLayout()
        CType(Me.grdvwChuHoSoDangKyCapGCNTCDN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(695, 17)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 10
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'txtGhiChuNoiDungChuDeNghiCapGCN
        '
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.Location = New System.Drawing.Point(4, 193)
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.Name = "txtGhiChuNoiDungChuDeNghiCapGCN"
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.Size = New System.Drawing.Size(753, 59)
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.TabIndex = 5
        Me.txtGhiChuNoiDungChuDeNghiCapGCN.Text = ""
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(186, 17)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 9
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.grdvwChuDeNghiCapGCN)
        Me.GroupBox1.Controls.Add(Me.txtGhiChuNoiDungChuDeNghiCapGCN)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(3, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 263)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nội dung thông tin Chủ (sử dụng, sở hữu) đề nghị ghi tại Mục I, Trang 1 của GCN"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 16)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Ghi chú thông tin Chủ (sử dụng, sở hữu)"
        '
        'grdvwChuDeNghiCapGCN
        '
        Me.grdvwChuDeNghiCapGCN.AllowUserToAddRows = False
        Me.grdvwChuDeNghiCapGCN.AllowUserToDeleteRows = False
        Me.grdvwChuDeNghiCapGCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChuDeNghiCapGCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwChuDeNghiCapGCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChuDeNghiCapGCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwChuDeNghiCapGCN.Location = New System.Drawing.Point(3, 21)
        Me.grdvwChuDeNghiCapGCN.Name = "grdvwChuDeNghiCapGCN"
        Me.grdvwChuDeNghiCapGCN.ReadOnly = True
        Me.grdvwChuDeNghiCapGCN.RowHeadersWidth = 25
        Me.grdvwChuDeNghiCapGCN.Size = New System.Drawing.Size(753, 150)
        Me.grdvwChuDeNghiCapGCN.TabIndex = 4
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(64, 17)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 7
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(3, 17)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 6
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(125, 17)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 8
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabGDCN)
        Me.TabControl1.Controls.Add(Me.tabCQNN)
        Me.TabControl1.Controls.Add(Me.tabTCDN)
        Me.TabControl1.Location = New System.Drawing.Point(6, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(752, 207)
        Me.TabControl1.TabIndex = 0
        '
        'tabGDCN
        '
        Me.tabGDCN.BackColor = System.Drawing.Color.Lavender
        Me.tabGDCN.Controls.Add(Me.btnUpChu)
        Me.tabGDCN.Controls.Add(Me.btnDownChuGDCN)
        Me.tabGDCN.Controls.Add(Me.grdvwChuHoSoDangKyCapGCNGDCN)
        Me.tabGDCN.Location = New System.Drawing.Point(4, 22)
        Me.tabGDCN.Name = "tabGDCN"
        Me.tabGDCN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGDCN.Size = New System.Drawing.Size(744, 181)
        Me.tabGDCN.TabIndex = 0
        Me.tabGDCN.Text = "Hộ gia đình, cá nhân"
        Me.tabGDCN.UseVisualStyleBackColor = True
        '
        'btnUpChu
        '
        Me.btnUpChu.Image = CType(resources.GetObject("btnUpChu.Image"), System.Drawing.Image)
        Me.btnUpChu.Location = New System.Drawing.Point(67, 157)
        Me.btnUpChu.Name = "btnUpChu"
        Me.btnUpChu.Size = New System.Drawing.Size(58, 21)
        Me.btnUpChu.TabIndex = 3
        Me.btnUpChu.UseVisualStyleBackColor = True
        '
        'btnDownChuGDCN
        '
        Me.btnDownChuGDCN.Image = CType(resources.GetObject("btnDownChuGDCN.Image"), System.Drawing.Image)
        Me.btnDownChuGDCN.Location = New System.Drawing.Point(3, 157)
        Me.btnDownChuGDCN.Name = "btnDownChuGDCN"
        Me.btnDownChuGDCN.Size = New System.Drawing.Size(58, 21)
        Me.btnDownChuGDCN.TabIndex = 2
        Me.btnDownChuGDCN.UseVisualStyleBackColor = True
        '
        'grdvwChuHoSoDangKyCapGCNGDCN
        '
        Me.grdvwChuHoSoDangKyCapGCNGDCN.AllowUserToAddRows = False
        Me.grdvwChuHoSoDangKyCapGCNGDCN.AllowUserToDeleteRows = False
        Me.grdvwChuHoSoDangKyCapGCNGDCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChuHoSoDangKyCapGCNGDCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChuHoSoDangKyCapGCNGDCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdvwChuHoSoDangKyCapGCNGDCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChuHoSoDangKyCapGCNGDCN.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdvwChuHoSoDangKyCapGCNGDCN.Location = New System.Drawing.Point(3, 3)
        Me.grdvwChuHoSoDangKyCapGCNGDCN.Name = "grdvwChuHoSoDangKyCapGCNGDCN"
        Me.grdvwChuHoSoDangKyCapGCNGDCN.ReadOnly = True
        Me.grdvwChuHoSoDangKyCapGCNGDCN.RowHeadersWidth = 25
        Me.grdvwChuHoSoDangKyCapGCNGDCN.Size = New System.Drawing.Size(739, 148)
        Me.grdvwChuHoSoDangKyCapGCNGDCN.TabIndex = 1
        '
        'tabCQNN
        '
        Me.tabCQNN.BackColor = System.Drawing.Color.Lavender
        Me.tabCQNN.Controls.Add(Me.btnUpChu2)
        Me.tabCQNN.Controls.Add(Me.btnDownChuCQNN)
        Me.tabCQNN.Controls.Add(Me.grdvwChuHoSoDangKyCapGCNCQNN)
        Me.tabCQNN.Location = New System.Drawing.Point(4, 22)
        Me.tabCQNN.Name = "tabCQNN"
        Me.tabCQNN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCQNN.Size = New System.Drawing.Size(744, 181)
        Me.tabCQNN.TabIndex = 1
        Me.tabCQNN.Text = "Cơ quan nhà nước, UBND"
        Me.tabCQNN.UseVisualStyleBackColor = True
        '
        'btnUpChu2
        '
        Me.btnUpChu2.Image = CType(resources.GetObject("btnUpChu2.Image"), System.Drawing.Image)
        Me.btnUpChu2.Location = New System.Drawing.Point(70, 154)
        Me.btnUpChu2.Name = "btnUpChu2"
        Me.btnUpChu2.Size = New System.Drawing.Size(58, 21)
        Me.btnUpChu2.TabIndex = 3
        Me.btnUpChu2.UseVisualStyleBackColor = True
        '
        'btnDownChuCQNN
        '
        Me.btnDownChuCQNN.Image = CType(resources.GetObject("btnDownChuCQNN.Image"), System.Drawing.Image)
        Me.btnDownChuCQNN.Location = New System.Drawing.Point(6, 154)
        Me.btnDownChuCQNN.Name = "btnDownChuCQNN"
        Me.btnDownChuCQNN.Size = New System.Drawing.Size(58, 21)
        Me.btnDownChuCQNN.TabIndex = 2
        Me.btnDownChuCQNN.UseVisualStyleBackColor = True
        '
        'grdvwChuHoSoDangKyCapGCNCQNN
        '
        Me.grdvwChuHoSoDangKyCapGCNCQNN.AllowUserToAddRows = False
        Me.grdvwChuHoSoDangKyCapGCNCQNN.AllowUserToDeleteRows = False
        Me.grdvwChuHoSoDangKyCapGCNCQNN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChuHoSoDangKyCapGCNCQNN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChuHoSoDangKyCapGCNCQNN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdvwChuHoSoDangKyCapGCNCQNN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChuHoSoDangKyCapGCNCQNN.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdvwChuHoSoDangKyCapGCNCQNN.Location = New System.Drawing.Point(3, 3)
        Me.grdvwChuHoSoDangKyCapGCNCQNN.Name = "grdvwChuHoSoDangKyCapGCNCQNN"
        Me.grdvwChuHoSoDangKyCapGCNCQNN.ReadOnly = True
        Me.grdvwChuHoSoDangKyCapGCNCQNN.RowHeadersWidth = 25
        Me.grdvwChuHoSoDangKyCapGCNCQNN.Size = New System.Drawing.Size(739, 145)
        Me.grdvwChuHoSoDangKyCapGCNCQNN.TabIndex = 1
        '
        'tabTCDN
        '
        Me.tabTCDN.BackColor = System.Drawing.Color.Lavender
        Me.tabTCDN.Controls.Add(Me.btnUpChu3)
        Me.tabTCDN.Controls.Add(Me.btnDownChuTCDN)
        Me.tabTCDN.Controls.Add(Me.grdvwChuHoSoDangKyCapGCNTCDN)
        Me.tabTCDN.Location = New System.Drawing.Point(4, 22)
        Me.tabTCDN.Name = "tabTCDN"
        Me.tabTCDN.Size = New System.Drawing.Size(744, 181)
        Me.tabTCDN.TabIndex = 2
        Me.tabTCDN.Text = "Tổ chức, doanh nghiệp"
        Me.tabTCDN.UseVisualStyleBackColor = True
        '
        'btnUpChu3
        '
        Me.btnUpChu3.Image = CType(resources.GetObject("btnUpChu3.Image"), System.Drawing.Image)
        Me.btnUpChu3.Location = New System.Drawing.Point(67, 157)
        Me.btnUpChu3.Name = "btnUpChu3"
        Me.btnUpChu3.Size = New System.Drawing.Size(58, 21)
        Me.btnUpChu3.TabIndex = 5
        Me.btnUpChu3.UseVisualStyleBackColor = True
        '
        'btnDownChuTCDN
        '
        Me.btnDownChuTCDN.Image = CType(resources.GetObject("btnDownChuTCDN.Image"), System.Drawing.Image)
        Me.btnDownChuTCDN.Location = New System.Drawing.Point(3, 157)
        Me.btnDownChuTCDN.Name = "btnDownChuTCDN"
        Me.btnDownChuTCDN.Size = New System.Drawing.Size(58, 21)
        Me.btnDownChuTCDN.TabIndex = 3
        Me.btnDownChuTCDN.UseVisualStyleBackColor = True
        '
        'grdvwChuHoSoDangKyCapGCNTCDN
        '
        Me.grdvwChuHoSoDangKyCapGCNTCDN.AllowUserToAddRows = False
        Me.grdvwChuHoSoDangKyCapGCNTCDN.AllowUserToDeleteRows = False
        Me.grdvwChuHoSoDangKyCapGCNTCDN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChuHoSoDangKyCapGCNTCDN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChuHoSoDangKyCapGCNTCDN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdvwChuHoSoDangKyCapGCNTCDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChuHoSoDangKyCapGCNTCDN.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdvwChuHoSoDangKyCapGCNTCDN.Location = New System.Drawing.Point(2, 0)
        Me.grdvwChuHoSoDangKyCapGCNTCDN.Name = "grdvwChuHoSoDangKyCapGCNTCDN"
        Me.grdvwChuHoSoDangKyCapGCNTCDN.ReadOnly = True
        Me.grdvwChuHoSoDangKyCapGCNTCDN.RowHeadersWidth = 25
        Me.grdvwChuHoSoDangKyCapGCNTCDN.Size = New System.Drawing.Size(740, 151)
        Me.grdvwChuHoSoDangKyCapGCNTCDN.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnTroGiup)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 471)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(759, 44)
        Me.GroupBox2.TabIndex = 108
        Me.GroupBox2.TabStop = False
        '
        'ctrlThongTinChuDeNghiCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinChuDeNghiCapGCN"
        Me.Size = New System.Drawing.Size(765, 518)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdvwChuDeNghiCapGCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabGDCN.ResumeLayout(False)
        CType(Me.grdvwChuHoSoDangKyCapGCNGDCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCQNN.ResumeLayout(False)
        CType(Me.grdvwChuHoSoDangKyCapGCNCQNN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTCDN.ResumeLayout(False)
        CType(Me.grdvwChuHoSoDangKyCapGCNTCDN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Public WithEvents txtGhiChuNoiDungChuDeNghiCapGCN As System.Windows.Forms.RichTextBox
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGDCN As System.Windows.Forms.TabPage
    Friend WithEvents grdvwChuHoSoDangKyCapGCNGDCN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents tabCQNN As System.Windows.Forms.TabPage
    Friend WithEvents tabTCDN As System.Windows.Forms.TabPage
    Friend WithEvents grdvwChuHoSoDangKyCapGCNCQNN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents grdvwChuHoSoDangKyCapGCNTCDN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents grdvwChuDeNghiCapGCN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnDownChuGDCN As System.Windows.Forms.Button
    Friend WithEvents btnDownChuCQNN As System.Windows.Forms.Button
    Friend WithEvents btnDownChuTCDN As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUpChu As System.Windows.Forms.Button
    Friend WithEvents btnUpChu2 As System.Windows.Forms.Button
    Friend WithEvents btnUpChu3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
