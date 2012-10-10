Imports DMC.Database
Imports System.Data.SqlClient
Public Class clsInPhieu
    Private Para() As String = {"@MaHoSoCapGCN", "@MaDonViHanhChinh"}
    Private ParaToTrinh() As String = {"@MaHoSoCapGCN", "@SoToTrinh", "@NgayTrinhPhuong", "@MaDonVIHanhChinh"}
    Private ParaDVHC() As String = {"@MaDVHC"}
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strMaDVHC As String = ""
    Private strFlag As String = ""
    Private strSoToTrinh As String = ""
    Private strNgayTrinhPhuong As String = ""
    Private strError As String = ""
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Property Connection()
        Get
            Return strConnection
        End Get
        Set(ByVal value)
            strConnection = value
        End Set
    End Property
    Public Property MaDVHC() As String
        Get
            Return strMaDVHC
        End Get
        Set(ByVal value As String)
            strMaDVHC = value
        End Set
    End Property
    Public Property SoToTrinh() As String
        Get
            Return strSoToTrinh
        End Get
        Set(ByVal value As String)
            strSoToTrinh = value
        End Set
    End Property
    Public Property NgayTrinhPhuong() As String
        Get
            Return strNgayTrinhPhuong
        End Get
        Set(ByVal value As String)
            strNgayTrinhPhuong = value
        End Set
    End Property
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    Public Function SelectHoSoThuaDat(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If (Database.OpenConnection) Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(MyTable, sp, paras, Values)
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function
    Public Function SelectGCN() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN, strMaDVHC}
            dt = SelectHoSoThuaDat("sp_SeletAllHoSoCapGCN", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectThongTinToTrinh() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strSoToTrinh, strNgayTrinhPhuong, strMaDVHC}
            dt = SelectHoSoThuaDat("sp_SelectThongTinToTrinh", Values, ParaToTrinh)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectGroupNghiaVuTaiChinh() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectGroupNghiaVuTaiChinh", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectDVHC() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDVHC}
            dt = SelectHoSoThuaDat("spSelectHuyenTinh", Values, ParaDVHC)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectChuHoSoCapGCN() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("spSelectChuHoSoCapGCN", Values, Para)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function ExecuteToTrinh(ByVal records As String) As String
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN, strSoToTrinh, strNgayTrinhPhuong}
                'Gọi phương thức ExecuteSP của đối tượng Database
                Database.ExecuteSP("sp_UpdateNhomHoSoTrinhPhuong", ParaToTrinh, Values, records)
                strError = Database.Err
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    
End Class

