Imports DMC.Database

Public Class clsThongTinHoSoCapGCNThuaDatLichSu
    Dim Paras() As String = {"@MaThuaDatLichSu", "@MaHoSoCapGCNHienThoi", "@MaDonViHanhChinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    'Mã thửa đất lịch sử
    Private strMaThuaDatLichSu As String = Nothing
    'Mã Hồ sơ cấp GCN hiện thời
    Private strMaHoSoCapGCNHienThoi As String = Nothing
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Thuộc tính Mã thửa đất lịch sử
    Public Property MaThuaDatLichSu() As String
        Get
            Return strMaThuaDatLichSu
        End Get
        Set(ByVal value As String)
            strMaThuaDatLichSu = value
        End Set
    End Property
    'Thuộc tính Mã Hồ sơ cấp GCN hiện thời
    Public Property MaHoSoCapGCNHienThoi() As String
        Get
            Return strMaHoSoCapGCNHienThoi
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCNHienThoi = value
        End Set
    End Property

#Region "Sao chép thông tin Lịch sử Chủ sử dụng đất"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử chủ sử dụng thửa đất
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về Chủ sử dụng thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuChuSuDung(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuChuSuDung", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin Chủ sử dụng lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuChuSuDung() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuChuSuDung", strResults)
    End Function
#End Region

#Region "Sao chép thông tin Lịch sử MỤC ĐÍCH sử dụng đất"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử MỤC ĐÍCH sử dụng thửa đất
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về MỤC ĐÍCH sử dụng thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuMucDichSuDung(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuMucDichSuDung", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin MỤC ĐÍCH sử dụng lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuMucDichSuDung() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuMucDichSuDung", strResults)
    End Function
#End Region

#Region "Sao chép thông tin Lịch sử NGUỒN GỐC sử dụng đất"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử NGUỒN GỐC sử dụng thửa đất
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về NGUỒN GỐC sử dụng thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuNguonGocSuDung(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuNguonGocSuDung", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin NGUỒN GỐC sử dụng lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuNguonGocSuDung() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuNguonGocSuDung", strResults)
    End Function
#End Region

#Region "Sao chép thông tin Lịch sử KIỂM KÊ sử dụng đất"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử KIỂM KÊ sử dụng thửa đất
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về KIỂM KÊ sử dụng thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuKiemKe(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuKiemKe", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin KIỂM KÊ sử dụng lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuKiemKe() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuKiemKe", strResults)
    End Function
#End Region

#Region "Sao chép thông tin Lịch sử QUI HOẠCH sử dụng đất"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử QUI HOẠCH sử dụng thửa đất
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về QUI HOẠCH sử dụng thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuQuiHoach(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuQuiHoach", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin QUI HOẠCH sử dụng lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuQuiHoach() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuQuiHoach", strResults)
    End Function
#End Region

#Region "Sao chép thông tin Lịch sử TÀI LIỆU KÈM THEO"
    ''' <summary>
    ''' Lựa chọn thông tin Lịch sử TÀI LIỆU KÈM THEO
    ''' Truy vấn này sẽ lựa chọn toàn bộ thông tin về TÀI LIỆU KÈM THEO
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSuTaiLieuKemTheo(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectThongTinLichSuTaiLieuKemTheo", dtRecords)
    End Function

    ''' <summary>
    ''' Sao chép thông tin TÀI LIỆU KÈM THEO lịch sử vào Hồ sơ thửa đất hiện thời
    ''' </summary>
    ''' <returns>Kết quả trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SaoChepThongTinLichSuTaiLieuKemTheo() As String
        Dim strResults As String = ""
        Return Me.Execute("spSaoChepThongTinLichSuTaiLieuKemTheo", strResults)
    End Function
#End Region

    ''' <summary>
    ''' Hàm truy vấn cơ sở dữ liệu
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If (Database.OpenConnection = True) Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strMaThuaDatLichSu, strMaHoSoCapGCNHienThoi, strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Hàm thực thi thủ tục SQL
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục</param>
    ''' <param name="strResults"></param>
    ''' <returns>Giá trị trả về là chuỗi lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = {strMaThuaDatLichSu, strMaHoSoCapGCNHienThoi, strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

End Class
