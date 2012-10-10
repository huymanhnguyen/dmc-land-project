<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimToTrinh
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpNgayLapTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.txtToTrinhSo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdToTrinh = New DMC.[Interface].GridView.ctrlGridView
        Me.cmdGhi = New System.Windows.Forms.Button
        Me.cmdXoa = New System.Windows.Forms.Button
        Me.cmdSua = New System.Windows.Forms.Button
        Me.cmdThem = New System.Windows.Forms.Button
        Me.txtDonViLapToTrinh = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpNgayTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdToTrinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(456, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ngày lập tờ trình"
        '
        'dtpNgayLapTrinhDiaChinh
        '
        Me.dtpNgayLapTrinhDiaChinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayLapTrinhDiaChinh.Location = New System.Drawing.Point(546, 12)
        Me.dtpNgayLapTrinhDiaChinh.Name = "dtpNgayLapTrinhDiaChinh"
        Me.dtpNgayLapTrinhDiaChinh.Size = New System.Drawing.Size(139, 20)
        Me.dtpNgayLapTrinhDiaChinh.TabIndex = 6
        '
        'txtToTrinhSo
        '
        Me.txtToTrinhSo.Location = New System.Drawing.Point(77, 12)
        Me.txtToTrinhSo.Name = "txtToTrinhSo"
        Me.txtToTrinhSo.Size = New System.Drawing.Size(123, 20)
        Me.txtToTrinhSo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tờ trình số:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grdToTrinh)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 100)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(683, 394)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách tờ trình"
        '
        'grdToTrinh
        '
        Me.grdToTrinh.AllowUserToAddRows = False
        Me.grdToTrinh.AllowUserToDeleteRows = False
        Me.grdToTrinh.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdToTrinh.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdToTrinh.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdToTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdToTrinh.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdToTrinh.Location = New System.Drawing.Point(11, 15)
        Me.grdToTrinh.Name = "grdToTrinh"
        Me.grdToTrinh.ReadOnly = True
        Me.grdToTrinh.RowHeadersWidth = 25
        Me.grdToTrinh.Size = New System.Drawing.Size(660, 375)
        Me.grdToTrinh.TabIndex = 0
        '
        'cmdGhi
        '
        Me.cmdGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGhi.Location = New System.Drawing.Point(427, 72)
        Me.cmdGhi.Name = "cmdGhi"
        Me.cmdGhi.Size = New System.Drawing.Size(60, 22)
        Me.cmdGhi.TabIndex = 16
        Me.cmdGhi.Text = "Ghi"
        Me.cmdGhi.UseVisualStyleBackColor = True
        '
        'cmdXoa
        '
        Me.cmdXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdXoa.Location = New System.Drawing.Point(625, 72)
        Me.cmdXoa.Name = "cmdXoa"
        Me.cmdXoa.Size = New System.Drawing.Size(60, 22)
        Me.cmdXoa.TabIndex = 15
        Me.cmdXoa.Text = "Xoá"
        Me.cmdXoa.UseVisualStyleBackColor = True
        '
        'cmdSua
        '
        Me.cmdSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSua.Location = New System.Drawing.Point(559, 72)
        Me.cmdSua.Name = "cmdSua"
        Me.cmdSua.Size = New System.Drawing.Size(60, 22)
        Me.cmdSua.TabIndex = 14
        Me.cmdSua.Text = "Sửa"
        Me.cmdSua.UseVisualStyleBackColor = True
        '
        'cmdThem
        '
        Me.cmdThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdThem.Location = New System.Drawing.Point(493, 72)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(60, 22)
        Me.cmdThem.TabIndex = 13
        Me.cmdThem.Text = "Thêm"
        Me.cmdThem.UseVisualStyleBackColor = True
        '
        'txtDonViLapToTrinh
        '
        Me.txtDonViLapToTrinh.Location = New System.Drawing.Point(77, 42)
        Me.txtDonViLapToTrinh.Name = "txtDonViLapToTrinh"
        Me.txtDonViLapToTrinh.Size = New System.Drawing.Size(368, 20)
        Me.txtDonViLapToTrinh.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Đơn vị lập"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(485, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Ngày trình"
        '
        'dtpNgayTrinhDiaChinh
        '
        Me.dtpNgayTrinhDiaChinh.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayTrinhDiaChinh.Location = New System.Drawing.Point(546, 39)
        Me.dtpNgayTrinhDiaChinh.Name = "dtpNgayTrinhDiaChinh"
        Me.dtpNgayTrinhDiaChinh.Size = New System.Drawing.Size(139, 20)
        Me.dtpNgayTrinhDiaChinh.TabIndex = 17
        '
        'frmTimToTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 506)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpNgayTrinhDiaChinh)
        Me.Controls.Add(Me.cmdGhi)
        Me.Controls.Add(Me.cmdXoa)
        Me.Controls.Add(Me.cmdSua)
        Me.Controls.Add(Me.cmdThem)
        Me.Controls.Add(Me.txtDonViLapToTrinh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpNgayLapTrinhDiaChinh)
        Me.Controls.Add(Me.txtToTrinhSo)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimToTrinh"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIM TO TRINH PHUONG"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdToTrinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayLapTrinhDiaChinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtToTrinhSo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdToTrinh As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents cmdGhi As System.Windows.Forms.Button
    Friend WithEvents cmdXoa As System.Windows.Forms.Button
    Friend WithEvents cmdSua As System.Windows.Forms.Button
    Friend WithEvents cmdThem As System.Windows.Forms.Button
    Friend WithEvents txtDonViLapToTrinh As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayTrinhDiaChinh As System.Windows.Forms.DateTimePicker
End Class
