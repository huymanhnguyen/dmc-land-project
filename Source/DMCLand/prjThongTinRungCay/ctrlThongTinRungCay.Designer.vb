<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinRungCay
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupThongtinkekhaitaisan = New System.Windows.Forms.GroupBox
        Me.txtNguonGocTaoLap = New System.Windows.Forms.TextBox
        Me.numDienTichCoRung = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSoHoSoGiaoRung = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grdvwRungCay = New DMC.[Interface].GridView.ctrlGridView
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupThongtinkekhaitaisan.SuspendLayout()
        CType(Me.numDienTichCoRung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvwRungCay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupThongtinkekhaitaisan
        '
        Me.GroupThongtinkekhaitaisan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.txtNguonGocTaoLap)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.numDienTichCoRung)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label12)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label3)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.txtSoHoSoGiaoRung)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label11)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label9)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.grdvwRungCay)
        Me.GroupThongtinkekhaitaisan.Location = New System.Drawing.Point(4, 3)
        Me.GroupThongtinkekhaitaisan.Name = "GroupThongtinkekhaitaisan"
        Me.GroupThongtinkekhaitaisan.Size = New System.Drawing.Size(746, 182)
        Me.GroupThongtinkekhaitaisan.TabIndex = 3
        Me.GroupThongtinkekhaitaisan.TabStop = False
        '
        'txtNguonGocTaoLap
        '
        Me.txtNguonGocTaoLap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNguonGocTaoLap.Location = New System.Drawing.Point(118, 45)
        Me.txtNguonGocTaoLap.Name = "txtNguonGocTaoLap"
        Me.txtNguonGocTaoLap.Size = New System.Drawing.Size(620, 20)
        Me.txtNguonGocTaoLap.TabIndex = 1
        '
        'numDienTichCoRung
        '
        Me.numDienTichCoRung.DecimalPlaces = 1
        Me.numDienTichCoRung.Location = New System.Drawing.Point(118, 14)
        Me.numDienTichCoRung.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDienTichCoRung.Name = "numDienTichCoRung"
        Me.numDienTichCoRung.Size = New System.Drawing.Size(110, 20)
        Me.numDienTichCoRung.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Nguồn gốc tạo lập"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Lavender
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(234, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "(m2)"
        '
        'txtSoHoSoGiaoRung
        '
        Me.txtSoHoSoGiaoRung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoHoSoGiaoRung.Location = New System.Drawing.Point(118, 75)
        Me.txtSoHoSoGiaoRung.Name = "txtSoHoSoGiaoRung"
        Me.txtSoHoSoGiaoRung.Size = New System.Drawing.Size(620, 20)
        Me.txtSoHoSoGiaoRung.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Số hồ sơ giao rừng"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(44, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Diện tích"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdvwRungCay
        '
        Me.grdvwRungCay.AllowUserToAddRows = False
        Me.grdvwRungCay.AllowUserToDeleteRows = False
        Me.grdvwRungCay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwRungCay.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwRungCay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwRungCay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwRungCay.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwRungCay.Location = New System.Drawing.Point(6, 101)
        Me.grdvwRungCay.Name = "grdvwRungCay"
        Me.grdvwRungCay.ReadOnly = True
        Me.grdvwRungCay.RowHeadersWidth = 25
        Me.grdvwRungCay.Size = New System.Drawing.Size(732, 76)
        Me.grdvwRungCay.TabIndex = 3
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(67, 13)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 5
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(6, 13)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 4
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(676, 13)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(63, 21)
        Me.btnTroGiup.TabIndex = 10
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(128, 13)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 6
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(256, 15)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 9
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(192, 14)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 7
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox1.Controls.Add(Me.btnCapNhat)
        Me.GroupBox1.Controls.Add(Me.btnSua)
        Me.GroupBox1.Controls.Add(Me.btnTroGiup)
        Me.GroupBox1.Controls.Add(Me.btnThem)
        Me.GroupBox1.Controls.Add(Me.btnXoa)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 186)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(747, 40)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'ctrlThongTinRungCay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupThongtinkekhaitaisan)
        Me.Name = "ctrlThongTinRungCay"
        Me.Size = New System.Drawing.Size(755, 234)
        Me.GroupThongtinkekhaitaisan.ResumeLayout(False)
        Me.GroupThongtinkekhaitaisan.PerformLayout()
        CType(Me.numDienTichCoRung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvwRungCay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupThongtinkekhaitaisan As System.Windows.Forms.GroupBox
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents grdvwRungCay As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents txtNguonGocTaoLap As System.Windows.Forms.TextBox
    Friend WithEvents numDienTichCoRung As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSoHoSoGiaoRung As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
