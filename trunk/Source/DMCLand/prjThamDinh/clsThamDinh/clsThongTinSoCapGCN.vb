Imports DMC.Database
Public Class clsThongTinSoCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private Paras() As String = {"@MaHoSoCapGCN", "@KyHieuThamQuyenCapGCN" _
        , "@ThuTuVaoSoCapGCN", "@SoVaoSoCapGCN", "@NgayVaoSoCapGCN"}

    Private strMaHoSoCapGCN As String
    Private strKyHieuThamQuyenCapGCN As String
    Private strThuTuVaoSoCapGCN As String
    Private strSoVaoSoCapGCN As String
    Private strNgayVaoSoCapGCN As String
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
    Public Property ThuTuVaoSoCapGCN() As String
        Get
            Return strThuTuVaoSoCapGCN
        End Get
        Set(ByVal value As String)
            strThuTuVaoSoCapGCN = value
        End Set
    End Property
    Public Property SoVaoSoCapGCN() As String
        Get
            Return strSoVaoSoCapGCN
        End Get
        Set(ByVal value As String)
            strSoVaoSoCapGCN = value
        End Set
    End Property

    Public Property NgayVaoSoCapGCN() As String
        Get
            Return strNgayVaoSoCapGCN
        End Get
        Set(ByVal value As String)
            strNgayVaoSoCapGCN = value
        End Set
    End Property

    Public Property KyHieuThamQuyenCapGCN() As String
        Get
            Return strKyHieuThamQuyenCapGCN
        End Get
        Set(ByVal value As String)
            strKyHieuThamQuyenCapGCN = value
        End Set
    End Property

    Public Function SelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa() As DataTable
        Dim dtResults As New DataTable
        Me.SelectSoThuTuVaoSoCapGCNLonNhat("spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapXa", dtResults)
        Return dtResults
    End Function

    Public Function SelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh() As DataTable
        Dim dtResults As New DataTable
        Me.SelectSoThuTuVaoSoCapGCNLonNhat("spSelectSoThuTuVaoSoCapGCNLonNhatTheoCapTinh", dtResults)
        Return dtResults
    End Function

    Private Function SelectSoThuTuVaoSoCapGCNLonNhat(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Dim strParas() As String = {"@MaHoSoCapGCN"}
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (strParas.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn thông tin Sổ quản lý
                Database.getValue(dtResults, strStoreProcedureName, strParas, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Cập nhật thông tin sổ Cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinSoCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinSoCapGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin sổ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinSoCapGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinSoCapGCNByMaHoSoCapGCN", str)
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
                    {strMaHoSoCapGCN, strKyHieuThamQuyenCapGCN, strThuTuVaoSoCapGCN _
                        , strSoVaoSoCapGCN, strNgayVaoSoCapGCN}
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
                    {strMaHoSoCapGCN, strKyHieuThamQuyenCapGCN, strThuTuVaoSoCapGCN _
                        , strSoVaoSoCapGCN, strNgayVaoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn thông tin Sổ quản lý
                Database.getValue(dtResults, "spSelectThongTinSoCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
