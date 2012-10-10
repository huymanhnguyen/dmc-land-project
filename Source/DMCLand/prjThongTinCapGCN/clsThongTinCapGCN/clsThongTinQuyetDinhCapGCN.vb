Imports DMC.Database

Public Class clsThongTinQuyetDinhCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN", "@MaQuyetDinhCapGCN" _
        , "@SoQuyetDinhCapGCN", "@NgayQuyetDinhCapGCN", "@DonViQuyetDinhCapGCN"}
    Private strMaHoSoCapGCN As String
    Private strMaQuyetDinhCapGCN As String
    Private strSoQuyetDinhCapGCN As String
    Private strNgayQuyetDinhCapGCN As String
    Private strDonViQuyetDinhCapGCN As String
    'Khai báo biến kiểm tra lỗi 
    Private strError As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối Database
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
    'Khai báo thuộc tính ứng với biến Mã quyết định cấp GCN
    Public Property MaQuyetDinhCapGCN() As String
        Get
            Return strMaQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strMaQuyetDinhCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính tương ứng với biến
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Thuộc tính đơn vị quyết định cấp GCN
    Public Property DonViQuyetDinhCapGCN() As String
        Get
            Return strDonViQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strDonViQuyetDinhCapGCN = value
        End Set
    End Property
    'Thuộc tính số Quyết định cấp GCN
    Public Property SoQuyetDinhCapGCN() As String
        Get
            Return strSoQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strSoQuyetDinhCapGCN = value
        End Set
    End Property
    'Thuộc tính ngày Ngày quyết định cấp GCN
    Public Property NgayQuyetDinhCapGCN() As String
        Get
            Return strNgayQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strNgayQuyetDinhCapGCN = value
        End Set
    End Property

    ''' <summary>
    ''' Thêm mới thông tin Quyết định cấp GCN theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spInsertThongTinQuyetDinhCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Quyết định cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinQuyetDinhCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin Quyết định cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinQuyetDinhCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Hàm thực thi phát biếu SQL
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục</param>
    ''' <param name="strRecords"></param>
    ''' <returns>Giá trị trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strMaQuyetDinhCapGCN, strSoQuyetDinhCapGCN, strNgayQuyetDinhCapGCN, strDonViQuyetDinhCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, strRecords)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Phương thức truy vấn cơ sở dữ liệu
    ''' </summary>
    ''' <param name="dtResults">Bảng dữ liệu trả về từ câu truy vấn</param>
    ''' <returns>Giá trị trả về kiểu String là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function GetData(ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strMaQuyetDinhCapGCN, strSoQuyetDinhCapGCN, strNgayQuyetDinhCapGCN, strDonViQuyetDinhCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinQuyetDinhCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
