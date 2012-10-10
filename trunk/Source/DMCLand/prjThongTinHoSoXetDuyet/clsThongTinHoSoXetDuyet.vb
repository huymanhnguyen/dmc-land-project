Imports DMC.Database
Public Class clsThongTinHoSoXetDuyet
    'Khai bao mang tham so
    Dim Paras() As String = {"@flag", "@TrangThaiHoSoCapGCN", "@MaHoSoCapGCN" _
    , "@ToTrinhPhuong", "@NgayTrinhPhuong", "@NgayXetDuyet", "@KetQuaXetDuyet" _
    , "@CanhBaoTranhChapKhieuKien", "@NoiDungTranhChapKhieuKien", "@QuyHoach", "@YKienCanBoXetDuyet" _
    , "@PhamViBaoVeHaTang", "@TongHopHienTrangSuDungDat", "@HTDienTichBanDo", "@HTDienTichBienBan", _
    "@HTDienTichChenhLech", "@HTLyDoChenhLech", "@HTDienTIchDatO", "@HTDienTichDatVuon", _
    "@HTDienTichHanhLang", "@HTDienTichSDNha", "@HTDienTichXD", "@HTKetCau", "@YKQuyHoachThoiDiem", _
    "@YKDienTichDuDK", "@YKDienTichNopTienSDD", "@YKDienTichDatO", "@YKDienTichVuonAo", _
    "@YKDienTichKhongDuDK", "@YKLyDo", "@YKDienTichXD", "@YKKetCau", "@YKDienTichSuDungNha", _
    "@YKDienTichChung", "@YKDienTichRieng", "@YKDienTichHanhLang", "@HTDTChungDatO", "@HTDTRiengDatO", _
    "@HTDTChungDatVuon", "@HTDTRiengDatVuon", "@HTDienTIchDatNN", "@HTDTChungDatNN", "@HTDTRiengDatNN", "@YKDienTichDatNN"}


    Private strConnection As String ' Khai báo biến nhận chuỗi kết nối Database
    Private strError As String 'Khai bao bien kiem tra loi 
    Private shortAction As Short
    'Trạng thái Hồ sơ cấp GCN
    Private longTrangThaiHoSoCapGCN As Long = 0
    Private strMaHoSoCapGCN As String
    Private strToTrinhPhuong As String
    Private dtmNgayTrinhPhuong As String
    Private dtmNgayXetDuyet As String
    Private strKetQuaXetDuyet As String
    Private blnCanhBaoTranhChapKhieuKien As String
    Private strNoiDungTranhChapKhieuKien As String
    Private strQuyHoach As String
    Private strYKienCanBoXetDuyet As String
    Private strflag As String = "0"
    Private strPhamViBaoVeHaTang As String
    Private strTongHopHIenTrangSuDung As String


    Private strYKQuyHoachThoiDiem As String
    Private strYKDienTichDuDK As String
    Private strYKDienTichNopTienSDD As String
    Private strYKDienTichDatO As String
    Private strYKDienTichVuonAo As String
    Private strYKDienTichDatNN As String
    Private strYKDienTichKhongDuDK As String
    Private strYKLyDo As String
    Private strYKDienTichXD As String
    Private strYKKetCau As String
    Private strYKDienTichSuDungNha As String
    Private strYKDienTichChung As String
    Private strYKDienTichRieng As String
    Private strYKDienTichHanhLang As String
    Private strHTDienTichBanDo As String
    Private strHTDienTichBienBan As String
    Private strHTDienTichChenhLech As String
    Private strHTLyDoChenhLech As String
    Private strHTDienTIchDatO As String
    Private strHTDTChungDatO As String
    Private strHTDTRiengDatO As String


    Private strHTDienTichDatVuon As String
    Private strHTDTChungDatVuon As String
    Private strHTDTRiengDatVuon As String

    Private strHTDienTichDatNN As String
    Private strHTDTChungDatNN As String
    Private strHTDTRiengDatNN As String

    Private strHTDienTichHanhLang As String
    Private strHTDienTichSDNha As String
    Private strHTDienTichXD As String
    Private strHTKetCau As String
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    Public Property QuyHoach() As String
        Get
            Return strQuyHoach
        End Get
        Set(ByVal value As String)
            strQuyHoach = value
        End Set
    End Property

    Public Property HTDTChungDatO() As String
        Get
            Return strHTDTChungDatO
        End Get
        Set(ByVal value As String)
            strHTDTChungDatO = value
        End Set
    End Property
    Public Property HTDTRiengDatO() As String
        Get
            Return strHTDTRiengDatO
        End Get
        Set(ByVal value As String)
            strHTDTRiengDatO = value
        End Set
    End Property

    Public Property YKDienTichDatNN() As String
        Get
            Return strYKDienTichDatNN
        End Get
        Set(ByVal value As String)
            strYKDienTichDatNN = value
        End Set
    End Property
    Public Property HTDTChungDatVuon() As String
        Get
            Return strHTDTChungDatVuon
        End Get
        Set(ByVal value As String)
            strHTDTChungDatVuon = value
        End Set
    End Property
    Public Property HTDTRiengDatVuon() As String
        Get
            Return strHTDTRiengDatVuon
        End Get
        Set(ByVal value As String)
            strHTDTRiengDatVuon = value
        End Set
    End Property
    Public Property HTDTChungDatNN() As String
        Get
            Return strHTDTChungDatNN
        End Get
        Set(ByVal value As String)
            strHTDTChungDatNN = value
        End Set
    End Property
    Public Property HTDTRiengDatNN() As String
        Get
            Return strHTDTRiengDatNN
        End Get
        Set(ByVal value As String)
            strHTDTRiengDatNN = value
        End Set
    End Property

    Public Property HTDientichDatNN() As String
        Get
            Return strHTDienTichDatNN
        End Get
        Set(ByVal value As String)
            strHTDienTichDatNN = value
        End Set
    End Property

    Public Property YKQuyHoachThoiDiem() As String
        Get
            Return strYKQuyHoachThoiDiem
        End Get
        Set(ByVal value As String)
            strYKQuyHoachThoiDiem = value
        End Set
    End Property
    Public Property YKDienTichDuDK() As String
        Get
            Return strYKDienTichDuDK
        End Get
        Set(ByVal value As String)
            strYKDienTichDuDK = value
        End Set
    End Property
    Public Property YKDienTichNopTienSDD() As String
        Get
            Return strYKDienTichNopTienSDD
        End Get
        Set(ByVal value As String)
            strYKDienTichNopTienSDD = value
        End Set
    End Property
    Public Property YKDienTichDatO() As String
        Get
            Return strYKDienTichDatO
        End Get
        Set(ByVal value As String)
            strYKDienTichDatO = value
        End Set
    End Property
    Public Property YKDienTichVuonAo() As String
        Get
            Return strYKDienTichVuonAo
        End Get
        Set(ByVal value As String)
            strYKDienTichVuonAo = value
        End Set
    End Property
    Public Property YKDienTichKhongDuDK() As String
        Get
            Return strYKDienTichKhongDuDK
        End Get
        Set(ByVal value As String)
            strYKDienTichKhongDuDK = value
        End Set
    End Property
    Public Property YKLyDo() As String
        Get
            Return strYKLyDo
        End Get
        Set(ByVal value As String)
            strYKLyDo = value
        End Set
    End Property
    Public Property YKDienTichXD() As String
        Get
            Return strYKDienTichXD
        End Get
        Set(ByVal value As String)
            strYKDienTichXD = value
        End Set
    End Property
    Public Property YKKetCau() As String
        Get
            Return strYKKetCau
        End Get
        Set(ByVal value As String)
            strYKKetCau = value
        End Set
    End Property
    Public Property YKDienTichSuDungNha() As String
        Get
            Return strYKDienTichSuDungNha
        End Get
        Set(ByVal value As String)
            strYKDienTichSuDungNha = value
        End Set
    End Property
    Public Property YKDienTichChung() As String
        Get
            Return strYKDienTichChung
        End Get
        Set(ByVal value As String)
            strYKDienTichChung = value
        End Set
    End Property
    Public Property YKDienTichRieng() As String
        Get
            Return strYKDienTichRieng
        End Get
        Set(ByVal value As String)
            strYKDienTichRieng = value
        End Set
    End Property
    Public Property YKDienTichHanhLang() As String
        Get
            Return strYKDienTichHanhLang
        End Get
        Set(ByVal value As String)
            strYKDienTichHanhLang = value
        End Set
    End Property
    Public Property HTDienTichBanDo() As String
        Get
            Return strHTDienTichBanDo
        End Get
        Set(ByVal value As String)
            strHTDienTichBanDo = value
        End Set
    End Property
    Public Property HTDienTichBienBan() As String
        Get
            Return strHTDienTichBienBan
        End Get
        Set(ByVal value As String)
            strHTDienTichBienBan = value
        End Set
    End Property
    Public Property HTDienTichChenhLech() As String
        Get
            Return strHTDienTichChenhLech
        End Get
        Set(ByVal value As String)
            strHTDienTichChenhLech = value
        End Set
    End Property
    Public Property HTLyDoChenhLech() As String
        Get
            Return strHTLyDoChenhLech
        End Get
        Set(ByVal value As String)
            strHTLyDoChenhLech = value
        End Set
    End Property
    Public Property HTDienTIchDatO() As String
        Get
            Return strHTDienTIchDatO
        End Get
        Set(ByVal value As String)
            strHTDienTIchDatO = value
        End Set
    End Property
    Public Property HTDienTichDatVuon() As String
        Get
            Return strHTDienTichDatVuon
        End Get
        Set(ByVal value As String)
            strHTDienTichDatVuon = value
        End Set
    End Property
    Public Property HTDienTichHanhLang() As String
        Get
            Return strHTDienTichHanhLang
        End Get
        Set(ByVal value As String)
            strHTDienTichHanhLang = value
        End Set
    End Property
    Public Property HTDienTichSDNha() As String
        Get
            Return strHTDienTichSDNha
        End Get
        Set(ByVal value As String)
            strHTDienTichSDNha = value
        End Set
    End Property
    Public Property HTDienTichXD() As String
        Get
            Return strHTDienTichXD
        End Get
        Set(ByVal value As String)
            strHTDienTichXD = value
        End Set
    End Property
    Public Property HTKetCau() As String
        Get
            Return strHTKetCau
        End Get
        Set(ByVal value As String)
            strHTKetCau = value
        End Set
    End Property

    Public Property TongHopHIenTrangSuDung() As String
        Get
            Return strTongHopHIenTrangSuDung
        End Get
        Set(ByVal value As String)
            strTongHopHIenTrangSuDung = value
        End Set
    End Property
    Public Property PhamViBaoVeHaTang() As String
        Get
            Return strPhamViBaoVeHaTang
        End Get
        Set(ByVal value As String)
            strPhamViBaoVeHaTang = value
        End Set
    End Property

    Public Property Flag() As String
        Get
            Return strflag
        End Get
        Set(ByVal value As String)
            strflag = value
        End Set
    End Property

    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnection = value
        End Set
    End Property
    'Khai báo thuộc tính đọc lỗi phát sinh
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    'Khai bao thuoc tinh ung voi bien shFlag
    Public Property Action() As String
        Get
            Return shortAction
        End Get
        Set(ByVal value As String)
            If value > 3 And value < 0 Then
                value = 0
            End If
            shortAction = value
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
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property ToTrinhPhuong() As String
        Get
            Return strToTrinhPhuong
        End Get
        Set(ByVal value As String)
            strToTrinhPhuong = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayTrinhPhuong() As String
        Get
            Return dtmNgayTrinhPhuong
        End Get
        Set(ByVal value As String)
            dtmNgayTrinhPhuong = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NgayXetDuyet() As String
        Get
            Return dtmNgayXetDuyet
        End Get
        Set(ByVal value As String)
            dtmNgayXetDuyet = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property KetQuaXetDuyet() As String
        Get
            Return strKetQuaXetDuyet
        End Get
        Set(ByVal value As String)
            strKetQuaXetDuyet = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property CanhBaoTranhChapKhieuKien() As String
        Get
            Return blnCanhBaoTranhChapKhieuKien
        End Get
        Set(ByVal value As String)
            blnCanhBaoTranhChapKhieuKien = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property NoiDungTranhChapKhieuKien() As String
        Get
            Return strNoiDungTranhChapKhieuKien
        End Get
        Set(ByVal value As String)
            strNoiDungTranhChapKhieuKien = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien 
    Public Property YKienCanBoXetDuyet() As String
        Get
            Return strYKienCanBoXetDuyet
        End Get
        Set(ByVal value As String)
            strYKienCanBoXetDuyet = value
        End Set
    End Property
    '
    Public Function Execute(ByRef records As String) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Khai bao mang gia tri
                Dim Values() As String = {shortAction, longTrangThaiHoSoCapGCN.ToString(), strMaHoSoCapGCN, strToTrinhPhuong, dtmNgayTrinhPhuong _
                , dtmNgayXetDuyet, strKetQuaXetDuyet, blnCanhBaoTranhChapKhieuKien _
                , strNoiDungTranhChapKhieuKien, strQuyHoach, strYKienCanBoXetDuyet, strPhamViBaoVeHaTang, _
                 strTongHopHIenTrangSuDung, strHTDienTichBanDo, strHTDienTichBienBan, strHTDienTichChenhLech, _
                 strHTLyDoChenhLech, strHTDienTIchDatO, strHTDienTichDatVuon, strHTDienTichHanhLang, strHTDienTichSDNha, _
                 strHTDienTichXD, strHTKetCau, strYKQuyHoachThoiDiem, strYKDienTichDuDK, strYKDienTichNopTienSDD, _
                 strYKDienTichDatO, strYKDienTichVuonAo, strYKDienTichKhongDuDK, strYKLyDo, strYKDienTichXD, _
                 strYKKetCau, strYKDienTichSuDungNha, strYKDienTichChung, strYKDienTichRieng, strYKDienTichHanhLang _
                 , strHTDTChungDatO, strHTDTRiengDatO, strHTDTChungDatVuon, strHTDTRiengDatVuon, strHTDienTichDatNN, strHTDTChungDatNN, strHTDTRiengDatNN, strYKDienTichDatNN}
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spThongTinHoSoXetDuyet", Paras, Values, records)
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
            'Khoi tao doi tuong clsDatabase
            Dim Database As New clsDatabase
            'Gán chuỗi kết nối Database
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {shortAction, longTrangThaiHoSoCapGCN.ToString() _
                , strMaHoSoCapGCN, strToTrinhPhuong, dtmNgayTrinhPhuong _
                , dtmNgayXetDuyet, strKetQuaXetDuyet, blnCanhBaoTranhChapKhieuKien _
                , strNoiDungTranhChapKhieuKien, strQuyHoach, strYKienCanBoXetDuyet, strPhamViBaoVeHaTang, _
                strTongHopHIenTrangSuDung, strHTDienTichBanDo, strHTDienTichBienBan, strHTDienTichChenhLech, _
                strHTLyDoChenhLech, strHTDienTIchDatO, strHTDienTichDatVuon, strHTDienTichHanhLang, _
                strHTDienTichSDNha, strHTDienTichXD, strHTKetCau, strYKQuyHoachThoiDiem, strYKDienTichDuDK, _
                strYKDienTichNopTienSDD, strYKDienTichDatO, strYKDienTichVuonAo, strYKDienTichKhongDuDK, _
                strYKLyDo, strYKDienTichXD, strYKKetCau, strYKDienTichSuDungNha, strYKDienTichChung, _
                strYKDienTichRieng, strYKDienTichHanhLang _
                 , strHTDTChungDatO, strHTDTRiengDatO, strHTDTChungDatVuon, strHTDTRiengDatVuon, strHTDienTichDatNN, strHTDTChungDatNN, strHTDTRiengDatNN, strYKDienTichDatNN}
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(records, "spThongTinHoSoXetDuyet", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function SelectTuDienTrangThaiXetDuyet(ByRef strRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp truy xuất cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Khai báo nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim arrValues() As String = {}
                Dim arrParas() As String = {}
                'Kiểm tra tính tương thích của cơ sở dữ liệu
                If (arrParas.Length <> arrValues.Length) Then
                    System.Windows.Forms.MessageBox.Show("Mảng giá trị truyền vào không tương thích với mảng tham số", "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng giá trị truyền vào không tương thích với mảng tham số"
                End If
                'Gọi phương thức thực thi Thủ tục truy vấn cơ sở dữ liệu
                Database.getValue(strRecords, "spSelectTuDienTrangThaiXetDuyet", arrParas, arrValues)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    Public Function UpdateTrangThai() As String
        Dim str As String = ""
        Return ExcuteTrangThai("spUpdateTrangThaiHoSoCapGCN", str)
    End Function
    Public Function ExcuteTrangThai(ByVal strStoreProcedureName As String, ByRef strRecord As String) As String
        Try
            ' Khai bao va khoi tao doi tuong lam viec voi DataBase
            Dim Database As New clsDatabase
            ' Nhan chuoi ket noi 
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                Dim ParaTrangThai() As String = {"@Flag", "@MaHoSoCapGCN", "@TrangThai", "@MaDonViHanhChinh"}
                Dim ValuesTrangThai() As String = {0, strMaHoSoCapGCN, strflag, strMaDonViHanhChinh}
                If ParaTrangThai.Length <> ValuesTrangThai.Length Then
                    System.Windows.Forms.MessageBox.Show("Độ dài mảng giá trị truyền vào không tương thích", _
                     "DMCLand", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Return "Mảng truyền vào không tương thích"
                End If
                Database.ExecuteSP(strStoreProcedureName, ParaTrangThai, ValuesTrangThai, strRecord)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
