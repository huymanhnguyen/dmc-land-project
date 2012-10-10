Imports DMC.Database

Public Class clsThongBaoCapGCN
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private Paras() As String = {"@MaHoSoCapGCN", "@NgayThongBaoUBND", "@NgayCongDanNhanThongBao"}

    Private strMaHoSoCapGCN As String
    Private strNgayThongBaoUBND As String
    Private strNgayCongDanNhanThongBao As String
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
    Public Property NgayCongDanNhanThongBao() As String
        Get
            Return strNgayCongDanNhanThongBao
        End Get
        Set(ByVal value As String)
            strNgayCongDanNhanThongBao = value
        End Set
    End Property
    Public Property NgayThongBaoUBND() As String
        Get
            Return strNgayThongBaoUBND
        End Get
        Set(ByVal value As String)
            strNgayThongBaoUBND = value
        End Set
    End Property

    ''' <summary>
    ''' Thêm mới Thông tin thông báo cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongBaoCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongBaoCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Thông báo cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongBaoCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongBaoCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông báo cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongBaoCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongBaoCapGCNByMaHoSoCapGCN", str)
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
                    {strMaHoSoCapGCN, strNgayThongBaoUBND, strNgayCongDanNhanThongBao}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
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
                    {strMaHoSoCapGCN, strNgayThongBaoUBND, strNgayCongDanNhanThongBao}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResults, "spSelectThongBaoCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
