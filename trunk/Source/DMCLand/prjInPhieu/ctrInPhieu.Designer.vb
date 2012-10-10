<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrInPhieu
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdChonIn = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrtTimKiemHoSoThuaDat1 = New DMC.Land.TimKiem.crtTimKiemHoSoThuaDat
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdChapNhan = New System.Windows.Forms.Button
        Me.cboBoChon = New System.Windows.Forms.Button
        Me.cboChon = New System.Windows.Forms.Button
        Me.saveFile = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpNgayTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.txtToTrinhSo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grdChonIn)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(784, 181)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách hồ sơ"
        '
        'grdChonIn
        '
        Me.grdChonIn.AllowUserToAddRows = False
        Me.grdChonIn.AllowUserToDeleteRows = False
        Me.grdChonIn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.grdChonIn.Location = New System.Drawing.Point(3, 16)
        Me.grdChonIn.Name = "grdChonIn"
        Me.grdChonIn.ReadOnly = True
        Me.grdChonIn.RowHeadersWidth = 25
        Me.grdChonIn.Size = New System.Drawing.Size(778, 162)
        Me.grdChonIn.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CrtTimKiemHoSoThuaDat1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(790, 283)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tìm kiếm hồ sơ in"
        '
        'CrtTimKiemHoSoThuaDat1
        '
        Me.CrtTimKiemHoSoThuaDat1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrtTimKiemHoSoThuaDat1.BackColor = System.Drawing.Color.Lavender
        Me.CrtTimKiemHoSoThuaDat1.ChuSuDung = ""
        Me.CrtTimKiemHoSoThuaDat1.DiaChiThua = ""
        Me.CrtTimKiemHoSoThuaDat1.DienTich = ""
        Me.CrtTimKiemHoSoThuaDat1.Location = New System.Drawing.Point(3, 16)
        Me.CrtTimKiemHoSoThuaDat1.NamCapGCN = ""
        Me.CrtTimKiemHoSoThuaDat1.Name = "CrtTimKiemHoSoThuaDat1"
        Me.CrtTimKiemHoSoThuaDat1.NgayLapToTrinh = ""
        Me.CrtTimKiemHoSoThuaDat1.Size = New System.Drawing.Size(784, 264)
        Me.CrtTimKiemHoSoThuaDat1.SoDinhDanh = ""
        Me.CrtTimKiemHoSoThuaDat1.SoThua = ""
        Me.CrtTimKiemHoSoThuaDat1.TabIndex = 3
        Me.CrtTimKiemHoSoThuaDat1.ToBanDo = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdChapNhan)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 575)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 37)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmdChapNhan
        '
        Me.cmdChapNhan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChapNhan.Location = New System.Drawing.Point(694, 13)
        Me.cmdChapNhan.Name = "cmdChapNhan"
        Me.cmdChapNhan.Size = New System.Drawing.Size(89, 22)
        Me.cmdChapNhan.TabIndex = 6
        Me.cmdChapNhan.Text = "Lưu"
        Me.cmdChapNhan.UseVisualStyleBackColor = True
        '
        'cboBoChon
        '
        Me.cboBoChon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboBoChon.BackgroundImage = Global.DMC.Land.InPhieu.My.Resources.Resources.Arrow_Up
        Me.cboBoChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cboBoChon.Location = New System.Drawing.Point(377, 351)
        Me.cboBoChon.Name = "cboBoChon"
        Me.cboBoChon.Size = New System.Drawing.Size(48, 33)
        Me.cboBoChon.TabIndex = 4
        Me.cboBoChon.UseVisualStyleBackColor = True
        '
        'cboChon
        '
        Me.cboChon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboChon.BackgroundImage = Global.DMC.Land.InPhieu.My.Resources.Resources.Arrow_Down
        Me.cboChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cboChon.Location = New System.Drawing.Point(323, 351)
        Me.cboChon.Name = "cboChon"
        Me.cboChon.Size = New System.Drawing.Size(48, 33)
        Me.cboChon.TabIndex = 3
        Me.cboChon.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.dtpNgayTrinhDiaChinh)
        Me.GroupBox4.Controls.Add(Me.txtToTrinhSo)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(787, 57)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông tin tờ trình"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ngày trình"
        '
        'dtpNgayTrinhDiaChinh
        '
        Me.dtpNgayTrinhDiaChinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayTrinhDiaChinh.Location = New System.Drawing.Point(312, 19)
        Me.dtpNgayTrinhDiaChinh.Name = "dtpNgayTrinhDiaChinh"
        Me.dtpNgayTrinhDiaChinh.Size = New System.Drawing.Size(139, 20)
        Me.dtpNgayTrinhDiaChinh.TabIndex = 2
        '
        'txtToTrinhSo
        '
        Me.txtToTrinhSo.Location = New System.Drawing.Point(81, 20)
        Me.txtToTrinhSo.Name = "txtToTrinhSo"
        Me.txtToTrinhSo.Size = New System.Drawing.Size(123, 20)
        Me.txtToTrinhSo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tờ trình số:"
        '
        'ctrInPhieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cboBoChon)
        Me.Controls.Add(Me.cboChon)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ctrInPhieu"
        Me.Size = New System.Drawing.Size(800, 617)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtTimKiemHoSoThuaDat1 As DMC.Land.TimKiem.crtTimKiemHoSoThuaDat
    Friend WithEvents grdChonIn As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChapNhan As System.Windows.Forms.Button
    Friend WithEvents cboChon As System.Windows.Forms.Button
    Friend WithEvents cboBoChon As System.Windows.Forms.Button
    Friend WithEvents saveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtToTrinhSo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayTrinhDiaChinh As System.Windows.Forms.DateTimePicker

End Class
