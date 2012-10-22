<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinSoDoNhaDat
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
        Me.btnMoTep = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnGhiLenDia = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.picSoDoNhaDat = New System.Windows.Forms.PictureBox
        Me.btnXoa = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.HScroll1 = New System.Windows.Forms.HScrollBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkHienThiAnhThua = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picSoDoNhaDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMoTep
        '
        Me.btnMoTep.Location = New System.Drawing.Point(3, 10)
        Me.btnMoTep.Name = "btnMoTep"
        Me.btnMoTep.Size = New System.Drawing.Size(69, 22)
        Me.btnMoTep.TabIndex = 1
        Me.btnMoTep.Text = "Mở tệp"
        Me.btnMoTep.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(75, 10)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(69, 22)
        Me.btnGhi.TabIndex = 2
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnGhiLenDia
        '
        Me.btnGhiLenDia.Location = New System.Drawing.Point(223, 10)
        Me.btnGhiLenDia.Name = "btnGhiLenDia"
        Me.btnGhiLenDia.Size = New System.Drawing.Size(69, 22)
        Me.btnGhiLenDia.TabIndex = 4
        Me.btnGhiLenDia.Text = "Ghi lên đĩa"
        Me.btnGhiLenDia.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(296, 10)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(69, 22)
        Me.btnHuyLenh.TabIndex = 5
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(653, 10)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(69, 22)
        Me.btnTroGiup.TabIndex = 6
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 408)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sơ đồ NHÀ, ĐẤT"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.picSoDoNhaDat)
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 384)
        Me.Panel1.TabIndex = 0
        '
        'picSoDoNhaDat
        '
        Me.picSoDoNhaDat.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picSoDoNhaDat.BackColor = System.Drawing.Color.White
        Me.picSoDoNhaDat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picSoDoNhaDat.Location = New System.Drawing.Point(130, 19)
        Me.picSoDoNhaDat.Name = "picSoDoNhaDat"
        Me.picSoDoNhaDat.Size = New System.Drawing.Size(454, 341)
        Me.picSoDoNhaDat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSoDoNhaDat.TabIndex = 1
        Me.picSoDoNhaDat.TabStop = False
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(148, 10)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(69, 22)
        Me.btnXoa.TabIndex = 3
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnTroGiup)
        Me.GroupBox2.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox2.Controls.Add(Me.btnGhiLenDia)
        Me.GroupBox2.Controls.Add(Me.btnGhi)
        Me.GroupBox2.Controls.Add(Me.btnMoTep)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 469)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(728, 38)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'HScroll1
        '
        Me.HScroll1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScroll1.Location = New System.Drawing.Point(6, 414)
        Me.HScroll1.Name = "HScroll1"
        Me.HScroll1.Size = New System.Drawing.Size(712, 22)
        Me.HScroll1.TabIndex = 7
        Me.HScroll1.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(689, 448)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "100%"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(337, 418)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "(Ảnh tiêu chuẩn 12cm x 16cm hoặc 340.2 pixel x 453.6 pixel)"
        '
        'chkHienThiAnhThua
        '
        Me.chkHienThiAnhThua.AutoSize = True
        Me.chkHienThiAnhThua.Location = New System.Drawing.Point(6, 417)
        Me.chkHienThiAnhThua.Name = "chkHienThiAnhThua"
        Me.chkHienThiAnhThua.Size = New System.Drawing.Size(198, 17)
        Me.chkHienThiAnhThua.TabIndex = 0
        Me.chkHienThiAnhThua.Text = "Hiển thị ảnh thửa đất lên mặt 3 GCN"
        Me.chkHienThiAnhThua.UseVisualStyleBackColor = True
        '
        'ctrlThongTinSoDoNhaDat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.chkHienThiAnhThua)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HScroll1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinSoDoNhaDat"
        Me.Size = New System.Drawing.Size(734, 510)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picSoDoNhaDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMoTep As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnGhiLenDia As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents picSoDoNhaDat As System.Windows.Forms.PictureBox
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents HScroll1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkHienThiAnhThua As System.Windows.Forms.CheckBox

End Class
