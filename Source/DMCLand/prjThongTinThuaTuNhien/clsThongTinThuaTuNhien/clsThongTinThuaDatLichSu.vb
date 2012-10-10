Imports DMC.Database

Public Class clsThongTinThuaDatLichSu
    Dim Paras() As String = {"@xml", "@MaDonViHanhChinh"}
    'Khai báo biến nhận chuỗi kết nối Database
    Private strConnnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    Private strXML As String
    'Private btHinhDangThua As Byte
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnnection = value
        End Set
    End Property
    Private strMaDonViHanhChinh As String = ""

    Public Property MaDonViHanhChinh() As String
        Get
            Return strMaDonViHanhChinh
        End Get
        Set(ByVal value As String)
            strMaDonViHanhChinh = value
        End Set
    End Property
    'Khai bao thuoc tinh ung voi bien
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property

    Public Property XML() As String
        Get
            Return strXML
        End Get
        Set(ByVal value As String)
            strXML = value
        End Set
    End Property

    Private strMaHoSoCapGCNLichSu As String
    Public Property MaHoSoCapGCNLichSu() As String
        Get
            Return strMaHoSoCapGCNLichSu
        End Get
        Set(ByVal value As String)
            strMaHoSoCapGCNLichSu = value
        End Set
    End Property
    ''' <summary>
    ''' Truy vấn thông tin LỊCH SỬ thửa đất
    ''' </summary>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectThongTinLichSu(ByRef dtRecords As DataTable) As String
        Return Me.SelectData("spSelectLichSuThuaDat", dtRecords)
    End Function


    ''' <summary>
    ''' Hàm truy vấn cơ sở dữ liệu
    ''' </summary>
    ''' <param name="strStoreProcedureName"></param>
    ''' <param name="dtRecords"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectData(ByVal strStoreProcedureName As String, ByRef dtRecords As DataTable) As String
        Try
            'Khai báo và khởi tạo đối tượng clsDatabase
            Dim Database As New clsDatabase
            Database.Connection = strConnnection
            If (Database.OpenConnection = True) Then
                'Neu ket noi co so du lieu thanh cong
                'Khai bao mang gia tri
                Dim Values() As String = {strXML, strMaDonViHanhChinh}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Goi phuong thuc GetValue cua doi tuong DMC.clsDatabase
                Database.getValue(dtRecords, strStoreProcedureName, Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function

End Class
