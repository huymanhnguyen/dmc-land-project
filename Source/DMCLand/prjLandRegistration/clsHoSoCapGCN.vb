Public Class clsHoSoCapGCN
    'Khai báo mảng tham số
    Dim Paras() As String = {"@MaXa", "@ToBanDo", "@SoThua", "@DienTichTuNhien", "@DiaChiThua", "@MaThuaDat", "@MaHoSoCapGCN", "@MaDonVIHanhChinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String = ""
    Private strMaXa As String
    Private strToBanDo As String
    Private strSoThua As String
    Private dblDienTichTuNhien As String
    Private strDiaChiThua As String
    Private strMaThuaDat As String
    Private strMaHoSoCapGCN As String
    Private strMoTaTrangThai As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strMaUser As String
    Private strMaChucNang As String
    Private strUserName As String
    Private strNgaySuDung As String
    Private strTuSoPhatHanh As String = ""
    Private strDenSoPhatHanh As String = ""

    Public Property TuSoPhatHanh() As String
        Get
            Return strTuSoPhatHanh
        End Get
        Set(ByVal value As String)
            strTuSoPhatHanh = value
        End Set
    End Property

    Public Property DenSoPhatHanh() As String
        Get
            Return strDenSoPhatHanh
        End Get
        Set(ByVal value As String)
            strDenSoPhatHanh = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return strUserName
        End Get
        Set(ByVal value As String)
            strUserName = value
        End Set
    End Property

    Public Property NgaySuDung() As String
        Get
            Return strNgaySuDung
        End Get
        Set(ByVal value As String)
            strNgaySuDung = value
        End Set
    End Property

    Public Property MaChucNang() As String
        Get
            Return strMaChucNang
        End Get
        Set(ByVal value As String)
            strMaChucNang = value
        End Set
    End Property
    Public Property MaUser() As String
        Get
            Return strMaUser
        End Get
        Set(ByVal value As String)
            strMaUser = value
        End Set
    End Property
    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property


    Public Property MoTaTrangThai() As String
        Get
            Return strMoTaTrangThai
        End Get
        Set(ByVal value As String)
            strMoTaTrangThai = value
        End Set
    End Property
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

    'Khai bao thuoc tinh ung voi bien 
    Public Property MaXa() As String
        Get
            Return strMaXa
        End Get
        Set(ByVal value As String)
            strMaXa = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property DienTichTuNhien() As String
        Get
            Return dblDienTichTuNhien
        End Get
        Set(ByVal value As String)
            dblDienTichTuNhien = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property DiaChiThua() As String
        Get
            Return strDiaChiThua
        End Get
        Set(ByVal value As String)
            strDiaChiThua = value
        End Set
    End Property

    'Khai bao thuoc tinh ung voi bien 
    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
        End Set
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
#Region "Thêm mới Hồ sơ cấp GCN khi chưa có thông tin hình học thửa đất trong bảng dữ liệu không gian thửa đất"
    Public Function InsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat(ByRef strRecords As String) As String
        Return Me.Executekhongthuadat(strRecords, "spInsertHoSoCapGCNChuaCoThongTinKhongGianThuaDat")
    End Function
#End Region

    Public Function InsertHoSoCapGCNCoThongTinKhongGianThuaDat(ByRef strRecords As String) As String
        Return Me.Execute(strRecords, "spInsertHoSoCapGCNDaCoThongTinKhongGianThuaDat")
    End Function
    '
    Private Function Execute(ByRef strRecords As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
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
    Private Function Executekhongthuadat(ByRef strRecords As String, ByVal strStoreProcedureName As String) As String
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim strMaThuaDat As String = ""
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

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResult As DataTable) As String
        Dim strError As String = ""
        Try
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaXa, strToBanDo, strSoThua, dblDienTichTuNhien, strDiaChiThua, strMaThuaDat, strMaHoSoCapGCN}
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
            MsgBox("Lỗi nhận dữ liệu thông tin thửa kê khai...", MsgBoxStyle.Information, "Lỗi nhận dữ liệu thông tin thửa kê khai...")
        End Try
        Return strError
    End Function

    ''' <summary>
    ''' Hàm xác định chức năng nghiệp vụ có được Active hay không
    ''' </summary>
    ''' <param name="intMangChucNang">Mảng chức năng mà cán bộ nghiệp vụ có thể thao tác</param>
    ''' <param name="strTenChucNang">Tên chức năng cần kiểm tra xem  có được thao tác
    ''' hay không</param>
    ''' <returns>Kết quả trả về kiểu bool:
    ''' True: Chức năng có tên strTenChucNang có quyền được thực hiện
    ''' False: Chức năng có tên strTenChucNang không có được thực hiện</returns>
    ''' <remarks></remarks>
    Public Function ActiveChucNang(ByVal intMangChucNang As Int32(), ByVal strTenChucNang As String) As Boolean
        Dim boolTemp As Boolean = False
        For i As Integer = 0 To intMangChucNang.Count - 1
            If (intMangChucNang(i).ToString = "5") Then
                If (strTenChucNang = "Tiếp nhận hồ sơ") Then
                    boolTemp = True
                    Exit For
                End If
            ElseIf (intMangChucNang(i).ToString = "6") Then
                If (strTenChucNang = "Hồ sơ kê khai") Then
                    boolTemp = True
                    Exit For
                End If
            ElseIf (intMangChucNang(i).ToString = "7") Then
                If (strTenChucNang = "Xét duyệt cấp cơ sở") Then
                    boolTemp = True
                    Exit For
                End If
            ElseIf (intMangChucNang(i).ToString = "8") Then
                If (strTenChucNang = "Thẩm định") Then
                    boolTemp = True
                    Exit For
                End If
            ElseIf (intMangChucNang(i).ToString = "9") Then
                If (strTenChucNang = "Phê duyệt") Then
                    boolTemp = True
                    Exit For
                End If
            ElseIf (intMangChucNang(i).ToString = "10") Then
                If (strTenChucNang = "Cấp Giấy chứng nhận") Then
                    boolTemp = True
                    Exit For
                End If
            End If
        Next
        Return boolTemp
    End Function
    Public Function SelectMaHoSoCapGCN(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@MaThuaDat", "@ToBanDo", "@SoThua", "@DienTichTuNhien", "@MaDonViHanhChinh"} ', "@HinhDangThua"}
        Dim Values() As String = _
                   {strMaThuaDat, strToBanDo, strSoThua, dblDienTichTuNhien, strMaDonViHanhChinh}
        Return Me.SelectData("spSelectMaHoSoCapGCNByToBanDoSoThua", dtRecords, Paras, Values)
    End Function
    Public Function SelectMaThuaDatInBanDo(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@ToBanDo", "@SoThua", "@MaDonViHanhChinh", "@MaThuaDat"} ', "@HinhDangThua"}
        Dim Values() As String = _
                   {strToBanDo, strSoThua, strMaDonViHanhChinh, strMaThuaDat}
        Return Me.SelectData("spSelectMaHoSoCapGCNByToBanDoSoThuaInBanDo", dtRecords, Paras, Values)
    End Function
    Public Function SelectThongTinHoSo(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@MaHoSoCapGCN"} ', "@HinhDangThua"}
        Dim Values() As String = {strMaHoSoCapGCN}
        Return Me.SelectData("spSelectThongTinChuByMaHoSoCapGCN", dtRecords, Paras, Values)
    End Function
    Public Function SelectTrangThaiHoSo(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@MaHoSoCapGCN"} ', "@HinhDangThua"}
        Dim Values() As String = {strMaHoSoCapGCN}
        Return Me.SelectData("spSelectTrangThaiHoSoCapGCN", dtRecords, Paras, Values)
    End Function
    Public Function SelectGiaTriTrangThaiHoSo(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@MoTa", "@MaDonViHanhChinh"} ', "@HinhDangThua"}
        Dim Values() As String = {3, strMaHoSoCapGCN,strMaDonViHanhChinh }
        Return Me.SelectData("spUpdateTrangThaiHoSoCapGCN", dtRecords, Paras, Values)
    End Function
    Private Function SelectData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable, ByVal paras() As String, ByVal values() As String) As String
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If (Database.OpenConnection = True) Then
                'Neu ket noi co so du lieu thanh cong
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtRecords, strStoreProcedureName, paras, values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function GetFileMap(ByVal flag As Integer, ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@MaHoSo", "MaDonViHanhChinh"}
        Dim Values() As String = _
                   {flag, strMaHoSoCapGCN, strMaDonViHanhChinh}
        Return Me.SelectData("spThongTinFileHSKT", dtRecords, Paras, Values)
    End Function

    Public Sub TrangThaiMoiNhatCuaHoSo(ByVal MaHoSo As String, ByVal MaThuaDat As String)
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim ValueTT() As String = {MaThuaDat, MaHoSo}
                Dim paraTT() As String = {"@MaThuaDat", "@MaHoSoCapGCN"}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paraTT.Length <> ValueTT.Length) Then
                    Exit Sub
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spUpdateTrangThaiLuaChonHoSo", paraTT, ValueTT, "")
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi cơ sở dữ liệu", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
        End Try
    End Sub

    Public Function UpDateDuLieuTuPhuongLenQuan(ByVal flag As Integer) As String
        Dim strKT As String = ""
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                Dim paras() As String = {"@flag", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}
                Dim values() As String = {flag, strMaHoSoCapGCN, strMaDonViHanhChinh}
                If (paras.Length <> values.Length) Then
                    Return "0"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spChuyenThongTinHoSoLenQuan", paras, values, strKT)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi cơ sở dữ liệu", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
            Return "0"
        End Try
        Return strKT
    End Function

    Public Function selKTTonTaiCuaHoSo(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}
        Dim Values() As String = _
                   {2, strMaHoSoCapGCN, strMaDonViHanhChinh}
        Return Me.SelectData("spChuyenThongTinHoSoLenQuan", dtRecords, Paras, Values)
    End Function

    Public Function selKTTonPhuongKhoiTao(ByRef dtRecords As DataTable, ByVal MaDVHC As String) As String
        Dim Paras() As String = {"@flag", "@MaDonViHanhChinh"}
        Dim Values() As String = _
                   {0, MaDVHC}
        Return Me.SelectData("spKhoiTaoDuLieuPhuong", dtRecords, Paras, Values)
    End Function


    Public Function insDVHCKhoiTao(ByVal TenPhuong As String, ByVal TenTat As String, ByVal MaDVHD As String) As String
        Dim strKT As String = ""
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                Dim paras() As String = {"@flag", "@TenTablePhuong", "@TenPhuongDayDu", "@MaDonViHanhChinh"}
                Dim values() As String = {1, TenTat, TenPhuong, MaDVHD}
                If (paras.Length <> values.Length) Then
                    Return "0"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spKhoiTaoDuLieuPhuong", paras, values, strKT)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi cơ sở dữ liệu", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
            Return "0"
        End Try
        Return strKT
    End Function

    Public Function KhoiTaoBangMapByDonViHanhChinh(ByVal TenTat As String, ByVal MaDVHD As String) As String
        Dim strKT As String = ""
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                Dim paras() As String = {"@flag", "@TenDVHC", "@MaDonViHanhChinh"}
                Dim values() As String = {0, TenTat, MaDVHD}
                If (paras.Length <> values.Length) Then
                    Return "0"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spTaoTableMapByDonViHanhChinh", paras, values, strKT)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi cơ sở dữ liệu", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
            Return "0"
        End Try
        Return strKT
    End Function

    Public Function ThaoTacDonViHanhChinhHienThoi(ByVal MaDVHD As String) As String
        Dim strKT As String = ""
        Try
            'Khởi tạo giá trị cho biến nhận thông báo lỗi
            strError = ""
            'Khởi tạo đối tượng thực thi cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nếu kết nối cơ sở dữ liệu thành công
            Database.Connection = GetConnection(bolKetNoiCSDL)
            If Database.OpenConnection = True Then
                Dim paras() As String = {"@MaDonViHanhChinh"}
                Dim values() As String = {MaDVHD}
                If (paras.Length <> values.Length) Then
                    Return "0"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spThaoTacPhuongHienThoi", paras, values, strKT)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi cơ sở dữ liệu", MsgBoxStyle.Information, "Lỗi thực thi cơ sở dữ liệu")
            Return "0"
        End Try
        Return strKT
    End Function

    Public Function SelectAnhThuaDat(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@MaHoSoCapGCN", "@MaDonViHanhChinh"}
        Dim Values() As String = {strMaHoSoCapGCN, strMaDonViHanhChinh}
        Return Me.SelectData("spSelectAnhThuaDat", dtRecords, Paras, Values)
    End Function
    Public Function SelectNhatKyNguoiDung(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@UserName", "@NgaySuDung", "@ToBanDo", "@SoThua", "@MaDonViHanhChinh"} ', "@HinhDangThua"}
        Dim Values() As String = {0, strUserName, strNgaySuDung, strToBanDo, strSoThua, strMaDonViHanhChinh}
        Return Me.SelectData("spNhatKyNguoiDung", dtRecords, Paras, Values)
    End Function
    Public Function SelectChucNangDuocPhanQuyen(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@MaUser", "@MaChucNang"} ', "@HinhDangThua"}
        Dim Values() As String = {4, strMaUser, strMaChucNang}
        Return Me.SelectData("spPhanQuyenByMaUser", dtRecords, Paras, Values)
    End Function
    Public Function SelectHoSoByToBanDoSoThua(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@ToBanDo", "@SoThua", "@MaDonViHanhChinh", "@MaThuaDat"} ', "@HinhDangThua"}
        Dim Values() As String = {0, strToBanDo, strSoThua, strMaDonViHanhChinh, strMaThuaDat}
        Return Me.SelectData("spSelectHoSoByToBanDoSoThua", dtRecords, Paras, Values)
    End Function

    Public Function SelectHoSoBySoPhatHanhGCN(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@flag", "@TuSoPhatHanh", "@DenSoPhatHanh"} ', "@HinhDangThua"}
        Dim Values() As String = {0, strTuSoPhatHanh, strDenSoPhatHanh}
        Return Me.SelectData("spSelectHoSoBySoPhatHanhGCN", dtRecords, Paras, Values)
    End Function

    Public Function SelectTongHopChu(ByRef dtRecords As DataTable) As String
        '"@MaDonViHanhChinh", "@TenChuSuDung", "@SoDinhDanh"
        Dim Paras() As String = {"@MaHoSoCapGCN"}
        Dim Values() As String = {strMaHoSoCapGCN}
        Return Me.SelectData("sp_selectTenChu", dtRecords, Paras, Values) 
    End Function

    Public Function SelectTongHopChuChuyenNhuong(ByRef dtRecords As DataTable) As String 
        Dim Paras() As String = {"@MaHoSoCapGCN"}
        Dim Values() As String = {strMaHoSoCapGCN}
        Return Me.SelectData("spSelectThongTinChuChuyenNhuongByMaHoSoCapGCN", dtRecords, Paras, Values)
    End Function

    Public Function SelectLoaiBienDong(ByRef dtRecords As DataTable) As String
        Dim Paras() As String = {"@MaHoSoCapGCN"}
        Dim Values() As String = {strMaHoSoCapGCN}
        Return Me.SelectData("spSelectLoaiBienDongByHoSoCapGCN", dtRecords, Paras, Values)
    End Function 
  
End Class
