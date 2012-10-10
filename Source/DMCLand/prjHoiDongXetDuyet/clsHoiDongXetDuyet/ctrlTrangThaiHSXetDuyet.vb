Public Class ctrlTrangThaiHSXetDuyet

    Private strConnection As String = ""
    Private strMaHoSoCapGCN As String = ""

    ' Tao thuoc tinh nhan ve chuoi ket noi DataBase
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    ' Tao thuoc tinh nhan ve MaHoSoCapGCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Private Sub btnhuylenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuylenh.Click
        chkXacNhan.Checked = False
        chkXacNhan.Enabled = False
        btnghi.Enabled = False
        btnsua.Enabled = True
        btnhuylenh.Enabled = False

    End Sub

    Private Sub btnsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsua.Click
        chkXacNhan.Enabled = True
        btnghi.Enabled = True
        btnhuylenh.Enabled = True
        btnsua.Enabled = False
    End Sub

    Private Sub btnghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnghi.Click
        ' Khai bao va khoi tao lop Thong Tin Xet Duyet
        Dim XetDuyet As New clsHoiDongXetDuyet
        XetDuyet.Connection = strConnection
        XetDuyet.MaHoSoCapGCN = strMaHoSoCapGCN
        XetDuyet.MaDonViHanhChinh = strMaDonViHanhChinh
        If chkXacNhan.Checked = True Then
            If Not strMaHoSoCapGCN = "" Then
                Dim str As String = ""
                XetDuyet.ExcecuteXetDuyet(str)
                chkXacNhan.Checked = False
                chkXacNhan.Enabled = False
                btnghi.Enabled = False
                btnhuylenh.Enabled = False
                btnsua.Enabled = True
            Else
                chkXacNhan.Checked = False
                chkXacNhan.Enabled = False
                btnghi.Enabled = False
                btnhuylenh.Enabled = False
                btnsua.Enabled = True
            End If
        End If

    End Sub
End Class
