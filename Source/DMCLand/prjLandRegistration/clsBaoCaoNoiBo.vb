Public Class clsBaoCaoNoiBo
#Region "Các thuộc tính"
    Private DiaChiNha As String
    Private ChuSuDung As String
    Private ChuSuDung1 As String
    Private ChuSuDung2 As String
    Private DienTich As String
    Private DienTichRieng As String
    Private DienTichChung As String
    Private DienTichSuDung As String
    Private SoTang As String
    Private NguoiPheDuyet As String
    Private DienTichDat As String
    Private KhieuNai_TranhChap As String
    Private DienTichDeNghiCapGCN As String
    Private KetCau As String
    Private NghiaVuTaiChinh As String
    Private TruongPhong As String
    Private ThuaDat As String
    Private ToBanDo As String
    Private NguonGocSuDung As String
    Private CapNha As String
    Private SoNha As String
    Private ThoiHanSuDung As String
    Private MucDichSuDung As String
    Private NamSinh As String
    Private NamSinh1 As String
    Private NamSinh2 As String
    Private SoCMND As String
    Private SoCMND1 As String
    Private SoCMND2 As String
    Private NoiCap As String
    Private NoiCap1 As String
    Private NoiCap2 As String
    Private NgayCap As String
    Private DienTichNha As String
    Private strDienTichXD As String
    Private strThoiHanSoHuu As String = ""
    Private NamXayDung As String
 
    Private LoaiNha As String
    Private DiaChiDat As String = ""
    Private strPhuong As String = ""
    Private strToTrinhPhuong As String = ""
    Private strNgayTrinhPhuong As String = ""
    Private strSoToTrinhDiaChinh As String = ""
    Private strNgayTrinhDiaChinh As String = ""
    Private strNguonGocNha As String = ""
    Private strGiaTriConLai As String = ""
    Private strHoTenCanBoThamDinh As String = ""

    Private strDatO As String = ""
    Private strDatVuon As String = ""
    Private strSoSeriToTrinh As String = ""

    Private strDieuKhoan As String = ""

    Private strNoiDungHoSo As String = ""
    Private strSoPhatHanhGCN As String = ""
    Private strDienTichChuyenDich As String = ""

#End Region
    'Khai bao mang tham so
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'khai báo biến nhận chuỗi kết nối Database
    Private strConnnection As String = ""
    'Khai bao bien kiem tra loi 
    Private strError As String
    Private strMaHoSoCapGCN As String

    Private strLoaiDuong As String = ""
    Private strViTri As String = ""
    Private strNgoRong As String = "0"
    Private strCachDuongChinh As String = "0"

    Private strLPTB As String = ""
    Private strTTNCN As String = ""

    Private strDT100GiaDat As String = "0"
    Private strDT50GiaDat As String = "0"
    Private strDT40GiaDat As String = "0"
    Private strDT20GiaDat As String = "0"

    Public Property DienTichChuyenDich() As String
        Get
            Return strDienTichChuyenDich
        End Get
        Set(ByVal value As String)
            strDienTichChuyenDich = value
        End Set
    End Property

    Public Property DT100GiaDat() As String
        Get
            Return strDT100GiaDat
        End Get
        Set(ByVal value As String)
            strDT100GiaDat = value
        End Set
    End Property
    Public Property DT50GiaDat() As String
        Get
            Return strDT50GiaDat
        End Get
        Set(ByVal value As String)
            strDT50GiaDat = value
        End Set
    End Property
    Public Property DT40GiaDat() As String
        Get
            Return strDT40GiaDat
        End Get
        Set(ByVal value As String)
            strDT40GiaDat = value
        End Set
    End Property
    Public Property DT20GiaDat() As String
        Get
            Return strDT20GiaDat
        End Get
        Set(ByVal value As String)
            strDT20GiaDat = value
        End Set
    End Property
    Public Property SoPhatHanhGCN() As String
        Get
            Return strSoPhatHanhGCN
        End Get
        Set(ByVal value As String)
            strSoPhatHanhGCN = value
        End Set
    End Property

    Public Property Get_DieuKhoan() As String
        Get
            Return strDieuKhoan
        End Get
        Set(ByVal value As String)
            strDieuKhoan = value
        End Set
    End Property

    Public Property Get_NoiDungHoSo() As String
        Get
            Return strNoiDungHoSo
        End Get
        Set(ByVal value As String)
            strNoiDungHoSo = value
        End Set
    End Property

    Public Property Get_LPTB() As String
        Get
            Return strLPTB
        End Get
        Set(ByVal value As String)
            strLPTB = value
        End Set
    End Property
    Public Property Get_TTNCN() As String
        Get
            Return strTTNCN
        End Get
        Set(ByVal value As String)
            strTTNCN = value
        End Set
    End Property

    Public Property Get_LoaiDuong() As String
        Get
            Return strLoaiDuong
        End Get
        Set(ByVal value As String)
            strLoaiDuong = value
        End Set
    End Property
    Public Property Get_ViTri() As String
        Get
            Return strViTri
        End Get
        Set(ByVal value As String)
            strViTri = value
        End Set
    End Property
    Public Property Get_NgoRong() As String
        Get
            Return strNgoRong
        End Get
        Set(ByVal value As String)
            strNgoRong = value
        End Set
    End Property
    Public Property Get_CachDuongChinh() As String
        Get
            Return strCachDuongChinh
        End Get
        Set(ByVal value As String)
            strCachDuongChinh = value
        End Set
    End Property

    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnnection = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    Public Property Get_Phuong() As String
        Get
            Return strPhuong
        End Get
        Set(ByVal value As String)
            strPhuong = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property Get_DiaChi() As String
        Get
            Return DiaChiNha
        End Get
        Set(ByVal value As String)
            DiaChiNha = value
        End Set
    End Property
    Public Property Get_ChuSuDung() As String
        Get
            Return ChuSuDung
        End Get
        Set(ByVal value As String)
            ChuSuDung = value
        End Set
    End Property
    Public Property Get_ChuSuDung1() As String
        Get
            Return ChuSuDung1
        End Get
        Set(ByVal value As String)
            ChuSuDung1 = value
        End Set
    End Property
    Public Property Get_ChuSuDung2() As String
        Get
            Return ChuSuDung2
        End Get
        Set(ByVal value As String)
            ChuSuDung2 = value
        End Set
    End Property
    Public Property Get_DiaChiNha() As String
        Get
            Return DiaChiNha
        End Get
        Set(ByVal value As String)
            DiaChiNha = value
        End Set
    End Property
    Public Property Get_SoNha() As String
        Get
            Return SoNha
        End Get
        Set(ByVal value As String)
            SoNha = value
        End Set
    End Property
    Public Property Get_DiaChiDat() As String
        Get
            Return DiaChiDat
        End Get
        Set(ByVal value As String)
            DiaChiDat = value
        End Set
    End Property
    Public Property Get_DienTich() As String
        Get
            Return DienTich
        End Get
        Set(ByVal value As String)
            DienTich = value
        End Set
    End Property
    Public Property Get_DienTichRieng() As String
        Get
            Return DienTichRieng
        End Get
        Set(ByVal value As String)
            DienTichRieng = value
        End Set
    End Property
    Public Property Get_DienTichXD() As String
        Get
            Return strDienTichXD
        End Get
        Set(ByVal value As String)
            strDienTichXD = value
        End Set
    End Property
    Public Property Get_DienTichChung() As String
        Get
            Return DienTichChung
        End Get
        Set(ByVal value As String)
            DienTichChung = value
        End Set
    End Property
    Public Property Get_DienTichSuDung() As String
        Get
            Return DienTichSuDung
        End Get
        Set(ByVal value As String)
            DienTichSuDung = value
        End Set
    End Property
    Public Property Get_SoTang() As String
        Get
            Return SoTang
        End Get
        Set(ByVal value As String)
            SoTang = value
        End Set
    End Property
    Public Property Get_NguoiPheDuyet() As String
        Get
            Return NguoiPheDuyet
        End Get
        Set(ByVal value As String)
            NguoiPheDuyet = value
        End Set
    End Property
    Public Property Get_DienTichDat() As String
        Get
            Return DienTichDat
        End Get
        Set(ByVal value As String)
            DienTichDat = value
        End Set
    End Property
    Public Property Get_KhieuNaiTranhChap() As String
        Get
            Return KhieuNai_TranhChap
        End Get
        Set(ByVal value As String)
            KhieuNai_TranhChap = value
        End Set
    End Property
    Public Property Get_DienTichDeNghiCapGCN() As String
        Get
            Return DienTichDeNghiCapGCN
        End Get
        Set(ByVal value As String)
            DienTichDeNghiCapGCN = value
        End Set
    End Property
    Public Property Get_KetCau() As String
        Get
            Return KetCau
        End Get
        Set(ByVal value As String)
            KetCau = value
        End Set
    End Property

    Public Property Get_DatO() As String
        Get
            Return strDatO
        End Get
        Set(ByVal value As String)
            strDatO = value
        End Set
    End Property
    Public Property Get_DatVuon() As String
        Get
            Return strDatVuon
        End Get
        Set(ByVal value As String)
            strDatVuon = value
        End Set
    End Property
    Public Property Get_SoSeriToTrinh() As String
        Get
            Return strSoSeriToTrinh
        End Get
        Set(ByVal value As String)
            strSoSeriToTrinh = value
        End Set
    End Property

    Public Property Get_NghiaVuTaiChinh() As String
        Get
            Return NghiaVuTaiChinh
        End Get
        Set(ByVal value As String)
            NghiaVuTaiChinh = value
        End Set
    End Property
    Public Property Get_TruongPhong() As String
        Get
            Return TruongPhong
        End Get
        Set(ByVal value As String)
            TruongPhong = value
        End Set
    End Property
    Public Property Get_ThuaDat() As String
        Get
            Return ThuaDat
        End Get
        Set(ByVal value As String)
            ThuaDat = value
        End Set
    End Property
    Public Property Get_ToBanDo() As String
        Get
            Return ToBanDo
        End Get
        Set(ByVal value As String)
            ToBanDo = value
        End Set
    End Property
    Public Property Get_NguonGocSuDung() As String
        Get
            Return NguonGocSuDung
        End Get
        Set(ByVal value As String)
            NguonGocSuDung = value
        End Set
    End Property
    Public Property Get_CapNha() As String
        Get
            Return CapNha
        End Get
        Set(ByVal value As String)
            CapNha = value
        End Set
    End Property
    Public Property Get_ThoiHanSoHuu() As String
        Get
            Return strThoiHanSoHuu
        End Get
        Set(ByVal value As String)
            strThoiHanSoHuu = value
        End Set
    End Property

    Public Property Get_ThoiHanSuDung() As String
        Get
            Return ThoiHanSuDung
        End Get
        Set(ByVal value As String)
            ThoiHanSuDung = value
        End Set
    End Property
    Public Property Get_MucDichSuDung() As String
        Get
            Return MucDichSuDung
        End Get
        Set(ByVal value As String)
            MucDichSuDung = value
        End Set
    End Property
    Public Property Get_NamSinh() As String
        Get
            Return NamSinh
        End Get
        Set(ByVal value As String)
            NamSinh = value
        End Set
    End Property
    Public Property Get_NamSinh1() As String
        Get
            Return NamSinh1
        End Get
        Set(ByVal value As String)
            NamSinh1 = value
        End Set
    End Property
    Public Property Get_NamSinh2() As String
        Get
            Return NamSinh2
        End Get
        Set(ByVal value As String)
            NamSinh2 = value
        End Set
    End Property
    Public Property Get_SoCMND() As String
        Get
            Return SoCMND
        End Get
        Set(ByVal value As String)
            SoCMND = value
        End Set
    End Property
    Public Property Get_SoCMND1() As String
        Get
            Return SoCMND1
        End Get
        Set(ByVal value As String)
            SoCMND1 = value
        End Set
    End Property
    Public Property Get_SoCMND2() As String
        Get
            Return SoCMND2
        End Get
        Set(ByVal value As String)
            SoCMND2 = value
        End Set
    End Property
    Public Property Get_NoiCap() As String
        Get
            Return NoiCap
        End Get
        Set(ByVal value As String)
            NoiCap = value
        End Set
    End Property
    Public Property Get_NoiCap1() As String
        Get
            Return NoiCap1
        End Get
        Set(ByVal value As String)
            NoiCap1 = value
        End Set
    End Property
    Public Property Get_NoiCap2() As String
        Get
            Return NoiCap2
        End Get
        Set(ByVal value As String)
            NoiCap2 = value
        End Set
    End Property
    Public Property Get_DienTichNha() As String
        Get
            Return DienTichNha
        End Get
        Set(ByVal value As String)
            DienTichNha = value
        End Set
    End Property
    Public Property Get_NamXayDung() As String
        Get
            Return NamXayDung
        End Get
        Set(ByVal value As String)
            NamXayDung = value
        End Set
    End Property
    Public Property Get_NgayCap() As String
        Get
            Return NgayCap
        End Get
        Set(ByVal value As String)
            NgayCap = value
        End Set
    End Property
    Public Property Get_LoaiNha() As String
        Get
            Return LoaiNha
        End Get
        Set(ByVal value As String)
            LoaiNha = value
        End Set
    End Property

    Public Property Get_ToTrinhPhuong() As String
        Get
            Return strToTrinhPhuong
        End Get
        Set(ByVal value As String)
            strToTrinhPhuong = value
        End Set
    End Property

    Public Property Get_NgayTrinhPhuong() As String
        Get
            Return strNgayTrinhPhuong
        End Get
        Set(ByVal value As String)
            strNgayTrinhPhuong = value
        End Set
    End Property

    Public Property Get_NguonGocNha() As String
        Get
            Return strNguonGocNha
        End Get
        Set(ByVal value As String)
            strNguonGocNha = value
        End Set
    End Property

    Public Property Get_GiaTriConLai() As String
        Get
            Return strGiaTriConLai
        End Get
        Set(ByVal value As String)
            strGiaTriConLai = value
        End Set
    End Property

    Public Property get_HoTenCanBoThamDinh() As String
        Get
            Return strHoTenCanBoThamDinh
        End Get
        Set(ByVal value As String)
            strHoTenCanBoThamDinh = value
        End Set
    End Property


    Public Property get_SoToTrinhDiaChinh() As String
        Get
            Return strSoToTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strSoToTrinhDiaChinh = value
        End Set
    End Property

    Public Property get_NgayTrinhDiaChinh() As String
        Get
            Return strNgayTrinhDiaChinh
        End Get
        Set(ByVal value As String)
            strNgayTrinhDiaChinh = value
        End Set
    End Property

    Public Function SelectChuDeNghiCapGCNByMaHoSoCapGCN(ByRef dtRecords As DataTable) As String
        Return Me.GetData("spSelectChuDeNghiCapGCNByMaHoSoCapGCN", dtRecords)
    End Function

    Public Function SelectGhiChuNoiDungChuDeNghiCapGCN(ByRef dtRecords As DataTable) As String
        Return Me.GetData("spSelectGhiChuNoiDungChuDeNghiCapGCN", dtRecords)
    End Function

    Private Function GetData(ByVal strStoreProcedureName As String, ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New DMC.Database.clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    ''' <summary>
    ''' Lựa chọn thông tin Địa chỉ thửa đất đề nghị cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là bảng chứa thông tin 
    ''' Địa chỉ thửa đất đề nghị cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectDiaChiThuaDatByMaHoSoCapGCN() As DataTable
        Dim dtResults As New DataTable
        Try
            dtResults = Me.SelectData("spSelectDiaChiThuaDatByMaHoSoCapGCN")
        Catch ex As Exception
            MsgBox("Lỗi hiển thị thông tin địa chỉ thửa đất đề nghị cấp GCN !", MsgBoxStyle.OkOnly, "DMCLand")
        End Try
        Return dtResults
    End Function

    ''' <summary>
    ''' Lựa chọn thông tin Thửa đất đề nghị cấp GCN theo Mã hồ sơ cấp GCN
    ''' </summary>
    ''' <returns>Giá trị trả về là dữ liệu kiểu bảng chứa thông tin
    ''' Thửa đất đất đề nghị cấp GCN</returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinThuaDat() As DataTable
        Dim dtResults As New DataTable
        Try
            dtResults = Me.SelectData("spSelectGCNThongTinThuaDatDeNghiCapGCNByMaHoSoCapGCN")
        Catch ex As Exception
            MsgBox("Lỗi hiển thị thông tin thửa đất đề nghị cấp GCN !", MsgBoxStyle.OkOnly, "DMCLand")
        End Try
        Return dtResults
    End Function
    ''' <summary>
    ''' Phương thức thực thi thủ tục truy vấn dữ liệu
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <returns>Giá trị trả về là kiểu bảng </returns>
    ''' <remarks></remarks>
    Private Function SelectData(ByVal strStoreProcedureName As String) As DataTable
        Dim dtRecords As New DataTable
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không phù hợp với mảng tham biến", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                End If
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi khi thực thi dữ liệu !")
        End Try
        Return dtRecords
    End Function
    Public Function SelecThongTinNhaO() As DataTable
        Dim dtRecords As New DataTable
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không phù hợp với mảng tham biến", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                End If
                Database.getValue(dtRecords, "spSelectGCNThongTinNhaODeNghiCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi dữ liệu !")
        End Try
        Return dtRecords
    End Function

    Public Function SelecThongTinThuaDat_NhaO(ByVal dtRecords As DataTable) As DataTable
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không phù hợp với mảng tham biến", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                End If
                Database.getValue(dtRecords, "spSelectThongTinBanDuThaoGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi dữ liệu !")
        End Try
        Return dtRecords
    End Function

    Public Function GetData(ByVal strStoreName As String, ByVal Paras() As String, ByVal Values() As String) As DataTable
        Dim dtRecords As New DataTable
        Try

            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New DMC.Database.clsDatabase
            Database.Connection = strConnnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không phù hợp với mảng tham biến", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                End If
                Database.getValue(dtRecords, strStoreName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox("Lỗi thực thi dữ liệu !")
        End Try
        Return dtRecords
    End Function

    Public Function selChuSuDungInQuyetDinhByHoGiaDinh() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@MaHoSoCapGCN"}
        Dim values() As String = {strMaHoSoCapGCN}
        dt = GetData("spSelectCSDHoGiaDinhByMaHoSoCapGCN", paras, values)
        Return dt
    End Function

    Public Function selChuSuDungChuyenNhuong(ByVal flag As String) As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaHoSoCapGCN"}
        Dim values() As String = {flag, strMaHoSoCapGCN}
        dt = GetData("spSelectChuChuyenNhuong", paras, values)
        Return dt
    End Function

    Public Function selDienTichChuyenDich() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@MaHoSoCapGCN"}
        Dim values() As String = {strMaHoSoCapGCN}
        dt = GetData("spSelectDienTichChuyenDich", paras, values)
        Return dt
    End Function
End Class

