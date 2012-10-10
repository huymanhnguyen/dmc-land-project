<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNguoiLap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.grdNguoiLapBieu = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdHuy = New System.Windows.Forms.Button
        Me.cmdGhi = New System.Windows.Forms.Button
        Me.cmdXoa = New System.Windows.Forms.Button
        Me.cmdSua = New System.Windows.Forms.Button
        Me.cmdThem = New System.Windows.Forms.Button
        Me.txtChucVu = New System.Windows.Forms.TextBox
        Me.cboGioiTinh = New System.Windows.Forms.ComboBox
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.grdNguoiLapBieu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdNguoiLapBieu
        '
        Me.grdNguoiLapBieu.AllowUserToAddRows = False
        Me.grdNguoiLapBieu.AllowUserToDeleteRows = False
        Me.grdNguoiLapBieu.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdNguoiLapBieu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdNguoiLapBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdNguoiLapBieu.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdNguoiLapBieu.Location = New System.Drawing.Point(5, 12)
        Me.grdNguoiLapBieu.Name = "grdNguoiLapBieu"
        Me.grdNguoiLapBieu.ReadOnly = True
        Me.grdNguoiLapBieu.RowHeadersWidth = 25
        Me.grdNguoiLapBieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdNguoiLapBieu.Size = New System.Drawing.Size(605, 241)
        Me.grdNguoiLapBieu.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdHuy)
        Me.GroupBox1.Controls.Add(Me.cmdGhi)
        Me.GroupBox1.Controls.Add(Me.cmdXoa)
        Me.GroupBox1.Controls.Add(Me.cmdSua)
        Me.GroupBox1.Controls.Add(Me.cmdThem)
        Me.GroupBox1.Controls.Add(Me.txtChucVu)
        Me.GroupBox1.Controls.Add(Me.cboGioiTinh)
        Me.GroupBox1.Controls.Add(Me.txtHoTen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 259)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(601, 104)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmdHuy
        '
        Me.cmdHuy.Location = New System.Drawing.Point(311, 71)
        Me.cmdHuy.Name = "cmdHuy"
        Me.cmdHuy.Size = New System.Drawing.Size(70, 23)
        Me.cmdHuy.TabIndex = 10
        Me.cmdHuy.Text = "Huỷ"
        Me.cmdHuy.UseVisualStyleBackColor = True
        '
        'cmdGhi
        '
        Me.cmdGhi.Location = New System.Drawing.Point(235, 71)
        Me.cmdGhi.Name = "cmdGhi"
        Me.cmdGhi.Size = New System.Drawing.Size(70, 23)
        Me.cmdGhi.TabIndex = 9
        Me.cmdGhi.Text = "Ghi"
        Me.cmdGhi.UseVisualStyleBackColor = True
        '
        'cmdXoa
        '
        Me.cmdXoa.Location = New System.Drawing.Point(159, 71)
        Me.cmdXoa.Name = "cmdXoa"
        Me.cmdXoa.Size = New System.Drawing.Size(70, 23)
        Me.cmdXoa.TabIndex = 8
        Me.cmdXoa.Text = "Xoá"
        Me.cmdXoa.UseVisualStyleBackColor = True
        '
        'cmdSua
        '
        Me.cmdSua.Location = New System.Drawing.Point(83, 71)
        Me.cmdSua.Name = "cmdSua"
        Me.cmdSua.Size = New System.Drawing.Size(70, 23)
        Me.cmdSua.TabIndex = 7
        Me.cmdSua.Text = "Sửa"
        Me.cmdSua.UseVisualStyleBackColor = True
        '
        'cmdThem
        '
        Me.cmdThem.Location = New System.Drawing.Point(7, 71)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(70, 23)
        Me.cmdThem.TabIndex = 6
        Me.cmdThem.Text = "Thêm"
        Me.cmdThem.UseVisualStyleBackColor = True
        '
        'txtChucVu
        '
        Me.txtChucVu.Location = New System.Drawing.Point(51, 45)
        Me.txtChucVu.Name = "txtChucVu"
        Me.txtChucVu.Size = New System.Drawing.Size(188, 20)
        Me.txtChucVu.TabIndex = 5
        '
        'cboGioiTinh
        '
        Me.cboGioiTinh.FormattingEnabled = True
        Me.cboGioiTinh.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cboGioiTinh.Location = New System.Drawing.Point(399, 21)
        Me.cboGioiTinh.Name = "cboGioiTinh"
        Me.cboGioiTinh.Size = New System.Drawing.Size(108, 21)
        Me.cboGioiTinh.TabIndex = 4
        '
        'txtHoTen
        '
        Me.txtHoTen.Location = New System.Drawing.Point(51, 19)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(238, 20)
        Me.txtHoTen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Chức vụ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Giới tính"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Họ tên"
        '
        'frmNguoiLap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdNguoiLapBieu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNguoiLap"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "NGUOI LAP BIEU"
        CType(Me.grdNguoiLapBieu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdNguoiLapBieu As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents txtChucVu As System.Windows.Forms.TextBox
    Friend WithEvents cboGioiTinh As System.Windows.Forms.ComboBox
    Friend WithEvents cmdXoa As System.Windows.Forms.Button
    Friend WithEvents cmdSua As System.Windows.Forms.Button
    Friend WithEvents cmdThem As System.Windows.Forms.Button
    Friend WithEvents cmdHuy As System.Windows.Forms.Button
    Friend WithEvents cmdGhi As System.Windows.Forms.Button
End Class
