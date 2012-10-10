Imports DMC.Land.User
Public Class frmServer
    'Khai báo biến đọc thông số kết nối máy chủ
    Private clsUsr As New clsUser
    'Khai báo thuộc tính chỉ đọc thông số kết nối máy chủ
    Public ReadOnly Property User() As clsUser
        Get
            Return clsUsr
        End Get
    End Property
    Private Sub frmServer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        clsUsr.ConnectionName = UcSerVer1.txtTenKetNoi.Text
        clsUsr.ServerName = UcSerVer1.Get_MayChu
        clsUsr.DatabaseName = UcSerVer1.Get_CoSoDuLieu
    End Sub

    Private Sub frmServer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UcSerVer1.Get_Ten = clsUsr.ConnectionName
        'UcSerVer1.MyForm = Me
    End Sub

    Private Sub frmServer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        clsUsr.ConnectionName = UcSerVer1.txtTenKetNoi.Text
        clsUsr.ServerName = UcSerVer1.Get_MayChu
        clsUsr.DatabaseName = UcSerVer1.Get_CoSoDuLieu
    End Sub
End Class
