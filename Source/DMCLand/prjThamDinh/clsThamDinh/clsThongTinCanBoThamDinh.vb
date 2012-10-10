Imports DMC.Database

Public Class clsThongTinCanBoThamDinh 'Mới thêm vào Lý do không cấp
    Dim Paras() As String = {"@MaHoSoThamDinh", "@MaHoSoCapGCN", "@DonViThamDinh", "@HoTenCanBoThamDinhDKND" _
            , "@YKienThamDinhDKND", "@KetQuaThamDinhDKND", "@NgayThamDinhDKND", "@HoTenCanBoThamDinhTNMT" _
            , "@YKienThamDinhTNMT", "@KetQuaThamDinhTNMT", "@NgayThamDinhTNMT", "@LyDoKhongCap", "@DienTichCapDatO", "@DienTichCapDatVuon", "@DienTichDatKhongCap", "@YKienKhac", "@GhiChuThamDinh", "@DienTich", "@DienTichBangChu", "@DienTichRieng", _
        "@DienTichChung"}

    ' Khai bao mang nhan ve gia tri Trang Thai Ho So Cap GCN
    Dim Para() As String = {"@Flag", "@MaHoSoCapGCN", "@TrangThai", "@MaDonViHanhChinh"}

    ' Tao mang tham so lay ve Thong Tin HS Chua Tham Dinh
    Dim ParaChuaThamDinh() As String = {"@KetQuaThamDinh", "@MaHoSoCapGCN"}
    ' Tao mang tham so lay ve thong tin HS Da Cap GCN
    Dim ParaDaThamDinh() As String = {"@KetQuaThamDinh", "@MaHoSoCapGCN"}
    ' Tao mang tham so lay ve thong tin HS Khong Du Dieu Kien
    Dim ParaKhongDuDieuKien() As String = {"@KetQuaThamDinh", "@MaHoSoCapGCN"}
    ' Tao mang tham so lay ve thong tin HS Chua Du Dieu Kien
    Dim ParaChuaDuDieuKien() As String = {"@KetQuaThamDinh", "@MaHoSoCapGCN"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    Private strMaHoSoCapGCN As String
    Private strFlag As String
    Private strDonViThamDinh As String
    Private strHoTenCanBoThamDinhDKND As String
    Private strYKienThamDinhDKND As String
    Private strKetQuaThamDinhDKND As String
    Private strNgayThamDinhDKND As String

    Private strHoTenCanBoThamDinhTNMT As String
    Private strYKienThamDinhTNMT As String
    Private strKetQuaThamDinhTNMT As String
    Private strNgayThamDinhTNMT As String

    Private strLyDoKhongCap As String

    Private strDienTichDatO As String
    Private strDienTichDatVuon As String
    Private strDienTichKhongCap As String
    Private strYKienKhac As String
    Private strGhiChu As String

    Private strDienTich As String
    Private strDienTichBangChu As String
    Private strDienTichRieng As String
    Private strDienTichChung As String
    Private strMaDonViHanhChinh As String

    Private strMaHoSoThamDinh As String
    Public Property MaHoSoThamDinh() As String
        Get
            Return strMaHoSoThamDinh
        End Get
        Set(ByVal value As String)
            strMaHoSoThamDinh = value
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

    Public Property DienTichDatO() As String
        Get
            Return strDienTichDatO
        End Get
        Set(ByVal value As String)
            strDienTichDatO = value
        End Set
    End Property
    Public Property DienTichDatVuon() As String
        Get
            Return strDienTichDatVuon
        End Get
        Set(ByVal value As String)
            strDienTichDatVuon = value
        End Set
    End Property
    Public Property DienTichKhongCap() As String
        Get
            Return strDienTichKhongCap
        End Get
        Set(ByVal value As String)
            strDienTichKhongCap = value
        End Set
    End Property
    Public Property YKienKhac() As String
        Get
            Return strYKienKhac
        End Get
        Set(ByVal value As String)
            strYKienKhac = value
        End Set
    End Property
    Public Property GhiChu() As String
        Get
            Return strGhiChu
        End Get
        Set(ByVal value As String)
            strGhiChu = value
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

    Public Property DienTichBangChu() As String
        Get
            Return strDienTichBangChu
        End Get
        Set(ByVal value As String)
            strDienTichBangChu = value
        End Set
    End Property

    Public Property DienTichRieng() As String
        Get
            Return strDienTichRieng
        End Get
        Set(ByVal value As String)
            strDienTichRieng = value
        End Set
    End Property

    Public Property DienTichChung() As String
        Get
            Return strDienTichChung
        End Get
        Set(ByVal value As String)
            strDienTichChung = value
        End Set
    End Property

#Region "Khai báo"

    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    ' Khai bao thuoc tinh ung voi Flag
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính ứng với biến Mã hồ sơ cấp GCN
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    'Khai báo thuộc tính ứng với biếnn Đơn vị thẩm định
    Public Property DonViThamDinh() As String
        Get
            Return strDonViThamDinh
        End Get
        Set(ByVal value As String)
            strDonViThamDinh = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Họ tên cán bộ thẩm định
    Public Property HoTenCanBoThamDinhDKND() As String
        Get
            Return strHoTenCanBoThamDinhDKND
        End Get
        Set(ByVal value As String)
            strHoTenCanBoThamDinhDKND = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Ý kiến thẩm định
    Public Property YKienThamDinhDKND() As String
        Get
            Return strYKienThamDinhDKND
        End Get
        Set(ByVal value As String)
            strYKienThamDinhDKND = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kết quả thẩm định
    Public Property KetQuaThamDinhDKND() As String
        Get
            Return strKetQuaThamDinhDKND
        End Get
        Set(ByVal value As String)
            strKetQuaThamDinhDKND = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Ngày thẩm định
    Public Property NgayThamDinhDKND() As String
        Get
            Return strNgayThamDinhDKND
        End Get
        Set(ByVal value As String)
            strNgayThamDinhDKND = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Họ tên cán bộ thẩm định
    Public Property HoTenCanBoThamDinhTNMT() As String
        Get
            Return strHoTenCanBoThamDinhTNMT
        End Get
        Set(ByVal value As String)
            strHoTenCanBoThamDinhTNMT = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Ý kiến thẩm định
    Public Property YKienThamDinhTNMT() As String
        Get
            Return strYKienThamDinhTNMT
        End Get
        Set(ByVal value As String)
            strYKienThamDinhTNMT = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kết quả thẩm định
    Public Property KetQuaThamDinhTNMT() As String
        Get
            Return strKetQuaThamDinhTNMT
        End Get
        Set(ByVal value As String)
            strKetQuaThamDinhTNMT = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Ngày thẩm định
    Public Property NgayThamDinhTNMT() As String
        Get
            Return strNgayThamDinhTNMT
        End Get
        Set(ByVal value As String)
            strNgayThamDinhTNMT = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến Lý do không cấp
    Public Property LyDoKhongCap() As String
        Get
            Return strLyDoKhongCap
        End Get
        Set(ByVal value As String)
            strLyDoKhongCap = value
        End Set
    End Property

#End Region
    ''' <summary>
    ''' Thêm thông tin Cán bộ thẩm định vào Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Public Function InsertThongTinCanBoThamDinhByMaHoSoCapGCN() As String
        Dim strRecords As String = ""
        Return Me.Execute("spInsertThongTinCanBoThamDinhByMaHoSoCapGCN", strRecords)
    End Function
    ''' <summary>
    ''' Cập nhật thông tin cán bộ thẩm định vào Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinCanBoThamDinhByMaHoSoCapGCN() As String
        Dim strRecords As String = ""
        Return Me.Execute("spUpdateThongTinCanBoThamDinhByMaHoSoCapGCN", strRecords)
    End Function
    ''' <summary>
    ''' Xóa thông tin cán bộ thẩm định vào Hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinCanBoThamDinhByMaHoSoCapGCN() As String
        Dim strRecords As String = ""
        Return Me.Execute("spDeleteThongTinCanBoThamDinhByMaHoSoCapGCN", strRecords)
    End Function

    ''' <summary>
    ''' Phương thức thực thị Thục tục SQL Server
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục SQLServer</param>
    ''' <param name="strRecords"></param>
    ''' <returns>Giá trị trả về là thông báo lỗi (nếu có)</returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaHoSoThamDinh, strMaHoSoCapGCN, strDonViThamDinh, strHoTenCanBoThamDinhDKND, strYKienThamDinhDKND _
                 , strKetQuaThamDinhDKND, strNgayThamDinhDKND, strHoTenCanBoThamDinhTNMT, strYKienThamDinhTNMT _
                 , strKetQuaThamDinhTNMT, strNgayThamDinhTNMT, strLyDoKhongCap, strDienTichDatO, strDienTichDatVuon, strDienTichKhongCap, strYKienKhac, strGhiChu, strDienTich, strDienTichBangChu, strDienTichRieng, strDienTichChung}
                'Kiểm tra tương thích dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
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


    ' Tao ham thuc thi cau lenh truy van SQL 

    Public Function ExcuteThamDinh(ByVal strStoreProcedureName As String, ByRef strRecord As String) As String
        Try
            ' Khai bao va khoi tao doi tuong lam viec voi DataBase
            Dim Database As New clsDatabase
            ' Nhan chuoi ket noi 
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                Dim ValuesThamDinh() As String = {0, strMaHoSoCapGCN, strFlag, strMaDonViHanhChinh}
                If Para.Length <> ValuesThamDinh.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                Database.ExecuteSP(strStoreProcedureName, Para, ValuesThamDinh, strRecord)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Tao ham Update Trang Thai HS Tham dinh

    Public Function UpdateThamDinh() As String
        Dim str As String = ""
        Return ExcuteThamDinh("spUpdateTrangThaiHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Phương thức truy vấn Thông tin cán bộ thẩm định theo Mã Hồ sơ cấp GCN
    ''' </summary>
    ''' <param name="dtRecords">Bảng kết quả truy vấn trả về</param>
    ''' <returns>Giá trị trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinCanBoThamDinhByMaHoSoCapGCN(ByRef dtRecords As DataTable) As String
        Return Me.GetData("spSelectThongTinCanBoThamDinhByMaHoSoCapGCN", dtRecords)
    End Function

    ''' <summary>
    ''' Hàm thực thi truy vấn cơ sở dữ liệu
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục SQLServer</param>
    ''' <param name="dtRecords">Tên  bảng dữ liệu trả về của câu truy vấn</param>
    ''' <returns>Giá tri trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                {strMaHoSoThamDinh, strMaHoSoCapGCN, strDonViThamDinh, strHoTenCanBoThamDinhDKND, strYKienThamDinhDKND _
                 , strKetQuaThamDinhDKND, strNgayThamDinhDKND, strHoTenCanBoThamDinhTNMT, strYKienThamDinhTNMT _
                 , strKetQuaThamDinhTNMT, strNgayThamDinhTNMT, strLyDoKhongCap, strDienTichDatO, strDienTichDatVuon, strDienTichKhongCap, strYKienKhac, strGhiChu, strDienTich, strDienTichBangChu, strDienTichRieng, strDienTichChung}
                'Kiểm tra tương thích dữ liệu
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                'Gọi phương thức truy vấn  cơ sở dữ liệu
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Tao ham lay ve tat ca thong tin HS Chua Tham dinh
    Public Function GetDataChuaThamDinh(ByRef dtRecords As DataTable) As String
        Try
            ' Khai bao va khoi tao truy xuat DataBase 
            Dim DataBase As New clsDatabase
            ' Khai bao chuoi nhan ket noi 
            DataBase.Connection = strConnection
            If DataBase.OpenConnection = True Then
                Dim ValueChuaThamDinh() As String = {"0", strMaHoSoCapGCN}
                If ParaChuaThamDinh.Length <> ValueChuaThamDinh.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                DataBase.getValue(dtRecords, "spSelectKetQuaThamDinh", ParaChuaThamDinh, ValueChuaThamDinh)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Tao ham lay ve toan bo thong tin HS Da Tham Dinh 
    Public Function GetDataHSDaThamDinh(ByRef dtRecords As DataTable) As String
        Try
            ' Khai bao khoi tao doi tuong thao tac voi DataBase 
            Dim DataBase As New clsDatabase
            ' Khai bao chuoi nhan ket noi DataBase
            DataBase.Connection = strConnection
            If DataBase.OpenConnection = True Then
                Dim ValuesDaThamDinh() As String = {"1", strMaHoSoCapGCN}
                If ParaDaThamDinh.Length <> ValuesDaThamDinh.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                DataBase.getValue(dtRecords, "spSelectKetQuaThamDinh", ParaDaThamDinh, ValuesDaThamDinh)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Tao ham lay ve toan bo thong tin HS Khong Du Dieu Kien
    Public Function GetDataHSKhongDuDieuKien(ByRef dtRecords As DataTable) As String
        Try
            ' Khai bao khoi tao doi tuong thao tac voi DataBase 
            Dim DataBase As New clsDatabase
            ' Tao chuoi ket noi den DataBase 
            DataBase.Connection = strConnection
            If DataBase.OpenConnection = True Then
                Dim ValuesKhongDuDieuKien() As String = {"3", strMaHoSoCapGCN}
                If ParaKhongDuDieuKien.Length <> ValuesKhongDuDieuKien.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                    "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                DataBase.getValue(dtRecords, "spSelectKetQuaThamDinh", ParaKhongDuDieuKien, ValuesKhongDuDieuKien)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message

        End Try
        Return strError
    End Function

    ' Tao ham lay ve toan bo thong tin HS Chua Du Dieu Kien
    Public Function GetDataHSChuaDuDieuKien(ByRef dtRecords As DataTable) As String
        Try
            ' Khai bao va khoi tao doi tuong ket noi DataBase 
            Dim DataBase As New clsDatabase
            ' Nhan ve chuoi ket noi
            DataBase.Connection = strConnection
            If DataBase.OpenConnection = True Then
                Dim ValuesChuaDuDieuKien() As String = {"2", strMaHoSoCapGCN}
                If ParaChuaDuDieuKien.Length <> ValuesChuaDuDieuKien.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                   "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                DataBase.getValue(dtRecords, "spSelectKetQuaThamDinh", ParaChuaDuDieuKien, ValuesChuaDuDieuKien)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function


    ''' <summary>
    ''' Lựa chọn Danh sách (Từ điển) trạng thái Thẩm định
    ''' Danh sách này sẽ hiển thị lên Combox trong phần 
    ''' chọn Kết quả trạng thái luôn chuyển hồ sơ (Kết quả thẩm định)
    ''' </summary>
    ''' <param name="dtRecords">Bảng danh sách trạng thái Thẩm định</param>
    ''' <returns>Kết quả trả về là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function SelectData(ByVal procedureName As String, ByVal paras() As String, ByVal values() As String, ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị 
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (paras.Length <> values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(dtRecords, procedureName, paras, values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function SelectTuDienTrangThaiThamDinh(ByVal MaDonViThamDinh As String, ByRef dtRecords As DataTable) As String
        'Khai báo mảng giá trị
        Dim arrParas() As String = {"@flag"}
        Dim arrValues() As String = {MaDonViThamDinh}
        strError = SelectData("spSelectTuDienTrangThaiThamDinh", arrParas, arrValues, dtRecords)
        Return strError
    End Function
End Class
