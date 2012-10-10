Imports DMC.Land.NguonGoc
Imports DMC.Land.MucDich
Imports DMC.Land.ChuSuDungDat
Imports DMC.Land.ThongTinThuaKeKhai
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlHoSoKeKhai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlHoSoKeKhai))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabChuHoSoCapGCN = New System.Windows.Forms.TabPage
        Me.TabControl3 = New System.Windows.Forms.TabControl
        Me.tabGDCN = New System.Windows.Forms.TabPage
        Me.tabCQNN = New System.Windows.Forms.TabPage
        Me.tabTCDN = New System.Windows.Forms.TabPage
        Me.tabThongTinThua = New System.Windows.Forms.TabPage
        Me.CtrlThongTinThuaKeKhai = New DMC.Land.ThongTinThuaKeKhai.ctrlThongTinThuaKeKhai
        Me.tabThongTinTaiSanNhaO = New System.Windows.Forms.TabPage
        Me.CtrlNhaO = New DMC.Land.NhaO.ctrlNhaO
        Me.tabThongTinTaiSanKhac = New System.Windows.Forms.TabPage
        Me.CtrlCongTrinhXayDung = New DMC.Land.CongTrinhXayDung.ctrlCongTrinhXayDung
        Me.tabThongTinRungCay = New System.Windows.Forms.TabPage
        Me.tabThongTinCayLauNam = New System.Windows.Forms.TabPage
        Me.tabSoDoNhaDat = New System.Windows.Forms.TabPage
        Me.CtrlThongTinSoDoNhaDat = New DMC.Land.ThongTinSoDoNhaDat.ctrlThongTinSoDoNhaDat
        Me.tabTaiLieuKemTheo = New System.Windows.Forms.TabPage
        Me.CtrlTaiLieuKemTheo = New DMC.Land.TaiLieuKemTheo.ctrlTaiLieuKemTheo
        Me.lblActiveHoSoKeKhai = New System.Windows.Forms.Label
        Me.CtrTrangThaiHoSo1 = New prjTrangThaiHoSo.ctrTrangThaiHoSo
        Me.CtrlChuGDCN = New DMC.Land.ChuHoSoCapGCN.ctrlChuGDCN
        Me.CtrlChuCQNN = New DMC.Land.ChuHoSoCapGCN.ctrlChuCQNN
        Me.CtrlChuTCDN = New DMC.Land.ChuHoSoCapGCN.ctrlChuTCDN
        Me.CtrlThongTinRungCay = New DMC.Land.ThongTinRungCay.ctrlThongTinRungCay
        Me.CtrlThongTinCayLauNam = New DMC.Land.ThongTinCayLauNam.ctrlThongTinCayLauNam
        Me.TabControl1.SuspendLayout()
        Me.tabChuHoSoCapGCN.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.tabGDCN.SuspendLayout()
        Me.tabCQNN.SuspendLayout()
        Me.tabTCDN.SuspendLayout()
        Me.tabThongTinThua.SuspendLayout()
        Me.tabThongTinTaiSanNhaO.SuspendLayout()
        Me.tabThongTinTaiSanKhac.SuspendLayout()
        Me.tabThongTinRungCay.SuspendLayout()
        Me.tabThongTinCayLauNam.SuspendLayout()
        Me.tabSoDoNhaDat.SuspendLayout()
        Me.tabTaiLieuKemTheo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabChuHoSoCapGCN)
        Me.TabControl1.Controls.Add(Me.tabThongTinThua)
        Me.TabControl1.Controls.Add(Me.tabThongTinTaiSanNhaO)
        Me.TabControl1.Controls.Add(Me.tabThongTinTaiSanKhac)
        Me.TabControl1.Controls.Add(Me.tabThongTinRungCay)
        Me.TabControl1.Controls.Add(Me.tabThongTinCayLauNam)
        Me.TabControl1.Controls.Add(Me.tabSoDoNhaDat)
        Me.TabControl1.Controls.Add(Me.tabTaiLieuKemTheo)
        Me.TabControl1.Location = New System.Drawing.Point(3, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(935, 514)
        Me.TabControl1.TabIndex = 1
        '
        'tabChuHoSoCapGCN
        '
        Me.tabChuHoSoCapGCN.Controls.Add(Me.TabControl3)
        Me.tabChuHoSoCapGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabChuHoSoCapGCN.Name = "tabChuHoSoCapGCN"
        Me.tabChuHoSoCapGCN.Size = New System.Drawing.Size(927, 488)
        Me.tabChuHoSoCapGCN.TabIndex = 7
        Me.tabChuHoSoCapGCN.Text = "Chủ sử dụng/sở hữu"
        Me.tabChuHoSoCapGCN.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.tabGDCN)
        Me.TabControl3.Controls.Add(Me.tabCQNN)
        Me.TabControl3.Controls.Add(Me.tabTCDN)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(0, 0)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(927, 488)
        Me.TabControl3.TabIndex = 1
        '
        'tabGDCN
        '
        Me.tabGDCN.Controls.Add(Me.CtrlChuGDCN)
        Me.tabGDCN.Location = New System.Drawing.Point(4, 22)
        Me.tabGDCN.Name = "tabGDCN"
        Me.tabGDCN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGDCN.Size = New System.Drawing.Size(919, 462)
        Me.tabGDCN.TabIndex = 0
        Me.tabGDCN.Text = "Hộ gia đình, cá nhân"
        Me.tabGDCN.UseVisualStyleBackColor = True
        '
        'tabCQNN
        '
        Me.tabCQNN.Controls.Add(Me.CtrlChuCQNN)
        Me.tabCQNN.Location = New System.Drawing.Point(4, 22)
        Me.tabCQNN.Name = "tabCQNN"
        Me.tabCQNN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCQNN.Size = New System.Drawing.Size(919, 444)
        Me.tabCQNN.TabIndex = 1
        Me.tabCQNN.Text = "Cơ quan nhà nước, Cộng đồng dân cư"
        Me.tabCQNN.UseVisualStyleBackColor = True
        '
        'tabTCDN
        '
        Me.tabTCDN.Controls.Add(Me.CtrlChuTCDN)
        Me.tabTCDN.Location = New System.Drawing.Point(4, 22)
        Me.tabTCDN.Name = "tabTCDN"
        Me.tabTCDN.Size = New System.Drawing.Size(919, 444)
        Me.tabTCDN.TabIndex = 2
        Me.tabTCDN.Text = "Tổ chức, doanh nghiệp"
        Me.tabTCDN.UseVisualStyleBackColor = True
        '
        'tabThongTinThua
        '
        Me.tabThongTinThua.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinThua.Controls.Add(Me.CtrlThongTinThuaKeKhai)
        Me.tabThongTinThua.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinThua.Name = "tabThongTinThua"
        Me.tabThongTinThua.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinThua.Size = New System.Drawing.Size(927, 470)
        Me.tabThongTinThua.TabIndex = 0
        Me.tabThongTinThua.Text = "Thông tin thửa đất"
        Me.tabThongTinThua.UseVisualStyleBackColor = True
        '
        'CtrlThongTinThuaKeKhai
        '
        Me.CtrlThongTinThuaKeKhai.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinThuaKeKhai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinThuaKeKhai.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinThuaKeKhai.Name = "CtrlThongTinThuaKeKhai"
        Me.CtrlThongTinThuaKeKhai.Size = New System.Drawing.Size(921, 464)
        Me.CtrlThongTinThuaKeKhai.TabIndex = 1
        '
        'tabThongTinTaiSanNhaO
        '
        Me.tabThongTinTaiSanNhaO.Controls.Add(Me.CtrlNhaO)
        Me.tabThongTinTaiSanNhaO.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinTaiSanNhaO.Name = "tabThongTinTaiSanNhaO"
        Me.tabThongTinTaiSanNhaO.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinTaiSanNhaO.Size = New System.Drawing.Size(927, 470)
        Me.tabThongTinTaiSanNhaO.TabIndex = 3
        Me.tabThongTinTaiSanNhaO.Text = "Nhà ở - Căn hộ"
        Me.tabThongTinTaiSanNhaO.UseVisualStyleBackColor = True
        '
        'CtrlNhaO
        '
        Me.CtrlNhaO.BackColor = System.Drawing.Color.Lavender
        Me.CtrlNhaO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlNhaO.Location = New System.Drawing.Point(3, 3)
        Me.CtrlNhaO.MaNhaO = ""
        Me.CtrlNhaO.Name = "CtrlNhaO"
        Me.CtrlNhaO.Size = New System.Drawing.Size(921, 464)
        Me.CtrlNhaO.TabIndex = 0
        '
        'tabThongTinTaiSanKhac
        '
        Me.tabThongTinTaiSanKhac.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinTaiSanKhac.Controls.Add(Me.CtrlCongTrinhXayDung)
        Me.tabThongTinTaiSanKhac.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinTaiSanKhac.Name = "tabThongTinTaiSanKhac"
        Me.tabThongTinTaiSanKhac.Size = New System.Drawing.Size(927, 470)
        Me.tabThongTinTaiSanKhac.TabIndex = 2
        Me.tabThongTinTaiSanKhac.Text = "Công trình xây dựng khác"
        Me.tabThongTinTaiSanKhac.UseVisualStyleBackColor = True
        '
        'CtrlCongTrinhXayDung
        '
        Me.CtrlCongTrinhXayDung.BackColor = System.Drawing.Color.Lavender
        Me.CtrlCongTrinhXayDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlCongTrinhXayDung.Location = New System.Drawing.Point(0, 0)
        Me.CtrlCongTrinhXayDung.Name = "CtrlCongTrinhXayDung"
        Me.CtrlCongTrinhXayDung.Size = New System.Drawing.Size(927, 470)
        Me.CtrlCongTrinhXayDung.TabIndex = 1
        '
        'tabThongTinRungCay
        '
        Me.tabThongTinRungCay.Controls.Add(Me.CtrlThongTinRungCay)
        Me.tabThongTinRungCay.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinRungCay.Name = "tabThongTinRungCay"
        Me.tabThongTinRungCay.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinRungCay.Size = New System.Drawing.Size(927, 470)
        Me.tabThongTinRungCay.TabIndex = 4
        Me.tabThongTinRungCay.Text = "Rừng cây"
        Me.tabThongTinRungCay.UseVisualStyleBackColor = True
        '
        'tabThongTinCayLauNam
        '
        Me.tabThongTinCayLauNam.Controls.Add(Me.CtrlThongTinCayLauNam)
        Me.tabThongTinCayLauNam.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinCayLauNam.Name = "tabThongTinCayLauNam"
        Me.tabThongTinCayLauNam.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinCayLauNam.Size = New System.Drawing.Size(927, 470)
        Me.tabThongTinCayLauNam.TabIndex = 5
        Me.tabThongTinCayLauNam.Text = "Cây lâu năm"
        Me.tabThongTinCayLauNam.UseVisualStyleBackColor = True
        '
        'tabSoDoNhaDat
        '
        Me.tabSoDoNhaDat.Controls.Add(Me.CtrlThongTinSoDoNhaDat)
        Me.tabSoDoNhaDat.Location = New System.Drawing.Point(4, 22)
        Me.tabSoDoNhaDat.Name = "tabSoDoNhaDat"
        Me.tabSoDoNhaDat.Size = New System.Drawing.Size(927, 470)
        Me.tabSoDoNhaDat.TabIndex = 6
        Me.tabSoDoNhaDat.Text = "Sơ đồ Nhà, Đất"
        Me.tabSoDoNhaDat.UseVisualStyleBackColor = True
        '
        'CtrlThongTinSoDoNhaDat
        '
        Me.CtrlThongTinSoDoNhaDat.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinSoDoNhaDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinSoDoNhaDat.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinSoDoNhaDat.Name = "CtrlThongTinSoDoNhaDat"
        Me.CtrlThongTinSoDoNhaDat.Size = New System.Drawing.Size(927, 470)
        Me.CtrlThongTinSoDoNhaDat.TabIndex = 0
        '
        'tabTaiLieuKemTheo
        '
        Me.tabTaiLieuKemTheo.Controls.Add(Me.CtrlTaiLieuKemTheo)
        Me.tabTaiLieuKemTheo.Location = New System.Drawing.Point(4, 22)
        Me.tabTaiLieuKemTheo.Name = "tabTaiLieuKemTheo"
        Me.tabTaiLieuKemTheo.Size = New System.Drawing.Size(927, 470)
        Me.tabTaiLieuKemTheo.TabIndex = 8
        Me.tabTaiLieuKemTheo.Text = "Tài liệu kèm theo"
        Me.tabTaiLieuKemTheo.UseVisualStyleBackColor = True
        '
        'CtrlTaiLieuKemTheo
        '
        Me.CtrlTaiLieuKemTheo.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTaiLieuKemTheo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlTaiLieuKemTheo.Location = New System.Drawing.Point(0, 0)
        Me.CtrlTaiLieuKemTheo.MaTaiLieuKemTheo = ""
        Me.CtrlTaiLieuKemTheo.MoTa = ""
        Me.CtrlTaiLieuKemTheo.Name = "CtrlTaiLieuKemTheo"
        Me.CtrlTaiLieuKemTheo.Size = New System.Drawing.Size(927, 470)
        Me.CtrlTaiLieuKemTheo.TabIndex = 1
        Me.CtrlTaiLieuKemTheo.TaiLieu = Nothing
        Me.CtrlTaiLieuKemTheo.TenTepDuLieuNguon = ""
        '
        'lblActiveHoSoKeKhai
        '
        Me.lblActiveHoSoKeKhai.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActiveHoSoKeKhai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveHoSoKeKhai.Image = CType(resources.GetObject("lblActiveHoSoKeKhai.Image"), System.Drawing.Image)
        Me.lblActiveHoSoKeKhai.Location = New System.Drawing.Point(0, 2)
        Me.lblActiveHoSoKeKhai.Name = "lblActiveHoSoKeKhai"
        Me.lblActiveHoSoKeKhai.Size = New System.Drawing.Size(941, 20)
        Me.lblActiveHoSoKeKhai.TabIndex = 13
        Me.lblActiveHoSoKeKhai.Text = "THÔNG TIN HỒ SƠ KÊ KHAI ĐĂNG KÝ CÂP GCN"
        Me.lblActiveHoSoKeKhai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtrTrangThaiHoSo1
        '
        Me.CtrTrangThaiHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTrangThaiHoSo1.Connection = ""
        Me.CtrTrangThaiHoSo1.Location = New System.Drawing.Point(7, 537)
        Me.CtrTrangThaiHoSo1.MaHoSoCapGCN = ""
        Me.CtrTrangThaiHoSo1.MaXacNhan = "0"
        Me.CtrTrangThaiHoSo1.Name = "CtrTrangThaiHoSo1"
        Me.CtrTrangThaiHoSo1.Size = New System.Drawing.Size(624, 61)
        Me.CtrTrangThaiHoSo1.TabIndex = 14
        '
        'CtrlChuGDCN
        '
        Me.CtrlChuGDCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlChuGDCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlChuGDCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlChuGDCN.MaChu = ""
        Me.CtrlChuGDCN.Name = "CtrlChuGDCN"
        Me.CtrlChuGDCN.Size = New System.Drawing.Size(913, 456)
        Me.CtrlChuGDCN.TabIndex = 0
        '
        'CtrlChuCQNN
        '
        Me.CtrlChuCQNN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlChuCQNN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlChuCQNN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlChuCQNN.MaChu = ""
        Me.CtrlChuCQNN.Name = "CtrlChuCQNN"
        Me.CtrlChuCQNN.Size = New System.Drawing.Size(913, 438)
        Me.CtrlChuCQNN.TabIndex = 2
        '
        'CtrlChuTCDN
        '
        Me.CtrlChuTCDN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlChuTCDN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlChuTCDN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlChuTCDN.MaChu = ""
        Me.CtrlChuTCDN.Name = "CtrlChuTCDN"
        Me.CtrlChuTCDN.Size = New System.Drawing.Size(919, 444)
        Me.CtrlChuTCDN.TabIndex = 0
        '
        'CtrlThongTinRungCay
        '
        Me.CtrlThongTinRungCay.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinRungCay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinRungCay.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinRungCay.MaThongTinRungCay = ""
        Me.CtrlThongTinRungCay.Name = "CtrlThongTinRungCay"
        Me.CtrlThongTinRungCay.Size = New System.Drawing.Size(921, 464)
        Me.CtrlThongTinRungCay.TabIndex = 0
        '
        'CtrlThongTinCayLauNam
        '
        Me.CtrlThongTinCayLauNam.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinCayLauNam.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinCayLauNam.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinCayLauNam.MaThongTinCayLauNam = ""
        Me.CtrlThongTinCayLauNam.Name = "CtrlThongTinCayLauNam"
        Me.CtrlThongTinCayLauNam.Size = New System.Drawing.Size(921, 464)
        Me.CtrlThongTinCayLauNam.TabIndex = 0
        '
        'ctrlHoSoKeKhai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.CtrTrangThaiHoSo1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblActiveHoSoKeKhai)
        Me.Name = "ctrlHoSoKeKhai"
        Me.Size = New System.Drawing.Size(941, 601)
        Me.TabControl1.ResumeLayout(False)
        Me.tabChuHoSoCapGCN.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.tabGDCN.ResumeLayout(False)
        Me.tabCQNN.ResumeLayout(False)
        Me.tabTCDN.ResumeLayout(False)
        Me.tabThongTinThua.ResumeLayout(False)
        Me.tabThongTinTaiSanNhaO.ResumeLayout(False)
        Me.tabThongTinTaiSanKhac.ResumeLayout(False)
        Me.tabThongTinRungCay.ResumeLayout(False)
        Me.tabThongTinCayLauNam.ResumeLayout(False)
        Me.tabSoDoNhaDat.ResumeLayout(False)
        Me.tabTaiLieuKemTheo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabThongTinTaiSanKhac As System.Windows.Forms.TabPage
    Public WithEvents TabControl1 As System.Windows.Forms.TabControl
    Public WithEvents lblActiveHoSoKeKhai As System.Windows.Forms.Label
    Public WithEvents tabThongTinThua As System.Windows.Forms.TabPage
    Friend WithEvents tabThongTinTaiSanNhaO As System.Windows.Forms.TabPage
    Friend WithEvents tabThongTinRungCay As System.Windows.Forms.TabPage
    Friend WithEvents tabThongTinCayLauNam As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinRungCay As DMC.Land.ThongTinRungCay.ctrlThongTinRungCay
    Public WithEvents CtrlThongTinCayLauNam As DMC.Land.ThongTinCayLauNam.ctrlThongTinCayLauNam
    Public WithEvents CtrlNhaO As DMC.Land.NhaO.ctrlNhaO
    Friend WithEvents tabSoDoNhaDat As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinSoDoNhaDat As DMC.Land.ThongTinSoDoNhaDat.ctrlThongTinSoDoNhaDat
    Friend WithEvents tabChuHoSoCapGCN As System.Windows.Forms.TabPage
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents tabGDCN As System.Windows.Forms.TabPage
    Friend WithEvents tabCQNN As System.Windows.Forms.TabPage
    Public WithEvents CtrlChuCQNN As DMC.Land.ChuHoSoCapGCN.ctrlChuCQNN
    Friend WithEvents tabTCDN As System.Windows.Forms.TabPage
    Public WithEvents CtrlChuGDCN As DMC.Land.ChuHoSoCapGCN.ctrlChuGDCN
    Public WithEvents CtrlChuTCDN As DMC.Land.ChuHoSoCapGCN.ctrlChuTCDN
    Public WithEvents CtrlCongTrinhXayDung As DMC.Land.CongTrinhXayDung.ctrlCongTrinhXayDung
    Friend WithEvents tabTaiLieuKemTheo As System.Windows.Forms.TabPage
    Public WithEvents CtrlTaiLieuKemTheo As DMC.Land.TaiLieuKemTheo.ctrlTaiLieuKemTheo
    Public WithEvents CtrlThongTinThuaKeKhai As DMC.Land.ThongTinThuaKeKhai.ctrlThongTinThuaKeKhai
    Public WithEvents CtrTrangThaiHoSo1 As prjTrangThaiHoSo.ctrTrangThaiHoSo

End Class
