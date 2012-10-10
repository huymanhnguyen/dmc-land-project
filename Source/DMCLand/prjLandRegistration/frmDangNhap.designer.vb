Imports DMC.Land.QuanTriHeThong.DangNhap
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangNhap
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDangNhap))
        Me.CtrlKetNoi = New DMC.Land.QuanTriHeThong.DangNhap.ctrlKetNoi
        Me.SuspendLayout()
        '
        'CtrlKetNoi
        '
        Me.CtrlKetNoi.BackColor = System.Drawing.Color.Red
        Me.CtrlKetNoi.BackgroundImage = CType(resources.GetObject("CtrlKetNoi.BackgroundImage"), System.Drawing.Image)
        Me.CtrlKetNoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CtrlKetNoi.ChucNang = Nothing
        Me.CtrlKetNoi.Connection = Nothing
        Me.CtrlKetNoi.ConnectionName = Nothing
        Me.CtrlKetNoi.DatabaseName = Nothing
        Me.CtrlKetNoi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtrlKetNoi.DonViHanhChinh = Nothing
        Me.CtrlKetNoi.Location = New System.Drawing.Point(0, 0)
        Me.CtrlKetNoi.MaNguoiDung = Nothing
        Me.CtrlKetNoi.MaQuyen = 0
        Me.CtrlKetNoi.Name = "CtrlKetNoi"
        Me.CtrlKetNoi.Password = Nothing
        Me.CtrlKetNoi.ServerName = Nothing
        Me.CtrlKetNoi.Size = New System.Drawing.Size(561, 298)
        Me.CtrlKetNoi.TabIndex = 0
        Me.CtrlKetNoi.TenNguoiDung = Nothing
        Me.CtrlKetNoi.TrangThaiKetNoi = 0
        Me.CtrlKetNoi.UserID = Nothing
        '
        'frmDangNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(561, 298)
        Me.Controls.Add(Me.CtrlKetNoi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDangNhap"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlKetNoi As DMC.Land.QuanTriHeThong.DangNhap.ctrlKetNoi
End Class
