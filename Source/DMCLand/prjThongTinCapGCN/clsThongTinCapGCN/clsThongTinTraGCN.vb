Imports DMC.Database

Public Class clsThongTinTraGCN
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private Paras() As String = {"@MaHoSoCapGCN", "@NgayTraGCN", "@NgayHoanTatGCN", "@TrangThaiTra", "@YKienTraGCN", "@KhoaSoGCN"}

    ' Khai bao bien nhan ve trang thai ho so bien dong
    Dim ParaTrangThaiHS() As String = {"@Flag", "@MaHoSoCapGCN", "@MaDonViHanhChinh"}

    Dim Para() As String = {"@MaHoSoCapGCN"}
    Private strMaHoSoCapGCN As String
    Private strNgayTraGCN As String
    Private strNgayHoanTatGCN As String
    Private strError As String = ""
    Private strFlag As String = ""
    Private strMaDonViHanhChinh As String
    Private strYKienTra As String
    Private strTrangThaiTra As String
    Private strKhoaSoGCN As String = ""

    Public Property KhoaSoGCN() As String
        Get
            Return strKhoaSoGCN
        End Get
        Set(ByVal value As String)
            strKhoaSoGCN = value
        End Set
    End Property

    Public Property TrangThaiTra() As String
        Get
            Return strTrangThaiTra
        End Get
        Set(ByVal value As String)
            strTrangThaiTra = value
        End Set
    End Property
    Public Property YKienTraGCN() As String
        Get
            Return strYKienTra
        End Get
        Set(ByVal value As String)
            strYKienTra = value
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
    Public Property Flag() As String
        Get
            Return strFlag
        End Get
        Set(ByVal value As String)
            strFlag = value
        End Set
    End Property
    'Khai báo thuộc tính nhận chuỗi kết nối Database
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
    'Khai bao thuoc tinh ung voi bien 
    Public Property MaHoSoCapGCN() As String
        Get
            Return strMaHoSoCapGCN
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property
    Public Property NgayTraGCN() As String
        Get
            Return strNgayTraGCN
        End Get
        Set(ByVal value As String)
            strNgayTraGCN = value
        End Set
    End Property
    Public Property NgayHoanTatGCN() As String
        Get
            Return strNgayHoanTatGCN
        End Get
        Set(ByVal value As String)
            strNgayHoanTatGCN = value
        End Set
    End Property

    ''' <summary>
    ''' Thêm mới Thông tin Trả GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function InsertThongInTraGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongInTraGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Cập nhật thông tin Trả GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function UpdateThongTinTraGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spUpdateThongTinTraGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Xóa thông tin Trả GCN
    ''' </summary>
    ''' <returns>Giá trị trả về kiểu String là thông  báo lối nếu có</returns>
    ''' <remarks></remarks>
    Public Function DeleteThongTinTraGCNByMaHoSoCapGCN() As String
        Dim str As String = ""
        Return Me.Execute("spDeleteThongTinTraGCNByMaHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Hàm thực thi phát biếu SQL
    ''' </summary>
    ''' <param name="strStoreProcedureName">Tên thủ tục</param>
    ''' <param name="strRecords"></param>
    ''' <returns>Giá trị trả về là chuỗi lỗi nếu có</returns>
    ''' <remarks></remarks>
    Private Function Execute(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            'Khai báo và khởi tạo đối tượng Database
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối cơ sở dữ liệu thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strNgayTraGCN, strNgayHoanTatGCN, strTrangThaiTra, strYKienTra, strKhoaSoGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
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

    ' Tao ham thuc thi cau lenh SQL 
    Public Function ExcuteTrangThaiHS(ByVal strStoreProcedureName As String, ByRef strRecords As String) As String
        Try
            ' khai bao va khoi tao doi tuong DataBase 
            Dim DataBase As New clsDatabase
            ' Nhan ve chuoi ket noi 
            DataBase.Connection = strConnection
            If DataBase.OpenConnection() = True Then
                Dim ValuesTrangThaiHS() As String = {strFlag, strMaHoSoCapGCN, strMaDonViHanhChinh}
                If (ValuesTrangThaiHS.Length <> ParaTrangThaiHS.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If

                ' Goi phuong thuc thuc thi cau lenh SQL 
                DataBase.ExecuteSP(strStoreProcedureName, ParaTrangThaiHS, ValuesTrangThaiHS, strRecords)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If

        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Tao phuong thuc thuc thi cap nhat trang thai ho so
    Public Function UpdateTrangThaiHS() As String
        Dim str As String = ""
        Return Me.ExcuteTrangThaiHS("spUpdateTrangThaiHoSoCapGCN", str)
    End Function

    ''' <summary>
    ''' Phương thức truy vấn cơ sở dữ liệu
    ''' </summary>
    ''' <param name="dtResults">Bảng dữ liệu trả về từ câu truy vấn</param>
    ''' <returns>Giá trị trả về kiểu String là thông báo lỗi nếu có</returns>
    ''' <remarks></remarks>
    Public Function GetData(ByRef dtResults As DataTable) As String
        Dim strError As String = ""
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            'Nhận chuỗi kết nối Database
            Database.Connection = strConnection
            'Nếu kết nối thành công
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = _
                    {strMaHoSoCapGCN, strNgayTraGCN, strNgayHoanTatGCN, strTrangThaiTra, strYKienTra, strKhoaSoGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức Truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinTraGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

    ' Ham lay ve thong tin TrangThaiHSCapGCN
    Public Function GetTrangThaiHS(ByRef dtResult As DataTable) As String
        Try
            ' Khai bao va khoi tao doi tuong ket noi DataBase 
            Dim DataBase As New clsDatabase
            ' Nhan ve chuoi ket noi 
            DataBase.Connection = strConnection
            If DataBase.OpenConnection() = True Then
                Dim ValuesTrangThaiHS() As String = {strMaHoSoCapGCN}
                If (ValuesTrangThaiHS.Length <> ParaTrangThaiHS.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                ' Goi phuong thuc truy van den DataBase nhan ve du lieu
                DataBase.getValue(dtResult, "", Para, ValuesTrangThaiHS)
                strError = DataBase.Err
                DataBase.CloseConnection()
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
