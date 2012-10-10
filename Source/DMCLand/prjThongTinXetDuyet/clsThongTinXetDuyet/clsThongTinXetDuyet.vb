Imports DMC.Database
Public Class clsThongTinXetDuyet
    'Khai bao mang tham so
    Dim Paras() As String = {"@flag", "@TrangThaiHoSoCapGCN", "@MaHoSoCapGCN" _
    , "@ToTrinhPhuong", "@NgayTrinhPhuong", "@NgayXetDuyet", "@KetQuaXetDuyet" _
    , "@CanhBaoTranhChapKhieuKien", "@NoiDungTranhChapKhieuKien", "@YKienCanBoXetDuyet", "@LyDoKhongCap", "@PhamViBaoVeHaTang"}


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
    Private strYKienCanBoXetDuyet As String
    Private strLyDoKhongCap As String
    Private strflag As String = "0"
    Private strPhamViBaoVeHaTang As String = ""
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
    'Khai bao thuoc tinh ung voi bien 
    Public Property LyDoKhongCap() As String
        Get
            Return strLyDoKhongCap
        End Get
        Set(ByVal value As String)
            strLyDoKhongCap = value
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
                , strNoiDungTranhChapKhieuKien, strYKienCanBoXetDuyet, strLyDoKhongCap, strPhamViBaoVeHaTang}
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP("spThongTinXetDuyet", Paras, Values, records)
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
                , strNoiDungTranhChapKhieuKien, strYKienCanBoXetDuyet, strLyDoKhongCap, strPhamViBaoVeHaTang}
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(records, "spThongTinXetDuyet", Paras, Values)
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
                Dim ParaTrangThai() As String = {"@Flag", "@MaHoSoCapGCN", "@TrangThai"}
                Dim ValuesTrangThai() As String = {0, strMaHoSoCapGCN, strflag}
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

