<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlChuCQNN
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
        Me.GroupThaoTac = New System.Windows.Forms.GroupBox
        Me.grdvwChu = New DMC.[Interface].GridView.ctrlGridView
        Me.btnMaDoiTuong = New System.Windows.Forms.Button
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.txtTen = New System.Windows.Forms.TextBox
        Me.txtMaDoiTuong = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupThaoTac.SuspendLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupThaoTac
        '
        Me.GroupThaoTac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupThaoTac.Controls.Add(Me.grdvwChu)
        Me.GroupThaoTac.Controls.Add(Me.btnMaDoiTuong)
        Me.GroupThaoTac.Controls.Add(Me.txtDiaChi)
        Me.GroupThaoTac.Controls.Add(Me.txtTen)
        Me.GroupThaoTac.Controls.Add(Me.txtMaDoiTuong)
        Me.GroupThaoTac.Controls.Add(Me.Label1)
        Me.GroupThaoTac.Controls.Add(Me.Label2)
        Me.GroupThaoTac.Controls.Add(Me.Label3)
        Me.GroupThaoTac.Location = New System.Drawing.Point(3, 3)
        Me.GroupThaoTac.Name = "GroupThaoTac"
        Me.GroupThaoTac.Size = New System.Drawing.Size(728, 238)
        Me.GroupThaoTac.TabIndex = 121
        Me.GroupThaoTac.TabStop = False
        '
        'grdvwChu
        '
        Me.grdvwChu.AllowUserToAddRows = False
        Me.grdvwChu.AllowUserToDeleteRows = False
        Me.grdvwChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdvwChu.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwChu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwChu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwChu.Location = New System.Drawing.Point(6, 65)
        Me.grdvwChu.Name = "grdvwChu"
        Me.grdvwChu.ReadOnly = True
        Me.grdvwChu.RowHeadersWidth = 25
        Me.grdvwChu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdvwChu.Size = New System.Drawing.Size(715, 166)
        Me.grdvwChu.TabIndex = 12
        '
        'btnMaDoiTuong
        '
        Me.btnMaDoiTuong.Location = New System.Drawing.Point(186, 13)
        Me.btnMaDoiTuong.Name = "btnMaDoiTuong"
        Me.btnMaDoiTuong.Size = New System.Drawing.Size(24, 21)
        Me.btnMaDoiTuong.TabIndex = 2
        Me.btnMaDoiTuong.Text = "..."
        Me.btnMaDoiTuong.UseVisualStyleBackColor = True
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChi.Location = New System.Drawing.Point(92, 39)
        Me.txtDiaChi.Multiline = True
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(630, 20)
        Me.txtDiaChi.TabIndex = 6
        Me.txtDiaChi.Text = "Phường Long Biên, Quận Long Biên, Tp Hà Nội"
        '
        'txtTen
        '
        Me.txtTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen.Location = New System.Drawing.Point(274, 13)
        Me.txtTen.Multiline = True
        Me.txtTen.Name = "txtTen"
        Me.txtTen.Size = New System.Drawing.Size(327, 20)
        Me.txtTen.TabIndex = 4
        '
        'txtMaDoiTuong
        '
        Me.txtMaDoiTuong.Location = New System.Drawing.Point(92, 13)
        Me.txtMaDoiTuong.Name = "txtMaDoiTuong"
        Me.txtMaDoiTuong.Size = New System.Drawing.Size(94, 20)
        Me.txtMaDoiTuong.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Địa chỉ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tên"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mã đối tượng"
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(207, 244)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(64, 23)
        Me.btnGhi.TabIndex = 10
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(141, 244)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(64, 23)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(75, 244)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(64, 23)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(9, 244)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(64, 23)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHuyLenh.Location = New System.Drawing.Point(273, 244)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(64, 23)
        Me.btnHuyLenh.TabIndex = 11
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'ctrlChuCQNN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupThaoTac)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Name = "ctrlChuCQNN"
        Me.Size = New System.Drawing.Size(735, 270)
        Me.GroupThaoTac.ResumeLayout(False)
        Me.GroupThaoTac.PerformLayout()
        CType(Me.grdvwChu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupThaoTac As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents txtTen As System.Windows.Forms.TextBox
    Friend WithEvents txtMaDoiTuong As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnMaDoiTuong As System.Windows.Forms.Button
    Public WithEvents grdvwChu As DMC.Interface.GridView.ctrlGridView

End Class
