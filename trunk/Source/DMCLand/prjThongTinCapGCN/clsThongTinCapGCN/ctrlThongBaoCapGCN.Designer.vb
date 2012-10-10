<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongBaoCapGCN
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
        Me.dtpNgayCongDanNhanThongBao = New System.Windows.Forms.DateTimePicker
        Me.btnInThongBao = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.dtpNgayThongBaoUBND = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpNgayCongDanNhanThongBao
        '
        Me.dtpNgayCongDanNhanThongBao.Location = New System.Drawing.Point(430, 20)
        Me.dtpNgayCongDanNhanThongBao.Name = "dtpNgayCongDanNhanThongBao"
        Me.dtpNgayCongDanNhanThongBao.Size = New System.Drawing.Size(136, 20)
        Me.dtpNgayCongDanNhanThongBao.TabIndex = 1
        '
        'btnInThongBao
        '
        Me.btnInThongBao.Location = New System.Drawing.Point(196, 12)
        Me.btnInThongBao.Name = "btnInThongBao"
        Me.btnInThongBao.Size = New System.Drawing.Size(76, 21)
        Me.btnInThongBao.TabIndex = 5
        Me.btnInThongBao.Text = "In thông báo"
        Me.btnInThongBao.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(294, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(130, 29)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Ngày công dân đến nhận thông báo cấp GCN"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpNgayThongBaoUBND
        '
        Me.dtpNgayThongBaoUBND.Location = New System.Drawing.Point(130, 20)
        Me.dtpNgayThongBaoUBND.Name = "dtpNgayThongBaoUBND"
        Me.dtpNgayThongBaoUBND.Size = New System.Drawing.Size(136, 20)
        Me.dtpNgayThongBaoUBND.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 29)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Ngày thông báo quyết định của UBND"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.dtpNgayCongDanNhanThongBao)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dtpNgayThongBaoUBND)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 49)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông báo cấp GCN"
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(6, 12)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(68, 12)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 3
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(132, 12)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 4
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnSua)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Controls.Add(Me.btnInThongBao)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(575, 39)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'ctrlThongBaoCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongBaoCapGCN"
        Me.Size = New System.Drawing.Size(582, 106)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpNgayCongDanNhanThongBao As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnInThongBao As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpNgayThongBaoUBND As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
