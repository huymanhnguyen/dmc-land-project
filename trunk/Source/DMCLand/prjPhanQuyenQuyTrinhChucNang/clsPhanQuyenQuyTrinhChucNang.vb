Imports DMC.Database.clsDatabase
Imports DMC.Database

Public Class clsPhanQuyenQuyTrinhChucNang
    Private strConnection As String
    Private strMaUser As String
    Private strError As String = ""
    Private strCapNhat As String
    Private strMaChucNang As String

    Public Property MaChucNang() As String
        Get
            Return strMaChucNang
        End Get
        Set(ByVal value As String)
            strMaChucNang = value
        End Set
    End Property
    Public Property CapNhat() As String
        Get
            Return strCapNhat
        End Get
        Set(ByVal value As String)
            strCapNhat = value
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
    Public Property MaUser() As String
        Get
            Return strMaUser
        End Get
        Set(ByVal value As String)
            strMaUser = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    Private Function Execute(ByVal strStoreProcedureName As String, ByVal Paras() As String, ByVal values() As String, ByVal strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, Paras, values, strRecords)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable, ByVal paras() As String, ByVal Values() As String) As String
        Try
            'Khởi tạo đối tượng cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                'Dim Values() As String = {strHoTen, strDiaChi}
                'Gọi phưong thức nhận dữ liệu của đối tượng clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectChucNangByMaUser() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {"@flag", "@MaUser"}
        Dim values() As String = {0, strMaUser}
        Me.GetData("spPhanQuyenByMaUser", dtResults, paras, values)
        Return dtResults
    End Function
    Public Function SelectMaUser() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {}
        Dim values() As String = {}
        Me.GetData("spSelectThongTinNguoiDung", dtResults, paras, values)
        Return dtResults
    End Function

    Public Function insChucNang() As String
        Dim paras() As String = {"@flag", "@MaChucNang", "@mauser", "@CapNhat"}
        Dim values() As String = {1, strMaChucNang, strMaUser, strCapNhat}
        Return Execute("spPhanQuyenByMaUser", paras, values, "")
    End Function
    Public Function DelChucNang() As String
        Dim paras() As String = {"@flag", "@MaChucNang", "@mauser", "@CapNhat"}
        Dim values() As String = {2, strMaChucNang, strMaUser, strCapNhat}
        Return Execute("spPhanQuyenByMaUser", paras, values, "")
    End Function
End Class
