<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlPheDuyet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlPheDuyet))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtLyDoKhongCap = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnTraCuu = New System.Windows.Forms.Button
        Me.cmbKetQuaPheDuyet = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtYKienPheDuyet = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTenCanBoPheDuyet = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPNgayPheDuyet = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.lblActivePheDuyet = New System.Windows.Forms.Label
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.CtrTrangThaiHoSo1 = New prjTrangThaiHoSo.ctrTrangThaiHoSo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtLyDoKhongCap)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btnTraCuu)
        Me.GroupBox3.Controls.Add(Me.cmbKetQuaPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtYKienPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtTenCanBoPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.DTPNgayPheDuyet)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(724, 129)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'txtLyDoKhongCap
        '
        Me.txtLyDoKhongCap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLyDoKhongCap.Location = New System.Drawing.Point(140, 98)
        Me.txtLyDoKhongCap.Name = "txtLyDoKhongCap"
        Me.txtLyDoKhongCap.Size = New System.Drawing.Size(548, 20)
        Me.txtLyDoKhongCap.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Lý do "
        '
        'btnTraCuu
        '
        Me.btnTraCuu.Location = New System.Drawing.Point(140, 12)
        Me.btnTraCuu.Name = "btnTraCuu"
        Me.btnTraCuu.Size = New System.Drawing.Size(53, 21)
        Me.btnTraCuu.TabIndex = 1
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
        Me.cmbKetQuaPheDuyet.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Kết quả phê duyệt"
        '
        'txtYKienPheDuyet
        '
        Me.txtYKienPheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYKienPheDuyet.Location = New System.Drawing.Point(140, 39)
        Me.txtYKienPheDuyet.Name = "txtYKienPheDuyet"
        Me.txtYKienPheDuyet.Size = New System.Drawing.Size(574, 20)
        Me.txtYKienPheDuyet.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Ý kiến cán bộ phê duyệt"
        '
        'txtTenCanBoPheDuyet
        '
        Me.txtTenCanBoPheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenCanBoPheDuyet.Location = New System.Drawing.Point(199, 13)
        Me.txtTenCanBoPheDuyet.Name = "txtTenCanBoPheDuyet"
        Me.txtTenCanBoPheDuyet.Size = New System.Drawing.Size(515, 20)
        Me.txtTenCanBoPheDuyet.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tên cán bộ phê duyệt"
        '
        'DTPNgayPheDuyet
        '
        Me.DTPNgayPheDuyet.Location = New System.Drawing.Point(385, 69)
        Me.DTPNgayPheDuyet.Name = "DTPNgayPheDuyet"
        Me.DTPNgayPheDuyet.Size = New System.Drawing.Size(113, 20)
        Me.DTPNgayPheDuyet.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ngày phê duyệt"
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(187, 19)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 14
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(127, 19)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 13
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(67, 19)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 12
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(247, 19)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 15
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'lblActivePheDuyet
        '
        Me.lblActivePheDuyet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivePheDuyet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivePheDuyet.Image = CType(resources.GetObject("lblActivePheDuyet.Image"), System.Drawing.Image)
        Me.lblActivePheDuyet.Location = New System.Drawing.Point(0, 0)
        Me.lblActivePheDuyet.Name = "lblActivePheDuyet"
        Me.lblActivePheDuyet.Size = New System.Drawing.Size(734, 20)
        Me.lblActivePheDuyet.TabIndex = 27
        Me.lblActivePheDuyet.Text = "THÔNG TIN PHÊ DUYỆT"
        Me.lblActivePheDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(640, 19)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 16
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(6, 19)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 11
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'CtrTrangThaiHoSo1
        '
        Me.CtrTrangThaiHoSo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrTrangThaiHoSo1.BackColor = System.Drawing.Color.Lavender
        Me.CtrTrangThaiHoSo1.Connection = ""
        Me.CtrTrangThaiHoSo1.Location = New System.Drawing.Point(0, 224)
        Me.CtrTrangThaiHoSo1.MaDonViHanhCHinh = ""
        Me.CtrTrangThaiHoSo1.MaHoSoCapGCN = ""
        Me.CtrTrangThaiHoSo1.MaXacNhan = "0"
        Me.CtrTrangThaiHoSo1.Name = "CtrTrangThaiHoSo1"
        Me.CtrTrangThaiHoSo1.Size = New System.Drawing.Size(480, 66)
        Me.CtrTrangThaiHoSo1.TabIndex = 17
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
        Me.GroupBox1.Location = New System.Drawing.Point(3, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 46)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'ctrlPheDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CtrTrangThaiHoSo1)
        Me.Controls.Add(Me.lblActivePheDuyet)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ctrlPheDuyet"
        Me.Size = New System.Drawing.Size(734, 293)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtYKienPheDuyet As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPNgayPheDuyet As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents cmbKetQuaPheDuyet As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblActivePheDuyet As System.Windows.Forms.Label
    Public WithEvents txtTenCanBoPheDuyet As System.Windows.Forms.TextBox
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnTraCuu As System.Windows.Forms.Button
    Public WithEvents txtLyDoKhongCap As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents CtrTrangThaiHoSo1 As prjTrangThaiHoSo.ctrTrangThaiHoSo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
