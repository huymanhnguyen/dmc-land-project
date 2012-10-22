<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongTinRungCay
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
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNguonGocTaoLap = New System.Windows.Forms.TextBox
        Me.numDienTichCoRung = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSoHoSoGiaoRung = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.numDienTichCoRung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(664, 105)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 5
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(68, 105)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 4
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(5, 105)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(58, 21)
        Me.btnCapNhat.TabIndex = 3
        Me.btnCapNhat.Text = "Cập nhật"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtNguonGocTaoLap)
        Me.GroupBox1.Controls.Add(Me.numDienTichCoRung)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSoHoSoGiaoRung)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(717, 98)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'txtNguonGocTaoLap
        '
        Me.txtNguonGocTaoLap.Location = New System.Drawing.Point(115, 42)
        Me.txtNguonGocTaoLap.Name = "txtNguonGocTaoLap"
        Me.txtNguonGocTaoLap.Size = New System.Drawing.Size(596, 20)
        Me.txtNguonGocTaoLap.TabIndex = 1
        '
        'numDienTichCoRung
        '
        Me.numDienTichCoRung.DecimalPlaces = 1
        Me.numDienTichCoRung.Location = New System.Drawing.Point(115, 11)
        Me.numDienTichCoRung.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numDienTichCoRung.Name = "numDienTichCoRung"
        Me.numDienTichCoRung.Size = New System.Drawing.Size(110, 20)
        Me.numDienTichCoRung.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Nguồn gốc tạo lập"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Lavender
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(231, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "(m2)"
        '
        'txtSoHoSoGiaoRung
        '
        Me.txtSoHoSoGiaoRung.Location = New System.Drawing.Point(115, 72)
        Me.txtSoHoSoGiaoRung.Name = "txtSoHoSoGiaoRung"
        Me.txtSoHoSoGiaoRung.Size = New System.Drawing.Size(598, 20)
        Me.txtSoHoSoGiaoRung.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Số hồ sơ giao rừng"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Diện tích"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmThongTinRungCay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(734, 128)
        Me.Controls.Add(Me.btnTroGiup)
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnCapNhat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmThongTinRungCay"
        Me.Text = "Thong tin Rung cay"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numDienTichCoRung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNguonGocTaoLap As System.Windows.Forms.TextBox
    Friend WithEvents numDienTichCoRung As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSoHoSoGiaoRung As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
