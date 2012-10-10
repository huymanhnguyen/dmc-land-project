Imports DMC.Database

Public Class clsThongTinKyGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private Paras() As String = {"@MaHoSoCapGCN", "@DiaDanhNoiCap" _
        , "@NgayKyGCN", "@TieuDeKyGCN", "@NguoiKyGCN"}
    Private strMaHoSoCapGCN As String
    Private strDiaDanhNoiCap As String
    Private strNgayKyGCN As String
    Private strTieuDeKyGCN As String
    Private strNguoiKyGCN As String

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
    'Khai bao thuoc tinh ung voi bien 
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property NgayKyGCN() As String
        Get
            Return strNgayKyGCN
        End Get
        Set(ByVal value As String)
            strNgayKyGCN = value
        End Set
    End Property
    Public Property NguoiKyGCN() As String
        Get
            Return strNguoiKyGCN
        End Get
        Set(ByVal value As String)
            strNguoiKyGCN = value
        End Set
    End Property

    Public Property TieuDeKyGCN() As String
        Get
            Return strTieuDeKyGCN
        End Get
        Set(ByVal value As String)
            strTieuDeKyGCN = value
        End Set
    End Property

    Public Property DiaDanhNoiCap() As String
        Get
            Return strDiaDanhNoiCap
        End Get
        Set(ByVal value As String)
            strDiaDanhNoiCap = value
        End Set
    End Property

    ''' <summary>
    ''' Thêm mới thông tin ký GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinKyGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spInsertThongTinKyGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin ký GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinKyGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinKyGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin sổ quản lý
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinKyGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinKyGCNByMaHoSoCapGCN", str)
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
            'Neu ket noi co so du lieu thanh cong
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strDiaDanhNoiCap, strNgayKyGCN _
                        , strTieuDeKyGCN, strNguoiKyGCN}
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
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strDiaDanhNoiCap, strNgayKyGCN _
                        , strTieuDeKyGCN, strNguoiKyGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn thông tin Sổ quản lý
                Database.getValue(dtResults, "spSelectThongTinKyGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
