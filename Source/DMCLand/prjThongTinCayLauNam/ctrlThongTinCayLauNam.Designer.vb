<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinCayLauNam
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
        Me.txtLoaiCay = New System.Windows.Forms.TextBox
        Me.numDienTich = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grdvw = New DMC.[Interface].GridView.ctrlGridView
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupThongtinkekhaitaisan.SuspendLayout()
        CType(Me.numDienTich, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupThongtinkekhaitaisan
        '
        Me.GroupThongtinkekhaitaisan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.txtLoaiCay)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.numDienTich)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label12)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label3)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.Label9)
        Me.GroupThongtinkekhaitaisan.Controls.Add(Me.grdvw)
        Me.GroupThongtinkekhaitaisan.Location = New System.Drawing.Point(3, 4)
        Me.GroupThongtinkekhaitaisan.Name = "GroupThongtinkekhaitaisan"
        Me.GroupThongtinkekhaitaisan.Size = New System.Drawing.Size(738, 150)
        Me.GroupThongtinkekhaitaisan.TabIndex = 5
        Me.GroupThongtinkekhaitaisan.TabStop = False
        '
        'txtLoaiCay
        '
        Me.txtLoaiCay.Location = New System.Drawing.Point(121, 42)
        Me.txtLoaiCay.Name = "txtLoaiCay"
        Me.txtLoaiCay.Size = New System.Drawing.Size(610, 20)
        Me.txtLoaiCay.TabIndex = 1
        '
        'numDienTich
        '
        Me.numDienTich.DecimalPlaces = 1
        Me.numDienTich.Location = New System.Drawing.Point(121, 11)
        Me.numDienTich.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDienTich.Name = "numDienTich"
        Me.numDienTich.Size = New System.Drawing.Size(110, 20)
        Me.numDienTich.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Loại cây"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Lavender
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(237, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "(m2)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(47, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Diện tích"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdvw
        '
        Me.grdvw.AllowUserToAddRows = False
        Me.grdvw.AllowUserToDeleteRows = False
        Me.grdvw.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvw.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvw.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvw.Location = New System.Drawing.Point(7, 68)
        Me.grdvw.Name = "grdvw"
        Me.grdvw.ReadOnly = True
        Me.grdvw.RowHeadersWidth = 25
        Me.grdvw.Size = New System.Drawing.Size(726, 75)
        Me.grdvw.TabIndex = 2
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(67, 9)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 4
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(6, 9)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 3
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(666, 9)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(63, 21)
        Me.btnTroGiup.TabIndex = 8
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(128, 9)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 5
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(253, 10)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 7
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(189, 9)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 6
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(738, 36)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'ctrlThongTinCayLauNam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupThongtinkekhaitaisan)
        Me.Name = "ctrlThongTinCayLauNam"
        Me.Size = New System.Drawing.Size(743, 197)
        Me.GroupThongtinkekhaitaisan.ResumeLayout(False)
        Me.GroupThongtinkekhaitaisan.PerformLayout()
        CType(Me.numDienTich, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupThongtinkekhaitaisan As System.Windows.Forms.GroupBox
    Friend WithEvents grdvw As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents txtLoaiCay As System.Windows.Forms.TextBox
    Friend WithEvents numDienTich As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
