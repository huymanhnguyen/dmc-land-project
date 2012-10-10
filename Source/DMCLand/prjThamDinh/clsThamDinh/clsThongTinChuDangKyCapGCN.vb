Imports DMC.Database

Public Class clsThongTinChuDangKyCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN"}

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
    ''' <summary>
    ''' Danh sách thông tin Chủ sở hữu công trình xây dựng đề nghị đăng ký cấp GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spSelectChuHoSoDangKyCapGCNGDCNByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function
    ''' <summary>
    ''' Danh sách thông tin Chủ sở hữu nhà đề nghị đăng ký cấp GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spSelectChuHoSoDangKyCapGCNCQNNByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function

    ''' <summary>
    ''' Danh sách thông tin Chủ sử dụng đề nghị đăng ký cấp GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Kết quả trả về là Bảng danh sách chủ sử dụng đăng ký cấp GCN theo
    ''' Mã Hồ sơ cấp GCN cho trước</returns>
    ''' <remarks></remarks>
    Public Function SelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spSelectChuHoSoDangKyCapGCNTCDNByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function

    ''' <summary>
    ''' Phương thức truy vấn Thông tin Chủ Hồ sơ cấp GCN
    ''' </summary>
    ''' <param name="dtResults">Bảng dữ liệu trả về từ câu truy vấn</param>
    ''' <returns>Giá trị trả về kiểu String là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
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
                    {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

End Class
