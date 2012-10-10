<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrInToTrinh
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdChonIn = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdInQuyetDinh = New System.Windows.Forms.Button
        Me.cmdInHoSo = New System.Windows.Forms.Button
        Me.saveFile = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdTimHoSo = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpNgayTrinhDiaChinh = New System.Windows.Forms.DateTimePicker
        Me.txtToTrinhSo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox3.Location = New System.Drawing.Point(6, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(790, 181)
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdChonIn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdChonIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdChonIn.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdChonIn.Location = New System.Drawing.Point(21, 16)
        Me.grdChonIn.Name = "grdChonIn"
        Me.grdChonIn.ReadOnly = True
        Me.grdChonIn.RowHeadersWidth = 25
        Me.grdChonIn.Size = New System.Drawing.Size(752, 162)
        Me.grdChonIn.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdInQuyetDinh)
        Me.GroupBox1.Controls.Add(Me.cmdInHoSo)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 253)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 37)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cmdInQuyetDinh
        '
        Me.cmdInQuyetDinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInQuyetDinh.Location = New System.Drawing.Point(689, 10)
        Me.cmdInQuyetDinh.Name = "cmdInQuyetDinh"
        Me.cmdInQuyetDinh.Size = New System.Drawing.Size(89, 22)
        Me.cmdInQuyetDinh.TabIndex = 6
        Me.cmdInQuyetDinh.Text = "In quyết định"
        Me.cmdInQuyetDinh.UseVisualStyleBackColor = True
        '
        'cmdInHoSo
        '
        Me.cmdInHoSo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInHoSo.Location = New System.Drawing.Point(594, 10)
        Me.cmdInHoSo.Name = "cmdInHoSo"
        Me.cmdInHoSo.Size = New System.Drawing.Size(89, 22)
        Me.cmdInHoSo.TabIndex = 5
        Me.cmdInHoSo.Text = "In phiếu hồ sơ"
        Me.cmdInHoSo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cmdTimHoSo)
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
        'cmdTimHoSo
        '
        Me.cmdTimHoSo.Location = New System.Drawing.Point(476, 18)
        Me.cmdTimHoSo.Name = "cmdTimHoSo"
        Me.cmdTimHoSo.Size = New System.Drawing.Size(115, 23)
        Me.cmdTimHoSo.TabIndex = 3
        Me.cmdTimHoSo.Text = "Tìm kiếm hồ sơ"
        Me.cmdTimHoSo.UseVisualStyleBackColor = True
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
        'ctrInToTrinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ctrInToTrinh"
        Me.Size = New System.Drawing.Size(800, 299)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdChonIn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdChonIn As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdInHoSo As System.Windows.Forms.Button
    Friend WithEvents saveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdInQuyetDinh As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtToTrinhSo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayTrinhDiaChinh As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdTimHoSo As System.Windows.Forms.Button

End Class
