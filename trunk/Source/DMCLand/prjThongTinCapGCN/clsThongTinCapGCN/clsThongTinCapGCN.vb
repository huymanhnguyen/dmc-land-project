Imports DMC.Database
Public Class clsThongTinCapGCN
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private ParaSelectNguoiLap() As String = {"@flag"}
    Private ParaXoaNguoiLap() As String = {"@flag", "@MaNguoiLap"}
    Private ParaktNguoiLap() As String = {"@flag", "@HoTen"}
    Private ParaInsertNguoiLap() As String = {"@flag", "@MaNguoiLap", "@HoTen", "@GioiTinh", "@ChucVu"}
    'Private ParaSelectThongTinCSD() As String = {"@flag", "@MaHoSoCapGCN"}

    Private strError As String = ""
    Private shflag As Short
    Private strMaHoSoCapGCN As String

    Private strMaTongHop As String = ""
    '================================
    Private strNguoilap As String = ""
    Private strHoTen As String = ""
    Private strGioiTinh As String = ""
    Private strMaNguoilap As String = ""
    Private strChucVu As String = ""

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

    'Khai bao thuoc tinh ung voi bien shFlag
    Public Property flag() As String
        Get
            Return shflag
        End Get
        Set(ByVal value As String)
            If value > 3 And value < 0 Then
                value = 0
            End If
            shflag = value
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

    Public Property MaTongHop() As String
        Get
            Return strMaTongHop
        End Get
        Set(ByVal value As String)
            strMaTongHop = value
        End Set
    End Property

    Public Property Nguoilap() As String
        Get
            Return strNguoilap
        End Get
        Set(ByVal value As String)
            strNguoilap = value
        End Set
    End Property
    Public Property HoTen() As String
        Get
            Return strHoTen
        End Get
        Set(ByVal value As String)
            strHoTen = value
        End Set
    End Property
    Public Property MaNguoilap() As String
        Get
            Return strMaNguoilap
        End Get
        Set(ByVal value As String)
            strMaNguoilap = value
        End Set
    End Property
    Public Property ChucVu() As String
        Get
            Return strChucVu
        End Get
        Set(ByVal value As String)
            strChucVu = value
        End Set
    End Property
    Public Property GioiTinh() As String
        Get
            Return strGioiTinh
        End Get
        Set(ByVal value As String)
            strGioiTinh = value
        End Set
    End Property

    Public Function GetData_SP(ByVal sp As String, ByVal Values() As String, ByVal paras() As String) As DataTable
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
    Public Function SelectNguoiLap() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {shflag}
            dt = GetData_SP("sp_NguoiLapBieu", Values, ParaSelectNguoiLap)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
    Public Function ktNguoiLap() As DataTable
        Dim dt As New DataTable
        Dim strError As String = ""
        Try
            Dim Values() As String = {shflag, strHoTen}
            dt = GetData_SP("sp_NguoiLapBieu", Values, ParaktNguoiLap)
            strError = ""
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return dt
    End Function
  
    'ham thuc thi cac cau lenh them moi, sua , xoa
    Public Function Execute_GCN(ByVal sp As String, ByVal para() As String, ByVal values() As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Neu ket noi co so du lieu thanh cong
            If Database.OpenConnection = True Then
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (para.Length <> values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Dim records As String = ""
                'Goi phuong thuc ExecuteSP cua doi tuong clsSQLDatabase
                Database.ExecuteSP(sp, para, values, records)
                strError = Database.Err
                Database.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
    'Xoa Cap GCN
    Public Function ThemNguoiLap() As String
        Dim Values() As String = {shflag, strMaNguoilap, strHoTen, GioiTinh, strChucVu}
        Return Execute_GCN("sp_NguoiLapBieu", ParaInsertNguoiLap, Values)
    End Function
    Public Function SuaNguoiLap() As String
        Dim Values() As String = {shflag, strMaNguoilap, strHoTen, GioiTinh, strChucVu}
        Return Execute_GCN("sp_NguoiLapBieu", ParaInsertNguoiLap, Values)
    End Function
    Public Function XoaNguoiLap() As String
        Dim Values() As String = {shflag, strMaNguoilap}
        Return Execute_GCN("sp_NguoiLapBieu", ParaXoaNguoiLap, Values)
    End Function
   
End Class
