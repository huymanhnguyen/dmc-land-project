Imports DMC.Database

Public Class clsTongHopDatInBienBanXetDuyet
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strError As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strTheoGiayTo As String = ""
    Private strKhongTheoGiayTo As String = ""
    Private strGiayToKhac As String = ""
    Private strDeNghiCapDat As String = ""
    Private strDeNghiCapTaiSan As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public WriteOnly Property MaDonViHanhChinh() As String
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property TheoGiayTo() As String
        Get
            Return strTheoGiayTo
        End Get
        Set(ByVal value As String)
            strTheoGiayTo = value
        End Set
    End Property
    Public Property KhongTheoGiayTo() As String
        Get
            Return strKhongTheoGiayTo
        End Get
        Set(ByVal value As String)
            strKhongTheoGiayTo = value
        End Set
    End Property
    Public Property GiayToKhac() As String
        Get
            Return strGiayToKhac
        End Get
        Set(ByVal value As String)
            strGiayToKhac = value
        End Set
    End Property
    Public Property DeNghiCapDat() As String
        Get
            Return strDeNghiCapDat
        End Get
        Set(ByVal value As String)
            strDeNghiCapDat = value
        End Set
    End Property
    Public Property DeNghiCapTaiSan() As String
        Get
            Return strDeNghiCapTaiSan
        End Get
        Set(ByVal value As String)
            strDeNghiCapTaiSan = value
        End Set
    End Property
    Public Function GetData(ByRef records As DataTable) As String
        Dim strError As String = ""
        Try
            'Khoi tao doi tuong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Paras() As String = {"@flag", "@MaHoSoCapGCN"}
                Dim Values() As String = {0, strMaHoSoCapGCN}
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(records, "spTongHopDatInBienBanXetDuyet", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function Execute(ByRef records As String, ByVal flag As Integer) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Paras() As String = {"@flag", "@MaHoSoCapGCN", "@TheoGiayTo", "@KhongTheoGiayTo", "@GiayToKhac", "@DeNghiCapDat", "@DeNghiCapTaiSan"}
                Dim Values() As String = {flag, strMaHoSoCapGCN, strTheoGiayTo, strKhongTheoGiayTo, strGiayToKhac, strDeNghiCapDat, strDeNghiCapTaiSan}
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spTongHopDatInBienBanXetDuyet", Paras, Values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
