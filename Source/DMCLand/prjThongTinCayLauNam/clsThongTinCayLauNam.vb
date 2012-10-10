Imports DMC.Database

Public Class clsThongTinCayLauNam
    Dim Paras() As String = {"@MaThongTinCayLauNam", "@MaHoSoCapGCN" _
        , "@DienTich", "@LoaiCay"}
    ' Nhận xâu kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThongTinCayLauNam As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strDienTich As String = ""
    Private strLoaiCay As String = ""
    'Khai báo thuộc tính nhận xâu kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    'Khai báo thuộc tính ứng với biến Mã Thông tin Cây lâu năm
    Public Property MaThongTinCayLauNam() As String
        Get
            Return strMaThongTinCayLauNam
        End Get
        Set(ByVal value As String)
            strMaThongTinCayLauNam = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến Mã Hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến DIỆN TÍCH CÂY LÂU NĂM
    Public Property DienTich() As String
        Get
            Return strDienTich
        End Get
        Set(ByVal value As String)
            strDienTich = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Loại cây
    Public Property LoaiCay() As String
        Get
            Return strLoaiCay
        End Get
        Set(ByVal value As String)
            strLoaiCay = value
        End Set
    End Property
    ''' <summary>
    ''' Hàm thức thi cơ sở dữ liệu dùng chung cho
    ''' trường hợp: Insert, Update, Delete Tài sản
    ''' </summary>
    ''' <param name="records"></param>
    ''' <param name="strStoreProcedureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Execute(ByRef records As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaThongTinCayLauNam, strMaHoSoCapGCN, strDienTich, strLoaiCay}
                'Gọi phương thức ExecuteSP của đối tượng Database
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
                strError = Database.Err
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    ''' <summary>
    ''' Xóa Thông tin Cây lâu năm với Mã Hồ sơ cấp GCN cho trước
    ''' Trường hợp này xóa nhiều bản ghi Thông tin Cây lâu năm
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinCayLauNamByMaHoSoCapGCN(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteThongTinCayLauNamByMaHoSoCapGCN")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Xóa tài sản với Mã Tài sản cho trước
    ''' Trường hợp này Xóa một bản ghi tài sản
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinCayLauNamByMaThongTinCayLauNam(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteThongTinCayLauNamByMaThongTinCayLauNam")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Cây lâu năm
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinCayLauNam(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spUpdateThongTinCayLauNam")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Thêm mới Thông tin Cây lâu năm
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinCayLauNam(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spInsertThongTinCayLauNam")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectThongTinCayLauNamByMaHoSoCapGCN(ByRef dtResults As DataTable) As String
        Return GetData("spSelectThongTinCayLauNamByMaHoSoCapGCN", dtResults)
    End Function

    ''' <summary>
    ''' Nhận Thông tin Cây lâu năm theo điều kiện truy vấn
    ''' </summary>
    ''' <param name="dtResults"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaThongTinCayLauNam, strMaHoSoCapGCN, strDienTich, strLoaiCay}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                'Đóng kết nối cơ sở dữ liệu
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
