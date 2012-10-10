<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinSoCapGCN
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
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.txtThuTuVaoSoCapGCN = New System.Windows.Forms.TextBox
        Me.txtSoVaoSoCapGCN = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnThuTuVaoSoCapGCN = New System.Windows.Forms.Button
        Me.btnSoVaoSoCapGCN = New System.Windows.Forms.Button
        Me.cmbKyHieuThamQuyenCapGCN = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpNgayVaoSoCapGCN = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(198, 13)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 9
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(73, 13)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 7
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(9, 13)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 6
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(134, 13)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 8
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'txtThuTuVaoSoCapGCN
        '
        Me.txtThuTuVaoSoCapGCN.Location = New System.Drawing.Point(439, 13)
        Me.txtThuTuVaoSoCapGCN.MaxLength = 5
        Me.txtThuTuVaoSoCapGCN.Name = "txtThuTuVaoSoCapGCN"
        Me.txtThuTuVaoSoCapGCN.Size = New System.Drawing.Size(145, 20)
        Me.txtThuTuVaoSoCapGCN.TabIndex = 2
        '
        'txtSoVaoSoCapGCN
        '
        Me.txtSoVaoSoCapGCN.Location = New System.Drawing.Point(173, 43)
        Me.txtSoVaoSoCapGCN.Name = "txtSoVaoSoCapGCN"
        Me.txtSoVaoSoCapGCN.Size = New System.Drawing.Size(116, 20)
        Me.txtSoVaoSoCapGCN.TabIndex = 4
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(314, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 13)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "Thứ tự vào sổ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Ký hiệu thẩm quyền cấp GCN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Số vào sổ GCN"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnThuTuVaoSoCapGCN)
        Me.GroupBox1.Controls.Add(Me.btnSoVaoSoCapGCN)
        Me.GroupBox1.Controls.Add(Me.cmbKyHieuThamQuyenCapGCN)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpNgayVaoSoCapGCN)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtSoVaoSoCapGCN)
        Me.GroupBox1.Controls.Add(Me.txtThuTuVaoSoCapGCN)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 71)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin Sổ quản lý cấp GCN"
        '
        'btnThuTuVaoSoCapGCN
        '
        Me.btnThuTuVaoSoCapGCN.Location = New System.Drawing.Point(410, 13)
        Me.btnThuTuVaoSoCapGCN.Name = "btnThuTuVaoSoCapGCN"
        Me.btnThuTuVaoSoCapGCN.Size = New System.Drawing.Size(27, 20)
        Me.btnThuTuVaoSoCapGCN.TabIndex = 1
        Me.btnThuTuVaoSoCapGCN.Text = ">>"
        Me.btnThuTuVaoSoCapGCN.UseVisualStyleBackColor = True
        '
        'btnSoVaoSoCapGCN
        '
        Me.btnSoVaoSoCapGCN.Location = New System.Drawing.Point(145, 43)
        Me.btnSoVaoSoCapGCN.Name = "btnSoVaoSoCapGCN"
        Me.btnSoVaoSoCapGCN.Size = New System.Drawing.Size(27, 20)
        Me.btnSoVaoSoCapGCN.TabIndex = 3
        Me.btnSoVaoSoCapGCN.Text = ">>"
        Me.btnSoVaoSoCapGCN.UseVisualStyleBackColor = True
        '
        'cmbKyHieuThamQuyenCapGCN
        '
        Me.cmbKyHieuThamQuyenCapGCN.FormattingEnabled = True
        Me.cmbKyHieuThamQuyenCapGCN.Items.AddRange(New Object() {"CH", "CT"})
        Me.cmbKyHieuThamQuyenCapGCN.Location = New System.Drawing.Point(173, 13)
        Me.cmbKyHieuThamQuyenCapGCN.Name = "cmbKyHieuThamQuyenCapGCN"
        Me.cmbKyHieuThamQuyenCapGCN.Size = New System.Drawing.Size(116, 21)
        Me.cmbKyHieuThamQuyenCapGCN.TabIndex = 0
        Me.cmbKyHieuThamQuyenCapGCN.Text = "CH"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(366, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Ngày vào sổ"
        '
        'dtpNgayVaoSoCapGCN
        '
        Me.dtpNgayVaoSoCapGCN.Location = New System.Drawing.Point(439, 43)
        Me.dtpNgayVaoSoCapGCN.Name = "dtpNgayVaoSoCapGCN"
        Me.dtpNgayVaoSoCapGCN.Size = New System.Drawing.Size(145, 20)
        Me.dtpNgayVaoSoCapGCN.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 45)
        Me.GroupBox2.TabIndex = 86
        Me.GroupBox2.TabStop = False
        '
        'ctrlThongTinSoCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinSoCapGCN"
        Me.Size = New System.Drawing.Size(729, 128)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents txtThuTuVaoSoCapGCN As System.Windows.Forms.TextBox
    Friend WithEvents txtSoVaoSoCapGCN As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayVaoSoCapGCN As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbKyHieuThamQuyenCapGCN As System.Windows.Forms.ComboBox
    Friend WithEvents btnSoVaoSoCapGCN As System.Windows.Forms.Button
    Friend WithEvents btnThuTuVaoSoCapGCN As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
