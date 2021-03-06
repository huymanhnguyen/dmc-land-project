'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database
Public Class clsHangMucCongTrinh
    Dim Paras() As String = {"@MaHangMucCongTrinh", "@MaCongTrinhXayDung" _
         , "@TenHangMucCongTrinh", "@DienTichXayDung", "@CongSuat", "@KetCau" _
         , "@CapHang", "@SoTang", "@NamXayDung", "@ThoiHanSoHuu"}
    'Nhận xâu kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaHangMucCongTrinh As String = ""
    Private strMaCongTrinhXayDung As String = ""
    Private strTenHangMucCongTrinh As String = ""
    Private dblDienTichXayDung As String = ""
    Private strCongSuat As String = ""
    Private strKetCau As String = ""
    Private strCapHang As String = ""
    Private intSoTang As String = ""
    Private intNamXayDung As String = ""
    Private strThoiHanSoHuu As String = ""

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

    'Khai báo thuộc tính ứng với biến 
    Public Property MaHangMucCongTrinh() As String
        Get
            Return strMaHangMucCongTrinh
        End Get
        Set(ByVal value As String)
            strMaHangMucCongTrinh = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến Mã Công trình xây dựng
    Public Property MaCongTrinhXayDung() As String
        Get
            Return strMaCongTrinhXayDung
        End Get
        Set(ByVal value As String)
            strMaCongTrinhXayDung = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Tên hạng mục công trình
    Public Property TenHangMucCongTrinh() As String
        Get
            Return strTenHangMucCongTrinh
        End Get
        Set(ByVal value As String)
            strTenHangMucCongTrinh = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến Cập hạng Công trình xây dựng
    Public Property CapHang() As String
        Get
            Return strCapHang
        End Get
        Set(ByVal value As String)
            strCapHang = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biến Kết cấu công trình xây dựng
    Public Property KetCau() As String
        Get
            Return strKetCau
        End Get
        Set(ByVal value As String)
            strKetCau = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoTang() As String
        Get
            Return intSoTang
        End Get
        Set(ByVal value As String)
            '          If value = 0 Then value = ""
            intSoTang = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NamXayDung() As String
        Get
            Return intNamXayDung
        End Get
        Set(ByVal value As String)
            '          If value = 0 Then value = ""
            intNamXayDung = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property ThoiHanSoHuu() As String
        Get
            Return strThoiHanSoHuu
        End Get
        Set(ByVal value As String)
            '          If value = 0 Then value = ""
            strThoiHanSoHuu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property DienTichXayDung() As String
        Get
            Return dblDienTichXayDung
        End Get
        Set(ByVal value As String)
            '           If value = 0 Then value = ""
            dblDienTichXayDung = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property CongSuat() As String
        Get
            Return strCongSuat
        End Get
        Set(ByVal value As String)
            strCongSuat = value
        End Set
    End Property
    ''' <summary>
    ''' Hàm thức thi cơ sở dữ liệu dùng chung cho
    ''' trường hợp: Insert, Update, Delete Công trình xây dựng
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
                {strMaHangMucCongTrinh, strMaCongTrinhXayDung, strTenHangMucCongTrinh _
                 , dblDienTichXayDung, strCongSuat, strKetCau, strCapHang _
                 , intSoTang, intNamXayDung, strThoiHanSoHuu}
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
    ''' Xóa Công trình xây dựng với Mã Công trình xây dựng cho trước
    ''' Trường hợp này xóa nhiều bản ghi Công trình xây dựng
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteHangMucCongTrinhByMaCongTrinhXayDung(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteHangMucCongTrinhByMaCongTrinhXayDung")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Xóa Công trình xây dựng với Mã Công trình xây dựng cho trước
    ''' Trường hợp này Xóa một bản ghi Công trình xây dựng
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteHangMucCongTrinhByMaHangMucCongTrinh(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spDeleteHangMucCongTrinhByMaHangMucCongTrinh")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Hạng mục công trình
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateHangMucCongTrinh(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spUpdateHangMucCongTrinh")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Thêm một Hạng mục công trình
    ''' </summary>
    ''' <param name="records"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertHangMucCongTrinh(ByRef records As String) As String
        strError = ""
        Try
            strError = Me.Execute(records, "spInsertHangMucCongTrinh")
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectHangMucCongTrinhByMaMaCongTrinhXayDung(ByRef dtResults As DataTable) As String
        Return GetData("spSelectHangMucCongTrinhByMaCongTrinhXayDung", dtResults)
    End Function

    ''' <summary>
    ''' Truy vấn Hạng mục công trình theo điều kiện truy vấn
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
                {strMaHangMucCongTrinh, strMaCongTrinhXayDung, strTenHangMucCongTrinh _
                 , dblDienTichXayDung, strCongSuat, strKetCau, strCapHang _
                 , intSoTang, intNamXayDung, strThoiHanSoHuu}
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





