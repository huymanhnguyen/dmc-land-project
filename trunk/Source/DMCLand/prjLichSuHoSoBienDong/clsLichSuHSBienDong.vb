Imports DMC.Database
Public Class clsLichSuHSBienDong
    Private strConnection As String = ""
    Private strError As String = ""
    Private strMaDangKyBienDong As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strMaThuaDat As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strMaBienDong As String = ""

    Public Property MaBienDong() As String
        Get
            Return strMaBienDong
        End Get
        Set(ByVal value As String)
            strMaBienDong = value
        End Set
    End Property
    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    Public Property MyError() As String
        Get
            Return strError
        End Get
        Set(ByVal value As String)
            strError = value
        End Set
    End Property
    Public Property MaDangKyBienDong() As String

        Get
            Return strMaDangKyBienDong
        End Get
        Set(ByVal value As String)
            strMaDangKyBienDong = value
        End Set
    End Property
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
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

    Public Sub selDanhSachBienDong(ByVal dt As DataTable)
        Dim cls As New clsDatabase
        cls.Connection = strConnection
        cls.OpenConnection()
        Dim para() As String = {"@flag", "@MaThuaDat", "@MaHoSoCapGCN", "@MaDonViHanhChinh", "@MaBienDong"}
        Dim value() As String = {0, strMaThuaDat, strMaHoSoCapGCN, strMaDonViHanhChinh, strMaBienDong}
        cls.getValue(dt, "spThongTinBienDongHoSo", para, value)
    End Sub
    Public Sub selThongTinHoSoBienDong(ByVal dt As DataTable)
        Dim cls As New clsDatabase
        cls.Connection = strConnection
        cls.OpenConnection()
        Dim para() As String = {"@flag", "@MaThuaDat", "@MaHoSoCapGCN", "@MaDonViHanhChinh", "@MaBienDong"}
        Dim value() As String = {1, strMaThuaDat, strMaHoSoCapGCN, strMaDonViHanhChinh, strMaBienDong}
        cls.getValue(dt, "spThongTinBienDongHoSo", para, value)
    End Sub
End Class
