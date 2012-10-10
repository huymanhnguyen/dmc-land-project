<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinPhapLyKhac
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
        Me.btnHoSoKiThuat = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSoSeri = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGhiChuThamDinh = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.txtCacKhoanPhaiNop = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtLyDo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTrinhTuThuTucPhuong = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpNgayNopDuHoSoHopLe = New System.Windows.Forms.DateTimePicker
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnPhieuThamDinh = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnHoSoKiThuat
        '
        Me.btnHoSoKiThuat.Location = New System.Drawing.Point(329, 19)
        Me.btnHoSoKiThuat.Name = "btnHoSoKiThuat"
        Me.btnHoSoKiThuat.Size = New System.Drawing.Size(92, 21)
        Me.btnHoSoKiThuat.TabIndex = 9
        Me.btnHoSoKiThuat.Text = "Hồ sơ kĩ thuật"
        Me.btnHoSoKiThuat.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSoSeri)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGhiChuThamDinh)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 211)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'txtSoSeri
        '
        Me.txtSoSeri.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoSeri.Location = New System.Drawing.Point(141, 128)
        Me.txtSoSeri.Name = "txtSoSeri"
        Me.txtSoSeri.Size = New System.Drawing.Size(165, 20)
        Me.txtSoSeri.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Số seri tờ trình"
        '
        'txtGhiChuThamDinh
        '
        Me.txtGhiChuThamDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGhiChuThamDinh.Location = New System.Drawing.Point(141, 154)
        Me.txtGhiChuThamDinh.Multiline = True
        Me.txtGhiChuThamDinh.Name = "txtGhiChuThamDinh"
        Me.txtGhiChuThamDinh.Size = New System.Drawing.Size(594, 51)
        Me.txtGhiChuThamDinh.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(91, 154)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 70
        Me.Label20.Text = "Ghi chú"
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.txtCacKhoanPhaiNop)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 85)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(741, 38)
        Me.GroupBox8.TabIndex = 68
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Nghĩa vụ tài chính cần nộp"
        '
        'txtCacKhoanPhaiNop
        '
        Me.txtCacKhoanPhaiNop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCacKhoanPhaiNop.Location = New System.Drawing.Point(137, 14)
        Me.txtCacKhoanPhaiNop.Name = "txtCacKhoanPhaiNop"
        Me.txtCacKhoanPhaiNop.Size = New System.Drawing.Size(599, 20)
        Me.txtCacKhoanPhaiNop.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Các khoản phải nộp"
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.txtLyDo)
        Me.GroupBox7.Controls.Add(Me.Label1)
        Me.GroupBox7.Controls.Add(Me.cmbTrinhTuThuTucPhuong)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.dtpNgayNopDuHoSoHopLe)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 11)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(734, 68)
        Me.GroupBox7.TabIndex = 67
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Thông tin tiến trình thủ tục"
        '
        'txtLyDo
        '
        Me.txtLyDo.Location = New System.Drawing.Point(138, 39)
        Me.txtLyDo.Name = "txtLyDo"
        Me.txtLyDo.Size = New System.Drawing.Size(593, 20)
        Me.txtLyDo.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Lý do"
        '
        'cmbTrinhTuThuTucPhuong
        '
        Me.cmbTrinhTuThuTucPhuong.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTrinhTuThuTucPhuong.FormattingEnabled = True
        Me.cmbTrinhTuThuTucPhuong.Items.AddRange(New Object() {"Đủ thủ tục", "Chưa đủ thủ tục (cần bổ xung)", "Không đủ thủ tục"})
        Me.cmbTrinhTuThuTucPhuong.Location = New System.Drawing.Point(414, 12)
        Me.cmbTrinhTuThuTucPhuong.Name = "cmbTrinhTuThuTucPhuong"
        Me.cmbTrinhTuThuTucPhuong.Size = New System.Drawing.Size(313, 21)
        Me.cmbTrinhTuThuTucPhuong.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(283, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Trình tự thủ tục phường"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(2, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Ngày nộp đủ hồ sơ hợp lệ"
        '
        'dtpNgayNopDuHoSoHopLe
        '
        Me.dtpNgayNopDuHoSoHopLe.Location = New System.Drawing.Point(138, 14)
        Me.dtpNgayNopDuHoSoHopLe.Name = "dtpNgayNopDuHoSoHopLe"
        Me.dtpNgayNopDuHoSoHopLe.Size = New System.Drawing.Size(107, 20)
        Me.dtpNgayNopDuHoSoHopLe.TabIndex = 0
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(674, 19)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 10
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnPhieuThamDinh
        '
        Me.btnPhieuThamDinh.Location = New System.Drawing.Point(234, 19)
        Me.btnPhieuThamDinh.Name = "btnPhieuThamDinh"
        Me.btnPhieuThamDinh.Size = New System.Drawing.Size(92, 21)
        Me.btnPhieuThamDinh.TabIndex = 8
        Me.btnPhieuThamDinh.Text = "Phiếu thẩm định"
        Me.btnPhieuThamDinh.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(175, 19)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 7
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(117, 19)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 6
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(59, 19)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 5
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(1, 19)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 4
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHoSoKiThuat)
        Me.GroupBox2.Controls.Add(Me.btnPhieuThamDinh)
        Me.GroupBox2.Controls.Add(Me.btnTroGiup)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnCapNhat)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 220)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(737, 53)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        '
        'ctrlThongTinPhapLyKhac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinPhapLyKhac"
        Me.Size = New System.Drawing.Size(749, 276)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btnHoSoKiThuat As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGhiChuThamDinh As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Public WithEvents txtCacKhoanPhaiNop As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTrinhTuThuTucPhuong As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayNopDuHoSoHopLe As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Public WithEvents btnPhieuThamDinh As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents txtLyDo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtSoSeri As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
