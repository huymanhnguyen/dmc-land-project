'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
Imports DMC.Database
Public Class clsMucDich
    'Khai báo mảng tham số
    Dim Paras() As String = {"@MaMucDichSuDung", "@MaThuaDatCapGCN" _
        , "@KyHieu", "@KyHieuKiemKe" _
        , "@KyHieuQuiHoach", "@ChiTiet", "@DienTichKeKhai" _
        , "@DienTichRieng", "@DienTichChung", "@ThoiHan", "@GhiChu", "@MaDonViHanhChinh"}
    'Khai báo biến chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaMucDichSuDung As String
    Private strMaThuaDatCapGCN As String
    Private strKyHieu As String
    Private strKyHieuKiemKe As String
    Private strKyHieuQuiHoach As String
    Private strChiTiet As String
    Private dblDienTichKeKhai As String
    Private dblDienTichRieng As String
    Private dblDienTichChung As String
    Private strThoiHan As String
    Private strGhiChu As String
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính thông báo lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính Mã mục đich sử dụng
    Public Property MaMucDichSuDung() As String
        Get
            Return strMaMucDichSuDung
        End Get
        Set(ByVal value As String)
            strMaMucDichSuDung = value
        End Set
    End Property
    'Khai báo thuộc tính Mã thửa đất cấp GCN
    Public Property MaThuaDatCapGCN() As String
        Get
            Return strMaThuaDatCapGCN
        End Get
        Set(ByVal value As String)
            strMaThuaDatCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính Ký hiệu mục đich sử dụng
    Public Property KyHieu() As String
        Get
            Return strKyHieu
        End Get
        Set(ByVal value As String)
            strKyHieu = value
        End Set
    End Property
    'Khai báo thuộc tính Ký hiệu kiểm kê đất đai
    Public Property KyHieuKiemKe() As String
        Get
            Return strKyHieuKiemKe
        End Get
        Set(ByVal value As String)
            strKyHieuKiemKe = value
        End Set
    End Property
    'Khai báo ký hiệu qui hoạch sử dụng đất
    Public Property KyHieuQuiHoach() As String
        Get
            Return strKyHieuQuiHoach
        End Get
        Set(ByVal value As String)
            strKyHieuQuiHoach = value
        End Set
    End Property
    'Khai báo thuộc tính Chi tiế mục đich sử dụng
    Public Property ChiTiet() As String
        Get
            Return strChiTiet
        End Get
        Set(ByVal value As String)
            strChiTiet = value
        End Set
    End Property
    'Khai báo Diện tích kê khai
    Public Property DienTichKeKhai() As String
        Get
            Return dblDienTichKeKhai
        End Get
        Set(ByVal value As String)
            dblDienTichKeKhai = value
        End Set
    End Property
    'Khai báo thuộc tính Diện tích Riêng
    Public Property DienTichRieng() As String
        Get
            Return dblDienTichRieng
        End Get
        Set(ByVal value As String)
            dblDienTichRieng = value
        End Set
    End Property
    'Khai báo thuộc tính diện tích Chung 
    Public Property DienTichChung() As String
        Get
            Return dblDienTichChung
        End Get
        Set(ByVal value As String)
            dblDienTichChung = value
        End Set
    End Property
    'Khai báo thuộc tính Thời hạn sử dụng đất
    Public Property ThoiHan() As String
        Get
            Return strThoiHan
        End Get
        Set(ByVal value As String)
            strThoiHan = value
        End Set
    End Property
    'Khai báo thuộc tính ghi chú
    Public Property GhiChu() As String
        Get
            Return strGhiChu
        End Get
        Set(ByVal value As String)
            strGhiChu = value
        End Set
    End Property

#Region "Cập nhật thông tin Mục đích sử dụng"
    Public Function DeleteMucDichByMaMucDichSuDung(ByRef strResults As String) As String
        Return Me.Execute("spDeleteMucDichByMaMucDichSuDung", strResults)
    End Function

    Public Function InsertMucDich(ByRef strResults As String) As String
        Return Me.Execute("spInsertMucDich", strResults)
    End Function

    Public Function UpdateMucDich(ByRef strResults As String) As String
        Return Me.Execute("spUpdateMucDich", strResults)
    End Function

#End Region



    ''' <summary>
    ''' Hàm thực thi phát biểu SQL
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên  Thủ tục trong SQL Server</param>
    ''' <param name="strResults"></param>
    ''' <returns>Kết quả trả về là biến lỗi</returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaMucDichSuDung, strMaThuaDatCapGCN, strKyHieu, strKyHieuKiemKe _
                 , strKyHieuQuiHoach, strChiTiet, dblDienTichKeKhai, dblDienTichRieng _
                 , dblDienTichChung, strThoiHan, strGhiChu, strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function GetData(ByRef records As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai  báo mảng giá trị
                Dim Values() As String = _
                {strMaMucDichSuDung, strMaThuaDatCapGCN, strKyHieu, strKyHieuKiemKe _
                 , strKyHieuQuiHoach, strChiTiet, dblDienTichKeKhai, dblDienTichRieng _
                 , dblDienTichChung, strThoiHan, strGhiChu, strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Database.getValue(records, "spSelectMucDich", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class

