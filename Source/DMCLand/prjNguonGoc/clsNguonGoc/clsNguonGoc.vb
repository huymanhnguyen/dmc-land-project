
'Ngày hiệu chỉnh gần nhất: 200807
'Danh sách người thực hiện: Vũ Lê Thành,
'Mô tả:
'Khai bao mang tham so
Imports DMC.Database
Public Class clsNguonGoc
    Dim Paras() As String = {"@MaNguonGoc", "@MaThuaDatCapGCN" _
        , "@KyHieu", "@DienTich", "@ChiTiet", "@GhiChu"}

    Private strConnection As String = "" ' Khai báo biến nhận chuỗi kết nối cơ sở dữ liệu
    Private strError As String     'Khai báo biến kiểm tra lỗi
    Private strMaNguonGoc As String
    Private strMaThuaDatCapGCN As String
    Private strKyHieu As String
    Private dblDienTich As String
    Private strChiTiet As String
    Private strGhiChu As String

    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
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
    'Khai báo thuộc tính Mã nguồn gốc sử dụng
    Public Property MaNguonGoc() As String
        Get
            Return strMaNguonGoc
        End Get
        Set(ByVal value As String)
            strMaNguonGoc = value
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
    'Khai báo thuộc tính Ký hiệu Nguồn gốc sử dụng
    Public Property KyHieu() As String
        Get
            Return strKyHieu
        End Get
        Set(ByVal value As String)
            strKyHieu = value
        End Set
    End Property
    'Khai báo thuộc tính Diện tích tương ứng với từng Nguồng gốc sử dụng
    Public Property DienTich() As String
        Get
            Return dblDienTich
        End Get
        Set(ByVal value As String)
            dblDienTich = value
        End Set
    End Property
    'Khai báo thuộc tính Chi tiết nguồn gốc sử dụng
    Public Property ChiTiet() As String
        Get
            Return strChiTiet
        End Get
        Set(ByVal value As String)
            strChiTiet = value
        End Set
    End Property
    'Khai báo thuộc tính Ghi chú nguồn gốc sử dụng
    Public Property GhiChu() As String
        Get
            Return strGhiChu
        End Get
        Set(ByVal value As String)
            strGhiChu = value
        End Set
    End Property

    Public Function DeleteNguonGocSuDungDatByMaThuaDatCapGCN(ByRef strRecords As String) As String
        Return Me.Execute("spDeleteNguonGocSuDungDatByMaThuaDatCapGCN", strRecords)
    End Function

    Public Function DeleteNguonGocSuDungDatByMaNguonGoc(ByRef strRecords As String) As String
        Return Me.Execute("spDeleteNguonGocSuDungDatByMaNguonGoc", strRecords)
    End Function

    Public Function InsertNguonGocSuDungDat(ByRef strRecords As String) As String
        Return Me.Execute("spInsertNguonGocSuDungDat", strRecords)
    End Function

    Public Function UpdateNguonGocSuDungDat(ByRef strRecords As String) As String
        Return Me.Execute("spUpdateNguonGocSuDungDat", strRecords)
    End Function
    '
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef records As String) As String
        Try
            'Khai báo và khởi tạo lớp Truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị tham số truyền vào
                Dim Values() As String = _
                {strMaNguonGoc, strMaThuaDatCapGCN, strKyHieu, dblDienTich _
                   , strChiTiet, strGhiChu}
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, Paras, Values, records)
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
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaNguonGoc, strMaThuaDatCapGCN, strKyHieu, dblDienTich _
                   , strChiTiet, strGhiChu}
                'Gọi phương thức thực thi thủ tục SQL
                Database.getValue(records, "spSelectNguonGocSuDungDatByMaThuaDatCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
