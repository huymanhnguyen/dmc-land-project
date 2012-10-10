Public Class clsThongTinPhapLyKhac
    'Khai bao mang tham so
    Dim Paras() As String = {"@MaHoSoCapGCN", "@TrangThaiHoSoCapGCN" _
        , "@NgayNopDuHoSoHopLe", "@TrinhTuThuTucPhuong" _
        , "@CacKhoanPhaiNop", "@GhiChuThamDinh", "@LyDo", "@SoSerriToTrinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String = ""
    Private strMaHoSoCapGCN As String
    'Trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Long = 0
    Private dtmNgayNopDuHoSoHopLe As String
    Private strTrinhTuThuTucPhuong As String
    Private strCacKhoanPhaiNop As String
    Private strGhiChuThamDinh As String
    Private strLyDo As String
    Private strSoSerriToTrinh As String = ""

    Public Property SoSerriToTrinh()
        Get
            Return strSoSerriToTrinh
        End Get
        Set(ByVal value)
            strSoSerriToTrinh = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien shFlag
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai bao thuoc tinh ung voi bien strMaHoSoCapGCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai báo thuộc tính Trạng thái Hồ sơ cấp GCN
    Public Property TrangThaiHoSoCapGCN() As Long
        Get
            Return longTrangThaiHoSoCapGCN
        End Get
        Set(ByVal value As Long)
            longTrangThaiHoSoCapGCN = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayNopDuHoSoHopLe() As String
        Get
            Return dtmNgayNopDuHoSoHopLe
        End Get
        Set(ByVal value As String)
            dtmNgayNopDuHoSoHopLe = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property TrinhTuThuTucPhuong() As String
        Get
            Return strTrinhTuThuTucPhuong
        End Get
        Set(ByVal value As String)
            strTrinhTuThuTucPhuong = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property CacKhoanPhaiNop() As String
        Get
            Return strCacKhoanPhaiNop
        End Get
        Set(ByVal value As String)
            strCacKhoanPhaiNop = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property GhiChuThamDinh() As String
        Get
            Return strGhiChuThamDinh
        End Get
        Set(ByVal value As String)
            strGhiChuThamDinh = value
        End Set
    End Property
    Public Property LyDo() As String
        Get
            Return strLyDo
        End Get
        Set(ByVal value As String)
            strLyDo = value
        End Set
    End Property
    ''' <summary>
    ''' Thêm thông tin Thẩm định vào hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function InsertThamDinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN", str)
    End Function
    ''' <summary>
    ''' Cập nhật thông tin Thẩm định theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function UpdateThamDinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThamDinhThongTinPhapLyKhacByMaHoSoCapGCN", str)
    End Function
    ''' <summary>
    ''' Xóa thông tin Thẩm định theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThamDinhByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThamDinhThongTinPhapLyKhacByMaHoSoCapGCN", str)
    End Function
    '
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tựong clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Neu ket noi co so du lieu thanh cong
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaHoSoCapGCN, longTrangThaiHoSoCapGCN.ToString() _
                 , dtmNgayNopDuHoSoHopLe, strTrinhTuThuTucPhuong _
                 , strCacKhoanPhaiNop, strGhiChuThamDinh, strLyDo, strSoSerriToTrinh}
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

    Public Function GetData(ByRef records As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = _
                {strMaHoSoCapGCN, longTrangThaiHoSoCapGCN.ToString() _
                 , dtmNgayNopDuHoSoHopLe, strTrinhTuThuTucPhuong _
                 , strCacKhoanPhaiNop, strGhiChuThamDinh, strLyDo, strSoSerriToTrinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(records, "spSelectThamDinhThongTinPhapLyKhacByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
