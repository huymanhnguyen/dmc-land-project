<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinCapGCN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlThongTinCapGCN))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CtrTrangThaiHoSo1 = New prjTrangThaiHoSo.ctrTrangThaiHoSo
        Me.tabThongTinCapGCN = New System.Windows.Forms.TabControl
        Me.tabThongTinQuiTrinhCapGCN = New System.Windows.Forms.TabPage
        Me.CtrlThongTinQuiTrinhCapGCN = New DMC.Land.ThongTinCapGCN.ctrlThongTinQuiTrinhCapGCN
        Me.tabThongTinToTrinhDiaChinh = New System.Windows.Forms.TabPage
        Me.CtrlThongTinToTrinhDiaChinh = New DMC.Land.ThongTinCapGCN.ctrlThongTinToTrinhDiaChinh
        Me.tabThongTinQuyetDinhCapGCN = New System.Windows.Forms.TabPage
        Me.CtrlThongTinQuyetDinhCapGCN = New DMC.Land.ThongTinCapGCN.ctrlThongTinQuyetDinhCapGCN
        Me.tabInGCN = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnXemVaIn = New System.Windows.Forms.Button
        Me.tabThongBao = New System.Windows.Forms.TabPage
        Me.CtrlThongBaoCapGCN = New DMC.Land.ThongTinCapGCN.ctrlThongBaoCapGCN
        Me.tabTraGCN = New System.Windows.Forms.TabPage
        Me.CtrlThongTinTraGCN = New DMC.Land.ThongTinCapGCN.ctrlThongTinTraGCN
        Me.lblActiveThongTinCapGCN = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.tabThongTinCapGCN.SuspendLayout()
        Me.tabThongTinQuiTrinhCapGCN.SuspendLayout()
        Me.tabThongTinToTrinhDiaChinh.SuspendLayout()
        Me.tabThongTinQuyetDinhCapGCN.SuspendLayout()
        Me.tabInGCN.SuspendLayout()
        Me.tabThongBao.SuspendLayout()
        Me.tabTraGCN.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrTrangThaiHoSo1)
        Me.GroupBox2.Controls.Add(Me.tabThongTinCapGCN)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(850, 427)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'CtrTrangThaiHoSo1
        '
        Me.CtrTrangThaiHoSo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrTrangThaiHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTrangThaiHoSo1.Connection = ""
        Me.CtrTrangThaiHoSo1.Location = New System.Drawing.Point(6, 355)
        Me.CtrTrangThaiHoSo1.MaDonViHanhCHinh = ""
        Me.CtrTrangThaiHoSo1.MaHoSoCapGCN = ""
        Me.CtrTrangThaiHoSo1.MaXacNhan = "0"
        Me.CtrTrangThaiHoSo1.Name = "CtrTrangThaiHoSo1"
        Me.CtrTrangThaiHoSo1.Size = New System.Drawing.Size(578, 69)
        Me.CtrTrangThaiHoSo1.TabIndex = 1
        '
        'tabThongTinCapGCN
        '
        Me.tabThongTinCapGCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabThongTinQuiTrinhCapGCN)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabThongTinToTrinhDiaChinh)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabThongTinQuyetDinhCapGCN)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabInGCN)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabThongBao)
        Me.tabThongTinCapGCN.Controls.Add(Me.tabTraGCN)
        Me.tabThongTinCapGCN.Location = New System.Drawing.Point(6, 13)
        Me.tabThongTinCapGCN.Name = "tabThongTinCapGCN"
        Me.tabThongTinCapGCN.SelectedIndex = 0
        Me.tabThongTinCapGCN.Size = New System.Drawing.Size(842, 344)
        Me.tabThongTinCapGCN.TabIndex = 0
        '
        'tabThongTinQuiTrinhCapGCN
        '
        Me.tabThongTinQuiTrinhCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinQuiTrinhCapGCN.Controls.Add(Me.CtrlThongTinQuiTrinhCapGCN)
        Me.tabThongTinQuiTrinhCapGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinQuiTrinhCapGCN.Name = "tabThongTinQuiTrinhCapGCN"
        Me.tabThongTinQuiTrinhCapGCN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongTinQuiTrinhCapGCN.Size = New System.Drawing.Size(834, 318)
        Me.tabThongTinQuiTrinhCapGCN.TabIndex = 6
        Me.tabThongTinQuiTrinhCapGCN.Text = "Thông tin qui trình cấp GCN"
        Me.tabThongTinQuiTrinhCapGCN.UseVisualStyleBackColor = True
        '
        'CtrlThongTinQuiTrinhCapGCN
        '
        Me.CtrlThongTinQuiTrinhCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinQuiTrinhCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinQuiTrinhCapGCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinQuiTrinhCapGCN.Name = "CtrlThongTinQuiTrinhCapGCN"
        Me.CtrlThongTinQuiTrinhCapGCN.Size = New System.Drawing.Size(828, 312)
        Me.CtrlThongTinQuiTrinhCapGCN.TabIndex = 0
        '
        'tabThongTinToTrinhDiaChinh
        '
        Me.tabThongTinToTrinhDiaChinh.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinToTrinhDiaChinh.Controls.Add(Me.CtrlThongTinToTrinhDiaChinh)
        Me.tabThongTinToTrinhDiaChinh.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinToTrinhDiaChinh.Name = "tabThongTinToTrinhDiaChinh"
        Me.tabThongTinToTrinhDiaChinh.Size = New System.Drawing.Size(834, 318)
        Me.tabThongTinToTrinhDiaChinh.TabIndex = 7
        Me.tabThongTinToTrinhDiaChinh.Text = "Tờ trình địa chính"
        Me.tabThongTinToTrinhDiaChinh.UseVisualStyleBackColor = True
        '
        'CtrlThongTinToTrinhDiaChinh
        '
        Me.CtrlThongTinToTrinhDiaChinh.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinToTrinhDiaChinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinToTrinhDiaChinh.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinToTrinhDiaChinh.MaKhoa = ""
        Me.CtrlThongTinToTrinhDiaChinh.Name = "CtrlThongTinToTrinhDiaChinh"
        Me.CtrlThongTinToTrinhDiaChinh.Size = New System.Drawing.Size(834, 318)
        Me.CtrlThongTinToTrinhDiaChinh.TabIndex = 0
        '
        'tabThongTinQuyetDinhCapGCN
        '
        Me.tabThongTinQuyetDinhCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabThongTinQuyetDinhCapGCN.Controls.Add(Me.CtrlThongTinQuyetDinhCapGCN)
        Me.tabThongTinQuyetDinhCapGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabThongTinQuyetDinhCapGCN.Name = "tabThongTinQuyetDinhCapGCN"
        Me.tabThongTinQuyetDinhCapGCN.Size = New System.Drawing.Size(834, 318)
        Me.tabThongTinQuyetDinhCapGCN.TabIndex = 8
        Me.tabThongTinQuyetDinhCapGCN.Text = "Quyết định cấp GCN"
        Me.tabThongTinQuyetDinhCapGCN.UseVisualStyleBackColor = True
        '
        'CtrlThongTinQuyetDinhCapGCN
        '
        Me.CtrlThongTinQuyetDinhCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinQuyetDinhCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinQuyetDinhCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.CtrlThongTinQuyetDinhCapGCN.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinQuyetDinhCapGCN.MaKhoa = ""
        Me.CtrlThongTinQuyetDinhCapGCN.Name = "CtrlThongTinQuyetDinhCapGCN"
        Me.CtrlThongTinQuyetDinhCapGCN.Size = New System.Drawing.Size(834, 318)
        Me.CtrlThongTinQuyetDinhCapGCN.TabIndex = 0
        '
        'tabInGCN
        '
        Me.tabInGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabInGCN.Controls.Add(Me.Label1)
        Me.tabInGCN.Controls.Add(Me.btnXemVaIn)
        Me.tabInGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabInGCN.Name = "tabInGCN"
        Me.tabInGCN.Size = New System.Drawing.Size(834, 318)
        Me.tabInGCN.TabIndex = 9
        Me.tabInGCN.Text = "In GCN"
        Me.tabInGCN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Xem và In Giấy chứng nhận:"
        '
        'btnXemVaIn
        '
        Me.btnXemVaIn.Enabled = False
        Me.btnXemVaIn.Location = New System.Drawing.Point(164, 10)
        Me.btnXemVaIn.Name = "btnXemVaIn"
        Me.btnXemVaIn.Size = New System.Drawing.Size(93, 26)
        Me.btnXemVaIn.TabIndex = 0
        Me.btnXemVaIn.Text = "Xem và In GCN"
        Me.btnXemVaIn.UseVisualStyleBackColor = True
        Me.btnXemVaIn.Visible = False
        '
        'tabThongBao
        '
        Me.tabThongBao.BackColor = System.Drawing.Color.Lavender
        Me.tabThongBao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tabThongBao.Controls.Add(Me.CtrlThongBaoCapGCN)
        Me.tabThongBao.Location = New System.Drawing.Point(4, 22)
        Me.tabThongBao.Name = "tabThongBao"
        Me.tabThongBao.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThongBao.Size = New System.Drawing.Size(834, 318)
        Me.tabThongBao.TabIndex = 2
        Me.tabThongBao.Text = "Thông báo cấp GCN"
        Me.tabThongBao.UseVisualStyleBackColor = True
        '
        'CtrlThongBaoCapGCN
        '
        Me.CtrlThongBaoCapGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongBaoCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongBaoCapGCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongBaoCapGCN.MaDonViHanhChinh = ""
        Me.CtrlThongBaoCapGCN.MaKhoa = ""
        Me.CtrlThongBaoCapGCN.Name = "CtrlThongBaoCapGCN"
        Me.CtrlThongBaoCapGCN.Size = New System.Drawing.Size(828, 312)
        Me.CtrlThongBaoCapGCN.TabIndex = 0
        '
        'tabTraGCN
        '
        Me.tabTraGCN.BackColor = System.Drawing.Color.Lavender
        Me.tabTraGCN.Controls.Add(Me.CtrlThongTinTraGCN)
        Me.tabTraGCN.Location = New System.Drawing.Point(4, 22)
        Me.tabTraGCN.Name = "tabTraGCN"
        Me.tabTraGCN.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTraGCN.Size = New System.Drawing.Size(834, 318)
        Me.tabTraGCN.TabIndex = 3
        Me.tabTraGCN.Text = "Trả GCN"
        Me.tabTraGCN.UseVisualStyleBackColor = True
        '
        'CtrlThongTinTraGCN
        '
        Me.CtrlThongTinTraGCN.BackColor = System.Drawing.Color.Lavender
        Me.CtrlThongTinTraGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlThongTinTraGCN.Flag = ""
        Me.CtrlThongTinTraGCN.Location = New System.Drawing.Point(3, 3)
        Me.CtrlThongTinTraGCN.MaDonViHanhChinh = Nothing
        Me.CtrlThongTinTraGCN.MaKhoa = ""
        Me.CtrlThongTinTraGCN.Name = "CtrlThongTinTraGCN"
        Me.CtrlThongTinTraGCN.Size = New System.Drawing.Size(828, 312)
        Me.CtrlThongTinTraGCN.TabIndex = 0
        '
        'lblActiveThongTinCapGCN
        '
        Me.lblActiveThongTinCapGCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActiveThongTinCapGCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveThongTinCapGCN.Image = CType(resources.GetObject("lblActiveThongTinCapGCN.Image"), System.Drawing.Image)
        Me.lblActiveThongTinCapGCN.Location = New System.Drawing.Point(0, 0)
        Me.lblActiveThongTinCapGCN.Name = "lblActiveThongTinCapGCN"
        Me.lblActiveThongTinCapGCN.Size = New System.Drawing.Size(859, 20)
        Me.lblActiveThongTinCapGCN.TabIndex = 27
        Me.lblActiveThongTinCapGCN.Text = "THÔNG TIN CẤP GIẤY CHỨNG NHẬN"
        Me.lblActiveThongTinCapGCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctrlThongTinCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.lblActiveThongTinCapGCN)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ctrlThongTinCapGCN"
        Me.Size = New System.Drawing.Size(859, 451)
        Me.GroupBox2.ResumeLayout(False)
        Me.tabThongTinCapGCN.ResumeLayout(False)
        Me.tabThongTinQuiTrinhCapGCN.ResumeLayout(False)
        Me.tabThongTinToTrinhDiaChinh.ResumeLayout(False)
        Me.tabThongTinQuyetDinhCapGCN.ResumeLayout(False)
        Me.tabInGCN.ResumeLayout(False)
        Me.tabInGCN.PerformLayout()
        Me.tabThongBao.ResumeLayout(False)
        Me.tabTraGCN.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents lblActiveThongTinCapGCN As System.Windows.Forms.Label
    Public WithEvents CtrTrangThaiHoSo1 As prjTrangThaiHoSo.ctrTrangThaiHoSo
    Friend WithEvents tabThongTinCapGCN As System.Windows.Forms.TabControl
    Friend WithEvents tabThongTinQuiTrinhCapGCN As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinQuiTrinhCapGCN As DMC.Land.ThongTinCapGCN.ctrlThongTinQuiTrinhCapGCN
    Friend WithEvents tabThongTinToTrinhDiaChinh As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinToTrinhDiaChinh As DMC.Land.ThongTinCapGCN.ctrlThongTinToTrinhDiaChinh
    Friend WithEvents tabThongTinQuyetDinhCapGCN As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinQuyetDinhCapGCN As DMC.Land.ThongTinCapGCN.ctrlThongTinQuyetDinhCapGCN
    Friend WithEvents tabInGCN As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btnXemVaIn As System.Windows.Forms.Button
    Friend WithEvents tabThongBao As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongBaoCapGCN As DMC.Land.ThongTinCapGCN.ctrlThongBaoCapGCN
    Friend WithEvents tabTraGCN As System.Windows.Forms.TabPage
    Public WithEvents CtrlThongTinTraGCN As DMC.Land.ThongTinCapGCN.ctrlThongTinTraGCN

End Class
