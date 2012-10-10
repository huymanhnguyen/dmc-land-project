Imports DMC.Database
Imports System.Data.SqlClient
Public Class clsToTrinh
    Private Para() As String = {"@MaHoSoCapGCN", "@MaDonViHanhChinh"}
    Private ParaToTrinh() As String = {"@MaHoSoCapGCN", "@SoToTrinhDiaChinh"}

    Private ParaDVHC() As String = {"@MaDVHC"}
    Private strMaHoSoCapGCN As String = ""
    Private strConnection As String = ""
    Private strMaDVHC As String = ""
    Private strFlag As String = ""
    Private strSoToTrinh As String = ""
    Private strNgayTrinh As String = ""
    Private strNgayLapToTrinh As String = ""
    Private strDonViLapToTrinh As String = ""
    Private strMaToTrinh As String = ""
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
  
   
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
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
    Public Property MaToTrinh() As String
        Get
            Return strMaToTrinh
        End Get
        Set(ByVal value As String)
            strMaToTrinh = value
        End Set
    End Property
    Public Property NgayTrinh() As String
        Get
            Return strNgayTrinh
        End Get
        Set(ByVal value As String)
            strNgayTrinh = value
        End Set
    End Property
    Public Property DonViLapToTrinh() As String
        Get
            Return strDonViLapToTrinh
        End Get
        Set(ByVal value As String)
            strDonViLapToTrinh = value
        End Set
    End Property
    Public Property NgayLapToTrinh() As String
        Get
            Return strNgayLapToTrinh
        End Get
        Set(ByVal value As String)
            strNgayLapToTrinh = value
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
            Dim Values() As String = {strSoToTrinh, strNgayTrinh, strMaDVHC}
            Dim paraSelectToTrinh() As String = {"@SoToTrinhDiaChinh", "@NgayTrinhDiaChinh", "@MaDonViHanhChinh"}
            dt = SelectHoSoThuaDat("sp_SelectThongTinToTrinh", Values, paraSelectToTrinh)
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
    Public Function SelectToTrinh() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDVHC}
            dt = SelectHoSoThuaDat("sp_SelectToTrinh", Values, ParaDVHC)
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

    Public Function SelectChuSuDung() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = SelectHoSoThuaDat("sp_SelectInPhieuChuSuDung", Values, Para)
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
                Dim Values() As String = {strMaHoSoCapGCN, strSoToTrinh}
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
    Public Function Execute(ByVal records As String, ByVal sp As String, ByVal value() As String, ByVal Para() As String)
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Gọi phương thức ExecuteSP của đối tượng Database
                Database.ExecuteSP(sp, Para, value, records)
                strError = Database.Err
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Sub InsertToTrinh()
        Dim Values() As String = {strSoToTrinh, strNgayLapToTrinh, strDonViLapToTrinh, strNgayTrinh, strMaDVHC}
        Dim ParaToTrinhs() As String = {"@SoToTrinhDiaChinh", "@NgayLapToTrinhDiaChinh", "@DonViLapToTrinhDiaChinh", "@NgayTrinhDiaChinh", "@MaDVHC"}
        Execute("", "sp_InsertToTrinh", Values, ParaToTrinhs)
    End Sub
    Public Sub UpdateToTrinh()
        Dim ParaToTrinhs() As String = {"@MaToTrinhDiaChinh", "@SoToTrinhDiaChinh", "@NgayLapToTrinhDiaChinh", "@DonViLapToTrinhDiaChinh", "@NgayTrinhDiaChinh"}
        Dim Values() As String = {strMaToTrinh, strSoToTrinh, strNgayLapToTrinh, strDonViLapToTrinh, strNgayTrinh}
        Execute("", "sp_UpdateToTrinh", Values, ParaToTrinhs)
    End Sub
    Public Sub DeleteToTrinh()
        Dim Values() As String = {strMaToTrinh}
        Dim ParaToTrinhs() As String = {"@MaToTrinhDiaChinh"}
        Execute("", "sp_DeleteToTrinh", Values, ParaToTrinhs)
    End Sub
End Class
