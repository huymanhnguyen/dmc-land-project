Imports DMC.Land.MucDich
Imports DMC.Land.NguonGoc
Imports DMC.Land.ChuSuDungDat
Imports DMC.Land.YeuCauBoXung
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThamDinh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlThamDinh))
        Me.lblActiveThamDinh = New System.Windows.Forms.Label
        Me.tabYeuCauBoXung = New System.Windows.Forms.TabPage
        Me.CtrlYeuCauBoXungThamDinh = New DMC.Land.YeuCauBoSung.ctrlYeuCauBoXung
        Me.tabKetQuaThamDinh = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CtrlThongTinCanBoThamDinh = New DMC.Land.ThamDinh.ctrlThongTinCanBoThamDinh
        Me.tabChu = New System.Windows.Forms.TabPage
        Me.CtrlThongTinChuDeNghiCapGCN = New DMC.Land.ThamDinh.ctrlThongTinChuDeNghiCapGCN
        Me.tabThuaDat = New System.Windows.Forms.TabPage
        Me.CtrlThamDinhThuaDat = New DMC.Land.ThamDinh.ctrlThongTinThuaDatDeNghiCapGCN
        Me.tabNhaO = New System.Windows.Forms.TabPage
        Me.CtrlThongTinNhaODeNghiCapGCN = New DMC.Land.ThamDinh.ctrlThongTinNhaODeNghiCapGCN
        Me.tabCongTrinhXayDungKhac = New System.Windows.Forms.TabPage
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN = New DMC.Land.ThamDinh.ctrlThongTinCongTrinhXayDungDeNghiCapGCN
        Me.tabRungCay = New System.Windows.Forms.TabPage
        Me.CtrlThongTinRungCayDeNghiCapGCN = New DMC.Land.ThamDinh.ctrlThongTinRungCayDeNghiCapGCN
        Me.tabCayLauNam = New System.Windows.Forms.TabPage
        Me.CtrlThongTinCayLauNamDeNghiCapGCN = New DMC.Land.ThamDinh.ctrlThongTinCayLauNamDeNghiCapGCN
        Me.tabSoDoNhaDat = New System.Windows.Forms.TabPage
        Me.CtrlThongTinSoDoNhaDat = New DMC.Land.ThongTinSoDoNhaDat.ctrlThongTinSoDoNhaDat
        Me.tabThongTinPhapLyKhac = New System.Windows.Forms.TabPage
        Me.CtrlThongTinPhapLyKhac = New DMC.Land.ThamDinh.ctrlThongTinPhapLyKhac
        Me.tabThamDinh = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.tabThongTinSoCapGCN = New System.Windows.Forms.TabPage
        Me.CtrlThongTinSoCapGCN = New DMC.Land.ThamDinh.ctrlThongTinSoCapGCN
        Me.tabThongTinKyGCN = New System.Windows.Forms.TabPage
        Me.CtrlThongTinKyGCN = New DMC.Land.ThamDinh.ctrlThongTinKyGCN
        Me.tabThongTinCapGCNKhac = New System.Windows.Forms.TabPage
        Me.CtrlThongTinGCN = New DMC.Land.ThamDinh.ctrlThongTinGCN
        Me.tabThongTinMaVach = New System.Windows.Forms.TabPage
        Me.CtrlEncodeEAN13 = New DMC.Barcode.ctrlEncodeEAN13
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtLyDoKhongCap = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.cmbKetQuaPheDuyet = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtYKienPheDuyet = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTenCanBoPheDuyet = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPNgayPheDuyet = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnKhongDuDK = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CtrTrangThaiHoSo1 = New prjTrangThaiHoSo.ctrTrangThaiHoSo
        Me.tabYeuCauBoXung.SuspendLayout()
        Me.tabKetQuaThamDinh.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabChu.SuspendLayout()
        Me.tabThuaDat.SuspendLayout()
        Me.tabNhaO.SuspendLayout()
        Me.tabCongTrinhXayDungKhac.SuspendLayout()
        Me.tabRungCay.SuspendLayout()
        Me.tabCayLauNam.SuspendLayout()
        Me.tabSoDoNhaDat.SuspendLayout()
        Me.tabThongTinPhapLyKhac.SuspendLayout()
        Me.tabThamDinh.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tabThongTinSoCapGCN.SuspendLayout()
        Me.tabThongTinKyGCN.SuspendLayout()
        Me.tabThongTinCapGCNKhac.SuspendLayout()
        Me.tabThongTinMaVach.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblActiveThamDinh
        '
        Me.lblActiveThamDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActiveThamDinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveThamDinh.Image = CType(resources.GetObject("lblActiveThamDinh.Image"), System.Drawing.Image)
        Me.lblActiveThamDinh.Location = New System.Drawing.Point(0, 0)
        Me.lblActiveThamDinh.Name = "lblActiveThamDinh"
        Me.lblActiveThamDinh.Size = New System.Drawing.Size(769, 20)
        Me.lblActiveThamDinh.TabIndex = 26
        Me.lblActiveThamDinh.Text = "THÔNG TIN THẨM ĐỊNH"
        Me.lblActiveThamDinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabYeuCauBoXung
        '
        Me.tabYeuCauBoXung.BackColor = System.Drawing.Color.Lavender
        Me.tabYeuCauBoXung.Controls.Add(Me.CtrlYeuCauBoXungThamDinh)
        Me.tabYeuCauBoXung.Location = New System.Drawing.Point(4, 22)
        Me.tabYeuCauBoXung.Name = "tabYeuCauBoXung"
        Me.tabYeuCauBoXung.Padding = New System.Windows.Forms.Padding(3)
        Me.tabYeuCauBoXung.Size = New System.Drawing.Size(756, 536)
        Me.tabYeuCauBoXung.TabIndex = 1
        Me.tabYeuCauBoXung.Text = "Yêu cầu bổ xung"
        Me.tabYeuCauBoXung.UseVisualStyleBackColor = True
        '
        'CtrlYeuCauBoXungThamDinh
        '
        Me.CtrlYeuCauBoXungThamDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlYeuCauBoXungThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlYeuCauBoXungThamDinh.Location = New System.Drawing.Point(2, 2)
        Me.CtrlYeuCauBoXungThamDinh.MaKhoa = ""
        Me.CtrlYeuCauBoXungThamDinh.Name = "CtrlYeuCauBoXungThamDinh"
        Me.CtrlYeuCauBoXungThamDinh.Size = New System.Drawing.Size(743, 437)
        Me.CtrlYeuCauBoXungThamDinh.TabIndex = 0
        '
        'tabKetQuaThamDinh
        '
        Me.tabKetQuaThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.tabKetQuaThamDinh.Controls.Add(Me.TabControl1)
        Me.tabKetQuaThamDinh.Location = New System.Drawing.Point(4, 22)
        Me.tabKetQuaThamDinh.Name = "tabKetQuaThamDinh"
        Me.tabKetQuaThamDinh.Padding = New System.Windows.Forms.Padding(3)
        Me.tabKetQuaThamDinh.Size = New System.Drawing.Size(756, 536)
        Me.tabKetQuaThamDinh.TabIndex = 0
        Me.tabKetQuaThamDinh.Text = "Kết quả thẩm định và Thông tin đề nghị cấp GCN"
        Me.tabKetQuaThamDinh.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tabChu)
        Me.TabControl1.Controls.Add(Me.tabThuaDat)
        Me.TabControl1.Controls.Add(Me.tabNhaO)
        Me.TabControl1.Controls.Add(Me.tabCongTrinhXayDungKhac)
        Me.TabControl1.Controls.Add(Me.tabRungCay)
        Me.TabControl1.Controls.Add(Me.tabCayLauNam)
        Me.TabControl1.Controls.Add(Me.tabSoDoNhaDat)
        Me.TabControl1.Controls.Add(Me.tabThongTinPhapLyKhac)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(750, 530)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CtrlThongTinCanBoThamDinh)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(742, 504)
        Me.TabPage1.TabIndex = 8
        Me.TabPage1.Text = "Kết quả thẩm định"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CtrlThongTinCanBoThamDinh
        '
        Me.CtrlThongTinCanBoThamDinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinCanBoThamDinh.DienTichKeKhai = "0"
        Me.CtrlThongTinCanBoThamDinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinCanBoThamDinh.Flag = ""
        Me.CtrlThongTinCanBoThamDinh.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinCanBoThamDinh.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinCanBoThamDinh.MaKhoa = ""
        Me.CtrlThongTinCanBoThamDinh.Name = "CtrlThongTinCanBoThamDinh"
        Me.CtrlThongTinCanBoThamDinh.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinCanBoThamDinh.TabIndex = 1
        '
        'tabChu
        '
        Me.tabChu.BackColor = System.Drawing.Color.Lavender
        Me.tabChu.Controls.Add(Me.CtrlThongTinChuDeNghiCapGCN)
        Me.tabChu.Location = New System.Drawing.Point(4, 22)
        Me.tabChu.Name = "tabChu"
        Me.tabChu.Size = New System.Drawing.Size(742, 504)
        Me.tabChu.TabIndex = 6
        Me.tabChu.Text = "Thông tin Chủ"
        Me.tabChu.UseVisualStyleBackColor = True
        '
        'CtrlThongTinChuDeNghiCapGCN
        '
        Me.CtrlThongTinChuDeNghiCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinChuDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinChuDeNghiCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinChuDeNghiCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongTinChuDeNghiCapGCN.MaKhoa = ""
        Me.CtrlThongTinChuDeNghiCapGCN.Name = "CtrlThongTinChuDeNghiCapGCN"
        Me.CtrlThongTinChuDeNghiCapGCN.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinChuDeNghiCapGCN.TabIndex = 0
        '
        'tabThuaDat
        '
        Me.tabThuaDat.Controls.Add(Me.CtrlThamDinhThuaDat)
        Me.tabThuaDat.Location = New System.Drawing.Point(4, 22)
        Me.tabThuaDat.Name = "tabThuaDat"
        Me.tabThuaDat.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThuaDat.Size = New System.Drawing.Size(742, 504)
        Me.tabThuaDat.TabIndex = 0
        Me.tabThuaDat.Text = "Thửa đất"
        Me.tabThuaDat.UseVisualStyleBackColor = True
        '
        'CtrlThamDinhThuaDat
        '
        Me.CtrlThamDinhThuaDat.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThamDinhThuaDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThamDinhThuaDat.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThamDinhThuaDat.MaDonViHanhChinh = ""
        Me.CtrlThamDinhThuaDat.MaKhoa = ""
        Me.CtrlThamDinhThuaDat.Name = "CtrlThamDinhThuaDat"
        Me.CtrlThamDinhThuaDat.Size = New System.Drawing.Size(736, 498)
        Me.CtrlThamDinhThuaDat.TabIndex = 1
        '
        'tabNhaO
        '
        Me.tabNhaO.BackColor = System.Drawing.Color.Lavender
        Me.tabNhaO.Controls.Add(Me.CtrlThongTinNhaODeNghiCapGCN)
        Me.tabNhaO.Location = New System.Drawing.Point(4, 22)
        Me.tabNhaO.Name = "tabNhaO"
        Me.tabNhaO.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNhaO.Size = New System.Drawing.Size(742, 504)
        Me.tabNhaO.TabIndex = 1
        Me.tabNhaO.Text = "Nhà ở"
        Me.tabNhaO.UseVisualStyleBackColor = True
        '
        'CtrlThongTinNhaODeNghiCapGCN
        '
        Me.CtrlThongTinNhaODeNghiCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinNhaODeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinNhaODeNghiCapGCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinNhaODeNghiCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongTinNhaODeNghiCapGCN.MaKhoa = ""
        Me.CtrlThongTinNhaODeNghiCapGCN.Name = "CtrlThongTinNhaODeNghiCapGCN"
        Me.CtrlThongTinNhaODeNghiCapGCN.Size = New System.Drawing.Size(736, 498)
        Me.CtrlThongTinNhaODeNghiCapGCN.TabIndex = 0
        '
        'tabCongTrinhXayDungKhac
        '
        Me.tabCongTrinhXayDungKhac.Controls.Add(Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN)
        Me.tabCongTrinhXayDungKhac.Location = New System.Drawing.Point(4, 22)
        Me.tabCongTrinhXayDungKhac.Name = "tabCongTrinhXayDungKhac"
        Me.tabCongTrinhXayDungKhac.Size = New System.Drawing.Size(742, 504)
        Me.tabCongTrinhXayDungKhac.TabIndex = 2
        Me.tabCongTrinhXayDungKhac.Text = "Công trình xây dựng khác"
        Me.tabCongTrinhXayDungKhac.UseVisualStyleBackColor = True
        '
        'CtrlThongTinCongTrinhXayDungDeNghiCapGCN
        '
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.MaKhoa = ""
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.Name = "CtrlThongTinCongTrinhXayDungDeNghiCapGCN"
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinCongTrinhXayDungDeNghiCapGCN.TabIndex = 0
        '
        'tabRungCay
        '
        Me.tabRungCay.Controls.Add(Me.CtrlThongTinRungCayDeNghiCapGCN)
        Me.tabRungCay.Location = New System.Drawing.Point(4, 22)
        Me.tabRungCay.Name = "tabRungCay"
        Me.tabRungCay.Size = New System.Drawing.Size(742, 504)
        Me.tabRungCay.TabIndex = 3
        Me.tabRungCay.Text = "Rừng cây"
        Me.tabRungCay.UseVisualStyleBackColor = True
        '
        'CtrlThongTinRungCayDeNghiCapGCN
        '
        Me.CtrlThongTinRungCayDeNghiCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinRungCayDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinRungCayDeNghiCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinRungCayDeNghiCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongTinRungCayDeNghiCapGCN.MaKhoa = ""
        Me.CtrlThongTinRungCayDeNghiCapGCN.Name = "CtrlThongTinRungCayDeNghiCapGCN"
        Me.CtrlThongTinRungCayDeNghiCapGCN.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinRungCayDeNghiCapGCN.TabIndex = 0
        '
        'tabCayLauNam
        '
        Me.tabCayLauNam.Controls.Add(Me.CtrlThongTinCayLauNamDeNghiCapGCN)
        Me.tabCayLauNam.Location = New System.Drawing.Point(4, 22)
        Me.tabCayLauNam.Name = "tabCayLauNam"
        Me.tabCayLauNam.Size = New System.Drawing.Size(742, 504)
        Me.tabCayLauNam.TabIndex = 4
        Me.tabCayLauNam.Text = "Cây lâu năm"
        Me.tabCayLauNam.UseVisualStyleBackColor = True
        '
        'CtrlThongTinCayLauNamDeNghiCapGCN
        '
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.MaKhoa = ""
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.Name = "CtrlThongTinCayLauNamDeNghiCapGCN"
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinCayLauNamDeNghiCapGCN.TabIndex = 0
        '
        'tabSoDoNhaDat
        '
        Me.tabSoDoNhaDat.Controls.Add(Me.CtrlThongTinSoDoNhaDat)
        Me.tabSoDoNhaDat.Location = New System.Drawing.Point(4, 22)
        Me.tabSoDoNhaDat.Name = "tabSoDoNhaDat"
        Me.tabSoDoNhaDat.Size = New System.Drawing.Size(742, 504)
        Me.tabSoDoNhaDat.TabIndex = 7
        Me.tabSoDoNhaDat.Text = "Sơ đồ Nhà, Đất"
        Me.tabSoDoNhaDat.UseVisualStyleBackColor = True
        '
        'CtrlThongTinSoDoNhaDat
        '
        Me.CtrlThongTinSoDoNhaDat.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinSoDoNhaDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinSoDoNhaDat.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinSoDoNhaDat.MaDonVihanhChinh = Nothing
        Me.CtrlThongTinSoDoNhaDat.MaHoSoCapGCN = ""
        Me.CtrlThongTinSoDoNhaDat.MaKhoa = ""
        Me.CtrlThongTinSoDoNhaDat.Name = "CtrlThongTinSoDoNhaDat"
        Me.CtrlThongTinSoDoNhaDat.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinSoDoNhaDat.TabIndex = 0
        '
        'tabThongTinPhapLyKhac
        '
        Me.tabThongTinPhapLyKhac.Controls.Add(Me.CtrlThongTinPhapLyKhac)
        Me.tabThongTinPhapLyKhac.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinPhapLyKhac.Name = "tabThongTinPhapLyKhac"
        Me.tabThongTinPhapLyKhac.Size = New System.Drawing.Size(742, 504)
        Me.tabThongTinPhapLyKhac.TabIndex = 5
        Me.tabThongTinPhapLyKhac.Text = "Thông tin pháp lý khác"
        Me.tabThongTinPhapLyKhac.UseVisualStyleBackColor = True
        '
        'CtrlThongTinPhapLyKhac
        '
        Me.CtrlThongTinPhapLyKhac.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinPhapLyKhac.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinPhapLyKhac.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinPhapLyKhac.MaDonViHanhChinh = ""
        Me.CtrlThongTinPhapLyKhac.MaKhoa = ""
        Me.CtrlThongTinPhapLyKhac.Name = "CtrlThongTinPhapLyKhac"
        Me.CtrlThongTinPhapLyKhac.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinPhapLyKhac.TabIndex = 0
        '
        'tabThamDinh
        '
        Me.tabThamDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabThamDinh.Controls.Add(Me.tabKetQuaThamDinh)
        Me.tabThamDinh.Controls.Add(Me.tabYeuCauBoXung)
        Me.tabThamDinh.Controls.Add(Me.TabPage3)
        Me.tabThamDinh.Controls.Add(Me.TabPage4)
        Me.tabThamDinh.Controls.Add(Me.TabPage2)
        Me.tabThamDinh.Location = New System.Drawing.Point(3, 23)
        Me.tabThamDinh.Name = "tabThamDinh"
        Me.tabThamDinh.SelectedIndex = 0
        Me.tabThamDinh.Size = New System.Drawing.Size(764, 562)
        Me.tabThamDinh.TabIndex = 28
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TabControl2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(756, 536)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Soạn TT, QĐ, GCN"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tabThongTinSoCapGCN)
        Me.TabControl2.Controls.Add(Me.tabThongTinKyGCN)
        Me.TabControl2.Controls.Add(Me.tabThongTinCapGCNKhac)
        Me.TabControl2.Controls.Add(Me.tabThongTinMaVach)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(756, 536)
        Me.TabControl2.TabIndex = 1
        '
        'tabThongTinSoCapGCN
        '
        Me.tabThongTinSoCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinSoCapGCN.Controls.Add(Me.CtrlThongTinSoCapGCN)
        Me.tabThongTinSoCapGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinSoCapGCN.Name = "tabThongTinSoCapGCN"
        Me.tabThongTinSoCapGCN.Size = New System.Drawing.Size(748, 510)
        Me.tabThongTinSoCapGCN.TabIndex = 3
        Me.tabThongTinSoCapGCN.Text = "Thông tin sổ cấp GCN"
        Me.tabThongTinSoCapGCN.UseVisualStyleBackColor = True
        '
        'CtrlThongTinSoCapGCN
        '
        Me.CtrlThongTinSoCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinSoCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinSoCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinSoCapGCN.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinSoCapGCN.MaKhoa = ""
        Me.CtrlThongTinSoCapGCN.Name = "CtrlThongTinSoCapGCN"
        Me.CtrlThongTinSoCapGCN.Size = New System.Drawing.Size(748, 510)
        Me.CtrlThongTinSoCapGCN.TabIndex = 0
        '
        'tabThongTinKyGCN
        '
        Me.tabThongTinKyGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinKyGCN.Controls.Add(Me.CtrlThongTinKyGCN)
        Me.tabThongTinKyGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinKyGCN.Name = "tabThongTinKyGCN"
        Me.tabThongTinKyGCN.Size = New System.Drawing.Size(748, 510)
        Me.tabThongTinKyGCN.TabIndex = 2
        Me.tabThongTinKyGCN.Text = "Thông tin ký GCN"
        Me.tabThongTinKyGCN.UseVisualStyleBackColor = True
        '
        'CtrlThongTinKyGCN
        '
        Me.CtrlThongTinKyGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinKyGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinKyGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinKyGCN.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinKyGCN.MaKhoa = ""
        Me.CtrlThongTinKyGCN.Name = "CtrlThongTinKyGCN"
        Me.CtrlThongTinKyGCN.Size = New System.Drawing.Size(748, 510)
        Me.CtrlThongTinKyGCN.TabIndex = 0
        '
        'tabThongTinCapGCNKhac
        '
        Me.tabThongTinCapGCNKhac.Controls.Add(Me.CtrlThongTinGCN)
        Me.tabThongTinCapGCNKhac.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinCapGCNKhac.Name = "tabThongTinCapGCNKhac"
        Me.tabThongTinCapGCNKhac.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinCapGCNKhac.Size = New System.Drawing.Size(748, 510)
        Me.tabThongTinCapGCNKhac.TabIndex = 0
        Me.tabThongTinCapGCNKhac.Text = "Thông tin cấp GCN khác"
        Me.tabThongTinCapGCNKhac.UseVisualStyleBackColor = True
        '
        'CtrlThongTinGCN
        '
        Me.CtrlThongTinGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinGCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinGCN.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinGCN.MaKhoa = ""
        Me.CtrlThongTinGCN.Name = "CtrlThongTinGCN"
        Me.CtrlThongTinGCN.Size = New System.Drawing.Size(742, 504)
        Me.CtrlThongTinGCN.TabIndex = 2
        '
        'tabThongTinMaVach
        '
        Me.tabThongTinMaVach.Controls.Add(Me.CtrlEncodeEAN13)
        Me.tabThongTinMaVach.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinMaVach.Name = "tabThongTinMaVach"
        Me.tabThongTinMaVach.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinMaVach.Size = New System.Drawing.Size(748, 510)
        Me.tabThongTinMaVach.TabIndex = 1
        Me.tabThongTinMaVach.Text = "Thông tin Mã vạch"
        Me.tabThongTinMaVach.UseVisualStyleBackColor = True
        '
        'CtrlEncodeEAN13
        '
        Me.CtrlEncodeEAN13.BackColor = System.Drawing.Color.Lavender
        Me.CtrlEncodeEAN13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlEncodeEAN13.Location = New System.Drawing.Point(3, 3)
        Me.CtrlEncodeEAN13.MaDonViHanhChinh = ""
        Me.CtrlEncodeEAN13.MaHoSoCapGCN = Nothing
        Me.CtrlEncodeEAN13.MaKhoa = ""
        Me.CtrlEncodeEAN13.Name = "CtrlEncodeEAN13"
        Me.CtrlEncodeEAN13.Size = New System.Drawing.Size(742, 504)
        Me.CtrlEncodeEAN13.TabIndex = 4
        Me.CtrlEncodeEAN13.UserName = ""
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Lavender
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(756, 536)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "Lãnh đạo duyệt"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.btnTroGiup)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Controls.Add(Me.btnCapNhat)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 46)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(6, 19)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(666, 19)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 12
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(247, 19)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 11
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(67, 19)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(127, 19)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(187, 19)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 10
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtLyDoKhongCap)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnTraCuu)
        Me.GroupBox3.Controls.Add(Me.cmbKetQuaPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtYKienPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtTenCanBoPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.DTPNgayPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(750, 129)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'txtLyDoKhongCap
        '
        Me.txtLyDoKhongCap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongCap.Location = New System.Drawing.Point(140, 98)
        Me.txtLyDoKhongCap.Name = "txtLyDoKhongCap"
        Me.txtLyDoKhongCap.Size = New System.Drawing.Size(574, 20)
        Me.txtLyDoKhongCap.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Lý do "
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(140, 12)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(53, 21)
        Me.btnTraCuu.TabIndex = 2
        Me.btnTraCuu.Text = "Tra cứu"
        Me.btnTraCuu.UseVisualStyleBackColor = True
        '
        'cmbKetQuaPheDuyet
        '
        Me.cmbKetQuaPheDuyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKetQuaPheDuyet.FormattingEnabled = True
        Me.cmbKetQuaPheDuyet.Location = New System.Drawing.Point(140, 69)
        Me.cmbKetQuaPheDuyet.Name = "cmbKetQuaPheDuyet"
        Me.cmbKetQuaPheDuyet.Size = New System.Drawing.Size(110, 21)
        Me.cmbKetQuaPheDuyet.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Kết quả phê duyệt"
        '
        'txtYKienPheDuyet
        '
        Me.txtYKienPheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYKienPheDuyet.Location = New System.Drawing.Point(140, 39)
        Me.txtYKienPheDuyet.Name = "txtYKienPheDuyet"
        Me.txtYKienPheDuyet.Size = New System.Drawing.Size(600, 20)
        Me.txtYKienPheDuyet.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Ý kiến cán bộ phê duyệt"
        '
        'txtTenCanBoPheDuyet
        '
        Me.txtTenCanBoPheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenCanBoPheDuyet.Location = New System.Drawing.Point(199, 13)
        Me.txtTenCanBoPheDuyet.Name = "txtTenCanBoPheDuyet"
        Me.txtTenCanBoPheDuyet.Size = New System.Drawing.Size(541, 20)
        Me.txtTenCanBoPheDuyet.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Tên cán bộ phê duyệt"
        '
        'DTPNgayPheDuyet
        '
        Me.DTPNgayPheDuyet.Location = New System.Drawing.Point(385, 69)
        Me.DTPNgayPheDuyet.Name = "DTPNgayPheDuyet"
        Me.DTPNgayPheDuyet.Size = New System.Drawing.Size(113, 20)
        Me.DTPNgayPheDuyet.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ngày phê duyệt"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnKhongDuDK)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(756, 536)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "In báo không đủ điều kiện"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnKhongDuDK
        '
        Me.btnKhongDuDK.Location = New System.Drawing.Point(298, 26)
        Me.btnKhongDuDK.Name = "btnKhongDuDK"
        Me.btnKhongDuDK.Size = New System.Drawing.Size(172, 27)
        Me.btnKhongDuDK.TabIndex = 0
        Me.btnKhongDuDK.Text = "Xem và In"
        Me.btnKhongDuDK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(272, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Xem và in Giấy thông báo không đủ điều kiện cấp GCN"
        '
        'CtrTrangThaiHoSo1
        '
        Me.CtrTrangThaiHoSo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrTrangThaiHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTrangThaiHoSo1.Connection = ""
        Me.CtrTrangThaiHoSo1.Location = New System.Drawing.Point(3, 584)
        Me.CtrTrangThaiHoSo1.MaDonViHanhCHinh = ""
        Me.CtrTrangThaiHoSo1.MaHoSoCapGCN = ""
        Me.CtrTrangThaiHoSo1.MaXacNhan = "0"
        Me.CtrTrangThaiHoSo1.Name = "CtrTrangThaiHoSo1"
        Me.CtrTrangThaiHoSo1.Size = New System.Drawing.Size(480, 32)
        Me.CtrTrangThaiHoSo1.TabIndex = 29
        '
        'ctrlThamDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.CtrTrangThaiHoSo1)
        Me.Controls.Add(Me.tabThamDinh)
        Me.Controls.Add(Me.lblActiveThamDinh)
        Me.Name = "ctrlThamDinh"
        Me.Size = New System.Drawing.Size(769, 627)
        Me.tabYeuCauBoXung.ResumeLayout(False)
        Me.tabKetQuaThamDinh.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.tabChu.ResumeLayout(False)
        Me.tabThuaDat.ResumeLayout(False)
        Me.tabNhaO.ResumeLayout(False)
        Me.tabCongTrinhXayDungKhac.ResumeLayout(False)
        Me.tabRungCay.ResumeLayout(False)
        Me.tabCayLauNam.ResumeLayout(False)
        Me.tabSoDoNhaDat.ResumeLayout(False)
        Me.tabThongTinPhapLyKhac.ResumeLayout(False)
        Me.tabThamDinh.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tabThongTinSoCapGCN.ResumeLayout(False)
        Me.tabThongTinKyGCN.ResumeLayout(False)
        Me.tabThongTinCapGCNKhac.ResumeLayout(False)
        Me.tabThongTinMaVach.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lblActiveThamDinh As System.Windows.Forms.Label
    Friend WithEvents tabYeuCauBoXung As System.Windows.Forms.TabPage
    Public WithEvents CtrlYeuCauBoXungThamDinh As DMC.Land.YeuCauBoSung.ctrlYeuCauBoXung
    Friend WithEvents tabKetQuaThamDinh As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Public WithEvents tabChu As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinChuDeNghiCapGCN As DMC.Land.ThamDinh.ctrlThongTinChuDeNghiCapGCN
    Friend WithEvents tabThuaDat As System.Windows.Forms.TabPage
    Public WithEvents CtrlThamDinhThuaDat As DMC.Land.ThamDinh.ctrlThongTinThuaDatDeNghiCapGCN
    Friend WithEvents tabNhaO As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinNhaODeNghiCapGCN As DMC.Land.ThamDinh.ctrlThongTinNhaODeNghiCapGCN
    Friend WithEvents tabCongTrinhXayDungKhac As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinCongTrinhXayDungDeNghiCapGCN As DMC.Land.ThamDinh.ctrlThongTinCongTrinhXayDungDeNghiCapGCN
    Friend WithEvents tabRungCay As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinRungCayDeNghiCapGCN As DMC.Land.ThamDinh.ctrlThongTinRungCayDeNghiCapGCN
    Friend WithEvents tabCayLauNam As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinCayLauNamDeNghiCapGCN As DMC.Land.ThamDinh.ctrlThongTinCayLauNamDeNghiCapGCN
    Public WithEvents tabSoDoNhaDat As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinSoDoNhaDat As DMC.Land.ThongTinSoDoNhaDat.ctrlThongTinSoDoNhaDat
    Friend WithEvents tabThongTinPhapLyKhac As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinPhapLyKhac As DMC.Land.ThamDinh.ctrlThongTinPhapLyKhac
    Friend WithEvents tabThamDinh As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinCanBoThamDinh As DMC.Land.ThamDinh.ctrlThongTinCanBoThamDinh
    Public WithEvents CtrTrangThaiHoSo1 As prjTrangThaiHoSo.ctrTrangThaiHoSo
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents btnKhongDuDK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tabThongTinSoCapGCN As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinSoCapGCN As DMC.Land.ThamDinh.ctrlThongTinSoCapGCN
    Public WithEvents tabThongTinKyGCN As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinKyGCN As DMC.Land.ThamDinh.ctrlThongTinKyGCN
    Friend WithEvents tabThongTinCapGCNKhac As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinGCN As DMC.Land.ThamDinh.ctrlThongTinGCN
    Friend WithEvents tabThongTinMaVach As System.Windows.Forms.TabPage
    Public WithEvents CtrlEncodeEAN13 As DMC.Barcode.ctrlEncodeEAN13
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txtLyDoKhongCap As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Friend WithEvents cmbKetQuaPheDuyet As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtYKienPheDuyet As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtTenCanBoPheDuyet As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPNgayPheDuyet As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
