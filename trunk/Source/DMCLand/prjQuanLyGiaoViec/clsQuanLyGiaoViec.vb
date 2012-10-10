Imports DMC.Database
Public Class clsQuanLyGiaoViec
    'Khai báo biến chuỗi kết nối cơ sở dữ liệu
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String = ""
    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
    Private strMaQuanLy As String = ""
    Private strSTT As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strTenCongViec As String = ""
    Private strSoNgay As String = ""
    Private strTuNgay As String = ""
    Private strDenNgay As String = ""
    Private strBoPhan As String = ""
    Private strCanBo As String = ""
    Private strDieuChinh As String = ""
    Private strSoNgayCanhBao As String = ""


    Private strSoNgayThucThi As String = "" 
    Private strMaSoNgayQUanLy As String = ""
    Private strNgayApdung As String = ""
    Private strMaDonViHanhCHinh As String = ""
    Private strDanhSachHoSoCapGCN As String = ""

    Private strMaLoaiHS As String = ""
    Private strLanDieuCHinh As String


    Private strR As String = "0"
    Private strG As String = "0"
    Private strB As String = "0"

    Public Property LanDieuChinh() As String
        Get
            Return strLanDieuCHinh
        End Get
        Set(ByVal value As String)
            strLanDieuCHinh = value
        End Set
    End Property

    Public Property MaLoaiHS() As String
        Get
            Return strMaLoaiHS
        End Get
        Set(ByVal value As String)
            strMaLoaiHS = value
        End Set
    End Property

    Public Property R() As String
        Get
            Return strR
        End Get
        Set(ByVal value As String)
            strR = value
        End Set
    End Property
    Public Property G() As String
        Get
            Return strG
        End Get
        Set(ByVal value As String)
            strG = value
        End Set
    End Property
    Public Property B() As String
        Get
            Return strB
        End Get
        Set(ByVal value As String)
            strB = value
        End Set
    End Property

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhCHinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhCHinh = value
        End Set
    End Property
    Public Property DanhSachHoSoCapGCN() As String
        Get
            Return strDanhSachHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strDanhSachHoSoCapGCN = value
        End Set
    End Property
    Public Property NgayApdung() As String
        Get
            Return strNgayApdung
        End Get
        Set(ByVal value As String)
            strNgayApdung = value
        End Set
    End Property

    Public Property MaSoNgayQUanLy() As String
        Get
            Return strMaSoNgayQUanLy
        End Get
        Set(ByVal value As String)
            strMaSoNgayQUanLy = value
        End Set
    End Property

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


    Public Property SoNgayThucThi() As String
        Get
            Return strSoNgayThucThi
        End Get
        Set(ByVal value As String)
            strSoNgayThucThi = value
        End Set
    End Property


    Public Property MaQuanLy() As String
        Get
            Return strMaQuanLy
        End Get
        Set(ByVal value As String)
            strMaQuanLy = value
        End Set
    End Property
    Public Property STT() As String
        Get
            Return strSTT
        End Get
        Set(ByVal value As String)
            strSTT = value
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
    Public Property TenCongViec() As String
        Get
            Return strTenCongViec
        End Get
        Set(ByVal value As String)
            strTenCongViec = value
        End Set
    End Property
    Public Property SoNgay() As String
        Get
            Return strSoNgay
        End Get
        Set(ByVal value As String)
            strSoNgay = value
        End Set
    End Property
    Public Property TuNgay() As String
        Get
            Return strTuNgay
        End Get
        Set(ByVal value As String)
            strTuNgay = value
        End Set
    End Property
    Public Property DenNgay() As String
        Get
            Return strDenNgay
        End Get
        Set(ByVal value As String)
            strDenNgay = value
        End Set
    End Property
    Public Property BoPhan() As String
        Get
            Return strBoPhan
        End Get
        Set(ByVal value As String)
            strBoPhan = value
        End Set
    End Property
    Public Property CanBo() As String
        Get
            Return strCanBo
        End Get
        Set(ByVal value As String)
            strCanBo = value
        End Set
    End Property

    Public Property DieuChinh() As String
        Get
            Return strDieuChinh
        End Get
        Set(ByVal value As String)
            strDieuChinh = value
        End Set
    End Property
    Public Property SoNgayCanhBao() As String
        Get
            Return strSoNgayCanhBao
        End Get
        Set(ByVal value As String)
            strSoNgayCanhBao = value
        End Set
    End Property
    Private Function Execute(ByVal strStoreProcedureName As String, ByVal paras() As String, ByVal values() As String, ByVal strResults As String) As String
        Try
            'Khoi tao doi tuong clsSqlDatabase
            Dim Database As New clsDatabase
            'Neu ket noi co so du lieu thanh cong
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                If (paras.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(strStoreProcedureName, paras, values, strResults)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    Public Function GetData(ByVal strStoreProcedureName As String, ByVal paras() As String, ByVal values() As String, ByRef records As DataTable) As String
        Try
            'Khoi tao doi tuong DMC.clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnection
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (paras.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Database.getValue(records, strStoreProcedureName, paras, values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    'spSelectThongTinHoSoByDanhSachMaHoSoCapGCN
    Public Function selDanhSachHoSoCapGCNDuocChon() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@MaDonViHanhChinh", "@DanhSachHoSoCapGCN"}
        Dim values() As String = {strMaDonViHanhCHinh, strDanhSachHoSoCapGCN}
        GetData("spSelectThongTinHoSoByDanhSachMaHoSoCapGCN", paras, values, dt)
        Return dt
    End Function

    Public Function selGhiChuMaMau() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaLoaiHS"}
        Dim values() As String = {"4", strMaLoaiHS}
        GetData("spTuDienSoNgayQuanLyQuyTrinh", paras, values, dt)
        Return dt
    End Function

    Public Function selDanhSachSoNgayQuanLy() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaLoaiHS"}
        Dim values() As String = {"0", strMaLoaiHS}
        GetData("spTuDienSoNgayQuanLyQuyTrinh", paras, values, dt)
        Return dt
    End Function

    Public Function InsSoNgayQuanLy(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@MaLoaiHS", "@MaSoNgayQUanLy", "@SoTT", "@TenCongViec", "@SONgayThucTHi", "@NgayApdung", "@BoPhan", "@R", "@G", "@B"}
        Dim values() As String = {"1", strMaLoaiHS, strMaSoNgayQUanLy, strSTT, TenCongViec, strSoNgayThucThi, strNgayApdung, strBoPhan, strR, strG, strB}
        Execute("spTuDienSoNgayQuanLyQuyTrinh", paras, values, strResults)
        Return strResults
    End Function
    Public Function UpSoNgayQuanLy(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@MaSoNgayQUanLy", "@MaLoaiHS", "@SoTT", "@TenCongViec", "@SONgayThucTHi", "@NgayApdung", "@BoPhan", "@R", "@G", "@B"}
        Dim values() As String = {"2", strMaSoNgayQUanLy, strMaLoaiHS, strSTT, TenCongViec, strSoNgayThucThi, strNgayApdung, strBoPhan, strR, strG, strB}
        Execute("spTuDienSoNgayQuanLyQuyTrinh", paras, values, strResults)
        Return strResults
    End Function
    Public Function delSoNgayQuanLy(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@MaSoNgayQUanLy", "@MaLoaiHS", "@SoTT", "@TenCongViec", "@SONgayThucTHi", "@NgayApdung", "@BoPhan", "@R", "@G", "@B"}
        Dim values() As String = {"3", strMaSoNgayQUanLy, strMaLoaiHS, strSTT, TenCongViec, strSoNgayThucThi, strNgayApdung, strBoPhan, strR, strG, strB}
        Execute("spTuDienSoNgayQuanLyQuyTrinh", paras, values, strResults)
        Return strResults
    End Function


    '====================================================================

    Public Function selDanhSachCongViecQuanLy() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaHoSoCapGCN", "@MaLoaiHS", "@MaDonVihanhChinh"}
        Dim values() As String = {"0", strMaHoSoCapGCN, strMaLoaiHS, strMaDonViHanhCHinh}
        GetData("spQuanLyGiaoViecByCanBo", paras, values, dt)
        Return dt
    End Function
    Public Function selLanDieuChinh() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaHoSoCapGCN", "@MaLoaiHS", "@MaDonVihanhChinh"}
        Dim values() As String = {"4", strMaHoSoCapGCN, strMaLoaiHS, strMaDonViHanhCHinh}
        GetData("spQuanLyGiaoViecByCanBo", paras, values, dt)
        Return dt
    End Function
    Public Function InsQuanLyGiaoViec(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@STT", "@MaLoaiHS", "@MaHoSoCapGCN", "@TenCongViec", "@SoNgay", "@TuNgay", "@DenNgay", "@BoPhan", "@CanBo", "@dieuChinh", "@SoNgayCanhBao", "@MaDonVIHanhCHinh", "@SoLanDIeuChinh"}
        Dim values() As String = {"1", strSTT, strMaLoaiHS, strMaHoSoCapGCN, strTenCongViec, strSoNgay, strTuNgay, strDenNgay, strBoPhan, strCanBo, strDieuChinh, strSoNgayCanhBao, strMaDonViHanhCHinh, strLanDieuCHinh}
        Execute("spQuanLyGiaoViecByCanBo", paras, values, strResults)
        Return strResults
    End Function
    Public Function UpQuanLyGiaoViec(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@MaLoaiHS", "@MaQuanLy", "@STT", "@MaHoSoCapGCN", "@TenCongViec", "@SoNgay", "@TuNgay", "@DenNgay", "@BoPhan", "@CanBo", "@dieuChinh", "@SoNgayCanhBao", "@MaDonVIHanhCHinh", "@SoLanDIeuChinh"}
        Dim values() As String = {"2", strMaLoaiHS, strMaQuanLy, strSTT, strMaHoSoCapGCN, strTenCongViec, strSoNgay, strTuNgay, strDenNgay, strBoPhan, strCanBo, strDieuChinh, strSoNgayCanhBao, strMaDonViHanhCHinh, strLanDieuCHinh}
        Execute("spQuanLyGiaoViecByCanBo", paras, values, strResults)
        Return strResults
    End Function
    Public Function delQuanLyGiaoViec(ByRef strResults As String) As String
        Dim paras() As String = {"@flag", "@MaLoaiHS", "@MaQuanLy", "@STT", "@MaHoSoCapGCN", "@TenCongViec", "@SoNgay", "@TuNgay", "@DenNgay", "@BoPhan", "@CanBo", "@dieuChinh", "@SoNgayCanhBao", "@MaDonVIHanhCHinh", "@SoLanDIeuChinh"}
        Dim values() As String = {"3", strMaLoaiHS, strMaQuanLy, strSTT, strMaHoSoCapGCN, strTenCongViec, strSoNgay, strTuNgay, strDenNgay, strBoPhan, strCanBo, strDieuChinh, strSoNgayCanhBao, strMaDonViHanhCHinh, strLanDieuCHinh}
        Execute("spQuanLyGiaoViecByCanBo", paras, values, strResults)
        Return strResults
    End Function

 
    '====================================

    Public Function selDanhSachHoSoCanhBao() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaLoaiHS", "@MaDonViHanhChinh", "@NgayHienThoi"}
        Dim values() As String = {"0", strMaLoaiHS, strMaDonViHanhCHinh, Now}
        GetData("spCanhBaoQuyTrinhHoSo", paras, values, dt)
        Return dt
    End Function
    Public Function selDanhSachHoSoDaGiao() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag", "@MaLoaiHS", "@MaDonViHanhChinh", "@NgayHienThoi"}
        Dim values() As String = {"1", strMaLoaiHS, strMaDonViHanhCHinh, Now}
        GetData("spCanhBaoQuyTrinhHoSo", paras, values, dt)
        Return dt
    End Function

    Public Function selTuDienLuanChuyenHoSo() As DataTable
        Dim dt As New DataTable
        Dim paras() As String = {"@flag"}
        Dim values() As String = {"0"}
        GetData("spSelectTuDienLuanChuyenHoSo", paras, values, dt)
        Return dt
    End Function
End Class
