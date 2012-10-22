<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTongHopChuSuDung
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
        Me.radTongHop1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radTongHop3 = New System.Windows.Forms.RadioButton
        Me.radTongHop2 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grdTongHopChiTiet = New DMC.[Interface].GridView.ctrlGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdTongHopChiTiet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'radTongHop1
        '
        Me.radTongHop1.AutoSize = True
        Me.radTongHop1.Checked = True
        Me.radTongHop1.Location = New System.Drawing.Point(16, 19)
        Me.radTongHop1.Name = "radTongHop1"
        Me.radTongHop1.Size = New System.Drawing.Size(343, 17)
        Me.radTongHop1.TabIndex = 0
        Me.radTongHop1.TabStop = True
        Me.radTongHop1.Text = "Thông tin về người sử dụng đất, chủ sở hữu tài sản gắn liền với đất"
        Me.radTongHop1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radTongHop3)
        Me.GroupBox1.Controls.Add(Me.radTongHop2)
        Me.GroupBox1.Controls.Add(Me.radTongHop1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 99)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trường hợp sử dụng đất và sở hữu tài sản"
        '
        'radTongHop3
        '
        Me.radTongHop3.AutoSize = True
        Me.radTongHop3.Location = New System.Drawing.Point(16, 65)
        Me.radTongHop3.Name = "radTongHop3"
        Me.radTongHop3.Size = New System.Drawing.Size(518, 17)
        Me.radTongHop3.TabIndex = 2
        Me.radTongHop3.Text = "Thửa đất có nhiều tổ chức, hộ gia đình, cá nhân cùng sử dụng đất, cùng sở hữu tài" & _
            " sản gắn liền với đất"
        Me.radTongHop3.UseVisualStyleBackColor = True
        '
        'radTongHop2
        '
        Me.radTongHop2.AutoSize = True
        Me.radTongHop2.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.radTongHop2.Location = New System.Drawing.Point(16, 42)
        Me.radTongHop2.Name = "radTongHop2"
        Me.radTongHop2.Size = New System.Drawing.Size(371, 17)
        Me.radTongHop2.TabIndex = 1
        Me.radTongHop2.Text = "Người sử dụng đất không đồng thời là chủ sở hữu tài sản gắn liền với đất"
        Me.radTongHop2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdTongHopChiTiet)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(713, 224)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin chi tiết"
        '
        'grdTongHopChiTiet
        '
        Me.grdTongHopChiTiet.AllowUserToAddRows = False
        Me.grdTongHopChiTiet.AllowUserToDeleteRows = False
        Me.grdTongHopChiTiet.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTongHopChiTiet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTongHopChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTongHopChiTiet.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdTongHopChiTiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTongHopChiTiet.Location = New System.Drawing.Point(3, 16)
        Me.grdTongHopChiTiet.Name = "grdTongHopChiTiet"
        Me.grdTongHopChiTiet.ReadOnly = True
        Me.grdTongHopChiTiet.RowHeadersWidth = 25
        Me.grdTongHopChiTiet.Size = New System.Drawing.Size(707, 205)
        Me.grdTongHopChiTiet.TabIndex = 4
        '
        'frmTongHopChuSuDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(736, 368)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTongHopChuSuDung"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tong hop chu su dung"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdTongHopChiTiet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents radTongHop1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radTongHop3 As System.Windows.Forms.RadioButton
    Friend WithEvents radTongHop2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdTongHopChiTiet As DMC.Interface.GridView.ctrlGridView
End Class
