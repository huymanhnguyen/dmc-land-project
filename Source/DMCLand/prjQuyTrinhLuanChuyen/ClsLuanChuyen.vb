Imports DMC.Database
Imports System.Data.SqlClient

Public Class ClsLuanChuyen
    Private strConnection As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strToBanDo As String = ""
    Private strSoThua As String = ""
    Private strDienTich As String = ""
    Private strDiaChi As String = ""
    Private strThoiDiemChuyen As String = ""
    Private strError As String = ""
    Private strThoiDiemNhan As String = ""
    Private strTenNguoiTiepNhan As String = ""
    Private strTenNguoiKeKhai As String = ""
    Private strTrangThai As String = ""
    Private strDaTraHS As String = ""
    Private strDieuKien As String = ""
    Private strLyDoKhongDuDK As String = ""
    Private strDonViXuLy As String = ""
    Private strNgayBaoCao As String = ""

    Dim Paras() As String = {"@MaDonViHanhChinh", "@MaHoSoCapGCN", "@ToBanDo", "@SoThua", "@DienTich", "@DiaChi", "@TrangThai", "@ThoiDiemChuyen", "@DuDieuKien", "@LyDoKhongDuDK"}
    Dim ParaVPNhaDat() As String = {"@MaDonViHanhChinh", "@MaHoSoCapGCN", "@ToBanDo", "@SoThua", "@DienTich", "@DiaChi", "@TrangThai", "@ThoiDiemTiepNhan", "@TenNguoiTiepNhan", "@TenNguoiDiKeKhai", "@ThoiDiemChuyen", "@DuDieuKien", "@LyDoKhongDuDK"}
    Dim para() As String = {"@MaDonViHanhChinh", "@MaHoSoCapGCN", "@TrangThai", "@ThoiDiemChuyen", "@DuDieuKien", "@LyDoKhongDuDK"}
    'Khai báo thuộc tính gán chuỗi kết nối cơ sở dữ liệu
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property

    Public Property NgayBaoCao() As String
        Get
            Return strNgayBaoCao
        End Get
        Set(ByVal value As String)
            strNgayBaoCao = value
        End Set
    End Property

    Public Property DonViXuLy() As String
        Get
            Return strDonViXuLy
        End Get
        Set(ByVal value As String)
            strDonViXuLy = value
        End Set
    End Property

    Public Property DieuKien() As String
        Get
            Return strDieuKien
        End Get
        Set(ByVal value As String)
            strDieuKien = value
        End Set
    End Property

    Public Property LyDoKhongDuDK() As String
        Get
            Return strLyDoKhongDuDK
        End Get
        Set(ByVal value As String)
            strLyDoKhongDuDK = value
        End Set
    End Property

    Public Property DaTraHS() As String
        Get
            Return strDaTraHS
        End Get
        Set(ByVal value As String)
            strDaTraHS = value
        End Set
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
    Public Property TrangThai() As String
        Get
            Return strTrangThai
        End Get
        Set(ByVal value As String)
            strTrangThai = value
        End Set
    End Property

    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property ToBanDo() As String
        Get
            Return strToBanDo
        End Get
        Set(ByVal value As String)
            strToBanDo = value
        End Set
    End Property
    Public Property SoThua() As String
        Get
            Return strSoThua
        End Get
        Set(ByVal value As String)
            strSoThua = value
        End Set
    End Property

    Public Property DienTich() As String
        Get
            Return strDienTich
        End Get
        Set(ByVal value As String)
            strDienTich = value
        End Set
    End Property
    Public Property DiaChi() As String
        Get
            Return strDiaChi
        End Get
        Set(ByVal value As String)
            strDiaChi = value
        End Set
    End Property
    Public Property ThoiDiemChuyen() As String
        Get
            Return strThoiDiemChuyen
        End Get
        Set(ByVal value As String)
            strThoiDiemChuyen = value
        End Set
    End Property
    Public Property ThoiDiemNhan() As String
        Get
            Return strThoiDiemNhan
        End Get
        Set(ByVal value As String)
            strThoiDiemNhan = value
        End Set
    End Property
    Public Property TenNguoiNhan() As String
        Get
            Return strTenNguoiTiepNhan
        End Get
        Set(ByVal value As String)
            strTenNguoiTiepNhan = value
        End Set
    End Property
    Public Property TenNguoiKeKhai() As String
        Get
            Return strTenNguoiKeKhai
        End Get
        Set(ByVal value As String)
            strTenNguoiKeKhai = value
        End Set
    End Property

    'Khai báo thuộc tính thông báo lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    Private Function ExecuteLenVPNhaDat(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "2"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertVPNhaDat(ByRef strResults As String) As String
        Return Me.ExecuteLenVPNhaDat("InsertLuanChuyenVPNhaDat", strResults)
    End Function


    Private Function ExecuteLuanChuyenTiepNhan(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "2"
                Dim ValueVPNhaDat() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich, strDiaChi, strtrangthai, strThoiDiemNhan, strTenNguoiTiepNhan, strTenNguoiKeKhai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (ParaVPNhaDat.Length <> ValueVPNhaDat.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, ParaVPNhaDat, ValueVPNhaDat, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function



    Public Function InsertLuanChuyenTiepNhan(ByRef strResults As String) As String
        Return Me.ExecuteLuanChuyenTiepNhan("InsertLuanChuyenTiepNhan", strResults)
    End Function

    '///////////// lên văn phòng thẩm đinh


    Private Function ExecuteLenVPThamDinh(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "3"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertVPThamDinh(ByRef strResults As String) As String
        Return Me.ExecuteLenVPThamDinh("InsertLuanChuyenVPThamDinh", strResults)
    End Function




    Private Function ExecuteUpDatVPNhaDat(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "3"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatVPNhaDat(ByRef strResults As String) As String
        Return Me.ExecuteUpDatVPNhaDat("UpdateVPNhaDat", strResults)
    End Function

    '///////////////////////////////////////////
    '///////////// lên phòng TNMT

    Private Function ExecuteLenPhongTNMT(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "4"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertPhongTNMT(ByRef strResults As String) As String
        Return Me.ExecuteLenPhongTNMT("InsertLuanChuyenPhongTNMT", strResults)
    End Function


    Private Function ExecuteUpDatPThamDinh(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "4"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatPThamDinh(ByRef strResults As String) As String
        Return Me.ExecuteUpDatPThamDinh("UpdateVPThamDinh", strResults)
    End Function
    '//////////////////////////////////////////////
    '///////////////////////////////////////////
    '///////////// lên UBThamDinh

    Private Function ExecuteLenUBThamDinh(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "5"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertUBThamDinh(ByRef strResults As String) As String
        Return Me.ExecuteLenUBThamDinh("InsertLuanChuyenUBThamDinh", strResults)
    End Function



    Private Function ExecuteUpDateTNMT(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "5"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatTNMT(ByRef strResults As String) As String
        Return Me.ExecuteUpDateTNMT("UpdateTNMT", strResults)
    End Function


    '//////////////////////////////////////////////
    '///////////////////////////////////////////
    '///////////// Insert Lại Vào bảng TNMT

    Private Function ExecuteLaiTNMT(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "6"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertLaiTNMT(ByRef strResults As String) As String
        Return Me.ExecuteLaiTNMT("InsertLaiPhongTNMT", strResults)
    End Function


    '/// UpData UBThamDinh



    Private Function ExecuteUpDateUBTD(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "6"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatUBThamDinh(ByRef strResults As String) As String
        Return Me.ExecuteUpDateUBTD("UpdateUBTD", strResults)
    End Function

    '///////////////////////////////////////////
    '///////////// Insert LạiVPNhaDat

    Private Function ExecuteLaiVPNhaDat(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "7"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertLaiVPNhaDat(ByRef strResults As String) As String
        Return Me.ExecuteLaiVPNhaDat("InsertLaiVPNhaDat", strResults)
    End Function




    Private Function ExecuteUpDateTNMTLan2(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "7"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatTNMTLan2(ByRef strResults As String) As String
        Return Me.ExecuteUpDateTNMTLan2("UpdateTNMTLan2", strResults)
    End Function


    '///////////////////////////////////////////
    '///////////// Insert Lại Nơi Tiếp Nhận

    Private Function ExecuteLaiNoiTiepNhan(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "8"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertLaiNoiTiepNhan(ByRef strResults As String) As String
        Return Me.ExecuteLaiNoiTiepNhan("InsertLuanChuyenLaiTiepNhan", strResults)
    End Function

    '////////////////// UPDATE VPNHADAT LẦN 2


    Private Function ExecuteUpDateVPNhaDatLan2(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim strtrangthai As String = "8"
                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strtrangthai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, para, Values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    Public Function UpdatVPNhaDatLan2(ByRef strResults As String) As String
        Return Me.ExecuteUpDateVPNhaDatLan2("UpdateVPNhaDatLan2", strResults)
    End Function

    Private Function ExecuteLuanChuyenTheoDoi(ByVal strStoreProcedureName As String, ByRef strResults As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị

                Dim Values() As String = _
                {strMaDonViHanhChinh, strMaHoSoCapGCN, strToBanDo, strSoThua, strDienTich _
                 , strDiaChi, strTrangThai, strThoiDiemChuyen, strDieuKien, strLyDoKhongDuDK}
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


    Public Function InsertLuanChuyenTheoDoi(ByRef strResults As String) As String
        Return Me.ExecuteLuanChuyenTheoDoi("InsertLuanChuyenTheoDoi", strResults)
    End Function

    Private Function Execute(ByVal strStoreProcedureName As String, ByVal Paras() As String, ByVal values() As String, ByVal strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức thực thi thủ tục SQL
                Database.ExecuteSP(strStoreProcedureName, Paras, values, strRecords)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable, ByVal paras() As String, ByVal Values() As String) As String
        Try
            'Khởi tạo đối tượng cơ sở dữ liệu clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Nếu kết nối cơ sở dữ liệu thành công
                'Khai báo mảng giá trị
                'Dim Values() As String = {strHoTen, strDiaChi}
                'Gọi phưong thức nhận dữ liệu của đối tượng clsDatabase
                Database.getValue(dtResults, strStoreProcedureName, paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function



    Public Function UpHoSoHoanThanh() As String
        Dim paras() As String = {"@MaDonViHanhChinh", "@MaHoSoCapGCN", "@DaTra"}
        Dim values() As String = {strMaDonViHanhChinh, strMaHoSoCapGCN, strDaTraHS}
        Return Execute("spUpdateLuanChuyenHSHoanThanh", paras, values, "")
    End Function


    Public Function UpHoSoDuDKHoSo(ByVal storeName As String) As String
        Dim paras() As String = {"@MaDonViHanhChinh", "@MaHoSoCapGCN", "@DuDieuKien", "@LyDoKhongDuDK"}
        Dim values() As String = {strMaDonViHanhChinh, strMaHoSoCapGCN, strDieuKien, strLyDoKhongDuDK}
        Return Execute(storeName, paras, values, "")
    End Function

    Public Function selBaoCaoMotCua(ByVal flag As String, ByVal dt As DataTable) As String
        Dim paras() As String = {"@flag", "@MaDonViHanhChinh", "@DonViXuLy", "@NgayBaoCao"}
        Dim values() As String = {flag, strMaDonViHanhChinh, strDonViXuLy, strNgayBaoCao}
        Return GetData("spXuatBaoCaoLuanChuyenHoSo", dt, paras, values)
    End Function



    Public Function TenDVHC() As String
        Dim conn As New SqlConnection
        Dim strDVHC As String
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        Dim s As String = "SELECT Ten FROM tblTuDienDonViHanhChinh where MaDonViHanhChinh=" & strMaDonViHanhChinh.ToString
        conn.ConnectionString = strConnection
        conn.Open()
        Dim da As New SqlDataAdapter(s, strConnection)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            strDVHC = dt.Rows(0).Item("ten")
        Else
            strDVHC = ""
        End If
        Return strDVHC
    End Function
    Public Sub InBaoCaoHoSo(ByVal DonVi As String, ByVal dtp As DateTimePicker)

        'Khai bao va khoi tao doi tuong clsTimKiem
        Dim frm As New FrmBaoCao
        Dim TimKiem As New ClsLuanChuyen
        Dim dt As New DataTable
        Dim dtDuDK As New DataTable
        Dim dtDuKoDK As New DataTable

        Dim strTenDonViHanhChinh As String = TenDVHC()
        With TimKiem
            'Gán chuỗi kết nối Database cho clsTimKiem
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            .DonViXuLy = DonVi
        End With
        Try
            Select Case DonVi
                Case "1Cua"
                    TimKiem.NgayBaoCao = FormatDateTime(dtp.Value, DateFormat.ShortDate).ToString
                    TimKiem.selBaoCaoMotCua(0, dt)
                    TimKiem.selBaoCaoMotCua(11, dtDuDK)
                    TimKiem.selBaoCaoMotCua(12, dtDuKoDK)
                    If dt.Rows.Count > 0 Then
                        dt.Columns.Add("TieuDeBC")
                        dt.Columns.Add("TenDVHC")
                        dt.Columns.Add("NgayBC")
                        dt.Rows(0).Item("TieuDeBC") = "HỒ SƠ CHUYỂN TỪ ĐƠN VỊ MỘT CỬA"
                        dt.Rows(0).Item("TenDVHC") = strTenDonViHanhChinh
                        dt.Rows(0).Item("NgayBC") = "Ngày " & dtp.Value.Day.ToString & " tháng " & dtp.Value.Month.ToString & " năm " & dtp.Value.Year.ToString
                    End If
                Case "VP"
                    TimKiem.NgayBaoCao = FormatDateTime(dtp.Value, DateFormat.ShortDate).ToString
                    TimKiem.selBaoCaoMotCua(0, dt)
                    TimKiem.selBaoCaoMotCua(21, dtDuDK)
                    TimKiem.selBaoCaoMotCua(22, dtDuKoDK)
                    If dt.Rows.Count > 0 Then
                        dt.Columns.Add("TieuDeBC")
                        dt.Columns.Add("TenDVHC")
                        dt.Columns.Add("NgayBC")
                        dt.Rows(0).Item("TieuDeBC") = "HỒ SƠ CHUYỂN TỪ CÁN BỘ VĂN PHÒNG ĐĂNG KÝ ĐẤT NHÀ"
                        dt.Rows(0).Item("TenDVHC") = strTenDonViHanhChinh
                        dt.Rows(0).Item("NgayBC") = "Ngày " & dtp.Value.Day.ToString & " tháng " & dtp.Value.Month.ToString & " năm " & dtp.Value.Year.ToString
                    End If
                Case "LDVP"
                    TimKiem.NgayBaoCao = FormatDateTime(dtp.Value, DateFormat.ShortDate).ToString
                    TimKiem.selBaoCaoMotCua(0, dt)
                    TimKiem.selBaoCaoMotCua(31, dtDuDK)
                    TimKiem.selBaoCaoMotCua(32, dtDuKoDK)
                    If dt.Rows.Count > 0 Then
                        dt.Columns.Add("TieuDeBC")
                        dt.Columns.Add("TenDVHC")
                        dt.Columns.Add("NgayBC")
                        dt.Rows(0).Item("TieuDeBC") = "HỒ SƠ CHUYỂN THẨM ĐỊNH TỪ VĂN PHÒNG ĐĂNG KÝ ĐẤT NHÀ"
                        dt.Rows(0).Item("TenDVHC") = strTenDonViHanhChinh
                        dt.Rows(0).Item("NgayBC") = "Ngày " & dtp.Value.Day.ToString & " tháng " & dtp.Value.Month.ToString & " năm " & dtp.Value.Year.ToString
                    End If
                Case "TNMT"
                    TimKiem.NgayBaoCao = FormatDateTime(dtp.Value, DateFormat.ShortDate).ToString
                    TimKiem.selBaoCaoMotCua(0, dt)
                    TimKiem.selBaoCaoMotCua(41, dtDuDK)
                    TimKiem.selBaoCaoMotCua(42, dtDuKoDK)
                    If dt.Rows.Count > 0 Then
                        dt.Columns.Add("TieuDeBC")
                        dt.Columns.Add("TenDVHC")
                        dt.Columns.Add("NgayBC")
                        dt.Rows(0).Item("TieuDeBC") = "HỒ SƠ CHUYỂN TỪ PHÒNG TÀI NGUYÊN MÔI TRƯỜNG"
                        dt.Rows(0).Item("TenDVHC") = strTenDonViHanhChinh
                        dt.Rows(0).Item("NgayBC") = "Ngày " & dtp.Value.Day.ToString & " tháng " & dtp.Value.Month.ToString & " năm " & dtp.Value.Year.ToString
                    End If
                Case "UB"
                    TimKiem.NgayBaoCao = FormatDateTime(dtp.Value, DateFormat.ShortDate).ToString
                    TimKiem.selBaoCaoMotCua(0, dt)
                    TimKiem.selBaoCaoMotCua(51, dtDuDK)
                    TimKiem.selBaoCaoMotCua(52, dtDuKoDK)
                    If dt.Rows.Count > 0 Then
                        dt.Columns.Add("TieuDeBC")
                        dt.Columns.Add("TenDVHC")
                        dt.Columns.Add("NgayBC")
                        dt.Rows(0).Item("TieuDeBC") = "HỒ SƠ CHUYỂN TỪ UBND QUẬN"
                        dt.Rows(0).Item("TenDVHC") = strTenDonViHanhChinh
                        dt.Rows(0).Item("NgayBC") = "Ngày " & dtp.Value.Day.ToString & " tháng " & dtp.Value.Month.ToString & " năm " & dtp.Value.Year.ToString
                    End If
            End Select


            Dim strFileBaoCao As String = ""
            strFileBaoCao = Application.StartupPath & "\Reports\BCLuanChuyen\rptBaoCaoLuanChuyenHoSo.rpt" 'fileReport(strChonIn.ToString.ToUpper.Trim)
            frm.DB = dt
            frm.DBDTDuDK = dtDuDK
            frm.DBDTKhongDuDK = dtDuKoDK
            frm.FileReport = strFileBaoCao
            frm.LoadReport()
            frm.Show()
        Catch ex As Exception
            strError = ex.Message
            MsgBox(vbNewLine & "Lỗi: " & vbNewLine + ex.Message, MsgBoxStyle.Information, "DMCLand")
        End Try
    End Sub
    Public Function fileReport(ByVal LoaiBC As String) As String
        Dim ViTri As Short
        Dim path As String
        ViTri = InStr(4, Application.ExecutablePath, "\", CompareMethod.Binary)
        path = Application.ExecutablePath.Substring(0, ViTri) & Application.ProductName
        Dim file As String = ""
        Select Case LoaiBC
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN VĂN PHÒNG NHÀ ĐẤT".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptVPNhaDatDaNhan.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN VĂN PHÒNG THẨM ĐỊNH".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoVPThamDinhDaNhan.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN PHÒNG TÀI NGUYÊN MÔI TRƯỜNG".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoPhongTNMTNhan.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ CHUYỂN LÊN UB THẨM ĐỊNH".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoUBTHAMDINHDANHAN.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ TNMT".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoPhongTNMTNhanLaiTuUBTD.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ VP NHÀ ĐẤT".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoVPNhaDatDaNhanLaiTuTNMT.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ TRẢ VỀ NƠI TIẾP NHẬN".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoNoiTiepNhanNhanLaiTuVPNhaDat.rpt"
            Case "DANH SÁCH HỒ SƠ ĐÃ HOÀN TẤT".ToUpper
                file = Application.StartupPath & "\Reports\ReportsBC\rptHoSoHoanTraChoNguoiDan.rpt"
        End Select

        Return file
    End Function


    Public Sub CheckGrid(ByVal grd As DataGridView, ByVal chk As CheckBox)
        If chk.Checked Then
            For i As Integer = 0 To grd.RowCount - 1
                grd.Rows(i).Cells("Chon").Value = True
            Next
        Else
            For i As Integer = 0 To grd.RowCount - 1
                grd.Rows(i).Cells("Chon").Value = False
            Next
        End If
    End Sub

    Public Sub LayThongTin(ByVal grd As DataGridView, ByVal rID As Integer, ByVal chk As CheckBox, ByVal txt As TextBox)
        If rID >= 0 Then
            If grd.Rows(rID).Cells("DuDieuKien").Value.ToString = "True" Then
                chk.Checked = True
                txt.Text = grd.Rows(rID).Cells("LyDoKhongDuDK").Value.ToString
            Else
                chk.Checked = False
                txt.Text = grd.Rows(rID).Cells("LyDoKhongDuDK").Value.ToString
            End If
        End If
    End Sub


    Public Sub UpdateThongTinCheck(ByVal grd As DataGridView, ByVal rID As Integer, ByVal chk As CheckBox)
        If rID >= 0 Then
            If chk.Checked Then
                grd.Rows(rID).Cells("DuDieuKien").Value = True
            Else
                grd.Rows(rID).Cells("DuDieuKien").Value = False
            End If
        End If
    End Sub
    Public Sub UpdateThongTinLyDo(ByVal grd As DataGridView, ByVal rID As Integer, ByVal chk As CheckBox, ByVal txt As TextBox)
        If rID >= 0 Then
            If chk.Checked Then
                grd.Rows(rID).Cells("LyDoKhongDuDK").Value = ""
            Else
                grd.Rows(rID).Cells("LyDoKhongDuDK").Value = txt.Text
            End If
        End If
    End Sub
    Public Sub CapNhatDieuKienHoSo(ByVal storeName As String, ByVal grd As DataGridView)
        Dim cls As New ClsLuanChuyen
        With cls
            .Connection = strConnection
            .MaDonViHanhChinh = strMaDonViHanhChinh
            For i As Integer = 0 To grd.Rows.Count - 1
                If grd.Rows(i).Cells("Chon").Value.ToString = "True" Then
                    .MaHoSoCapGCN = grd.Rows(i).Cells("MaHoSoCapGCN").Value.ToString
                    If grd.Rows(i).Cells("DuDieuKien").Value.ToString = "True" Then
                        .DieuKien = "1"
                    Else
                        .DieuKien = "0"
                    End If
                    .LyDoKhongDuDK = grd.Rows(i).Cells("LyDoKhongDuDK").Value.ToString
                    .UpHoSoDuDKHoSo(storeName)
                End If
            Next


        End With
    End Sub

    Public Sub ChangeTile(ByVal grd As DataGridView)
        With grd
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).Visible = False
            Next

            .Columns("MaHoSoCapGCN").HeaderText = "Mã Hồ Sơ Cấp GCN"
            .Columns("MaHoSoCapGCN").Visible = False
            .Columns("ToBanDo").HeaderText = "Tờ Bản Đồ"
            .Columns("ToBanDo").Width = 100
            .Columns("ToBanDo").Visible = True

            .Columns("SoThua").HeaderText = "Số Thửa"
            .Columns("SoThua").Width = 100
            .Columns("SoThua").Visible = True

            .Columns("DiaChi").HeaderText = "Địa Chỉ"
            .Columns("DiaChi").Width = 300
            .Columns("DiaChi").Visible = True


            .Columns("DienTich").HeaderText = "Diện Tích"
            .Columns("DienTich").Width = 100
            .Columns("DienTich").Visible = True

            .Columns("NgayNhanChuyenVe").HeaderText = "Ngày Nhận Hồ Sơ"
            .Columns("NgayNhanChuyenVe").Width = 150
            .Columns("NgayNhanChuyenVe").Visible = True

            .Columns("DuDieuKien").HeaderText = "Có/Không đủ ĐK"
            .Columns("DuDieuKien").Width = 150
            .Columns("DuDieuKien").Visible = True

            .Columns("LyDoKhongDuDK").HeaderText = "Lý do không đủ ĐK"
            .Columns("LyDoKhongDuDK").Width = 200
            .Columns("LyDoKhongDuDK").Visible = True

            .Columns("DaXuLy").HeaderText = "HS xử lý/chưa xử lý"
            .Columns("DaXuLy").Width = 200
            .Columns("DaXuLy").Visible = True

            .Columns("SoLan").HeaderText = "Số lần xử lý"
            .Columns("SoLan").Width = 100
            .Columns("SoLan").Visible = True

        End With
    End Sub
    Public Sub checkColumn(ByRef grdvw As DataGridView, ByVal intRowIndex As Int32, ByVal intColumnIndex As Int32)
        If (intRowIndex) < 0 Then
            Exit Sub
        End If
        If intColumnIndex >= 0 Then
            If grdvw.Columns(intColumnIndex).Name.ToUpper() = "chon".ToUpper Then
                If (grdvw.Rows(intRowIndex).Cells("Chon").Value.ToString = "") Then
                    grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
                Else
                    If (grdvw.Rows(intRowIndex).Cells("Chon").Value = True) Then
                        grdvw.Rows(intRowIndex).Cells("Chon").Value = "False"
                    Else
                        grdvw.Rows(intRowIndex).Cells("Chon").Value = "True"
                    End If
                End If
            End If
        End If
    End Sub
End Class

