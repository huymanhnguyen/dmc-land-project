<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTraCuu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlTraCuu))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSearch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DTPNgayCapCMT = New System.Windows.Forms.DateTimePicker
        Me.txtNoiCapCMT = New System.Windows.Forms.TextBox
        Me.txtSoCMT = New System.Windows.Forms.TextBox
        Me.LabSoDinhDanh = New System.Windows.Forms.Label
        Me.LabNoiCapDinhDanh = New System.Windows.Forms.Label
        Me.LabNgayCapDinhDanh = New System.Windows.Forms.Label
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdvw = New DMC.[Interface].GridView.ctrlGridView
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(524, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(57, 24)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "Tìm"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DTPNgayCapCMT)
        Me.GroupBox1.Controls.Add(Me.txtNoiCapCMT)
        Me.GroupBox1.Controls.Add(Me.txtSoCMT)
        Me.GroupBox1.Controls.Add(Me.LabSoDinhDanh)
        Me.GroupBox1.Controls.Add(Me.LabNoiCapDinhDanh)
        Me.GroupBox1.Controls.Add(Me.LabNgayCapDinhDanh)
        Me.GroupBox1.Controls.Add(Me.txtDiaChi)
        Me.GroupBox1.Controls.Add(Me.txtHoTen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 151)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Điều kiện tìm kiếm"
        '
        'DTPNgayCapCMT
        '
        Me.DTPNgayCapCMT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTPNgayCapCMT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPNgayCapCMT.Location = New System.Drawing.Point(111, 71)
        Me.DTPNgayCapCMT.Name = "DTPNgayCapCMT"
        Me.DTPNgayCapCMT.Size = New System.Drawing.Size(119, 20)
        Me.DTPNgayCapCMT.TabIndex = 126
        '
        'txtNoiCapCMT
        '
        Me.txtNoiCapCMT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoiCapCMT.Location = New System.Drawing.Point(111, 97)
        Me.txtNoiCapCMT.Name = "txtNoiCapCMT"
        Me.txtNoiCapCMT.Size = New System.Drawing.Size(326, 20)
        Me.txtNoiCapCMT.TabIndex = 127
        '
        'txtSoCMT
        '
        Me.txtSoCMT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoCMT.Location = New System.Drawing.Point(111, 45)
        Me.txtSoCMT.Name = "txtSoCMT"
        Me.txtSoCMT.Size = New System.Drawing.Size(162, 20)
        Me.txtSoCMT.TabIndex = 125
        '
        'LabSoDinhDanh
        '
        Me.LabSoDinhDanh.AutoSize = True
        Me.LabSoDinhDanh.Location = New System.Drawing.Point(3, 48)
        Me.LabSoDinhDanh.Name = "LabSoDinhDanh"
        Me.LabSoDinhDanh.Size = New System.Drawing.Size(67, 13)
        Me.LabSoDinhDanh.TabIndex = 130
        Me.LabSoDinhDanh.Text = "Số CMT(HC)"
        '
        'LabNoiCapDinhDanh
        '
        Me.LabNoiCapDinhDanh.AutoSize = True
        Me.LabNoiCapDinhDanh.Location = New System.Drawing.Point(2, 100)
        Me.LabNoiCapDinhDanh.Name = "LabNoiCapDinhDanh"
        Me.LabNoiCapDinhDanh.Size = New System.Drawing.Size(94, 13)
        Me.LabNoiCapDinhDanh.TabIndex = 129
        Me.LabNoiCapDinhDanh.Text = "Nơi cấp CMT (HC)"
        '
        'LabNgayCapDinhDanh
        '
        Me.LabNgayCapDinhDanh.AutoSize = True
        Me.LabNgayCapDinhDanh.Location = New System.Drawing.Point(2, 75)
        Me.LabNgayCapDinhDanh.Name = "LabNgayCapDinhDanh"
        Me.LabNgayCapDinhDanh.Size = New System.Drawing.Size(103, 13)
        Me.LabNgayCapDinhDanh.TabIndex = 128
        Me.LabNgayCapDinhDanh.Text = "Ngày cấp CMT (HC)"
        '
        'txtDiaChi
        '
        Me.txtDiaChi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiaChi.Location = New System.Drawing.Point(111, 123)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(375, 20)
        Me.txtDiaChi.TabIndex = 5
        '
        'txtHoTen
        '
        Me.txtHoTen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHoTen.Location = New System.Drawing.Point(111, 19)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(294, 20)
        Me.txtHoTen.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Địa chỉ:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên:"
        '
        'grdvw
        '
        Me.grdvw.AllowUserToAddRows = False
        Me.grdvw.AllowUserToDeleteRows = False
        Me.grdvw.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.grdvw.Location = New System.Drawing.Point(3, 160)
        Me.grdvw.Name = "grdvw"
        Me.grdvw.ReadOnly = True
        Me.grdvw.RowHeadersWidth = 25
        Me.grdvw.Size = New System.Drawing.Size(598, 125)
        Me.grdvw.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(524, 41)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(57, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Ghi"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ctrlTraCuu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grdvw)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "ctrlTraCuu"
        Me.Size = New System.Drawing.Size(604, 290)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdvw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents grdvw As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents DTPNgayCapCMT As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNoiCapCMT As System.Windows.Forms.TextBox
    Friend WithEvents txtSoCMT As System.Windows.Forms.TextBox
    Friend WithEvents LabSoDinhDanh As System.Windows.Forms.Label
    Friend WithEvents LabNoiCapDinhDanh As System.Windows.Forms.Label
    Friend WithEvents LabNgayCapDinhDanh As System.Windows.Forms.Label

End Class
