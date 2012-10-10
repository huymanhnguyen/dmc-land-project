Imports DMC.Database

Public Class clsThongTinToTrinhDiaChinh
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN", "@MaToTrinhDiaChinh", "@SoToTrinhDiaChinh" _
        , "@NgayLapToTrinhDiaChinh", "@DonViLapToTrinhDiaChinh", "@NgayTrinhDiaChinh", "@DieuKhoan"}

    Private strMaHoSoCapGCN As String
    Private strMaToTrinhDiaChinh As String
    Private strSoToTrinhDiaChinh As String
    Private strNgayLapToTrinhDiaChinh As String
    Private strDonViLapToTrinhDiaChinh As String
    Private strNgayTrinhDiaChinh As String
    Private strDieuKhoan As String

    Public Property DieuKhoan() As String
        Get
            Return strDieuKhoan
        End Get
        Set(ByVal value As String)
            strDieuKhoan = value
        End Set
    End Property
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
    'Khai báo thuộc tính tương ứng với biến
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với  biến Mã tờ trình địa chính
    Public Property MaToTrinhDiaChinh() As String
        Get
            Return strMaToTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strMaToTrinhDiaChinh = value
        End Set
    End Property
    'Thuộc tính đơn vị lập tờ trình
    Public Property DonViLapToTrinhDiaChinh() As String
        Get
            Return strDonViLapToTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strDonViLapToTrinhDiaChinh = value
        End Set
    End Property
    'Thuộc tính ngày trình địa chính
    Public Property NgayTrinhDiaChinh() As String
        Get
            Return strNgayTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strNgayTrinhDiaChinh = value
        End Set
    End Property
    'Thuộc tính số tờ trình địa chính
    Public Property SoToTrinhDiaChinh() As String
        Get
            Return strSoToTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strSoToTrinhDiaChinh = value
        End Set
    End Property
    'Thuộc tính ngày lập tờ trình
    Public Property NgayLapToTrinhDiaChinh() As String
        Get
            Return strNgayLapToTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strNgayLapToTrinhDiaChinh = value
        End Set
    End Property

    ''' <summary>
    ''' Thêm mới thông tin Tờ trình địa chính theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinToTrinhDiaChinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spInsertThongTinToTrinhDiaChinhByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Tờ trình địa chính
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinToTrinhDiaChinhByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin Tờ trình địa chính
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinToTrinhDiaChinhByMaHoSoCapGCN", str)
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
                    {strMaHoSoCapGCN, strMaToTrinhDiaChinh, strSoToTrinhDiaChinh, strNgayLapToTrinhDiaChinh, strDonViLapToTrinhDiaChinh _
                        , strNgayTrinhDiaChinh, strDieuKhoan}
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
                    {strMaHoSoCapGCN, strMaToTrinhDiaChinh, strSoToTrinhDiaChinh, strNgayLapToTrinhDiaChinh, strDonViLapToTrinhDiaChinh _
                        , strNgayTrinhDiaChinh, strDieuKhoan}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, "spSelectThongTinToTrinhDiaChinhByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
