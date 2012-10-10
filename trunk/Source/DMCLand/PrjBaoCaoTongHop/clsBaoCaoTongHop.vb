Imports DMC.Database.clsDatabase
Imports DMC.Database

Public Class clsBaoCaoTongHop
    Private strConnection As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strTuNgay As String = ""
    Private strDenNgay As String = ""
    Public Property Connection() As String
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
    Public Property TuNgay() As String
        Get
            Return strTuNgay
        End Get
        Set(ByVal value As String)
            strTuNgay = value
        End Set
    End Property
    Public Property DenNgay() As String
        Get
            Return strDenNgay
        End Get
        Set(ByVal value As String)
            strDenNgay = value
        End Set
    End Property
    Public Function GetData_SP(ByVal sp As String, ByVal paras() As String, ByVal Values() As String) As DataTable
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
    Public Function SelectDVHC() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Dim ParaDVHC() As String = {"@MaDVHC"}
        Try
            Dim Values() As String = {strMaDonViHanhChinh}
            dt = GetData_SP("spSelectHuyenTinh", ParaDVHC, Values)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

End Class
