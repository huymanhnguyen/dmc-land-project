<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDanhSachChuSuDungDat
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
        Me.grdvwDanhSachChuDangKyCapGCN = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdvwDanhSachChuDangKyCapGCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdvwDanhSachChuDangKyCapGCN)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(751, 156)
        Me.GroupBox2.TabIndex = 108
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Danh sách Chủ (sử dụng, sở hữu) đăng ký cấp GCN"
        '
        'grdvwDanhSachChuDangKyCapGCN
        '
        Me.grdvwDanhSachChuDangKyCapGCN.AllowUserToAddRows = False
        Me.grdvwDanhSachChuDangKyCapGCN.AllowUserToDeleteRows = False
        Me.grdvwDanhSachChuDangKyCapGCN.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdvwDanhSachChuDangKyCapGCN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdvwDanhSachChuDangKyCapGCN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdvwDanhSachChuDangKyCapGCN.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdvwDanhSachChuDangKyCapGCN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdvwDanhSachChuDangKyCapGCN.Location = New System.Drawing.Point(3, 17)
        Me.grdvwDanhSachChuDangKyCapGCN.Name = "grdvwDanhSachChuDangKyCapGCN"
        Me.grdvwDanhSachChuDangKyCapGCN.ReadOnly = True
        Me.grdvwDanhSachChuDangKyCapGCN.RowHeadersWidth = 25
        Me.grdvwDanhSachChuDangKyCapGCN.Size = New System.Drawing.Size(745, 136)
        Me.grdvwDanhSachChuDangKyCapGCN.TabIndex = 0
        '
        'ctrlDanhSachChuSuDungDat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ctrlDanhSachChuSuDungDat"
        Me.Size = New System.Drawing.Size(756, 164)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdvwDanhSachChuDangKyCapGCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdvwDanhSachChuDangKyCapGCN As DMC.Interface.GridView.ctrlGridView

End Class
