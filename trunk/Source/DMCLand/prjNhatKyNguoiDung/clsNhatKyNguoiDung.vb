Imports DMC.Database
Imports System.Xml

Public Class clsNhatKyNguoiDung
    Private strConnection As String = ""
    Private strUserName As String = ""
    Private strThoiGian As String = ""
    Private strMaDonViHanhChinh As String = ""
    Private strNghiepVu As String = ""
    Private strChucNang As String = ""
    Private strKetQua As String = ""
    Private strError As String = ""
    Private strMoTa As String = ""
    Private strMaThuaDat As String = ""
    Private strMaHoSoCapGCN As String = ""
    Private strDuongDanFile As String
    Public Property DuongDanFile() As String
        Get
            Return strDuongDanFile
        End Get
        Set(ByVal value As String)
            strDuongDanFile = value
        End Set
    End Property

    Public Property MaThuaDat() As String
        Get
            Return strMaThuaDat
        End Get
        Set(ByVal value As String)
            strMaThuaDat = value
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

    Public Property Connection() As String
        Get
            Return strConnection
        End Get
        Set(ByVal value As String)
            strConnection = value
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
    Public Property ThoiGian() As String
        Get
            Return strThoiGian
        End Get
        Set(ByVal value As String)
            strThoiGian = value
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
    Public Property NghiepVu() As String
        Get
            Return strNghiepVu
        End Get
        Set(ByVal value As String)
            strNghiepVu = value
        End Set
    End Property

    Public Property ChucNang() As String
        Get
            Return strChucNang
        End Get
        Set(ByVal value As String)
            strChucNang = value
        End Set
    End Property
    Public Property KetQua() As String
        Get
            Return strKetQua
        End Get
        Set(ByVal value As String)
            strKetQua = value
        End Set
    End Property
    Public Property MoTa() As String
        Get
            Return strMoTa
        End Get
        Set(ByVal value As String)
            strMoTa = value
        End Set
    End Property
    'Khai báo thuộc tính ứng với biến kiểm tra lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
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

    Public Function SelectAllNhatKySuDung() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {"@flag"}
        Dim values() As String = {0}
        Me.GetData("spNhatKyNguoiDung", dtResults, paras, values)
        Return dtResults
    End Function

    Public Function SelectNhatKySuDungByUser() As DataTable
        Dim dtResults As New DataTable
        Dim paras() As String = {"@flag", "@UserName", "@ThoiGian"}
        Dim values() As String = {2, strUserName, strThoiGian}
        Me.GetData("spNhatKyNguoiDung", dtResults, paras, values)
        Return dtResults
    End Function

    Public Function LuuNhatKyNguoiDung() As String
        Dim paras() As String = {"@flag", "@UserName", "@MaDonViHanhChinh", "@NghiepVu", "@MaThuaDat", "@MaHoSoCapGCN", "@ChucNang", "@KetQua", "@MoTa"}
        Dim values() As String = {1, GetUserName(), strMaDonViHanhChinh, strNghiepVu, strMaThuaDat, strMaHoSoCapGCN, strChucNang, strKetQua, strMoTa}
        strError = Execute("spNhatKyNguoiDung", paras, values, strError)
        Return strError
    End Function

    Public Function GetUserName() As String
        Dim strPathXML As String
        Dim xmlDocument As New XmlDocument
        strPathXML = strDuongDanFile + "\logUser.xml"
        xmlDocument.Load(strPathXML)
        Dim nodelist As XmlNodeList = xmlDocument.DocumentElement.ChildNodes
        If nodelist.Count > 0 Then
            strUserName = nodelist(0).ChildNodes(0).InnerText
        End If
        Return strUserName
    End Function
End Class
