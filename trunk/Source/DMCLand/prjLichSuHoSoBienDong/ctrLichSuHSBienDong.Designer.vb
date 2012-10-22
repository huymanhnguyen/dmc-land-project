<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrLichSuHSBienDong
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.RTNoiDungBienDong = New System.Windows.Forms.RichTextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.grdDanhSachBienDong = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDanhSachBienDong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(816, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LỊCH SỬ BIẾN ĐỘNG CỦA THỬA ĐẤT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RTNoiDungBienDong
        '
        Me.RTNoiDungBienDong.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTNoiDungBienDong.Location = New System.Drawing.Point(5, 226)
        Me.RTNoiDungBienDong.Name = "RTNoiDungBienDong"
        Me.RTNoiDungBienDong.ReadOnly = True
        Me.RTNoiDungBienDong.Size = New System.Drawing.Size(805, 239)
        Me.RTNoiDungBienDong.TabIndex = 1
        Me.RTNoiDungBienDong.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdThoat)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 463)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(805, 42)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdThoat
        '
        Me.cmdThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdThoat.Location = New System.Drawing.Point(744, 12)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(55, 23)
        Me.cmdThoat.TabIndex = 2
        Me.cmdThoat.Text = "Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'grdDanhSachBienDong
        '
        Me.grdDanhSachBienDong.AllowUserToAddRows = False
        Me.grdDanhSachBienDong.AllowUserToDeleteRows = False
        Me.grdDanhSachBienDong.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDanhSachBienDong.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDanhSachBienDong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdDanhSachBienDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDanhSachBienDong.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdDanhSachBienDong.Location = New System.Drawing.Point(3, 23)
        Me.grdDanhSachBienDong.Name = "grdDanhSachBienDong"
        Me.grdDanhSachBienDong.ReadOnly = True
        Me.grdDanhSachBienDong.RowHeadersWidth = 25
        Me.grdDanhSachBienDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDanhSachBienDong.Size = New System.Drawing.Size(810, 199)
        Me.grdDanhSachBienDong.TabIndex = 0
        '
        'ctrLichSuHSBienDong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grdDanhSachBienDong)
        Me.Controls.Add(Me.RTNoiDungBienDong)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ctrLichSuHSBienDong"
        Me.Size = New System.Drawing.Size(816, 505)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdDanhSachBienDong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDanhSachBienDong As DMC.Interface.GridView.ctrlGridView
    Friend WithEvents RTNoiDungBienDong As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdThoat As System.Windows.Forms.Button

End Class
