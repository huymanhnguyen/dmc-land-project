Imports DMC.Database
Public Class clsTimKiemHoSo
    Private paraCapGCN() As String = {"@MaDonViHanhChinh", "@SoPhatHanhGCN", "@SoVaoSoCapGCN", "@SoQuyetDinhCapGCN", "@SoToTrinh", "@NamTrinh", "@NgayQuyetDinhCapGCN", "@IsCoBanDo"}
    Private paraThuaDat() As String = {"@MaDonViHanhChinh", "@ToBanDo", "@SoThua", "@DiaChiThua", "@IsCoBanDo"}
    Private paraHoSo() As String = {"@MaDonViHanhChinh", "@TrangThaiHoSoCapGCN", "@SoPhatHanhGCN", "@SoVaoSoCapGCN", "@SoQuyetDinhCapGCN", "@SoHoSo", "@SoThuTuHoSo", "@IsCoBanDo"} '{"@MaDonViHanhChinh", "@HoanTatHoSoKeKhai", "@HoanTatThamDinh", "@HoanTatPheDuyet", "@SoPhatHanhGCN", "@SoVaoSoCapGCN", "@SoQuyetDinhCapGCN", "@HoanTatCapGCN", "@SoHoSo", "@SoThuTuHoSo"}
    Private paraChuSuDung() As String = {"@MaDonViHanhChinh", "@TenChuSuDung", "@SoDinhDanh", "@IsCoBanDo"}
    Dim paraChu() As String = {"@MaHoSoCapGCN"}
    'Khai báo chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strToBanDo As String = ""
    Private strSoThua As String = ""
    Private dblDienTichTuNhien As Double
    Private strToBanDoKKhai As String = ""
    Private strSoThuaKKhai As String = ""
    Private dblDTichTNhienKKhai As Double
    Private dblDienTichRieng As Double
    Private dblDienTichChung As Double
    Private strDiaChiThua As String = ""
    Private strHoanTatHoSoKeKhai As String = ""
    Private strHoanTatThamDinh As String = ""
    Private strHoanTatPheDuyet As String = ""
    Private strHoanTatCapGCN As String = ""
    Private strSoPhatHanhGCN As String = ""
    Private strSoVaoSoCapGCN As String = ""
    Private strSoQuyetDinhCapGCN As String = ""
    Private strTenChu As String = ""
    Private strSoDinhDanh As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strTrangThaiHoSoCapGCN As String = ""
    Private strHoSo As String
    Private strSoThuTuHoSo As String
    Private strIsBanDo As String

    Private strNamTrinh As String
    Private strSoToTrinh As String
    Private strNgayQuyetDinhCapGCN As String

    Private strMaThuaDat As String = ""
    Private strMaXa As String = ""

    Public Property MaXa() As String
        Get
            Return strMaXa
        End Get
        Set(ByVal value As String)
            strMaXa = value
        End Set
    End Property


    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
    End Property

    Public Property TrangThaiHoSoCapGCN() As String
        Get
            Return strTrangThaiHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strTrangThaiHoSoCapGCN = value
        End Set
    End Property
    Public Property SoHoSo() As String
        Get
            Return strHoSo
        End Get
        Set(ByVal value As String)
            strHoSo = value
        End Set
    End Property
    Public Property SoThuTuHoSo() As String
        Get
            Return strSoThuTuHoSo
        End Get
        Set(ByVal value As String)
            strSoThuTuHoSo = value
        End Set
    End Property
    Public Property NamTrinh() As String
        Get
            Return strNamTrinh
        End Get
        Set(ByVal value As String)
            strNamTrinh = value
        End Set
    End Property
    Public Property SoToTrinh() As String
        Get
            Return strSoToTrinh
        End Get
        Set(ByVal value As String)
            strSoToTrinh = value
        End Set
    End Property
    Public Property NgayQuyetDinhCapGCN() As String
        Get
            Return strNgayQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strNgayQuyetDinhCapGCN = value
        End Set
    End Property

    'Khai báo thuộc tính gán chuỗi kết nối cơ sở dữ liệu
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

    'Khai bao thuoc tinh ung voi bien MaDonViHanhChinh
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien ToBanDo
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien strSoThua
    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien dblDienTichTuNhien
    Public Property DienTichTuNhien() As Double
        Get
            Return dblDienTichTuNhien
        End Get
        Set(ByVal value As Double)
            dblDienTichTuNhien = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien ToBanDoKKhai
    Public Property ToBanDoKKhai() As String
        Get
            Return strToBanDoKKhai
        End Get
        Set(ByVal value As String)
            strToBanDoKKhai = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien strSoThuaKKhai
    Public Property SoThuaKKhai() As String
        Get
            Return strSoThuaKKhai
        End Get
        Set(ByVal value As String)
            strSoThuaKKhai = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien dblDTichTNhienKKhai
    Public Property DTichTNhienKKhai() As Double
        Get
            Return dblDTichTNhienKKhai
        End Get
        Set(ByVal value As Double)
            dblDTichTNhienKKhai = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien dblDienTichRieng
    Public Property DienTichRieng() As Double
        Get
            Return dblDienTichRieng
        End Get
        Set(ByVal value As Double)
            dblDienTichRieng = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien dblDienTichChung
    Public Property DienTichChung() As Double
        Get
            Return dblDienTichChung
        End Get
        Set(ByVal value As Double)
            dblDienTichChung = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien strDiaChiThua
    Public Property DiaChiThua() As String
        Get
            Return strDiaChiThua
        End Get
        Set(ByVal value As String)
            strDiaChiThua = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public Property HoanTatHoSoKeKhai() As String
        Get
            Return strHoanTatHoSoKeKhai
        End Get
        Set(ByVal value As String)
            'If value = "" Then
            '    value = 0
            'End If
            strHoanTatHoSoKeKhai = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien
    Public Property HoanTatThamDinh() As String
        Get
            Return strHoanTatThamDinh
        End Get
        Set(ByVal value As String)
            'If value = "" Then
            '    value = 0
            'End If
            strHoanTatThamDinh = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien KetQuaPheDuyet
    Public Property HoanTatPheDuyet() As String
        Get
            Return strHoanTatPheDuyet
        End Get
        Set(ByVal value As String)
            'If value = "" Then
            '    value = 0
            'End If
            strHoanTatPheDuyet = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public Property HoanTatCapGCN() As String
        Get
            Return strHoanTatCapGCN
        End Get
        Set(ByVal value As String)
            'If value = "" Then
            '    value = 0
            'End If
            strHoanTatCapGCN = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien SoPhatHanhGCN
    Public Property SoPhatHanhGCN() As String
        Get
            Return strSoPhatHanhGCN
        End Get
        Set(ByVal value As String)
            strSoPhatHanhGCN = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien SoVaoSoCapGCN
    Public Property SoVaoSoCapGCN() As String
        Get
            Return strSoVaoSoCapGCN
        End Get
        Set(ByVal value As String)
            strSoVaoSoCapGCN = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoQuyetDinhCapGCN() As String
        Get
            Return strSoQuyetDinhCapGCN
        End Get
        Set(ByVal value As String)
            strSoQuyetDinhCapGCN = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien TenNguoiSuDung
    Public Property TenChuSuDung() As String
        Get
            Return strTenChu
        End Get
        Set(ByVal value As String)
            strTenChu = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien SoCMT
    Public Property SoDinhDanh() As String
        Get
            Return strSoDinhDanh
        End Get
        Set(ByVal value As String)
            strSoDinhDanh = value
        End Set
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
    Public Property IsBanDo() As String
        Get
            Return strIsBanDo
        End Get
        Set(ByVal value As String)
            strIsBanDo = value
        End Set
    End Property

    'Public Function Execute(ByRef records As Integer) As String
    '    Try
    '        'Khai báo và khởi tạo đối tượng Database
    '        Dim Database As New clsDatabase
    '        'Neu ket noi co so du lieu thanh cong
    '        Database.Connection = strConnection
    '        If Database.OpenConnection = True Then
    '            'Khai bao mang gia tri
    '            Dim Values() As String = _
    '            {strMaDonViHanhChinh, strToBanDo, strSoThua, strHoanTatHoSoKeKhai, strHoanTatThamDinh _
    '            , strHoanTatPheDuyet, strSoPhatHanhGCN, strSoVaoSoCapGCN, strSoQuyetDinhCapGCN, strHoanTatCapGCN _
    '            , strTenChuSuDung, strSoDinhDanh}
    '            'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
    '            If (Paras.Length <> Values.Length) Then
    '                Return "Mảng giá trị chuyền vào chưa phù hợp!"
    '            End If
    '            'Gọi phương thức ExecuteSp của đối tượng clsDatabase
    '            Database.ExecuteSP("spTimKiem", Paras, Values, records)
    '            strError = Database.Err
    '            Database.CloseConnection()
    '        End If
    '    Catch ex As Exception
    '        strError = ex.Message
    '    End Try
    '    Return strError
    'End Function

    'Public Function GetData(ByRef records As DataTable) As String
    '    Dim strError As String = ""
    '    Try
    '        'Khoi tao doi tuong DMC.clsDatabase
    '        Dim Database As New clsDatabase
    '        Database.Connection = strConnection
    '        If (Database.OpenConnection) Then
    '            'Neu ket noi co so du lieu thanh cong
    '            'Khai bao mang gia tri
    '            Dim Values() As String = _
    '            {strMaDonViHanhChinh, strToBanDo, strSoThua, strHoanTatHoSoKeKhai, strHoanTatThamDinh _
    '            , strHoanTatPheDuyet, strSoPhatHanhGCN, strSoVaoSoCapGCN, strSoQuyetDinhCapGCN, strHoanTatCapGCN _
    '            , strTenChuSuDung, strSoDinhDanh}
    '            'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
    '            If (Paras.Length <> Values.Length) Then
    '                Return "Mảng giá trị chuyền vào chưa phù hợp!"
    '            End If
    '            'Gọi phương thức GetValue của đối tượng clsDatabase
    '            Database.getValue(records, "spTimKiem", Paras, Values)
    '            Database.CloseConnection()
    '            strError = ""
    '        End If
    '    Catch ex As Exception
    '        strError = ex.Message
    '    End Try
    '    Return strError
    'End Function

    Public Function TimKiemHoSoThuaDat(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
        Dim strError As String = ""
        Dim MyTable As New DataTable
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If (Database.OpenConnection) Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> Values.Length) Then
                    Return Nothing
                End If
                'Gọi phương thức GetValue của đối tượng clsDatabase
                Database.getValue(MyTable, sp, paras, Values)
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return MyTable
    End Function

    Public Function SelectGCN() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            '{"@MaDonViHanhChinh", "@SoPhatHanhGCN", "@SoVaoSoCapGCN", "@SoQuyetDinhCapGCN", "@SoToTrinh", "@NamTrinh", "@NamCapGCN"}
            Dim Values() As String = {strMaDonViHanhChinh, strSoPhatHanhGCN, strSoVaoSoCapGCN, strSoQuyetDinhCapGCN, strSoToTrinh, strNamTrinh, strNgayQuyetDinhCapGCN, strIsBanDo}
            dt = TimKiemHoSoThuaDat("spSelectHoSoCapGCN", Values, paraCapGCN)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectThuaDat() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh, strToBanDo, strSoThua, strDiaChiThua, strIsBanDo}
            dt = TimKiemHoSoThuaDat("spSelectThongTinThuaDat", Values, paraThuaDat)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectHoSo() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            '{"@MaDonViHanhChinh", "@HoanTatHoSoKeKhai", "@HoanTatThamDinh", "@HoanTatPheDuyet", "@SoPhatHanhGCN", "@SoVaoSoCapGCN", "@SoQuyetDinhCapGCN", "@HoanTatCapGCN", "@SoHoSo", "@SoThuTuHoSo"}
            Dim Values() As String = {strMaDonViHanhChinh, strTrangThaiHoSoCapGCN, strSoPhatHanhGCN, strSoVaoSoCapGCN, strSoQuyetDinhCapGCN, strHoSo, strSoThuTuHoSo, strIsBanDo}
            dt = TimKiemHoSoThuaDat("spSelectTheoHoSoCapGCN", Values, paraHoSo)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectChu() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {strMaDonViHanhChinh, strTenChu, strSoDinhDanh, strIsBanDo}
            dt = TimKiemHoSoThuaDat("spSelectTheoChuSuDung", Values, paraChuSuDung)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectTongHopChu() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            '"@MaDonViHanhChinh", "@TenChuSuDung", "@SoDinhDanh"
            Dim Values() As String = {strMaHoSoCapGCN}
            dt = TimKiemHoSoThuaDat("sp_selectTenChu", Values, paraChu)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function SelectMaXa() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim paraMaXa() As String = {"@MaDonViHanhChinh"}
            Dim Values() As String = {strMaDonViHanhChinh}
            dt = TimKiemHoSoThuaDat("sp_SelectMaXaByMaDVHC", Values, paraMaXa)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function SelectTuDienTrangThai() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim paraMaXa() As String = {"@flag"}
            Dim Values() As String = {0}
            dt = TimKiemHoSoThuaDat("spSelectValueTrangThaiCapGCN", Values, paraMaXa)
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function

    Public Function InsertHoSoCapGCNCoThongTinKhongGianThuaDat(ByRef strRecords As String) As String
        Return Me.Execute(strRecords, "spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat")
    End Function
    Private Function Execute(ByRef strRecords As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Paras() As String = {"@MaXa", "@ToBanDo", "@SoThua", "@DienTichTuNhien", "@DiaChiThua", "@MaThuaDat", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}
                Dim Values() As String = _
                {strMaXa, strToBanDo, strSoThua, dblDienTichTuNhien, strDiaChiThua, strMaThuaDat, strMaHoSoCapGCN, strMaDonViHanhChinh}
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
            MsgBox("Lỗi thực thi dữ liệu !", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
        End Try
        Return strError
    End Function


    Public Function SelectTuDienDonViHanhChinhByMaXa(ByRef dtResult As DataTable) As String
        Return Me.GetData("spSelectTuDienDonViHanhChinhByMaXa", dtResult)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResult As DataTable) As String
        Dim strError As String = ""
        Try
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Paras() As String = {"@MaDonViHanhChinh"}
                Dim Values() As String = {strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtResult, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            System.Windows.Forms.MessageBox.Show("Lỗi thực thi dữ liệu !", "DMCLand", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return strError
    End Function
End Class
