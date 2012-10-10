Imports DMC.Database
Public Class clsRptGCN
    'Khai báo mảng tham số
    Dim Paras() As String = {"@MaHoSoCapGCN"}
    'khai báo biến nhận chuỗi kết nối Database
    Private strConnnection As String = ""
    'Khai báo biến kiểm tra lỗi
    Private strError As String
    'Khai báo biến mã hồ sơ cấp GCN
    Private strMaHoSoCapGCN As String
    'Khai báo thuộc tính nhận chuỗi kết nối Database
    Public WriteOnly Property Connection() As String
        Set(ByVal value As String)
            strConnnection = value
        End Set
    End Property
    'Khai báo thuộc tính nhận thông báo lỗi
    Public ReadOnly Property Err() As String
        Get
            Return strError
        End Get
    End Property
    'Khai báo thuộc tính Mã hồ sơ cấp GCN
    Public WriteOnly Property MaHoSoCapGCN() As String
        Set(ByVal value As String)
            strMaHoSoCapGCN = value
        End Set
    End Property

    Public Function GetData(ByRef records As DataTable) As String
        Try
            'Khai báo và khởi tạo lớp thao tác cơ sở dữ liệu
            Dim Database As New clsDatabase
            'Gán giá trị cho thuộc tính chuỗi kết nối cơ sở dữ liệu
            Database.Connection = strConnnection
            If Database.OpenConnection = True Then
                'Khai báo mảng giá trị
                Dim Values() As String = {strMaHoSoCapGCN}
                'Chắc chắn rằng mảng giá trị truyền vào tương đương với mảng tham biến
                If (Paras.Length <> Values.Length) Then
                    Return "Mảng giá trị chuyền vào chưa phù hợp!"
                End If
                Database.getValue(records, "spSelectRptGCN", Paras, Values)
                Database.CloseConnection()
                strError = ""
            End If
        Catch ex As Exception
            strError = ex.Message
            MsgBox(strError)
        End Try
        Return strError
    End Function
End Class
