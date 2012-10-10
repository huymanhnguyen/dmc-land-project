Imports System.Data.SqlClient

Public Class ctrLuanChuyen
    Private shortAction As Short = 0
    Private strError As String = ""
    Private strConnection As String = ""
    Private dtTimKiem As New DataTable
    Private strMaDonViHanhChinh As String = ""
    Private strNgayTimKiem As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strToBanDo As String = ""
    Private strSoThua As String = ""
    Private strDienTich As String = ""
    Private strDiaChi As String = ""
    Private strThoiDiemTiepNhan As String = ""
    Private strTenNguoiTiepNhan As String = ""
    Private strTenNguoiKeKhai As String = ""
    Private strDieuKien As String = ""
    Private strLyDoKhongDuDK As String = ""
    Private strThoiDiemChuyen As String = Now.Date.ToString()
    Private strTrangThai As String = ""
    Private strChonIn As String = ""


    Public Property Conection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Private strUserName As String = ""
    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property

   
    Private Sub cmdTiepNhanHoSo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTiepNhanHoSo.Click
        Dim frm As New frmHoSoTiepNhan
        With frm
            .Conection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .TimKiemTiepNhanTu1Cua()
            .TimKiemHoSoDaChuyenVeVPNhaDat()
            .TimKiemHoSoNhanVe()
            .TimKiemTheoDoi()
        End With
        frm.ShowDialog()
    End Sub

    Private Sub cmdVPDangKy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVPDangKy.Click
        Dim frm As New frmHoSoVPDK
        With frm
            .Conection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .TimKiemVpNhaDatTiepNhan()
            .TimKiemVpNhaDatDaNhanLai()
            .TimKiemHoSoVPNhaDatChuyenLenThamDinh()
            .TimKiemTheoDoi()
        End With
        frm.ShowDialog()
    End Sub

    Private Sub cmdLanhDaoVP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLanhDaoVP.Click
        Dim frm As New frmHoSoLanhDaoVPDK
        With frm
            .Conection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .TimKiemVPThamDinhTiepNhan()
            .TimKiemHoSoVPNhaDatChuyenLenThamDinh()
            .TimKiemTheoDoi()
        End With
        frm.ShowDialog()
    End Sub

    Private Sub cmdPhongTNMT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPhongTNMT.Click
        Dim frm As New frmHoSoTNMT
        With frm
            .Conection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .TimKiemTNMTTiepNhan()
            .TimKiemHoSoDaChuyenLenUBThamDinh()
            .TimKiemTheoDoi()
        End With
        frm.ShowDialog()
    End Sub

    Private Sub cmdUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUB.Click
        Dim frm As New frmHoSoUB
        With frm
            .Conection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .TimKiemUBThamDinhNhan()
            .TimKiemHoSoDaChuyenVeNoiTiepNhan()
            .TimKiemTheoDoi()
        End With
        frm.ShowDialog()
    End Sub
 
End Class
