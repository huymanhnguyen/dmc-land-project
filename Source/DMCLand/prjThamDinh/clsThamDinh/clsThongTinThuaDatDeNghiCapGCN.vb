Public Class clsThongTinThuaDatDeNghiCapGCN
    'Khai bao mang tham so
    Dim Paras() As String = {"@MaHoSoCapGCN", "@ThongTinThuaDatDeNghiCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String = ""
    Private strMaHoSoCapGCN As String
    Private strThongTinThuaDatDeNghiCapGCN As String

    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien shFlag
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai bao thuoc tinh ung voi bien strMaHoSoCapGCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Property ThongTinThuaDatDeNghiCapGCN() As String
        Get
            Return strThongTinThuaDatDeNghiCapGCN
        End Get
        Set(ByVal value As String)
            strThongTinThuaDatDeNghiCapGCN = value
        End Set
    End Property


    ''' <summary>
    ''' Thêm thông tin Thẩm định vào hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN", str)
    End Function
    ''' <summary>
    ''' Cập nhật thông tin Thẩm định theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN", str)
    End Function
    ''' <summary>
    ''' Xóa thông tin Thẩm định theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN", str)
    End Function
    '
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaHoSoCapGCN, strThongTinThuaDatDeNghiCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi cơ sở dữ liệu
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, strRecords)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN(ByRef dtRecords As DataTable) As String
        Dim str As String = ""
        Return str = Me.GetData("spSelectThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN", dtRecords)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaHoSoCapGCN, strThongTinThuaDatDeNghiCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn dữ liệu của lớp thao tác cơ sở dữ liệu
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
