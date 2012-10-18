<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBanDoTongThe
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
        Me.CtrlTachThua = New TachThua.ctrlTachThua
        Me.SuspendLayout()
        '
        'CtrlTachThua
        '
        Me.CtrlTachThua.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlTachThua.BackColor = System.Drawing.Color.Lavender
        Me.CtrlTachThua.Connection = ""
        Me.CtrlTachThua.DiaChiDat = ""
        Me.CtrlTachThua.DienTich = ""
        Me.CtrlTachThua.Location = New System.Drawing.Point(1, -1)
        Me.CtrlTachThua.MaDonViHanhChinh = ""
        Me.CtrlTachThua.MaHoSoCapGCN = ""
        Me.CtrlTachThua.MapShowed = False
        Me.CtrlTachThua.MaThuaDat = "0"
        Me.CtrlTachThua.Name = "CtrlTachThua"
        Me.CtrlTachThua.Size = New System.Drawing.Size(634, 514)
        Me.CtrlTachThua.SoThua = ""
        Me.CtrlTachThua.TabIndex = 0
        Me.CtrlTachThua.TenBangDat = ""
        Me.CtrlTachThua.ToBanDo = ""
        '
        'frmBanDoTongThe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 516)
        Me.Controls.Add(Me.CtrlTachThua)
        Me.Name = "frmBanDoTongThe"
        Me.Text = "Ban do"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CtrlTachThua As TachThua.ctrlTachThua
End Class
