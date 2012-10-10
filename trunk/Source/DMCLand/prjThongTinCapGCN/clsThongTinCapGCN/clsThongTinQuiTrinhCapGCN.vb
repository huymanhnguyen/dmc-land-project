Imports DMC.Database

Public Class clsThongTinQuiTrinhCapGCN
    Private strConnection As String = ""
    'Khai báo biến kiểm tra lỗi 
    Private Paras() As String = {"@MaHoSoCapGCN"}

    Private strMaHoSoCapGCN As String

    Private strError As String = ""
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
                    {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                'Gọi phương thức Truy vấn cơ sở dữ liệu
                Database.getValue(dtResults, "spSelectThongTinQuiTrinhCapGCNByMaHoSoCapGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
        End Try
        Return strError
    End Function
End Class
