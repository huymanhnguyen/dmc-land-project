<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlNghiepVuHoSo
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
        Dim OutlookBarButton1 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlNghiepVuHoSo))
        Dim OutlookBarButton2 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton3 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton4 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton5 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton6 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton7 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Dim OutlookBarButton8 As DMC.[Interface].OutlookBar.OutlookBarButton = New DMC.[Interface].OutlookBar.OutlookBarButton
        Me.splitContainer = New System.Windows.Forms.SplitContainer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.labChuyenNhuong = New System.Windows.Forms.TextBox
        Me.lbCanhBao = New System.Windows.Forms.TextBox
        Me.lbCanhBaoTranhChap = New System.Windows.Forms.TextBox
        Me.CtrlThongTinThuaTuNhien1 = New DMC.Land.ThongTinThuaTuNhien.ctrlThongTinThuaTuNhien
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PicTrangThai = New System.Windows.Forms.PictureBox
        Me.LabTrangThai = New System.Windows.Forms.Label
        Me.outlookChucNang = New DMC.[Interface].OutlookBar.OutlookBar
        Me.lblHinhAnhThua = New System.Windows.Forms.Label
        Me.rtxtThongTinSoLuoc = New System.Windows.Forms.RichTextBox
        Me.CtrlDangKyBienDong = New prjBienDong.ctrlDangKyBienDong
        Me.CtrlHoSoKeKhai = New DMC.Land.HoSoKeKhaiCapGCN.ctrlHoSoKeKhai
        Me.CtrlThongTinTiepNhanHoSo = New DMC.Land.ThongTinTiepNhanHoSo.ctrlThongTinTiepNhanHoSo
        Me.CtrlThongTinCapGCN = New DMC.Land.ThongTinCapGCN.ctrlThongTinCapGCN
        Me.CtrlPheDuyet = New DMC.Land.PheDuyet.ctrlPheDuyet
        Me.CtrlThamDinh = New DMC.Land.ThamDinh.ctrlThamDinh
        Me.CtrlXetDuyetCapCoSo = New DMC.Land.XetDuyetCapCoSo.ctrlXetDuyetCapCoSo
        Me.splitContainer.Panel1.SuspendLayout()
        Me.splitContainer.Panel2.SuspendLayout()
        Me.splitContainer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicTrangThai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'splitContainer
        '
        Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer.Name = "splitContainer"
        '
        'splitContainer.Panel1
        '
        Me.splitContainer.Panel1.Controls.Add(Me.Panel2)
        Me.splitContainer.Panel1.Controls.Add(Me.CtrlThongTinThuaTuNhien1)
        Me.splitContainer.Panel1.Controls.Add(Me.Panel1)
        Me.splitContainer.Panel1.Controls.Add(Me.rtxtThongTinSoLuoc)
        '
        'splitContainer.Panel2
        '
        Me.splitContainer.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
        Me.splitContainer.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlDangKyBienDong)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlHoSoKeKhai)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlThongTinTiepNhanHoSo)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlThongTinCapGCN)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlPheDuyet)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlThamDinh)
        Me.splitContainer.Panel2.Controls.Add(Me.CtrlXetDuyetCapCoSo)
        Me.splitContainer.Size = New System.Drawing.Size(982, 786)
        Me.splitContainer.SplitterDistance = 229
        Me.splitContainer.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.labChuyenNhuong)
        Me.Panel2.Controls.Add(Me.lbCanhBao)
        Me.Panel2.Controls.Add(Me.lbCanhBaoTranhChap)
        Me.Panel2.Location = New System.Drawing.Point(4, 589)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(225, 131)
        Me.Panel2.TabIndex = 14
        '
        'labChuyenNhuong
        '
        Me.labChuyenNhuong.BackColor = System.Drawing.Color.Red
        Me.labChuyenNhuong.Dock = System.Windows.Forms.DockStyle.Top
        Me.labChuyenNhuong.ForeColor = System.Drawing.SystemColors.Menu
        Me.labChuyenNhuong.Location = New System.Drawing.Point(0, 40)
        Me.labChuyenNhuong.Multiline = True
        Me.labChuyenNhuong.Name = "labChuyenNhuong"
        Me.labChuyenNhuong.ReadOnly = True
        Me.labChuyenNhuong.Size = New System.Drawing.Size(225, 20)
        Me.labChuyenNhuong.TabIndex = 22
        Me.labChuyenNhuong.Visible = False
        Me.labChuyenNhuong.WordWrap = False
        '
        'lbCanhBao
        '
        Me.lbCanhBao.BackColor = System.Drawing.Color.Red
        Me.lbCanhBao.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbCanhBao.ForeColor = System.Drawing.SystemColors.Menu
        Me.lbCanhBao.Location = New System.Drawing.Point(0, 20)
        Me.lbCanhBao.Multiline = True
        Me.lbCanhBao.Name = "lbCanhBao"
        Me.lbCanhBao.ReadOnly = True
        Me.lbCanhBao.Size = New System.Drawing.Size(225, 20)
        Me.lbCanhBao.TabIndex = 21
        Me.lbCanhBao.Visible = False
        Me.lbCanhBao.WordWrap = False
        '
        'lbCanhBaoTranhChap
        '
        Me.lbCanhBaoTranhChap.BackColor = System.Drawing.Color.Red
        Me.lbCanhBaoTranhChap.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbCanhBaoTranhChap.ForeColor = System.Drawing.SystemColors.Menu
        Me.lbCanhBaoTranhChap.Location = New System.Drawing.Point(0, 0)
        Me.lbCanhBaoTranhChap.Multiline = True
        Me.lbCanhBaoTranhChap.Name = "lbCanhBaoTranhChap"
        Me.lbCanhBaoTranhChap.ReadOnly = True
        Me.lbCanhBaoTranhChap.Size = New System.Drawing.Size(225, 20)
        Me.lbCanhBaoTranhChap.TabIndex = 20
        Me.lbCanhBaoTranhChap.Visible = False
        Me.lbCanhBaoTranhChap.WordWrap = False
        '
        'CtrlThongTinThuaTuNhien1
        '
        Me.CtrlThongTinThuaTuNhien1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlThongTinThuaTuNhien1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CtrlThongTinThuaTuNhien1.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinThuaTuNhien1.Location = New System.Drawing.Point(1, 0)
        Me.CtrlThongTinThuaTuNhien1.MaDonViHanhChinh = ""
        Me.CtrlThongTinThuaTuNhien1.MaHoSoCapGCNLichSu = Nothing
        Me.CtrlThongTinThuaTuNhien1.MaHSChon = ""
        Me.CtrlThongTinThuaTuNhien1.Name = "CtrlThongTinThuaTuNhien1"
        Me.CtrlThongTinThuaTuNhien1.Size = New System.Drawing.Size(227, 229)
        Me.CtrlThongTinThuaTuNhien1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.PicTrangThai)
        Me.Panel1.Controls.Add(Me.LabTrangThai)
        Me.Panel1.Controls.Add(Me.outlookChucNang)
        Me.Panel1.Controls.Add(Me.lblHinhAnhThua)
        Me.Panel1.Location = New System.Drawing.Point(4, 229)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(227, 354)
        Me.Panel1.TabIndex = 13
        '
        'PicTrangThai
        '
        Me.PicTrangThai.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PicTrangThai.Location = New System.Drawing.Point(4, 323)
        Me.PicTrangThai.Name = "PicTrangThai"
        Me.PicTrangThai.Size = New System.Drawing.Size(28, 25)
        Me.PicTrangThai.TabIndex = 14
        Me.PicTrangThai.TabStop = False
        Me.PicTrangThai.Visible = False
        '
        'LabTrangThai
        '
        Me.LabTrangThai.AutoSize = True
        Me.LabTrangThai.Location = New System.Drawing.Point(38, 328)
        Me.LabTrangThai.Name = "LabTrangThai"
        Me.LabTrangThai.Size = New System.Drawing.Size(25, 13)
        Me.LabTrangThai.TabIndex = 15
        Me.LabTrangThai.Text = "......"
        Me.LabTrangThai.Visible = False
        '
        'outlookChucNang
        '
        Me.outlookChucNang.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.outlookChucNang.ButtonColorHoveringBottom = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorHoveringTop = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorPassiveBottom = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorPassiveTop = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorSelectedAndHoveringBottom = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorSelectedAndHoveringTop = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorSelectedBottom = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonColorSelectedTop = System.Drawing.Color.Empty
        Me.outlookChucNang.ButtonHeight = 35
        OutlookBarButton1.Image = CType(resources.GetObject("OutlookBarButton1.Image"), System.Drawing.Icon)
        OutlookBarButton1.Text = "Tìm kiếm"
        OutlookBarButton2.Image = CType(resources.GetObject("OutlookBarButton2.Image"), System.Drawing.Icon)
        OutlookBarButton2.Text = "Tiếp nhận hồ sơ"
        OutlookBarButton3.Image = CType(resources.GetObject("OutlookBarButton3.Image"), System.Drawing.Icon)
        OutlookBarButton3.Text = "Hồ sơ kê khai"
        OutlookBarButton4.Image = CType(resources.GetObject("OutlookBarButton4.Image"), System.Drawing.Icon)
        OutlookBarButton4.Text = "Xét duyệt cấp cơ sở"
        OutlookBarButton5.Image = CType(resources.GetObject("OutlookBarButton5.Image"), System.Drawing.Icon)
        OutlookBarButton5.Text = "Thẩm định"
        OutlookBarButton6.Image = CType(resources.GetObject("OutlookBarButton6.Image"), System.Drawing.Icon)
        OutlookBarButton6.Text = "Phê duyệt"
        OutlookBarButton7.Image = CType(resources.GetObject("OutlookBarButton7.Image"), System.Drawing.Icon)
        OutlookBarButton7.Text = "Cấp Giấy chứng nhận"
        OutlookBarButton8.Image = CType(resources.GetObject("OutlookBarButton8.Image"), System.Drawing.Icon)
        OutlookBarButton8.Text = "Đăng ký biến động"
        Me.outlookChucNang.Buttons.Add(OutlookBarButton1)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton2)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton3)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton4)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton5)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton6)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton7)
        Me.outlookChucNang.Buttons.Add(OutlookBarButton8)
        Me.outlookChucNang.Dock = System.Windows.Forms.DockStyle.Top
        Me.outlookChucNang.ForeColorSelected = System.Drawing.Color.Empty
        Me.outlookChucNang.Location = New System.Drawing.Point(0, 0)
        Me.outlookChucNang.MinimumSize = New System.Drawing.Size(16, 40)
        Me.outlookChucNang.Name = "outlookChucNang"
        Me.outlookChucNang.OutlookBarLineColor = System.Drawing.Color.Empty
        Me.outlookChucNang.Renderer = DMC.[Interface].OutlookBar.Renderer.Outlook2007
        Me.outlookChucNang.Size = New System.Drawing.Size(227, 296)
        Me.outlookChucNang.TabIndex = 10
        Me.outlookChucNang.Text = "Chuc Nang"
        '
        'lblHinhAnhThua
        '
        Me.lblHinhAnhThua.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHinhAnhThua.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblHinhAnhThua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHinhAnhThua.Image = CType(resources.GetObject("lblHinhAnhThua.Image"), System.Drawing.Image)
        Me.lblHinhAnhThua.Location = New System.Drawing.Point(-2, 297)
        Me.lblHinhAnhThua.Name = "lblHinhAnhThua"
        Me.lblHinhAnhThua.Size = New System.Drawing.Size(229, 21)
        Me.lblHinhAnhThua.TabIndex = 2
        Me.lblHinhAnhThua.Text = "Tiến trình thủ tục Hồ sơ cấp GCN"
        Me.lblHinhAnhThua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHinhAnhThua.UseCompatibleTextRendering = True
        '
        'rtxtThongTinSoLuoc
        '
        Me.rtxtThongTinSoLuoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtxtThongTinSoLuoc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rtxtThongTinSoLuoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtxtThongTinSoLuoc.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtThongTinSoLuoc.ForeColor = System.Drawing.Color.Red
        Me.rtxtThongTinSoLuoc.Location = New System.Drawing.Point(3, 745)
        Me.rtxtThongTinSoLuoc.Name = "rtxtThongTinSoLuoc"
        Me.rtxtThongTinSoLuoc.ReadOnly = True
        Me.rtxtThongTinSoLuoc.Size = New System.Drawing.Size(223, 38)
        Me.rtxtThongTinSoLuoc.TabIndex = 3
        Me.rtxtThongTinSoLuoc.Text = ""
        Me.rtxtThongTinSoLuoc.Visible = False
        '
        'CtrlDangKyBienDong
        '
        Me.CtrlDangKyBienDong.AutoScroll = True
        Me.CtrlDangKyBienDong.BackColor = System.Drawing.Color.Lavender
        Me.CtrlDangKyBienDong.Flag = ""
        Me.CtrlDangKyBienDong.KyHieu = ""
        Me.CtrlDangKyBienDong.Location = New System.Drawing.Point(10, 416)
        Me.CtrlDangKyBienDong.MaBD = 0
        Me.CtrlDangKyBienDong.MaDonViHanhChinh = ""
        Me.CtrlDangKyBienDong.MaKhoa = ""
        Me.CtrlDangKyBienDong.MaThuaDat = ""
        Me.CtrlDangKyBienDong.Name = "CtrlDangKyBienDong"
        Me.CtrlDangKyBienDong.Nhom = ""
        Me.CtrlDangKyBienDong.Size = New System.Drawing.Size(819, 741)
        Me.CtrlDangKyBienDong.TabIndex = 89
        Me.CtrlDangKyBienDong.TenDonViHanhChinh = ""
        Me.CtrlDangKyBienDong.TenPhuong = ""
        '
        'CtrlHoSoKeKhai
        '
        Me.CtrlHoSoKeKhai.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlHoSoKeKhai.AutoScroll = True
        Me.CtrlHoSoKeKhai.BackColor = System.Drawing.Color.Lavender
        Me.CtrlHoSoKeKhai.Connection = ""
        Me.CtrlHoSoKeKhai.Location = New System.Drawing.Point(10, 379)
        Me.CtrlHoSoKeKhai.MaHoSoCapGCN = ""
        Me.CtrlHoSoKeKhai.Name = "CtrlHoSoKeKhai"
        Me.CtrlHoSoKeKhai.Size = New System.Drawing.Size(746, 623)
        Me.CtrlHoSoKeKhai.TabIndex = 88
        '
        'CtrlThongTinTiepNhanHoSo
        '
        Me.CtrlThongTinTiepNhanHoSo.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinTiepNhanHoSo.Location = New System.Drawing.Point(4, 340)
        Me.CtrlThongTinTiepNhanHoSo.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinTiepNhanHoSo.MaHoSoCapGCN = CType(0, Long)
        Me.CtrlThongTinTiepNhanHoSo.MaKhoa = ""
        Me.CtrlThongTinTiepNhanHoSo.Name = "CtrlThongTinTiepNhanHoSo"
        Me.CtrlThongTinTiepNhanHoSo.Size = New System.Drawing.Size(737, 298)
        Me.CtrlThongTinTiepNhanHoSo.TabIndex = 87
        '
        'CtrlThongTinCapGCN
        '
        Me.CtrlThongTinCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinCapGCN.Location = New System.Drawing.Point(2, 295)
        Me.CtrlThongTinCapGCN.Name = "CtrlThongTinCapGCN"
        Me.CtrlThongTinCapGCN.Size = New System.Drawing.Size(742, 387)
        Me.CtrlThongTinCapGCN.TabIndex = 84
        Me.CtrlThongTinCapGCN.UserName = ""
        '
        'CtrlPheDuyet
        '
        Me.CtrlPheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlPheDuyet.BackColor = System.Drawing.Color.Lavender
        Me.CtrlPheDuyet.Flag = "0"
        Me.CtrlPheDuyet.Location = New System.Drawing.Point(10, 202)
        Me.CtrlPheDuyet.MaDonViHanhChinh = ""
        Me.CtrlPheDuyet.MaKhoa = ""
        Me.CtrlPheDuyet.Name = "CtrlPheDuyet"
        Me.CtrlPheDuyet.Size = New System.Drawing.Size(739, 181)
        Me.CtrlPheDuyet.TabIndex = 83
        '
        'CtrlThamDinh
        '
        Me.CtrlThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThamDinh.Flag = ""
        Me.CtrlThamDinh.Location = New System.Drawing.Point(2, 151)
        Me.CtrlThamDinh.MaDonVihanhChinh = Nothing
        Me.CtrlThamDinh.MaHoSoCapGCN = ""
        Me.CtrlThamDinh.MaKhoa = ""
        Me.CtrlThamDinh.Name = "CtrlThamDinh"
        Me.CtrlThamDinh.Size = New System.Drawing.Size(746, 496)
        Me.CtrlThamDinh.TabIndex = 82
        Me.CtrlThamDinh.UserName = ""
        '
        'CtrlXetDuyetCapCoSo
        '
        Me.CtrlXetDuyetCapCoSo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlXetDuyetCapCoSo.BackColor = System.Drawing.Color.Lavender
        Me.CtrlXetDuyetCapCoSo.Connection = ""
        Me.CtrlXetDuyetCapCoSo.Location = New System.Drawing.Point(2, 43)
        Me.CtrlXetDuyetCapCoSo.MaDonViHanhChinh = Nothing
        Me.CtrlXetDuyetCapCoSo.MaHoSoCapGCN = ""
        Me.CtrlXetDuyetCapCoSo.Name = "CtrlXetDuyetCapCoSo"
        Me.CtrlXetDuyetCapCoSo.Size = New System.Drawing.Size(743, 466)
        Me.CtrlXetDuyetCapCoSo.TabIndex = 81
        '
        'ctrlNghiepVuHoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.splitContainer)
        Me.Name = "ctrlNghiepVuHoSo"
        Me.Size = New System.Drawing.Size(982, 786)
        Me.splitContainer.Panel1.ResumeLayout(False)
        Me.splitContainer.Panel2.ResumeLayout(False)
        Me.splitContainer.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicTrangThai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rtxtThongTinSoLuoc As System.Windows.Forms.RichTextBox
    Friend WithEvents lblHinhAnhThua As System.Windows.Forms.Label
    Friend WithEvents CtrlThongTinThuaTuNhien1 As DMC.Land.ThongTinThuaTuNhien.ctrlThongTinThuaTuNhien
    Friend WithEvents CtrlThongTinCapGCN As DMC.Land.ThongTinCapGCN.ctrlThongTinCapGCN
    Friend WithEvents CtrlPheDuyet As DMC.Land.PheDuyet.ctrlPheDuyet
    Friend WithEvents CtrlThamDinh As DMC.Land.ThamDinh.ctrlThamDinh
    Friend WithEvents CtrlXetDuyetCapCoSo As DMC.Land.XetDuyetCapCoSo.ctrlXetDuyetCapCoSo
    Public WithEvents outlookChucNang As DMC.Interface.OutlookBar.OutlookBar
    Friend WithEvents CtrlThongTinTiepNhanHoSo As DMC.Land.ThongTinTiepNhanHoSo.ctrlThongTinTiepNhanHoSo
    Public WithEvents CtrlHoSoKeKhai As DMC.Land.HoSoKeKhaiCapGCN.ctrlHoSoKeKhai
    Friend WithEvents LabTrangThai As System.Windows.Forms.Label
    Friend WithEvents PicTrangThai As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbCanhBao As System.Windows.Forms.TextBox
    Friend WithEvents lbCanhBaoTranhChap As System.Windows.Forms.TextBox
    Friend WithEvents labChuyenNhuong As System.Windows.Forms.TextBox
    Friend WithEvents CtrlDangKyBienDong As prjBienDong.ctrlDangKyBienDong

End Class
