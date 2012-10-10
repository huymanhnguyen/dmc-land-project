Imports DMC.Land.HoiDongXetDuyet
Imports DMC.Land.ThongTinXetDuyet
Imports DMC.Land.YeuCauBoXung
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlXetDuyetCapCoSo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlXetDuyetCapCoSo))
        Me.Label4 = New System.Windows.Forms.Label
        Me.tabThongTinBoSung = New System.Windows.Forms.TabPage
        Me.CtrlThongTinBoSung = New DMC.Land.YeuCauBoSung.ctrlThongTinBoSung
        Me.TabThongTinXetDuyet = New System.Windows.Forms.TabPage
        Me.CtrlThongTinXetDuyet = New DMC.Land.ThongTinXetDuyet.ctrlThongTinXetDuyet
        Me.TabThanhPhanHoiDongXetDuyet = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CtrTrangThaiHoSo1 = New prjTrangThaiHoSo.ctrTrangThaiHoSo
        Me.CtrTongHopDatInBienBanXetDuyet1 = New DMC.Land.TongHopThongTinDatInBienBanXetDuyet.ctrTongHopDatInBienBanXetDuyet
        Me.CtrThongTinHoSoXetDuyet1 = New prjThongTinHoSoXetDuyet.ctrThongTinHoSoXetDuyet
        Me.CtrlHoiDongXetDuyet = New DMC.Land.HoiDongXetDuyet.ctrlHoiDongXetDuyet
        Me.tabThongTinBoSung.SuspendLayout()
        Me.TabThongTinXetDuyet.SuspendLayout()
        Me.TabThanhPhanHoiDongXetDuyet.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.Location = New System.Drawing.Point(-3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(788, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Xét duyệt cấp cơ sở"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabThongTinBoSung
        '
        Me.tabThongTinBoSung.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinBoSung.Controls.Add(Me.CtrlThongTinBoSung)
        Me.tabThongTinBoSung.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinBoSung.Name = "tabThongTinBoSung"
        Me.tabThongTinBoSung.Size = New System.Drawing.Size(771, 561)
        Me.tabThongTinBoSung.TabIndex = 5
        Me.tabThongTinBoSung.Text = "Thông tin bổ sung"
        Me.tabThongTinBoSung.UseVisualStyleBackColor = True
        '
        'CtrlThongTinBoSung
        '
        Me.CtrlThongTinBoSung.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinBoSung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinBoSung.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinBoSung.MaKhoa = ""
        Me.CtrlThongTinBoSung.Name = "CtrlThongTinBoSung"
        Me.CtrlThongTinBoSung.Size = New System.Drawing.Size(771, 561)
        Me.CtrlThongTinBoSung.TabIndex = 0
        '
        'TabThongTinXetDuyet
        '
        Me.TabThongTinXetDuyet.BackColor = System.Drawing.Color.Lavender
        Me.TabThongTinXetDuyet.Controls.Add(Me.CtrThongTinHoSoXetDuyet1)
        Me.TabThongTinXetDuyet.Controls.Add(Me.CtrlThongTinXetDuyet)
        Me.TabThongTinXetDuyet.Location = New System.Drawing.Point(4, 22)
        Me.TabThongTinXetDuyet.Name = "TabThongTinXetDuyet"
        Me.TabThongTinXetDuyet.Size = New System.Drawing.Size(771, 561)
        Me.TabThongTinXetDuyet.TabIndex = 4
        Me.TabThongTinXetDuyet.Text = "Thông tin xét duyệt"
        Me.TabThongTinXetDuyet.UseVisualStyleBackColor = True
        '
        'CtrlThongTinXetDuyet
        '
        Me.CtrlThongTinXetDuyet.AutoScroll = True
        Me.CtrlThongTinXetDuyet.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinXetDuyet.Location = New System.Drawing.Point(575, 3)
        Me.CtrlThongTinXetDuyet.Name = "CtrlThongTinXetDuyet"
        Me.CtrlThongTinXetDuyet.Size = New System.Drawing.Size(196, 355)
        Me.CtrlThongTinXetDuyet.TabIndex = 0
        Me.CtrlThongTinXetDuyet.Visible = False
        '
        'TabThanhPhanHoiDongXetDuyet
        '
        Me.TabThanhPhanHoiDongXetDuyet.BackColor = System.Drawing.Color.Lavender
        Me.TabThanhPhanHoiDongXetDuyet.Controls.Add(Me.CtrlHoiDongXetDuyet)
        Me.TabThanhPhanHoiDongXetDuyet.Location = New System.Drawing.Point(4, 22)
        Me.TabThanhPhanHoiDongXetDuyet.Name = "TabThanhPhanHoiDongXetDuyet"
        Me.TabThanhPhanHoiDongXetDuyet.Size = New System.Drawing.Size(771, 561)
        Me.TabThanhPhanHoiDongXetDuyet.TabIndex = 2
        Me.TabThanhPhanHoiDongXetDuyet.Text = "Thành phần hội đồng xét duyệt"
        Me.TabThanhPhanHoiDongXetDuyet.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabThanhPhanHoiDongXetDuyet)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabThongTinXetDuyet)
        Me.TabControl1.Controls.Add(Me.tabThongTinBoSung)
        Me.TabControl1.Location = New System.Drawing.Point(3, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(779, 587)
        Me.TabControl1.TabIndex = 40
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CtrTongHopDatInBienBanXetDuyet1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(771, 561)
        Me.TabPage2.TabIndex = 7
        Me.TabPage2.Text = "Tổng hợp thông tin xét duyệt"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CtrTrangThaiHoSo1
        '
        Me.CtrTrangThaiHoSo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrTrangThaiHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTrangThaiHoSo1.Connection = ""
        Me.CtrTrangThaiHoSo1.Location = New System.Drawing.Point(3, 616)
        Me.CtrTrangThaiHoSo1.MaDonViHanhCHinh = ""
        Me.CtrTrangThaiHoSo1.MaHoSoCapGCN = ""
        Me.CtrTrangThaiHoSo1.MaXacNhan = "0"
        Me.CtrTrangThaiHoSo1.Name = "CtrTrangThaiHoSo1"
        Me.CtrTrangThaiHoSo1.Size = New System.Drawing.Size(552, 68)
        Me.CtrTrangThaiHoSo1.TabIndex = 41
        '
        'CtrTongHopDatInBienBanXetDuyet1
        '
        Me.CtrTongHopDatInBienBanXetDuyet1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTongHopDatInBienBanXetDuyet1.Connection = ""
        Me.CtrTongHopDatInBienBanXetDuyet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrTongHopDatInBienBanXetDuyet1.Location = New System.Drawing.Point(3, 3)
        Me.CtrTongHopDatInBienBanXetDuyet1.MaHoSoCapGCN = ""
        Me.CtrTongHopDatInBienBanXetDuyet1.MaKhoa = ""
        Me.CtrTongHopDatInBienBanXetDuyet1.Name = "CtrTongHopDatInBienBanXetDuyet1"
        Me.CtrTongHopDatInBienBanXetDuyet1.Size = New System.Drawing.Size(765, 555)
        Me.CtrTongHopDatInBienBanXetDuyet1.TabIndex = 0
        '
        'CtrThongTinHoSoXetDuyet1
        '
        Me.CtrThongTinHoSoXetDuyet1.AutoScroll = True
        Me.CtrThongTinHoSoXetDuyet1.BackColor = System.Drawing.Color.Lavender
        Me.CtrThongTinHoSoXetDuyet1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrThongTinHoSoXetDuyet1.Location = New System.Drawing.Point(0, 0)
        Me.CtrThongTinHoSoXetDuyet1.MaKhoa = ""
        Me.CtrThongTinHoSoXetDuyet1.Name = "CtrThongTinHoSoXetDuyet1"
        Me.CtrThongTinHoSoXetDuyet1.Size = New System.Drawing.Size(771, 561)
        Me.CtrThongTinHoSoXetDuyet1.TabIndex = 42
        '
        'CtrlHoiDongXetDuyet
        '
        Me.CtrlHoiDongXetDuyet.BackColor = System.Drawing.Color.Lavender
        Me.CtrlHoiDongXetDuyet.DatabaseName = ""
        Me.CtrlHoiDongXetDuyet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlHoiDongXetDuyet.Location = New System.Drawing.Point(0, 0)
        Me.CtrlHoiDongXetDuyet.MaDonViHanhChinh = ""
        Me.CtrlHoiDongXetDuyet.MaDVHC = ""
        Me.CtrlHoiDongXetDuyet.MaKhoa = ""
        Me.CtrlHoiDongXetDuyet.Name = "CtrlHoiDongXetDuyet"
        Me.CtrlHoiDongXetDuyet.ServerName = ""
        Me.CtrlHoiDongXetDuyet.Size = New System.Drawing.Size(771, 561)
        Me.CtrlHoiDongXetDuyet.TabIndex = 0
        Me.CtrlHoiDongXetDuyet.UID = ""
        Me.CtrlHoiDongXetDuyet.UPass = ""
        '
        'ctrlXetDuyetCapCoSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.CtrTrangThaiHoSo1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label4)
        Me.Name = "ctrlXetDuyetCapCoSo"
        Me.Size = New System.Drawing.Size(785, 680)
        Me.tabThongTinBoSung.ResumeLayout(False)
        Me.TabThongTinXetDuyet.ResumeLayout(False)
        Me.TabThanhPhanHoiDongXetDuyet.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tabThongTinBoSung As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinBoSung As DMC.Land.YeuCauBoSung.ctrlThongTinBoSung
    Friend WithEvents TabThongTinXetDuyet As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinXetDuyet As DMC.Land.ThongTinXetDuyet.ctrlThongTinXetDuyet
    Friend WithEvents TabThanhPhanHoiDongXetDuyet As System.Windows.Forms.TabPage
    Public WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents CtrTongHopDatInBienBanXetDuyet1 As DMC.Land.TongHopThongTinDatInBienBanXetDuyet.ctrTongHopDatInBienBanXetDuyet
    Public WithEvents CtrTrangThaiHoSo1 As prjTrangThaiHoSo.ctrTrangThaiHoSo
    Public WithEvents CtrThongTinHoSoXetDuyet1 As prjThongTinHoSoXetDuyet.ctrThongTinHoSoXetDuyet
    Public WithEvents CtrlHoiDongXetDuyet As DMC.Land.HoiDongXetDuyet.ctrlHoiDongXetDuyet
End Class
