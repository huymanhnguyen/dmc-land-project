Imports DMC.Database

Public Class clsThongTinRungCay
    Dim Paras() As String = {"@MaThongTinRungCay", "@MaHoSoCapGCN" _
    , "@DienTichCoRung", "@NguonGocTaoLap", "@SoHoSoGiaoRung"}
    ' Nhận xâu kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaThongTinRungCay As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strDienTichCoRung As String = ""
    Private strNguonGocTaoLap As String = ""
    Private strSoHoSoGiaoRung As String = ""
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

    'Khai báo thuộc tính ứng với biến Mã Thông tin Rừng cây
    Public Property MaThongTinRungCay() As String
        Get
            Return strMaThongTinRungCay
        End Get
        Set(ByVal value As String)
            strMaThongTinRungCay = value
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
    'Khai báo thuộc tính ứng với biến DIỆN TÍCH CÓ RỪNG
    Public Property DienTichCoRung() As String
        Get
            Return strDienTichCoRung
        End Get
        Set(ByVal value As String)
            strDienTichCoRung = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến NGUỒN GỐC TẠO LẬP
    Public Property NguonGocTaoLap() As String
        Get
            Return strNguonGocTaoLap
        End Get
        Set(ByVal value As String)
            strNguonGocTaoLap = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến SỐ HỒ SƠ GIAO RỪNG
    Public Property SoHoSoGiaoRung() As String
        Get
            Return strSoHoSoGiaoRung
        End Get
        Set(ByVal value As String)
            strSoHoSoGiaoRung = value
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
                {strMaThongTinRungCay, strMaHoSoCapGCN, strDienTichCoRung, strNguonGocTaoLap, strSoHoSoGiaoRung}
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
    ''' Xóa Thông tin Rừng cây với Mã Hồ sơ cấp GCN cho trước
    ''' Trường hợp này xóa nhiều bản ghi Thông tin Rừng cây
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinRungCayByMaHoSoCapGCN(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteThongTinRungCayByMaHoSoCapGCN")
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
    Public Function DeleteThongTinRungCayByMaThongTinRungCay(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteThongTinRungCayByMaThongTinRungCay")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Rừng cây
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinRungCay(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spUpdateThongTinRungCay")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Thêm mới Thông tin Rừng cây
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinRungCay(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spInsertThongTinRungCay")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectThongTinRungCayByMaHoSoCapGCN(ByRef dtResults As DataTable) As String
        Return GetData("spSelectThongTinRungCayByMaHoSoCapGCN", dtResults)
    End Function

    ''' <summary>
    ''' Nhận Thông tin Rừng cây theo điều kiện truy vấn
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
                {strMaThongTinRungCay, strMaHoSoCapGCN, strDienTichCoRung, strNguonGocTaoLap, strSoHoSoGiaoRung}
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
