'Imports DMC.Database
Public Class clsPhanQuyen
    Private ArrUser() As String = {"MaUsers", "Tendangnhap", "MaQuyen", "MatKhau", "NgayTaoUser", "TenDayDu", "Chucvu", "Phongban", "Diachi", "SoDienThoai"}
    Private ArrUserStatus() As String = {"MaUsers", "MaDonViHanhChinh", "NgayPhanQuyen"}
    Private ArrUserChucNang() As String = {"uMaUserChucNang", "MaUsers", "iMaChucNang", "dNgayPhanChucNang"}
    Private ArrTuDienChucNang() As String = {"iMachucnang", "nTenchucnang", "nMotachucnang", "IDGroup"}

    Private strConnection As String = "" ' Khai báo biến chuỗi kết nối cơ sở dữ liệu
    Private strError As String 'Khai báo biến kiểm tra lỗi
    Private shflag As Short
    '-----------------------------------------
    Private strMaUsers As String
    Private strTenDangNhap As String
    Private strMaQuyen As String
    Private strMatKhau As String
    Private strNgayTaoUser As String
    Private strTenDayDu As String
    Private strChucVu As String
    Private strPhongBan As String
    Private strDiaChi As String
    Private strSoDienThoai As String

    '--------------------------------------
    Private strMaDonViHanhChinh As String
    Private strNgayPhanQuyen As String
    '----------------------------------
    Private struMaUserChucNang As String
    Private striMaChucNang As String
    Private strdNgayPhanChucNang As String
    '------------------------------------
    Private strnTenchucnang As String
    Private strnMotachucnang As String
    Private strIDGroup As String

    'Khai báo thuộc tính nhận chuỗi kết nối cơ sở dữ liệu
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

    'Khai bao thuoc tinh ung voi bien
    Public Property flag() As String
        Get
            Return shflag
        End Get
        Set(ByVal value As String)
            shflag = value
        End Set
    End Property

    Public Property MaUser() As String
        Get
            Return strMaUsers
        End Get
        Set(ByVal value As String)
            strMaUsers = value
        End Set
    End Property

    Public Property TenDangNhap() As String
        Get
            Return strTenDangNhap
        End Get
        Set(ByVal value As String)
            strTenDangNhap = value
        End Set
    End Property

    Public Property MaQuyen() As String
        Get
            Return strMaQuyen
        End Get
        Set(ByVal value As String)
            strMaQuyen = value
        End Set
    End Property

    Public Property MatKhau() As String
        Get
            Return strMatKhau
        End Get
        Set(ByVal value As String)
            strMatKhau = value
        End Set
    End Property

    Public Property NgayTaoUser() As String
        Get
            Return strNgayTaoUser
        End Get
        Set(ByVal value As String)
            strNgayTaoUser = value
        End Set
    End Property

    Public Property TenDayDu() As String
        Get
            Return strTenDayDu
        End Get
        Set(ByVal value As String)
            strTenDayDu = value
        End Set
    End Property

    Public Property ChucVu() As String
        Get
            Return strTenDayDu
        End Get
        Set(ByVal value As String)
            strTenDayDu = value
        End Set
    End Property

    Public Property PhongBan() As String
        Get
            Return strPhongBan
        End Get
        Set(ByVal value As String)
            strPhongBan = value
        End Set
    End Property

    Public Property DiaChi() As String
        Get
            Return strPhongBan
        End Get
        Set(ByVal value As String)
            strPhongBan = value
        End Set
    End Property

    Public Property SoDienThoai() As String
        Get
            Return strSoDienThoai
        End Get
        Set(ByVal value As String)
            strSoDienThoai = value
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

    Public Property NgayPhanQuyen() As String
        Get
            Return strNgayPhanQuyen
        End Get
        Set(ByVal value As String)
            strNgayPhanQuyen = value
        End Set
    End Property

    Public Property uMaUserChucNang() As String
        Get
            Return struMaUserChucNang
        End Get
        Set(ByVal value As String)
            struMaUserChucNang = value
        End Set
    End Property

    Public Property iMaChucNang() As String
        Get
            Return striMaChucNang
        End Get
        Set(ByVal value As String)
            striMaChucNang = value
        End Set
    End Property

    Public Property dNgayPhanChucNang() As String
        Get
            Return strdNgayPhanChucNang
        End Get
        Set(ByVal value As String)
            strdNgayPhanChucNang = value
        End Set
    End Property

    Public Property nTenChucNang() As String
        Get
            Return strnTenchucnang
        End Get
        Set(ByVal value As String)
            strnTenchucnang = value
        End Set
    End Property

    Public Property nMoToChucNang() As String
        Get
            Return strnMotachucnang
        End Get
        Set(ByVal value As String)
            strnMotachucnang = value
        End Set
    End Property

    Public Property IDGroup() As String
        Get
            Return strIDGroup
        End Get
        Set(ByVal value As String)
            strIDGroup = value
        End Set
    End Property
End Class
