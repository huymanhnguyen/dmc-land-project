﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrToTrinh
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpNgayTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.txtDonViLapToTrinh = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpNgayLapTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.txtToTrinhSo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdTimToTrinh = New System.Windows.Forms.Button
        Me.saveFile = New System.Windows.Forms.SaveFileDialog
        Me.cboBoChon = New System.Windows.Forms.Button
        Me.cboChon = New System.Windows.Forms.Button
        Me.cmdChapNhan = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdChonIn = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrtTimKiemHoSoThuaDat1 = New DMC.Land.TimKiem.crtTimKiemHoSoThuaDat
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.dtpNgayTrinhDiaChinh)
        Me.GroupBox4.Controls.Add(Me.txtDonViLapToTrinh)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.dtpNgayLapTrinhDiaChinh)
        Me.GroupBox4.Controls.Add(Me.txtToTrinhSo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cmdTimToTrinh)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(787, 70)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông tin tờ trình"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ngày trình"
        '
        'dtpNgayTrinhDiaChinh
        '
        Me.dtpNgayTrinhDiaChinh.Enabled = False
        Me.dtpNgayTrinhDiaChinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayTrinhDiaChinh.Location = New System.Drawing.Point(542, 39)
        Me.dtpNgayTrinhDiaChinh.Name = "dtpNgayTrinhDiaChinh"
        Me.dtpNgayTrinhDiaChinh.Size = New System.Drawing.Size(139, 20)
        Me.dtpNgayTrinhDiaChinh.TabIndex = 7
        '
        'txtDonViLapToTrinh
        '
        Me.txtDonViLapToTrinh.Enabled = False
        Me.txtDonViLapToTrinh.Location = New System.Drawing.Point(73, 42)
        Me.txtDonViLapToTrinh.Name = "txtDonViLapToTrinh"
        Me.txtDonViLapToTrinh.Size = New System.Drawing.Size(368, 20)
        Me.txtDonViLapToTrinh.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Đơn vị lập"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(452, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ngày lập tờ trình"
        '
        'dtpNgayLapTrinhDiaChinh
        '
        Me.dtpNgayLapTrinhDiaChinh.Enabled = False
        Me.dtpNgayLapTrinhDiaChinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayLapTrinhDiaChinh.Location = New System.Drawing.Point(542, 15)
        Me.dtpNgayLapTrinhDiaChinh.Name = "dtpNgayLapTrinhDiaChinh"
        Me.dtpNgayLapTrinhDiaChinh.Size = New System.Drawing.Size(139, 20)
        Me.dtpNgayLapTrinhDiaChinh.TabIndex = 5
        '
        'txtToTrinhSo
        '
        Me.txtToTrinhSo.Enabled = False
        Me.txtToTrinhSo.Location = New System.Drawing.Point(73, 18)
        Me.txtToTrinhSo.Name = "txtToTrinhSo"
        Me.txtToTrinhSo.Size = New System.Drawing.Size(123, 20)
        Me.txtToTrinhSo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tờ trình số:"
        '
        'cmdTimToTrinh
        '
        Me.cmdTimToTrinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTimToTrinh.Location = New System.Drawing.Point(721, 23)
        Me.cmdTimToTrinh.Name = "cmdTimToTrinh"
        Me.cmdTimToTrinh.Size = New System.Drawing.Size(60, 22)
        Me.cmdTimToTrinh.TabIndex = 8
        Me.cmdTimToTrinh.Text = "Tìm"
        Me.cmdTimToTrinh.UseVisualStyleBackColor = True
        '
        'cboBoChon
        '
        Me.cboBoChon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboBoChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cboBoChon.Location = New System.Drawing.Point(383, 469)
        Me.cboBoChon.Name = "cboBoChon"
        Me.cboBoChon.Size = New System.Drawing.Size(55, 33)
        Me.cboBoChon.TabIndex = 11
        Me.cboBoChon.Text = "Bỏ chọn"
        Me.cboBoChon.UseVisualStyleBackColor = True
        '
        'cboChon
        '
        Me.cboChon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cboChon.Location = New System.Drawing.Point(329, 469)
        Me.cboChon.Name = "cboChon"
        Me.cboChon.Size = New System.Drawing.Size(55, 33)
        Me.cboChon.TabIndex = 10
        Me.cboChon.Text = "Chọn"
        Me.cboChon.UseVisualStyleBackColor = True
        '
        'cmdChapNhan
        '
        Me.cmdChapNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChapNhan.Location = New System.Drawing.Point(724, 648)
        Me.cmdChapNhan.Name = "cmdChapNhan"
        Me.cmdChapNhan.Size = New System.Drawing.Size(60, 22)
        Me.cmdChapNhan.TabIndex = 13
        Me.cmdChapNhan.Text = "Ghi"
        Me.cmdChapNhan.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grdChonIn)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 498)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(784, 144)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách hồ sơ"
        '
        'grdChonIn
        '
        Me.grdChonIn.AllowUserToAddRows = False
        Me.grdChonIn.AllowUserToDeleteRows = False
        Me.grdChonIn.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonIn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdChonIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdChonIn.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdChonIn.Location = New System.Drawing.Point(6, 16)
        Me.grdChonIn.Name = "grdChonIn"
        Me.grdChonIn.ReadOnly = True
        Me.grdChonIn.RowHeadersWidth = 25
        Me.grdChonIn.Size = New System.Drawing.Size(762, 122)
        Me.grdChonIn.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CrtTimKiemHoSoThuaDat1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(790, 396)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tìm kiếm hồ sơ in"
        '
        'CrtTimKiemHoSoThuaDat1
        '
        Me.CrtTimKiemHoSoThuaDat1.BackColor = System.Drawing.Color.Lavender
        Me.CrtTimKiemHoSoThuaDat1.CanhBaoTranhChap = ""
        Me.CrtTimKiemHoSoThuaDat1.ChuChuyenNhuong = Nothing
        Me.CrtTimKiemHoSoThuaDat1.ChuSuDung = ""
        Me.CrtTimKiemHoSoThuaDat1.DiaChiThua = ""
        Me.CrtTimKiemHoSoThuaDat1.DienTich = ""
        Me.CrtTimKiemHoSoThuaDat1.Location = New System.Drawing.Point(8, 21)
        Me.CrtTimKiemHoSoThuaDat1.MaDonViHanhChinh = ""
        Me.CrtTimKiemHoSoThuaDat1.NamCapGCN = ""
        Me.CrtTimKiemHoSoThuaDat1.Name = "CrtTimKiemHoSoThuaDat1"
        Me.CrtTimKiemHoSoThuaDat1.NgayLapToTrinh = ""
        Me.CrtTimKiemHoSoThuaDat1.Size = New System.Drawing.Size(772, 369)
        Me.CrtTimKiemHoSoThuaDat1.SoDinhDanh = ""
        Me.CrtTimKiemHoSoThuaDat1.SoThua = ""
        Me.CrtTimKiemHoSoThuaDat1.TabIndex = 9
        Me.CrtTimKiemHoSoThuaDat1.TenBangBanDo = Nothing
        Me.CrtTimKiemHoSoThuaDat1.ToBanDo = ""
        '
        'ctrToTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.cmdChapNhan)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cboBoChon)
        Me.Controls.Add(Me.cboChon)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ctrToTrinh"
        Me.Size = New System.Drawing.Size(799, 673)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents saveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboBoChon As System.Windows.Forms.Button
    Friend WithEvents cboChon As System.Windows.Forms.Button
    Friend WithEvents cmdChapNhan As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtTimKiemHoSoThuaDat1 As DMC.Land.TimKiem.crtTimKiemHoSoThuaDat
    Friend WithEvents grdChonIn As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents cmdTimToTrinh As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayTrinhDiaChinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDonViLapToTrinh As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayLapTrinhDiaChinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtToTrinhSo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class