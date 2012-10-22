<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrPhanQuyenQuyTrinhChucNang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrPhanQuyenQuyTrinhChucNang))
        Me.lblActiveThamDinh = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdHuyLenh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpNgayCapNhat = New System.Windows.Forms.DateTimePicker
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.dmcXoa = New System.Windows.Forms.Button
        Me.cmdCapNhat = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkCheckAll = New System.Windows.Forms.CheckBox
        Me.grdChucNang = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdNguoiDung = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdChucNang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdNguoiDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblActiveThamDinh
        '
        Me.lblActiveThamDinh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActiveThamDinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveThamDinh.Image = CType(resources.GetObject("lblActiveThamDinh.Image"), System.Drawing.Image)
        Me.lblActiveThamDinh.Location = New System.Drawing.Point(-3, 0)
        Me.lblActiveThamDinh.Name = "lblActiveThamDinh"
        Me.lblActiveThamDinh.Size = New System.Drawing.Size(879, 20)
        Me.lblActiveThamDinh.TabIndex = 27
        Me.lblActiveThamDinh.Text = "PHÂN QUYỀN QUY TRÌNH CHỨC NĂNG HỒ SƠ"
        Me.lblActiveThamDinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdHuyLenh)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpNgayCapNhat)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.dmcXoa)
        Me.GroupBox1.Controls.Add(Me.cmdCapNhat)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(875, 48)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'cmdHuyLenh
        '
        Me.cmdHuyLenh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdHuyLenh.Location = New System.Drawing.Point(744, 19)
        Me.cmdHuyLenh.Name = "cmdHuyLenh"
        Me.cmdHuyLenh.Size = New System.Drawing.Size(59, 22)
        Me.cmdHuyLenh.TabIndex = 7
        Me.cmdHuyLenh.Text = "Hủy lệnh"
        Me.cmdHuyLenh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ngày cập nhật"
        '
        'dtpNgayCapNhat
        '
        Me.dtpNgayCapNhat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayCapNhat.Location = New System.Drawing.Point(90, 19)
        Me.dtpNgayCapNhat.Name = "dtpNgayCapNhat"
        Me.dtpNgayCapNhat.Size = New System.Drawing.Size(128, 20)
        Me.dtpNgayCapNhat.TabIndex = 1
        '
        'cmdThoat
        '
        Me.cmdThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdThoat.Location = New System.Drawing.Point(810, 19)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(59, 22)
        Me.cmdThoat.TabIndex = 8
        Me.cmdThoat.Text = "Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'dmcXoa
        '
        Me.dmcXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dmcXoa.Location = New System.Drawing.Point(679, 20)
        Me.dmcXoa.Name = "dmcXoa"
        Me.dmcXoa.Size = New System.Drawing.Size(59, 22)
        Me.dmcXoa.TabIndex = 6
        Me.dmcXoa.Text = "Xóa"
        Me.dmcXoa.UseVisualStyleBackColor = True
        '
        'cmdCapNhat
        '
        Me.cmdCapNhat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCapNhat.Location = New System.Drawing.Point(614, 20)
        Me.cmdCapNhat.Name = "cmdCapNhat"
        Me.cmdCapNhat.Size = New System.Drawing.Size(59, 22)
        Me.cmdCapNhat.TabIndex = 5
        Me.cmdCapNhat.Text = "Cập nhật"
        Me.cmdCapNhat.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCheckAll)
        Me.GroupBox2.Controls.Add(Me.grdChucNang)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(307, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 434)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Location = New System.Drawing.Point(9, 16)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(125, 17)
        Me.chkCheckAll.TabIndex = 3
        Me.chkCheckAll.Text = "Chọn/bỏ chọn tất cả"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'grdChucNang
        '
        Me.grdChucNang.AllowUserToAddRows = False
        Me.grdChucNang.AllowUserToDeleteRows = False
        Me.grdChucNang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdChucNang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdChucNang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdChucNang.Location = New System.Drawing.Point(3, 39)
        Me.grdChucNang.Name = "grdChucNang"
        Me.grdChucNang.ReadOnly = True
        Me.grdChucNang.Size = New System.Drawing.Size(557, 392)
        Me.grdChucNang.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdNguoiDung)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(304, 434)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'grdNguoiDung
        '
        Me.grdNguoiDung.AllowUserToAddRows = False
        Me.grdNguoiDung.AllowUserToDeleteRows = False
        Me.grdNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNguoiDung.Location = New System.Drawing.Point(3, 16)
        Me.grdNguoiDung.Name = "grdNguoiDung"
        Me.grdNguoiDung.ReadOnly = True
        Me.grdNguoiDung.Size = New System.Drawing.Size(298, 415)
        Me.grdNguoiDung.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Splitter1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(873, 453)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(307, 16)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 434)
        Me.Splitter1.TabIndex = 31
        Me.Splitter1.TabStop = False
        '
        'ctrPhanQuyenQuyTrinhChucNang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblActiveThamDinh)
        Me.Name = "ctrPhanQuyenQuyTrinhChucNang"
        Me.Size = New System.Drawing.Size(876, 535)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdChucNang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdNguoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lblActiveThamDinh As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdChucNang As System.Windows.Forms.DataGridView
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents dmcXoa As System.Windows.Forms.Button
    Friend WithEvents cmdCapNhat As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayCapNhat As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdNguoiDung As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents chkCheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdHuyLenh As System.Windows.Forms.Button

End Class
