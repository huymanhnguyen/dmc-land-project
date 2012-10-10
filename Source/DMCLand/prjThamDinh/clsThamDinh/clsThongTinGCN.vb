Imports DMC.Database

Public Class clsThongTinGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN", "@TrangThaiHoSoCapGCN", "@CoQuanCapGCN", "@MaSoGCN" _
        , "@GhiChuGCN", "@NghiaVuTaiChinh", "@SoHoSoGoc", "@SoPhatHanhGCN", "@InKhungMat3", "@InHoSoThuaDat3"}

    'Trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Long = 0
    Private strMaHoSoCapGCN As String = ""
    Private strCoQuanCapGCN As String = ""
    Private strMaSoGCN As String = ""
    Private strGhiChuGCN As String = ""
    Private strNghiaVuTaiChinh As String = ""
    Private strSoHoSoGoc As String = ""
    Private strSoPhatHanhGCN As String = ""
    Private strCheckInKhungMat3 As String = ""
    Private strCheckInHoSoThuaDat3 As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private strError As String = ""
    Public Property CheckInHoSoThuaDatMat3() As String
        Get
            Return strCheckInHoSoThuaDat3
        End Get
        Set(ByVal value As String)
            strCheckInHoSoThuaDat3 = value
        End Set
    End Property
    Public Property CheckInKhungMat3() As String
        Get
            Return strCheckInKhungMat3
        End Get
        Set(ByVal value As String)
            strCheckInKhungMat3 = value
        End Set
    End Property
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
    'Khai báo thuộc tính Trạng thái Hồ sơ cấp GCN
    Public Property TrangThaiHoSoCapGCN() As Long
        Get
            Return longTrangThaiHoSoCapGCN
        End Get
        Set(ByVal value As Long)
            longTrangThaiHoSoCapGCN = value
        End Set
    End Property
    'Thuộc tính nơi cấp GCN
    Public Property CoQuanCapGCN() As String
        Get
            Return strCoQuanCapGCN
        End Get
        Set(ByVal value As String)
            strCoQuanCapGCN = value
        End Set
    End Property
    'Thuộc tính Mã số GCN
    Public Property MaSoGCN() As String
        Get
            Return strMaSoGCN
        End Get
        Set(ByVal value As String)
            strMaSoGCN = value
        End Set
    End Property
    'Thuộc tính Ghi chú GCN
    Public Property GhiChuGCN() As String
        Get
            Return strGhiChuGCN
        End Get
        Set(ByVal value As String)
            strGhiChuGCN = value
        End Set
    End Property
    'Thuộc tính Nghĩa vụ tài chính
    Public Property NghiaVuTaiChinh() As String
        Get
            Return strNghiaVuTaiChinh
        End Get
        Set(ByVal value As String)
            strNghiaVuTaiChinh = value
        End Set
    End Property
    Public Property SoPhatHanhGCN() As String
        Get
            Return strSoPhatHanhGCN
        End Get
        Set(ByVal value As String)
            strSoPhatHanhGCN = value
        End Set
    End Property
    Public Property SoHoSoGoc() As String
        Get
            Return strSoHoSoGoc
        End Get
        Set(ByVal value As String)
            strSoHoSoGoc = value
        End Set
    End Property

    Public Function SelectSoHoSoGocLonNhatByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.SelectTheoMaHoSoCapGCN("spSelectSoHoSoGocLonNhatByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function

    Private Function SelectTheoMaHoSoCapGCN(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Dim strParas() As String = {"@MaHoSoCapGCN"}
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (strParas.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn thông tin Sổ quản lý
                Database.getValue(dtResults, strStoreProcedureName, strParas, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Thêm mới thông tin GCN theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinGCNByMaHoSoCapGCN", str)
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
                    {strMaHoSoCapGCN, longTrangThaiHoSoCapGCN.ToString(), strCoQuanCapGCN, strMaSoGCN _
                        , strGhiChuGCN, strNghiaVuTaiChinh, strSoHoSoGoc, strSoPhatHanhGCN, strCheckInKhungMat3, strCheckInHoSoThuaDat3}
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
                    {strMaHoSoCapGCN, longTrangThaiHoSoCapGCN.ToString(), strCoQuanCapGCN, strMaSoGCN _
                        , strGhiChuGCN, strNghiaVuTaiChinh, strSoHoSoGoc, strSoPhatHanhGCN, strCheckInKhungMat3, strCheckInHoSoThuaDat3}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function selKiemTraTrungMaVach(ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim para() As String = {"@GiaTriMaVach"}
                Dim Values() As String = _
                    {strMaSoGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectCheckMaVach", para, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
