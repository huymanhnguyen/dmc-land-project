﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlThongTinCayLauNamDeNghiCapGCN
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdvwDanhSachCayLauNamDangKyCapGCN = New DMC.[Interface].GridView.ctrlGridView
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.txtThongTinCayLauNamDeNghiCapGCN = New System.Windows.Forms.RichTextBox
        Me.btnTroGiup = New System.Windows.Forms.Button
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdvwDanhSachCayLauNamDangKyCapGCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdvwDanhSachCayLauNamDangKyCapGCN)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(757, 158)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Danh sách Thông tin CÂY LÂU NĂM đăng ký cấp GCN"
        '
        'grdvwDanhSachCayLauNamDangKyCapGCN
        '
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.AllowUserToAddRows = False
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.AllowUserToDeleteRows = False
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.Location = New System.Drawing.Point(3, 18)
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.Name = "grdvwDanhSachCayLauNamDangKyCapGCN"
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.ReadOnly = True
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.RowHeadersWidth = 25
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.Size = New System.Drawing.Size(751, 137)
        Me.grdvwDanhSachCayLauNamDangKyCapGCN.TabIndex = 0
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(64, 12)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 3
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(3, 12)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 2
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(125, 12)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 4
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'txtThongTinCayLauNamDeNghiCapGCN
        '
        Me.txtThongTinCayLauNamDeNghiCapGCN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtThongTinCayLauNamDeNghiCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtThongTinCayLauNamDeNghiCapGCN.Location = New System.Drawing.Point(3, 18)
        Me.txtThongTinCayLauNamDeNghiCapGCN.Name = "txtThongTinCayLauNamDeNghiCapGCN"
        Me.txtThongTinCayLauNamDeNghiCapGCN.Size = New System.Drawing.Size(753, 249)
        Me.txtThongTinCayLauNamDeNghiCapGCN.TabIndex = 1
        Me.txtThongTinCayLauNamDeNghiCapGCN.Text = ""
        '
        'btnTroGiup
        '
        Me.btnTroGiup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTroGiup.Location = New System.Drawing.Point(694, 12)
        Me.btnTroGiup.Name = "btnTroGiup"
        Me.btnTroGiup.Size = New System.Drawing.Size(58, 21)
        Me.btnTroGiup.TabIndex = 6
        Me.btnTroGiup.Text = "Trợ giúp"
        Me.btnTroGiup.UseVisualStyleBackColor = True
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(186, 12)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 5
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtThongTinCayLauNamDeNghiCapGCN)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 270)
        Me.GroupBox1.TabIndex = 120
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nội dung thông tin Cây lâu năm đề nghị ghi tại Điểm 5, Mục II, Trang 2 của GCN"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnXoa)
        Me.GroupBox3.Controls.Add(Me.btnSua)
        Me.GroupBox3.Controls.Add(Me.btnGhi)
        Me.GroupBox3.Controls.Add(Me.btnTroGiup)
        Me.GroupBox3.Controls.Add(Me.btnHuyLenh)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 434)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(758, 39)
        Me.GroupBox3.TabIndex = 123
        Me.GroupBox3.TabStop = False
        '
        'ctrlThongTinCayLauNamDeNghiCapGCN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ctrlThongTinCayLauNamDeNghiCapGCN"
        Me.Size = New System.Drawing.Size(763, 478)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdvwDanhSachCayLauNamDangKyCapGCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwDanhSachCayLauNamDangKyCapGCN As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Public WithEvents txtThongTinCayLauNamDeNghiCapGCN As System.Windows.Forms.RichTextBox
    Friend WithEvents btnTroGiup As System.Windows.Forms.Button
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class
