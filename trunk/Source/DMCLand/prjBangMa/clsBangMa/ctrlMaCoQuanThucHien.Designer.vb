<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlMaCoQuanThucHien
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grdvwBangMaCoQuanThucHien = New DMC.[Interface].GridView.ctrlGridView
        Me.txtBangMaKyHieu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnHuyLenh = New System.Windows.Forms.Button
        Me.btnSua = New System.Windows.Forms.Button
        Me.btnGhi = New System.Windows.Forms.Button
        Me.btnXoa = New System.Windows.Forms.Button
        Me.btnThem = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBangMaMoTa = New System.Windows.Forms.TextBox
        CType(Me.grdvwBangMaCoQuanThucHien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdvwBangMaCoQuanThucHien
        '
        Me.grdvwBangMaCoQuanThucHien.AllowUserToAddRows = False
        Me.grdvwBangMaCoQuanThucHien.AllowUserToDeleteRows = False
        Me.grdvwBangMaCoQuanThucHien.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwBangMaCoQuanThucHien.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdvwBangMaCoQuanThucHien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwBangMaCoQuanThucHien.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdvwBangMaCoQuanThucHien.Location = New System.Drawing.Point(0, 0)
        Me.grdvwBangMaCoQuanThucHien.MultiSelect = False
        Me.grdvwBangMaCoQuanThucHien.Name = "grdvwBangMaCoQuanThucHien"
        Me.grdvwBangMaCoQuanThucHien.ReadOnly = True
        Me.grdvwBangMaCoQuanThucHien.RowHeadersVisible = False
        Me.grdvwBangMaCoQuanThucHien.RowHeadersWidth = 25
        Me.grdvwBangMaCoQuanThucHien.Size = New System.Drawing.Size(574, 165)
        Me.grdvwBangMaCoQuanThucHien.TabIndex = 41
        '
        'txtBangMaKyHieu
        '
        Me.txtBangMaKyHieu.Location = New System.Drawing.Point(0, 184)
        Me.txtBangMaKyHieu.Multiline = True
        Me.txtBangMaKyHieu.Name = "txtBangMaKyHieu"
        Me.txtBangMaKyHieu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBangMaKyHieu.Size = New System.Drawing.Size(574, 39)
        Me.txtBangMaKyHieu.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Ký Hiệu : "
        '
        'btnHuyLenh
        '
        Me.btnHuyLenh.Location = New System.Drawing.Point(246, 296)
        Me.btnHuyLenh.Name = "btnHuyLenh"
        Me.btnHuyLenh.Size = New System.Drawing.Size(58, 21)
        Me.btnHuyLenh.TabIndex = 55
        Me.btnHuyLenh.Text = "Hủy lệnh"
        Me.btnHuyLenh.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(66, 296)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(58, 21)
        Me.btnSua.TabIndex = 52
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnGhi
        '
        Me.btnGhi.Location = New System.Drawing.Point(184, 296)
        Me.btnGhi.Name = "btnGhi"
        Me.btnGhi.Size = New System.Drawing.Size(58, 21)
        Me.btnGhi.TabIndex = 54
        Me.btnGhi.Text = "Ghi"
        Me.btnGhi.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(126, 296)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(58, 21)
        Me.btnXoa.TabIndex = 53
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(6, 296)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(58, 21)
        Me.btnThem.TabIndex = 51
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Mô tả : "
        '
        'txtBangMaMoTa
        '
        Me.txtBangMaMoTa.Location = New System.Drawing.Point(0, 242)
        Me.txtBangMaMoTa.Multiline = True
        Me.txtBangMaMoTa.Name = "txtBangMaMoTa"
        Me.txtBangMaMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBangMaMoTa.Size = New System.Drawing.Size(574, 48)
        Me.txtBangMaMoTa.TabIndex = 43
        '
        'ctrlMaCoQuanThucHien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.btnHuyLenh)
        Me.Controls.Add(Me.btnSua)
        Me.Controls.Add(Me.btnGhi)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBangMaMoTa)
        Me.Controls.Add(Me.txtBangMaKyHieu)
        Me.Controls.Add(Me.grdvwBangMaCoQuanThucHien)
        Me.Name = "ctrlMaCoQuanThucHien"
        Me.Size = New System.Drawing.Size(574, 317)
        CType(Me.grdvwBangMaCoQuanThucHien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdvwBangMaCoQuanThucHien As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents txtBangMaKyHieu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHuyLenh As System.Windows.Forms.Button
    Friend WithEvents btnSua As System.Windows.Forms.Button
    Friend WithEvents btnGhi As System.Windows.Forms.Button
    Friend WithEvents btnXoa As System.Windows.Forms.Button
    Friend WithEvents btnThem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBangMaMoTa As System.Windows.Forms.TextBox

End Class
