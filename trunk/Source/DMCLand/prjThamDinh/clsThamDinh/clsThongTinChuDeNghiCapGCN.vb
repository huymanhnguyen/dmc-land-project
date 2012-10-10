Imports DMC.Database
''' <summary>
''' Lớp thông tin Chủ sử dụng đất và chủ sở hữu tài sản gắn liền với đất
''' đề nghị nghi tại mục I, trang 1 của GCN
''' </summary>
''' <remarks></remarks>
Public Class clsThongTinChuDeNghiCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    Private Paras() As String = {"@MaHoSoCapGCN"}
    Private strXML As String = ""
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
    'Khai báo thuộc tính tương ứng với biến
    Public Property XML() As String
        Get
            Return strXML
        End Get
        Set(ByVal value As String)
            strXML = value
        End Set
    End Property
    ''' <summary>
    ''' Danh sách thông tin Chủ GCN đề nghị In GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Kết quả trả về là Bảng danh sách chủ GCN đề nghị In GCN theo
    ''' Mã Hồ sơ cấp GCN cho trước</returns>
    ''' <remarks></remarks>
    Public Function SelectChuDeNghiCapGCNByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Me.GetData("spSelectChuDeNghiCapGCNByMaHoSoCapGCN", dtResults)
        Return dtResults
    End Function

    ''' <summary>
    ''' Xóa Chủ đề nghị cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteChuDeNghiCapGCN() As String
        Dim strRecords As String = ""
        'Trả về thông báo lỗi nếu có
        Return Me.Execute("spDeleteChuDeNghiCapGCN", strRecords)
    End Function

    ''' <summary>
    ''' Thêm Chủ đề nghị cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertChuDeNghiCapGCN() As String
        Dim strRecords As String = ""
        'Trả về thông báo lỗi nếu có
        Return Me.Execute("spInsertChuDeNghiCapGCN", strRecords)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Chủ đề nghị cấp GCN
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục</param>
    ''' <param name="strRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng tham số
                Dim Paras() As String = {"@XML"}
                'Khai báo mảng giá trị
                Dim Values() As String = {strXML}
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
    ''' Phương thức truy vấn Thông tin Chủ đề nghị cấp GCN
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
