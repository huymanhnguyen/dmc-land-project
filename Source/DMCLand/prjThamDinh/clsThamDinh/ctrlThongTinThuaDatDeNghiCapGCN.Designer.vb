<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinThuaDatDeNghiCapGCN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlThongTinThuaDatDeNghiCapGCN))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnHoSoKiThuat = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnPhieuThamDinh = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtThongTinThuaDatDeNghiCapGCN = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdvwDanhSachThuaDatDangKyCapGCN = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvwDanhSachThuaDatDangKyCapGCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnHoSoKiThuat
        '
        Me.btnHoSoKiThuat.Location = New System.Drawing.Point(330, 12)
        Me.btnHoSoKiThuat.Name = "btnHoSoKiThuat"
        Me.btnHoSoKiThuat.Size = New System.Drawing.Size(92, 21)
        Me.btnHoSoKiThuat.TabIndex = 7
        Me.btnHoSoKiThuat.Text = "Hồ sơ kĩ thuật"
        Me.btnHoSoKiThuat.UseVisualStyleBackColor = True
        Me.btnHoSoKiThuat.Visible = False
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(686, 11)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 8
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnPhieuThamDinh
        '
        Me.btnPhieuThamDinh.Location = New System.Drawing.Point(235, 12)
        Me.btnPhieuThamDinh.Name = "btnPhieuThamDinh"
        Me.btnPhieuThamDinh.Size = New System.Drawing.Size(92, 21)
        Me.btnPhieuThamDinh.TabIndex = 6
        Me.btnPhieuThamDinh.Text = "Phiếu thẩm định"
        Me.btnPhieuThamDinh.UseVisualStyleBackColor = True
        Me.btnPhieuThamDinh.Visible = False
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(176, 12)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 5
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(118, 12)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 4
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(60, 12)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 3
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(2, 12)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox2.Controls.Add(Me.txtThongTinThuaDatDeNghiCapGCN)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(4, 166)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(750, 263)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nội dung thông tin Thửa đất đề nghị ghi tại điểm 1, Mục II của  GCN"
        '
        'txtThongTinThuaDatDeNghiCapGCN
        '
        Me.txtThongTinThuaDatDeNghiCapGCN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtThongTinThuaDatDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtThongTinThuaDatDeNghiCapGCN.Location = New System.Drawing.Point(3, 18)
        Me.txtThongTinThuaDatDeNghiCapGCN.Name = "txtThongTinThuaDatDeNghiCapGCN"
        Me.txtThongTinThuaDatDeNghiCapGCN.Size = New System.Drawing.Size(744, 242)
        Me.txtThongTinThuaDatDeNghiCapGCN.TabIndex = 1
        Me.txtThongTinThuaDatDeNghiCapGCN.Text = resources.GetString("txtThongTinThuaDatDeNghiCapGCN.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdvwDanhSachThuaDatDangKyCapGCN)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 158)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách Thông tin THỬA ĐẤT đăng ký cấp GCN"
        '
        'grdvwDanhSachThuaDatDangKyCapGCN
        '
        Me.grdvwDanhSachThuaDatDangKyCapGCN.AllowUserToAddRows = False
        Me.grdvwDanhSachThuaDatDangKyCapGCN.AllowUserToDeleteRows = False
        Me.grdvwDanhSachThuaDatDangKyCapGCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwDanhSachThuaDatDangKyCapGCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwDanhSachThuaDatDangKyCapGCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwDanhSachThuaDatDangKyCapGCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwDanhSachThuaDatDangKyCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdvwDanhSachThuaDatDangKyCapGCN.Location = New System.Drawing.Point(3, 18)
        Me.grdvwDanhSachThuaDatDangKyCapGCN.Name = "grdvwDanhSachThuaDatDangKyCapGCN"
        Me.grdvwDanhSachThuaDatDangKyCapGCN.ReadOnly = True
        Me.grdvwDanhSachThuaDatDangKyCapGCN.RowHeadersWidth = 25
        Me.grdvwDanhSachThuaDatDangKyCapGCN.Size = New System.Drawing.Size(737, 137)
        Me.grdvwDanhSachThuaDatDangKyCapGCN.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnHoSoKiThuat)
        Me.GroupBox3.Controls.Add(Me.btnPhieuThamDinh)
        Me.GroupBox3.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox3.Controls.Add(Me.btnTroGiup)
        Me.GroupBox3.Controls.Add(Me.btnCapNhat)
        Me.GroupBox3.Controls.Add(Me.btnXoa)
        Me.GroupBox3.Controls.Add(Me.btnSua)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 428)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(751, 39)
        Me.GroupBox3.TabIndex = 116
        Me.GroupBox3.TabStop = False
        '
        'ctrlThongTinThuaDatDeNghiCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ctrlThongTinThuaDatDeNghiCapGCN"
        Me.Size = New System.Drawing.Size(763, 470)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdvwDanhSachThuaDatDangKyCapGCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents btnHoSoKiThuat As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Public WithEvents btnPhieuThamDinh As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtThongTinThuaDatDeNghiCapGCN As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwDanhSachThuaDatDangKyCapGCN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
