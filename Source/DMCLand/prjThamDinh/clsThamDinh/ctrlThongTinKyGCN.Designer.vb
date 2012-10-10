<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinKyGCN
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnTieuDeKyGCN = New System.Windows.Forms.Button
        Me.btnTuDienNguoiKyGCN = New System.Windows.Forms.Button
        Me.txtTieuDeKyGCN = New System.Windows.Forms.RichTextBox
        Me.txtDiaDanhNoiCap = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtpNgayKyGCN = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNguoiKyGCN = New System.Windows.Forms.TextBox
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmDiaDanh = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmDiaDanh)
        Me.GroupBox1.Controls.Add(Me.btnTieuDeKyGCN)
        Me.GroupBox1.Controls.Add(Me.btnTuDienNguoiKyGCN)
        Me.GroupBox1.Controls.Add(Me.txtTieuDeKyGCN)
        Me.GroupBox1.Controls.Add(Me.txtDiaDanhNoiCap)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.dtpNgayKyGCN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNguoiKyGCN)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 117)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin ký cấp GCN"
        '
        'btnTieuDeKyGCN
        '
        Me.btnTieuDeKyGCN.Location = New System.Drawing.Point(127, 65)
        Me.btnTieuDeKyGCN.Name = "btnTieuDeKyGCN"
        Me.btnTieuDeKyGCN.Size = New System.Drawing.Size(24, 21)
        Me.btnTieuDeKyGCN.TabIndex = 2
        Me.btnTieuDeKyGCN.Text = "..."
        Me.btnTieuDeKyGCN.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnTieuDeKyGCN.UseVisualStyleBackColor = True
        '
        'btnTuDienNguoiKyGCN
        '
        Me.btnTuDienNguoiKyGCN.Location = New System.Drawing.Point(126, 92)
        Me.btnTuDienNguoiKyGCN.Name = "btnTuDienNguoiKyGCN"
        Me.btnTuDienNguoiKyGCN.Size = New System.Drawing.Size(24, 21)
        Me.btnTuDienNguoiKyGCN.TabIndex = 4
        Me.btnTuDienNguoiKyGCN.Text = "..."
        Me.btnTuDienNguoiKyGCN.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnTuDienNguoiKyGCN.UseVisualStyleBackColor = True
        '
        'txtTieuDeKyGCN
        '
        Me.txtTieuDeKyGCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTieuDeKyGCN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTieuDeKyGCN.Location = New System.Drawing.Point(156, 42)
        Me.txtTieuDeKyGCN.Name = "txtTieuDeKyGCN"
        Me.txtTieuDeKyGCN.Size = New System.Drawing.Size(561, 43)
        Me.txtTieuDeKyGCN.TabIndex = 3
        Me.txtTieuDeKyGCN.Text = ""
        '
        'txtDiaDanhNoiCap
        '
        Me.txtDiaDanhNoiCap.Location = New System.Drawing.Point(156, 13)
        Me.txtDiaDanhNoiCap.Name = "txtDiaDanhNoiCap"
        Me.txtDiaDanhNoiCap.Size = New System.Drawing.Size(260, 20)
        Me.txtDiaDanhNoiCap.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Tiêu đề ký cấp GCN"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Địa danh nơi cấp GCN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(457, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Ngày ký GCN"
        '
        'dtpNgayKyGCN
        '
        Me.dtpNgayKyGCN.Enabled = False
        Me.dtpNgayKyGCN.Location = New System.Drawing.Point(556, 14)
        Me.dtpNgayKyGCN.Name = "dtpNgayKyGCN"
        Me.dtpNgayKyGCN.Size = New System.Drawing.Size(162, 20)
        Me.dtpNgayKyGCN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Người ký GCN"
        '
        'txtNguoiKyGCN
        '
        Me.txtNguoiKyGCN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNguoiKyGCN.Location = New System.Drawing.Point(156, 93)
        Me.txtNguoiKyGCN.Name = "txtNguoiKyGCN"
        Me.txtNguoiKyGCN.Size = New System.Drawing.Size(564, 20)
        Me.txtNguoiKyGCN.TabIndex = 5
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(195, 11)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 9
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(70, 11)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 7
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(6, 11)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 6
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(131, 11)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 8
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 38)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        '
        'cmDiaDanh
        '
        Me.cmDiaDanh.Location = New System.Drawing.Point(422, 12)
        Me.cmDiaDanh.Name = "cmDiaDanh"
        Me.cmDiaDanh.Size = New System.Drawing.Size(24, 21)
        Me.cmDiaDanh.TabIndex = 81
        Me.cmDiaDanh.Text = "..."
        Me.cmDiaDanh.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmDiaDanh.UseVisualStyleBackColor = True
        '
        'ctrlThongTinKyGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinKyGCN"
        Me.Size = New System.Drawing.Size(729, 173)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiaDanhNoiCap As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayKyGCN As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents txtTieuDeKyGCN As System.Windows.Forms.RichTextBox
    Public WithEvents txtNguoiKyGCN As System.Windows.Forms.TextBox
    Friend WithEvents btnTuDienNguoiKyGCN As System.Windows.Forms.Button
    Friend WithEvents btnTieuDeKyGCN As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmDiaDanh As System.Windows.Forms.Button

End Class
