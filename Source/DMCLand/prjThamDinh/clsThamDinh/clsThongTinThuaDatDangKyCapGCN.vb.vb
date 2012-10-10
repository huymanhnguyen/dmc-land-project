Imports DMC.Database

Public Class clsThongTinThuaDatDangKyCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN", "@MaDonViHanhChinh"}

    Private strMaHoSoCapGCN As String
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

    Private strmaDonViHanhChinh As String = ""
    Public Property MaDonVIHanhChinh() As String
        Get
            Return strmaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strmaDonViHanhChinh = value
        End Set
    End Property

    ''' <summary>
    ''' Danh sách Thửa đất đăng ký cấp GCN 
    ''' </summary>
    ''' <returns>Giá trị trả về là bảng danh sách Thửa đất cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData(dtResults)
        Return dtResults
    End Function

    ''' <summary>
    ''' Danh sách Thửa đất đăng ký cấp GCN 
    ''' </summary>
    ''' <returns>Giá trị trả về là bảng danh sách Thửa đất cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinThuaDatTongHopCapGCNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetDataTongHOP(dtResults)
        Return dtResults
    End Function
    ''' <summary>
    ''' Phương thức truy vấn Danh sách thông tin Thửa đất đăng ký cấp GCN
    ''' </summary>
    ''' <param name="dtResults">Bảng dữ liệu trả về từ câu truy vấn</param>
    ''' <returns>Giá trị trả về kiểu String là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function GetData(ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN, strmaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinThuaDatDangKyCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    ''' <summary>
    ''' Phương thức truy vấn Danh sách thông tin Thửa đất đăng ký cấp GCN
    ''' </summary>
    ''' <param name="dtResults">Bảng dữ liệu trả về từ câu truy vấn</param>
    ''' <returns>Giá trị trả về kiểu String là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function GetDataTongHOP(ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Paras() As String = {"@MaHoSoCapGCN"}
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinThuaDatTongHopThamDinhByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
