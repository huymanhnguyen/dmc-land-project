<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrTongHopDatInBienBanXetDuyet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrTongHopDatInBienBanXetDuyet))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.richGiayToKhac = New System.Windows.Forms.RichTextBox
        Me.richKhongTheoGiayTo = New System.Windows.Forms.RichTextBox
        Me.richTheoGiayTo = New System.Windows.Forms.RichTextBox
        Me.btnThem = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnCapNhat = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.richDeNghiCapTaiSan = New System.Windows.Forms.RichTextBox
        Me.richDeNghiCapDat = New System.Windows.Forms.RichTextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.richGiayToKhac)
        Me.GroupBox1.Controls.Add(Me.richKhongTheoGiayTo)
        Me.GroupBox1.Controls.Add(Me.richTheoGiayTo)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 312)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nội dung về đất"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Thông tin theo giấy tờ khác"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Thông tin không theo giấy tờ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Thông tin theo giấy tờ"
        '
        'richGiayToKhac
        '
        Me.richGiayToKhac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richGiayToKhac.Location = New System.Drawing.Point(6, 249)
        Me.richGiayToKhac.Name = "richGiayToKhac"
        Me.richGiayToKhac.Size = New System.Drawing.Size(423, 57)
        Me.richGiayToKhac.TabIndex = 2
        Me.richGiayToKhac.Text = "…………m2 (theo giấy tờ khác)…………………………"
        '
        'richKhongTheoGiayTo
        '
        Me.richKhongTheoGiayTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richKhongTheoGiayTo.Location = New System.Drawing.Point(6, 126)
        Me.richKhongTheoGiayTo.Name = "richKhongTheoGiayTo"
        Me.richKhongTheoGiayTo.Size = New System.Drawing.Size(423, 104)
        Me.richKhongTheoGiayTo.TabIndex = 1
        Me.richKhongTheoGiayTo.Text = resources.GetString("richKhongTheoGiayTo.Text")
        '
        'richTheoGiayTo
        '
        Me.richTheoGiayTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richTheoGiayTo.Location = New System.Drawing.Point(4, 34)
        Me.richTheoGiayTo.Name = "richTheoGiayTo"
        Me.richTheoGiayTo.Size = New System.Drawing.Size(423, 73)
        Me.richTheoGiayTo.TabIndex = 0
        Me.richTheoGiayTo.Text = "........... m2 theo tờ giấy (quy định tại khoản 1,2 và 5 Điều 50 Luật đất đai);……" & _
            "………………       Ranh giới theo các mốc từ: ...................................  Tại" & _
            " sơ đồ thửa đất."
        '
        'btnThem
        '
        Me.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnThem.Location = New System.Drawing.Point(257, 14)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(64, 24)
        Me.btnThem.TabIndex = 7
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnXoa.Enabled = False
        Me.btnXoa.Location = New System.Drawing.Point(389, 14)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(64, 24)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnHuyLenh.Location = New System.Drawing.Point(522, 14)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(64, 24)
        Me.btnHuyLenh.TabIndex = 11
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSua.Location = New System.Drawing.Point(323, 14)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(64, 24)
        Me.btnSua.TabIndex = 8
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCapNhat.Location = New System.Drawing.Point(455, 14)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(64, 24)
        Me.btnCapNhat.TabIndex = 10
        Me.btnCapNhat.Text = "Ghi"
        Me.btnCapNhat.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.richDeNghiCapTaiSan)
        Me.GroupBox2.Controls.Add(Me.richDeNghiCapDat)
        Me.GroupBox2.Location = New System.Drawing.Point(456, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 310)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Đề nghị cấp"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Thông tin đất"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tài sản"
        '
        'richDeNghiCapTaiSan
        '
        Me.richDeNghiCapTaiSan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richDeNghiCapTaiSan.Location = New System.Drawing.Point(6, 200)
        Me.richDeNghiCapTaiSan.Name = "richDeNghiCapTaiSan"
        Me.richDeNghiCapTaiSan.Size = New System.Drawing.Size(372, 104)
        Me.richDeNghiCapTaiSan.TabIndex = 6
        Me.richDeNghiCapTaiSan.Text = "Tài sản gắn liền với đất:………………."
        '
        'richDeNghiCapDat
        '
        Me.richDeNghiCapDat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richDeNghiCapDat.Location = New System.Drawing.Point(6, 32)
        Me.richDeNghiCapDat.Name = "richDeNghiCapDat"
        Me.richDeNghiCapDat.Size = New System.Drawing.Size(378, 149)
        Me.richDeNghiCapDat.TabIndex = 5
        Me.richDeNghiCapDat.Text = resources.GetString("richDeNghiCapDat.Text")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnThem)
        Me.GroupBox3.Controls.Add(Me.btnXoa)
        Me.GroupBox3.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox3.Controls.Add(Me.btnSua)
        Me.GroupBox3.Controls.Add(Me.btnCapNhat)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 323)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(831, 51)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        '
        'ctrTongHopDatInBienBanXetDuyet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrTongHopDatInBienBanXetDuyet"
        Me.Size = New System.Drawing.Size(862, 377)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents richGiayToKhac As System.Windows.Forms.RichTextBox
    Friend WithEvents richKhongTheoGiayTo As System.Windows.Forms.RichTextBox
    Friend WithEvents richTheoGiayTo As System.Windows.Forms.RichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnCapNhat As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents richDeNghiCapTaiSan As System.Windows.Forms.RichTextBox
    Friend WithEvents richDeNghiCapDat As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
